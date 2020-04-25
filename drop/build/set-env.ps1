# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.
Param(
    [Switch]
    $AsOutput
)

# Detect if we're running on Azure Pipelines.
$script:IsAzurePipelines = "$Env:TF_BUILD" -ne "";
Write-Host "-> Running on Azure Pipelines? $script:IsAzurePipelines"

###
# Decides if this is a quickbuild. In a quickbuild, certain feature flags are disabled, regardless
# if the flag is explicitly set. This allows to quickly turn off all the non-esential features 
# to make the build complete faster.
#
# A quickbuild is triggered if:
#   1. $Env:BUILD_QUICK == "true"
#   2. $Env:BUILD_REASON is CI (IndividualCI or BatchedCI)
##
function Get-Quickbuild() {
    if ($Env:BUILD_QUICK -eq "true") {
        Write-Host "-> Running quickbuild since Env:BUILD_QUICK is set to '$Env:BUILD_QUICK'."
        $true
    } elseif (($Env:BUILD_REASON -eq "IndividualCI") -or ($Env:BUILD_REASON -eq "BatchedCI")) {
        $Env:BUILD_QUICK=$null
        $branch = $Env:BUILD_SOURCEBRANCH.Replace("refs/heads/","")
        if ("master" -ne $branch) {
            Write-Host "-> Running quickbuild since running CI build in branch '$branch'."
            $true
        } else {
            $false
        }
    } else {
        $false
    }
}

# Define a set of variables that we aren't allowed to set so that we can raise
# warnings rather than killing a build.
$script:ReadOnlyVariables = @{
    "build.buildnumber" = $true;
    "build.sourcebranch" = $true;
};

<#
    .SYNOPSIS
        Sets the value of one environment variable.
        If the value is already set, just prints it, otherwise
        it sets it to the given defaultValue.

        Note: After the value is set, it will be available for all build steps and jobs that come afterwards.
#>
function Set-OneVariable() {
    param(
        [string]$raw,
        [string]$defaultValue,
        [bool]$secret = $false
    )

    

    $name = ($raw.ToUpper()) -replace "\.", "_"

    if (Test-Path -Path Env:$name) {
        if ($AsOutput) { 
            # When running on Azure Pipelines instead of on a local build, we can't
            # set some variables.
            if ($script:IsAzurePipelines -and $script:ReadOnlyVariables.ContainsKey($raw.ToLowerInvariant())) {
                Write-Host "== $raw is a read-only variable, skipping.";
            } else {
                $value = (Get-Item -Path Env:$name).Value
                Write-Host "##vso[task.setvariable variable=$raw;isOutput=true]$value" 
            }
        }

        $value = if ($secret) { "*****" } else { (Get-Item -Path Env:$name).Value }
        Write-Host "  == $name ($raw) :: '$value'"
    } else {
        Set-Item -Path Env:$name -Value $defaultValue
        $isOutput = if ($AsOutput) { ";isOutput=true"} else { "" }
        Write-Host "##vso[task.setvariable variable=$raw$isOutput]$defaultValue"
        $value = if ($secret) { "*****" } else { $defaultValue }
        Write-Host "  ++ $name ($raw) :: '$value'"
    }
}

###
# Sets a build flag.
# Build flags control whether certain build steps (Tests/Conda/Docker/etc) are enabled.
# Only non-quickbuilds can control these flags, for everything else (CI/PR/etc) the flags are always "true".
###
function Set-OneFlag() {
    param(
        [string]$flag,
        [string]$defaultValue = "true"
    )

    if (-not $quickBuild) {
        Set-OneVariable $flag $defaultValue
    } else {
        $name = (($flag.ToUpper()) -replace "\.", "_")
        Set-Item -Path Env:$name -Value $defaultValue
        $isOutput = if ($AsOutput) { ";isOutput=true"} else { "" }
        Write-Host "##vso[task.setvariable variable=$flag$isOutput]$defaultValue"
        Write-Host "  !! $name ($flag) :: '$defaultValue'"
    }
}


###
# Sets the value of the given variable and then creates
# the folder corresponding to the value of the variable if it doesn't exist
###
function Set-OneFolder() {
    param(
        [string]$raw,
        [string]$defaultValue
    )

    Set-OneVariable $raw $defaultValue
    $name = ($raw.ToUpper()) -replace "\.", "_"
    $path = (Get-Item -Path Env:$name).Value
    If (-not (Test-Path -Path $path)) { 
        Write-Host "--> Creating folder $path"
        $_ = [IO.Directory]::CreateDirectory($path) 
    }
}

###
# Selects the suffix to add to nuget packages.
# If it's a build targeting `master` or a `hotfix/*` branch then it selects no suffix (i.e. they will be release packages),
# otherwise it uses `-beta`.
# If the build is for a PullRequest or the BUILD_SOURCEBRANCH is not specified, it selects `-alpha`
###
function Get-ReleaseType() {
    if ($Env:BUILD_REASON -eq 'PullRequest') {
        $Env:BUILD_RELEASETYPE=$null
        Write-Host "-> Running a PullRequest build. Creating 'pull' release."
        "pull"
    } elseif ($null -ne $Env:BUILD_RELEASETYPE) {
        Write-Host "-> Creating '$Env:BUILD_RELEASETYPE' release based on Env:BUILD_RELEASETYPE."
        $Env:BUILD_RELEASETYPE
    } elseif ($null -eq $Env:BUILD_SOURCEBRANCH) {
        Write-Host "##vso[task.logissue type=warning;]BUILD_SOURCEBRANCH is missing. Creating alpha versions."
        "alpha"
    } else {
        $branch = $Env:BUILD_SOURCEBRANCH.Replace("refs/heads/","")
        Write-Host "-> Creating beta versions for branch '$branch'."
        "beta"
    }
}

function Get-CurrentBranch() {
    $current = git branch --show-current
    if  ($LastExitCode -ne 0) {
        Write-Host "-> Not on a branch!"
    }
    $current
}

##
# If $Env:GITHUB_PAT is set, creates the parameters to git command that needs to be added for
# Authorization to push changes to origin.
#
# The GITHUB_PAT should be the base64 encoded value of the string "pat:<GITHUB-PAT>" where 
#   <GITHUB-PAT> is a Personal Access Token generated in github.com
##
function Get-GitExtraHeader() {
    if ($null -ne $Env:BUILD_GITEXTRAHEADER) {
        $Env:BUILD_GITEXTRAHEADER
    } elseif ($null -eq $Env:GITHUB_PAT) {
        Write-Host "Env:GITHUB_PAT is not set. Will not provide custom AUTH header to git push commands."
        "http.none="
    } else {
        Write-Host "-> Using GITHUB_PAT for pushing changes."
        "http.https://github.com.extraheader=""AUTHORIZATION: basic $Env:GITHUB_PAT"""
    }
}

Write-Host "# Setting up build environment variables."



# Select the nuget & python suffix based on the release type:
$releaseType = Get-ReleaseType
$quickBuild  = Get-Quickbuild
$currentBranch = Get-CurrentBranch
$nugetLabel  = if ($releaseType -eq "release") { "" } else { "-$releaseType" }
$pythonLabel = if ($releaseType -eq "release") { "" } elseif ($releaseType -eq "beta") { "b1" } else { "a1" }

Set-OneVariable "Build.Buildnumber"     "0.0.1.0"
Set-OneVariable "Build.Configuration"   "Release"
Set-OneVariable "Build.Verbosity"       "minimal"
Set-OneVariable "Build.ReleaseType"     $releaseType
Set-OneVariable "Build.Tag"             "$Env:BUILD_RELEASETYPE/v$Env:BUILD_BUILDNUMBER"
Set-OneVariable "Build.SourceBranch"    $currentBranch
Set-OneVariable "Build.Aria.Version"    "0.92.6"
Set-OneVariable "Build.Dotnet.Version"  "3.1.x"
Set-OneVariable "Build.NuGet.Version"   "4.9.3"
Set-OneVariable "Build.Python.Version"  "3.7"
Set-OneVariable "Build.GitExtraHeader"  (Get-GitExtraHeader) $true
Set-OneVariable "Assembly.Version"      $Env:BUILD_BUILDNUMBER
Set-OneVariable "Nuget.Version"         ($Env:ASSEMBLY_VERSION + $nugetLabel)
Set-OneVariable "Python.Version"        ($Env:ASSEMBLY_VERSION + $pythonLabel)
Set-OneVariable "Docker.Prefix"         ""


Set-OneVariable "Enable.Push.Branches"  "false"
# These features are disabled when running a quickbuild (CI)
$enabled = if ($quickBuild) { "false" } else { "true" }
Set-OneFlag "Enable.Conda"    $enabled
Set-OneFlag "Enable.Docker"   $enabled
Set-OneFlag "Enable.Katas"    $enabled
Set-OneFlag "Enable.Perf"     $enabled
Set-OneFlag "Enable.Python"   $enabled
Set-OneFlag "Enable.Samples"  $enabled
Set-OneFlag "Enable.Tests"    $enabled
Set-OneFlag "Enable.VSIX"     $enabled

Set-OneFolder "Tools.Dir"       ([IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".tools")))
Set-OneFolder "Blobs.Outdir"    ([IO.Path]::GetFullPath((Join-Path $PSScriptRoot ".blobs")))
Set-OneFolder "Drops.Dir"       ([IO.Path]::GetFullPath((Join-Path $PSScriptRoot "..\drops")))
Set-OneFolder "Nuget.Outdir"    (Join-Path $Env:DROPS_DIR "nugets")
Set-OneFolder "Python.Outdir"   (Join-Path $Env:DROPS_DIR "wheels")
Set-OneFolder "VSIX.Outdir"     (Join-Path $Env:DROPS_DIR "vsix")
Set-OneFolder "Images.Outdir"   (Join-Path $Env:DROPS_DIR "images")
Set-OneFolder "Docs.Outdir"     (Join-Path $Env:DROPS_DIR "docs")

exit 0
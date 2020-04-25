# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

$all_ok = $True

if ($PSVersionTable.PSEdition -eq "Desktop") {
    $IsWindows = $true;
}

if ($IsWindows) {
    $RuntimeID = "win-64";
} elseif ($IsLinux) {
    $RuntimeID = "linux-64";
} elseif ($IsMacOS) {
    $RuntimeID = "osx-64";
}

# Only test the qsharp package in pthon 3.7... it transitive validates iqsharp too.
$drop    = (Resolve-Path "../../drops/conda/$RuntimeID")
$package = (dir $drop -Filter "qsharp*-py37*.tar.bz2").Name

$package -match '^qsharp-(.+)-py37'
$version = $matches[1]
$env     = "_test_$version"

Write-Host "Using package $package, with version $version, found in drop folder $drop"

# Start by removing iqsharp kernel if installed:
conda env remove -n $env
jupyter kernelspec list
jupyter kernelspec remove iqsharp

# Create qsharp environment:
conda create -y -n $env -c ../../drops/conda python==3.7 pytest qsharp==$version
conda activate $env

# Report list of kernels
jupyter kernelspec list
pytest --doctest-modules --junitxml=junit/test-results.xml

# Check for success.
if  ($LastExitCode -ne 0) {
    Write-Host "##vso[task.logissue type=error;]Conda package tests failed: qsharp==$version"
    $script:all_ok = $False
}

conda deactivate
conda env remove -n $env


if (-not $all_ok) 
{
    throw "Conda package tests failed. Check the logs."
}


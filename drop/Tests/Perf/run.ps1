# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.
param(
    [string] $DocumentDbKey = "",
    [string] $IgnoreValidation = ""
);


Push-Location (Join-Path $PSScriptRoot "qperf") 
    Write-Host "##vso[info]Starting performance run."
    dotnet run -- $DocumentDbKey $IgnoreValidation
Pop-Location



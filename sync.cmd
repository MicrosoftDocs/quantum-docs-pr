::
:: This script syncs api\prelude and api\canon with the build output
:: 
call :prepare
call :build
call :updateOne Solid\src\Quantum.Primitives api\prelude
REM call :updateOne Libraries\Microsoft.Quantum.Canon api\canon

git commit -m "Updating from script."
git push
EXIT /B


::
:: Prepares the repo for building
::
:prepare
git submodule foreach git checkout origin/master
Solid\bin\nuget restore Solid\src\Qflat.sln
Solid\bin\nuget restore Libraries\QsharpLibraries.sln
EXIT /B

::
:: builds docgen and the yaml files
::
:build
msbuild Solid\src\qflat\docgen
msbuild /t:clean Solid\src\Quantum.Primitives
msbuild /t:clean Libraries\Microsoft.Quantum.Canon
msbuild /t:QsharpDocgen Solid\src\Quantum.Primitives
msbuild /t:QsharpDocgen Libraries\Microsoft.Quantum.Canon
EXIT /B

::
:: Updates one docs api folder
::
:updateOne
set source=%1
set target=%2
git rm %target%\*
xcopy %source%\obj\qsharp\docs %target% /I
git add %target%
EXIT /B
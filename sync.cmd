::
:: This script syncs api\prelude and api\canon with the build output
:: 
call :updateOne Solid\src\Quantum.Primitives api\prelude
call :updateOne Libraries\Microsoft.Quantum.Canon api\canon

git commit -m "Updating from script."
git push
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

# Building this repo:


  * Update all submodules to master: `git submodule foreach git checkout origin/master`
  * nuget restore 
  * Build `Solid\src\qflat\docgen`
  * Generate docs:
    - `msbuild /t:QsharpDocgen Solid\src\Quantum.Primitives`
    - `msbuild /t:QsharpDocgen Libraries\Microsoft.Quantum.Canon`
  * Run 

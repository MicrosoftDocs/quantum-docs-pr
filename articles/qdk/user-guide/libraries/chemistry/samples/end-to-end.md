---
title: Sample NWChem quantum program
description: Using an NWChem input deck, walk through an example of getting gate counts for quantum chemistry simulation.
author: cgranade
ms.author: chgranad@microsoft.com
ms.date: 10/23/2018
uid: microsoft.quantum.chemistry.examples.endtoend
---

# End-to-end with NWChem #

In this article, you will walk through an example of getting gate counts for quantum chemistry simulation, starting from an [NWChem](http://www.nwchem-sw.org/index.php/Main_Page) input deck.
Before proceeding with this example, make sure that you've installed Docker, following the [installation and validation guide](xref:microsoft.quantum.chemistry.concepts.installation).

For more information:
- [Structure of NWChem input decks](https://github.com/nwchemgit/nwchem/wiki/Getting-Started#input-file-structure)
    - [Input deck commands for use with the Quantum Development Kit](https://github.com/nwchemgit/nwchem/tree/master/contrib/quasar)
- [Installing the chemistry library and dependencies](xref:microsoft.quantum.chemistry.concepts.installation)
- [Resource counting](xref:microsoft.quantum.chemistry.examples.resourcecounts)

> [!NOTE]
> This example requires Windows PowerShell Core to run.
> Download PowerShell Core for Windows, macOS, or Linux at https://github.com/PowerShell/PowerShell.

## Importing Required PowerShell Modules ##

If you haven't already done so, clone the [Microsoft/Quantum repository](https://github.com/Microsoft/Quantum), which contains samples and utilities for working with the Quantum Development Kit:

```powershell
git clone https://github.com/Microsoft/Quantum
```

Once you've cloned `Microsoft/Quantum`, perform `cd` into the `utilities/` folder and import the PowerShell module for working with Docker and NWChem:

```powershell
cd utilities
Import-Module InvokeNWChem.psm1
```

> [!NOTE]
> By default, Windows prevents the execution of any scripts or modules as a security measure.
> To allow modules such as `Invoke-NWChem.psm1` to run on Windows, you may need to change the execution policy.
> To do so, run the `Set-ExecutionPolicy` command:
> ```powershell
> Set-ExecutionPolicy RemoteSigned -Scope Process
> ```
> The execution policy will then be reverted when you exit PowerShell.
> If you would like to save the execution policy, use a different value for `-Scope`:
> ```powershell
> Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
> ```

You should now have the `Convert-NWChemToBroombridge` command available:

```powershell
Get-Command -Module InvokeNWChem
```

Next, we'll import the `Get-GateCount` command provided with the **GetGateCount** sample.
For full details, see the [instructions provided with the sample](https://github.com/Microsoft/Quantum/tree/master/samples/chemistry/GetGateCount).
Next, run the following, substituting `<runtime>` with either `win10-x64`, `osx-x64`, or `linux-x64`, depending on your operating system:

```powershell
cd ../Chemistry/GetGateCount
dotnet publish --self-contained -r <runtime>
Import-Module ./bin/Debug/netcoreapp2.1/<runtime>/publish/get-gatecount.dll
```

You should now have the `Get-GateCount` command available:

```powershell
Get-Command Get-GateCount
```

## Input Decks ##

The NWChem package takes a text file called an _input deck_ which specifies a quantum chemistry problem to be solved, along with other parameters such as memory allocation settings.
For this example, we'll use one of the pre-made input decks that comes with NWChem.
First, clone the [nwchemgit/nwchem repository](https://github.com/nwchemgit/nwchem):

> [!NOTE]
> Since this is a very large repository, we can do a shallow clone to save some bandwidth and disk space, using the `--depth 1` argument.
> This is optional, however.
> Cloning will work just fine without `--depth 1`.

```powershell
git clone https://github.com/nwchemgit/nwchem --depth 1
```

The `nwchemgit/nwchem` repository comes with a variety of input decks intended for use with the Quantum Development Kit, listed under the [`QA/chem_library_tests` folder](https://github.com/nwchemgit/nwchem/tree/master/QA/chem_library_tests).
For this example, we'll use the `H4` input deck:

```powershell
cd nwchem/QA/chem_library_tests/H4
Get-Content h4_sto6g_0.000.nw
```

The molecule in question is a system of 4 hydrogen atoms that are arranged in a certain geometry that depends on one angle, the parameter `alpha` as indicated in the name `h4_sto6g_alpha.nw` of the deck. H4 is a known [molecular benchmark](https://onlinelibrary.wiley.com/doi/abs/10.1002/qua.560180511) for computational chemistry since the 1970s. The parameter `sto6g` is indicative that the deck implements a representation with respect to a Slater-type orbital, specifically, a representation with respect to an [STO-nG basis set](https://en.wikipedia.org/wiki/STO-nG_basis_sets) with 6 Gaussian basis functions. This input deck furthermore contains several instructions to the NWChem Tensor Contraction Engine (TCE) that direct NWChem to produce the information needed for interoperating with the Quantum Development Kit:

```
...
set tce:print_integrals T
set tce:qorb 18
set tce:qela  9
set tce:qelb  9
```

## Producing and Consuming Broombridge Output from NWChem ##

You now have everything you need to produce and consume Broombridge documents.
To run NWChem and produce a Broombridge document for the `h4_sto6g_0.000.nw` input deck, run `Convert-NWChemToBroombridge`:

> [!NOTE]
> The first time you run this command, Docker will download the `nwchemorg/nwchem-qc` image for you.
> This may take a little while, depending on your connection speed, possibly providing an opportunity to get a cup of coffee.

```powershell
Convert-NWChemToBroombridge h4_sto6g_0.000.nw 
```

This will produce a Broombridge document called `h4_sto6g_0.000.yaml` that you can use with `Get-GateCount`:

```powershell
Get-GateCount -Format YAML h4_sto6g_0.000.yaml
```

You should now see console output which contains resource estimation such as T-count, rotations count, CNOT count, etc. for various quantum simulation methods:

```powershell 
IntegralDataPath    : C:\Users\martinro\REPOS\nwchem\qa\chem_library_tests\h4\h4_sto6g_0.000.yaml
HamiltonianName     : hamiltonian_0
SpinOrbitals        : 8
Method              : Trotter
TCount              : 0
RotationsCount      : 92
CNOTCount           : 520
ElapsedMilliseconds : 327

IntegralDataPath    : C:\Users\martinro\REPOS\nwchem\qa\chem_library_tests\h4\h4_sto6g_0.000.yaml
HamiltonianName     : hamiltonian_0
SpinOrbitals        : 8
Method              : Qubitization
TCount              : 438
RotationsCount      : 516
CNOTCount           : 2150
ElapsedMilliseconds : 528

IntegralDataPath    : C:\Users\martinro\REPOS\nwchem\qa\chem_library_tests\h4\h4_sto6g_0.000.yaml
HamiltonianName     : hamiltonian_0
SpinOrbitals        : 8
Method              : Optimized Qubitization
TCount              : 3540
RotationsCount      : 18
CNOTCount           : 7932
ElapsedMilliseconds : 721
```

There are many things to go do from here: 
- Try out different predefined input decks, e.g., by varying the parameter `alpha` in `h4_sto6g_alpha.nw`, 
- Try modifying the decks by editing the NWChem decks directly, e.g., exploring `STO-nG` models for various choices of n, 
- Try other predefined NWChem input decks that are available at `nwchem/qa/chem_library_tests`,
- Try out a suite of predefined Broombridge YAML benchmarks that were generated from NWChem and are available as part of the [Microsoft/Quantum repository](https://github.com/Microsoft/Quantum/tree/master/samples/chemistry/IntegralData/YAML). These benchmarks include: 
    - small molecules such as molecular hydrogen (H2), Beryllium (Be), Lithium hydride (LiH),
    - larger molecules such as ozone (O3), beta-carotene, cytosine, and many more. 
- Try out the graphical front-end [EMSL Arrows](https://arrows.emsl.pnnl.gov/api/qsharp_chem) that features an interface to the Microsoft Quantum Development Kit. 


## Producing Broombridge Output from EMSL Arrows ##

To get started with web-based front end EMSL Arrows, navigate a browser [here](https://arrows.emsl.pnnl.gov/api/qsharp_chem). 

> [!NOTE]
> Running EMSL Arrows in a web browser requires JavaScript to be enabled. Please refer to these [instructions](https://www.enable-javascript.com/) on how to enable JavaScript in your browser. 

First, enter a molecule in the query box that says ``Enter an esmiles, esmiles reaction, or other Arrows input, then push the "Run Arrows" button.`` 

You can enter many molecules by their colloquial name, such as "caffeine" instead of "1,3,7-Trimethylxanthine". 

Next, click the button that says ``theory{qsharp_chem}``. This will populate the query box further with an instruction that will tell the run to export output in the Broombridge YAML format. 

Now, clock on ``Run Arrows``. Depending on the size of the input, this might take a while. Or, in case the particular model has already been computed before, it can be done extremely fast as it will only amount to a lookup in a database. In either case, you will be taken to a new page that contains a plethora of information about the particular run of NWChem against the deck specified by your input. 

You can download and save the Broombridge YAML file from the section that starts with the following header: 
```powershell
+==================================================+
||              Molecular Calculation             ||
+==================================================+

Id     = 48443

NWOutput = Link to NWChem Output (download)

Datafiles:
qsharp_chem.yaml-2018-10-23-14:37:42 (download)
...
```

Click on ``download``, which saves a local copy with a unique file name such as ``qsharp_chem48443.yaml`` (the particular name will be different for each run). You can then further process this file as above, e.g., with 
```powershell
Get-GateCount -Format YAML qsharp_chem48443.yaml
```
to get resource counts. 

You might enjoy the 3D molecule builder that can be accessed from the ``Arrows Entry - 3D Builder`` tab on the EMSL Arrows start page. Clicking the [JSMol](http://wiki.jmol.org/index.php/JSmol) 3D picture of the shown molecule will let you allow to edit it. You can move atoms around, drag atoms apart so that their inter-molecular distances change, add/remove atoms, etc. For each of these choices, once you added ``theory{qsharp_chem}`` in the query box, you can then generate an instance of the Broombridge YAML schema and further explore it using the Quantum Chemistry Library. 

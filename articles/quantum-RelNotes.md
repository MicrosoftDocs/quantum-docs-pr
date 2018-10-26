---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Quantum Development Kit preview release notes| Microsoft Docs 
description: Quantum Development Kit preview release notes
author: QuantumWriter
ms.author: Alan.Geller@microsoft.com 
ms.date: 10/09/2017
ms.topic: article
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# For Quantum products none of these categories have been defined  yet.
# ms.service: service-name-from-white-list
# ms.prod: product-name-from-white-list
# ms.technology: tech-name-from-white-list
---

# Microsoft Quantum Development Kit Preview Release Notes

# Version 0.2.1809.701

*Release date: September 10, 2018*

This release includes bug fixes for issues reported by the community. Including:

* Unable to use shift operator ([GitHub](https://github.com/Microsoft/Quantum/issues/75)).
* `DumpMachine` / `DumpRegister` fails on `QCTraceSimulator` when printing to console ([UserVoice](https://quantum.uservoice.com/forums/906946/suggestions/34709680)).
* Allow allocating 0 qubits ([UserVoice](https://quantum.uservoice.com/forums/906208-q-language/suggestions/34768069-allow-allocating-0-qubits)).
* `AssertQubitState` requires explicit Complex() call ([UserVoice](https://quantum.uservoice.com/forums/906208-q-language/suggestions/34713733-assertqubitstate-requires-explicit-complex-call)).
* `Measure` operation always returns `One` on macOS ([UserVoice](https://quantum.uservoice.com/forums/906940/suggestions/35008546)).

Thanks! 

# Version 0.2.1806.3001

*Release date: June 30, 2018*

This releases is just a quick fix for [issue #48 reported on GitHub](https://github.com/Microsoft/Quantum/issues/48) (Q# compilation fails if user name contains a blank space). Follow same update instructions as `0.2.1806.1503` with the corresponding new version (`0.2.1806.3001-preview`).


# Version 0.2.1806.1503

*Release date: June 22, 2018*

This release includes several community contributions as well as an improved debugging experience and improved performance.  Specifically:

* Performance improvements on both small and large simulations for the QuantumSimulator target machine.
* Improved debugging functionality.
* Community contributions in bug fixes, new helper functions, operations and new samples.


### Performance improvements ###

This update includes significant performance improvements for simulation of large and small numbers of qubits for all the target machines.  This improvement is easily visible with the H<sub>2</sub> simulation that is a standard sample in the Quantum Development Kit.


### Improved debugging functionality ###

This update adds new debugging functionality:
* Added two new operations,  @"microsoft.quantum.extensions.diagnostics.dumpmachine" and @"microsoft.quantum.extensions.diagnostics.dumpregister" that output wave function information about the target quantum machine at a point in time.  
* In Visual Studio, the probability of measuring a $\ket{1}$ on a single qubit is now automatically shown in the debugging window for the QuantumSimulator target machine.
* In Visual Studio, improved the display of variable properties in the **Autos** and **Locals** debug windows. 

Learn more about [Testing and Debugging](quantum-techniques-TestingAndDebugging.md).


### Community Contributions ###

The Q# coder community is growing and we are thrilled to see the first user contributed libraries and samples that were submitted to our open code base at http://github.com/Microsoft/quantum.  **A big Thank you!** to the following contributors:
* Mathias Soeken ([@msoeken](https://github.com/msoeken)):  contributed a sample defining a transformation based logic synthesis method that constructs Toffoli networks to implement a given permutation. The code is written entirely in Q# functions and operations.  [PR #41](https://github.com/Microsoft/Quantum/pull/41).
* RolfHuisman ([@RolfHuisman](https://github.com/RolfHuisman)): Microsoft MVP Rolf Huisman contributed a sample that generates flat QASM code from Q# code for a restricted class of programs that do not have classical control flow and restricted quantum operations. [PR #59](https://github.com/Microsoft/Quantum/pull/59)
* Sarah Kasier ([@crazy4pi314](https://github.com/crazy4pi314)): helped to improve our code base by submitting a library function for controlled operations. [PR #53](https://github.com/Microsoft/Quantum/pull/53)
* Jessica Lemieux ([@Lemj3111](https://github.com/Lemj3111)): fixed @"microsoft.quantum.canon.quantumphaseestimation" and created new unit tests.  [PR #54](https://github.com/Microsoft/Quantum/pull/54)
* Tama McGlinn ([@TamaHobbit](https://github.com/TamaHobbit)): cleaned the Teleportation sample by making sure the QuantumSimulator instance is disposed. [PR #20](https://github.com/Microsoft/Quantum/pull/20)

Additionally, a big **Thank You!** to these Microsoft Software Engineers from the Commercial Engineering Services team contributors who made valuable changes to our documentation during their Hackathon.  Their changes vastly improved the clarity and onboarding experience for all of us:
* Sascha Corti
* Mihaela Curmei
* John Donnelly
* Kirill Logachev
* Jan Pospisil
* Anita Ramanan
* Frances Tibble
* Alessandro Vozza

### Update existing projects ###

This release is fully backwards compatible. Just update the nuget pakages in your projects to version `0.2.1806.1503-preview` and do a **full rebuild** to make sure all intermediate files are regenerated.

From Visual Studio, follow the normal instructions on how to [update a package](https://docs.microsoft.com/en-us/nuget/tools/package-manager-ui#updating-a-package).

To update project templates for the command line, run the following command:
```
dotnet new -i "Microsoft.Quantum.ProjectTemplates::0.2.1806.1503-preview"
```

After running this command, any new projects created using `dotnet new <project-type> -lang Q#` will automatically use this version of the Quantum Development Kit.

To update an existing project to use the newest version, run the following command from within the directory for each project:

```
dotnet add package Microsoft.Quantum.Development.Kit -v "0.2.1806.1503-preview"
dotnet add package Microsoft.Quantum.Canon -v "0.2.1806.1503-preview"
```

If an existing project also uses XUnit integration for unit testing, then a similar command can be used to update that package as well:
```
dotnet add package Microsoft.Quantum.Xunit -v "0.2.1806.1503-preview"
```

Depending on the version of XUnit that your test project uses, you may also need to update XUnit to 2.3.1:
```
dotnet add package xunit -v "2.3.1" 
```

After the update, make sure you remove all temporary files generated by the previous version by doing:
```
dotnet clean 
```

### Known Issues ###

No aditional known issues to report.


# Version 0.2.1802.2202

*Release date: February 26, 2018*

This release brings support for development on more platforms, language interoperability, and performance enhancements. Specifically:

- Support for macOS- and Linux-based development. 
- .NET Core compatibility, including support for Visual Studio Code across platforms.
- A full Open Source license for the Quantum Development Kit Libraries.
- Improved simulator performance on projects requiring 20 or more qubits.
- Interoperability with the Python language (preview release available on Windows).

### .NET Editions ###

The .NET platform is available through two different editions, the .NET Framework that is provided with Windows, and the open-source .NET Core that is available on Windows, macOS and Linux.
With this release, most parts of the Quantum Development Kit are provided as libraries for .NET Standard, the set of classes common to both Framework and Core.
These libraries are therefore compatible with recent versions of either .NET Framework or .NET Core.

Thus, to help ensure that projects written using the Quantum Development Kit are as portable as possible, we recommend that library projects written using the Quantum Development Kit target .NET Standard, while console applications target .NET Core.
Since previous releases of the Quantum Development Kit only supported .NET Framework, you may need to migrate your existing projects; see below for details on how to do this.

### Project Migration

Projects created using previous versions of Quantum Development Kit will still work, as long as you don't update the NuGet packages used in them. To migrate existing code to the new version, perform the following steps:
1. Create a new .NET Core project using the right type of Q# project template (Application, Library or Test Project).
2. Copy existing .qs and .cs/.fs files from the old project to the new project (using Add > Existing Item). Do not copy the AssemblyInfo.cs file.
3. Build and run the new project.

Please note that the operation RandomWalkPhaseEstimation from the namespace Microsoft.Quantum.Canon was moved into the namespace Microsoft.Research.Quantum.RandomWalkPhaseEstimation in the [Microsoft/Quantum-NC](https://github.com/microsoft/quantum-nc) repository.

### Known Issues ###

- The `--filter` option to `dotnet test` does not work correctly for tests written in Q#.
  As a result, individual unit tests cannot be run in Visual Studio Code; we recommend using `dotnet test` at the command line to re-run all tests.

# Version 0.1.1801.1707

*Release date: January 18, 2018*

This release fixes some issues reported by the community. Namely:

- The simulator now works with early non-AVX-enabled CPUs.
- Regional decimal settings will not cause the Q# parser to fail.
- `SignD` primitive operation now returns `Int` rather than `Double`.


# Version 0.1.1712.901

*Release date: December 11, 2017*

## Known Issues

### Hardware and Software Requirements

- The simulator included with the Quantum Development Kit requires a 64-bit installation of Microsoft Windows to run.
- Microsoft's quantum simulator, installed with the Quantum Development Kit, utilizes Advance Vector Extensions (AVX), and requires an AVX-enabled CPU. Intel processors shipped in Q1 2011 (Sandy Bridge) or later support AVX. We are evaluating support for earlier CPUs and may announce details at a later time.

### Project Creation

- When creating a solution (.sln) that will use Q#, the solution must be one directory higher than each project (.csproj) in the solution. When creating a new solution, this can be accomplished by making sure that the "Create directory for solution" checkbox on the "New Project" dialog box is checked. If this is not done, the Quantum Development Kit NuGet packages will need to be installed manually.

### Q#

- Intellisense does not display proper errors for Q# code. Make sure that you are displaying Build errors in the Visual Studio Error List to see correct Q# errors. Also note that Q# errors will not show up until after you've done a build.
- Using a mutable array in a partial application may lead to unexpected behavior.
- Binding an immutable array to a mutable array (let a = b, where b is a mutable array) may lead to unexpected behavior.
- Profiling, code coverage and other VS plugins may not always count Q# lines and blocks accurately.
- The Q# compiler does not validate interpolated strings. It is possible to create C# compilation errors by misspelling variable names or using expressions in Q# interpolated strings.

### Simulation

- The Quantum Simulator uses OpenMP to parallelize the linear algebra required. By default OpenMP uses all available hardware threads, which means that programs with small numbers of qubits will often run slowly because the coordination required will dwarf the actual work. This can be fixed by setting the environment variable OMP_NUM_THREADS to a small number. As a very rough rule of thumb, 1 thread is good for up to about 4 qubits, and then an additional thread per qubit is good, although this is highly dependent on your algorithm.

### Debugging

- F11 (step in) doesn't work in Q# code.
- Code highlighting in Q# code at a breakpoint or single-step pause is sometimes inaccurate. The correct line will be highlighted, but sometimes the highlight will start and end at incorrect columns on the line.

### Testing

- Tests must be executed in 64-bit mode. If your tests are failing with a BadImageFormatException, go to the Test menu and select Test Settings > Default Processor Architecture > X64.
- Some tests take a long time (possibly as much as 5 minutes depending on your computer) to run. This is normal, as some use over twenty qubits; our largest test currently runs on 23 qubits.

### Samples

- On some machines, some small samples may run slowly unless the environment variable OMP_NUM_THREADS is set to "1". See also the release note under "Simulation".

### Libraries

- There is an implicit assumption that the qubits passed to an operation in different arguments are all distinct. For instance, all of the library operations (and all of the simulators) assume that the two qubits passed to a controlled NOT are different qubits. Violating this assumption may lead to unpredictable unexpected. It is possible to test for this using the quantum computer tracer simulator.
- The Microsoft.Quantum.Bind function may not act as expected in all cases.
- In the Microsoft.Quantum.Extensions.Math namespace, the SignD function returns a Double rather than an Int, although the underlying System.Math.Sign function always returns an integer. It is safe to compare the result against 1.0, -1.0, and 0.0, since these doubles all have exact binary representations.

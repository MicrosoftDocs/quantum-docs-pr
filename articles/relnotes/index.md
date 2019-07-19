---
title: Quantum Development Kit preview release notes| Microsoft Docs 
description: Quantum Development Kit preview release notes
author: QuantumWriter
ms.author: Alan.Geller@microsoft.com 
ms.date: 10/09/2017
ms.topic: article
uid: microsoft.quantum.relnotes
---

# Microsoft Quantum Development Kit Release Notes

## Migrating to the newest packages.

1.  To update IQ# to the latest version, from the command line, execute:
```Command Prompt
dotnet tool update -g Microsoft.Quantum.IQSharp
```  
2.  To update Python, first update IQ# (step 1) and then follow [these instructions](xref:microsoft.quantum.install.python).
3.  Follow [these instructions](xref:microsoft.quantum.install.csharp#update) to update your .csproj files, using the PackageReference for the Version below.

> [!NOTE]
> * The language server included with the Quantum Development Kit does not support multiple workspaces.
> * In order to work with a project in Visual Studio Code, open the root folder containing the project itself and all referenced projects.   
> * In order to work with a solution in Visual Studio, all projects contained in the solution need to be in the same folder as the solution or in one of its subfolders.  
> * References between projects migrated to 0.6 and higher and projects using older package versions are **not** supported.

# Version 0.8 (*PackageReference 0.8.1907.1701*)

*Release date: July 12, 2019*

This release contains the following:

- New indexing locations for slicing arrays, [see the language reference](xref:microsoft.quantum.language.expressions#array-slices) for more information.
- Added Dockerfile hosted on the [Microsoft Container Registry](https://github.com/microsoft/ContainerRegistry), see the [IQ# repository for more information](https://github.com/microsoft/iqsharp/blob/master/README.md)
- Breaking change for [the trace simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro), update to configuration settings, name changes; see the [.NET API Browser for the updated names](https://docs.microsoft.com/dotnet/api/microsoft.quantum.simulation.simulators.qctracesimulators.qctracesimulatorconfiguration).

See the full list of closed PRs for [libraries](https://github.com/Microsoft/QuantumLibraries/pulls?q=is%3Apr+is%3Aclosed) and [samples](https://github.com/Microsoft/Quantum/pulls?q=is%3Apr+is%3Aclosed).  






# Version 0.7 (*PackageReference 0.7.1905.3109*)

*Release date: May 31, 2019*

This release contains the following:
- additions to the Q# language, 
- updates to the chemistry library, 
- a new numerics library.

See the full list of closed PRs for [libraries](https://github.com/Microsoft/QuantumLibraries/pulls?q=is%3Apr+is%3Aclosed) and [samples](https://github.com/Microsoft/Quantum/pulls?q=is%3Apr+is%3Aclosed).  

The changes are summarized here as well as instructions for upgrading your existing programs.  Read more about these changes on the [Q# dev blog](https://devblogs.microsoft.com/qsharp).

## Q# language syntax
This release adds new Q# language syntax:
* Add named items for [user-defined types](xref:microsoft.quantum.language.type-model#user-defined-types).  
* User-defined type constructors can now be used as functions.
* Add support for [copy-and-update](xref:microsoft.quantum.language.expressions#copy-and-update-expressions) and [apply-and-reassign]((xref:microsoft.quantum.qsharp-ref.statements#rebinding-of-mutable-symbols)) in user-defined types.
* Fixup-block for [repeat-until-success](xref:microsoft.quantum.qsharp-ref.statements#repeat-until-success-loop) loops is now optional.
* We now support while loops in functions (not in operations).

## Library 

This release adds a numerics library: Learn more about how to [use the new numerics library](xref:microsoft.quantum.numerics.usage) and try out the [new samples](https://github.com/microsoft/quantum/tree/master/Numerics).  [PR #102](https://github.com/Microsoft/QuantumLibraries/pull/102).  

This release reorganizes extends and updates the chemistry library:
* Improves modularity of components, extensibility, general code cleanup.  [PR #58](https://github.com/microsoft/QuantumLibraries/pull/58).
* Add support for [multi-reference wavefunctions](xref:microsoft.quantum.chemistry.concepts.multireference), both sparse multi-reference wavefunctions and unitary coupled cluster.  [PR #110](https://github.com/Microsoft/QuantumLibraries/pull/110).
* (Thank you!) [1QBit](https://1qbit.com) contributor ([@valentinS4t1qbit](https://github.com/ValentinS4t1qbit)): Energy evaluation using variational ansatz. [PR #120](https://github.com/Microsoft/QuantumLibraries/pull/120).
* Updating [Broombridge](xref:microsoft.quantum.libraries.chemistry.schema.broombridge) schema to new [version 0.2](xref:microsoft.quantum.libraries.chemistry.schema.spec_v_0_2), adding unitary coupled cluster specification. [Issue #65](https://github.com/microsoft/QuantumLibraries/issues/65).
* Adding Python interoperability to chemistry library functions. Try out this [sample](https://github.com/microsoft/Quantum/tree/master/Chemistry/PythonIntegration). [Issue #53](https://github.com/microsoft/QuantumLibraries/issues/53) [PR #110](https://github.com/Microsoft/QuantumLibraries/pull/110).





# Version 0.6.1905

*Release date: May 3, 2019*

This release contains the following:
- makes changes to the Q# language, 
- restructures the Quantum Development Kit libraries, 
- adds new samples, and 
- fixes bugs.  Several closed PRs for [libraries](https://github.com/Microsoft/QuantumLibraries/pulls?q=is%3Apr+is%3Aclosed) and [samples](https://github.com/Microsoft/Quantum/pulls?q=is%3Apr+is%3Aclosed).  

The changes are summarized here as well as instructions for upgrading your existing programs.  You can read more about these changes on devblogs.microsoft.com/qsharp.

## Q# language syntax
This release adds new Q# language syntax:
* Add a [shorthand way to express specializations of quantum operations](xref:microsoft.quantum.language.type-model#functors) (control and adjoints) with `+` operators.  The old syntax is deprecated.  Programs that use the old syntax (e.g., `: adjoint`) will continue to work, but a compile time warning will be generated.  
* Add a new operator for [copy-and-update](xref:microsoft.quantum.language.expressions#copy-and-update-expressions), `w/`, can be used to express array creation as a modification of an existing array.
* Add the common [apply-and-upate statement](xref:microsoft.quantum.qsharp-ref.statements#rebinding-of-mutable-symbols), e.g., `+=`, `w/=`.
* Add a way to specify a short name for namespaces in [open directives](xref:microsoft.quantum.language.file-structure#open-directives).

With this release, we no longer allow an array element to be specified on the left side of a set statement.  This is because that syntax implies that arrays are mutable when in fact, the result of the operation has always been the creation of a new array with the modification.  Instead, a compiler error will be generated with a suggestion to use the new copy-and-update operator, `w/`, to accomplish the same result.  

## Library restructuring
This release reorganizes the libraries to enable their growth in a consistent way:
* Renames the Microsoft.Quantum.Primitive namespace  to Microsoft.Quantum.Intrinsic.  These operations are implemented by the target machine.  The Microsoft.Quantum.Primitive namespace is deprecated.  A runtime warning will advise when programs call operations and functions using deprecated names.

* Renames the Microsoft.Quantum.Canon package to Microsoft.Quantum.Standard.  This package contains namespaces that are common to most Q# programs.  This includes:  
    - Microsoft.Quantum.Canon for common operations
    - Microsoft.Quantum.Arithmetic for general purpose arithmetic operations
    - Microsoft.Quantum.Preparation for operations used to prepare qubit state
    - Microsoft.Quantum.Simulation for simulation functionality

With this change, programs that include a single "open" statement for the namespace Microsoft.Quatum.Canon may encounter build errors if the program references operations that were moved to the other three new namespaces.  Adding the additional open statements for the three new namespaces is a straightforward way to resolve this issue.  

* Several namespaces have been deprecated as the operations within have been reorganized to other namespaces. Programs that use these namespaces will continue to work, and a compile time warning will denote the namespace where the operation is defined.  

* The Microsoft.Quantum.Arithmetic namespace has been normalized to use the <xref:microsoft.quantum.arithmetic.littleendian> user-defined type. Use the function [BigEndianAsLittleEndian](xref:microsoft.quantum.arithmetic.bigendianaslittleendian) when needed to convert to little endian.  

* The names of several callables (functions and operations) have been changed to conform to the [Q# Style Guide](xref:microsoft.quantum.contributing.style).  The old callable names are deprecated.  Programs that use the old callables will continue to work with a compile time warning. 

## New Samples ##

We added a [sample of using Q# with F# driver](https://github.com/Microsoft/Quantum/pull/164).  

**Thank you!** to the following contributor to our open code base at http://github.com/Microsoft/Quantum. These contributions add significantly to the rich samples of Q# code:

* Mathias Soeken ([@msoeken](https://github.com/msoeken)): Oracle function synthesis. [PR #135](https://github.com/Microsoft/Quantum/pull/135).

## Migrating existing projects to 0.6.1905.

  
1.  To update IQ# to the latest version, from the command line, execute:
```Command Prompt
dotnet tool update -g Microsoft.Quantum.IQSharp
```  
2.  To update Python, first update IQ# (step 1) and then follow [these instructions](xref:microsoft.quantum.install.python).
3.  Follow these instructions to update your .csproj file: 

If you have existing Q# projects from version 0.5 of the Quantum Development Kit, the following are the steps to migrate those projects to the newest version.

      1. Projects need to be upgraded in order.  If you have a solution with multiple projects, update each project in the order they are referenced.
      2. From a command line, Run `dotnet clean` to remove all existing binaries and intermediate files.
      3. In a text editor, edit the .csproj file to change the version of all the "Microsoft.Quantum" `PackageReference` to version 0.6.1904, and change the "Microsoft.Quantum.Canon" package name to "Microsoft.Quantum.Standard", for example:
```xml
    <PackageReference Include="Microsoft.Quantum.Standard" Version="0.6.1905.301" />
    <PackageReference Include="Microsoft.Quantum.Development.Kit" Version="0.6.1905.301" />
```
      4. From the command line, run this command: `dotnet msbuild`  
      5. After running this, you might still need to manually address errors due to changes listed above.  In many cases, these errors will also be reported by IntelliSense in Visual Studio or Visual Studio Code.
            - Open the root folder of the project or the containing solution in Visual Studio 2017 or Visual Studio Code.
            - After opening a .qs file in the editor, you should see the output of the Q# language extension in the output window.
            - After the project has loaded successfully (indicated in the output window) open each file and manually to address all remaining issues.


> [!NOTE]
> * For the 0.6 release, the language server included with the Quantum Development Kit does not support multiple workspaces.
> * In order to work with a project in Visual Studio Code, open the root folder containing the project itself and all referenced projects.   
> * In order to work with a solution in Visual Studio, all projects contained in the solution need to be in the same folder as the solution or in one of its subfolders.  
> * References between projects migrated to 0.6 and higher and projects using older package versions are **not** supported.



# Version 0.5.1904

*Release date: April 15, 2019*

This release contains bug fixes.


# Version 0.5.1903

*Release date: March 27, 2019*

This release contains the following:

- Adds support for Jupyter Notebook, which offers a great way to learn about Q#.  [Check out new Jupyter Notebook samples and learn how to write your own Notebooks](xref:microsoft.quantum.install.jupyter). 

- Adds integer adder arithmetic to the Quantum Canon library.  See also a Jupyter Notebook that [describes how to use the new integer adders](https://github.com/Microsoft/Quantum/blob/master/Samples/src/Arithmetic/Adder%20Example.ipynb).

- Bug fix for DumpRegister issue reported by the community ([#148](https://github.com/Microsoft/Quantum/issues/148)).

- Added ability to return from within a [using statement](xref:microsoft.quantum.qsharp-ref.statements).

- Revamped [getting started guide](xref:microsoft.quantum.install).


# Version 0.5.1902

*Release date: February 27, 2019*

This release contains the following:

- Adds support for a cross-platform Python host.  The `qsharp` package for Python makes it easy to simulate Q# operations and functions from within Python. Learn more about [Python interoperability](xref:microsoft.quantum.install.python). 

- The Visual Studio and Visual Studio Code extensions now support renaming of symbols (e.g., functions and operations).

- The Visual Studio extension can now be installed on Visual Studio 2019.



# Version 0.4.1901

*Release date: January 30, 2019*

This release contains the following:

- adds support for a new primitive type, BigInt, which represents a signed integer of arbitrary size.  Learn more about [BigInt type](xref:microsoft.quantum.language.type-model).
- adds new Toffoli simulator, a special purpose fast simulator that can simulate X, CNOT and multi-controlled X quantum operations with very large numbers of qubits.  Learn more about [Toffoli simulator](xref:microsoft.quantum.machines.toffoli-simulator).
- adds a simple resource estimator that estimates the resources required to run a given instancee of a Q# operation on a quantum computer.  Learn more about the [Resource Estimator](xref:microsoft.quantum.machines.resources-estimator).


# Version 0.3.1811.2802

*Release date: November 28, 2018*

Even though our VS Code extension was not using it, it was flagged and removed from the marketplace during
[the extensions purge](https://code.visualstudio.com/blogs/2018/11/26/event-stream) related to the `event-stream` NPM package. 
This version removes all runtime dependencies that could make the extension trigger any red flags.

If you had previously installed the extension you will need to install it again by visiting 
the [Microsoft Quantum Development Kit for Visual Studio Code](vscode:extension/quantum.quantum-devkit-vscode) extension on the 
Visual Studio Marketplace and press Install. We are sorry about the inconvenience.


# Version 0.3.1811.1511

*Release date: November 20, 2018*

This release fixes a bug that prevented some users to successfully load the Visual Studio extension.

If you are upgrading from a 0.2 version of the Quantum Development Kit, learn more about [Q# language changes and migrating your Q# program](xref:microsoft.quantum.relnotes.migration-0-3).

# Version 0.3.1811.203

*Release date: November 2, 2018*

This release includes a few bug fixes, including:

* Invoking `DumpMachine` could change the state of the simulator under certain situations.
* Removed compilation warnings when building projects using a version of .NET Core previous to 2.1.403.
* Clean up of documentation, specially the tooltips shown during mouse hover in VS Code or Visual Studio.

If you are upgrading from a 0.2 version of the Quantum Development Kit, learn more about [Q# language changes and migrating your Q# program](xref:microsoft.quantum.relnotes.migration-0-3).

# Version 0.3.1810.2508

*Release date: October 29, 2018*

This release includes new language features and an improved developer experience:

* This release includes a language server for Q#, as well as the client integrations for Visual Studio and Visual Studio Code. This enables a new set of IntelliSense features along with live feedback on typing in form of squiggly underlinings of errors and warnings. 
* This update greatly improves diagnostic messages in general, with easy navigation to and precise ranges for diagnostics and additional details in the displayed hover information.
* The Q# language has been extended in ways that unifies the ways developers can do common operations and new enhancements to the language features to powerfully express quantum computation.  There are a handful of breaking changes to the Q# language with this release.   

Learn more about [Q# language changes and migrating your Q# program](xref:microsoft.quantum.relnotes.migration-0-3).

This release also includes a new quantum chemistry library:

* The chemistry library contains new Hamiltonian simulation features, including:
    - Trotter–Suzuki integrators of arbitrary even order for improved simulation accuracy.
    - Qubitization simulation technique with chemistry-specific optimizations for reducing $T$-gate complexity.
* A new open source schema, called Broombridge Schema (in reference to a [landmark](https://en.wikipedia.org/wiki/Broom_Bridge) celebrated as a birthplace of Hamiltonians), is introduced for importing representations of molecules and simulating them.
* Multiple chemical representations defined using the Broombridge Schema are provided.  These models were generated by [NWChem](http://www.nwchem-sw.org/), an open source high-performance computational chemistry tool.
* Tutorials and Samples describe how to use the chemistry library and the Broombridge data models to:
    - Construct simple Hamiltonians using the chemistry library
    - Visualize ground and excited energies of Lithium Hydride using phase estimation.
    - Perform resource estimates of quantum chemistry simulation.
    - Estimate energy levels of molecules represented by the Broombridge schema.
* Documentation describes how to use NWChem to generate additional chemical models for quantum simulation with Q#.

Learn more about the [Quantum Development Kit chemistry library](xref:microsoft.quantum.chemistry.concepts.intro).

With the new chemistry library, we are separating out the libraries into a new GitHub repo, [Microsoft/QuantumLibraries](https://github.com/Microsoft/QuantumLibraries).  The samples remain in the repo [Microsoft/Quantum](https://github.com/Microsoft/Quantum).  We welcome contributions to both!

This release includes bug fixes and features for issues reported by the community:

* Intellisense for Q#? ([UserVoice](https://quantum.uservoice.com/forums/906943/suggestions/32656918)).
* .qs files ([UserVoice](https://quantum.uservoice.com/forums/906097/suggestions/32593049)).
* Improve error message when curly braces are abbreviated in if statement ([UserVoice](https://quantum.uservoice.com/forums/906208/suggestions/34718518)).
* Support tuple deconstruction at mutable (re-)binding ([UserVoice](https://quantum.uservoice.com/forums/906208/suggestions/35020444)).
* Error Running Provided BitFlipCode ([UserVoice](https://quantum.uservoice.com/forums/906940/suggestions/35008546)).
* H2SimulationGUI displays big peaks sometimes ([UserVoice](https://quantum.uservoice.com/forums/906946/suggestions/34668370)).

### Community Contributions ###

**Thank you!** to the following contributors to our open code base at http://github.com/Microsoft/Quantum. These contributions add significantly to the rich samples of Q# code:

* Rolf Huisman ([@RolfHuisman](https://github.com/RolfHuisman)): Improved the experience for QASM/Q# developers by creating a QASM to Q# translator. [PR #58](https://github.com/Microsoft/Quantum/pull/58).

* Andrew Helwer ([@ahelwer](https://github.com/ahelwer)):  Contributed a sample implementing the CHSH Game, a quantum game related to non-locality.  [PR #84](https://github.com/Microsoft/Quantum/pull/84).

Thank you also to Rohit Gupta ([@guptarohit](https://github.com/guptarohit),[PR #90](https://github.com/Microsoft/quantum/pull/90)), Tanaka Takayoshi ([@tanaka-takayoshi](https://github.com/tanaka-takayoshi),[PR #289](https://github.com/MicrosoftDocs/quantum-docs-pr/pull/289)), and Lee James O'Riordan ([@mlxd](https://github.com/mlxd),[PR #96](https://github.com/Microsoft/Quantum/pull/96)) for their work improving the content for all of us through documentation, spelling and typo corrections! 




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

Learn more about [Testing and Debugging](xref:microsoft.quantum.techniques.testing-and-debugging).


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

From Visual Studio, follow the normal instructions on how to [update a package](https://docs.microsoft.com/nuget/tools/package-manager-ui#updating-a-package).

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

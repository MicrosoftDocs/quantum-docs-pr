---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Quantum Development Kit preview release notes| Microsoft Docs 
description: Quantum Development Kit preview release notes
services: service-name-with-dashes-AZURE-ONLY 
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: QuantumWriter
ms.author: MSFT-alias-person-or-DL
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# ms.service: service-name-from-white-list
# product-name-from-white-list

# Optional fields. Don't forget to remove # if you need a field.
# ms.custom: can-be-multiple-comma-separated
# ms.devlang:devlang-from-white-list
# ms.suite: 
# ms.tgt_pltfrm:
# ms.reviewer:
# manager: MSFT-alias-manager-or-PM-counterpart
---

# Microsoft Quantum Development Kit Preview Release Notes

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

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

### Project Creation

- Solution (.sln) must be one directory higher than each project (.csproj) in it (or else install nugets manually)

### Q#

- Intellisense does not display proper errors for Q# code. Make sure that you are displaying Build errors in the Visual Studio Error List to see correct Q# errors. Also note that Q# errors will not show up until after you've done a build.
- Using a mutable array in a partial application may lead to unexpected behavior.
- Binding an immutable array to a mutable array (let a = b, where b is a mutable array) may lead to unexpected behavior.
- In some cases, Q# may allow for passing operations which expect UDTs when to an operation-type input which expects a base type, such that type safety may not be guaranteed in these cases.
- Profiling, code coverage and other VS plugins may not always count Q# lines and blocks accurately.
- The Q# compiler does not validate interpolated strings. It is possible (easy?) to create C# compilation errors by misspelling variable names or using expressions in Q# interpolated strings.

### Simulation

- The Quantum Simulator uses OpenMP to parallelize the linear algebra required. By default OpenMP uses all available hardware threads, which means that programs with small numbers of qubits will often run slowly because the coordination required will dwarf the actual work. This can be fixed by setting the environment variable OMP_NUM_THREADS to a small number. As a very rough rule of thumb, 1 thread is good for up to about 4 qubits, and then an additional thread per qubit is good, although this is highly dependent on your algorithm.

### Debugging

- F11 (step in) doesn't work in Q# code.
- Code highlighting in Q# code at a breakpoint or single-step pause can be a bit flaky. In general, the correct line will be highlighted, but often the highlight will start and end at the incorrect columns on the line.

### Testing

- Tests must be executed in 64-bit mode. If your tests are failing with BadImageFormatException, go to Test menu and select Test Settings > Default Processor Architecture > X64.
- Some tests take a long time (~1 to 5 minutes depending on computer) to run — this is normal, as they use up to approximately twenty qubits.

### Samples

- On some machines, some samples may run slowly unless the environment variable OMP_NUM_THREADS is set to "1". See also the release note under "Simulation".

### Libraries

- There is an implicit assumption that the qubits passed to an operation in different arguments are all distinct. For instance, all of the library operations (and all of the simulators) assume that the two qubits passed to a controlled NOT are different qubits. Violating this assumption may lead to unpredictable unexpected. It is possible to test for this using the quantum computer tracer simulator.
- The Microsoft.Quantum.Bind function may not act as expected in all cases.
- In Quantum.Math libraries, function SignD returns a Double type. Actually, logically, it returns only three values: -1, 0, 1. It does not make sense for it to return Double type for this "enum" (one can not even compare return to 0), it must return Int type. The fix is in PR and will go in after the release.

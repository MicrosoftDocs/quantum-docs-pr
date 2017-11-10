---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Intent and product brand in a unique string of 43-59 chars including spaces | Microsoft Docs 
description: 115-145 characters including spaces. Edit the intro para describing article intent to fit here. This abstract displays in the search result.
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

# What is Q#? #

At its most basic, Q# is a specialized language for describing how a quantum machine or simulator should generate instructions to execute on a quantum computer.
From that perspective, a quantum program is a particular set of classical functions which, when called, generate quantum circuits as their side effects.
An important consequence of that view is that a program written in Q# does not directly model qubits themselves, but how a classical control computer interacts with those qubits.
By intention, Q# thus does not define quantum states or other properties of quantum mechanics directly, but rather does so indirectly through the action of the various subroutines defined in the language.
For instance, consider the state $\ket{+} = \left(\ket{0} + \ket{1}\right) / \sqrt{2}$ discussed in the <!-- TODO: link --> quantum concepts guide.
To prepare this state in Q#, we use that qubits are initialized in the $\ket{0}$ state, and that $\ket{+} = H\ket{0}$, where $H$ is the Hadamard transform:

```qsharp
using (register = Qubit[1]) {
    let qubit = register[0];
    // At this point, qubit is in the state |0〉.
    H(qubit);
    // We've now applied H, such that our qubit is in
    // H|0〉 = |+〉, as we wanted.
}
```

Importantly, in writing the above program, we did not explicitly refer to the state within Q#, but rather described how the state was *transformed* by our program.
Thus, similar to how a graphics shader program accumulates a description of transformations to each vertex, a quantum program in Q# accumulates transformations to quantum states.
This allows us to be entirely agnostic about what a quantum state even *is* on each target machine.
As a particularly extreme example, the quantum computing trace simulator <!-- TODO: link to Vadym's docs --> does not assign any state to a qubit even internally, and instead traces out how a qubit is used.
The replacement of a traditional simulator with a trace simulator is entirely transparent to Q#, such that a quantum programmer need not know anything about the target machine that will be used to run their application.

Indeed, as we will see later on in this guide, from the perspective of a Q# program, a qubit is entirely an entirely opaque reference to the internal structure of a target machine.
A Q# program has no ability to introspect into the state of a qubit, its representation on a target machine, or even whether it is the same qubit as any other qubit available to the program.
Rather, a program can call operations such as `Measure` to learn information from a qubit, and call operations such as `X` and `H` to act on the state of a qubit.
These operations have no intrinsic definition within the language, and are made concrete only by the target machine used to run a particular Q# program.
A Q# program recombines these operations as defined by a target machine to create new, higher-level operations to express quantum computation.
In this way, Q# makes it very easy to express the logic underlying quantum and semi-quantum algorithms, while also being very general with respect to the structure of a target machine or simulator.

Concretely, a Q# program is comprised of one or more *operations*.
Each operation defined in Q# may then call any number of other operations, including the built-in *primitive* operations defined by the language and implemented by each target machine.
When compiled, each operation is represented as a .NET class type that can be provided to target machines.

Throughout the rest of this guide, we will see how to use different language concepts and constructs to help us define quantum logic through operations.

# Structure of Q# Source Files

Minimally, a Q# source file consists of a *namespace declaration*, which specifies a .NET namespace which will contain the definitions in the source file.
Definitions from other Q# source files and libraries can be included using the `open` statement.
For instance, most of the operations defining fundamental gates are defined in the @"microsoft.quantum.primitive" namespace.
To make this available to our code, we simply `open` that namespace at the top of each file:

```qsharp
namespace Example {
    open Microsoft.Quantum.Primitive;

    // ...
}
```

Within a namespace, each Q# source file can define any combination of *operations*, *functions*, and *user-defined types*.
In the rest of this section, we will describe each in turn and provide examples of how they can be used in practice to make useful quantum programs.
---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Quantum development techniques introduction | Microsoft Docs 
description: Quantum development techniques introduction
author: QuantumWriter
ms.author: Christopher.Granade@microsoft.com
ms.date: 12/11/2017
ms.topic: article
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# For Quantum products none of these categories have been defined  yet.
# ms.service: service-name-from-white-list
# ms.prod: product-name-from-white-list
# ms.technology: tech-name-from-white-list
---

# What is Q#? #

Q# is a scalable, multi-paradigm, domain-specific programming language for quantum computing. Q# is a quantum programming language in that it can be used to describe how instructions are executed on quantum machines. The machines that can be targeted range from simulators to actual quantum hardware. Q# is scalable: it can be used to write simple demonstration programss like teleport that run on a few qubits, but also supports writing large, sophisticated programs such simulations of complex molecules that will require large machines with millions of qubits. Even though large physical machines are still in the future, Q# allows a programmer to program complex quantum algorithms now. What is more, Q# supports various tasks such as debugging, profiling, resource estimation, and certain special-purpose simulations in a scalable way. 

From a technical perspective, a quantum program can be seen as a particular set of classical functions which, when called, generate quantum circuits as their side effects. An important consequence of that view is that a program written in Q# does not directly model qubits themselves, but rather describes how a classical control computer interacts with those qubits.
By design, Q# thus does not define quantum states or other properties of quantum mechanics directly, but rather does so indirectly through the action of the various subroutines defined in the language.
For instance, consider the state $\ket{+} = \left(\ket{0} + \ket{1}\right) / \sqrt{2}$ discussed in the [Quantum Computing Concepts](xref:microsoft.quantum.concepts.intro) guide.
To prepare this state in Q#, we use the facts that the qubits are initialized in the $\ket{0}$ state, and that $\ket{+} = H\ket{0}$, where $H$ is the Hadamard transform:

```qsharp
using (qubit = Qubit()) {
    // At this point, qubit is in the state |0〉.
    H(qubit);
    // We've now applied H, such that our qubit is in H|0〉 = |+〉, as we wanted.
}
```

Importantly, in writing the above program, we did not explicitly refer to the state within Q#, but rather described how the state was *transformed* by our program.
Thus, similar to how a graphics shader program accumulates a description of transformations to each vertex, a quantum program in Q# accumulates transformations to quantum states.
This allows us to be entirely agnostic about what a quantum state even *is* on each target machine, which might have different interpretations depending on the machine. 

From the perspective of a Q# program, a qubit is an entirely opaque reference to the internal structure of a target machine.
A Q# program has no ability to introspect into the state of a qubit, its representation on a target machine, or even whether it is the same qubit as any other qubit available to the program.
Rather, a program can call operations such as `Measure` to learn information from a qubit, and call operations such as `X` and `H` to act on the state of a qubit.
These operations have no intrinsic definition within the language, and are made concrete only by the target machine used to run a particular Q# program.
A Q# program recombines these operations as defined by a target machine to create new, higher-level operations to express quantum computation.
In this way, Q# makes it easy to express the logic underlying quantum and hybrid quantum-classical algorithms, while also being general with respect to the structure of a target machine or simulator.

Concretely, a Q# program is comprised of one or more *operations*, one or more *functions*, and user defined types. Operations are used to describe the transformations of the state of a quantum machine and are the most basic building block of Q# programs. 
Each operation defined in Q# may then call any number of other operations, including the built-in *intrinsic* operations implemented by a target machine.
When compiled, each operation is represented as a .NET class type that can be provided to target machines.

In contrast to operations, functions are used to describe purely classical behavior and do not have any effects besides computing classical output values. Q# is a strongly typed language and comes with a set of built-in primitive types as well as support for user defined types. 

Throughout the rest of this guide, we will see how to use different language concepts and constructs to help us define complex quantum programs through the basic building blocks of operations, functions, and types. 

# Structure of Q# Source Files

Minimally, a Q# source file consists of a *namespace declaration*, which specifies a .NET namespace which will contain the definitions in the source file.
Definitions from other Q# source files and libraries can be included using the `open` statement.
For instance, most of the operations defining fundamental gates are defined in the @"microsoft.quantum.primitive" namespace.
To make this available to our code, we simply `open` that namespace at the top of each file:

```qsharp
namespace Example {
    open Microsoft.Quantum.Intrinsic;

    // ...
}
```

Within a namespace, each Q# source file can define any combination of *operations*, *functions*, and *user-defined types*.
In the rest of this section, we will describe each in turn and provide examples of how they can be used in practice to make useful quantum programs.

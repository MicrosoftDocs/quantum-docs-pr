---
title: Q# Basics
description: Basic concepts of Q#
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.date: 02/28/2020
ms.topic: article
uid: microsoft.quantum.guide.basics
---

# Q# Basics

In this section, we present a brief introduction to the basic building blocks of Q#.

For an overview of what Q# is and where it fits in as a fundamental component of the Quantum Development Kit, see [What is Q#?](xref:microsoft.quantum.overview.q-sharp). 

## What is a quantum program?

From a technical perspective, a quantum program is a particular set of classical subroutines which, when called, perform certain operations on a quantum system.
An important consequence of that view is that a Q# program does not directly model qubits themselves, but rather describes how a classically controlled computer interacts with those qubits.
By design, Q# does not define quantum states or other properties of quantum mechanics directly.
For instance, consider the state $\ket{+} = \left(\ket{0} + \ket{1}\right) / \sqrt{2}$ discussed in the [Quantum Computing Concepts](xref:microsoft.quantum.concepts.intro) guide.
To prepare this state in Q#, we use the facts that the qubits are initialized in the $\ket{0}$ state, and that $\ket{+} = H\ket{0}$, where $H$ is the Hadamard transform, implemented by the [`H` operation](xref:microsoft.quantum.intrinsic.h):

```qsharp
using (qubit = Qubit()) {
    // At this point, the qubit is in the state |0⟩.
    H(qubit);
    // We've now applied H, such that our qubit is in H|0⟩ = |+⟩, as we wanted.
}
```

## Quantum states in Q#

Importantly, in writing the above program, we did not explicitly refer to the state within Q# but described how our program *transformed* the state.
This approach allows us to be entirely agnostic about what a quantum state even *is* on each target machine, which might have different interpretations depending on the machine. 

A Q# program cannot introspect into the state of a qubit.
Instead, a program can call operations such as [`Measure`](xref:microsoft.quantum.intrinsic.measure) to learn information from a qubit, and call operations such as [`X`](xref:microsoft.quantum.intrinsic.x) and [`H`](xref:microsoft.quantum.intrinsic.h) to act on the state of a qubit.
What these operations actually *do* is only made concrete by the target machine we use to run the particular Q# program.
For example, if running the program on our [full-state simulator](xref:microsoft.quantum.machines.full-state-simulator), the simulator performs the corresponding mathematical operations to the simulated quantum system.
But looking toward the future, when the target machine is a real quantum computer, calling such operations in Q# directs the quantum computer to perform the corresponding *real* operations on the *real* quantum system, for example, precisely timed laser pulses).

A Q# program recombines these operations as defined by a target machine to create new, higher-level operations to express quantum computation.
In this way, Q# makes it easy to express the logic underlying the quantum and hybrid quantum–classical algorithms, while also being general with respect to the structure of a target machine or simulator.

## Q# operations and functions

Concretely, a Q# program comprises *operations*, *functions*, and any user-defined types. 

Operations are used to describe the transformations of quantum systems and are the most fundamental building block of Q# programs. 
Each operation defined in Q# may then call any number of other operations.

In contrast to operations, functions are used to describe purely *deterministic* classical behavior and do not have any effects besides computing classical values. 
For example, suppose we would like to measure our qubits at the end of a program and add the measurement results to an array.
In this case, `Measure` is an *operation* that instructs the target machine to perform a measurement on the (real or simulated) qubits. At the same time, *functions* handle the classical process of adding the returned results to an array.

Together, operations and functions are known as *callables*. Their underlying structure and behavior are introduced and detailed in [Operations and Functions in Q#](xref:microsoft.quantum.guide.operationsfunctions).


## Q# syntax overview

The syntax of a language describes the different combinations of symbols that form a syntactically correct program.
In Q#, we can classify the elements of its syntax in three different groups: types, expressions, and statements.

### Types
Q# is a strongly-typed language, such that careful use of types can help the compiler provide strong guarantees about Q# programs at compile time.
In addition to standard and quantum-specific built-in primitive types, for example, `Int`, `Bool`, `Qubit`, and `Result`, Q# provides support for user-defined types.

For descriptions of all the primitive types, details for array and tuple types, and steps to define new types within a Q# file, see [Types in Q#](xref:microsoft.quantum.guide.types).

### Expressions
An expression in a programming language is a combination of one or more constants, variables, operators, and functions that the programming language interprets and evaluates to a specific value.
Most simply, for every type in a language, expressions of that type can be either *literals* or symbols bound to a value of that type.
For example, `5` is an `Int` literal (thus also an expression of type `Int`), and if the symbol `count` is bound to the integer value `5`, then `count` is also an integer expression.

Additionally, an expression can consist of other expressions combined by certain operators.
For example, another example of an `Int` expression that evaluates to `5` is `2+3`.

For more information about expressions and compatible operators in Q#, see [Type Expressions in Q#](xref:microsoft.quantum.guide.expressions). 

### Statements 
A statement is a syntactic unit of an imperative programming language that expresses some action to carry out.
Statements contrast with expressions in that statements do not return results and are executed solely for their side effects. Expressions, however, always return a result and often do not have side effects at all. In short, the Q# compiler executes a statement and evaluates an expression.

A simple example of a statement in Q# is assigning a symbol to an expression:
```qsharp
let count = 5;
```

A more interesting example is the `for` statement which supports iteration and includes a *statement block*.
Suppose `qubits` is the symbol bound to a register of qubits (technically of type `Qubit[]`, or an array of `Qubit` types). 
Then
```qsharp
for (qubit in qubits) {
    H(qubit);
}
```
is a statement that iterates over each qubit in the register, performing the `H` operation on each one. 
Note that `H(qubit);` is a statement in itself as well.

You can use any call expression of type `Unit` (a `Unit` type does not return any information) as a statement.
This type of expression is useful when calling operations on qubits that return `Unit` because the purpose of the statement is to modify the implicit quantum state.
Expression evaluation statements require a terminating semicolon.

You use statements to build nearly every aspect of a Q# program, and no single page could encompass all the information relating to them.
For more information about their lexical structure and formatting, see [Q# File Structure](xref:microsoft.quantum.guide.filestructure); for symbol binding assignment and scope, see [Variables in Q#](xref:microsoft.quantum.guide.variables), and for control flow loops such as `for`, see [Control Flow in Q#](xref:microsoft.quantum.guide.controlflow).

## Next steps

Start learning about [Types in Q#](xref:microsoft.quantum.guide.types).

For more background about the foundations and motivation behind Q#, see [Why do we need Q#?](https://devblogs.microsoft.com/qsharp/why-do-we-need-q/).

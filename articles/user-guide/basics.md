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

In this section we present a brief introduction to the basic building blocks of Q#.

For a quick overview of what Q# is and where it fits in as a fundamental component of the Quantum Development Kit, you can check out [What is Q#?](xref:microsoft.quantum.overview.q-sharp). 

## What is a quantum program?

From a technical perspective, a quantum program can be seen as a particular set of classical subroutines which, when called, perform certain operations on a quantum system.
An important consequence of that view is that a program written in Q# does not directly model qubits themselves, but rather describes how a classical control computer interacts with those qubits.
By design, Q# thus does not define quantum states or other properties of quantum mechanics directly.
For instance, consider the state $\ket{+} = \left(\ket{0} + \ket{1}\right) / \sqrt{2}$ discussed in the [Quantum Computing Concepts](xref:microsoft.quantum.concepts.intro) guide.
To prepare this state in Q#, we use the facts that the qubits are initialized in the $\ket{0}$ state, and that $\ket{+} = H\ket{0}$, where $H$ is the Hadamard transform, implemented by the [`H` operation](](xref:microsoft.quantum.intrinsic.h):

```qsharp
using (qubit = Qubit()) {
    // At this point, qubit is in the state |0⟩.
    H(qubit);
    // We've now applied H, such that our qubit is in H|0⟩ = |+⟩, as we wanted.
}
```

## Quantum states in Q#

Importantly, in writing the above program, we did not explicitly refer to the state within Q#, but rather described how the state was *transformed* by our program.
This allows us to be entirely agnostic about what a quantum state even *is* on each target machine, which might have different interpretations depending on the machine. 

A Q# program has no ability to introspect into the state of a qubit.
Rather, a program can call operations such as [`Measure`](xref:microsoft.quantum.intrinsic.measure) to learn information from a qubit, and call operations such as [`X`](xref:microsoft.quantum.intrinsic.x) and [`H`](xref:microsoft.quantum.intrinsic.h) to act on the state of a qubit.
What these operations actually *do* is only made concrete by the target machine we use to run the particular Q# program.
For example, if running the program on our [full-state simulator](xref:microsoft.quantum.machines.full-state-simulator), the simulator will perform the corresponding mathematical operations to the simulated quantum system.
But looking toward the future, when the target machine is a real quantum computer, calling such operations in Q# will direct the quantum computer to perform the corresponding *real* operations on the *real* quantum system (e.g. precisely timed laser pulses).

A Q# program recombines these operations as defined by a target machine to create new, higher-level operations to express quantum computation.
In this way, Q# makes it easy to express the logic underlying quantum and hybrid quantum–classical algorithms, while also being general with respect to the structure of a target machine or simulator.

## Q# operations and functions

Concretely, a Q# program is comprised of *operations*, *functions*, and any user-defined types. 

Operations are used to describe the transformations of quantum systems and are the most basic building block of Q# programs. 
Each operation defined in Q# may then call any number of other operations.

In contrast to operations, functions are used to describe purely *deterministic* classical behavior and do not have any effects besides computing classical values. 
For example, suppose we would like to measure our qubits at the end of a program, and add the measurement results to an array.
In this case `Measure` is an *operation* which instructs the target machine to perform a measurement on the (real or simulated) qubits, and the classical process of adding the returned results to an array will be handled by *functions*.

Together, operations and functions are referred to as *callables*, and their underlying structure and behavior is introduced on the [Operations and Functions in Q#](xref:microsoft.quantum.guide.operationsfunctions) page.


## Q# syntax overview

The syntax of a language describes the different combinations of symbols that form a syntactically correct program.
In Q# we can classify the elements of its syntax in three different groups: types, expressions and statements.

### Types
Q# is a strongly-typed language, such that careful use of types can help the compiler provide strong guarantees about Q# programs at compile time.
In addition to standard and quantum-specific built-in primitive types (e.g. `Int`, `Bool`, `Qubit`, and `Result`), Q# provides support for user-defined types.
All of Q#'s various primitive types are described on the [Types in Q#](xref:microsoft.quantum.guide.types) page, along with details on array and tuple types, as well as how to define new types within a Q# file.

### Expressions
An expression in a programming language is a combination of one or more constants, variables, operators, and functions that the programming language interprets and evaluates to a specific value.
Most simply, for every type in a language, expressions of that type can be either *literals* or symbols bound to a value of that type.
For example, `5` is an `Int` literal (thus also an expression of type `Int`), and if the symbol `count` is bound to the integer value `5`, then `count` is also an integer expression.

Additionally, an expression can consist of other expressions combined with certain operators.
Hence another example of an `Int` expression which evaluates to `5` is `2+3`.

The possible expressions of types in Q#, as well as the compatible operators that can be used to form them, are detailed on the [Type Expressions in Q#](xref:microsoft.quantum.guide.expressions) page. 

### Statements 
A statement is a syntactic unit of an imperative programming language that expresses some action to be carried out.
Statements contrast with expressions in that statements do not return results and are executed solely for their side effects, while expressions always return a result and often do not have side effects at all.
This distinction is frequently observed in wording: an expression is evaluated, whereas a statement is executed.

A very basic example of a statement in Q# is assigning a symbol to an expression:
```qsharp
let count = 5;
```

A slightly more interesting example is the `for` statement which supports iteration and includes a *statement block*.
Suppose `qubits` is the symbol bound to a register of qubits (technically of type `Qubit[]`, i.e. an array of `Qubit` types). 
Then
```qsharp
for (qubit in qubits) {
    H(qubit);
}
```
is a statement which iterates over each qubit in the register, performing the `H` operation on each. 
Note that `H(qubit);` is a statement in itself as well.

In fact, any call expression of type `Unit` (those callables that do not return any information) may be used as a statement.
This is primarily of use when calling operations on qubits that return `Unit` because the purpose of the statement is to modify the implicit quantum state.
Expression evaluation statements require a terminating semicolon.

Nearly every aspect of a Q# program is built using statements, so no single page could encompass all the information relating to them.
However, their lexical structure and formatting is described on the [Q# File Structure](xref:microsoft.quantum.guide.filestructure) page, symbol binding assignment and scope at [Variables in Q#](xref:microsoft.quantum.guide.variables), and control flow loops such as `for` at [Control Flow in Q#](xref:microsoft.quantum.guide.controlflow).

## Next steps
Throughout the rest of this guide, we will show you how to use Q# to construct complex quantum programs through the basic building blocks of operations, functions, and types.

To get started, you can start learning about [Types in Q#](xref:microsoft.quantum.guide.types).

If you are interested in learning more about the foundations and motivation behind Q#, check out [Why do we need Q#?](https://devblogs.microsoft.com/qsharp/why-do-we-need-q/).

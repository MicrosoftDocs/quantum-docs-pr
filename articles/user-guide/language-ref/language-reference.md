---
title: Keyword and language reference
description: List of keywords and common symbols in the Q# language, with links to their respective pages in documentation
author: gillenhaalb
ms.author: a-gibec
ms.date: 09/20/2020
ms.topic: article
uid: microsoft.quantum.lang-ref.main-list
---

# Q# Keyword and Language Reference

This page contains brief descriptions and links to further information about all Q# language keywords and many common symbols. 
Each keyword is hyperlinked to its own dedicated page where you will find more details and examples of its use.

## Keywords

|Keyword|Description|
|----|-----------|
|[`Adjoint`](xref:microsoft.quantum.lang-ref.adjoint)|Operation functor; used to call the adjoint version of an operation.|
|[`adjoint`](xref:microsoft.quantum.lang-ref.adjoint-tag)|Specialization tag used to explicitly define the implementation of an operation's adjoint specialization.|
|[`apply-within`](xref:microsoft.quantum.lang-ref.apply-within)|Programming structure which allows an operation or statement block to be applied between a sandwich of the standard and adjoint implementations of another operation or statement block.|
|[`as`](xref:microsoft.quantum.lang-ref.as)|Used in an `open` statement to define a short name for a namespace.|
|[`auto`](xref:microsoft.quantum.lang-ref.auto)|Generation directive indicating that the compiler should select an appropriate directive to apply when generating an operation specialization.|
|[`body`](xref:microsoft.quantum.lang-ref.body-tag)|Specialization tag used to explicitly define the implementation of an operation's standard version (called when no functors are applied).|
|[`borrowing`](xref:microsoft.quantum.lang-ref.borrowing)|Used to allocate qubits for temporary use, which do not need to be in a specific state. Compare to `using`, which allocates fresh qubits in $\ket{0}$.|
|[`Controlled`](xref:microsoft.quantum.lang-ref.controlled)|Operation functor; used to call the controlled version of an operation.|
|[`controlled`](xref:microsoft.quantum.lang-ref.controlled-tag)|Specialization tag used to explicitly define the implementation of an operation's controlled specialization.|
|[`Controlled Adjoint`](xref:microsoft.quantum.lang-ref.controlled-adjoint)|Operation functor; used to call the controlled adjoint version of an operation.|
|[`controlled adjoint`](xref:microsoft.quantum.lang-ref.controlled-adjoint-tag)|Specialization tag used to explicitly define the implementation of an operation's controlled adjoint specialization. *Equivalent to `adjoint controlled`.*|
|[`distribute`](xref:microsoft.quantum.lang-ref.distribute)|Generation directive indicating how the compiler should generate an operation specialization. Can be used with `controlled` and `controlled adjoint` specializations.|
|[`elif`](xref:microsoft.quantum.lang-ref.elif)|Indicates an *else-if* clause, to be evaluated if a preceding *if* condition was *false*.|
|[`else`](xref:microsoft.quantum.lang-ref.else)|Indicates an *else* block, which will be run if, to be evaluated if the preceding *if* condition was *false* (in addition to any *else-if* conditions).|
|[`fail`](xref:microsoft.quantum.lang-ref.fail)|Ends the run of an operation and returns an error message to the caller.|
|[`fixup`](xref:microsoft.quantum.lang-ref.fixup)|Optional block to be run after each failed repetiton of a `repeat-until` loop.|
|[`for`](xref:microsoft.quantum.lang-ref.for)|Supports iteration over an integer range or an array. Used in conjunction with `in`.|
|[`function`](xref:microsoft.quantum.lang-ref.function)|Marks the declaration of a new function.|
|[`if`](xref:microsoft.quantum.lang-ref.if)|Followed by a Boolean expression, supports conditional processing.|
|[`in`](xref:microsoft.quantum.lang-ref.in)|Supports iteration over an integer range or an array. Used in conjunction with `for`.|
|[`internal`](xref:microsoft.quantum.lang-ref.internal)|When declaring an `operation`, `function`, or `newtype`, used to indicate that it is for internal use only, and not a part of the public API.|
|[`intrinsic`](xref:microsoft.quantum.lang-ref.intrinsic)|Generation directive indicating that the target machine provides an operation specialization.|
|[`invert`](xref:microsoft.quantum.lang-ref.invert)|Generation directive indicating how the compiler should generate an operation specialization. Can be used with `adjoint` and `controlled adjoint` specializations.|
|[`is Adj`](xref:microsoft.quantum.lang-ref.adj)|Annotation to the signature of an operation being defined; declares the existence of an adjoint specialization. Thus the `Adjoint` functor can be used when calling the operation.|
|[`is Adj + Ctl`](xref:microsoft.quantum.lang-ref.adj-ctl)|Annotation to the signature of an operation being defined; declares the existence of a controlled adjoint specialization. Thus the `Controlled Adjoint` functor can be used when calling the operation. *Equivalent to `is Ctl + Adj`.*|
|[`is Ctl`](xref:microsoft.quantum.lang-ref.ctl)|Annotation to the signature of an operation being defined; declares the existence of a controlled specialization. Thus the `Controlled` functor can be used when calling the operation.|
|[`let`](xref:microsoft.quantum.lang-ref.let)|Used to bind a value to an immutable variable. Compare to `mutable`, which allows rebinding.|
|[`mutable`](xref:microsoft.quantum.lang-ref.mutable)|Used to create a mutable variable which can be rebound using `set`.|
|[`namespace`](xref:microsoft.quantum.lang-ref.namespace)|Marks the declaration of a namespace within a Q# file; directly precedes the namespace name.|
|[`new`](xref:microsoft.quantum.lang-ref.new)|Used to create a new array of a given length and element-type.|
|[`newtype`](xref:microsoft.quantum.lang-ref.newtype)|Marks the declaration of a new user-defined type.|
|[`open`](xref:microsoft.quantum.lang-ref.open)|Directive used to import all types and callables defined within a certain namespace.|
|[`operation`](xref:microsoft.quantum.lang-ref.operation)|Marks the declaration of a new operation.|
|[`repeat-until`](xref:microsoft.quantum.lang-ref.repeat-until)|Programming structure supporting the quantum-specific *repeat-until-success* pattern. Runs the *repeat* loop body until a Boolean expression evaluates to `True`. Can be supplemented with a `fixup` block, which runs after each failed repetition.|
|[`return`](xref:microsoft.quantum.lang-ref.return)|Ends the run of an operation or function and returns a value to the caller. Not required in callables which return `Unit`.|
|[`self`](xref:microsoft.quantum.lang-ref.self)|Generation directive indicating that the `adjoint` specialization of an operation is the same as the `body` implementation. Can be used with `adjoint` and `adjoint controlled` specializations.|
|[`set`](xref:microsoft.quantum.lang-ref.set)|Used to rebind a mutable variable.|
|[`using`](xref:microsoft.quantum.lang-ref.using)|Used to allocate new qubits for use in a statement block.|
|[`while`](xref:microsoft.quantum.lang-ref.while)|Supports running a statement block until an expression evaluates to `True`. Only to be used within *functions*, while the quantum-specific `repeat-until` loops should be used inside *operations*.|

## Intrinsic types

|Type|Description|
|----|-----------|
|[`BigInt`](xref:microsoft.quantum.lang-ref.bigint)|...|
|[`Bool`](xref:microsoft.quantum.lang-ref.bool)|...|
|[`Double`](xref:microsoft.quantum.lang-ref.double)|...|
|[`Int`](xref:microsoft.quantum.lang-ref.int)|...|
|[`Pauli`](xref:microsoft.quantum.lang-ref.pauli)|...|
|[`Qubit`](xref:microsoft.quantum.lang-ref.qubit)|...|
|[`Range`](xref:microsoft.quantum.lang-ref.range)|...|
|[`Result`](xref:microsoft.quantum.lang-ref.result)|...|
|[`String`](xref:microsoft.quantum.lang-ref.string)|...|
|[`Unit`](xref:microsoft.quantum.lang-ref.unit)|...|

## Reserved values 

|Value|Type|
|----|-----------|
|[`True`](xref:microsoft.quantum.lang-ref.true)|`Bool`|
|[`False`](xref:microsoft.quantum.lang-ref.false)|`Bool`|
|[`Zero`](xref:microsoft.quantum.lang-ref.zero)|`Result`|
|[`One`](xref:microsoft.quantum.lang-ref.one)|`Result`|
|[`PauliI`](xref:microsoft.quantum.lang-ref.paulii)|`Pauli`|
|[`PauliX`](xref:microsoft.quantum.lang-ref.paulix)|`Pauli`|
|[`PauliY`](xref:microsoft.quantum.lang-ref.pauliy)|`Pauli`|
|[`PauliZ`](xref:microsoft.quantum.lang-ref.pauliz)|`Pauli`|



## Attributes

|Attribute|Description|
|----|-----------|
|[`@EntryPoint`](xref:microsoft.quantum.lang-ref.entrypoint)|Used when running Q# directly via the command line interface. Marks an operation as that which will be run upon the `dotnet run` command.|
|[`@Test`](xref:microsoft.quantum.lang-ref.test)|Marks an operation or function as a unit test to be run on a specific target machine. Can be used with any function that has no inputs or returns (i.e. simply `Unit`).|

## Symbols

|Symbol|Description|
|----|-----------|
|[`_`](xref:microsoft.quantum.lang-ref.partial-app-symb)|Used in partial application.|
|[`->`](xref:microsoft.quantum.lang-ref.fn-signature-symb)|Describes the signature of a *function*.|
|[`=>`](xref:microsoft.quantum.lang-ref.op-signature-symb)|Describes the signature of an *operation*.|




## See also

- ??
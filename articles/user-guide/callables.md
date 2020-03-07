---
title: Callables in Q# | Microsoft Docs 
description: Functions and operations
author: Gillenhaal Beck
ms.author: a-gibec@microsoft.com 
ms.date: 02/28/2020
ms.topic: article
uid: microsoft.quantum.guide.callables
---

# Q# Callables: operations and functions

`******` This page still very rough
`******` Use this page to talk about the underlying principles of the types, signatures, etc., and then use the `operations-functions.md` page to go more into detail/examples/implementation?

A Q# _operation_ is a quantum subroutine.
That is, it is a callable routine that contains quantum operations.

A Q# _function_ is a classical subroutine used within a quantum algorithm.
It may contain classical code but no quantum operations.
Specifically, functions may not allocate or borrow qubits, nor may they call operations.
It is possible, however, to pass them operations or qubits for processing.
Functions are thus entirely deterministic in the sense that calling them with the same arguments will always produce the same result. 

Together, operations and functions are called _callables_.
On this page, we will detail the underlying principles behind them as types in a relatively abstract manner.
On the following page, [Defining and using Q# callables](xref:microsoft.quantum.guide.operations-functions), these principles are presented in conjunction with many code examples.

## Callable types 

All Q# callables are considered to take a single value as input and return a single value as output.
Both the input and output values may be tuples.
Callables that have no result return `Unit`.
Callables that have no input take the empty tuple as input.

### Signatures specify the callable type

The basic type for any callable is written as `('Tinput => 'Tresult)` or `('Tinput -> 'Tresult)`, where both `'Tinput` and `'Tresult` are types.
These are called the *signature* of the callable.

> [!NOTE]
> The first form, with `=>`, is used for operations; the second form, with `->`, for functions.
> For example, `((Qubit, Pauli) => Result)` represents the signature for a possible single-qubit measurement operation.

*Function* types are completely specified by their signature.
For example, a function that computes the sine of an angle would have type `(Double -> Double)`.

*Operations*---but not functions---have certain additional characteristics that are expressed as part of the operation type. 
Such characteristics include information about what functors the operation supports.
We discuss the specifics of functors further below on this page. 
 
In order to require support for the `Controlled` and/or `Adjoint` functor in an operation type, we need to add an annotation indicating the corresponding characteristics.
An annotation `is Ctl` for example indicates that the operation is controllable (i.e. it's execution conditioned on the state of another qubit or qubits). 
If we want to require that an operation of that type supports both the `Adjoint` and `Controlled` functor we can express this as `(Qubit => Unit is Adj + Ctl)`. 

For example, the Pauli `X` operation has type `(Qubit => Unit is Adj + Ctl)`.
An operation type that does not support any functors is specified by its input and output type alone, with no additional annotation.

### Type-Parameterized Functions and Operations

Callable types may contain type parameters.
Type parameters are indicated by a symbol prefixed by a single quote; for example, `'A` is a legal type parameter.

A type parameter may appear more than once in a single signature.
For example, a function that applies another function to each element of an array and returns the collected results would have signature `(('A[], ('A->'A)) -> 'A[])`.
Similarly, a function that returns the composition of two operations might have signature `((('A=>'B), ('B=>'C)) -> ('A=>'C))`.

When invoking a type-parameterized callable, all arguments that have the same type parameter must be of the same type.

Q# does not provide a mechanism for constraining the possible types that might be substituted for a type parameter.

A callable literal may be used as a value, say to assign to a variable or to pass to another callable.
In this case, if the callable has type parameters, they must be provided as part of the callable value.
A callable value cannot have any unspecified type parameters.

For instance, if `Fun` is a function with signature `('T1 -> Unit)`:

```qsharp
let f = Fun<Int>;            // defining that the input type parameter 'T1 is Int, so f is (Int -> Unit).
SomeOtherFun(Fun<Double>);   // A (Double -> Unit) is passed to SomOtherFun.
let g = Fun;                 // This causes a compilation error.
SomeOtherFun(Fun);           // This also causes a compilation error.
```

### Type Compatibility

An operation with additional functors supported may be used anywhere an operation with fewer functors but the same signature is expected.
For instance, an operation of type `(Qubit => Unit is Adj)` may be used anywhere an operation of type `(Qubit => Unit)` is expected.

Q# is covariant with respect to callable return types: a callable that returns a type `'A` is compatible with a callable with the same input type and a result type that `'A` is compatible with.

Q# is contravariant with respect to input types: a callable that takes a type `'A` as input is compatible with a callable with the same result type and an input type that is compatible with `'A`.

That is, given the following definitions:

```qsharp
operation Invert(qubits : Qubit[]) : Unit 
is Adj {...} 

operation ApplyUnitary(qubits : Qubit[]) : Unit 
is Adj + Ctl {...} 

function ConjugateInvertWith(
    inner : (Qubit[] => Unit is Adj),
    outer : (Qubit[] => Unit is Adj))
: (Qubit[] => Unit is Adj) {...}

function ConjugateUnitaryWith(
    inner : (Qubit[] => Unit is Adj + Ctl),
    outer : (Qubit[] => Unit is Adj))
: (Qubit[] => Unit is Adj + Ctl) {...}
```

the following are true:

- The function `ConjugateInvertWith` may be invoked with an `inner` argument of either `Invert` or `ApplyUnitary`.
- The function `ConjugateUnitaryWith` may be invoked with an `inner` argument of `ApplyUnitary`, but not `Invert`.
- A value of type `(Qubit[] => Unit is Adj + Ctl)` may be returned from `ConjugateInvertWith`.

> [!IMPORTANT]
> Q# 0.3 introduced a significant difference in the behavior of user-defined types.
User-defined types are treated as a wrapped version of the underlying type, rather than as a subtype.
This means that a value of a user-defined type is not usable where a value of the underlying type is expected.

## Functors on operations

A functor in Q# is a factory that defines a new operation from another operation.
Functors have access to the implementation of the base operation when defining the implementation of the new operation.

A functor is used by applying it to an operation, returning a new operation.
For example, the operation that results from applying the `Adjoint` functor to the `Y` operation is written as `Adjoint Y`.
The new operation may then be invoked like any other operation.
Thus, `Adjoint Y(q1)` applies the Adjoint functor to the `Y` operation to generate a new operation, and applies that new operation to `q1`.

Similarly, `Controlled X(controls, target)` applies the Controlled functor to the `X` operation to generate a new operation, and applies that new operation to `controls` and `target`.

The two standard functors in Q# are `Adjoint` and `Controlled`.

Functors bind more closely than all other operators, except for the unwrap operator `!` and array indexing with `[]`.
Thus, the following are all legal, assuming that the operations support the functors used:

```qsharp
Adjoint Op(qs)
Controlled Op(controls, targets)
Controlled Adjoint Op(controls, targets)
Adjoint WrappedOp!(qs)
```

### Adjoint

In quantum computing, the adjoint of an operation is the complex conjugate transpose of the operation. For operations that implement a unitary operator, the adjoint is the inverse of the operation.
For a simple operation that just invokes a sequence of other unitary operations on a set of qubits, the adjoint may be computed by applying the adjoints of the sub-operations on the same qubits, in the reverse sequence.

Given an operation expression, a new operation expression may be formed using the `Adjoint` functor.
For instance, `Adjoint QFT` designates the adjoint of the `QFT` operation.
The new operation has the same signature and type as the base operation.
In particular, the new operation also allows `Adjoint`, and will allow `Controlled` if and only if the base operation did.

The Adjoint functor is its own inverse; that is, `Adjoint Adjoint Op` is always the same as `Op`.

### Controlled

The controlled version of an operation is a new operation that effectively applies the base operation only if all of the control qubits are in a specified state.
If the control qubits are in superposition, then the base operation is applied coherently to the appropriate part of the superposition.
Thus, controlled operations are often used to generate entanglement.

In Q#, controlled versions always take an array of control qubits, and the specified state is always for all of the control qubits to be in the computational (`PauliZ`) `One` state, $\ket{1}$.
Controlling based on other states may be achieved by applying the appropriate unitary operation to the control qubits before the controlled operation, and then applying the inverses of the unitary operation after the controlled operation.
For example, applying an `X` operation to a control qubit before and after a controlled operation will cause the operation to control on the `Zero` state ($\ket{0}$) for that qubit; applying an `H` operation before and after will control on the `PauliX` `One` state, that is -1 eigenvalue of Pauli X, $\ket{-} \mathrel{:=} (\ket{0} - \ket{1}) / \sqrt{2}$ rather than the `PauliZ` `One` state.

Given an operation expression, a new operation expression may be formed using the `Controlled` functor.
The signature of the new operation is based on the signature of the original operation.
The result type is the same, but the input type is a two-tuple with a qubit array that holds the control qubit(s) as the first element and the arguments of the original operation as the second element.
The new operation supports `Controlled`, and will support `Adjoint` if and only if the original operation did.

If the original operation took only a single argument, then singleton tuple equivalence will come into play here.
For instance, `Controlled X` is the controlled version of the `X` operation. 
`X` has type `(Qubit => Unit is Adj + Ctl)`, so `Controlled X` has type `((Qubit[], (Qubit)) => Unit is Adj + Ctl)`; because of singleton tuple equivalence, this is the same as `((Qubit[], Qubit) => Unit is Adj + Ctl)`.

If the base operation took several arguments, remember to enclose the corresponding arguments of the controlled version of the operation in parentheses to convert them into a tuple.
For instance, `Controlled Rz` is the controlled version of the `Rz` operation. `Rz` has type `((Double, Qubit) => Unit is Adj + Ctl)`, so `Controlled Rz` has type `((Qubit[], (Double, Qubit)) => Unit is Adj + Ctl)`.
Thus, `Controlled Rz(controls, (0.1, target))` would be a valid invocation of `Controlled Rz` (note the parentheses around `0.1, target`).

As another example, `CNOT(control, target)` can be implemented as `Controlled X([control], target)`. 
If a target should be controlled by 2 control qubits (CCNOT), we can use `Controlled X([control1, control2], target)` statement.



`******` blend in this following info to this or the following page

## Callable Invocation Expressions

Given a callable (operation or function) expression and a tuple expression of the input type of the callable's signature, an invocation expression may be formed by appending the tuple expression to the callable expression.
The type of the invocation expression is the output type of the callable's signature.

For example, if `Op` is an operation with signature `((Int, Qubit) => Double)`, `Op(3, qubit1)` is an expression of type `Double`.
Similarly, if `Sin` is a function with signature `(Double -> Double)`, `Sin(0.1)` is an expression of type `Double`.
Finally, if `Builder` is a function with signature `(Int -> (Int -> Int))`, then `Builder(3)` is a function with signature `(Int -> Int)`.

Invoking the result of a callable-valued expression requires an extra pair of parentheses around the callable expression.
Thus, to invoke the result of calling `Builder` from the previous paragraph, the correct syntax is:

```qsharp
(Builder(3))(2)
```

### Invoking type-parameterized callables

When invoking a type-parameterized callable, the actual type parameters may be specified within angle brackets `<` and `>` after the callable expression.
This is usually unnecessary as the Q# compiler will infer the actual types.
However, it is required for partial application (see below) if a type-parameterized argument is left unspecified.
It is also sometimes useful when passing operations with different functor supports to a callable.

For instance, suppose
- `Func` has signature `(('T1, 'T2, 'T1) -> 'T2)`, 
- `Op1` and `Op2` have signature `(Qubit[] => Unit is Adj)`, and
- `Op3` has signature `(Qubit[] => Unit)`.
Then, to invoke `Func` with `Op1` as the first argument, `Op2`
as the second, and `Op3` as the third:

```qsharp
let combinedOp = Func<(Qubit[] => Unit), (Qubit[] => Unit is Adj)>(Op1, Op2, Op3);
```
`******` Do we need an additional type parameter here?^

The type specification is required because `Op3` and `Op1` have different types, so the compiler will treat this as ambiguous without the specification.

### Partial Application

Given a callable expression, a new callable may be created by providing a subset of the arguments to the callable.
This is called _partial application_.

In Q#, a partially applied callable is expressed by writing a normal invocation expression, but using an underscore, `_`, for the unspecified arguments.
The resulting callable has the same result type as the base callable, and the same specializations for operations.
The input type of the partial application is simply the original type with the specified arguments removed.

If a mutable variable is passed as a specified argument when creating
a partial application, the current value of the variable is used.
Changing the value of the variable afterward will not impact the partial
application.

For example, if `Op` has type
`((Int, ((Qubit, Qubit), Double)) => Unit is Adj)`:

- `Op(5,(_,_))` has type `(((Qubit,Qubit), Double) => Unit is Adj)`, and so has `Op(5,_)`.
- `Op(_,(_,1.0))` has type `((Int, (Qubit,Qubit)) => Unit is Adj)`.
- `Op(_,((q1,q2),_))` has type `((Int,Double) => Unit is Adj)`.
   Note that we have applied singleton tuple equivalence here.

If the partially-applied callable has type parameters that cannot be
inferred by the compiler, they must be provided at the invocation site.
The partial application cannot have any unspecified type parameters.

For example, if `Op` has type
`(('T1, Qubit, 'T1) => Unit : Adjoint)`:

```qsharp
let f1 = Op<Int>(_, qb, _); // f1 has type ((Int,Int) => Unit is Adj)
let f2 = Op(5, qb, _);      // f2 has type (Int => Unit is Adj)
let f3 = Op(_,qb, _);       // f3 generates a compilation error
```

### Recursion

Q# callables are allowed to be directly or indirectly recursive.
That is, an operation or function may call itself, or it may call
another callable that directly or indirectly calls the callable operation.

There are two important comments about the use of recursion, however:

- The use of recursion in operations is likely to interfere with certain optimizations.
  This may have a substantial impact on the execution time of the algorithm.
- When executing on an actual quantum device, stack space may be limited, and so deep recursion may lead to a runtime error.
  In particular, the Q# compiler and runtime do not identify and optimize tail recursion.
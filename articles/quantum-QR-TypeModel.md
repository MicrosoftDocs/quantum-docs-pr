---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Q# type model | Microsoft Docs 
description: Q# type model
author: QuantumWriter
uid: microsoft.quantum.qsharp-ref.type-model
ms.author: Alan.Geller@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# For Quantum products none of these categories have been defined  yet.
# ms.service: service-name-from-white-list
# ms.prod: product-name-from-white-list
# ms.technology: tech-name-from-white-list
---

# The Type Model

This section lays out the Q# type model and describes the syntax for 
specifying and working with types.

## Primitive Types

Q# provides several primitive types, out of which all other types 
are constructed:
- The `Int` type represents a 64- bit signed (two's complement) integer. 
- The `Double` type represents a double-precision floating-point number. 
- The `Bool` type represents a Boolean value, either `true` or `false`.
- The `Qubit` type represents a quantum bit or qubit. 
  `Qubit`s are opaque to the user; the only operation possible with them,
   other than passing them to another operation, is to test for identity 
   (equality).
   Ultimately, actions on `Qubit`s are implemented by calling operations
   in the Q# standard library.
- The `Pauli` type represents an element of the single-qubit Pauli group. 
   This type is used to denote the base operation for rotations and 
   to specify the basis of a measurement. 
   This type is a discriminated union with four possible values: 
   `PauliI`, `PauliX`, `PauliY`, and `PauliZ`.
- The `Result` type represents the result of a measurement.
   This type is a discriminated union with two possible values: 
   `One` and `Zero`. 
   `Zero` indicates that the +1 eigenvalue was measured; 
   `One` indicates the -1 eigenvalue.
- The `Range` type represents a sequence of integers. 
- The `String` type is a sequence of Unicode characters that
  is opaque to the user once created.
  This type is used to report messages to a classical host.

Note that this implies that `true`, `false`, `PauliI`, `PauliX`, 
`PauliY`, `PauliZ`, `One`, and `Zero` are all reserved symbols in Q#.

## Array Types

Given any valid Q# type `'T`, there is a type that represents an 
array of values of type `'T`. 
This array type is represented as `'T[]`; 
for example, `Qubit[]` or `Int[][]`.

In the second example, note that this represents a potentially 
jagged array of arrays, and not a rectangular two-dimensional array. 
Q# does not include support for rectangular multi-dimensional arrays.

## Tuple Types

Given any valid Q# types `'T1`, `'T2`, `'T3`, etc., there is a type that 
represents a tuple of values of types `'T1`, `'T2`, `'T3`, etc., 
respectively. 
This tuple type is represented as `('T1, 'T2, 'T3, …)`. 
Any number of types may be tupled together.
The empty tuple, `()`, is equivalent to `unit` in F#. 

It is possible to create arrays of tuples, tuples of arrays, 
tuples of sub-tuples, etc.

Tuple instances are immutable.
Q# does not provide a mechanism to change the contents of a tuple 
once created.

## Singleton Tuple Equivalence

It is possible to create a singleton (single-element) tuple, `('T1)`, 
such as `(5)` or `([1;2;3])`.
However, Q# treats a singleton tuple as completely equivalent 
to a value of the enclosed type.
That is, there is no difference between `5` and `(5)`, or between 
`5` and `(((5)))`, or between `(5, (6))` and `(5, 6)`.

This equivalence applies for all purposes, including assignment and expressions.
It is just as valid to write `(5)+3` as to write `5+3`, 
and both expressions will evaluate to `8`.

We refer to this property as _singleton tuple equivalence_.

## User-Defined Types

A Q# file may define a new named type based on a standard type. 
Any legal type may be used as the base for a user-defined type.

User-defined types may be used anywhere any other type may be used. 
In particular, it is possible to define an array of a user-defined type 
and to include a user-defined type as an element of a tuple type.

It is not possible to create recursive type structures.
That is, the type that defines a user-defined type may not be a tuple type
that includes an element of the user-defined type.
More generally, user-defined types may not have cyclic dependencies
on each other, so the following set of type definitions would be illegal:

```qsharp
newtype TypeA = (Int, TypeB);
newtype TypeB = (Double, TypeC);
newtype TypeC = (TypeA, Range);
```

The mutability of instances of user-defined types is the same as the
mutability of instances of the base type of the user-defined type.
Specifically, instances of user-defined types based on tuples are
immutable; instances of user-defined types based on arrays are
potentially mutable.

### Type Compatibility

Effectively, a user-defined type is a subtype of the base type. 
Thus, a value of a user-defined type may be used anywhere a value 
of the base type is expected. 
This is applied recursively.

For example, suppose type `IntPair` is a user-defined type with base type 
`(Int, Int)`, and type `IntPair2` is a user-defined type with base type 
`IntPair`.
A value of type `IntPair2` may be used anywhere a value of type `IntPair2`, 
`IntPair`, or `(Int, Int)` is expected.
A value of type `IntPair` may be used anywhere a value of type `IntPair` or
`(Int, Int)` is expected.

Different user-defined types based on the same base type are treated as
distinct and unrelated types. 
In the previous example, if `IntPair3` is also a user-defined type with
base type `(Int, Int)`, then `IntPair` and `IntPair3` are unrelated and
a value of one may not be used where a value of the other is expected.

## Operation and Function Types

A Q# _operation_ is a quantum subroutine.
That is, it is a callable routine that contains quantum operations.

A Q# _function_ is a classical subroutine used within 
a quantum algorithm.
It may contain classical code but no quantum operations.
Functions may not allocate or borrow qubits, nor may they call operations. It is possible, however, to pass them operations or qubits for processing. 

Together, operations and functions are known as _callables_.

All Q# callables are considered to take a single value as input 
and return a single value as output. 
Both the input and output values may be tuples.
Callables that have no result return the empty tuple, `()`;
callables that have no input take the empty tuple as input.

The basic signature for any callable is written as 
`('Tinput => 'Tresult)` or `('Tinput -> 'Tresult)`, 
where both `'Tinput` and `'Tresult` are type specifiers. 
The first form, with `=>`, is used for operations; 
the second form, with `->`, for functions.
For example, `((Qubit, Pauli) => Result)` represents the 
signature for a possible single-qubit measurement operation.

Function types are completely specified by their signature.
For example, a function that computes the sine of an angle 
would have type `(Double -> Double)`.

Operations -- but not functions -- may allow the application of 
one or more functors.
Functors are meta-operations that generate a variant of a base operation; 
see [Functors](#functors), below.

Operation types are specified by the their signature 
and the list of functors they support.
For example, the Pauli `X` operation has type 
`(Qubit => () : Adjoint, Controlled)`.
An operation type that does not support any functors is specified
by its signature alone, with no trailing `:`.

### Type-Parameterized Functions and Operations

Callable signatures may contain type parameters.
Type parameters are indicated by a symbol prefixed by a single quote;
for example, `'A` is a legal type parameter.
Type-parameterized functions and operations are similar to generic
functions in many programming languages, but Q# does not provide
a full generic type/function capability.

A type parameter may appear more than once in a single signature.
For example, a function that applies another function to each element
of an array and returns the collected results would have signature 
`(('A[], 'A->'A) -> 'A[])`.
Similarly, a function that returns the composition of two operations
might have signature `((('A=>'B), ('B=>'C)) -> ('A=>'C))`.

When invoking a type-parameterized callable, all arguments that have the same type parameter must be of the same type, or be compatible with the same type; that is.

Q# does not provide a mechanism for constraining the possible types
that might be substituted for a type parameter.
Thus, type parameters are primarily useful for functions on arrays and 
for composing callables.

### Type Compatibility

An operation with additional functors supported may be used anywhere
an operation with fewer functors but the same signature is expected.
For instance, an operation of type `(Qubit=>():Adjoint)` may be used 
anywhere an operation of type `(Qubit=>())` is expected.

Q# is covariant with respect to callable return types:
a callable that returns a type `'A` is compatible with a callable with 
the same input type and a result type that `'A` is compatible with.

Q# is contravariant with respect to input types:
a callable that takes a type `'A` as input is compatible with a callable 
with the same result type and an input type that is compatible with `'A`.

That is, given the following type definitions:

    newtype IntPair : (Int, Int) 
    newtype IntPairTransform : ((Int, Int) -> (Int, Int))
    newType IntPairTransform2 : ((Int, Int) -> IntPair)   
    newType IntPairTransform3 : (IntPair -> (Int, Int))   

the following are true:
 - A value of type `IntPairTransform` may be invoked with a single argument 
    of type `IntPair`.
 - The result of invoking a function of type `IntPairTransform` may not be 
    used where a value of type `IntPair` is expected.
 - A value of type `IntPairTransform2` may be used when an `IntPairTransform` 
    is expected, but not _vice versa_.
 - A value of type `IntPairTransform` may be used when an `IntPairTransform3`
    is expected, but not _vice versa_.

### Functors

A functor in Q# is a factory that defines a new operation 
from another operation.
Functors have access to the implementation of the base operation when 
defining the implementation of the new operation. 
Thus, functors can perform more complex functions than 
traditional higher-level functions.

A functor is used by applying it to an operation, returning a new operation.
For example, the operation that results from applying the `Adjoint` functor 
to the `Y` operation is written as `(Adjoint Y)`.
The new operation may then be invoked like any other operation.
Thus, `(Adjoint Y)(q1)` applies the adjoint functor to the `Y` operation to
generate a new operation, and applies that new operation to `q1`.

Similarly, `(Controlled X)(controls, target)` 

The two standard functors in Q# are `Adjoint` and `Controlled`.

#### Adjoint

In quantum computing, the adjoint of an operation is the 
complex conjugate transpose of the operation.
For operations that implement a unitary operator, the adjoint is the 
inverse of the operation.
For a simple operation that just invokes a sequence of other
unitary operations on a set of qubits, the adjoint may be computed
by applying the adjoints of the sub-operations on the same qubits,
in the reverse sequence.

Given an operation expression, a new operation expression may be formed 
using the `Adjoint` functor, with the base operation expression 
enclosed in parentheses, `(` and `)`. 
The new operation has the same signature and type as the base operation.
In particular, the new operation also allows `Adjoint`, and will allow
`Controlled` if and only if the base operation did.

For instance, `(Adjoint QFT)` designates the adjoint of the `QFT` operation.

#### Controlled

The controlled version of an operation is a new operation that effectively 
applies the base operation only if all of the control qubits are in a
specified state.
If the control qubits are in superposition, then the base operation is
applied coherently to the appropriate part of the superposition.
Thus, controlled operations are often used to generate entanglement.

In Q#, controlled versions always take an array of control qubits,
and the specified state is always for all of the control qubits to be
in the computational (`PauliZ`) `One` state, $\ket{1}$.
Controlling based on other states may be achieved by applying the
appropriate Clifford operations to the control qubits before the
controlled operation, and then applying the inverses of the Cliffords
after the controlled operation.
For example, applying an `X` operation to a control qubit before and after
a controlled operation will cause the operation to control 
on the `Zero` state ($\ket{0}$) for that qubit; applying an `H` operation will control
on the `PauliX` `Zero` state $\ket{+} \mathrel{:=} (\ket{0} + \ket{1}) / \sqrt{2}$
rather than the `PauliZ` `Zero` state.

Given an operation expression, a new operation expression 
may be formed using the `Controlled` functor, with the base operation 
expression enclosed in parentheses, `(` and `)`. 
The signature of the new operation is based on the signature of the 
base operation.
The result type is the same, but the input type is a two-tuple with a 
qubit array that holds the control qubit(s) as the first element and
the arguments of the base operation as the second element.
If the base operation took no arguments, `()`, then the input type of
the controlled version is just the array of control qubits.
The new operation allows `Controlled`, and will allow
`Adjoint` if and only if the base operation did.

If the base function took only a single argument, then singleton
tuple equivalence will come into play here.
For instance, `Controlled(X)` is the controlled version of the
`X` operation.
`X` has type `(Qubit => () : Adjoint, Controlled)`, so `Controlled(X)` 
has type `((Qubit[], (Qubit)) => () : Adjoint, Controlled)`;
because of singleton tuple equivalence, this is the same as
`((Qubit[], Qubit) => () : Adjoint, Controlled)`.

Similarly, `Controlled(Rz)` is the controlled version of the
`Rz` operation.
`Rz` has type `((Double, Qubit) => () : Adjoint, Controlled)`, 
so `Controlled(Rz)` has type 
`((Qubit[], (Double, Qubit)) => () : Adjoint, Controlled)`.
For example, `((Controlled(Rz))(controls, (0.1, target))` would be 
a valid invocation of `Controlled(Rz)`.

As another example, `CNOT(control, target)` can be implemented as `(Controlled(X))([control], target)`. 
If a target should be controlled by 2 control qubits (CCNOT), we can use `(Controlled(X))([control1;control2], target)` statement.


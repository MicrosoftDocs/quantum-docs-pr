---
title: Q# type model | Microsoft Docs 
description: Q# type model
author: QuantumWriter
uid: microsoft.quantum.qsharp-ref.type-model
ms.author: Alan.Geller@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
uid: microsoft.quantum.language.type-model
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
- The `Pauli` type represents one of the four single-qubit Pauli operators.
   This type is used to denote the base operation for rotations and
   to specify the observable being measured.
   This is an enumerated type that has four possible values:
   `PauliI`, `PauliX`, `PauliY`, and `PauliZ`, which are constants of type `Pauli`.
- The `Result` type represents the result of a measurement.
   This is an enumerated type with two possible values:
   `One` and `Zero`, which are constants of type `Result`.
   `Zero` indicates that the +1 eigenvalue was measured;
   `One` indicates the -1 eigenvalue.
- The `Range` type represents a sequence of integers.
- The `String` type is a sequence of Unicode characters that
  is opaque to the user once created.
  This type is used to report messages to a classical host.
- :new: The `Unit` type is the type that allows only one value `()`. 
  This type is used to indicate that Q# function or operation returns no information. 

The constants `true`, `false`, `PauliI`, `PauliX`,
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

:new: In Q# 0.3, we have introduced `Unit` as the name for the *type*
of the empty tuple; `()` is used for the empty tuple *value*.
For now, `()` is still supported as a type name, but this is deprecated
and may break in the future.

It is possible to create arrays of tuples, tuples of arrays,
tuples of sub-tuples, etc.

Tuple instances are immutable.
Q# does not provide a mechanism to change the contents of a tuple
once created.

## Singleton Tuple Equivalence

It is possible to create a singleton (single-element) tuple, `('T1)`,
such as `(5)` or `([1,2,3])`.
However, Q# treats a singleton tuple as completely equivalent
to a value of the enclosed type.
That is, there is no difference between `5` and `(5)`, or between
`5` and `(((5)))`, or between `(5, (6))` and `(5, 6)`.

This equivalence applies for all purposes,
including assignment and expressions.
It is just as valid to write `(5)+3` as to write `5+3`,
and both expressions will evaluate to `8`.

We refer to this property as _singleton tuple equivalence_.

## User-Defined Types

A Q# file may define a new named type based on a standard type.
Any legal type, including an existing user-defined type,
may be used as the base for a new user-defined type.

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

> [!IMPORTANT]
> Q# 0.3 introduces a significant difference in the behavior of
> user-defined types.

:new: User-defined types are now treated as a wrapped version of
the base type, rather than as a subtype.
This means that a value of a user-defined type is not usable
where a value of the base type is expected.

Q# 0.3 introduces the "unwrap" operator, `!`, which unwraps a value of a
user-defined type to a value of the base type.
The unwrap operator unwraps exactly one layer of wrapping.
Multiple unwrap operators may be used to access a multiply-wrapped base value.

For instance:

```qsharp
newtype WrappedInt = Int;
newtype DoublyWrappedInt = WrappedInt;

...
    let x = DoublyWrappedInt(WrappedInt(6));
    let y = x!;       // y is WrappedInt(6)
    let z = x!!;      // z is 6
    let a = x + 5;    // This is an error, a DoublyWrappedInt isn't an Int
    let b = x! + 5;   // Also an error
    let c = x!! + 5;  // This is valid, c will be 11
...
```

## Operation and Function Types

A Q# _operation_ is a quantum subroutine.
That is, it is a callable routine that contains quantum operations.

A Q# _function_ is a classical subroutine used within
a quantum algorithm.
It may contain classical code but no quantum operations.
Functions may not allocate or borrow qubits, nor may they call operations.
It is possible, however, to pass them operations or qubits for processing.

Together, operations and functions are called _callables_.

All Q# callables are considered to take a single value as input
and return a single value as output.
Both the input and output values may be tuples.
:new: Callables that have no result return `Unit`.
Callables that have no input take the empty tuple as input.

The basic type for any callable is written as
`('Tinput => 'Tresult)` or `('Tinput -> 'Tresult)`,
where both `'Tinput` and `'Tresult` are types.
The first form, with `=>`, is used for operations;
the second form, with `->`, for functions.
For example, `((Qubit, Pauli) => Result)` represents the
signature for a possible single-qubit measurement operation.

Function types are completely specified by their signature.
For example, a function that computes the sine of an angle
would have type `(Double -> Double)`.

Operations -- but not functions -- may allow the application of
one or more functors.
Functors are meta-operations that generate a specialization of a base operation;
see [Functors](#functors), below.

Operation types are specified by the their signature
and the list of functors they support.
For example, the Pauli `X` operation has type
`(Qubit => Unit : Adjoint, Controlled)`.
An operation type that does not support any functors is specified
by its signature alone, with no trailing `:`.

### Type-Parameterized Functions and Operations

Callable types may contain type parameters.
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

When invoking a type-parameterized callable, all arguments that have the same
type parameter must be of the same type.

Q# does not provide a mechanism for constraining the possible types
that might be substituted for a type parameter.
Thus, type parameters are primarily useful for functions on arrays and
for composing callables.

### Type Compatibility

> [!IMPORTANT]
> Q# 0.3 introduces a significant difference in the behavior of user-defined types.

:new: User-defined types are now treated as a wrapped version of the base type,
rather than as a subtype.
This means that a value of a user-defined type is not usable where a value of the
base type is expected.

An operation with additional functors supported may be used anywhere
an operation with fewer functors but the same signature is expected.
For instance, an operation of type `(Qubit => Unit : Adjoint)` may be used
anywhere an operation of type `(Qubit => Unit)` is expected.

Q# is covariant with respect to callable return types:
a callable that returns a type `'A` is compatible with a callable with
the same input type and a result type that `'A` is compatible with.

Q# is contravariant with respect to input types:
a callable that takes a type `'A` as input is compatible with a callable
with the same result type and an input type that is compatible with `'A`.

That is, given the following definitions:

```qsharp
operation Invertible (qs : Qubit[]) : Unit {...} // Defines an Adjoint
operation Controllable (qs : Qubit[]) : Unit {...}    // Defines both Adjoint and Controlled
function ConjugateInvertibleWith : (inner: ((Qubit[] => Unit) : Adjoint),
                                    outer : ((Qubit[] => Unit) : Adjoint))
                                 : ((Qubit[] => Unit) : Adjoint)
function ConjugateControllableWith : (inner: ((Qubit[] => Unit) : Adjoint, Controlled),
                                      outer : ((Qubit[] => Unit) : Adjoint))
                                   : ((Qubit[] => Unit) : Adjoint, Controlled)
```

the following are true:

- The operation `ConjugateInvertibleWith` may be invoked with an `inner`
  argument of either `Invertible` or `Controllable`.
- The operation `ConjugateControllableWith` may be invoked with an `inner`
  argument of `Controllable`, but not `Invertible`.
- A value of type `((Qubit[] => Unit) : Adjoint, Controlled)` may be returned
  from `ConjugateInvertibleWith`.

### Functors

A functor in Q# is a factory that defines a new operation
from another operation.
Functors have access to the implementation of the base operation when
defining the implementation of the new operation.
Thus, functors can perform more complex functions than
traditional higher-level functions.

A functor is used by applying it to an operation, returning a new operation.
For example, the operation that results from applying the `Adjoint` functor
to the `Y` operation is written as `Adjoint Y`.
The new operation may then be invoked like any other operation.
Thus, `Adjoint Y(q1)` applies the Adjoint functor to the `Y` operation to
generate a new operation, and applies that new operation to `q1`.

Similarly, `Controlled X(controls, target)` applies the Controlled functor
to the `X` operation to generate a new operation, and applies that new
operation to `controls` and `target`.

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
using the `Adjoint` functor modifier.
For instance, `Adjoint QFT` designates the adjoint of the `QFT` operation.
The new operation has the same signature and type as the base operation.
In particular, the new operation also allows `Adjoint`, and will allow
`Controlled` if and only if the base operation did.

The Adjoint functor is its own inverse; that is, `Adjoint Adjoint Op` is
always the same as `Op`.

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
appropriate unitary operation to the control qubits before the
controlled operation, and then applying the inverses of the unitary operation
after the controlled operation.
For example, applying an `X` operation to a control qubit before and after
a controlled operation will cause the operation to control
on the `Zero` state ($\ket{0}$) for that qubit; applying an `H` operation before and after will control
on the `PauliX` `One` state, that is -1 eigenvalue of Pauli X, $\ket{-} \mathrel{:=} (\ket{0} - \ket{1}) / \sqrt{2}$
rather than the `PauliZ` `One` state.

Given an operation expression, a new operation expression
may be formed using the `Controlled` functor followed by the base operation
expression.
The signature of the new operation is based on the signature of the
base operation.
The result type is the same, but the input type is a two-tuple with a
qubit array that holds the control qubit(s) as the first element and
the arguments of the base operation as the second element.
The new operation allows `Controlled`, and will allow
`Adjoint` if and only if the base operation did.

If the base operation took no arguments, `()`, then the input type of
the controlled version is just the array of control qubits.

If the base operation took only a single argument, then singleton
tuple equivalence will come into play here.
For instance, `Controlled X` is the controlled version of the
`X` operation.
`X` has type `(Qubit => Unit : Adjoint, Controlled)`, so `Controlled X`
has type `((Qubit[], (Qubit)) => Unit : Adjoint, Controlled)`;
because of singleton tuple equivalence, this is the same as
`((Qubit[], Qubit) => Unit : Adjoint, Controlled)`.

If the base operation took several arguments, remember to enclose 
the corresponding arguments of the controlled version of the operation in parentheses 
to convert them into a tuple.
For instance, `Controlled Rz` is the controlled version of the
`Rz` operation.
`Rz` has type `((Double, Qubit) => Unit : Adjoint, Controlled)`,
so `Controlled Rz` has type
`((Qubit[], (Double, Qubit)) => Unit : Adjoint, Controlled)`.
Thus, `Controlled Rz(controls, (0.1, target))` would be
a valid invocation of `Controlled Rz` (note the parentheses around `0.1, target`).

As another example, `CNOT(control, target)` can be implemented as `Controlled X([control], target)`. 
If a target should be controlled by 2 control qubits (CCNOT), we can use `Controlled X([control1;control2], target)` statement.

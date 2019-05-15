---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Q# techniques - type model | Microsoft Docs 
description: Q# techniques - type model
author: QuantumWriter
uid: microsoft.quantum.techniques.type-model
ms.author: Christopher.Granade@microsoft.com
ms.date: 12/11/2017
ms.topic: article
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# For Quantum products none of these categories have been defined  yet.
# ms.service: service-name-from-white-list
# ms.prod: product-name-from-white-list
# ms.technology: tech-name-from-white-list
---

# Q# Type Model #

In discussing how to define Q# operations and functions, we have seen that inputs to and outputs from callables are each denoted along with their *types*.
At this point, it is helpful to take a step back and discuss these types in more detail.
In particular, we note that Q# is a *strongly-typed* language, such that careful use of these types can help the compiler to provide strong guarantees about Q# programs at compile time.

> [!WARNING] 
> In order to provide the strongest guarantees possible, conversions between types in Q# **must** be made explicitly using calls to functions which express that conversion. 
> A variety of such functions are provided as a part of the @"microsoft.quantum.extensions.convert" namespace.
> Upcasts to compatible types on the other hand happen implicitly. 

Q# provides both primitive types, which can be used directly, and a variety of ways to produce new types from other types.
We describe each in the rest of this section.

## Primitive Types ##

The Q# language provides a small set of *primitive types* that can be used throughout operations and functions.

- **`Int`**: Represents 64-bit signed integers, e.g.: `2`, `107`, `-5`.
- **`BigInt`**: Represents an arbitrary-sized signed integer, e.g. `2L`, `107L`, `-5L`.
- **`Double`**: Represents double-precision floating point numbers, e.g.: `0.0`, `-1.3`, `4e-7`.
- **`Bool`**: Represents a condition which can either be `true` or `false`.
- **`Pauli`**: Represents one of the Pauli matrices, either `PauliI`, `PauliX`, `PauliY`, or `PauliZ`.
- **`Result`**: Represents the result of a measurement in the computational basis, either `Zero` for $\ket{0}$ or `One` for $\ket{1}$.
- **`Range`**: Represents a consecutive sequence of integers, denoted by `start..step..stop`. E.g: `1..2..7` represents the sequence $\{1, 3, 5, 7\}$.
- **`String`**: Represents a message to be reported in the case of an error or diagnostic event.

In addition, Q# defines a primitive type `Qubit` to model an opaque reference to a qubit within a target machine.
A value of type `Qubit` cannot be directly used in Q#, but can be passed to operations defined by a target machine (such as gates and measurements) in order to do interesting things.
We will consider the `Qubit` type in much more detail in the section on [using qubits](#using-qubits).

## Tuple Types ##

Given zero or more different types `T0`, `T1`, ..., `Tn`, we can denote a new  *tuple type* as `(T0, T1, ..., Tn)`.
Values of the new tuple type are tuples formed by sequences of values from each type in the tuple.
For instance, `(3, false)` is a tuple whose type is the tuple type `(Int, Bool)`.
The types used to construct a new tuple type can themselves be tuples, as in `(Int, (Qubit, Qubit))`.
Such nesting is always finite, however, as tuple types cannot under any circumstances contain themselves.

Tuples are a powerful concept used throughout Q# to collect values together into a single value, making it easier to pass them around.
In particular, using tuple notation, we can express that every operation and callable takes exactly one input and returns exactly one output.

In Q#, a tuple type with exactly one element is considered to be equivalent to the type of that element alone, a property known as *singleton tuple equivalence*.
For instance, there is no difference between the types `Qubit`, `(Qubit)`, and `((((Qubit))))`.
In particular, this means that an operation or function whose input tuple or output tuple type has one field can be thought of as taking a single argument or returning a single value.

## Array Types ##

Given any other type `T`, the type `T[]` denotes an array of values of that type.
For instance, a collection of integers is denoted `Int[]`, while an array of arrays of `(Bool, Pauli)` values is denoted `(Bool, Pauli)[][]`.

An array value can be written in Q# source code by using square brackets around the elements of an array, as in `[PauliI, PauliX, PauliY, PauliZ]`.
The type of an array literal is determined by the common base type of all items in the array. 

> [!WARNING]
> The elements of an array cannot be changed after the array has been created.
> Update-and-reassign statements and/or copy-and-update expressions can be used to construct a modified array.

Alternatively, an array can be created from its size using the `new` keyword:

```qsharp
let zeros = new Int[13];
// new also allows for creating empty arrays:
let emptyRegister = new Qubit[0];
```

In either case, once an array has been constructed, the built-in `Length` function can be used to obtain the number of elements as an `Int`.
Arrays can be subscripted using square brackets, with subscripts either having type `Int` or type `Range`, to obtain either single elements or new arrays containing a subset of the elements of an array.
The subscripts of arrays are zero-based:

```qsharp
let arr = [10, 11, 36, 49];
let ten = arr[0]; // 10
let odds = arr[1..2..4]; // [11, 49]
```

## Operation and Function Types ##

As noted above, operations and functions are values in and of themselves in Q#.
The types of these values are constructed from the types of the input and output tuples that each operation and function takes and returns, as well as its characteristics.
To see this in practice, let's consider the `ApplyTwice` example from above:

```qsharp
operation ApplyTwice(op : (Qubit => Unit), target : Qubit) : Unit {
    ...
```

Here, we see that the operation declaration specifies that `op` has type `(Qubit => Unit)`, 
which means that the type of `op` is an operation type, and has as its valid values operations which accept an input of `Qubit` and produce an output of `Unit`.
We can indicate functions in the same way by using `->` instead of `=>`.
The types before and after each arrow can be whatever type we wish, including other operation or function types.
For instance, we can pass the function `SquareOperation` defined above to any input expecting type ` ((Qubit => Unit) -> (Qubit => Unit))`.
Informally, we can read that type as "a classical function which takes operations on a single qubit and returns operations on a single qubit."

In order to require support for the `Controlled` and/or `Adjoint` functor in an operation type, we need to add an annotation indicating the corresponding characteristics.
An annotation `is Ctl` for example indicates that the operation is controllable. 
If we want to require that an operation of that type supports both the `Adjoint` and `Controlled` functor we can express this as `(Qubit => Unit is Adj + Ctl)`. 
The used operation characteristics `Adj` and `Ctl` strictly speaking are two pre-defined sets of labels, where each label indicates a particular operation characteristics like e.g. support for a particular functor.
Hence, `+` is used to indicate the union of those two sets, and `*` is used to indicate the intersection - i.e. the labels that are common to both sets.  

## User-Defined Types ##

The final way to construct new types in Q# is with *user-defined types* (UDTs).
For any tuple type `T`, we can declare a new user-defined type that is a subtype of `T` with the `newtype` statement.
In the @"microsoft.quantum.canon" namespace, for instance, complex numbers are defined as a user-defined type:

```qsharp
newtype Complex = (Double, Double);
```

This statement creates a new type which is effectively a label for a particular tuple type.
Values of the new type are created by calling the corresponding type constructor:

```
let realUnit = Complex(1.0, 0.0);
let imaginaryUnit = Complex(0.0, 1.0);
```

In order to access the items in a user defined type, the tuple first needs to be extracted to give an expression of the corresponding tuple type. 
The postfix operator `!` will do this extraction.
This lets us write out accessor functions into the structure of a user-defined type, for instance:

```qsharp
function Re(z : Complex) : Double {
    let (re, im) = z!;
    return re;
}

function Im(z : Complex) : Double {
    let (re, im) = z!;
    return im;
}
```

In addition to providing short aliases for potentially complicated tuple types, one significant advantage of using UDTs is that they can document the intent of a particular value.
Returning to the example of `Complex`, one could have also defined 2D polar coordinates as a user-defined type:

```qsharp
newtype Polar = (Double, Double);
```

Even though both `Complex` and `Polar` are both wrapped versions of `(Double, Double)`, the two types are wholly incompatible in Q#, minimizing the risk of accidentally calling a complex math function with polar coordinates and vice versa.
In this way, user-defined types can play a similar role to `struct` types in C and other such languages.

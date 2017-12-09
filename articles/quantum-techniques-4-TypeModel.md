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
uid: microsoft.quantum.techniques.type-model
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

An array value can be written in Q# source code by using square brackets around the elements of an array, as in `[PauliI; PauliX; PauliY; PauliZ]`.
The types of each element must match exactly, as there are no "base" types in Q#.
<!-- TODO: is Length actually a function? Check on this. -->

> [!WARNING]
> The elements of an array cannot typically be changed after the array has been created.
> In order to change the elements of an array, it must be bound to a [mutable variable](#mutability).

Alternatively, an array can be created from its size using the `new` keyword:

```qsharp
let zeros = new Int[13];
// new also allows for creating empty arrays:
let emptyRegister = new Qubit[0];
```

This is typically more useful for mutable arrays, as we [discussed above](#mutability), since the individual elements of an array created using the `new` keyword are not often useful in and of themselves.

In either case, once an array has been constructed, the built-in `Length` function can be used to obtain the number of elements as an `Int`.
Arrays can be subscripting using square brackets, with subscripts either having type `Int` or type `Range`, to obtain either single elements or new arrays containing a subset of the elements of an array.
The subscripts of arrays are zero-based:

```qsharp
let arr = [10; 11; 36; 49];
let ten = arr[0]; // 10
let odds = arr[1..2..4]; // [11; 49]
```

## Operation and Function Types ##

As noted above, operations and functions are values in and of themselves in Q#.
The types of these values are constructed from the types of the input and output tuples that each operation and function takes and returns.
To see this in practice, let's consider the `ApplyTwice` example from above:

```qsharp
operation ApplyTwice(op : ((Qubit) => ()), target : Qubit) : () {
    ...
```

Here, we see that the operation declaration specifies that `op` has type `((Qubit) => ())`, which means that the type of `op` is an operation type, and has as its valid values operations which accept an input of `(Qubit)` and produce an output of `()`.
We can indicate functions in the same way by using `->` instead of `=>`.
The types before and after each arrow can be whatever type we wish, including other operation or function types.
For instance, we can pass the function `SquareOperation` defined above to any input expecting type ` ((Qubit) => ())) ->  ((Qubit) => ())`.
Informally, we can read that type as "a classical function which takes operations on a single qubit and returns operations on a single qubit."

In order to use the `Controlled` and `Adjoint` variants of an operation type, we need to indicate that the values of that type support the variants we wish to call.
This is done by adding constraints to the operation type, as in `(Qubit => () : Adjoint)`, which indicates an adjointable operation acting on one qubit to produce an empty tuple as its output.

## User-Defined Types ##

The final way to construct new types in Q# is with *user-defined types* (UDTs).
For any tuple type `T`, we can declare a new user-defined type that is a subtype of `T` with the `newtype` statement.
In the @"microsoft.quantum.canon" namespace, for instance, complex numbers are defined as a user-defined type:

```qsharp
newtype Complex = (Double, Double);
```

This statement creates a new type which is effectively a label for a particular tuple type.
Values of the new type are created by using the name of the type as a function:

```
let realUnit = Complex(1.0, 0.0);
let imaginaryUnit = Complex(0.0, 1.0);
```

As with ordinary tuple types, the constituting elements of a user-defined type can be accessed using deconstruction.
This lets us write out accessor functions into the structure of a user-defined type, for instance:

```qsharp
function Re(z : Complex) : Double {
    let (re, im) = z;
    return re;
}

function Im(z : Complex) : Double {
    let (re, im) = z;
    return im;
}
```

In addition to providing short aliases for potentially complicated tuple types, one significant advantage of using UDTs is that they can document the intent of a particular value.
Returning to the example of `Complex`, one could have also defined 2D polar coordinates as a user-defined type:

```qsharp
newtype Polar = (Double, Double);
```

Even though both `Complex` and `Polar` both derive from `(Double, Double)`, the two types are wholly incompatable in Q#, minimizing the risk of accidently calling a complex math function with polar coordinates and vice versa.
In this way, user-defined types can play a similar role to `struct` types in C and other such languages.

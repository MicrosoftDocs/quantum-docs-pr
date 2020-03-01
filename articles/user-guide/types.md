---
title: Types in Q# | Microsoft Docs 
description: Learn about the different types used in the Q# programming language, including built-in types, user-defined types, as well as arrays and tuples of types.
author: Gillenhaal Beck
ms.author: a-gibec@microsoft.com
ms.date: 02/28/2020
ms.topic: article
uid: microsoft.quantum.guide.types
---

# Types in Q#

This section lays out the Q# type model and describes the syntax for specifying types.
Details on working with expressions of each type are described in the following section, ["Expressions: working with types"](xref:microsoft.quantum.guide.expressions).

We note that Q# is a *strongly-typed* language, such that careful use of these types can help the compiler to provide strong guarantees about Q# programs at compile time.
In order to provide the strongest guarantees possible, conversions between types in Q# must be explicit using calls to functions which express that conversion. 
A variety of such functions are provided as a part of the <xref:microsoft.quantum.convert> namespace.
Upcasts to compatible types on the other hand happen implicitly. 

Q# provides both primitive types, which can be used directly, and a variety of ways to produce new types from other types. 
These include arrays and tuples, as well as the ability to define new types yourself.
We describe each in the rest of this section.

## Primitive Types

The Q# language provides several *primitive types*, from which other types
can be constructed. Alongside "standard" types commonly found in programming languages, Q# also provides several primitive types specifically for use with quantum computing.  

### Standard Types

| Type | what it represents | examples | remarks |
| --- | ------------ | ------- | ----------- |
| `Int` | 64-bit signed integer | `2`, `107`, `-5` |  |
| `BigInt` | signed integer of arbitrary size | `2L`, `107L`, `-5L` | based on the .NET <xref:System.Numerics.BigInteger> type |
| `Double` | double-precision floating-point number | `0.0`, `-1.3`, `4e-7`|  |
| `Bool` | Boolean value | either `true` or `false` |  |
| `Range` | sequence of integers, denoted by `start..step..stop` (denoting `step` is optional) | `1..4` represents the sequence $\{1, 2, 3, 4\}$, `1..2..7` represents  $\{1, 3, 5, 7\}$ | `start .. stop` corresponds to `start..1..stop` |
| `String` | sequence of Unicode characters that
  is opaque to the user once created | `"Example of a string"` | used to report messages to a classical host in the case of an error or diagnostic event |
| `Unit` | allows only one value: `()` | `()` | used to indicate that Q# function or operation returns no information |

### Quantum-specific

- The `Qubit` type represents a quantum bit or qubit.
   `Qubit`s are opaque to the user; the only operation possible with them,
   other than passing them to another operation, is to test for identity
   (equality).
   Ultimately, actions on `Qubit`s are implemented by calling intrinsic instructions on a quantum processor (or a simulation thereof).
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

The constants `true`, `false`, `PauliI`, `PauliX`,
`PauliY`, `PauliZ`, `One`, and `Zero` are all reserved symbols in Q#.

## Array Types

Given any valid Q# type `'T`, there is a type that represents an array of values of type `'T`.
This array type is represented as `'T[]`; for example, `Result[]` or `Int[][]`.
Here, the first denotes an array of `Result` values, whereas the second corresponds to an array of `Int[]` arrays.

Note that the latter represents a (potentially jagged) array of arrays, and *not* a rectangular two-dimensional array.
Q# does not provide support for rectangular multi-dimensional arrays.

An array value can be written in Q# source code by using square brackets around the elements of an array, as in `[PauliI, PauliX, PauliY, PauliZ]`.
The type of an array literal is determined by the common base type of all items in the array. 

Alternatively, an array can be created from its size using the `new` keyword:

```qsharp
let zeros = new Int[13];
// new also allows for creating empty arrays:
let emptyRegister = new Qubit[0];
```

In either case, once an array has been constructed, the core function [`Length`](xref:microsoft.quantum.core.length) can be used to obtain the number of elements as an `Int`.
Arrays can be subscripted using square brackets, with subscripts either having type `Int` or type `Range`, to obtain either single elements or new arrays containing a subset of the elements of an array.
The subscripts of arrays are zero-based:

```qsharp
let arr = [10, 11, 36, 49];
let ten = arr[0]; // 10
let odds = arr[1..2..4]; // [11, 49]
```

> [!WARNING]
> The elements of an array cannot be changed after the array has been created.
> Update-and-reassign statements and/or copy-and-update expressions can be used to construct a modified array.
> Details on manipulating arrays can be found in the `******` section.

## Tuple Types

Given zero or more different types `T0`, `T1`, ..., `Tn`, we can denote a new  *tuple type* as `(T0, T1, ..., Tn)`.
The types used to construct a new tuple type can themselves be tuples, as in `(Int, (Qubit, Qubit))`.
Such nesting is always finite, however, as tuple types cannot under any circumstances contain themselves.

Values of the new tuple type are tuples formed by sequences of values from each type in the tuple.
For instance, `(3, false)` is a tuple whose type is the tuple type `(Int, Bool)`.
It is possible to create arrays of tuples, tuples of arrays, tuples of sub-tuples, etc.

As of Q# 0.3, `Unit` is the name of the *type*
of the empty tuple; `()` is used for the empty tuple *value*.

Tuple instances are immutable.
Q# does not provide a mechanism to change the contents of a tuple once created.

Tuples are a powerful concept used throughout Q# to collect values together into a single value, making it easier to pass them around.
In particular, using tuple notation, we can express that every operation and callable takes exactly one input and returns exactly one output.

### Singleton Tuple Equivalence

It is possible to create a singleton (single-element) tuple, `('T1)`, such as `(5)` or `([1,2,3])`.
However, Q# treats a singleton tuple as completely equivalent to a value of the enclosed type.
That is, there is no difference between `5` and `(5)`, or between `5` and `(((5)))`, or between `(5, (6))` and `(5, 6)`.

This equivalence applies for all purposes, including assignment and expressions.
It is just as valid to write `(5)+3` as to write `5+3`, and both expressions will evaluate to `8`.
In particular, this means that an operation or function whose input tuple or output tuple type has one field can be thought of as taking a single argument or returning a single value.

We refer to this property as _singleton tuple equivalence_.


## User-Defined Types

A Q# file may define a new named type containing a single value of any legal type.
For any tuple type `T`, we can declare a new user-defined type that is a subtype of `T` with the `newtype` statement.
In the @"microsoft.quantum.math" namespace, for instance, complex numbers are defined as a user-defined type:

```qsharp
newtype Complex = (Double, Double);
```

This statement creates a new type with two *anonymous* items of type `Double`.

### Naming items in type definitions

Aside from anonymous items, user-defined types also support *named* items as of Q# version 0.7 or higher. 
For example, we could have named the two `Double` items in the definition above: 

```qsharp
newtype Complex = (Re : Double, Im : Double);
```

Here, the name `Re` is assigned to the double representing the real part of a complex number, and `Im` to the imaginary part.

Naming one item in a user-defined type does not imply that all items need to be named - any combination of named and unnamed items is supported. 
Furthermore, inner items may also be named.
The type `Nested` defined below, for example, has an underlying type `(Double, (Int, String))`, of which only the item of type `Int` is named and all other items are anonymous. 

```qsharp
newtype Nested = (Double, (ItemName : Int, String)); 
```

### Named vs. anonymous items

Named items have the advantage that they can be accessed directly via the *access operator* `::`. 

```qsharp
function ComplexAddition(c1 : Complex, c2 : Complex) : Complex {
    return Complex(c1::Re + c2::Re, c1::Im + c2::Im);
}
```

`******` Make this following example more illustrative of the named/anonymous comparison (also it's using not-yet-described syntax with the `_`, might very well be unclear or a frustration to some.)

In order to access anonymous items on the other hand, the wrapped value first needs to be extracted using the postfix operator `!`.
The "unwrap" operator, `!`, allows to extract the value contained in a user defined type.
The type of such an "unwrap" expression is the underlying type of the user defined type. 

```qsharp
function PrintedMessage(value : Nested) : Unit {
    let (d, (_, str)) = value!;
    Message ($"{str}, value: {d}");
}
```
`******` Simply say that more details on wrap/unwrap can be found on the expressions/working with data pages


### Creating values of user-defined types

Values of a user defined type can be created by calling the corresponding type constructor:

```
let realUnit = Complex(1.0, 0.0);
let imaginaryUnit = Complex(0.0, 1.0);
```

`******` Update/succinct-ify following description, as it's bordering on tangential (move example to expressions page, simply direct there?)

Alternatively, new values can be created from existing ones using [copy-and-update expressions](xref:microsoft.quantum.language.expressions#copy-and-update-expressions). 
Like for arrays, such expressions copy all item values of the original expression, with the exception of the specified named items. For these the values are set to the ones defined on the right hand side of the expression. 
Any other language constructs, like for example [update-and-reassign statements](xref:microsoft.quantum.language.statements#update-and-reassign-statement), that are available for array items exist for *named* items in user defined types as well.

```qsharp
newtype ComplexArray = (Count : Int, Data : Complex[]);

function AsComplexArray (data : Double[]) : ComplexArray {

    mutable res = ComplexArray(0, new Complex[0]);
    for (item in data) {
        set res w/= Data <- res::Data + [Complex(item, 0.)]; // update-and-reassign statement
    }
    return res w/ Count <- Length(res::Data); // returning a copy-and-update expression
}
```

User-defined types may be used anywhere any other type may be used.
In particular, it is possible to define an array of a user-defined type and to include a user-defined type as an element of a tuple type.

It is not possible to create recursive type structures.
That is, the type that defines a user-defined type may not be a tuple type that includes an element of the user-defined type.
More generally, user-defined types may not have cyclic dependencies on each other, so the following set of type definitions would be illegal:

```qsharp
newtype TypeA = (Int, TypeB);
newtype TypeB = (Double, TypeC);
newtype TypeC = (TypeA, Range);
```

In addition to providing short aliases for potentially complicated tuple types, one significant advantage of defining such types is that they can document the intent of a particular value.
Returning to the example of `Complex`, one could have also defined 2D polar coordinates as a user-defined type:

```qsharp
newtype Polar = (Radius : Double, Phase : Double);
```

Even though both `Complex` and `Polar` are both have an underlying type `(Double, Double)`, the two types are wholly incompatible in Q#, minimizing the risk of accidentally calling a complex math function with polar coordinates and vice versa.
In this way, user-defined types have a similar role as Records in F# for example. 

## What's next?

On the [next page](xref:microsoft.quantum.guide.expressions) we detail how expressions are constructed from all of these types, as well as how to deal with them.


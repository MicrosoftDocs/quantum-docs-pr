---
title: Types in Q#
description: Learn about the different types used in the Q# programming language.
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.date: 03/05/2020
ms.topic: article
uid: microsoft.quantum.guide.types
---

# Types in Q#

This page lays out the Q# type model and describes the syntax for specifying and working with types.
The next page, [Type Expressions](xref:microsoft.quantum.guide.expressions), details how to create and operate on expressions of these types.

We note that Q# is a *strongly-typed* language, such that careful use of these types can help the compiler to provide strong guarantees about Q# programs at compile time.
In order to provide the strongest guarantees possible, conversions between types in Q# must be explicit using calls to functions which express that conversion. 
A variety of such functions are provided as a part of the <xref:microsoft.quantum.convert> namespace.
Upcasts to compatible types on the other hand happen implicitly. 

Q# provides both primitive types, which can be used directly, and a variety of ways to produce new types from other types.
We describe each in the rest of this section.

## Primitive Types

The Q# language provides several *primitive types*, from which other types can be constructed:

- The `Int` type represents a 64-bit signed integer, e.g.: `2`, `107`, `-5`.
- The `BigInt` type represents a signed integer of arbitrary size, e.g. `2L`, `107L`, `-5L`.
   This type is based on the .NET
   <xref:System.Numerics.BigInteger>
   type.
- The `Double` type represents a double-precision floating-point number, e.g.: `0.0`, `-1.3`, `4e-7`.
- The `Bool` type represents a Boolean value which can either be `true` or `false`.
- The `Range` type represents a sequence of integers, denoted by `start..step..stop`, where denoting the step is optional. 
   That is `start .. stop` corresponds to `start..1..stop`, and e.g. `1..2..7` represents the sequence $\{1, 3, 5, 7\}$.
- The `String` type is a sequence of Unicode characters that is opaque to the user once created.
  This type is used to report messages to a classical host in the case of an error or diagnostic event.
- The `Unit` type is the type that allows only one value `()`. 
  This type is used to indicate that Q# function or operation returns no information. 
- The `Qubit` type represents a quantum bit or qubit.
   `Qubit`s are opaque to the user; the only operation possible with them, other than passing them to another operation, is to test for identity (equality).
   Ultimately, actions on `Qubit`s are implemented by calling intrinsic instructions on a quantum processor (or a simulation thereof).
- The `Pauli` type represents one of the four single-qubit Pauli operators.
   This type is used to denote the base operation for rotations and to specify the observable being measured.
   This is an enumerated type that has four possible values: `PauliI`, `PauliX`, `PauliY`, and `PauliZ`, which are constants of type `Pauli`.
- The `Result` type represents the result of a measurement.
   This is an enumerated type with two possible values: `One` and `Zero`, which are constants of type `Result`.
   `Zero` indicates that the +1 eigenvalue was measured; `One` indicates the -1 eigenvalue.

The constants `true`, `false`, `PauliI`, `PauliX`, `PauliY`, `PauliZ`, `One`, and `Zero` are all reserved symbols in Q#.

## Array Types

Given any valid Q# type `'T`, there is a type that represents an array of values of type `'T`.
This array type is represented as `'T[]`; for example, `Qubit[]` or `Int[][]`.
For instance, a collection of integers is denoted `Int[]`, while an array of arrays of `(Bool, Pauli)` values is denoted `(Bool, Pauli)[][]`.

In the second example, note that this represents a potentially jagged array of arrays, and not a rectangular two-dimensional array.
Q# does not provide support for rectangular multi-dimensional arrays.

An array value can be written in Q# source code by using square brackets around the elements of an array, as in `[PauliI, PauliX, PauliY, PauliZ]`.
The type of an array literal is determined by the common base type of all items in the array. 
Hence trying to construct an array with elements that have no common base type will raise an error.  
See [arrays of callables](xref:microsoft.quantum.guide.expressions#arrays-of-callables) for an example of this.

> [!WARNING]
> The elements of an array cannot be changed after the array has been created.
> [Update-and-reassign statements](xref:microsoft.quantum.guide.variables#update-and-reassign-statements) and/or [copy-and-update expressions](xref:microsoft.quantum.guide.expressions#copy-and-update-expressions) can be used to construct a modified array.

Alternatively, an array can be created from its size using the `new` keyword:

```qsharp
let zeros = new Int[13];
// new also allows for creating empty arrays:
let emptyRegister = new Qubit[0];
```

In either case, once an array has been constructed, the core function `Length` can be used to obtain the number of elements as an `Int`.
Arrays can be subscripted using square brackets, with subscripts either having type `Int` or type `Range`, to obtain either single elements or new arrays containing a subset of the elements of an array.
The subscripts of arrays are zero-based:

```qsharp
let arr = [10, 11, 36, 49];
let ten = arr[0]; // 10
let odds = arr[1..2..4]; // [11, 49]
```

## Tuple Types

Given zero or more different types `T0`, `T1`, ..., `Tn`, we can denote a new  *tuple type* as `(T0, T1, ..., Tn)`.
The types used to construct a new tuple type can themselves be tuples, as in `(Int, (Qubit, Qubit))`.
Such nesting is always finite, however, as tuple types cannot under any circumstances contain themselves.

Values of the new tuple type are tuples formed by sequences of values from each type in the tuple.
For instance, `(3, false)` is a tuple whose type is the tuple type `(Int, Bool)`.
It is possible to create arrays of tuples, tuples of arrays, tuples of sub-tuples, etc.

As of Q# 0.3, `Unit` is the name of the *type* of the empty tuple; `()` is used for the empty tuple *value*.

Tuple instances are immutable.
Q# does not provide a mechanism to change the contents of a tuple once created.

Tuples are a powerful concept used throughout Q# to collect values together into a single value, making it easier to pass them around.
In particular, using tuple notation, we can express that every operation and callable takes exactly one input and returns exactly one output.

### Singleton Tuple Equivalence

It is possible to create a singleton (single-element) tuple, `('T1)`, such as `(5)` or `([1,2,3])`.
However, Q# treats a singleton tuple as completely equivalent to a value of the enclosed type.
That is, there is no difference between `5` and `(5)`, or between `5` and `(((5)))`, or between `(5, (6))` and `(5, 6)`.
It is just as valid to write `(5)+3` as to write `5+3`, and both expressions will evaluate to `8`.

This equivalence applies for all purposes, including assignment and expressions.
Given any expression, that same expression enclosed in parentheses is an expression of the same type.
For instance, `(7)` is an `Int` expression, `([1,2,3])` is an expression of type array of `Int`s, and `((1,2))` is an expression with type `(Int, Int)`.

In particular, this means that an operation or function whose input tuple or output tuple type has one field can be thought of as taking a single argument or returning a single value.

We refer to this property as _singleton tuple equivalence_.


## User-Defined Types

A user-defined type declaration consists of the keyword `newtype`, followed by the name of the user-defined type, an `=`, a valid type specification, and a terminating semicolon.

For example:

```qsharp
newtype PairOfInts = (Int, Int);
```

Each Q# source file may declare any number of user-defined types.
Type names must be unique within a namespace and may not conflict with operation and function names.

User-defined types are distinct even if the base types are identical.
In particular, there is no automatic conversion between values of two user-defined types even if the underlying types are identical.

### Named vs. anonymous items

A Q# file may define a new named type containing a single value of any legal type.
For any tuple type `T`, we can declare a new user-defined type that is a subtype of `T` with the `newtype` statement.
In the @"microsoft.quantum.math" namespace, for instance, complex numbers are defined as a user-defined type:

```qsharp
newtype Complex = (Double, Double);
```
This statement creates a new type with two anonymous items of type `Double`.   

Aside from anonymous items, user-defined types also support *named items* as of Q# version 0.7 or higher. 
For example, we could have named the to items `Re` for the double representing the real part of a complex number and `Im` for the imaginary part: 

```qsharp
newtype Complex = (Re : Double, Im : Double);
```
Naming one item in a user-defined type does not imply that all items need to be named - any combination of named and unnamed items is supported. 
Furthermore, inner items may also be named.
The type `Nested` as defined below for example has an underlying type `(Double, (Int, String))`, of which only the item of type `Int` is named and all other items are anonymous. 

```qsharp
newtype Nested = (Double, (ItemName : Int, String)); 
```

Named items have the advantage that they can be accessed directly via the *access operator* `::`. 

```qsharp
function ComplexAddition(c1 : Complex, c2 : Complex) : Complex {
    return Complex(c1::Re + c2::Re, c1::Im + c2::Im);
}
```

In addition to providing short aliases for potentially complicated tuple types, one significant advantage of defining such types is that they can document the intent of a particular value.
Returning to the example of `Complex`, one could have also defined 2D polar coordinates as a user-defined type:

```qsharp
newtype Polar = (Radius : Double, Phase : Double);
```

Even though both `Complex` and `Polar` are both have an underlying type `(Double, Double)`, the two types are wholly incompatible in Q#, minimizing the risk of accidentally calling a complex math function with polar coordinates and vice versa.
In this way, user-defined types have a similar role as Records in F# for example. 


#### Access anonymous items with the unwrap operator

In order to access anonymous items on the other hand, the wrapped value first needs to be extracted using the postfix operator `!`.
The "unwrap" operator, `!`, allows to extract the value contained in a user-defined type.
The type of such an "unwrap" expression is the underlying type of the user-defined type. 

```qsharp
function PrintedMessage(value : Nested) : Unit {
    let (d, (_, str)) = value!;
    Message ($"{str}, value: {d}");
}
```

The unwrap operator unwraps exactly one layer of wrapping.
Multiple unwrap operators may be used to access a multiply-wrapped value.

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

More details on the unwrap operator can be found at [Type Expressions in Q#](xref:microsoft.quantum.guide.expressions).

### Creating values of user-defined types

Values of a user-defined type can be created by calling the corresponding type constructor:

```
let realUnit = Complex(1.0, 0.0);
let imaginaryUnit = Complex(0.0, 1.0);
```

Alternatively, new values can be created from existing ones using [copy-and-update expressions](xref:microsoft.quantum.guide.expressions#copy-and-update-expressions). 
Like for arrays, such expressions copy all item values of the original expression, with the exception of the specified named items. For these the values are set to the ones defined on the right hand side of the expression. 
Any other language constructs, like for example [update-and-reassign statements](xref:microsoft.quantum.guide.variables#update-and-reassign-statements), that are available for array items exist for named-items in user-defined types as well.

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

Note is not possible to create recursive type structures.
That is, the type that defines a user-defined type may not be a tuple type that includes an element of the user-defined type.
More generally, user-defined types may not have cyclic dependencies on each other, so the following set of type definitions would be illegal:

```qsharp
newtype TypeA = (Int, TypeB);
newtype TypeB = (Double, TypeC);
newtype TypeC = (TypeA, Range);
```


## Operation and Function Types

The basic type for any callable is written as `('Tinput => 'Tresult)` or `('Tinput -> 'Tresult)`, where both `'Tinput` and `'Tresult` are types.
These are called the *signature* of the callable.

All Q# callables are considered to take a single value as input and return a single value as output.
Both the input and output values may be tuples.
Callables that have no result return `Unit`.
Callables that have no input take the empty tuple as input.

> [!NOTE]
> The first form, with `=>`, is used for operations; the second form, with `->`, for functions.
> For example, `((Qubit, Pauli) => Result)` represents the signature for a possible single-qubit measurement operation.
*Function* types are completely specified by their signature.
For example, a function that computes the sine of an angle would have type `(Double -> Double)`.

*Operations*---but not functions---have certain additional characteristics that are expressed as part of the operation type. 
Such characteristics include information about what *functors* the operation supports.
For example, if execution of the operation can be conditioned on the state of other qubits, it should support the `Controlled` functor; if the operation has an inverse, it should support the `Adjoint` functor. 
Functors and operations are discussed in detail at [Operations and Functions in Q#](xref:microsoft.quantum.guide.operationsfunctions), but here we simply discuss how this alters the operation signature.

In order to require support for the `Controlled` and/or `Adjoint` functor in an operation type, we need to add an annotation indicating the corresponding characteristics.
An annotation `is Ctl` (e.g. `(Qubit => Unit is Ctl)`) indicates that the operation is controllable---that is, it's execution conditioned on the state of another qubit or qubits. 
Similarly, `is Adj` indicates that the operation has an adjoint; or simply, it can be "inverted" such that successively applying an operation and then its adjoint to a state leaves the state unchanged. 

If we want to require that an operation of that type supports both the `Adjoint` and `Controlled` functor we can express this as `(Qubit => Unit is Adj + Ctl)`. 
For example, the built-in Pauli <xref:microsoft.quantum.intrinsic.x> operation has type `(Qubit => Unit is Adj + Ctl)`. 

An operation type that does not support any functors is specified by its input and output type alone, with no additional annotation.

### Type-Parameterized Functions and Operations

Callable types may contain type parameters.
Type parameters are indicated by a symbol prefixed by a single quote; for example, `'A` is a legal type parameter.
Details on defining type-parameterized callables are provided on the [Operations and Functions in Q#](xref:microsoft.quantum.guide.operationsfunctions#generic-type-parameterized-callables) page.

A type parameter may appear more than once in a single signature.
For example, a function that applies another function to each element of an array and returns the collected results would have signature `(('A[], 'A->'A) -> 'A[])`.
Similarly, a function that returns the composition of two operations might have signature `((('A=>'B), ('B=>'C)) -> ('A=>'C))`.

When invoking a type-parameterized callable, all arguments that have the same type parameter must be of the same type.

Q# does not provide a mechanism for constraining the possible types that might be substituted for a type parameter.

## Next steps

Now that you've seen all the types which comprise the Q# language, you can head to [Type Expressions in Q#](xref:microsoft.quantum.guide.expressions) to see how to create and manipulate expressions of these various types.



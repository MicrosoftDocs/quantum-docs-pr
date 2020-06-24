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

This article describes the Q# type model and the syntax for specifying and working with types. For details on how to create and operate on expressions of these types, see [Type Expressions](xref:microsoft.quantum.guide.expressions).

We note that Q# is a *strongly-typed* language, such that careful use of these types can help the compiler to provide strong guarantees about Q# programs at compile time.
To provide the strongest guarantees possible, conversions between types in Q# must be explicit using calls to functions which express that conversion. 
Q# provides a variety of such functions as a part of the <xref:microsoft.quantum.convert> namespace.
Upcasts to compatible types, on the other hand, happen implicitly. 

Q# provides both primitive types, which are used directly, and a variety of ways to produce new types from other types.
We describe each in the rest of this article.

## Primitive Types

The Q# language provides the following *primitive types*, all of which you can use directly in Q# programs. You can also use these primitive types to construct new types.

- The `Int` type represents a 64-bit signed integer, for example, `2`, `107`, `-5`.
- The `BigInt` type represents a signed integer of arbitrary size, for example, `2L`, `107L`, `-5L`.
   This type is based on the .NET
   <xref:System.Numerics.BigInteger>
   type.

- The `Double` type represents a double-precision floating-point number, for example, `0.0`, `-1.3`, `4e-7`.
- The `Bool` type represents a Boolean value of either `true` or `false`.
- The `Range` type represents a sequence of integers, denoted by `start..step..stop`, where denoting the step is optional. 
   For example, `start .. stop` corresponds to `start..1..stop`, and `1..2..7` represents the sequence $\{1, 3, 5, 7\}$.
- The `String` type is a sequence of Unicode characters that is opaque to the user once created.
  Use the `string` type to report messages to a classical host in the case of an error or diagnostic event.
- The `Unit` type can have only one value, `()`. 
  Use this type to indicate that a Q# function or operation returns no information. 
- The `Qubit` type represents a quantum bit or qubit.
   `Qubit`s are opaque to the user. The only operation possible with them, other than passing them to another operation, is to test for identity (equality).
   Ultimately, you implement actions on `Qubit`s by calling intrinsic instructions on a quantum processor (or a quantum simulator).
- The `Pauli` type represents one of the four single-qubit Pauli operators.
   Use this type to denote the base operation for rotations and to specify the observable being measured.
   It is an enumerated type that has four possible values: `PauliI`, `PauliX`, `PauliY`, and `PauliZ`, which are constants of type `Pauli`.
- The `Result` type represents the result of a measurement.
   It is an enumerated type with two possible values: `One` and `Zero`, which are constants of type `Result`.
   `Zero` indicates that the +1 eigenvalue was measured; `One` indicates the -1 eigenvalue was measured.

The constants `true`, `false`, `PauliI`, `PauliX`, `PauliY`, `PauliZ`, `One`, and `Zero` are all reserved symbols in Q#.

## Array Types

* For any valid Q# type, there is a type that represents an array of values of that type.
    For example, `Qubit[]` and `(Bool, Pauli)[]` represent arrays of `Qubit` values and `(Bool, Pauli)` tuple values.

* An array of arrays is also valid. Expanding on the previous example, an array of `(Bool, Pauli)` arrays is denoted `(Bool, Pauli)[][]`.

> [!NOTE] 
> This example, `(Bool, Pauli)[][]`, represents a potentially jagged array of arrays and not a rectangular two-dimensional array. Q# does not support rectangular multi-dimensional arrays.

* An array value can be written in Q# source code by using square brackets around the elements of an array, as in `[PauliI, PauliX, PauliY, PauliZ]`.
The common base type of all items in the array determines the type of an array literal. 
Hence, constructing an array with elements that have no common base type raises an error.  
For an example, see [arrays of callables](xref:microsoft.quantum.guide.expressions#arrays-of-callables).

    > [!WARNING]
    > Once created, the elements of an array cannot be changed.
    > To construct a modified array, use [update-and-reassign statements](xref:microsoft.quantum.guide.variables#update-and-reassign-statements) or [copy-and-update expressions](xref:microsoft.quantum.guide.expressions#copy-and-update-expressions).

* Alternatively, an array can be created from its size using the `new` keyword:

    ```qsharp
    let zeros = new Int[13];
    // you can also use new for creating empty arrays:
    let emptyRegister = new Qubit[0];
    ```

* Use the core function `Length` to obtain the number of elements from an array as an `Int`.
* Arrays can be subscripted to obtain either single elements or new arrays containing a subset of the elements of an array.
The subscripts of arrays are zero-based and must be type `Int` or type `Range`:

    ```qsharp
    let arr = [10, 11, 36, 49];
    let ten = arr[0]; // 10
    let odds = arr[1..2..4]; // [11, 49]
    ```

## Tuple Types

Tuples are a powerful concept used throughout Q# to collect values together into a single value, making it easier to pass them around.
In particular, using tuple notation, you can express that every operation and callable takes exactly one input and returns exactly one output.

* Given zero or more different types `T0`, `T1`, ..., `Tn`, you can denote a new  *tuple type* as `(T0, T1, ..., Tn)`.
The types used to construct a new tuple type can themselves be tuples, as in `(Int, (Qubit, Qubit))`.
Such nesting is always finite, however, as tuple types cannot under any circumstances contain themselves.

* The values of the new tuple type are tuples formed by sequences of values from each type in the tuple.
For example, `(3, false)` is a tuple whose type is the tuple type `(Int, Bool)`.
It is possible to create arrays of tuples, tuples of arrays, tuples of sub-tuples, and so on.

* As of Q# 0.3, `Unit` is the name of the *type* of the empty tuple; `()` is used for the *value* of the empty tuple.

* Tuple instances are immutable.
Q# does not provide a mechanism to change the contents of a tuple once created.



### Singleton Tuple Equivalence

It is possible to create a singleton (single-element) tuple `('T1)`, such as `(5)` or `([1,2,3])`.
However, Q# treats a singleton tuple as equivalent to a value of the enclosed type.
That is, there is no difference between `5` and `(5)`, or between `5` and `(((5)))`, or between `(5, (6))` and `(5, 6)`.
It is just as valid to write `(5)+3` as it is to write `5+3`; both expressions evaluate to `8`.

This equivalence applies for all purposes, including assignment and expressions.
Given any expression, that same expression enclosed in parentheses is an expression of the same type.
For example, `(7)` is an expression of type `Int`, `([1,2,3])` is an expression of type `Int[]`, and `((1,2))` is an expression of type `(Int, Int)`.

In particular, this means that you can view an operation or function whose input tuple or output tuple type has one field as taking a single argument or returning a single value.

We refer to this property as _singleton tuple equivalence_.


## User-Defined Types

A user-defined type declaration consists of the keyword `newtype`, followed by the name of the user-defined type, an `=`, a valid type specification, and a terminating semicolon.

For example:

```qsharp
newtype PairOfInts = (Int, Int);
```
    
* Each Q# source file may declare any number of user-defined types.
* Type names must be unique within a namespace and may not conflict with operation and function names.
* User-defined types are distinct, even if the base types are identical.
In particular, there is no automatic conversion between the values of two user-defined types, even if the underlying types are identical.

### Named vs. anonymous items

A Q# file may define a new named type containing a single value of any legal type.
For any tuple type `T`, you can declare a new user-defined type that is a subtype of `T` with the `newtype` statement.
In the @"microsoft.quantum.math" namespace, for example, complex numbers are defined as a user-defined type:

```qsharp
newtype Complex = (Double, Double);
```
This statement creates a new type with two anonymous items of type `Double`.   

Aside from anonymous items, user-defined types also support *named items* as of Q# version 0.7 or higher. 
For example, you could name the items to `Re` for the double representing the real part of a complex number and `Im` for the imaginary part: 

```qsharp
newtype Complex = (Re : Double, Im : Double);
```
Naming one item in a user-defined type does not imply that all items need to be named - any combination of named and unnamed items is supported. 
Furthermore, inner items may also be named.
The type `Nested`, as defined below for example, has an underlying type `(Double, (Int, String))`, of which only the item of type `Int` is named, and all other items are anonymous. 

```qsharp
newtype Nested = (Double, (ItemName : Int, String)); 
```

Named items have the advantage that they can be accessed directly via the *access operator* `::`. 

```qsharp
function ComplexAddition(c1 : Complex, c2 : Complex) : Complex {
    return Complex(c1::Re + c2::Re, c1::Im + c2::Im);
}
```

In addition to providing short aliases for potentially complicated tuple types, a significant advantage of defining such types is that they can document the intent of a particular value.
Returning to the example of `Complex`, one could have also defined 2D polar coordinates as a user-defined type:

```qsharp
newtype Polar = (Radius : Double, Phase : Double);
```

Even though both `Complex` and `Polar` both have an underlying type `(Double, Double)`, the two types are wholly incompatible in Q#, minimizing the risk of accidentally calling a complex math function with polar coordinates and vice versa.

#### Access anonymous items with the unwrap operator

To access anonymous items, first extract the wrapped value using the postfix operator `!`.
With the "unwrap" operator, `!`, you can extract the value contained in a user-defined type.
The type of such an "unwrap" expression is the underlying type of the user-defined type. 

```qsharp
function PrintedMessage(value : Nested) : Unit {
    let (d, (_, str)) = value!;
    Message ($"{str}, value: {d}");
}
```

A single unwrap operator unwraps one layer of wrapping. Use multiple unwrap operators to access a multiply-wrapped value.

For example:

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

For more details on the unwrap operator, see [Type Expressions in Q#](xref:microsoft.quantum.guide.expressions).

### Creating values of user-defined types

Create values of a user-defined type by calling the corresponding type constructor:

```qsharp
let realUnit = Complex(1.0, 0.0);
let imaginaryUnit = Complex(0.0, 1.0);
```

Alternatively, you can create new values from existing ones using [copy-and-update expressions](xref:microsoft.quantum.guide.expressions#copy-and-update-expressions). 
Just as they do with arrays, copy-and-update expressions copy all item values of the original expression, except for the specified named items. For these exceptions, the values of these items are the values defined on the right-hand side of the expression. 
Any other language constructs that are available for array items, for example [update-and-reassign statements](xref:microsoft.quantum.guide.variables#update-and-reassign-statements), exist for named-items in user-defined types as well.

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

* You can use user-defined types anywhere you use any other types.
In particular, it is possible to define an array of a user-defined type and to include a user-defined type as an element of a tuple type.

* It is not possible to create recursive type structures.
That is, the type that defines a user-defined type cannot be a tuple type that includes an element of the user-defined type.
More generally, user-defined types may not have cyclic dependencies on each other, so the following set of type definitions are invalid:

    ```qsharp
    newtype TypeA = (Int, TypeB);
    newtype TypeB = (Double, TypeC);
    newtype TypeC = (TypeA, Range);
    ```


## Operation and Function Types

Given the types `'Tinput` and `'Tresult`:

* `('Tinput => 'Tresult)` is the basic type for any *operation*, for example `((Qubit, Pauli) => Result)`.
* `('Tinput -> 'Tresult)` is the basic type for any *function*, for example `(Int -> Int)`. 

These are called the *signature* of the callable.

* All Q# callables take a single value as input and return a single value as output.
* You can use tuples for both the input and output values.
* Callables that have no result, return `Unit`.
* Callables that have no input take the empty tuple as input.

### Functors

*Function* types are completely specified by their signature. For example, a function that computes the sine of an angle would have type `(Double -> Double)`. 

*Operations* have certain additional characteristics that are expressed as part of the operation type. 
Such characteristics include information about which *functors* the operation supports.
For example, if the execution of the operation relies on the state of other qubits, then it should support the `Controlled` functor; if the operation has an inverse, then it should support the `Adjoint` functor.

> [!NOTE]
> This article only discuss how functors alter the operation signature. For more details about functors and operations, see [Operations and Functions in Q#](xref:microsoft.quantum.guide.operationsfunctions). 

To require support for the `Controlled` and/or `Adjoint` functor in an operation type, you need to add an annotation indicating the corresponding characteristics.
The annotation `is Ctl` (for example, `(Qubit => Unit is Ctl)`) indicates that the operation is controllable. That is, its execution relies on the state of another qubit or qubits. 
Similarly, the annotation `is Adj` indicates that the operation has an adjoint, that is, it can be "inverted" such that successively applying an operation and then its adjoint to a state leaves the state unchanged. 

If you want to require that an operation of that type supports both the `Adjoint` and `Controlled` functor you can express this as `(Qubit => Unit is Adj + Ctl)`. 
For example, the built-in Pauli <xref:microsoft.quantum.intrinsic.x> operation has type `(Qubit => Unit is Adj + Ctl)`. 

An operation type that does not support any functors is specified by its input and output type alone, with no additional annotation.

### Type-Parameterized Functions and Operations

Callable types may contain *type parameters*.
Use a symbol prefixed by a single quote to indicated a type parameter; for example, `'A` is a legal type parameter.
For more information and details on how to define type-parameterized callables, see [Operations and Functions in Q#](xref:microsoft.quantum.guide.operationsfunctions#generic-type-parameterized-callables).

A type parameter may appear more than once in a single signature.
For example, a function that applies another function to each element of an array and returns the collected results has the signature `(('A[], 'A->'A) -> 'A[])`.
Similarly, a function that returns the composition of two operations has the signature `((('A=>'B), ('B=>'C)) -> ('A=>'C))`.

When you invoke a type-parameterized callable, all arguments that have the same type parameter must be of the same type.

Q# does not provide a mechanism for constraining the possible types that a user might substitute for a type parameter.

## Next steps

Now that you've seen all the types which comprise the Q# language, see [Type Expressions in Q#](xref:microsoft.quantum.guide.expressions) to learn how to create and manipulate expressions of these various types.

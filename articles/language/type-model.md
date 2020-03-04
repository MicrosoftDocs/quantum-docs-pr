---
title: Q# Data types
description: Learn about the different types used in the Q# programming language, including built-in types, arrays, tuples, operations, functions and user-defined types. 
author: QuantumWriter
uid: microsoft.quantum.language.type-model
ms.author: Alan.Geller@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
uid: microsoft.quantum.language.type-model
---

# The Type Model

This section lays out the Q# type model and describes the syntax for
specifying and working with types.
We note that Q# is a *strongly-typed* language, such that careful use of these types can help the compiler to provide strong guarantees about Q# programs at compile time.

In order to provide the strongest guarantees possible, conversions between types in Q# must be explicit 
using calls to functions which express that conversion. 
A variety of such functions are provided as a part of the <xref:microsoft.quantum.convert> namespace.
Upcasts to compatible types on the other hand happen implicitly. 

Q# provides both primitive types, which can be used directly, and a variety of ways to produce new types from other types.
We describe each in the rest of this section.

## Primitive Types

The Q# language provides several *primitive types*, from which other types
can be constructed:

- The `Int` type represents a 64-bit signed integer, e.g.: `2`, `107`, `-5`.
- The `BigInt` type represents a signed integer of arbitrary size, e.g. `2L`, `107L`, `-5L`.
   This type is based on the .NET
   <xref:System.Numerics.BigInteger>
   type.
- The `Double` type represents a double-precision floating-point number, e.g.: `0.0`, `-1.3`, `4e-7`.
- The `Bool` type represents a Boolean value which can either be `true` or `false`.
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
- The `Range` type represents a sequence of integers, denoted by `start..step..stop`, where denoting the step is options. 
   That is `start .. stop` corresponds to `start..1..stop`, and e.g. `1..2..7` represents the sequence $\{1, 3, 5, 7\}$.
- The `String` type is a sequence of Unicode characters that
  is opaque to the user once created.
  This type is used to report messages to a classical host in the case of an error or diagnostic event.
- The `Unit` type is the type that allows only one value `()`. 
  This type is used to indicate that Q# function or operation returns no information. 

The constants `true`, `false`, `PauliI`, `PauliX`,
`PauliY`, `PauliZ`, `One`, and `Zero` are all reserved symbols in Q#.

## Array Types

Given any valid Q# type `'T`, there is a type that represents an
array of values of type `'T`.
This array type is represented as `'T[]`;
for example, `Qubit[]` or `Int[][]`.
For instance, a collection of integers is denoted `Int[]`, while an array of arrays of `(Bool, Pauli)` values is denoted `(Bool, Pauli)[][]`.

In the second example, note that this represents a potentially
jagged array of arrays, and not a rectangular two-dimensional array.
Q# does not provide support for rectangular multi-dimensional arrays.

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
It is possible to create arrays of tuples, tuples of arrays,
tuples of sub-tuples, etc.

As of Q# 0.3, `Unit` is the name of the *type*
of the empty tuple; `()` is used for the empty tuple *value*.

Tuple instances are immutable.
Q# does not provide a mechanism to change the contents of a tuple
once created.

Tuples are a powerful concept used throughout Q# to collect values together into a single value, making it easier to pass them around.
In particular, using tuple notation, we can express that every operation and callable takes exactly one input and returns exactly one output.

### Singleton Tuple Equivalence

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
In particular, this means that an operation or function whose input tuple or output tuple type has one field can be thought of as taking a single argument or returning a single value.

We refer to this property as _singleton tuple equivalence_.

## User-Defined Types

A Q# file may define a new named type containing a single value of any legal type.
For any tuple type `T`, we can declare a new user-defined type that is a subtype of `T` with the `newtype` statement.
In the @"microsoft.quantum.math" namespace, for instance, complex numbers are defined as a user-defined type:

```qsharp
newtype Complex = (Double, Double);
```

This statement creates a new type with two anonymous items of type `Double`.   
Aside from anonymous items, user defined types also support named items as of Q# version 0.7 or higher. For example, we could have named the to items `Re` for the double representing the real part of a complex number and `Im` for the imaginary part: 

```qsharp
newtype Complex = (Re : Double, Im : Double);
```
Naming one item in a user defined type does not imply that all items need to be named - any combination of named and unnamed items is supported. Furthermore, also inner items may be named.
The type `Nested` as defined below for example has an underlying type `(Double, (Int, String))`, of which only the item of type `Int` is named and all other items are anonymous. 

```qsharp
newtype Nested = (Double, (ItemName : Int, String)); 
```
Named items have the advantage that they can be accessed directly via the access operator `::`. 

```qsharp
function ComplexAddition(c1 : Complex, c2 : Complex) : Complex {
    return Complex(c1::Re + c2::Re, c1::Im + c2::Im);
}
```

In order to access anonymous items on the other hand, 
the wrapped value first needs to be extracted using the postfix operator `!`.
The "unwrap" operator, `!`, allows to extract the value contained in a user defined type.
The type of such an "unwrap" expression is the underlying type of the user defined type. 

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

Take a look at the section on [unwrap expressions](xref:microsoft.quantum.language.expressions#unwrap-expressions) and [operators precedence](xref:microsoft.quantum.language.expressions#operator-precedence) for more details.

Values of a user defined type can be created by calling the corresponding type constructor:

```
let realUnit = Complex(1.0, 0.0);
let imaginaryUnit = Complex(0.0, 1.0);
```

Alternatively, new values can be created from existing ones using [copy-and-update expressions](xref:microsoft.quantum.language.expressions#copy-and-update-expressions). 
Like for arrays, such expressions copy all item values of the original expression, 
with the exception of the specified named items. For these the values are set to the ones defined on the right hand side of the expression. 
Any other language constructs, like for example [update-and-reassign statements](xref:microsoft.quantum.language.statements#update-and-reassign-statement), that are available for array items exist for named-items in user defined types as well.

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

In addition to providing short aliases for potentially complicated tuple types, one significant advantage of defining such types is that they can document the intent of a particular value.
Returning to the example of `Complex`, one could have also defined 2D polar coordinates as a user-defined type:

```qsharp
newtype Polar = (Radius : Double, Phase : Double);
```

Even though both `Complex` and `Polar` are both have an underlying type `(Double, Double)`, the two types are wholly incompatible in Q#, minimizing the risk of accidentally calling a complex math function with polar coordinates and vice versa.
In this way, user-defined types have a similar role as Records in F# for example. 


## Operation and Function Types

A Q# _operation_ is a quantum subroutine.
That is, it is a callable routine that contains quantum operations.

A Q# _function_ is a classical subroutine used within
a quantum algorithm.
It may contain classical code but no quantum operations.
Specifically, functions may not allocate or borrow qubits, nor may they call operations.
It is possible, however, to pass them operations or qubits for processing.
Functions are thus entirely deterministic in the sense that calling them with the same arguments will always produce the same result. 

Together, operations and functions are called _callables_.  You can see some [examples](#examples) of these below.

All Q# callables are considered to take a single value as input
and return a single value as output.
Both the input and output values may be tuples.
Callables that have no result return `Unit`.
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

Operations—but not functions—have certain additional _characteristics_ that are expressed as part of the operation type. 
Such characteristics include information about what functors the operation supports.
Functors are meta-operations that generate a specialization of a base operation;
see [Functors](#functors), below.

Operation types are specified by the their input type, output type, and their characteristics.    
In order to require support for the `Controlled` and/or `Adjoint` functor in an operation type, we need to add an annotation indicating the corresponding characteristics.
An annotation `is Ctl` for example indicates that the operation is controllable. 
If we want to require that an operation of that type supports both the `Adjoint` and `Controlled` functor we can express this as `(Qubit => Unit is Adj + Ctl)`. 
The used operation characteristics `Adj` and `Ctl` strictly speaking are two pre-defined sets of labels, where each label indicates a particular operation characteristics like e.g. support for a particular functor.
Hence, `+` is used to indicate the union of those two sets, and `*` is used to indicate the intersection - i.e. the labels that are common to both sets.  

For example, the Pauli `X` operation has type
`(Qubit => Unit is Adj + Ctl)`.
An operation type that does not support any functors is specified
by its input and output type alone, with no additional annotation.


### Type-Parameterized Functions and Operations

Callable types may contain type parameters.
Type parameters are indicated by a symbol prefixed by a single quote;
for example, `'A` is a legal type parameter.

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

### Type Compatibility

An operation with additional functors supported may be used anywhere
an operation with fewer functors but the same signature is expected.
For instance, an operation of type `(Qubit => Unit is Adj)` may be used
anywhere an operation of type `(Qubit => Unit)` is expected.

Q# is covariant with respect to callable return types:
a callable that returns a type `'A` is compatible with a callable with
the same input type and a result type that `'A` is compatible with.

Q# is contravariant with respect to input types:
a callable that takes a type `'A` as input is compatible with a callable
with the same result type and an input type that is compatible with `'A`.

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

- The function `ConjugateInvertWith` may be invoked with an `inner`
  argument of either `Invert` or `ApplyUnitary`.
- The function `ConjugateUnitaryWith` may be invoked with an `inner`
  argument of `ApplyUnitary`, but not `Invert`.
- A value of type `(Qubit[] => Unit is Adj + Ctl)` may be returned
  from `ConjugateInvertWith`.

> [!IMPORTANT]
> Q# 0.3 introduces a significant difference in the behavior of
> user-defined types.

User-defined types are treated as a wrapped version of
the underlying type, rather than as a subtype.
This means that a value of a user-defined type is not usable
where a value of the underlying type is expected.

### Functors

A functor in Q# is a factory that defines a new operation
from another operation.
Functors have access to the implementation of the base operation when
defining the implementation of the new operation.
Thus, functors can perform more complex functions than
traditional higher-level functions.

Functors do not have a representation in the Q# type system. 
It is thus currently not possible to bind them to a variable or pass them as arguments. 

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
using the `Adjoint` functor.
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
may be formed using the `Controlled` functor.
The signature of the new operation is based on the signature of the
original operation.
The result type is the same, but the input type is a two-tuple with a
qubit array that holds the control qubit(s) as the first element and
the arguments of the original operation as the second element.
The new operation supports `Controlled`, and will support
`Adjoint` if and only if the original operation did.

If the original operation took only a single argument, then singleton
tuple equivalence will come into play here.
For instance, `Controlled X` is the controlled version of the
`X` operation.
`X` has type `(Qubit => Unit is Adj + Ctl)`, so `Controlled X`
has type `((Qubit[], (Qubit)) => Unit is Adj + Ctl)`;
because of singleton tuple equivalence, this is the same as
`((Qubit[], Qubit) => Unit is Adj + Ctl)`.

If the base operation took several arguments, remember to enclose 
the corresponding arguments of the controlled version of the operation in parentheses 
to convert them into a tuple.
For instance, `Controlled Rz` is the controlled version of the
`Rz` operation.
`Rz` has type `((Double, Qubit) => Unit is Adj + Ctl)`,
so `Controlled Rz` has type
`((Qubit[], (Double, Qubit)) => Unit is Adj + Ctl)`.
Thus, `Controlled Rz(controls, (0.1, target))` would be
a valid invocation of `Controlled Rz` (note the parentheses around `0.1, target`).

As another example, `CNOT(control, target)` can be implemented as `Controlled X([control], target)`. 
If a target should be controlled by 2 control qubits (CCNOT), we can use `Controlled X([control1, control2], target)` statement.

### Examples

This example of a Q# operation comes from the [Measurement](https://github.com/microsoft/Quantum/tree/master/samples/getting-started/measurement) sample. Within operations, we can allocate qubits and use quantum operations on those qubits such as `H` and `X`:

```qsharp
/// # Summary
/// Prepares a state and measures it in the Pauli-Z basis.
operation MeasureOneQubit() : Result {
        mutable result = Zero;

        using (qubit = Qubit()) { // Allocate a qubit
            H(qubit);               // Use a quantum operation on that qubit
            set result = M(qubit);      // Measure the qubit
            if (result == One) {    // Reset the qubit so that it can be released
                X(qubit);
            }

            return result;
        }
 }
```

This example of a function comes from the [PhaseEstimation](https://github.com/microsoft/Quantum/tree/master/samples/characterization/phase-estimation) sample. It contains purely classical code. You can see that, unlike the example above, no qubits are allocated, and no quantum operations are used.

```qsharp
/// # Summary
/// Given two arrays, returns a new array that is the pointwise product
/// of each of the given arrays.
function PointwiseProduct(left : Double[], right : Double[]) : Double[] {
    mutable product = new Double[Length(left)];

    for (idxElement in IndexRange(left)) {
        set product w/= idxElement <- left[idxElement] * right[idxElement];
    }
    return product;
}
```

It is also possible for a function to be passed qubits for processing, as in this example from the [ReversibleLogicSynthesis](https://github.com/microsoft/Quantum/tree/master/samples/algorithms/reversible-logic-synthesis) sample. Qubits are passed to the function and used for processing, although at no point are the qubit states themselves modified.

```qsharp
/// # Summary
/// Translate MCT masks into multiple-controlled Toffoli gates (with single
/// targets).
function GateMasksToToffoliGates(
    qubits : Qubit[], 
    masks : MCMTMask[]) 
: MCTGate[] {

    mutable result = new MCTGate[0];
    let n = Length(qubits);

    for (i in 0 .. Length(masks) - 1) {
        let (controls, targets) = (masks[i])!;
        let controlBits = IntegerBits(controls, n);
        let targetBits = IntegerBits(targets, n);
        let cQubits = Subarray(controlBits, qubits);
        let tQubits = Subarray(targetBits, qubits);

        for (target in tQubits) {
            set result += [MCTGate(cQubits, target)];
        }
    }

    return result;
}
```

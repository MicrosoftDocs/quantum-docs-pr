---
title: Operations and functions in Q#
description: How to define and call operations and functions, as well the controlled and adjoint operation specializations.
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.date: 03/05/2020
ms.topic: article
uid: microsoft.quantum.guide.operationsfunctions
---

# Operations and Functions in Q#

## Defining New Operations

Operations are the core of Q#.
Once declared, they can either be called from classical .NET applications, for example, using a simulator or by other operations within Q#.
Each operation defined in Q# can call any number of other operations, including the built-in intrinsic operations defined by the language. 
The particular way in which Q# defines these intrinsic operations depends on the target machine.
When compiled, each operation is represented as a .NET class type that can be provided to target machines.

Each Q# source file can define any number of operations.
Operation names must be unique within a namespace and can not conflict with type or function names.

An operation declaration consists of the keyword `operation`, followed by the symbol that is the operation's name, a typed identifier tuple that defines the arguments to the operation, a colon `:`, a type annotation that describes the operation's result type, optionally an annotation with the operation characteristics, an open brace, and then the body of the operation declaration, enclosed in braces `{ }`.

Each operation takes an input, produces an output, and specifies the implementation for one or more operation specializations.
The possible specializations, and how to define and call them, are detailed the different sections of this article.
For now, consider the following operation, which defines only a default body specialization and takes a single qubit as its input, then calls the built-in <xref:microsoft.quantum.intrinsic.x> operation on that input:

```qsharp
operation BitFlip(target : Qubit) : Unit {
    X(target);
}
```

The keyword `operation` begins the operation definition, followed by the name; here, `BitFlip`.
Next, the type of input is defined (`Qubit`), along with a name, `target`, for referring to the input within the new operation.
Lastly, `Unit` defines that the operation's output is empty.
`Unit` is used similarly to `void` in C# and other imperative languages and is equivalent to `unit` in F# and other functional languages.

Operations can also return more interesting types than `Unit`.
For instance, the <xref:microsoft.quantum.intrinsic.m> operation returns an output of type `Result`, representing having performed a measurement. We can either pass the output from an operation to another operation or use it with the `let` keyword to define a new variable.

This approach allows for representing classical computation that interacts with quantum operations at a low level, such as in [superdense coding](https://github.com/microsoft/QuantumKatas/tree/master/SuperdenseCoding):

```qsharp
operation DecodeSuperdense(here : Qubit, there : Qubit) : (Result, Result) {

    CNOT(there, here);
    H(there);

    let firstBit = M(there);
    let secondBit = M(here);

    return (firstBit, secondBit);
}
```

> [!NOTE]
> Each operation in Q# takes exactly one input and returns exactly one output.
> Multiple inputs and outputs are represented using *tuples*, which collect multiple values together into a single value.
> Informally, we say that Q# is a "tuple-in tuple-out" language.
> Following this concept, a set of empty parenteses, `()`, should then be read as the "empty" tuple, which has the type `Unit`.

## Controlled and Adjoint Operations

If an operation implements a unitary transformation, as is the case for many operations in Q#, then it is possible to define how the operation acts when *adjointed* or *controlled*. 
An *adjoint* specialization of an operation specifies how the "inverse" of the operation acts, while a *controlled* specialization specifies how an operation acts when its application is conditioned on the state of a particular quantum register.

Adjoints of quantum operations are crucial to many aspects of quantum computing. 
For an example of one such situation discussed alongside a useful Q# programming technique, see [Conjugations](#conjugations) in this article. 

The controlled version of an operation is a new operation that effectively applies the base operation only if all of the control qubits are in a specified state.
If the control qubits are in superposition, then the base operation is applied coherently to the appropriate part of the superposition.
Thus, controlled operations are often used to generate entanglement.

Naturally, a *controlled adjoint* specialization could exist as well, specifying the controlled application of an operation's adjoint.

> [!NOTE]
> If $U$ is the unitary transformation implemented by an operation `U`, then `Adjoint U` represents the unitary transformation $U^\dagger$, which is the complex conjugate transpose.
> Successively applying an operation and then its adjoint to a state leaves the state unchanged, as illustrated by the fact that $UU^\dagger = U^\dagger U = \id$, the identity matrix.
> The unitary representation of a controlled operation is slightly more nuanced, but you can find more details at [Quantum computing concepts: multiple qubits](xref:microsoft.quantum.concepts.multiple-qubits).

The following section describes how to call these various specializations in your Q# code.
Below, we detail how to define operations to support them.

### Calling operation specializations

A *functor* in Q# is a factory that defines a new operation from another operation.
The two standard functors in Q# are `Adjoint` and `Controlled`.

Functors have access to the implementation of the base operation when defining the implementation of the new operation.
Thus, functors can perform more complex functions than traditional higher-level functions. 
Functors do not have a representation in the Q# type system. 
It is thus currently not possible to bind them to a variable or pass them as arguments. 

Use a functor by applying it to an operation, which returns a new operation.
For example, applying the `Adjoint functor` to the `Y` operation returns the new operation `Adjoint Y`. You can invoke the new operation like any other operation.
For an operation to support the application of the `Adjoint` or `Controlled` functors, its return type necessarily needs to be `Unit`. 

#### `Adjoint` functor

Thus, `Adjoint Y(q1)` applies the Adjoint functor to the `Y` operation to generate a new operation, and applies that new operation to `q1`.
The new operation has the same signature and type as the base operation `Y`.
In particular, the new operation also allows `Adjoint`, and will allow `Controlled` if and only if the base operation did.
The Adjoint functor is its own inverse; that is, `Adjoint Adjoint Op` is always the same as `Op`.

#### `Controlled` functor

Similarly, `Controlled X(controls, target)` applies the Controlled functor to the `X` operation to generate a new operation, and applies that new operation to `controls` and `target`.

> [!NOTE]
> In Q#, controlled versions always take an array of control qubits, and the specified state is for all of the control qubits to always be in the computational (`PauliZ`) `One` state, $\ket{1}$.
> Controlling based on other states is achieved by applying the appropriate unitary operation to the control qubits before the controlled operation, and then applying the inverses of the unitary operation after the controlled operation.
> For example, applying an `X` operation to a control qubit before and after a controlled operation causes the operation to control on the `Zero` state ($\ket{0}$) for that qubit; applying an `H` operation before and after controls on the `PauliX` `One` state, that is -1 eigenvalue of Pauli X, $\ket{-} \mathrel{:=} (\ket{0} - \ket{1}) / \sqrt{2}$ rather than the `PauliZ` `One` state.

Given an operation expression, you can form a new operation expression by using the `Controlled` functor.
The signature of the new operation is based on the signature of the original operation.
The result type is the same, but the input type is a two-tuple with a qubit array that holds the control qubit(s) as the first element and the arguments of the original operation as the second element.
The new operation supports `Controlled`, and will support `Adjoint` if and only if the original operation did.

If the original operation took only a single argument, then [singleton tuple equivalence](xref:microsoft.quantum.guide.types) comes into play here.
For instance, `Controlled X` is the controlled version of the `X` operation. 
`X` has type `(Qubit => Unit is Adj + Ctl)`, so `Controlled X` has type `((Qubit[], (Qubit)) => Unit is Adj + Ctl)`; because of singleton tuple equivalence, this is the same as `((Qubit[], Qubit) => Unit is Adj + Ctl)`.

If the base operation took several arguments, remember to enclose the corresponding arguments of the controlled version of the operation in parentheses to convert them into a tuple.
For instance, `Controlled Rz` is the controlled version of the `Rz` operation. 
`Rz` has type `((Double, Qubit) => Unit is Adj + Ctl)`, so `Controlled Rz` has type
`((Qubit[], (Double, Qubit)) => Unit is Adj + Ctl)`.
Thus, `Controlled Rz(controls, (0.1, target))` would be a valid invocation of `Controlled Rz` (note the parentheses around `0.1, target`).

As another example, `CNOT(control, target)` can be implemented as `Controlled X([control], target)`. 
If a target should be controlled by 2 control qubits (CCNOT), we can use `Controlled X([control1, control2], target)` statement.

#### `Controlled Adjoint` 

The `Controlled` and `Adjoint` functors commute, so there is no difference between applying `Controlled Adjoint Op` or `Adjoint Controlled Op`.


## Defining Controlled and Adjoint Implementations

In the first operation declaration examples above, the operations `BitFlip` and `DecodeSuperdense` were defined with signatures `(Qubit => Unit)` and `((Qubit, Qubit) => (Result, Result))`, respectively.
As `DecodeSuperdense` includes measurements, it is not a unitary operation, and therefore neither controlled not adjoint specializations could exist (recall the related requirement that such an operation return `Unit`).
However, as `BitFlip` simply performs the unitary <xref:microsoft.quantum.intrinsic.x> operation, we could have defined it with both specializations.

Here, we detail how to include the existence of specializations in your Q# operation declarations, hence giving them the ability to called in conjunction with the `Adjoint` or `Controlled` functors.
For more information about some of the situations in which it is either valid or not valid to declare certain specializations, see [Circumstances for validly defining specializations](#circumstances-for-validly-defining-specializations) in this article.

Operation characteristics define what kinds of functors you can apply to the declared operation, and what effect they have. 
The existence of these specializations can be declared as part of the operation signature, specifically through an annotation with the operation characteristics: either `is Adj`, `is Ctl`, or `is Adj + Ctl`.
The actual implementation of each specialization can either be *implicitly* or *explicitly* defined.

### Implicitly specifying implementations

In this case, the body of the operation declaration consists solely of the default implementation. 
For example:

```qsharp
operation PrepareEntangledPair(here : Qubit, there : Qubit) : Unit 
is Adj + Ctl { // implies the existence of an adjoint, a controlled, and a controlled adjoint specialization
    H(here);
    CNOT(here, there);
}
```
Here, the corresponding implementation for each such implicitly declared specialization is automatically generated by the compiler, to be performed if the `Adjoint` or `Controlled` functors are used.

So, a call of `Adjoint PrepareEntangledPair` would result in the compiler implementing the adjoint of `CNOT` and then the adjoint of `H`.
These individual operations are both self-adjoint, so the resulting `Adjoint PrepareEntangledPair` operation would simply consist of applying `CNOT(here, there)` and then `H(here)`.
Hence we can use this to write the `DecodeSuperdense` example above more compactly, by using the adjoint of `PrepareEntangledPair` to transform the entangled state back into an unentangled pair of qubits:

```qsharp
operation DecodeSuperdense(here : Qubit, there : Qubit) : (Result, Result) {
    Adjoint PrepareEntangledPair(there, here);

    let firstBit = M(there);
    let secondBit = M(here);

    return (firstBit, secondBit);
}
```

The annotation with the operation characteristics in the declaration is useful to ensure that the compiler auto-generates other specializations based on the default implementation. 

There are several important limitations to consider when designing operations for use with functors.
Most critically, specializations for an operation that uses the output value of any other operation *cannot* be auto-generated by the compiler, as it is ambiguous how to reorder the statements in such an operation to obtain the same effect.

Therefore, it is often useful to explicitly specify the various implementations.

### Explicitly specifying implementations

In the case where the compiler cannot generate the implementation, you can specify it explicitly. 
Such explicit specialization declarations can consist of a suitable *generation directive* or a user-defined implementation.
Here we provide the full range of possibilities, followed by some examples of explicit specialization. 


#### Explicit specialization declarations

Q# operations can contain the following explicit specialization declarations:

- The `body` specialization specifies the implementation of the operation with no functors applied.
- The `adjoint` specialization specifies the implementation of the operation with the `Adjoint` functor applied.
- The `controlled` specialization specifies the implementation of the operation with the `Controlled` functor applied.
- The `controlled adjoint` specialization specifies the implementation of the
  operation with both the `Adjoint` and `Controlled` functors applied.
  This specialization can also be named `adjoint controlled`, since the two functors commute.


An operation specialization consists of the specialization tag (for example, `body` or `adjoint`) followed by one of:

- An explicit declaration as described below.
- A *directive* that tells the compiler *how* to generate the specialization, one of:
  - `intrinsic`, which indicates that the target machine provides the specialization.
  - `distribute`, used with the `controlled` and `controlled adjoint` specializations.
    When used with `controlled`, it indicates that the compiler should compute the specialization by applying `Controlled` to all of the operations in the `body`.
    When used with `controlled adjoint`, it indicates that the compiler should compute the specialization by applying `Controlled` to all of the operations in the `adjoint` specialization.
  - `invert`, which indicates that the compiler should compute the `adjoint` specialization by inverting the `body`, for example, reversing the order of operations and applying the adjoint to each one.
    When used with `adjoint controlled`, this indicates that the compiler should compute the specialization by inverting the `controlled` specialization.
  - `self`, to indicate that the adjoint specialization is the same as the `body` specialization.
    Using `self` is legal for the `adjoint` and `adjoint controlled` specializations.
    For `adjoint controlled`, `self` implies that the `adjoint controlled` specialization is the same as the `controlled` specialization.
  - `auto`, to indicate that the compiler should select an appropriate directive to apply.
    You cannot use`auto` for the `body` specialization.

The directives and `auto` all require a closing semi-colon `;`.
The `auto` directive resolves to the following generated directive if an explicit declaration of the `body` is provided:

- The `adjoint` specialization generates according to the directive `invert`.
- The `controlled` specialization generates according to the directive `distribute`.
- The `adjoint controlled` specialization  generates according to the directive `invert` if an explicit
  declaration for `controlled` is given but not one for `adjoint`, and
  `distribute` otherwise.

> [!TIP]   
> If an operation is self-adjoint, explicitly specify either the adjoint or the controlled adjoint specialization via the generation directive `self` to allow the compiler to make use of that information for optimization purposes.

A specialization declaration containing a user-defined implementation consists of an argument tuple followed by a statement block with the Q# code that implements the specialization.
In the argument list, `...` is used to represent the arguments declared for the operation as a whole.
For `body` and `adjoint`, the argument list should always be `(...)`; for `controlled` and `adjoint controlled`, the argument list should be a symbol that represents the array of control qubits, followed by `...`, enclosed in parentheses; for example, `(controls,...)`.

### Examples

An operation declaration might be as simple as the following, which defines the primitive Pauli X operation:

```qsharp
operation X (qubit : Qubit) : Unit
is Adj + Ctl {
    body intrinsic;
    adjoint self;
}
```
Note that the adjoint of the Pauli X operation is defined with the directive `self` because by definition `X` is its own inverse.

The code in `PrepareEntangledPair` above for example is equivalent to the code below containing explicit specialization declarations: 

```qsharp
operation PrepareEntangledPair(here : Qubit, there : Qubit) : Unit 
is Ctl + Adj {
    body (...) { // default body specialization
        H(here);
        CNOT(here, there);
    }

    adjoint auto; // auto-generate adjoint specialization
    controlled auto; // auto-generate controlled specialization
    controlled adjoint auto; // auto-generate controlled adjoint specialization
}
```
The keyword `auto` indicates that the compiler should determine how to generate the specialization implementation.

#### User-defined specialization implementation

If the compiler cannot generate the implementation for a certain specialization automatically, or if a more efficient implementation can be given, then you can manually define the implementation.

```qsharp
operation PrepareEntangledPair(here : Qubit, there : Qubit) : Unit
is Ctl + Adj {
    body (...) { // default body specialization
        H(here);
        CNOT(here, there);
    }

    controlled (cs, ...) { // user-defined implementation for the controlled specialization
        Controlled H(cs, here);
        Controlled X(cs + [here], there);
    }

    adjoint invert; 
    controlled adjoint invert; 
}
```
In the example above, `adjoint invert;` indicates that the adjoint specialization is to be generated by inverting the body implementation, and `controlled adjoint invert;` indicates that the controlled adjoint specialization is to be generated by inverting the given implementation of the controlled specialization.

If one or more specializations besides the default body need to be explicitly declared, then the implementation for the default body needs to be wrapped into a suitable specialization declaration as well:

```qsharp
operation CountOnes(qubits: Qubit[]) : Int {

    body (...) // default body specialization
    {
        mutable n = 0;
        for (qubit in qubits) {
            set n += M(q) == One ? 1 | 0;
        }
        return n;
    }

    ...
```

### Circumstances for validly defining specializations

#### Operation declarations with adjoint/controlled

It is legal to specify an operation with no adjoint or controlled versions. 
For instance, measurement operations have neither because they are not invertible or controllable.

An operation supports the `Adjoint` and `Controlled` functors if its declaration contains an implicit or explicit declaration of the respective specializations.

An explicitly declared adjoint/controlled specialization implies the existence of an adjoint/controlled specialization. 

For an operation whose body contains repeat-until-success loops, set statements, measurements, return statements, or calls to other operations that do not support the `Adjoint` functor, auto-generating an adjoint specialization following the `invert` or `auto` directive is not possible.

For an operation whose body contains calls to other operations that do not support the `Controlled` functor, auto-generating a controlled specialization following the `distribute` or `auto` directive is not possible.

#### Controlled Adjoint

The controlled adjoint version of an operation specifies how to implement a quantum-controlled version of the adjoint of the operation.
It is legal to specify an operation with no controlled adjoint version; for instance, measurement operations have no controlled adjoint version because they are neither controllable nor invertible.

A controlled adjoint specialization for an operation needs to exist if and only if both an adjoint and a controlled specialization exist. In that case, the existence of the controlled adjoint specialization is inferred. If no implementation is explicitly defined, the compile generates an appropriate specialization.

For an operation whose body contains calls to other operations that do not have a controlled adjoint version, auto-generating an adjoint specialization following the `invert`, `distribute`, or `auto` directive is not possible.


### Type Compatibility

Use an operation with additional functors supported anywhere you use an operation with fewer functors but the same signature. For instance, use an operation of type `(Qubit => Unit is Adj)` anywhere you use an operation of type `(Qubit => Unit)`.

Q# is *covariant* with respect to callable return types: a callable that returns a type `'A` is compatible with a callable with the same input type and a result type that is compatible with `'A` .

Q# is *contravariant* with respect to input types: a callable that takes a type `'A` as input is compatible with a callable with the same result type and an input type that is compatible with `'A`.

That is, given the following definitions,

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

you can

- Invoke the function `ConjugateInvertWith` with an `inner` argument of either `Invert` or `ApplyUnitary`.
- Invoke the function `ConjugateUnitaryWith` with an `inner` argument of `ApplyUnitary`, but not `Invert`.
- Return a value of type `(Qubit[] => Unit is Adj + Ctl)` from `ConjugateInvertWith`.

> [!IMPORTANT]
> Q# 0.3 introduced a significant difference in the behavior of user-defined types.

User-defined types are treated as a wrapped version of the underlying type, rather than as a subtype.
This means that a value of a user-defined type is not usable where you expect a value of the underlying type is.


### Conjugations

In contrast to classical bits, releasing quantum memory is slightly more involved since blindly resetting qubits can have undesired effects on the remaining computation if the qubits are still entangled. 
These effects can be avoided by properly "undoing" performed computations prior to releasing the memory. 
A common pattern in quantum computing is hence the following: 

```qsharp
operation ApplyWith<'T>(
    outerOperation : ('T => Unit is Adj), 
    innerOperation : ('T => Unit), 
    target : 'T) 
: Unit {

    outerOperation(target);
    innerOperation(target);
    Adjoint outerOperation(target);
}
```

Starting with our 0.9 release, we support a conjugation statement that implements the transformation above. Using that statement, the operation `ApplyWith` can be implemented in the following way:

```qsharp
operation ApplyWith<'T>(
    outerOperation : ('T => Unit is Adj), 
    innerOperation : ('T => Unit), 
    target : 'T) 
: Unit {

    within{ 
        outerOperation(target);
    }
    apply {
        innerOperation(target);
    }
}
```
Such a conjugation statement becomes far more useful if the outer and inner transformations are not readily available as operations but are instead more convenient to describe by a block consisting of several statements. 

The inverse transformation for the statements defined in the within-block is automatically generated by the compiler and executed after the apply-block completes.
Since any mutable variables used as part of the within-block cannot be rebound in the apply-block, the generated transformation is guaranteed to be the adjoint of the computation in the within-block. 


## Defining New Functions

Functions are purely deterministic, classical routines in Q#, which are distinct from operations in that they are not allowed to have any effects beyond calculating an output value.
In particular, functions cannot call operations; act on, allocate, or borrow qubits; sample random numbers; or otherwise depend on state beyond the input value to a function.
As a consequence, Q# functions are *pure*, in that they always map the same input values to the same output values.
This behavior allows the Q# compiler to safely reorder how and when to call functions when generating operation specializations.

Each Q# source file can define any number of functions.
Function names must be unique within a namespace and cannot conflict with operation or type names.

Defining a function works similarly to defining an operation, except that no adjoint or controlled specializations can be defined for a function.
For instance:

```qsharp
function Square(x : Double) : (Double) {
    return x * x;
}
```

or 

```qsharp
function DotProduct(a : Double[], b : Double[]) : Double {
    if (Length(a) != Length(b)) {
        fail "Arrays are not compatible";
    }

    mutable accum = 0.0;
    for (i in 0..Length(a)-1) {
        set accum += a[i] * b[i];
    }
    return accum;
}
```

### Classical logic in functions == good

Whenever it is possible to do so, it is helpful to write out classical logic in terms of functions rather than operations so that operations can more readily use it. For example, if we had written the `Square` declaration above as an *operation*, then the compiler would not have been able to guarantee that calling it with the same input would consistently produce the same outputs.

To underscore the difference between functions and operations, consider the problem of classically sampling a random number from within a Q# operation:

```qsharp
operation U(target : Qubit) : Unit {

    let angle = RandomReal()
    Rz(angle, target)
}
```

Each time that `U` is called, it has a different action on `target`.
In particular, the compiler cannot guarantee that if we added an `adjoint auto` specialization declaration to `U`, then `U(target); Adjoint U(target);` acts as identity (that is, as a no-op).
This violates the definition of the adjoint defined in [Vectors and Matrices](xref:microsoft.quantum.concepts.vectors), such that allowing the compiler to auto-generate an adjoint specialization in an operation where we have called the operation <xref:microsoft.quantum.math.randomreal> would break the guarantees provided by the compiler; <xref:microsoft.quantum.math.randomreal> is an operation for which no adjoint or controlled version exists.

On the other hand, allowing function calls such as `Square` is safe, and assures the compiler that it only needs to preserve the input to `Square` to keep its output stable.
Thus, isolating as much classical logic as possible into functions makes it easy to reuse that logic in other functions and operations alike.


## Generic (Type-Parameterized) Callables

Many functions and operations that we might wish to define do not actually heavily rely on the types of their inputs, but rather only implicitly use their types via some other function or operation.
For example, consider the *map* concept common to many functional languages; given a function $f(x)$ and a collection of values $\{x_1, x_2, \dots, x_n\}$, map returns a new collection $\{f(x_1), f(x_2), \dots, f(x_n)\}$.
To implement this in Q#, we can take advantage of that functions are first class.
Let's write out a quick example of `Map`, using `T` as a placeholder while we figure out what types we need.

```qsharp
function Map(fn : (T -> T), values : T[]) : T[] {
    mutable mappedValues = new T[Length(values)];
    for (idx in 0..Length(values) - 1) {
        set mappedValues w/= idx <- fn(values[idx]);
    }
    return mappedValues;
}
```

Note this function looks very much the same no matter what actual types we substitute in.
A map from integers to Paulis, for instance, looks much the same as a map from floating-point numbers to strings:

```qsharp
function MapIntsToPaulis(fn : (Int -> Pauli), values : Int[]) : Pauli[] {
    mutable mappedValues = new Pauli[Length(values)];
    for (idx in 0..Length(values) - 1) {
        set mappedValues w/= idx <- fn(values[idx]);
    }
    return mappedValues;
}

function MapDoublesToStrings(fn : (Double -> String), values : Double[]) : String[] {
    mutable mappedValues = new String[Length(values)];
    for (idx in 0..Length(values) - 1) {
        set mappedValues w/= idx <- fn(values[idx]);
    }
    return mappedValues;
}
```

In principle, we could write a version of `Map` for every pair of types that we encounter, but this introduces several difficulties.
For instance, if we find a bug in `Map`, then we must ensure that the fix is applied uniformly across all versions of `Map`.
Moreover, if we construct a new tuple or UDT, then we must now also construct a new `Map` to go along with the new type.
While this is tractable for a small number of such functions, as we collect more and more functions of the same form as `Map`, the cost of introducing new types becomes unreasonably large in fairly short order.

However, much of this difficulty results from the fact that we have not given the compiler the information it needs to recognize how the different versions of `Map` are related.
Effectively, we want the compiler to treat `Map` as some kind of mathematical function from Q# *types* to Q# functions.

Q# formalizes this notion by allowing functions and operations to have *type parameters*, as well as their ordinary tuple parameters.
In the examples above, we wish to think of `Map` as having type parameters `Int, Pauli` in the first case and `Double, String` in the second case.
For the most part, we use these type parameters are used as though they were ordinary types. We use values of type parameters to make arrays and tuples, call functions and operations, and assign to ordinary or mutable variables.

> [!NOTE]
> The most extreme case of indirect dependence is that of qubits, where a Q# program cannot directly rely on the structure of the `Qubit` type but **must** pass such types to other operations and functions.

Returning to the example above, then, we can see that we need `Map` to have type parameters, one to represent the input to `fn` and one to represent the output from `fn`.
In Q#, this is written by adding angle brackets (that's `<>`, not brakets $\braket{}$!) after the name of a function or operation in its declaration, and by listing each type parameter.
The name of each type parameter must start with a tick `'`, indicating that it is a type parameter and not a ordinary type (also known as a *concrete* type).
For `Map`, we thus write:

```qsharp
function Map<'Input, 'Output>(fn : ('Input -> 'Output), values : 'Input[]) : 'Output[] {
    mutable mappedValues = new 'Output[Length(values)];
    for (idx in 0..Length(values) - 1) {
        set mappedValues w/= idx <- fn(values[idx]);
    }
    return mappedValues;
}
```

Note that the definition of `Map<'Input, 'Output>` looks extremely similar to the versions we wrote out before.
The only difference is that we have explicitly informed the compiler that `Map` doesn't directly depend on what `'Input` and `'Output` are, but works for any two types by using them indirectly through `fn`.
Once we have defined `Map<'Input, 'Output>` in this way, we can call it as though it was an ordinary function:

```qsharp
// Represent Z₀ Z₁ X₂ Y₃ as a list of ints.
let ints = [3, 3, 1, 2];
// Here, we assume IntToPauli : Int -> Pauli
// looks up PauliI by 0, PauliX by 1, so forth.
let paulis = Map(IntToPauli, ints);
```

> [!TIP]
> Writing generic functions and operations is one place where "tuple-in tuple-out" is a very useful way to think about Q# functions and operations.
> Since every function takes exactly one input and returns exactly one output, an input of type `'T -> 'U` matches *any* Q# function whatsoever.
> Similarly, you can pass any operation to an input of type `'T => 'U`.

As a second example, consider the challenge of writing a function that returns the composition of two other functions:

```qsharp
function ComposeImpl(outerFn : (B -> C), innerFn : (A -> B), input : A) : C {
    return outerFn(innerFn(input));
}

function Compose(outerFn : (B -> C), innerFn : (A -> B)) : (A -> C) {
    return ComposeImpl(outerFn, innerFn, _);
}
```

Here, we must specify exactly what `A`, `B`, and `C` are, hence severely limiting the utility of our new `Compose` function.
After all, `Compose` only depends on `A`, `B`, and `C` *via* `innerFn` and `outerFn`.
As an alternative, then, we can add type parameters to `Compose` that indicate that it works for *any* `A`, `B`, and `C`, so long as these parameters match those expected by `innerFn` and `outerFn`:

```qsharp
function ComposeImpl<'A, 'B, 'C>(outerFn : ('B -> 'C), innerFn : ('A -> 'B), input : 'A) : 'C {
    return outerFn(innerFn(input));
}

function Compose<'A, 'B, 'C>(outerFn : ('B -> 'C), innerFn : ('A -> 'B)) : ('A -> 'C) {
    return ComposeImpl(outerFn, innerFn, _);
}
```

The Q# standard libraries provide a range of such type-parameterized operations and functions to make higher-order control flow easier to express.
These are discussed further in the [Q# standard library guide](xref:microsoft.quantum.libraries.standard.intro).


## Callables as First-Class Values

One critical technique for reasoning about control flow and classical logic using functions rather than operations is to utilize that operations and functions in Q# are *first-class*.
That is, they are each values in the language in their own right.
For instance, the following is perfectly valid Q# code, if a little indirect:

```qsharp
operation FirstClassExample(target : Qubit) : Unit {
    let ourH = H;
    ourH(target);
}
```

The value of the variable `ourH` in the snippet above is then the operation <xref:microsoft.quantum.intrinsic.h>, such that we can call that value like any other operation.
This ability allows us to write operations that take operations as a part of their input, forming higher-order control flow concepts.
For instance, we could imagine wanting to "square" an operation by applying it twice to the same target qubit.

```qsharp
operation ApplyTwice(op : (Qubit => Unit), target : Qubit) : Unit {
    op(target);
    op(target);
}
```

### Returning operations from a function

We emphasize that we can also return operations as a part of outputs, such that we can isolate some kinds of classical conditional logic as a classical function, which returns a description of a quantum program in the form of an operation.
As a simple example, consider the teleportation example, in which the party receiving a two-bit classical message needs to use the message to decode their qubit into the proper teleported state.
We could write this in terms of a function that takes those two classical bits and returns the proper decoding operation.

```qsharp
function TeleporationDecoderForMessage(hereBit : Result, thereBit : Result)
: (Qubit => Unit is Adj + Ctl) {

    if (hereBit == Zero && thereBit == Zero) {
        return I;
    } elif (hereBit == One && thereBit == Zero) {
        return X;
    } elif (hereBit == Zero && thereBit == One) {
        return Z;
    } else {
        return Y;
    }
}
```

This new function is indeed a function, in that if you call it with the same values of `hereBit` and `thereBit`, you always get back the same operation.
Thus, the decoder can safely run inside operations without having to reason about how the decoding logic interacts with the definitions of the different operation specializations.
That is, we have isolated the classical logic inside a function, guaranteeing to the compiler that the function call can be reordered with impunity so long as the input is preserved.


## Partial Application

We can do significantly more with functions that return operations by using *partial application*, in which we can provide one or more parts of the input to a function or operation without actually calling it. For example, recalling the `ApplyTwice` example above, we can indicate that we don't want to specify, right away, to which qubit the input operation should apply:

```qsharp
operation PartialApplicationExample(op : (Qubit => Unit), target : Qubit) : Unit {
    let twiceOp = ApplyTwice(op, _);
    twiceOp(target);
}
```

In this case, the local variable `twiceOp` holds the partially applied operation `ApplyTwice(op, _)`, where `_` indicates parts of the input that have not yet been specified.
When we call `twiceOp` in the next line, we pass as input to the partially applied operation all of the remaining parts of the input to the original operation.
Thus, the above snippet is effectively identical to having called `ApplyTwice(op, target)` directly, save for that we have introduced a new local variable that allows us to delay the call while providing some parts of the input.

Since an operation that has been partially applied is not actually called until its entire input has been provided, we can safely partially apply operations even from within functions.

```qsharp
function SquareOperation(op : (Qubit => Unit)) : (Qubit => Unit) {
    return ApplyTwice(op, _);
}
```

In principle, the classical logic within `SquareOperation` could have been much more involved, but it is still isolated from the rest of an operation by the guarantees that the compiler can offer about functions. 
The Q# standard library uses this approach throughout for expressing classical control flow in a way that quantum programs can readily use.


## Recursion

Q# callables are allowed to be directly or indirectly recursive.
That is, an operation or function can call itself, or it can call another callable that directly or indirectly calls the callable operation.

There are two important comments about the use of recursion, however:

- The use of recursion in operations is likely to interfere with certain optimizations.
  This interference can have a substantial impact on the execution time of the algorithm.
- When running on an actual quantum device, stack space might be limited, and so deep recursion can lead to a runtime error.
  In particular, the Q# compiler and runtime do not identify and optimize tail recursion.

## Next steps

Learn about [Variables](xref:microsoft.quantum.guide.variables) in Q#.
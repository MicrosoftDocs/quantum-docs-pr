---
title: Variables in Q#
description: fill description
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.date: 03/05/2020
ms.topic: article
uid: microsoft.quantum.guide.variables
---

# Variables in Q#

Q# distinguishes between mutable and immutable symbols, or "variables", which are bound/assigned to expressions.
In general, the use of immutable symbols is encouraged because it allows the compiler to perform more optimizations.

The left-hand-side of a binding consists of a symbol tuple, and the right hand side of an expression.

## Immutable Variables

A value of any type in Q# can be assigned to a variable for reuse within an operation or function by using the `let` keyword.

An immutable binding consists of the keyword `let`, followed by a symbol or symbol tuple, an equals sign `=`, an expression to bind the symbol(s) to, and a terminating semicolon.

For instance:

```qsharp
let measurementOperator = [PauliX, PauliZ, PauliZ, PauliX, PauliI];
```

This assigns a particular array of Pauli operators to the variable name (or "symbol"), `measurementOperator`.

> [!NOTE]
> We did not need to explicitly specify the type of our new variable, as the expression on the right-hand side of the `let` statement is unambiguous and the type is inferred by the compiler. 

Variables defined using `let` are *immutable*, meaning that once it has been defined, it can no longer be changed in any way.
This allows for several beneficial optimizations, including optimization of the classical logic acting on variables to be reordered for applying the `Adjoint` variant of an operation.

## Mutable Variables

As an alternative to creating a variable with `let`, the `mutable` keyword will create a mutable variable that *can* be re-bound after it is initially created by using the `set` keyword.

Symbols declared and bound as part of a `mutable` statement may be rebound to a different value later in the code. 
If a symbol is rebound later in the code, its type does not change, and the newly bound value needs to be compatible with that type.

### Rebinding of Mutable Symbols

A mutable variable may be rebound using a `set` statement.
Such a rebinding consists of the keyword `set`, followed by a symbol or symbol tuple, an equals sign `=`, an expression to rebind the symbol(s) to, and a terminating semicolon.

Here, we provide some possible examples of rebinding statement techniques

### Apply-and-Reassign Statements

A particular kind of `set`-statement we refer to as an *apply-and-reassign* statement provides a convenient way of concatenation if the right hand side consists of the application of a binary operator and the result is to be rebound to the left argument to the operator. 
For example,
```qsharp
mutable counter = 0;
for (i in 1 .. 2 .. 10) {
    set counter += 1;
    // ...
}
```
increments the value of the counter `counter` in each iteration of the `for` loop. The code above is equivalent to 
```qsharp
mutable counter = 0;
for (i in 1 .. 2 .. 10) {
    set counter = counter + 1;
    // ...
}
```

Similar statements are available for all binary operators in which the type of the left-hand-side matches the expression type. 
This provides for example a convenient way to accumulate values.

For example, supposing `qubits` is a regsiter of qubits:
```qsharp
mutable results = new Result[0];   // results is an empty array of type Result[]
for (q in qubits) {
    set results += [M(q)];         // concatenate the outcome from measuring q to the existing array
    // ...
}
...                                // results contains the measurement outcomes from the whole register
```

### Update-and-Reassign Statements

A similar concatenation exists for [copy-and-update expressions](xref:microsoft.quantum.guide.expressions#copy-and-update-expressions) on the right-hand-side.
Correspondingly, *update-and-reassign* statements exist for *named items* in user-defined types as well as for *array items*.  

```qsharp
newtype Complex = (Re : Double, Im : Double);

function ComplexSum(reals : Double[], ims : Double[]) : Complex[] {
    mutable res = Complex(0.,0.);

    for (r in reals) {
        set res w/= Re <- res::Re + r; // update-and-reassign statement
    }
    for (i in ims) {
        set res w/= Im <- res::Im + i; // update-and-reassign statement
    }
    return res;
}
```

In the case of arrays, [`Microsoft.Quantum.Arrays`](xref:microsoft.quantum.arrays) in our standard libraries provides the necessary tools for many common array initialization and manipulation needs, and thus help avoid having to update array items in the first place. 

Update-and-reassign statements provide an alternative if needed:

```qsharp
operation GenerateRandomInts(max : Int, nSamples : Int) : Int[] {
    mutable samples = new Double[0];
    for (i in 1 .. nSamples) {
        set samples += [RandomInt(max)];
    }
    return samples;
}

operation SampleUniformDistrbution(nSamples : Int, nSteps : Int) : Double[] {
    let normalization = 1. / IntAsDouble(nSteps);
    mutable samples = GenerateRandomInts(nSteps, nSamples);
    
    for (i in IndexRange(samples) {
        let value = IntAsDouble(samples[i]);
        set samples w/= i <- normalization * value; // update-and-reassign statement
    }
}

```

Using the library tools for arrays provided in [`Microsoft.Quantum.Arrays`](xref:microsoft.quantum.arrays), we can, for example, easily define a function that returns an array of Paulis where the Pauli at index `i` takes the given value and all other entries are the identity.

Here are two definitions of such a function, with the second taking advantage of the tools at our disposal.

```qsharp
function PauliEmbedding(pauli : Pauli, length : Int, location : Int) : Pauli[] {
    mutable pauliArray = new Pauli[length];             // initialize pauliArray of given length
    for (index in 0 .. length - 1) {                    // iterate over the integers in the length range
        set pauliArray w/= index <-                     // change the value at index to input pauli or PauliI
            index == location ? pauli | PauliI;         // cond. expression evaluating to pauli or PauliI dep. on whether index==location
    }    
    return pauliArray;
}
```

Instead of iterating over each index in the array, and conditionally setting it to `PauliI` or `Pauli`, we can instead use `ConstantArray` from [`Microsoft.Quantum.Arrays`](xref:microsoft.quantum.arrays) to create an array of `PauliI`'s, and then simply returning a copy-and-update expression in which we've changed the specifc value at index `location`:

```qsharp
function PauliEmbedding(pauli : Pauli, length : Int, location : Int) : Pauli[] {
    return ConstantArray(length, PauliI) w/ location <- pauli;
}
```

## Tuple Deconstruction

In addition to assigning a single variable, the `let` and `mutable` keywords---or in fact any other binding construct, such as `set` (described below)---also allow for unpacking the contents of a [tuple type](xref:microsoft.quantum.guide.types#tuple-types).
An assignment of this form is said to *deconstruct* the elements of that tuple.

If the right-hand side of the binding is a tuple, then that tuple may be deconstructed upon assignment.
Such deconstructions may involve nested tuples, and any full or partial deconstruction is valid as long as the shape of the tuple on the right hand side is compatible with the shape of the symbol tuple.

For example:

```qsharp
let (i, f) = (5, 0.1); // i is bound to 5 and f to 0.1
mutable (a, (_, b)) = (1, (2, 3)); // a is bound to 1, b is bound to 3
mutable (x, y) = ((1, 2), [3, 4]); // x is bound to (1,2), y is bound to [3,4]
set (x, _, y) = ((5, 6), 7, [8]);  // x is rebound to (5,6), y is rebound to [8]
let (r1, r2) = MeasureTwice(q1, PauliX, q2, PauliY);
```

## Binding Scopes

In general, symbol bindings go out of scope and become inoperative at the end of the statement block they occur in.
There are two exceptions to this rule:

- The binding of the loop variable of a `for` loop is in scope for the body of the for loop, but not after the end of the loop.
- All three portions of a `repeat`/`until` loop (the body, the test, and the fixup) are treated as a single scope, so symbols that are bound in the body are available in the test and in the fixup.

For both types of loops, each pass through the loop executes in its own scope, so bindings from an earlier pass are not available in a later pass.
Details on these loops can be found at [Control Flow](xref:microsoft.quantum.guide.controlflow).

Symbol bindings from outer blocks are inherited by inner blocks.
A symbol may only be bound once per block; it is illegal to define a symbol with the same name as another symbol that is within scope (no "shadowing").
The following sequences would be legal:

```qsharp
if (a == b) {
    ...
    let n = 5;
    ...             // n is 5
}
let n = 8;
...                 // n is 8
```

and

```qsharp
if (a == b) {
    ...
    let n = 5;
    ...             // n is 5
} else {
    ...
    let n = 8;
    ...             // n is 8
}
...                 // n is not bound to a value
```

But this would be illegal:

```qsharp
let n = 5;
...                 // n is 5
let n = 8;          // Error!!
...
```

as would:

```qsharp
let n = 8;
if (a == b) {
    ...             // n is 8
    let n = 5;      // Error!
    ...
}
...
```

## What's Next?
Learn about [Working With Qubits](xref:microsoft.quantum.guide.qubits) in Q#.
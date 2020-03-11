---
title: Mutable and immutable variables in Q#
description: fill description
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.date: 03/05/2020
ms.topic: article
uid: microsoft.quantum.guide.using.variables
---

# Mutable and immutable variables in Q#

words

# from 'statements' file
## Symbol Binding and Assignment

Q# distinguishes between mutable and immutable symbols.
In general, the use of immutable symbols is encouraged because it
allows the compiler to perform more optimizations.

The left-hand-side of the binding consists of a symbol tuple, and the right hand side of an expression.

Since all Q# types are value types - with the qubits taking a somewhat special role - 
formally a "copy" is created when a value is bound to a symbol, or when a symbol is rebound. 
That is to say, the behavior of Q# is the same as if a copy were created on assignment. 
This in particular also includes arrays. Of course in practice only the relevant pieces are actually recreated as needed. 

### Tuple Deconstruction

If the right-hand side of the binding is a tuple,
then that tuple may be deconstructed upon assignment.
Such deconstructions may involve nested tuples, and any full or partial deconstruction is valid as long as the shape of the tuple on the right hand side is compatible with the shape of the symbol tuple.
Tuple deconstruction can in particular also be used when the right-hand side of the `=` is a tuple-valued expression.

```qsharp
let (i, f) = (5, 0.1); // i is bound to 5 and f to 0.1
mutable (a, (_, b)) = (1, (2, 3)); // a is bound to 1, b is bound to 3
mutable (x, y) = ((1, 2), [3, 4]); // x is bound to (1,2), y is bound to [3,4]
set (x, _, y) = ((5, 6), 7, [8]);  // x is rebound to (5,6), y is rebound to [8]
let (r1, r2) = MeasureTwice(q1, PauliX, q2, PauliY);
```

### Immutable Symbols

Immutable symbols are bound using the `let` statement.
This is roughly equivalent to variable declaration and initialization in
languages such as C#, except that Q# symbols, once bound, may not be changed;
`let` bindings are immutable.

An immutable binding consists of the keyword `let`, followed by
a symbol or symbol tuple, an equals sign `=`, an expression to bind the symbol(s) to, and a terminating semicolon.
The type of the bound symbol(s) is inferred based on the expression on the right hand side.

### Mutable Symbols

Mutable symbols are defined and initialized using the `mutable` statement.
Symbols declared and bound as part of a `mutable` statement may be rebound to a different value later in the code. 

A mutable binding statement consists of the keyword `mutable`, followed by
a symbol or symbol tuple, an equals sign `=`, an expression to bind the symbol(s) to, and a terminating semicolon.
The type of the bound symbol(s) is inferred based on the expression on the right hand side. If a symbol is rebound later in the code, its type does not change, and the bound value needs to be compatible with that type.

### Rebinding of Mutable Symbols

A mutable variable may be rebound using a `set` statement.
Such a rebinding consists of the keyword `set`, followed by
a symbol or symbol tuple, an equals sign `=`, an expression to rebind the symbol(s) to, and a terminating semicolon.
The value must be compatible with the type(s) of the symbol(s) it is bound to.

#### Apply-and-Reassign Statement

A particular kind of set-statement we refer to as an apply-and-reassign statement provides a convenient way of concatenation if the right hand side consists of the application of a binary operator and the result is to be rebound to the left argument to the operator. 
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
This provides for example a convenient way to accumulate values:
```qsharp
mutable results = new Result[0];
for (qubit in qubits) {
    set results += [M(q)];
    // ...
}
```
#### Update-and-Reassign Statement

A similar concatenation exists for copy-and-update expressions on the right hand side. 
Correspondingly, update-and-reassign statements exist for named items in user-defined types as well as for array items.  

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

In the case of arrays, 
our standard libraries contain the necessary tools for many common array initialization and manipulation needs, 
and thus help avoid having to update array items in the first place. 
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

> [!TIP]   
> Avoid unnecessary use of update-and-reassign statements by leveraging the tools provided in <xref:microsoft.quantum.arrays>.

The function
```qsharp
function PauliEmbedding(pauli : Pauli, length : Int, location : Int) : Pauli[] {
    mutable pauliArray = new Pauli[length];
    for (index in 0 .. length - 1) {
        set pauliArray w/= index <- 
            index == location ? pauli | PauliI;
    }    
    return pauliArray;
}
```
for example can simply be simplified using the function `ConstantArray` in `Microsoft.Quantum.Arrays`, 
and returning a copy-and-update expression:

```qsharp
function PauliEmbedding(pauli : Pauli, length : Int, location : Int) : Pauli[] {
    return ConstantArray(length, PauliI) w/ location <- pauli;
}
```

### Binding Scopes

In general, symbol bindings go out of scope and become inoperative
at the end of the statement block they occur in.
There are two exceptions to this rule:

- The binding of the loop variable of a `for` loop is in scope for
  the body of the for loop, but not after the end of the loop.
- All three portions of a `repeat`/`until` loop (the body, the test,
  and the fixup) are treated as a single scope, so symbols that are
  bound in the body are available in the test and in the fixup.

For both types of loops, each pass through the loop executes in its own scope,
so bindings from an earlier pass are not available in a later pass.

Symbol bindings from outer blocks are inherited by inner blocks.
A symbol may only be bound once per block; it is illegal to define a symbol
with the same name as another symbol that is within scope (no "shadowing").
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
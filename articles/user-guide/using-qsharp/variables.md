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

## from local variables page
## Local Variables 

A value of any type in Q# can be assigned to a variable for reuse within an operation or function by using the `let` keyword.
For instance:

```qsharp
let measurementOperator = [PauliX, PauliZ, PauliZ, PauliX, PauliI];
```

This assigns a particular array of Pauli operators to a variable called `measurementOperator`.

> [!TIP]
> Note that we did not need to explicitly specify the type of our new variable, as the expression on the right-hand side of the `let` statement is unambiguous and the type is inferred by the compiler. 

Variables in Q# are *immutable*, meaning that once a variable has been defined in this way, it can no longer be changed in any way.
This allows for several beneficial optimizations, including optimization of the classical logic acting on variables to be reordered for applying the `Adjoint` variant of an operation.

Variables defined using the `let` binding as above are local to a particular scope, such as the body of an operation or the contents of a `for` loop.


## Mutability ##

As an alternative to creating a variable with `let`, the `mutable` keyword will create a special mutable variable that can be re-bound after it is initially created by using the `set` keyword.

```qsharp
operation RandomInts(maxInt : Int, nrSamples : Int) : Int[] {
    mutable samples = new Int[0];
    for (i in 1 .. nrSamples) {
        set samples += [RandomInt(maxInt)];
    }
    return samples;
}
```

All types in Q#, including arrays, follow value semantics. In particular, it is not possible to update array items. To modify an existing array requires leveraging a copy-and-update mechanism much like the one for records in F#. 
Using the library tools for arrays provided in [`Microsoft.Quantum.Arrays`](xref:microsoft.quantum.arrays), we can e.g. easily define a function that returns an array of Paulis where the Pauli at index `i` takes the given value and all other entries are the identity: 

```qsharp
function EmbedPauli (pauli : Pauli, i : Int, n : Int) : Pauli[] {
    
    let arr = ConstantArray(n, PauliI); // creates an array of filled with PauliI
    return arr w/ i <- pauli; // constructs a new array based on arr except that entry i is set to pauli
}
```

We will elaborate more on how to work with arrays when discussing Q# statements and expressions. 

Mutability within Q# is a concept that applies to a *symbol* rather than a type or value. 
Specifically, it does not have a representation in the type system, implicitly or explicitly, and whether or not a binding is mutable (as indicated by the `mutable` keyword) or immutable (as indicated by `let`) does not change the type of the bound variable(s). 
This provides an important way to isolate mutability inside specialized functions and operations.
In particular, even though an adjoint specialization for an operation which uses a mutable variable cannot be auto-generated, auto-generation works fine for an operation calling a function which uses mutability.
For this reason, it is a good practice to make functions and operations which use mutability as short and compact as possible, so that the rest of the quantum program can be written using ordinary immutable variables.


## Deconstruction ##

In addition to assigning a single variable, the `let` and `mutable` keywords - or in fact any other binding construct - also allow for unpacking the contents of a [tuple type](xref:microsoft.quantum.language.type-model#tuple-types).
An assignment of this form is said to *deconstruct* the elements of that tuple.
For instance, if we model a term in a Hamiltonian by a tuple, then we can use deconstruction to access the different data that we need to simulate under that term:

```qsharp
// Represents H = 3.1 X_0 Z_1.
let (_, (paulis, idxQubits)) = ((3.1, 1.0), ([PauliX, PauliZ], [0, 1])); // paulis and idxQubits are both immutable variables
mutable ((c1, c2), _) = ((3.1, 1.0), ([PauliX, PauliZ], [0, 1])); // c1 and c2 are both mutable variables
```





words

## from 'statements' file
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
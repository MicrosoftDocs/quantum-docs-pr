---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Q# techniques - local variables | Microsoft Docs 
description: Q# techniques - local variables
author: QuantumWriter
ms.author: Christopher.Granade@microsoft.com
ms.date: 12/11/2017
ms.topic: article
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# For Quantum products none of these categories have been defined  yet.
# ms.service: service-name-from-white-list
# ms.prod: product-name-from-white-list
# ms.technology: tech-name-from-white-list
---

# Local Variables #

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

As an alternative to creating a variable with `let`, the `mutable` keyword will create a special mutable variable that can be changed after it is initially created by using the `set` keyword.
If a mutable variable is an array type, then the elements of that array can also be changed.
This is very useful, for instance, for creating arrays programmatically:

```qsharp
function Squares(nSquares : Int) : Int[] {
    mutable squares = new Int[nSquares];
    for (idxSquare in 0..nSquares - 1) {
        set squares[idxSequare] = idxSquare ^ 2;
    }
    return squares;
}
```

The example above also illustrates another important feature of mutability in Q#: arrays bound to mutable local variables are themselves mutable.
As we will see in more detail when discussing [array types](xref:microsoft.quantum.techniques.type-model#array-types), this is not true of ordinary variables.
Informally, collections descending from immutable variables are immutable, while collections descending from mutable variables are mutable.

No operation or function calling `Squares` can observe that the local variable `squares` was defined to be mutable; mutability is an implementation detail that callers do not need to worry about.
This provides an important way to isolate mutability inside specialized functions and operations.
In particular, even though an operation which uses a mutable variable cannot use `adjoint auto`, an operation can call a function which uses mutability.
For this reason, it is a good practice to make functions and operations which use mutability as short and compact as possible, so that the rest of the quantum program can be written using ordinary immutable variables.

## Deconstruction ##

In addition to assigning a single variable, the `let` keyword also allows for unpacking the contents of a [tuple type](#tuple-types).
An assignment of this form is said to *deconstruct* the elements of that tuple.
For instance, if we model a term in a Hamiltonian by a tuple, then we can use deconstruction to access the different data that we need to simulate under that term:

```qsharp
// Represents H = 3.1 X_0 Z_1.
let (coefficient, (paulis, idxQubits)) = (3.1, ([PauliX, PauliZ], [0, 1]));
```

We can also use deconstruction to access the different parts of a [user-defined type](#user-defined-types):

```qsharp
newtype Quaternion = (Double, Double, Double, Double);
let (realPart, iPart, jPart, kPart) = Quaternion(1.0, -2.0, 3.5, 0.0);
```

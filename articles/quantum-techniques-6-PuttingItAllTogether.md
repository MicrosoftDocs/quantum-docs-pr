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

## Putting it All Together: Teleportation ##

Let's return to the example of the teleportation circuit defined in @qc_concepts <!-- TODO: more specific link. -->.

![`Teleport(msg : Qubit, there : Qubit) : ()`](figures/teleportation.svg)

We can now translate each of the steps in this quantum circuit into Q#.
First, we begin the definition of a new operation while will perform the teleportation given two qubits `msg` and `there`:

```qsharp
operation Teleport(msg : Qubit, there : Qubit) : () {
    body {
```

Next, we allocate a qubit `here` with a `using` block:

```qsharp
        using (register = Qubit[1]) {
            let here = register[0];
```

We can then create the entangled pair between `here` and `there` by using the @"microsoft.quantum.primitive.h" and @"microsoft.quantum.primitive.cnot" operations:

```qsharp
            H(here);
            CNOT(here, there);
```

We then use the next $\operatorname{CNOT}$ and $H$ gates to move our message qubit:

```qsharp
            CNOT(msg, here);
            H(msg);
```

Finally, we use @"microsoft.quantum.primitive.m" to perform the measurements and feed them into classical control, as denoted by `if` statements:

```qsharp
            // Measure out the entanglement.
            if (M(msg) == One)  { Z(there); }
            if (M(here) == One) { X(there); }
```

This finishes the definition of our teleportation operator, so we can deallocate `here`, end the body, and end the operation.

```qsharp
        }
    }
}
```

# Going Further #

## Borrowing Qubits ##

<!-- TODO -->

## Generic Operations and Functions ##

Many functions and operations that we might wish to define do not actually heavily rely on the types of their inputs, but rather only implicitly use their types via some other function or operation.
The most extreme case, of course, is that of qubits, where a Q# program cannot directly rely on the structure of the `Qubit` type, but **must** pass such types to other operations and functions.
Type-parameterized, or generic, operations and functions formalize this idea by allowing us to specify that an operation or function has an additional *type parameter* in addition to its input.
Jumping right in, consider the challenge of writing a function that returns the composition of two other functions:

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

The canon provided with the Q# standard library provides a range of such type-parameterized operations and functions to make higher-order control flow easier to express.
These are discused further in the [standard library guide](). <!-- TODO: link -->

## Debugging and Testing Quantum Programs ##

<!-- TODO -->
---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: "Quantum Techniques: Going Further | Microsoft Docs"
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

# Going Further #

Now that you've seen how to write interesting quantum programs in Q#, this section goes further by introducing a few more advanced topics that should prove uiseful going forward.

## Debugging and Testing Quantum Programs ##

One important consequence of the fact that functions in Q# are deterministic is that a function whose output type is the empty tuple `()` cannot ever be observed from within a Q# program.
That is, a target machine can choose not to execute any function which returns `()` with the guarantee that this omission will not modify the behavior of any following Q# code.
This consequence makes functions a useful tool for embedding debugging and testing logic.

In particular, functions of this form can be used to represent diagnostic side effects.
Let's consider a simple example:

```
function AssertPositive(value : Double) : () {
    if (value <= 0) {
        fail "Expected a positive number.";
    }
}
```

Here, the keyword `fail` indicates that the computation should not proceed, raising an exception in the target machine running the Q# program.
By definition, a failure of this kind cannot be observed from within Q#, as no further Q# code is run after a `fail` statement is reached.
Thus, if we proceed past a call to `AssertPositive`, we can be assured by the [anthropic principle](https://www.scottaaronson.com/democritus/lec17.html) that its input was positive, even though we were not able to directly observe this fact.

Similarly, the primitive function @"microsoft.quantum.primitive.message" has type `String -> ()`, and allows for emitting diagnostic messages.
That a target machine observes the contents of the input to `Message` does not imply any consequence that is observable from within Q#.
A target machine may thus elide calls to `Message` by the same logic.

Building on these ideas, the prelude offers two especially useful assertions, both modeled as functions onto `()`: @"microsoft.quantum.primitive.assert" and @"microsoft.quantum.primitive.assertprob".
These assertions each take a Pauli operator describing a particular measurement of interest, a register on which a measurement is to be performed, and a hypothetical outcome.
On target machines which work by simulation, we are not bound by the [no-cloning theorm](TODO: link to glossary), and can perform such measurements without disturbing the register passed to such assertions.
A simulator can then, similar to the `AssertPositive` function above, abort computation if the hypothetical outcome would not be observed in practice:

<!-- TODO: check that this code is correct. -->

```
using (register = Qubit[1]) {
    H(register[0]);
    Assert([PauliX], register, Zero);
    // Even though we do not have access to states in Q#,
    // we know by the anthropic principle that the state
    // of register at this point is |+〉.
}
```

On actual hardware, where we are constrained by physics, we of course cannot perform such counterfactual measurements, and so the `Assert` and `AssertProb` functions simply return `()` with no other effect.


<!--

    TODO: finish this section.

-->

## Generic Operations and Functions ##

Many functions and operations that we might wish to define do not actually heavily rely on the types of their inputs, but rather only implicitly use their types via some other function or operation.
The most extreme case, of course, is that of qubits, where a Q# program cannot directly rely on the structure of the `Qubit` type, but **must** pass such types to other operations and functions.
Type-parameterized, or generic, operations and functions formalize this idea by allowing us to specify that an operation or function has an additional *type parameter* in addition to its input.
Q# uses a notation for 



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

## Borrowing Qubits ##

<!-- TODO -->
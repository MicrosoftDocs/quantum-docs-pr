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

Now that you've seen how to write interesting quantum programs in Q#, this section goes further by introducing a few more advanced topics that should prove useful going forward.

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

> [!TIP]
> This section assumes some basic familiarity with [generics in C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/introduction-to-generics), [generics in F#](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/generics/), [C++ templates](https://docs.microsoft.com/en-us/cpp/cpp/templates-cpp), or similar approaches to metaprogramming in other languages.

Many functions and operations that we might wish to define do not actually heavily rely on the types of their inputs, but rather only implicitly use their types via some other function or operation.
For example, consider the *map* concept common to many functional languages; given a function $f(x)$ and a collection of values $\{x_1, x_2, \dots, x_n\}$, map returns a new collection $\{f(x_1), f(x_2), \dots, f(x_n)\}$.
To implement this in Q#, we can take advantage of that functions are first class:

```qsharp
function Map(fn : ??? -> ???, values : ???[]) : ???[] {
    mutable mappedValues = new ???[Length(values)];
    for (idx in 0..Length(values) - 1) {
        set mappedValues[idx] = fn(values[idx]);
    }
    return mappedValues;
}
```

In the above snippet, we have intentionally left the type annotations unspecified to emphasize that this function looks very much the same no matter what actual types we substitute in.
A map from integers to Paulis, for instance, looks much the same as a map from floating-point numbers to strings:


```qsharp
function MapIntsToPaulis(fn : Int -> Pauli, values : Int[]) : Pauli[] {
    mutable mappedValues = new Pauli[Length(values)];
    for (idx in 0..Length(values) - 1) {
        set mappedValues[idx] = fn(values[idx]);
    }
    return mappedValues;
}

function MapDoublesToStrings(fn : Double -> String, values : Double[]) : String[] {
    mutable mappedValues = new String[Length(values)];
    for (idx in 0..Length(values) - 1) {
        set mappedValues[idx] = fn(values[idx]);
    }
    return mappedValues;
}
```

In principle, we could write a version of `Map` for every pair of types that we encounter, but this introduces a number of difficulties.
For instance, if we find a bug in `Map`, then we must ensure that the fix is applied uniformly across all versions of `Map`.
Moreover, if we construct a new tuple or UDT, then we must now also construct a new `Map` to go along with the new type.
While this is tractable for a small number of such functions, as we collect more and more functions of the same form as `Map`, the cost of introducing new types becomes unreasonably large in fairly short order.

Much of this difficulty results, however, from that the we have not given the compiler the information it needs to recognize how the different versions of `Map` are related.
Effectively, we want the compiler to treat `Map` as some kind of mathematical function from Q# *types* to Q# functions.
This notion is formalized by allowing functions and operations to have *type parameters*, as well as their ordinary tuple parameters.
In the examples above, we wish to think of `Map` as having type parameters `Int, Pauli` in the first case and `Double, String` in the second case.
For the most part, these type parameters can then be used as though they were ordinary types, provided we use values of each type parameter only indirectly through calling other functions and operations.

> [!NOTE]
> The most extreme case of indirect dependence is that of qubits, where a Q# program cannot directly rely on the structure of the `Qubit` type, but **must** pass such types to other operations and functions.

Returning to the example above, then, we can see that we need `Map` to have type parameters, one to represent the input to `fn` and one to represent the output from `fn`.
In Q#, this is written by adding angle brackets (that's `<>`, not brakets $\braket{}$!) after the name of a function or operation in its declaration, and by listing each type parameter.
The name of each type parameter must start with a tick `'`, indicating that it is a type parameter and not a ordinary type (also known as a *concrete* type).
For `Map`, we thus write:

```qsharp
function Map<'Input, 'Output>(fn : 'Input -> 'Output, values : 'Input[]) : 'Output {
    mutable mappedValues = new 'Output[Length(values)];
    for (idx in 0..Length(values) - 1) {
        set mappedValues[idx] = fn(values[idx]);
    }
    return mappedValues;
}
```

Note that the definition of `Map<'Input, 'Output>` looks extremely similar to the versions we wrote out before.
The only difference is that we have explicitly informed the compiler that `Map` doesn't directly depend on what `Input` and `'Output` are, but works for any two types by using them indirectly through `fn`.
Once we have defined `Map<'Input, 'Output>` in this way, we can call it as though it was an ordinary function:

```qsharp
// Represent Z₀ Z₁ X₂ Y₃ as a list of ints.
let ints = [3; 3; 1; 2];
// Here, we assume IntToPauli : Int -> Pauli
// looks up PauliI by 0, PauliX by 1, so forth.
let paulis = Map(IntToPauli, ints);
```

> [!TIP]
> Writing generic functions and operations is one place where "tuple-in tuple-out" is a very useful way to think about Q# functions and operations.
> Since every function takes exactly one input and returns exactly one output, `'T -> 'U` matches *any* Q# function whatsoever.
> Similarly, every operation is compatible with `'T => 'U`.

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

The canon provided with the Q# standard library provides a range of such type-parameterized operations and functions to make higher-order control flow easier to express.
These are discused further in the [standard library guide](). <!-- TODO: link -->

## Borrowing Qubits ##

<!-- TODO -->
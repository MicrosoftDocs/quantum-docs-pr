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

<!-- Moved Debugging and Testing Quantum Programs section to a separate article -->

## Generic Operations and Functions ##

> [!TIP]
> This section assumes some basic familiarity with [generics in C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/introduction-to-generics), [generics in F#](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/generics/), [C++ templates](https://docs.microsoft.com/en-us/cpp/cpp/templates-cpp), or similar approaches to metaprogramming in other languages.

Many functions and operations that we might wish to define do not actually heavily rely on the types of their inputs, but rather only implicitly use their types via some other function or operation.
For example, consider the *map* concept common to many functional languages; given a function $f(x)$ and a collection of values $\{x_1, x_2, \dots, x_n\}$, map returns a new collection $\{f(x_1), f(x_2), \dots, f(x_n)\}$.
To implement this in Q#, we can take advantage of that functions are first class.
Let's write out a quick example of `Map`, using ★ as a placeholder while we figure out what types we need.

```qsharp
function Map(fn : ★ -> ★, values : ★[]) : ★[] {
    mutable mappedValues = new ★[Length(values)];
    for (idx in 0..Length(values) - 1) {
        set mappedValues[idx] = fn(values[idx]);
    }
    return mappedValues;
}
```

Note this function looks very much the same no matter what actual types we substitute in.
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
For the most part, these type parameters can then be used as though they were ordinary types: we use values of type parameters to make arrays and tuples, call functions and operations, and assign to ordinary or mutable variables.

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
The only difference is that we have explicitly informed the compiler that `Map` doesn't directly depend on what `'Input` and `'Output` are, but works for any two types by using them indirectly through `fn`.
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
> Since every function takes exactly one input and returns exactly one output, an input of type `'T -> 'U` matches *any* Q# function whatsoever.
> Similarly, any operation can be passed to an input of type `'T => 'U`.

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
These are discussed further in the [Q# standard library guide](libraries/intro.md).

## Borrowing Qubits ##

The borrowing mechanism allows to allocate qubits that can be used as scratch space during a computation. These qubits are generally not in a clean state, i.e., they are not necessarily initialized in a known state such as $\ket{0}$. One also speaks of "dirty" qubits as their state is unknown and can even be entangled with other parts of the quantum computer's memory. Among the known use cases of dirty qubits are implementations of multiply-controlled CNOT gates that require only very few qubits and implementation of incrementers. 

In the canon there are examples that use the `borrowing` keyword, for instance the function `MultiControlledXBorrow` defined below. If `controls` denotes the control qubits that should be added to an `X` operation, then an overall of `Length(controls)-2` many dirty ancillas will be added by this implementation. 

```qsharp
operation MultiControlledXBorrow ( controls : Qubit[] , target : Qubit ) : () {
    body {
        ... // skipping some case handling here
        let numberOfDirtyQubits = numberOfControls - 2;
        borrowing( dirtyQubits = Qubit[ numberOfDirtyQubits ] ) {

            let allQubits = [ target ] + dirtyQubits + controls;
            let lastDirtyQubit = numberOfDirtyQubits;
            let totalNumberOfQubits = Length(allQubits);

            let outerOperation1 = 
                CCNOTByIndexLadder(
                    numberOfDirtyQubits + 1, 1, 0, numberOfDirtyQubits , _ );
            
            let innerOperation = 
                CCNOTByIndex(
                    totalNumberOfQubits - 1, totalNumberOfQubits - 2, lastDirtyQubit, _ );
            
            WithA(outerOperation1, innerOperation, allQubits);
            
            let outerOperation2 = 
                CCNOTByIndexLadder(
                    numberOfDirtyQubits + 2, 2, 1, numberOfDirtyQubits - 1 , _ );
            
            WithA(outerOperation2, innerOperation, allQubits);
        }
    }
    adjoint auto
    controlled( extraControls ) {
        MultiControlledXBorrow( extraControls + controls, target );
    }
    controlled adjoint auto
}
```

Note that extensive use of the `With` combinator---in its form that is applicable for operations that support adjoint, i.e., `WithA`---was made in this example which is good programming style as adding control to structures involving `With` only propagates control to the inner operation. Further note that here in addition to the `body` of the operation an implementation of the `controlled` body of the operation was explicitly provided, rather than resorting to a `controlled auto` statement. The reason for this is that we know from the structure of the circuit how to easily add further controls which is beneficial compared to adding control to each and every individual gate in the `body`. 

It is instructive to compare this code with another canon function `MultiControlledXClean` which achieves the same goal of implementing a multiply-controlled `X` operation, however, which uses several clean qubits using the `using` mechanism. 

It should be noted that only such qubits can be borrowed inside an operation that are not already within the scope of the operation, or else the compiler will raise an exception. 

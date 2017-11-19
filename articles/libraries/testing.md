---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: "Testing | Q# standard libraries | Microsoft Docs"
description: 115-145 characters including spaces. Edit the intro para describing article intent to fit here. This abstract displays in the search result.
services: service-name-with-dashes-AZURE-ONLY 
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: vadym-kl
ms.author: vadym@microsoft.com
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

# Testing and Debugging #

As with classical development, is is important to be able to diagnose mistakes and errors in quantum programs.
In this section, we discuss the functions and operations provided by the canon to assist in diagnosing quantum operations implemented in Q#.
Many of these functions and operations rely on the fact that classical simulations of quantum mechanics need not obey the [no cloning theorem](TODO: link), such that we can make unphysical measurements and assertions when using a simulator for our target machine.
Thus, we can test individual operations on a classical simulator before deploying on hardware.

## Testing Qubit States ##

Suppose that `P : Qubit => ()` is an operation intended to prepare the state $\ket{\psi}$ when its input is in the state $\ket{0}$.
Let $\ket{\psi'}$ be the actual state prepared by `P`.
Then, $\ket{\psi} = \ket{\psi'}$ if and only if measuring $\ket{\psi'}$ in the axis described by $\ket{\psi}$ always returns `Zero`.
That is,
\begin{align}
    \ket{\psi} = \ket{\psi'} \text{ if and only if } \braket{\psi | \psi'} = 1.
\end{align}
Using the primitive operations defined in the prelude, we can directly perform a measurement that returns `Zero` if $\ket{\psi}$ is an eigenstate of one of the Pauli operators.

In the case that our target machine is a simulator, however, we can do better, as described in [../quantum-techniques-7-going-further#debugging-and-testing-quantum-programs].
We can use that the classical information used by a simulator to represent the internal state of a qubit is amenable to copying, such that we do not need to actually perform a measurement to test our assertion.
In particular, this allows us to reason about *incompatible* measurements that would be impossible on actual hardware.

The operation <xref:microsoft.quantum.canon.assertqubit> provides useful a particularly useful shorthand to do so in the case that we wish to test the assertion $\ket{\psi} = \ket{0}$.
This is common, for instance, when we have uncomputed to return auxillary qubits to $\ket{0}$ before releasing them.
Asserting against $\ket{0}$ is also useful when we wish to assert that two state preparation `P` and `Q` operations both prepare the same state, and when `Q` supports `Adjoint`.
In particular,
```qsharp
using (register = Qubit[1]) {
    P(register[0]);
    (Adjoint Q)(register[0]);

    AssertQubit(Zero, register[0]);
}
```

More generally, however, we may not have access to assertions about states that do not coincide with eigenstates of Pauli operators.
For example, $\ket{\psi} = (\ket{0} + e^{i \pi / 8} \ket{1}) / \sqrt{2}$ is not an eigenstate of any Pauli operator, such that we cannot use <xref:microsoft.quantum.primitive.assertprob> to uniquely determine that a state $\ket{\psi'}$ is equal to $\ket{\psi}$.
Instead, we must decompose the assertion $\ket{\psi'} = \ket{\psi}$ into assumptions that can be directly tested using  the primitives supported by our simulator.
To do so, let $\ket{\psi} = \alpha \ket{0} + \beta \ket{1}$ for complex numbers $\alpha = a\_r + a\_i i$ and $\beta$.
Note that this expression requires four real numbers $\{a\_r, a\_i, b\_r, b\_i\}$ to specify, as each complex number can be expressed as the sum of a real and imaginary part.
Due to the global phase, however, we can choose $a\_i = 0$, such that we only need three real numbers to uniquely specify a single-qubit state.

Thus, we need to specify three assertions which are independent of each other in order to assert the state that we expect.
We do so by finding the probability of observing `Zero` for each Pauli measurement given $\alpha$ and $\beta$, and asserting each independently.
Let $x$, $y$, and $z$ be `Result` values for Pauli $X$, $Y$, and $Z$ measurements respectively.
Then, using the likelihood function for quantum measurements,
\begin{align}
    \Pr(x = \texttt{Zero} | \alpha, \beta) & = \frac12 + a\_r b\_r + a\_i b\_i \\\\
    \Pr(y = \texttt{Zero} | \alpha, \beta) & = \frac12 + a\_r b\_i - a\_i b\_r \\\\
    \Pr(z = \texttt{Zero} | \alpha, \beta) &
        = \frac12\left(
            1 + a\_r^2 + a\_i^2 + b\_r^2 + b\_i^2
        \right).
\end{align}

The <xref:microsoft.quantum.canon.assertqubitstate> implements these assertions given representations of $\alpha$ and $\beta$ as values of type <xref:microsoft.quantum.canon.complex>.
This is helpful when the expected state can be computed mathematically.

## Representing Quantum Operations ##

We begin by describing how to represent quantum operations mathematically, as this will be helpful in formulating useful assertions

##  ##

We provide several function that built on top of `Microsoft.Quantum.Primitive.AssertProb`
 to help user test the correctness of the operations they implemented. These include: 

* [Checking if two operations are equal](#checking-equality-of-the-operations)
* [Checking that the qubit in the given state](#checking-that-the-qubit-is-in-the-given-state)
* [Helpers to iterate over a Cartesian products and powers](#iterating-over-cartesian-products-and-powers)
* [Asserts on classical values](#asserts-on-classical-values)

## Checking equality of the operations
There are three functions that assist witch checking the equality of quantum operations:

* [Microsoft.Quantum.Canon.AssertOperationsEqualReferenced](fixme.md)
* [Microsoft.Quantum.Canon.AssertOperationsEqualInPlace](fixme.md)
* [Microsoft.Quantum.Canon.AssertOperationsEqualInPlaceCompBasis](fixme.md)

First two functions ensure that two operations are equal. They differ in the number 
of calls to operations being tested and number of total qubits needed. The third operation 
checks equality only on computational basis states and can be particularly useful when 
used with the reversible simulators. First two operations use only Clifford gates 
in addition to calls to operations being tested. 


## Iterating over Cartesian products and powers

There are two helper operations that help user to exhaustively go through possible options 
in their tests: 

* [Microsoft.Quantum.Canon.IterateThroughCartesianProduct](fixme.md)
* [Microsoft.Quantum.Canon.IterateThroughCartesianPower](fixme.md)

The example of use of these operations can be found in the implementation of 
[Microsoft.Quantum.Canon.AssertOperationsEqualInPlace](fixme.md).

## Asserts on classical values

We also provide a range of functions for asserting different properties of and relations between
classical values. These functions all start with prefix Assert and located in Microsoft.Quantum.Canon 
namespace.
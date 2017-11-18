---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: "Q# standard libraries | Microsoft Docs"
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

# Higher-Order Control Flow #

<!--
    FIXME: Some of the functionality here has not been implemented yet.
-->

One of the primary roles of the canon is to make it easier to express high-level algorithmic ideas as quantum programs.
Thus, the Q# canon provides a variety of different flow control constructs, each implemented using partial application of functions and operations.
Jumping immediately into an example, consider the case in which one wants to construct a "CNOT ladder" on a register:

```qsharp
let nQubits = Length(register);
CNOT(register[0], register[1]);
CNOT(register[1], register[2]);
// ...
CNOT(register[nQubits - 2], register[nQubits - 1]);
```

We can express this pattern by using iteration and `for` loops:

```
for (idxQubit in 0..nQubits - 2) {
    CNOT(register[idxQubit], register[idxQubit + 1]);
}
```

Expressed in terms of <xref:microsoft.quantum.canon.applytoeachac> and array manipulation functions such as <xref:microsoft.quantum.canon.zip>, however, this is much shorter and easier to read:

```qsharp
ApplyToEachAC(CNOT, Zip(register[0..nQubits - 2], register[1..nQubits - 1]));
```

In the rest of this section, we will provide a number of examples of how to use the various flow control operations and functions provided by the canon to compactly express quantum programs.

## Applying Operations and Functions over Arrays and Ranges ##

One of the primary abstractions provided by the canon is that of iteration.
For instance, consider an unitary of the form $U \otimes U \otimes \cdots \otimes U$ for a single-qubit unitary $U$.
In Q#, this might get represented as a `for` loop over a register:

```
/// # Summary
/// Applies $H$ to all qubits in a register.
operation HAll(register : Qubit) : () {
    body {
        for (idxQubit in 0..Length(register) - 1) {
            H(register[idxQubit]);
        }
    }
    adjoint auto
    controlled auto
    adjoint controlled auto
}
```

We can then use this new operation as `HAll(register)` to apply $H \otimes H \otimes \cdots \otimes H$.

This is cumbersome to do, however, especially in a larger algorithm.
Moreover, this approach is specialized to the particular operation that we wish to apply to each qubit.
We can use that [operations are first-class](../quantum-techniques-2-operationsandfunctions#operations-and-functions-as-first-class-values) to express this algorithmic concept more explicitly:

```
ApplyToEachAC(H, register);
```

Here, the suffix `AC` indicates that the call to `ApplyToEach` is itself adjointable and controllable.
Thus, if `U` supports `Adjoint` and `Controlled`, the following lines are equivalent:

```
(Adjoint ApplyToEachAC)(U, register);
ApplyToEach((Adjoint U), register);
```

In particular, this means that calls to `ApplyToEachAC` can appear in operations which declare `adjoint auto`.
Similarly, <xref:microsoft.quantum.applytorange> is useful for representing patterns of the form `U(0, targets[0]); U(1, targets[1]); ...`, and offers versions for each combination of functors supports by its input.

> [!TIP]
> `ApplyToEach` is [type-parameterized](../quantum-techniques-7-going-further#generic-operations-and-functions), such that it can be used with operations that take inputs other than `Qubit`.
> For example, suppose that `codeBlocks` is an array of <xref:microsoft.quantum.canon.logicalregister> values that need to be recovered.
> Then `ApplyToEach(Recover(code, recoveryFn, _), codeBlocks)` will apply the error-correcting code `code` and recovery function `recoveryFn` to each block independently.
> This holds even for classical inputs: `ApplyToEach(R(_, _, qubit), [(PauliX, PI() / 2.0); (PauliY(), PI() / 3.0]))` will apply a rotation of $\pi / 2$ about $X$ followed by a rotation of $pi / 3$ about $Y$.

The Q# canon also provides support for classical enumeration patterns familiar to functional programming.- Map / MapIndex (**NB: write this!**)
For instance, <xref:microsoft.quantum.canon.fold> implements the pattern $f(f(f(s\_{\text{initial}}, x\_0), x\_1), \dots)$ for reducing a function over a list.
This pattern can be used to implement sums, products, minima, maxima and other such functions:

```
function Plus(a : Int, b : Int) : Int { return a + b; }
function Sum(xs : Int[]) {
    return Fold(Sum, 0, xs);
}
```

## Composing Operations and Functions ##

The control flow constructs offered by the canon take operations and functions as their inputs, such that it is helpful to be able to compose several operations or functions into a single callable.
For instance, the pattern $UVU^{\dagger}$ is extremely common in quantum programming, such that the canon provides the operation <xref:microsoft.quantum.canon.with> as an abstraction for this pattern.
This abstraction also allows for more efficient compliation into circuits, as `Controlled` acting on the sequence `U(qubit); V(qubit); (Adjoint U)(qubit);` does not need to act on each `U`.
To see this, let $c(U)$ be the unitary representing `(Controlled U)([control], target)` and let $c(V)$ be defined in the same way.
Then for an arbitrary state $\ket{\psi}$,
\begin{align}
    c(U) c(V) c(U)^\dagger \ket{1} \otimes \ket{\psi}
        & = \ket{1} \otimes (UVU^{\dagger} \ket{\psi}) \\\\
        & = (\boldone \otimes U) (c(V)) (\boldone \otimes U^\dagger) \ket{1} \otimes \ket{\psi}.
\end{align}
by the definition of `Controlled`.
On the other hand,
\begin{align}
    c(U) c(V) c(U)^\dagger \ket{0} \otimes \ket{\psi}
        & = \ket{0} \otimes \ket{\psi} \\\\
        & = \ket{0} \otimes (UU^\dagger \ket{\psi}) \\\\
        & = (\boldone \otimes U) (c(V)) (\boldone \otimes U^\dagger) \ket{0} \otimes \ket{\psi}.
\end{align}

**TODO**:
- With
- Bind
- Curry
- Compose / ComposeOp (**NB: these need to be written**)

### Time-Ordered Composition ###

- DecomposeIntoTimeSteps

## Controlling Operations ##

- ControlledOnBitString

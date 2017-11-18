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

```qsharp
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

```qsharp
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

```qsharp
ApplyToEachAC(H, register);
```

Here, the suffix `AC` indicates that the call to `ApplyToEach` is itself adjointable and controllable.
Thus, if `U` supports `Adjoint` and `Controlled`, the following lines are equivalent:

```qsharp
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

```qsharp
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
By linearity, we can conclude that we can factor $U$ out in this way for all input states.
That is, $c(UVU^\dagger) = U c(V) U^\dagger$.
Since controlling operations can be expensive in general, using controlled variants such as `WithC` and `WithCA` can help reduce the number of control functors that need to be applied.

> [!NOTE]
> One other consequence of factoring out $U$ is that we need not even know how to apply the `Controlled` functor to `U`.
> `WithCA` therefore has weaker signature than might be expected:
> ```qsharp
> WithCA<'T> : (('T => () : Adjoint), ('T => () : Adjoint, Controlled), 'T) => ()
> ```

Similarly, <xref:microsoft.quantum.canon.bind> produces operations which apply a sequence of other operations in turn.
For instance, the following are equivalent:
```qsharp
H(qubit); X(qubit);
Bind([H; X], qubit);
```
Combining with iteration patterns can make this especially useful:
```qsharp
// Bracket the quantum Fourier transform with $XH$ on each qubit.
With(ApplyToEach(Bind([H; X]), _), QFT, _);
```

### Time-Ordered Composition ###

We can go still further by thinking of flow control in terms of partial application and classical functions, and can model even fairly sophisticated quantum concepts in terms of classical flow control.
This analogy is made precise by the recognition that unitary operators correspond exactly to the side effects of calling operations, such that any decomposition of unitary operators in terms of other unitary operators correpsonds to constructing a particular calling sequence for classical subroutines which emit instructions to act particular unitary operators.
Under this view, `Bind` is precisely the representation of the matrix product, since `Bind([A; B])(target)` is equivalent to `A(target); B(target);`, which in turn is the calling sequence corresponding to $BA$.

A more sophisticated example is the [Trotter–Suzuki expansion](TODO: cite).
As discussed in [Dynamical Generator Representation](data-structures#dynamical-generator-modeling), the Trotter–Suzuki expansion provides a particularly useful way of expressing matrix exponentials.
For instance, applying the expansion at its lowest order yields that for any operators $A$ and $B$ such that $A = A^\dagger$ and $B = B^\dagger$,
\begin{align}
    \tag{★} \label{eq:trotter-suzuki-0}
    \exp(i [A + B] t) = \lim_{n\to\infty} \left(\exp(i A t / n) \exp(i B t / n)\right)^n.
\end{align}
Colloquially, this says that we can approximately evolve a state under $A + B$ by alternately evolving under $A$ and $B$ alone.
If we represent evolution under $A$ by an operation `A : (Double, Qubit[]) => ()` that applies $e^{i t A}$, then the representation of the Trotter–Suzuki expansion in terms of rearranging calling sequences becomes clear.
Concretely, given two operations `A : (Double, Qubit[]) => ()` and `B : (Double, Qubit[])`, we can define a new operation `AB(t)` by generating sequences of the form
```qsharp
A(time / Float(nSteps));
B(time / Float(nSteps));
A(time / Float(nSteps));
B(time / Float(nSteps));
// ...
```
At this point, we can now reason about the Trotter–Suzuki expansion *without reference to quantum mechanics at all*.
The expansion is effectively a very particular iteration pattern motivated by $\eqref{eq:trotter-suzuki-0}$.
This iteration pattern is implemented by <xref:microsoft.quantum.canon.decomposeintotimesteps>:

```qsharp
// TODO
```

## Putting it Together: Controlling Operations ##

Finally, the canon builds on the `Controlled` functor by providing additional ways to condition quantum operations.
It is common, especially in [quantum arithmetic](algorithms#arithmetic), to condition operations on computational basis states other than $\ket{0\cdots 0}$.
Using the control operations and functions introduced above, we can more general quantum conditions in a single statement.
Let's jump in to how <xref:microsoft.quantum.canon.controlledonbitstring> does it (sans type parameters), then we'll break down the pieces one by one.
The first thing we'll need to do is to define an operation which actually does the heavy lifting of implementing the control on arbitrary computational basis states.
We won't call this operation directly, however, and so we add `Impl` to the end of the name to indicate that it's an implementation of another construct elsewhere.
```qsharp
operation ControlledOnBitStringImpl(
        bits : Bool[],
        oracle: (Qubit[] => (): Adjoint, Controlled),
        controlRegister : Qubit[],
        targetRegister: Qubit[]
    ) : ()
```

Note that we take a string of bits, represented as a `Bool` array, that we use to specify the conditioning that we want to apply to the operation `oracle` that we are given.
Since this operation actually does the application directly, we also need to take the control and target registers, both represented here as `Qubit[]`.

Next, we note that controlling on the computational basis state $\ket{\vec{s}} = \ket{s\_0 s\_1 \dots s\_{n - 1}}$ for a bit string $\vec{s}$ can be realized by transforming $\ket{\vec{s}}$ into $\ket{0\cdots 0}$.
In particular, $\ket{\vec{s}} = X^{s\_0} \otimes X^{s\_1} \otimes \cdots \otimes X^{s\_{n - 1}} \ket{0\cdots 0}$.
Since $X^{\dagger} = X$, this implies that $\ket{0\dots 0} = X^{s\_0} \otimes X^{s\_1} \otimes \cdots \otimes X^{s\_{n - 1}} \ket{\vec{s}}$.
Thus, we can apply $P = X^{s\_0} \otimes X^{s\_1} \otimes \cdots \otimes X^{s\_{n - 1}}$, apply `(Controlled oracle)`, and transform back to $\vec{s}$.
This construction is precisely `With`, so we write the body of our new operation accordingly:

```qsharp
{
    body {
        WithCA(
            ApplyPauliFromBitString(PauliX, false, bits, _),
            (Controlled oracle)(_, targetRegister),
            controlRegister
        );
    }
```

Here, we have used @"microsoft.quantum.canon.applypaulifrombitstring" to apply $P$, partially applying over its target for use with `With`.
Note, however, that we need to transform the *control* register to our desired form, so we partially apply the inner operation `(Controlled oracle)` on the *target*.
This leaves `With` acting to bracket the control register with $P$, exactly as we desired.
We finish defining our operation by declaring that we support the usual functor applications:

```qsharp
    adjoint auto
    controlled auto
    adjoint controlled auto
}
```

At this point, we could be done, but it is somehow unsatisfying that our new operation does not "feel" like applying the `Controlled` functor.
Thus, we finish defining our new control flow concept by writing a function that takes the oracle to be controlled and that returns a new operation.
In this way, our new function looks and feels very much like `Controlled`, illustrating that we can easily define powerful new control flow constructs using Q# and the canon together:

```
function ControlledOnBitString(
        bits : Bool[],
        oracle: (Qubit[] => (): Adjoint, Controlled)
    ) : ((Qubit[], Qubit[]) => (): Adjoint, Controlled)
{
    return ControlledOnBitStringImpl(bits, oracle, _, _);
}
```

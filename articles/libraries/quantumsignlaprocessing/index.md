---
title: Quantum Signal Processing | Microsoft Docs 
description: Concept of quantum signal processing
author: Jeongwan Haah
uid: microsoft.quantum.libraries.quantumsignalprocessing.index
ms.author: jwhaah@microsoft.com 
ms.date: 9/20/2019
ms.topic: article
---

# Quantum Signal Processing

Given a linear operator $W$ on a complex vector space and a polynomial function $f(z) = \sum_k f_k z^k$ where $f_k \in \mathbb{C}$,
we can think of a linear operator 
$$
f(W) = \sum_k f_k W^k.
$$
A number of quantum algorithms can be thought of as implementing $f(W)$ using already implemented $W$ one or more times.
Since unitary operations are meant to be composed rather than superposed,
the expression $f(W) = \sum_k f_k W^k$ does not make much sense as it reads.
Quantum signal processing is a general technique to overcome this apparent mismatch.

## Eigenvalue transformation

Let us assume that $W$ is a unitary.
This is a natural assumption to proceed, since $W$ is thought to be an operator that is easily implemented.
Then, $W$ has a spectral decomposition
$$
W = \sum_k \lambda_k \ket{\psi_k}\bra{\psi_k}
$$
where each $\lambda_k$ is a complex number of modulus one.
An important feature of the transformation $W \mapsto f(W)$ is that it does not change the eigenvectors of $W$:
$$
f(W) = \sum_k f(\lambda_k) \ket{\psi_k}\bra{psi_k}.
$$
So, conceptually we aim to express and implement the scalar function $f$ on the eigenvalues.
Note that the eigenvalues of a unitary is on the unit circle in the complex plane,
so we regard that the function $f$ is defined only on the complex unit circle.

### Enlarging the space

A typical, well, actually the only way to access eigenvalues of a unitary in quantum computing 
is through an ancilla on which $W$ is controlled.
Imagine that we have a controlled unitary
$$
V = \ket{0}\bra{0} \otimes I + \ket{1}\bra{1} \otimes W,
$$
which is concretely implementable by, for example, replacing each elementary gate in $W$ by a controlled version.
In Q# this is conveniently done via [functor Controlled](xref:microsoft.quantum.language.type-model#functors).
If the control qubit was initialized in $\ket{+}$ and we applied $V$, and if we measure the control qubit to project it to $\ket{+}$,
then the overall action on the qubits on which $W$ acts would be
$$
(\bra{+} \otimes I) V (\ket{+} \otimes I) = \frac{1}{2} I + \frac{1}{2} W.
$$
This is a linear combination (superposition) of unitaries!
This exactly corresponds to a transformation function $f(z) = (1+z)/2$.
Similarly, the following corresponds to a transformation function $f(z) = (1+z^{-1})/2$
$$
(\bra{+} \otimes I) V^\dagger (\ket{+} \otimes I) = \frac{1}{2} I + \frac{1}{2} W^\dagger.
$$

### Unitary to (non)unitary

The above trick is easily generalized with multiple calls to $V$ or $V^\dagger$,
in between which we may insert some single qubit rotations $E_k$:
$$
f(W) =
\left(\bra{+} \otimes I\right)  E_0 V E_1 V^\dagger E_2 V E_3 V^\dagger E_4 \cdots E_{2n-1} V E_{2n} \left(\ket{+} \otimes I\right) .
$$ 
There are $2n+1$ interspersing single qubit unitaries $E_k$ and $2n$ calls to $V$ or $V^\dagger$.
The alternating appearance of $V$ and $V^\dagger$ is a special choice.
(This is due to a technical convenience that we do not explain here, but interested readers might want to see this [paper](https://arxiv.org/abs/1806.10236).
One may consider more general sequences where $V$ and $V^\dagger$ are not necessarily balanced.)

At this point, it is somewhat mysterious how we measure $\ket{+}$ on the ancilla qubit.
As a matter of fact, we cannot and do not ensure we always measure $\ket{+}$.
Especially, if $f(W)$ is not a unitary, there is always a nonzero probability that we measure $\ket{-}$ 
at the end of the sequence, and that is unavoidable.
Thus, the implementation of $f(W)$ is probabilistic.
However, this should be regarded as a feature rather than a bug.
By giving up executions with certainty, we acquire flexibility in algorithm design
that we may use nonunitary transformations.
This comes with a price; a nonunitary transformation may fail and we may have to try many times.
On the other hand, if $f(W)$ is a unitary, that is, if the function $f(e^{i\theta})$ is valued in the complex unit circle,
then we know that the ancilla will be in the $\ket{+}$ state (apart from an unimportant phase factor) in the end,
and we may omit the measurement on the ancilla.

## Application scope

It is nontrivial when and how $f(W)$ can be expressed as in the sequence above.
A useful mathematical fact is that the form of the sequence above covers a very broad class of transformation functions $f$.
Namely, the sequence above can express any complex valued function $f$ satisfying all of the following conditions.

1. The function $f(z = e^{i\theta}) = \sum_{k=-n}^n f_k z^k$ is a Laurent polynomial in $z$.
2. For any real $\theta$, the function value $f(e^{i\theta})$ has modulus at most 1.
3. The real part $\theta \mapsto \mathrm{Re} f(e^{i\theta})$ is an even or odd function of $\theta$.
4. The imaginary part $\theta \mapsto \mathrm{Im} f(e^{i\theta})$ is an even or odd function of $\theta$.


Note that this is an existence or possibility statement.
It is a nontrivial computation to find the interspersing single qubit unitaries for a given transformation function $f$.
The QuantumSignalProcessing library provides such a computational functionality.
This computation is classical preprocessing for a quantum algorithm that requires $f(W)$ in the form of sequence above.

In most cases, the transformation function will not be expressed as a Laurent polynomial 
(equivalent to being trigonometric polynomial in the eigenphase).
In such a case, one has to find a Laurent polynomial approximation to the ultimate transformation function $f_\text{true}$.
The approximation can be found by Fourier expansion of $f_\text{true}$ and truncating high frequency terms.

## References


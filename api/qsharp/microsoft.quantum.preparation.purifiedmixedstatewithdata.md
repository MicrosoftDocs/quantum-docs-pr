---
uid: Microsoft.Quantum.Preparation.PurifiedMixedStateWithData
title: PurifiedMixedStateWithData function
ms.date: 2/5/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: PurifiedMixedStateWithData
qsharp.summary: "Returns an operation that prepares a a purification of a given mixed\rstate, entangled with a register representing a given collection of data.\rA \"purified mixed state with data\" refers to a state of the form Σᵢ √\U0001D45Dᵢ |\U0001D456⟩ |\U0001D465ᵢ⟩ |garbageᵢ⟩,\rwhere each \U0001D465ᵢ is a bitstring encoding additional data associated with the register |\U0001D456⟩.\r\rSee https://arxiv.org/pdf/1805.03662.pdf?page=15 for further discussion."
---

# PurifiedMixedStateWithData function

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns an operation that prepares a a purification of a given mixedstate, entangled with a register representing a given collection of data.A "purified mixed state with data" refers to a state of the form Σᵢ √𝑝ᵢ |𝑖⟩ |𝑥ᵢ⟩ |garbageᵢ⟩,where each 𝑥ᵢ is a bitstring encoding additional data associated with the register |𝑖⟩.See https://arxiv.org/pdf/1805.03662.pdf?page=15 for further discussion.

```qsharp
function PurifiedMixedStateWithData (targetError : Double, coefficients : (Double, Bool[])[]) : Microsoft.Quantum.Preparation.MixedStatePreparation
```


## Description

Uses the Quantum ROM technique to represent a given density matrix,returning that representation as a state preparation operation.In particular, given a list of $N$ coefficients $\alpha_j$, and abitstring $\vec{x}_j$ associated with each coefficient, thisfunction returns an operation that uses the Quantum ROM technique toprepare an approximation$$\begin{align}\tilde\rho = \sum_{j = 0}^{N - 1} p_j \ket{j}\bra{j} \otimes \ket{\vec{x}_j}\bra{\vec{x}_j}\end{align}$$of the mixed state$$\begin{align}\rho = \sum_{j = 0}^{N-1}\ frac{|alpha_j|}{\sum_k |\alpha_k|} \ket{j}\bra{j} \otimes \ket{\vec{x}_j}\bra{\vec{x}_j},\end{align}$$where each $p_j$ is an approximation to the given coefficient $\alpha_j$such that$$\begin{align}\left| p_j - \frac{ |\alpha_j| }{ \sum_k |\alpha_k| } \le \frac{\epsilon}{N}\end{align}$$for each $j$.When passed an index register and a register of garbage qubits,initially in the state $\ket{0} \ket{00\cdots 0}, the returned operationprepares both registers into the purification of $\tilde \rho$,$$\begin{align}\sum_{j=0}^{N-1} \sqrt{p_j} \ket{j} \ket{\vec{x}_j} \ket{\text{garbage}_j},\end{align}$$such that resetting and deallocating the garbage register enacts thedesired preparation to within the target error $\epsilon$.

## Input

### targetError : [Double](xref:microsoft.quantum.lang-ref.double)

The target error $\epsilon$.


### coefficients : ([Double](xref:microsoft.quantum.lang-ref.double),[Bool](xref:microsoft.quantum.lang-ref.bool)[])[]

Array of $N$ coefficients specifying the probability of basis states,along with the bitstring $\vec{x}_j$ associated with each coefficient.Negative numbers $-\alpha_j$ will be treated as positive $|\alpha_j|$.



## Output : [MixedStatePreparation](xref:Microsoft.Quantum.Preparation.MixedStatePreparation)

An operation that prepares $\tilde \rho$ as a purification onto a jointindex and garbage register.

## Remarks

The coefficients provided to this operation are normalized following the1-norm, such that the coefficients are always considered to describe avalid categorical probability distribution.

## References

- Encoding Electronic Spectra in Quantum Circuits with Linear T Complexity  Ryan Babbush, Craig Gidney, Dominic W. Berry, Nathan Wiebe, Jarrod McClean, Alexandru Paler, Austin Fowler, Hartmut Neven  https://arxiv.org/abs/1805.03662

## See Also

- [Microsoft.Quantum.Preparation.PurifiedMixedState](xref:Microsoft.Quantum.Preparation.PurifiedMixedState)
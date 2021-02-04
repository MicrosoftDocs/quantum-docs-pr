---
uid: Microsoft.Quantum.Preparation.PurifiedMixedState
title: PurifiedMixedState function
ms.date: 2/4/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: PurifiedMixedState
qsharp.summary: "Returns an operation that prepares a a purification of a given mixed state.\rA \"purified mixed state\" refers to states of the form |ψ⟩ = Σᵢ √\U0001D45Dᵢ |\U0001D456⟩ |garbageᵢ⟩ specified by a vector of\rcoefficients {\U0001D45Dᵢ}. States of this form can be reduced to mixed states ρ ≔ \U0001D45Dᵢ |\U0001D456⟩⟨\U0001D456| by tracing over the \"garbage\"\rregister (that is, a mixed state that is diagonal in the computational basis).\r\rSee https://arxiv.org/pdf/1805.03662.pdf?page=15 for further discussion."
---

# PurifiedMixedState function

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns an operation that prepares a a purification of a given mixed state.A "purified mixed state" refers to states of the form |ψ⟩ = Σᵢ √𝑝ᵢ |𝑖⟩ |garbageᵢ⟩ specified by a vector ofcoefficients {𝑝ᵢ}. States of this form can be reduced to mixed states ρ ≔ 𝑝ᵢ |𝑖⟩⟨𝑖| by tracing over the "garbage"register (that is, a mixed state that is diagonal in the computational basis).See https://arxiv.org/pdf/1805.03662.pdf?page=15 for further discussion.

```qsharp
function PurifiedMixedState (targetError : Double, coefficients : Double[]) : Microsoft.Quantum.Preparation.MixedStatePreparation
```


## Description

Uses the Quantum ROM technique to represent a given density matrix,returning that representation as a state preparation operation.In particular, given a list of $N$ coefficients $\alpha_j$, thisfunction returns an operation that uses the Quantum ROM technique toprepare an approximation$$\begin{align}\tilde\rho = \sum_{j = 0}^{N - 1} p_j \ket{j}\bra{j}\end{align}$$of the mixed state$$\begin{align}\rho = \sum_{j = 0}^{N-1}\ frac{|alpha_j|}{\sum_k |\alpha_k|} \ket{j}\bra{j},\end{align}$$where each $p_j$ is an approximation to the given coefficient $\alpha_j$such that$$\begin{align}\left| p_j - \frac{ |\alpha_j| }{ \sum_k |\alpha_k| } \le \frac{\epsilon}{N}\end{align}$$for each $j$.When passed an index register and a register of garbage qubits,initially in the state $\ket{0} \ket{00\cdots 0}, the returned operationprepares both registers into the purification of $\tilde \rho$,$$\begin{align}\sum_{j=0}^{N-1} \sqrt{p_j} \ket{j}\ket{\text{garbage}_j},\end{align}$$such that resetting and deallocating the garbage register enacts thedesired preparation to within the target error $\epsilon$.

## Input

### targetError : [Double](xref:microsoft.quantum.lang-ref.double)

The target error $\epsilon$.


### coefficients : [Double](xref:microsoft.quantum.lang-ref.double)[]

Array of $N$ coefficients specifying the probability of basis states.Negative numbers $-\alpha_j$ will be treated as positive $|\alpha_j|$.



## Output : [MixedStatePreparation](xref:Microsoft.Quantum.Preparation.MixedStatePreparation)

An operation that prepares $\tilde \rho$ as a purification onto a jointindex and garbage register.

## Example

The following code snippet prepares an purification of the $3$-qubit state$\rho=\sum_{j=0}^{4}\frac{|alpha_j|}{\sum_k |\alpha_k|}\ket{j}\bra{j}$, where$\vec\alpha=(1.0, 2.0, 3.0, 4.0, 5.0)$, and the target error is$10^{-3}$:```qsharplet coefficients = [1.0, 2.0, 3.0, 4.0, 5.0];let targetError = 1e-3;let purifiedState = PurifiedMixedState(targetError, coefficients);using (indexRegister = Qubit[purifiedState::Requirements::NIndexQubits]) {    using (garbageRegister = Qubit[purifiedState::Requirements::NGarbageQubits]) {        purifiedState::Prepare(LittleEndian(indexRegister), new Qubit[0], garbageRegister);    }}```

## Remarks

The coefficients provided to this operation are normalized following the1-norm, such that the coefficients are always considered to describe avalid categorical probability distribution.

## References

- Encoding Electronic Spectra in Quantum Circuits with Linear T Complexity  Ryan Babbush, Craig Gidney, Dominic W. Berry, Nathan Wiebe, Jarrod McClean, Alexandru Paler, Austin Fowler, Hartmut Neven  https://arxiv.org/abs/1805.03662

## See Also

- [Microsoft.Quantum.Preparation.PurifiedMixedStateWithData](xref:Microsoft.Quantum.Preparation.PurifiedMixedStateWithData)
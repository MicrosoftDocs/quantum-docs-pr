---
uid: Microsoft.Quantum.AmplitudeAmplification.ApplyObliviousAmplitudeAmplification
title: ApplyObliviousAmplitudeAmplification operation
ms.date: 12/21/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.AmplitudeAmplification
qsharp.name: ApplyObliviousAmplitudeAmplification
qsharp.summary: Oblivious amplitude amplification by specifying partial reflections.
---

# ApplyObliviousAmplitudeAmplification operation

Namespace: [Microsoft.Quantum.AmplitudeAmplification](xref:Microsoft.Quantum.AmplitudeAmplification)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Oblivious amplitude amplification by specifying partial reflections.

```qsharp
operation ApplyObliviousAmplitudeAmplification (phases : Microsoft.Quantum.AmplitudeAmplification.ReflectionPhases, startStateReflection : Microsoft.Quantum.Oracles.ReflectionOracle, targetStateReflection : Microsoft.Quantum.Oracles.ReflectionOracle, signalOracle : Microsoft.Quantum.Oracles.ObliviousOracle, auxiliaryRegister : Qubit[], systemRegister : Qubit[]) : Unit is Adj + Ctl
```


## Input

### phases : [ReflectionPhases](xref:Microsoft.Quantum.AmplitudeAmplification.ReflectionPhases)

Phases of partial reflections


### startStateReflection : [ReflectionOracle](xref:Microsoft.Quantum.Oracles.ReflectionOracle)

Reflection operator about start state of auxiliary register


### targetStateReflection : [ReflectionOracle](xref:Microsoft.Quantum.Oracles.ReflectionOracle)

Reflection operator about target state of auxiliary register


### signalOracle : [ObliviousOracle](xref:Microsoft.Quantum.Oracles.ObliviousOracle)

Unitary oracle $O$ of type `ObliviousOracle` that acts jointly on theauxiliary and system registers.


### auxiliaryRegister : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Auxiliary register


### systemRegister : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

System register



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Given a particular auxiliary start state $\ket{\text{start}}\_a$, aparticular auxiliary target state $\ket{\text{target}}\_a$, and anysystem state $\ket{\psi}\_s$, suppose that\begin{align}O\ket{\text{start}}\_a\ket{\psi}\_s= \lambda\ket{\text{target}}\_a U \ket{\psi}\_s + \sqrt{1-|\lambda|^2}\ket{\text{target}^\perp}\_a\cdots\end{align}for some unitary $U$.By a sequence of reflections about the start and target states on theauxiliary register interleaved by applications of `signalOracle` and itsadjoint, the success probability of applying U may be altered.In most cases, `auxiliaryRegister` is initialized in the state $\ket{\text{start}}\_a$.

## References

See- [ *D.W. Berry, A.M. Childs, R. Cleve, R. Kothari, R.D. Somma* ](https://arxiv.org/abs/1312.1414)  for the standard version.  See- [ *G.H. Low, I.L. Chuang* ](https://arxiv.org/abs/1610.06546)  for a generalization to partial reflections.
---
uid: Microsoft.Quantum.ErrorCorrection.KnillDistill
title: KnillDistill operation
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: KnillDistill
qsharp.summary: Implements the Knill magic state distillation algorithm.
---

# KnillDistill operation

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Implements the Knill magic state distillation algorithm.

```qsharp
operation KnillDistill (roughMagic : Qubit[]) : Bool
```


## Description

Given 15 approximate copies of a magic state$$\begin{align}\cos\frac{\pi}{8} \ket{0} + \sin \frac{\pi}{8} \ket{1}\end{align},$$yields one higher-quality copy.

## Input

### roughMagic : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A register of fifteen qubits containing approximate copiesof a magic state. Following application of this distillationprocedure, `roughMagic[0]` will contain one higher-qualitycopy, and the rest of the register will be reset to the$\ket{00\cdots 0}$ state.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

If `true`, then the procedure succeeded and the higher-qualitycopy should be accepted. If `false`, the procedure failed, andthe state of the register should be considered undefined.

## Remarks

We follow the algorithm of Knill.However, the present implementation is far from being optimal,as it uses too many qubits.The magic states are injected in this routine,in which case there are better protocols.

## References

- [Knill](https://arxiv.org/abs/quant-ph/0402171)
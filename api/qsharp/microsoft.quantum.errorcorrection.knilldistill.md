---
uid: Microsoft.Quantum.ErrorCorrection.KnillDistill
title: KnillDistill operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: KnillDistill
qsharp.summary: Implements the Knill magic state distillation algorithm.
---

# KnillDistill operation

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [](https://nuget.org/packages/)


Implements the Knill magic state distillation algorithm.

```qsharp
operation KnillDistill (roughMagic : Qubit[]) : Bool
```


## Description

Given 15 approximate copies of a magic state

## Input

### roughMagic : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A register of fifteen qubits containing approximate copies



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

If `true`, then the procedure succeeded and the higher-quality

## Remarks

We follow the algorithm of Knill.

## References

- [Knill](https://arxiv.org/abs/quant-ph/0402171)
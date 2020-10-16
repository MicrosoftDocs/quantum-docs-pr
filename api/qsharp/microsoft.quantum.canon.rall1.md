---
uid: Microsoft.Quantum.Canon.RAll1
title: RAll1 operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: RAll1
qsharp.summary: >-
  Performs a phase shift operation.

  $R=\boldone-(1-e^{i \phi})\ket{1\cdots 1}\bra{1\cdots 1}$.
---

# RAll1 operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Performs a phase shift operation.$R=\boldone-(1-e^{i \phi})\ket{1\cdots 1}\bra{1\cdots 1}$.

```Q#
RAll1 (phase : Double, qubits : Qubit[]) : Unit
```


## Input

### phase : Double

The phase $\phi$ applied to state $\ket{1\cdots 1}\bra{1\cdots 1}$.


### qubits : Qubit[]

The register whose state is to be rotated by $R$.


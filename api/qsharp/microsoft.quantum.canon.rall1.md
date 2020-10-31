---
uid: Microsoft.Quantum.Canon.RAll1
title: RAll1 operation
ms.date: 10/31/2020 12:00:00 AM
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

```qsharp
operation RAll1 (phase : Double, qubits : Qubit[]) : Unit
```


## Input

### phase : [Double](xref:microsoft.quantum.lang-ref.double)

The phase $\phi$ applied to state $\ket{1\cdots 1}\bra{1\cdots 1}$.


### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

The register whose state is to be rotated by $R$.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


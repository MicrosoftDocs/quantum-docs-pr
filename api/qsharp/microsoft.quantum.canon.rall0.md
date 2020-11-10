---
uid: Microsoft.Quantum.Canon.RAll0
title: RAll0 operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: RAll0
qsharp.summary: >-
  Performs a phase shift operation.

  $R=\boldone-(1-e^{i \phi})\ket{0\cdots 0}\bra{0\cdots 0}$.
---

# RAll0 operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Performs a phase shift operation.$R=\boldone-(1-e^{i \phi})\ket{0\cdots 0}\bra{0\cdots 0}$.

```qsharp
operation RAll0 (phase : Double, qubits : Qubit[]) : Unit
```


## Input

### phase : [Double](xref:microsoft.quantum.lang-ref.double)

The phase $\phi$ applied to state $\ket{0\cdots 0}\bra{0\cdots 0}$.


### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

The register whose state is to be rotated by $R$.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Canon.RAll1](xref:Microsoft.Quantum.Canon.RAll1)
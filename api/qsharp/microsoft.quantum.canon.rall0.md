---
uid: Microsoft.Quantum.Canon.RAll0
title: RAll0 operation
ms.date: 11/25/2020 12:00:00 AM
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Performs a phase shift operation.$R=\boldone-(1-e^{i \phi})\ket{0\cdots 0}\bra{0\cdots 0}$.

```qsharp
operation RAll0 (phase : Double, qubits : Qubit[]) : Unit is Adj + Ctl
```


## Input

### phase : [Double](xref:microsoft.quantum.user-guide.language.types)

The phase $\phi$ applied to state $\ket{0\cdots 0}\bra{0\cdots 0}$.


### qubits : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[]

The register whose state is to be rotated by $R$.



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## See Also

- [Microsoft.Quantum.Canon.RAll1](xref:Microsoft.Quantum.Canon.RAll1)
---
uid: Microsoft.Quantum.Characterization.MeasureIdentity
title: MeasureIdentity operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Characterization
qsharp.name: MeasureIdentity
qsharp.summary: >-
  Measures the identity operator on a register
  of qubits.
---

# MeasureIdentity operation

Namespace: [Microsoft.Quantum.Characterization](xref:Microsoft.Quantum.Characterization)

Package: [](https://nuget.org/packages/)


Measures the identity operator on a register

```qsharp
operation MeasureIdentity (register : Qubit[]) : Result
```


## Input

### register : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

The register to be measured.



## Output : __invalid<Result>__

The result value `Zero`.

## Remarks

Since $\boldone$ has only the eigenvalue $1$, and does not
---
uid: Microsoft.Quantum.Measurement.MeasureWithScratch
title: MeasureWithScratch operation
ms.date: 1/29/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Measurement
qsharp.name: MeasureWithScratch
qsharp.summary: >-
  Measures the given Pauli operator using an explicit scratch
  qubit to perform the measurement.
---

# MeasureWithScratch operation

Namespace: [Microsoft.Quantum.Measurement](xref:Microsoft.Quantum.Measurement)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Measures the given Pauli operator using an explicit scratchqubit to perform the measurement.

```qsharp
operation MeasureWithScratch (pauli : Pauli[], target : Qubit[]) : Result
```


## Input

### pauli : [Pauli](xref:microsoft.quantum.lang-ref.pauli)[]

A multi-qubit Pauli operator specified as an array ofsingle-qubit Pauli operators.


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubit register to be measured.



## Output : __invalid<Result>__

The result of measuring the given Pauli operator onthe `target` register.
---
uid: Microsoft.Quantum.Chemistry.JordanWigner.VQE.MeasurementOperators
title: MeasurementOperators function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner.VQE
qsharp.name: MeasurementOperators
qsharp.summary: Computes all the measurement operators required to compute the expectation of a Jordan-Wigner term.
---

# MeasurementOperators function

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner.VQE](xref:Microsoft.Quantum.Chemistry.JordanWigner.VQE)

Package: [](https://nuget.org/packages/)


Computes all the measurement operators required to compute the expectation of a Jordan-Wigner term.

```Q#
MeasurementOperators (nQubits : Int, indices : Int[], termType : Int) : Pauli[][]
```


## Input

### nQubits : Int

The number of qubits required to simulate the molecular system.


### indices : Int[]

An array containing the indices of the qubit each Pauli operator is applied to.


### termType : Int

The type of the Jordan-Wigner term.



## Output

An array of measurement operators (each being an array of Pauli).
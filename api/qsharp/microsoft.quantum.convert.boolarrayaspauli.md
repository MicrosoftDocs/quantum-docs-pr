---
uid: Microsoft.Quantum.Convert.BoolArrayAsPauli
title: BoolArrayAsPauli function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Convert
qsharp.name: BoolArrayAsPauli
qsharp.summary: >-
  Given a bit string, returns a multi-qubit Pauli operator
  represented as an array of single-qubit Pauli operators.
---

# BoolArrayAsPauli function

Namespace: [Microsoft.Quantum.Convert](xref:Microsoft.Quantum.Convert)

Package: [](https://nuget.org/packages/)


Given a bit string, returns a multi-qubit Pauli operatorrepresented as an array of single-qubit Pauli operators.

```Q#
BoolArrayAsPauli (pauli : Pauli, bitApply : Bool, bits : Bool[]) : Pauli[]
```


## Input

### pauli : Pauli

Pauli operator to apply to qubits where `bitsApply == bits[idx]`.


### bitApply : Bool

apply Pauli if bit is this value.


### bits : Bool[]

Boolean array.


### qubits

Quantum register to which a Pauli operator is to be applied.



## Remarks

The Boolean array and the quantum register must be of equal length.
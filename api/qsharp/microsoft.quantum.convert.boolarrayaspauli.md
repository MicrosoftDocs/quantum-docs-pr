---
uid: Microsoft.Quantum.Convert.BoolArrayAsPauli
title: BoolArrayAsPauli function
ms.date: 11/13/2020 12:00:00 AM
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given a bit string, returns a multi-qubit Pauli operatorrepresented as an array of single-qubit Pauli operators.

```qsharp
function BoolArrayAsPauli (pauli : Pauli, bitApply : Bool, bits : Bool[]) : Pauli[]
```


## Input

### pauli : [Pauli](xref:microsoft.quantum.lang-ref.pauli)

Pauli operator to apply to qubits where `bitsApply == bits[idx]`.


### bitApply : [Bool](xref:microsoft.quantum.lang-ref.bool)

apply Pauli if bit is this value.


### bits : [Bool](xref:microsoft.quantum.lang-ref.bool)[]

Boolean array.



## Output : [Pauli](xref:microsoft.quantum.lang-ref.pauli)[]



## Remarks

The Boolean array and the quantum register must be of equal length.
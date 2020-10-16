---
uid: Microsoft.Quantum.MachineLearning.ControlledRotation
title: ControlledRotation user defined type
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: ControlledRotation
qsharp.summary: >-
  Describes a controlled rotation in terms of its target and control
  indices, rotation axis, and index into a model parameter vector.
---

# ControlledRotation user defined type

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [](https://nuget.org/packages/)


Describes a controlled rotation in terms of its target and controlindices, rotation axis, and index into a model parameter vector.

```Q#

newtype ControlledRotation = ((TargetIndex : Int, ControlIndices : Int[]), Axis : Pauli, ParameterIndex : Int);
```



## Named Items

### TargetIndex : Int

Index of the target qubit for this controlled rotation.


### ControlIndices : Int[]

An array of the control qubit indices for this rotation.


### Axis : Pauli

The axis for this rotation.


### ParameterIndex : Int

An index into a model parameter vector describing the anglefor this rotation.



## Remarks

An uncontrolled rotation can be represented by setting `ControlIndices`to an empty array of indexes, `new Int[0]`.
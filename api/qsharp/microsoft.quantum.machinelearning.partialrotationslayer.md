---
uid: Microsoft.Quantum.MachineLearning.PartialRotationsLayer
title: PartialRotationsLayer function
ms.date: 12/15/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: PartialRotationsLayer
qsharp.summary: >-
  Returns an array of single-qubit rotations along a given
  axis, parameterized by distinct model parameters.
---

# PartialRotationsLayer function

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


Returns an array of single-qubit rotations along a givenaxis, parameterized by distinct model parameters.

```qsharp
function PartialRotationsLayer (idxsQubits : Int[], axis : Pauli) : Microsoft.Quantum.MachineLearning.ControlledRotation[]
```


## Input

### idxsQubits : [Int](xref:microsoft.quantum.lang-ref.int)[]

Indices for the qubits to be used as the targets for each rotation.


### axis : [Pauli](xref:microsoft.quantum.lang-ref.pauli)

The rotation axis for each rotation in the given layer.



## Output : [ControlledRotation](xref:Microsoft.Quantum.MachineLearning.ControlledRotation)[]

An array of controlled rotations about the given axis, one on each of`nQubits` qubits.
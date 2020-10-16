---
uid: Microsoft.Quantum.MachineLearning.CyclicEntanglingLayer
title: CyclicEntanglingLayer function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: CyclicEntanglingLayer
qsharp.summary: >-
  Returns an array of singly controlled rotations along a given axis,
  arranged cyclically across a register of qubits, and parameterized by
  distinct model parameters.
---

# CyclicEntanglingLayer function

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [](https://nuget.org/packages/)


Returns an array of singly controlled rotations along a given axis,arranged cyclically across a register of qubits, and parameterized bydistinct model parameters.

```Q#
CyclicEntanglingLayer (nQubits : Int, axis : Pauli, stride : Int) : Microsoft.Quantum.MachineLearning.ControlledRotation[]
```


## Input

### nQubits : Int

The number of qubits acted on by the given layer.


### axis : Pauli

The rotation axis for each rotation in the given layer.


### stride : Int

The separation between the target and control indices for each rotation.



## Output

An array of two-qubit controlled rotations laid out cyclically acrossa register of `nQubits` qubits.
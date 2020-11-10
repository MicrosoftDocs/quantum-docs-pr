---
uid: Microsoft.Quantum.Canon.WeightOnePaulis
title: WeightOnePaulis function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: WeightOnePaulis
qsharp.summary: >-
  Returns an array of all weight-1 Pauli operators
  on a given number of qubits.
---

# WeightOnePaulis function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Returns an array of all weight-1 Pauli operatorson a given number of qubits.

```qsharp
function WeightOnePaulis (nQubits : Int) : Pauli[][]
```


## Input

### nQubits : [Int](xref:microsoft.quantum.lang-ref.int)

The number of qubits on which the returned Pauli operatorsare defined.



## Output : [Pauli](xref:microsoft.quantum.lang-ref.pauli)[][]

An array of multi-qubit Pauli operators, each of which isrepresented as an array with length `nQubits`.
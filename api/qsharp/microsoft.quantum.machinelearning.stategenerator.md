---
uid: Microsoft.Quantum.MachineLearning.StateGenerator
title: StateGenerator user defined type
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: StateGenerator
qsharp.summary: >-
  Describes an operation that prepares a given input to a sequential
  classifier.
---

# StateGenerator user defined type

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [](https://nuget.org/packages/)


Describes an operation that prepares a given input to a sequentialclassifier.

```Q#

newtype StateGenerator = (NQubits : Int, Prepare : (Microsoft.Quantum.Arithmetic.LittleEndian => Unit is Adj + Ctl));
```



## Named Items

### NQubits : Int

The number of qubits on which the encoded input is defined.


### Prepare : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian) => Unit Adj + Ctl

An operation which prepares the encoded input on a little-endianregister of `NQubits` qubits.


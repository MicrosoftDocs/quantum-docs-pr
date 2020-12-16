---
uid: Microsoft.Quantum.MachineLearning.StateGenerator
title: StateGenerator user defined type
ms.date: 12/15/2020 12:00:00 AM
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

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


Describes an operation that prepares a given input to a sequentialclassifier.

```qsharp

newtype StateGenerator = (NQubits : Int, Prepare : (Microsoft.Quantum.Arithmetic.LittleEndian => Unit is Adj + Ctl));
```



## Named Items

### NQubits : [Int](xref:microsoft.quantum.lang-ref.int)

The number of qubits on which the encoded input is defined.
### Prepare : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

An operation which prepares the encoded input on a little-endianregister of `NQubits` qubits.
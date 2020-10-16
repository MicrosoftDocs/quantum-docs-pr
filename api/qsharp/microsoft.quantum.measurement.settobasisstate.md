---
uid: Microsoft.Quantum.Measurement.SetToBasisState
title: SetToBasisState operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Measurement
qsharp.name: SetToBasisState
qsharp.summary: >-
  Sets a qubit to a given computational basis state by measuring the
  qubit and applying a bit flip if needed.
---

# SetToBasisState operation

Namespace: [Microsoft.Quantum.Measurement](xref:Microsoft.Quantum.Measurement)

Package: [](https://nuget.org/packages/)


Sets a qubit to a given computational basis state by measuring thequbit and applying a bit flip if needed.

```Q#
SetToBasisState (desired : Result, target : Qubit) : Unit
```


## Input

### desired : __invalid<Result>__

The basis state that the qubit should be set to.


### target : Qubit

The qubit whose state is to be set.



## Remarks

As an invariant of this operation, calling `M(q)` immediatelyafter `SetToBasisState(result, q)` will return `result`.
---
uid: Microsoft.Quantum.Intrinsic.Reset
title: Reset operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: Reset
qsharp.summary: >-
  Given a single qubit, measures it and ensures it is in the |0⟩ state
  such that it can be safely released.
---

# Reset operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [](https://nuget.org/packages/)


Given a single qubit, measures it and ensures it is in the |0⟩ statesuch that it can be safely released.

```Q#
Reset (target : Qubit) : Unit
```


## Input

### qubit

The qubit whose state is to be reset to $\ket{0}$.


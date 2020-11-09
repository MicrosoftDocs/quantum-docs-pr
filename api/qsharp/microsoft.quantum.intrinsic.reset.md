---
uid: Microsoft.Quantum.Intrinsic.Reset
title: Reset operation
ms.date: 11/9/2020 12:00:00 AM
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

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Given a single qubit, measures it and ensures it is in the |0⟩ statesuch that it can be safely released.

```qsharp
operation Reset (target : Qubit) : Unit
```


## Input

### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

The qubit whose state is to be reset to $\ket{0}$.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


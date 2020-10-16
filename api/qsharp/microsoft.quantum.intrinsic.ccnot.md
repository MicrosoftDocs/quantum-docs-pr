---
uid: Microsoft.Quantum.Intrinsic.CCNOT
title: CCNOT operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: CCNOT
qsharp.summary: Applies the doubly controlled–NOT (CCNOT) gate to three qubits.
---

# CCNOT operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [](https://nuget.org/packages/)


Applies the doubly controlled–NOT (CCNOT) gate to three qubits.

```Q#
CCNOT (control1 : Qubit, control2 : Qubit, target : Qubit) : Unit
```


## Input

### control1 : Qubit

First control qubit for the CCNOT gate.


### control2 : Qubit

Second control qubit for the CCNOT gate.


### target : Qubit

Target qubit for the CCNOT gate.



## Remarks

Equivalent to:```qsharpControlled X([control1, control2], target);```
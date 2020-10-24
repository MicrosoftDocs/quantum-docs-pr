---
uid: Microsoft.Quantum.Chemistry.IsNotZero
title: IsNotZero function
ms.date: 10/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Chemistry
qsharp.name: IsNotZero
qsharp.summary: Checks whether a `Double` number is not approximately zero.
---

# IsNotZero function

Namespace: [Microsoft.Quantum.Chemistry](xref:Microsoft.Quantum.Chemistry)

Package: [](https://nuget.org/packages/)


Checks whether a `Double` number is not approximately zero.

```qsharp
function IsNotZero (number : Double) : Bool
```


## Input

### number : [Double](xref:microsoft.quantum.lang-ref.double)

Number to be checked



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

Returns true if `number` has an absolute value greater than `1e-15`.
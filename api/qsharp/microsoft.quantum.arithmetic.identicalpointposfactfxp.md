---
uid: Microsoft.Quantum.Arithmetic.IdenticalPointPosFactFxP
title: IdenticalPointPosFactFxP function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: IdenticalPointPosFactFxP
qsharp.summary: >-
  Assert that all fixed-point numbers in the provided array
  have identical point positions when counting from the least-
  significant bit. I.e., number of bits minus point position must
  be constant for all fixed-point numbers in the array.
---

# IdenticalPointPosFactFxP function

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Assert that all fixed-point numbers in the provided arrayhave identical point positions when counting from the least-significant bit. I.e., number of bits minus point position mustbe constant for all fixed-point numbers in the array.

```qsharp
function IdenticalPointPosFactFxP (fixedPoints : Microsoft.Quantum.Arithmetic.FixedPoint[]) : Unit
```


## Input

### fixedPoints : [FixedPoint](xref:Microsoft.Quantum.Arithmetic.FixedPoint)[]

Array of quantum fixed-point numbers that will be checked forcompatibility (using assertions).



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


---
uid: Microsoft.Quantum.Arithmetic.GreaterThan
title: GreaterThan operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: GreaterThan
qsharp.summary: >-
  Applies a greater-than comparison between two integers encoded into
  qubit registers, flipping a target qubit based on the result of the
  comparison.
---

# GreaterThan operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Applies a greater-than comparison between two integers encoded into

```qsharp
operation GreaterThan (xs : Microsoft.Quantum.Arithmetic.LittleEndian, ys : Microsoft.Quantum.Arithmetic.LittleEndian, result : Qubit) : Unit
```


## Description

Carries out a strictly greater than comparison of two integers $x$ and $y$, encoded

## Input

### xs : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

LittleEndian qubit register encoding the first integer $x$.


### ys : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

LittleEndian qubit register encoding the second integer $y$.


### result : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Single qubit that will be flipped if $x > y$.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Uses the trick that $x - y = (x'+y)'$, where ' denotes the one's complement.

## References

- Steven A. Cuccaro, Thomas G. Draper, Samuel A. Kutin, David
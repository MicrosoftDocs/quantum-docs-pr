---
uid: Microsoft.Quantum.Logical.LessThanI
title: LessThanI function
ms.date: 1/30/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: LessThanI
qsharp.summary: Returns true if and only if a number is less than another number.
---

# LessThanI function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns true if and only if a number is less than another number.

```qsharp
function LessThanI (a : Int, b : Int) : Bool
```


## Input

### a : [Int](xref:microsoft.quantum.lang-ref.int)

The first value to be compared.


### b : [Int](xref:microsoft.quantum.lang-ref.int)

The second value to be compared.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

`true` if and only if `a` is strictly less than `b`.

## Remarks

The following are equivalent:```qsharplet cond = a < b;let cond = LessThanI(a, b);```
---
uid: Microsoft.Quantum.Logical.GreaterThanOrEqualL
title: GreaterThanOrEqualL function
ms.date: 2/14/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: GreaterThanOrEqualL
qsharp.summary: >-
  Returns true if and only if a number is greater than or equal to another
  number.
---

# GreaterThanOrEqualL function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns true if and only if a number is greater than or equal to anothernumber.

```qsharp
function GreaterThanOrEqualL (a : BigInt, b : BigInt) : Bool
```


## Input

### a : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The first value to be compared.


### b : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The second value to be compared.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

`true` if and only if `a` is greater than or is equal to `b`.

## Remarks

The following are equivalent:```qsharplet cond = a >= b;let cond = GreaterThanOrEqualL(a, b);```
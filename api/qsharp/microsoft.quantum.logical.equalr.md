---
uid: Microsoft.Quantum.Logical.EqualR
title: EqualR function
ms.date: 1/29/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: EqualR
qsharp.summary: Returns true if and only if two inputs are equal.
---

# EqualR function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns true if and only if two inputs are equal.

```qsharp
function EqualR (a : Result, b : Result) : Bool
```


## Input

### a : __invalid<Result>__

The first value to be compared.


### b : __invalid<Result>__

The second value to be compared.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

`true` if and only if `a` is equal to `b`.

## Remarks

The following are equivalent:```qsharplet cond = a == b;let cond = EqualR(a, b);```
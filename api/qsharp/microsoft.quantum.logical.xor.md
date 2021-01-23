---
uid: Microsoft.Quantum.Logical.Xor
title: Xor function
ms.date: 1/23/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: Xor
qsharp.summary: Returns the Boolean exclusive disjunction of two values.
---

# Xor function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns the Boolean exclusive disjunction of two values.

```qsharp
function Xor (a : Bool, b : Bool) : Bool
```


## Input

### a : [Bool](xref:microsoft.quantum.lang-ref.bool)

The first value to be considered.


### b : [Bool](xref:microsoft.quantum.lang-ref.bool)

The second value to be considered.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

`true` if and only if exactly one of `a` and `b` is `true`.
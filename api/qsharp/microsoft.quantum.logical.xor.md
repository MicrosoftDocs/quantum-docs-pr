---
uid: Microsoft.Quantum.Logical.Xor
title: Xor function
ms.date: 11/25/2020 12:00:00 AM
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

### a : [Bool](xref:microsoft.quantum.user-guide.language.types)

The first value to be considered.


### b : [Bool](xref:microsoft.quantum.user-guide.language.types)

The second value to be considered.



## Output : [Bool](xref:microsoft.quantum.user-guide.language.types)

`true` if and only if exactly one of `a` and `b` is `true`.
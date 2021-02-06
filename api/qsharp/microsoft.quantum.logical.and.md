---
uid: Microsoft.Quantum.Logical.And
title: And function
ms.date: 2/6/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: And
qsharp.summary: Returns the Boolean conjunction of two values.
---

# And function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns the Boolean conjunction of two values.

```qsharp
function And (a : Bool, b : Bool) : Bool
```


## Input

### a : [Bool](xref:microsoft.quantum.lang-ref.bool)

The first value to be considered.


### b : [Bool](xref:microsoft.quantum.lang-ref.bool)

The second value to be considered.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

`true` if and only if `a` and `b` are both `true`.

## Remarks

Unlike the `and` operator, this function does not short-circuit, such thatboth inputs are fully evaluated.Up to short-circuiting behavior, the following are equivalent:```qsharplet x = a and b;let x = And(a, b);```
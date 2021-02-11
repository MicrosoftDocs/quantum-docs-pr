---
uid: Microsoft.Quantum.Math.MaxI
title: MaxI function
ms.date: 2/11/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: MaxI
qsharp.summary: Returns the larger of two specified numbers.
---

# MaxI function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Returns the larger of two specified numbers.

```qsharp
function MaxI (a : Int, b : Int) : Int
```


## Input

### a : [Int](xref:microsoft.quantum.lang-ref.int)

The first number to be compared.


### b : [Int](xref:microsoft.quantum.lang-ref.int)

The second number to be compared.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

The larger of `a` and `b`.

## Example

```qsharplet max = MaxD(314, 271);  // 314```

## See Also

- [Microsoft.Quantum.MaxD](xref:Microsoft.Quantum.MaxD)
- [Microsoft.Quantum.MaxL](xref:Microsoft.Quantum.MaxL)
---
uid: Microsoft.Quantum.Math.MaxD
title: MaxD function
ms.date: 2/16/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: MaxD
qsharp.summary: Returns the larger of two specified numbers.
---

# MaxD function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Returns the larger of two specified numbers.

```qsharp
function MaxD (a : Double, b : Double) : Double
```


## Input

### a : [Double](xref:microsoft.quantum.lang-ref.double)

The first number to be compared.


### b : [Double](xref:microsoft.quantum.lang-ref.double)

The second number to be compared.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)

The larger of `a` and `b`.

## Example

```qsharplet max = MaxD(3.14, 2.71);  // 3.14```

## See Also

- [Microsoft.Quantum.MaxI](xref:Microsoft.Quantum.MaxI)
- [Microsoft.Quantum.MaxL](xref:Microsoft.Quantum.MaxL)
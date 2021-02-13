---
uid: Microsoft.Quantum.Math.MinD
title: MinD function
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: MinD
qsharp.summary: Returns the smaller of two specified numbers.
---

# MinD function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Returns the smaller of two specified numbers.

```qsharp
function MinD (a : Double, b : Double) : Double
```


## Input

### a : [Double](xref:microsoft.quantum.lang-ref.double)

The first number to be compared.


### b : [Double](xref:microsoft.quantum.lang-ref.double)

The second number to be compared.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)

The smaller of `a` and `b`.

## Example

```qsharplet min = MinD(3.14, 2.71);  // 2.71```

## See Also

- [Microsoft.Quantum.MinI](xref:Microsoft.Quantum.MinI)
- [Microsoft.Quantum.MinL](xref:Microsoft.Quantum.MinL)
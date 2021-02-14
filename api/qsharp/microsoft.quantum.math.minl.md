---
uid: Microsoft.Quantum.Math.MinL
title: MinL function
ms.date: 2/14/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: MinL
qsharp.summary: Returns the smaller of two specified numbers.
---

# MinL function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Returns the smaller of two specified numbers.

```qsharp
function MinL (a : BigInt, b : BigInt) : BigInt
```


## Input

### a : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The first number to be compared.


### b : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The second number to be compared.



## Output : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The smaller of `a` and `b`.

## Example

```qsharplet min = MinD(314L, 271L);  // 271L```

## See Also

- [Microsoft.Quantum.MinD](xref:Microsoft.Quantum.MinD)
- [Microsoft.Quantum.MinI](xref:Microsoft.Quantum.MinI)
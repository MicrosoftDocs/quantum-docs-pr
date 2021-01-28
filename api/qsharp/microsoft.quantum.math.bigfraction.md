---
uid: Microsoft.Quantum.Math.BigFraction
title: BigFraction user defined type
ms.date: 1/27/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: BigFraction
qsharp.summary: >-
  Represents a rational number of the form `p/q`. Integer `p` is
  the first element of the tuple and `q` is the second element
  of the tuple.
---

# BigFraction user defined type

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents a rational number of the form `p/q`. Integer `p` isthe first element of the tuple and `q` is the second elementof the tuple.

```qsharp

newtype BigFraction = (Numerator : BigInt, Denominator : BigInt);
```



## Named Items

### Numerator : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

Numerator of the fraction.
### Denominator : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

Denominator of the fraction/
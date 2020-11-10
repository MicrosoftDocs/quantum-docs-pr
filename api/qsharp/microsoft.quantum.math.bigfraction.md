---
uid: Microsoft.Quantum.Math.BigFraction
title: BigFraction user defined type
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
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

Package: [](https://nuget.org/packages/)


Represents a rational number of the form `p/q`. Integer `p` isthe first element of the tuple and `q` is the second elementof the tuple.

```qsharp

newtype BigFraction = (Numerator : BigInt, Denominator : BigInt);
```



## Named Items

### Numerator : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

Numerator of the fraction.
### Denominator : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

Denominator of the fraction/
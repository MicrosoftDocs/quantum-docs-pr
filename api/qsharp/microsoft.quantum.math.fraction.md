---
uid: Microsoft.Quantum.Math.Fraction
title: Fraction user defined type
ms.date: 12/15/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: Fraction
qsharp.summary: >-
  Represents a rational number of the form `p/q`. Integer `p` is
  the first element of the tuple and `q` is the second element
  of the tuple.
---

# Fraction user defined type

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents a rational number of the form `p/q`. Integer `p` isthe first element of the tuple and `q` is the second elementof the tuple.

```qsharp

newtype Fraction = (Numerator : Int, Denominator : Int);
```



## Named Items

### Numerator : [Int](xref:microsoft.quantum.lang-ref.int)

Numerator of the fraction.
### Denominator : [Int](xref:microsoft.quantum.lang-ref.int)

Denominator of the fraction/
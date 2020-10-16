---
uid: Microsoft.Quantum.Math.Fraction
title: Fraction user defined type
ms.date: 10/16/2020 12:00:00 AM
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

Package: [](https://nuget.org/packages/)


Represents a rational number of the form `p/q`. Integer `p` isthe first element of the tuple and `q` is the second elementof the tuple.

```Q#

newtype Fraction = (Numerator : Int, Denominator : Int);
```



## Named Items

### Numerator : Int

Numerator of the fraction.


### Denominator : Int

Denominator of the fraction/


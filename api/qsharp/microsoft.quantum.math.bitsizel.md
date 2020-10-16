---
uid: Microsoft.Quantum.Math.BitSizeL
title: BitSizeL function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: BitSizeL
qsharp.summary: >-
  For a non-negative integer `a`, returns the number of bits required to represent `a`.

  That is, returns the smallest $n$ such
  that $a < 2^n$.
---

# BitSizeL function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [](https://nuget.org/packages/)


For a non-negative integer `a`, returns the number of bits required to represent `a`.That is, returns the smallest $n$ suchthat $a < 2^n$.

```Q#
BitSizeL (a : BigInt) : Int
```


## Input

### a : BigInt

The integer whose bit-size is to be computed.



## Output

The bit-size of `a`.
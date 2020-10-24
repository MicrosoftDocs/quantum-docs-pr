---
uid: Microsoft.Quantum.Math.BitSizeI
title: BitSizeI function
ms.date: 10/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: BitSizeI
qsharp.summary: >-
  For a non-negative integer `a`, returns the number of bits required to represent `a`.

  That is, returns the smallest $n$ such
  that $a < 2^n$.
---

# BitSizeI function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [](https://nuget.org/packages/)


For a non-negative integer `a`, returns the number of bits required to represent `a`.That is, returns the smallest $n$ suchthat $a < 2^n$.

```qsharp
function BitSizeI (a : Int) : Int
```


## Input

### a : [Int](xref:microsoft.quantum.lang-ref.int)

The integer whose bit-size is to be computed.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

The bit-size of `a`.
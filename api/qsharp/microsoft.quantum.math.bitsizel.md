---
uid: Microsoft.Quantum.Math.BitSizeL
title: BitSizeL function
ms.date: 11/11/2020 12:00:00 AM
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


For a non-negative integer `a`, returns the number of bits required to represent `a`.That is, returns the smallest $n$ suchthat $a < 2^n$.

```qsharp
function BitSizeL (a : BigInt) : Int
```


## Input

### a : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The integer whose bit-size is to be computed.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

The bit-size of `a`.
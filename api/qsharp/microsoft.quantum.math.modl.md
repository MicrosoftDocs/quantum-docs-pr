---
uid: Microsoft.Quantum.Math.ModL
title: ModL function
ms.date: 10/28/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: ModL
qsharp.summary: Returns the modulus of a number with respect to another number.
---

# ModL function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [](https://nuget.org/packages/)


Returns the modulus of a number with respect to another number.

```qsharp
function ModL (a : BigInt, b : BigInt) : BigInt
```


## Input

### a : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The input $a$ whose modulus is to be returned.


### b : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The number with respect to which the modulus of $a$ is to be returned.



## Output : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The modulus $a \bmod b$.
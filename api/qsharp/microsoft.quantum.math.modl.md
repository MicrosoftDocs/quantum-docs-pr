---
uid: Microsoft.Quantum.Math.ModL
title: ModL function
ms.date: 2/4/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: ModL
qsharp.summary: Returns the modulus of a number with respect to another number.
---

# ModL function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


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
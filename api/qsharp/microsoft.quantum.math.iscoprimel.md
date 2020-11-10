---
uid: Microsoft.Quantum.Math.IsCoprimeL
title: IsCoprimeL function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: IsCoprimeL
qsharp.summary: Returns true if $a$ and $b$ are co-prime and false otherwise.
---

# IsCoprimeL function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [](https://nuget.org/packages/)


Returns true if $a$ and $b$ are co-prime and false otherwise.

```qsharp
function IsCoprimeL (a : BigInt, b : BigInt) : Bool
```


## Input

### a : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

the first number of which co-primality is being tested


### b : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

the second number of which co-primality is being tested



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

True, if $a$ and $b$ are co-prime (e.g. their greatest common divisor is 1 ),and false otherwise
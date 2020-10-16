---
uid: Microsoft.Quantum.Math.IsCoprimeL
title: IsCoprimeL function
ms.date: 10/16/2020 12:00:00 AM
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

```Q#
IsCoprimeL (a : BigInt, b : BigInt) : Bool
```


## Input

### a : BigInt

the first number of which co-primality is being tested


### b : BigInt

the second number of which co-primality is being tested



## Output

True, if $a$ and $b$ are co-prime (e.g. their greatest common divisor is 1 ),and false otherwise
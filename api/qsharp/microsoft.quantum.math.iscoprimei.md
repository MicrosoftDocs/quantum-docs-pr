---
uid: Microsoft.Quantum.Math.IsCoprimeI
title: IsCoprimeI function
ms.date: 12/8/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: IsCoprimeI
qsharp.summary: Returns true if $a$ and $b$ are co-prime and false otherwise.
---

# IsCoprimeI function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns true if $a$ and $b$ are co-prime and false otherwise.

```qsharp
function IsCoprimeI (a : Int, b : Int) : Bool
```


## Input

### a : [Int](xref:microsoft.quantum.lang-ref.int)

the first number of which co-primality is being tested


### b : [Int](xref:microsoft.quantum.lang-ref.int)

the second number of which co-primality is being tested



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

True, if $a$ and $b$ are co-prime (e.g. their greatest common divisor is 1 ),and false otherwise
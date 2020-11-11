---
uid: Microsoft.Quantum.Random.DrawRandomBool
title: DrawRandomBool operation
ms.date: 11/11/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Random
qsharp.name: DrawRandomBool
qsharp.summary: >-
  Given a success probability, returns a single Bernoulli trial that
  is true with the given probability.
---

# DrawRandomBool operation

Namespace: [Microsoft.Quantum.Random](xref:Microsoft.Quantum.Random)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Given a success probability, returns a single Bernoulli trial thatis true with the given probability.

```qsharp
operation DrawRandomBool (successProbability : Double) : Bool
```


## Input

### successProbability : [Double](xref:microsoft.quantum.lang-ref.double)

The probability with which `true` should be returned.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

`true` with probability `successProbability` and `false` withprobability `1.0 - successProbability`.
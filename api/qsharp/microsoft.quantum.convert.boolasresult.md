---
uid: Microsoft.Quantum.Convert.BoolAsResult
title: BoolAsResult function
ms.date: 12/21/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Convert
qsharp.name: BoolAsResult
qsharp.summary: >-
  Converts a `Bool` type to a `Result` type, where `true` is mapped to
  `One` and `false` is mapped to `Zero`.
---

# BoolAsResult function

Namespace: [Microsoft.Quantum.Convert](xref:Microsoft.Quantum.Convert)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Converts a `Bool` type to a `Result` type, where `true` is mapped to`One` and `false` is mapped to `Zero`.

```qsharp
function BoolAsResult (input : Bool) : Result
```


## Input

### input : [Bool](xref:microsoft.quantum.lang-ref.bool)

`Bool` to be converted.



## Output : __invalid<Result>__

A `Result` representing the `input`.
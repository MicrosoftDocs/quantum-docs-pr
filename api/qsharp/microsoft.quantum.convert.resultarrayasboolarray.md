---
uid: Microsoft.Quantum.Convert.ResultArrayAsBoolArray
title: ResultArrayAsBoolArray function
ms.date: 11/2/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Convert
qsharp.name: ResultArrayAsBoolArray
qsharp.summary: >-
  Converts a `Result[]` type to a `Bool[]` type, where `One` is mapped to
  `true` and `Zero` is mapped to `false`.
---

# ResultArrayAsBoolArray function

Namespace: [Microsoft.Quantum.Convert](xref:Microsoft.Quantum.Convert)

Package: [](https://nuget.org/packages/)


Converts a `Result[]` type to a `Bool[]` type, where `One` is mapped to`true` and `Zero` is mapped to `false`.

```qsharp
function ResultArrayAsBoolArray (input : Result[]) : Bool[]
```


## Input

### input : __invalid<Result>__[]

`Result[]` to be converted.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)[]

A `Bool[]` representing the `input`.
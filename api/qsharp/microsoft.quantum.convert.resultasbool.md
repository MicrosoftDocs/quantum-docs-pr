---
uid: Microsoft.Quantum.Convert.ResultAsBool
title: ResultAsBool function
ms.date: 10/28/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Convert
qsharp.name: ResultAsBool
qsharp.summary: >-
  Converts a `Result` type to a `Bool` type, where `One` is mapped to
  `true` and `Zero` is mapped to `false`.
---

# ResultAsBool function

Namespace: [Microsoft.Quantum.Convert](xref:Microsoft.Quantum.Convert)

Package: [](https://nuget.org/packages/)


Converts a `Result` type to a `Bool` type, where `One` is mapped to`true` and `Zero` is mapped to `false`.

```qsharp
function ResultAsBool (input : Result) : Bool
```


## Input

### input : __invalid<Result>__

`Result` to be converted.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

A `Bool` representing the `input`.
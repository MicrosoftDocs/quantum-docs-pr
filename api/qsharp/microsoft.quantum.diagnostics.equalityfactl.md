---
uid: Microsoft.Quantum.Diagnostics.EqualityFactL
title: EqualityFactL function
ms.date: 11/6/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: EqualityFactL
qsharp.summary: Asserts that a classical BigInt variable has the expected value.
---

# EqualityFactL function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Asserts that a classical BigInt variable has the expected value.

```qsharp
function EqualityFactL (actual : BigInt, expected : BigInt, message : String) : Unit
```


## Input

### actual : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The number to be checked.


### expected : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The expected value.


### message : [String](xref:microsoft.quantum.lang-ref.string)

Failure message string to be used when the assertion is triggered.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


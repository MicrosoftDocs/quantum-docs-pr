---
uid: Microsoft.Quantum.Diagnostics.EqualityFactB
title: EqualityFactB function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: EqualityFactB
qsharp.summary: Asserts that a classical Bool variable has the expected value.
---

# EqualityFactB function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Asserts that a classical Bool variable has the expected value.

```qsharp
function EqualityFactB (actual : Bool, expected : Bool, message : String) : Unit
```


## Input

### actual : [Bool](xref:microsoft.quantum.lang-ref.bool)

The variable to be checked.


### expected : [Bool](xref:microsoft.quantum.lang-ref.bool)

The expected value.


### message : [String](xref:microsoft.quantum.lang-ref.string)

Failure message string to be used when the assertion is triggered.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


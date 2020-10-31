---
uid: Microsoft.Quantum.Diagnostics.EqualityFactI
title: EqualityFactI function
ms.date: 10/30/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: EqualityFactI
qsharp.summary: Asserts that a classical Int variable has the expected value.
---

# EqualityFactI function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Asserts that a classical Int variable has the expected value.

```qsharp
function EqualityFactI (actual : Int, expected : Int, message : String) : Unit
```


## Input

### actual : [Int](xref:microsoft.quantum.lang-ref.int)

The number to be checked.


### expected : [Int](xref:microsoft.quantum.lang-ref.int)

The expected value.


### message : [String](xref:microsoft.quantum.lang-ref.string)

Failure message string to be used when the assertion is triggered.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


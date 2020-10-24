---
uid: Microsoft.Quantum.Diagnostics.AllEqualityFactB
title: AllEqualityFactB function
ms.date: 10/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: AllEqualityFactB
qsharp.summary: Asserts that two arrays of boolean values are equal.
---

# AllEqualityFactB function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Asserts that two arrays of boolean values are equal.

```qsharp
function AllEqualityFactB (actual : Bool[], expected : Bool[], message : String) : Unit
```


## Input

### actual : [Bool](xref:microsoft.quantum.lang-ref.bool)[]

The array that is produced by a test case of interest.


### expected : [Bool](xref:microsoft.quantum.lang-ref.bool)[]

The array that is expected from a test case of interest.


### message : [String](xref:microsoft.quantum.lang-ref.string)

A message to be printed if the arrays are not equal.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


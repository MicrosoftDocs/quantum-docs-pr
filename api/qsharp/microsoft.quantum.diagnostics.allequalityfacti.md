---
uid: Microsoft.Quantum.Diagnostics.AllEqualityFactI
title: AllEqualityFactI function
ms.date: 11/1/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: AllEqualityFactI
qsharp.summary: Asserts that two arrays of integer values are equal.
---

# AllEqualityFactI function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Asserts that two arrays of integer values are equal.

```qsharp
function AllEqualityFactI (actual : Int[], expected : Int[], message : String) : Unit
```


## Input

### actual : [Int](xref:microsoft.quantum.lang-ref.int)[]

The array that is produced by a test case of interest.


### expected : [Int](xref:microsoft.quantum.lang-ref.int)[]

The array that is expected from a test case of interest.


### message : [String](xref:microsoft.quantum.lang-ref.string)

A message to be printed if the arrays are not equal.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


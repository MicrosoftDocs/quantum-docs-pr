---
uid: Microsoft.Quantum.Diagnostics.EqualityFactC
title: EqualityFactC function
ms.date: 1/29/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: EqualityFactC
qsharp.summary: Asserts that a complex number has the expected value.
---

# EqualityFactC function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Asserts that a complex number has the expected value.

```qsharp
function EqualityFactC (actual : Microsoft.Quantum.Math.Complex, expected : Microsoft.Quantum.Math.Complex, message : String) : Unit
```


## Input

### actual : [Complex](xref:Microsoft.Quantum.Math.Complex)

The value to be checked.


### expected : [Complex](xref:Microsoft.Quantum.Math.Complex)

The expected value.


### message : [String](xref:microsoft.quantum.lang-ref.string)

Failure message string to be used when the assertion is triggered.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


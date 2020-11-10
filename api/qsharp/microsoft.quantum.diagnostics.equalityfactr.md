---
uid: Microsoft.Quantum.Diagnostics.EqualityFactR
title: EqualityFactR function
ms.date: 11/10/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: EqualityFactR
qsharp.summary: Asserts that a classical Result variable has the expected value.
---

# EqualityFactR function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Asserts that a classical Result variable has the expected value.

```qsharp
function EqualityFactR (actual : Result, expected : Result, message : String) : Unit
```


## Input

### actual : __invalid<Result>__

The variable to be checked.


### expected : __invalid<Result>__

The expected value.


### message : [String](xref:microsoft.quantum.lang-ref.string)

Failure message string to be used when the assertion is triggered.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


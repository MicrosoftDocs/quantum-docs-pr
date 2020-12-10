---
uid: Microsoft.Quantum.Diagnostics.FormattedFailure
title: FormattedFailure function
ms.date: 12/10/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: FormattedFailure
qsharp.summary: Internal function used to fail with meaningful error messages.
---

# FormattedFailure function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Internal function used to fail with meaningful error messages.

```qsharp
function FormattedFailure<'T> (actual : 'T, expected : 'T, message : String) : Unit
```


## Input

### actual : 'T




### expected : 'T




### message : [String](xref:microsoft.quantum.lang-ref.string)





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T



## Remarks

This function is intended to be emulated by simulation runtimes, so asto allow forwarding formatted contradictions.
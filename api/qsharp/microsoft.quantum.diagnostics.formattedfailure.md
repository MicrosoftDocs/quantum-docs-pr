---
uid: Microsoft.Quantum.Diagnostics.FormattedFailure
title: FormattedFailure function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: FormattedFailure
qsharp.summary: Internal function used to fail with meaningful error messages.
---

# FormattedFailure function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Internal function used to fail with meaningful error messages.

```Q#
FormattedFailure<'T> (actual : 'T, expected : 'T, message : String) : Unit
```


## Remarks

This function is intended to be emulated by simulation runtimes, so asto allow forwarding formatted contradictions.
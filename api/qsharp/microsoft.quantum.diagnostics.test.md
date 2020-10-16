---
uid: Microsoft.Quantum.Diagnostics.Test
title: Test user defined type
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: Test
qsharp.summary: Compiler-recognized attribute used to mark a unit test.
---

# Test user defined type

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Compiler-recognized attribute used to mark a unit test.

```Q#

@ Microsoft.Quantum.Core.Attribute()
newtype Test = (ExecutionTarget : String);
```


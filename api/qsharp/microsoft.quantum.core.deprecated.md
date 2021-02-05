---
uid: Microsoft.Quantum.Core.Deprecated
title: Deprecated user defined type
ms.date: 2/5/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Core
qsharp.name: Deprecated
qsharp.summary: Compiler-recognized attribute used to mark a type or callable as deprecated.
---

# Deprecated user defined type

Namespace: [Microsoft.Quantum.Core](xref:Microsoft.Quantum.Core)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Compiler-recognized attribute used to mark a type or callable as deprecated.

```qsharp

@ Microsoft.Quantum.Core.Attribute()
newtype Deprecated = (NewName : String);
```



## Named Items

### NewName : [String](xref:microsoft.quantum.lang-ref.string)

The full name of the type or callable to use instead.Is set to the empty String if a type or callable has been deprecated without substitution.
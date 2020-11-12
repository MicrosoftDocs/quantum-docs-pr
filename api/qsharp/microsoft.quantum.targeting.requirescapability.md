---
uid: Microsoft.Quantum.Targeting.RequiresCapability
title: RequiresCapability user defined type
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Targeting
qsharp.name: RequiresCapability
qsharp.summary: >-
  Compiler-recognized attribute used to mark a callable with the runtime capabilities it
  requires.
---

# RequiresCapability user defined type

Namespace: [Microsoft.Quantum.Targeting](xref:Microsoft.Quantum.Targeting)

Package: [](https://nuget.org/packages/)


Compiler-recognized attribute used to mark a callable with the runtime capabilities it

```qsharp

@ Microsoft.Quantum.Core.Attribute()
newtype RequiresCapability = (Level : String, Reason : String);
```



## Named Items

### Level : [String](xref:microsoft.quantum.lang-ref.string)

The name of the runtime capability level required by the callable.
### Reason : [String](xref:microsoft.quantum.lang-ref.string)

A description of why the callable requires this runtime capability.

## Remarks

This attribute is automatically added to callables by the compiler, unless an instance of
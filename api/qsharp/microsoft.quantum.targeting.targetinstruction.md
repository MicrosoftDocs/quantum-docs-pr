---
uid: Microsoft.Quantum.Targeting.TargetInstruction
title: TargetInstruction user defined type
ms.date: 2/6/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Targeting
qsharp.name: TargetInstruction
qsharp.summary: >-
  Compiler-recognized attribute for usage within target-specific packages
  to specify the name of the instruction on the target machine.
---

# TargetInstruction user defined type

Namespace: [Microsoft.Quantum.Targeting](xref:Microsoft.Quantum.Targeting)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Compiler-recognized attribute for usage within target-specific packagesto specify the name of the instruction on the target machine.

```qsharp

@ Microsoft.Quantum.Core.Attribute()
newtype TargetInstruction = (String);
```


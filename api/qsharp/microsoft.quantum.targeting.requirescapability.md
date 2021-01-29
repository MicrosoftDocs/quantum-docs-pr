---
uid: Microsoft.Quantum.Targeting.RequiresCapability
title: RequiresCapability user defined type
ms.date: 1/29/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Targeting
qsharp.name: RequiresCapability
qsharp.summary: >-
  Compiler-recognized attribute used to mark a callable with the runtime capabilities it
  requires.
---

# RequiresCapability user defined type

Namespace: [Microsoft.Quantum.Targeting](xref:Microsoft.Quantum.Targeting)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Compiler-recognized attribute used to mark a callable with the runtime capabilities itrequires.

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

This attribute is automatically added to callables by the compiler, unless an instance ofthis attribute already exists on the callable. It should not be used except in rare caseswhere the compiler does not infer the required capability correctly.Below is the list of capability level names, in order of increasing capabilities ordecreasing restrictions:## `"BasicQuantumFunctionality"`Measurement results cannot be compared for equality.## `"BasicMeasurementFeedback"`Measurement results can be compared for equality only in if-statement conditionalexpressions in operations. The block of an if-statement that depends on a result cannotcontain set statements for mutable variables declared outside the block, or returnstatements.## `"FullComputation"`No runtime restrictions. Any Q# program can be executed.
---
uid: Microsoft.Quantum.Synthesis.MCMTMask
title: MCMTMask user defined type
ms.date: 11/10/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: MCMTMask
qsharp.summary: >-
  A type to represent a multiple-controlled multiple-target Toffoli gate.

  The first integer is a bit mask for control lines.  Bit indexes which
  are set correspond to control line indexes.

  The second integer is a bit mask for target lines.  Bit indexes which
  are set correspond to target line indexes.

  The bit indexes of both integers must be disjoint.
---

# MCMTMask user defined type

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


A type to represent a multiple-controlled multiple-target Toffoli gate.The first integer is a bit mask for control lines.  Bit indexes whichare set correspond to control line indexes.The second integer is a bit mask for target lines.  Bit indexes whichare set correspond to target line indexes.The bit indexes of both integers must be disjoint.

```qsharp

newtype MCMTMask = (ControlMask : Int, TargetMask : Int);
```



## Named Items

### ControlMask : [Int](xref:microsoft.quantum.lang-ref.int)


### TargetMask : [Int](xref:microsoft.quantum.lang-ref.int)


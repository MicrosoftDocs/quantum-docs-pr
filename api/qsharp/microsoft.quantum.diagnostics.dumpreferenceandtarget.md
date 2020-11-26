---
uid: Microsoft.Quantum.Diagnostics.DumpReferenceAndTarget
title: DumpReferenceAndTarget operation
ms.date: 11/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: DumpReferenceAndTarget
qsharp.summary: >-
  Uses DumpRegister to provide diagnostics on the state of a reference and
  target register. Written as separate operation to allow overriding and
  interpreting as separate registers, rather than as a single combined
  register.
---

# DumpReferenceAndTarget operation

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Uses DumpRegister to provide diagnostics on the state of a reference andtarget register. Written as separate operation to allow overriding andinterpreting as separate registers, rather than as a single combinedregister.

```qsharp
operation DumpReferenceAndTarget (reference : Qubit[], target : Qubit[]) : Unit
```


## Input

### reference : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]




### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


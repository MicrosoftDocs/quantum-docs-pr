---
uid: Microsoft.Quantum.Arithmetic.ApplyPhaseLEOperationOnLE
title: ApplyPhaseLEOperationOnLE operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: ApplyPhaseLEOperationOnLE
qsharp.summary: >-
  Applies an operation that takes a
  <xref:microsoft.quantum.arithmetic.littleendian> register as input
  on a target register of type <xref:microsoft.quantum.arithmetic.phaselittleendian>.
---

# ApplyPhaseLEOperationOnLE operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Applies an operation that takes a<xref:microsoft.quantum.arithmetic.littleendian> register as inputon a target register of type <xref:microsoft.quantum.arithmetic.phaselittleendian>.

```Q#
ApplyPhaseLEOperationOnLE (op : (Microsoft.Quantum.Arithmetic.PhaseLittleEndian => Unit), target : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit
```


## Input

### op : [PhaseLittleEndian](xref:Microsoft.Quantum.Arithmetic.PhaseLittleEndian) => Unit 

The operation to be applied.


### target : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

The register to which the operation is applied.



## Remarks

The register is transformed to `PhaseLittleEndian` by the use of<xref:microsoft.quantum.canon.qftle> and is then returned toits original representation after application of `op`.

## See Also

- [Microsoft.Quantum.Canon.ApplyPhaseLEOperationonLEA](xref:Microsoft.Quantum.Canon.ApplyPhaseLEOperationonLEA)
- [Microsoft.Quantum.Canon.ApplyPhaseLEOperationonLEA](xref:Microsoft.Quantum.Canon.ApplyPhaseLEOperationonLEA)
- [Microsoft.Quantum.Canon.ApplyPhaseLEOperationonLECA](xref:Microsoft.Quantum.Canon.ApplyPhaseLEOperationonLECA)
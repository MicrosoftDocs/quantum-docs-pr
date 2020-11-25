---
uid: Microsoft.Quantum.Arithmetic.ApplyLEOperationOnPhaseLE
title: ApplyLEOperationOnPhaseLE operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: ApplyLEOperationOnPhaseLE
qsharp.summary: >-
  Applies an operation that takes a
  <xref:microsoft.quantum.arithmetic.phaselittleendian> register as input
  on a target register of type <xref:microsoft.quantum.arithmetic.littleendian>.
---

# ApplyLEOperationOnPhaseLE operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation that takes a<xref:microsoft.quantum.arithmetic.phaselittleendian> register as inputon a target register of type <xref:microsoft.quantum.arithmetic.littleendian>.

```qsharp
operation ApplyLEOperationOnPhaseLE (op : (Microsoft.Quantum.Arithmetic.LittleEndian => Unit), target : Microsoft.Quantum.Arithmetic.PhaseLittleEndian) : Unit
```


## Input

### op : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian) => [Unit](xref:microsoft.quantum.user-guide.language.types) 

The operation to be applied.


### target : [PhaseLittleEndian](xref:Microsoft.Quantum.Arithmetic.PhaseLittleEndian)

The register to which the operation is applied.



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## Remarks

The register is transformed to `LittleEndian` by the use of<xref:microsoft.quantum.canon.qftle> and is then returned toits original representation after application of `op`.

## See Also

- [Microsoft.Quantum.Canon.ApplyLEOperationonPhaseLEA](xref:Microsoft.Quantum.Canon.ApplyLEOperationonPhaseLEA)
- [Microsoft.Quantum.Canon.ApplyLEOperationonPhaseLEC](xref:Microsoft.Quantum.Canon.ApplyLEOperationonPhaseLEC)
- [Microsoft.Quantum.Canon.ApplyLEOperationonPhaseLECA](xref:Microsoft.Quantum.Canon.ApplyLEOperationonPhaseLECA)
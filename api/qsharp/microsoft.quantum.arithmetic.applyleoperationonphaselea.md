---
uid: Microsoft.Quantum.Arithmetic.ApplyLEOperationOnPhaseLEA
title: ApplyLEOperationOnPhaseLEA operation
ms.date: 10/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: ApplyLEOperationOnPhaseLEA
qsharp.summary: >-
  Applies an operation that takes a
  <xref:microsoft.quantum.arithmetic.phaselittleendian> register as input
  on a target register of type <xref:microsoft.quantum.arithmetic.littleendian>.
---

# ApplyLEOperationOnPhaseLEA operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Applies an operation that takes a<xref:microsoft.quantum.arithmetic.phaselittleendian> register as inputon a target register of type <xref:microsoft.quantum.arithmetic.littleendian>.

```qsharp
operation ApplyLEOperationOnPhaseLEA (op : (Microsoft.Quantum.Arithmetic.LittleEndian => Unit is Adj), target : Microsoft.Quantum.Arithmetic.PhaseLittleEndian) : Unit
```


## Input

### op : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian) => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj

The operation to be applied.


### target : [PhaseLittleEndian](xref:Microsoft.Quantum.Arithmetic.PhaseLittleEndian)

The register to which the operation is applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

The register is transformed to `LittleEndian` by the use of<xref:microsoft.quantum.canon.qftle> and is then returned toits original representation after application of `op`.

## See Also

- [Microsoft.Quantum.Canon.ApplyLEOperationonPhaseLE](xref:Microsoft.Quantum.Canon.ApplyLEOperationonPhaseLE)
- [Microsoft.Quantum.Canon.ApplyLEOperationonPhaseLEC](xref:Microsoft.Quantum.Canon.ApplyLEOperationonPhaseLEC)
- [Microsoft.Quantum.Canon.ApplyLEOperationonPhaseLECA](xref:Microsoft.Quantum.Canon.ApplyLEOperationonPhaseLECA)
---
uid: Microsoft.Quantum.Arithmetic.ApplyPhaseLEOperationOnLE
title: ApplyPhaseLEOperationOnLE operation
ms.date: 2/16/2021 12:00:00 AM
ms.topic: managed-reference
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation that takes a<xref:microsoft.quantum.arithmetic.littleendian> register as inputon a target register of type <xref:microsoft.quantum.arithmetic.phaselittleendian>.

```qsharp
operation ApplyPhaseLEOperationOnLE (op : (Microsoft.Quantum.Arithmetic.PhaseLittleEndian => Unit), target : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit
```


## Input

### op : [PhaseLittleEndian](xref:Microsoft.Quantum.Arithmetic.PhaseLittleEndian) => [Unit](xref:microsoft.quantum.lang-ref.unit) 

The operation to be applied.


### target : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

The register to which the operation is applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

The register is transformed to `PhaseLittleEndian` by the use of<xref:microsoft.quantum.canon.qftle> and is then returned toits original representation after application of `op`.

## See Also

- [Microsoft.Quantum.Canon.ApplyPhaseLEOperationonLEA](xref:Microsoft.Quantum.Canon.ApplyPhaseLEOperationonLEA)
- [Microsoft.Quantum.Canon.ApplyPhaseLEOperationonLEA](xref:Microsoft.Quantum.Canon.ApplyPhaseLEOperationonLEA)
- [Microsoft.Quantum.Canon.ApplyPhaseLEOperationonLECA](xref:Microsoft.Quantum.Canon.ApplyPhaseLEOperationonLECA)
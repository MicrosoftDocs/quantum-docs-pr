---
uid: Microsoft.Quantum.Arithmetic.ApplyReversedOpLEC
title: ApplyReversedOpLEC operation
ms.date: 1/30/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: ApplyReversedOpLEC
qsharp.summary: >-
  Applies an operation that takes little-endian input to a register encoding
  an unsigned integer using big-endian format.
---

# ApplyReversedOpLEC operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation that takes little-endian input to a register encodingan unsigned integer using big-endian format.

```qsharp
operation ApplyReversedOpLEC (op : (Microsoft.Quantum.Arithmetic.LittleEndian => Unit is Ctl), register : Microsoft.Quantum.Arithmetic.BigEndian) : Unit is Ctl
```


## Input

### op : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Ctl

Operation that acts on a little-endian register.


### register : [BigEndian](xref:Microsoft.Quantum.Arithmetic.BigEndian)

A big-endian register to be transformed.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Arithmetic.ApplyReversedOpLE](xref:Microsoft.Quantum.Arithmetic.ApplyReversedOpLE)
- [Microsoft.Quantum.Arithmetic.ApplyReversedOpLEA](xref:Microsoft.Quantum.Arithmetic.ApplyReversedOpLEA)
- [Microsoft.Quantum.Arithmetic.ApplyReversedOpLECA](xref:Microsoft.Quantum.Arithmetic.ApplyReversedOpLECA)
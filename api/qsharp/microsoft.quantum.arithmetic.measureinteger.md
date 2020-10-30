---
uid: Microsoft.Quantum.Arithmetic.MeasureInteger
title: MeasureInteger operation
ms.date: 10/29/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: MeasureInteger
qsharp.summary: >-
  Measures the content of a quantum register and converts
  it to an integer. The measurement is performed with respect
  to the standard computational basis, i.e., the eigenbasis of `PauliZ`.
---

# MeasureInteger operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Measures the content of a quantum register and convertsit to an integer. The measurement is performed with respectto the standard computational basis, i.e., the eigenbasis of `PauliZ`.

```qsharp
operation MeasureInteger (target : Microsoft.Quantum.Arithmetic.LittleEndian) : Int
```


## Input

### target : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

A quantum register in the little-endian encoding.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

An unsigned integer that contains the measured value of `target`.

## Remarks

This operation resets its input register to the $\ket{00\cdots 0}$ state,suitable for releasing back to a target machine.

## See Also

- [Microsoft.Quantum.Canon.MeasureIntegerBE](xref:Microsoft.Quantum.Canon.MeasureIntegerBE)
---
uid: Microsoft.Quantum.Arithmetic.ReversedOpBE
title: ReversedOpBE function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: ReversedOpBE
qsharp.summary: >-
  Given an operation that takes a big-endian input, returns a new
  operation that takes a little-endian input.
---

# ReversedOpBE function

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Given an operation that takes a big-endian input, returns a newoperation that takes a little-endian input.

```Q#
ReversedOpBE (op : (Microsoft.Quantum.Arithmetic.BigEndian => Unit)) : (Microsoft.Quantum.Arithmetic.LittleEndian => Unit)
```


## Input

### op : [BigEndian](xref:Microsoft.Quantum.Arithmetic.BigEndian) => Unit 

The operation whose input is to be reversed.



## Output

A new operation that accepts its input as a little-endian register.

## See Also

- [Microsoft.Quantum.Arithmetic.ApplyReversedOpBE](xref:Microsoft.Quantum.Arithmetic.ApplyReversedOpBE)
- [Microsoft.Quantum.Arithmetic.ReversedOpBEA](xref:Microsoft.Quantum.Arithmetic.ReversedOpBEA)
- [Microsoft.Quantum.Arithmetic.ReversedOpBEC](xref:Microsoft.Quantum.Arithmetic.ReversedOpBEC)
- [Microsoft.Quantum.Arithmetic.ReversedOpBECA](xref:Microsoft.Quantum.Arithmetic.ReversedOpBECA)
---
uid: Microsoft.Quantum.Arithmetic.ReversedOpBEA
title: ReversedOpBEA function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: ReversedOpBEA
qsharp.summary: >-
  Given an operation that takes a big-endian input, returns a new
  operation that takes a little-endian input.
---

# ReversedOpBEA function

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Given an operation that takes a big-endian input, returns a newoperation that takes a little-endian input.

```Q#
ReversedOpBEA (op : (Microsoft.Quantum.Arithmetic.BigEndian => Unit is Adj)) : (Microsoft.Quantum.Arithmetic.LittleEndian => Unit is Adj)
```


## Input

### op : [BigEndian](xref:Microsoft.Quantum.Arithmetic.BigEndian) => Unit Adj

The operation whose input is to be reversed.



## Output

A new operation that accepts its input as a little-endian register.

## See Also

- [Microsoft.Quantum.Arithmetic.ApplyReversedOpBEA](xref:Microsoft.Quantum.Arithmetic.ApplyReversedOpBEA)
- [Microsoft.Quantum.Arithmetic.ReversedOpBE](xref:Microsoft.Quantum.Arithmetic.ReversedOpBE)
- [Microsoft.Quantum.Arithmetic.ReversedOpBEC](xref:Microsoft.Quantum.Arithmetic.ReversedOpBEC)
- [Microsoft.Quantum.Arithmetic.ReversedOpBECA](xref:Microsoft.Quantum.Arithmetic.ReversedOpBECA)
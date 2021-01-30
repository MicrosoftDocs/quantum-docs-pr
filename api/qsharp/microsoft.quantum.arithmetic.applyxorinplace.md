---
uid: Microsoft.Quantum.Arithmetic.ApplyXorInPlace
title: ApplyXorInPlace operation
ms.date: 1/30/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: ApplyXorInPlace
qsharp.summary: >-
  Applies a bitwise-XOR operation between a classical integer and an
  integer represented by a register of qubits.
---

# ApplyXorInPlace operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies a bitwise-XOR operation between a classical integer and aninteger represented by a register of qubits.

```qsharp
operation ApplyXorInPlace (value : Int, target : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit is Adj + Ctl
```


## Description

Applies `X` operations to qubits in a little-endian register based on1 bits in an integer.Let us denote `value` by a and let y be an unsigned integer encoded in `target`,then `InPlaceXorLE` performs an operation given by the following map:$\ket{y}\rightarrow \ket{y\oplus a}$ , where $\oplus$ is the bitwise exclusive OR operator.

## Input

### value : [Int](xref:microsoft.quantum.lang-ref.int)

An integer which is assumed to be non-negative.


### target : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

A quantum register which is used to store `value` in little-endian encoding.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


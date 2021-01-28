---
uid: Microsoft.Quantum.Arithmetic.CompareUsingRippleCarry
title: CompareUsingRippleCarry operation
ms.date: 1/27/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: CompareUsingRippleCarry
qsharp.summary: >-
  This operation tests if an integer represented by a register of qubits
  is greater than another integer, applying an XOR of the result onto an
  output qubit.
---

# CompareUsingRippleCarry operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


This operation tests if an integer represented by a register of qubitsis greater than another integer, applying an XOR of the result onto anoutput qubit.

```qsharp
operation CompareUsingRippleCarry (x : Microsoft.Quantum.Arithmetic.LittleEndian, y : Microsoft.Quantum.Arithmetic.LittleEndian, output : Qubit) : Unit is Adj + Ctl
```


## Description

Given two integers `x` and `y` stored in equal-size qubit registers,this operation checks if they satisfy `x > y`. If true, 1 isXORed into an output qubit. Otherwise, 0 is XORed into an output qubit.In other words, this operation can be represented by the unitary$$\begin{align}U\ket{x}\ket{y}\ket{z} = \ket{x}\ket{y}\ket{z\oplus (x>y)}.\end{align}$$

## Input

### x : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

First number to be compared stored in `LittleEndian` format in a qubit register.


### y : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

Second number to be compared stored in `LittleEndian` format in a qubit register.


### output : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit that stores the result of the comparison $x>y$.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## References

- A new quantum ripple-carry addition circuit  Steven A. Cuccaro, Thomas G. Draper, Samuel A. Kutin, David Petrie Moulton  https://arxiv.org/abs/quant-ph/0410184
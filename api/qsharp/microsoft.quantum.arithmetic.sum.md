---
uid: Microsoft.Quantum.Arithmetic.Sum
title: Sum operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: Sum
qsharp.summary: >-
  Implements a reversible sum gate. Given a carry-in bit encoded in
  qubit `carryIn` and two summand bits encoded in `summand1` and `summand2`,
  computes the bitwise xor of `carryIn`, `summand1` and `summand2` in the qubit
  `summand2`.
---

# Sum operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Implements a reversible sum gate. Given a carry-in bit encoded inqubit `carryIn` and two summand bits encoded in `summand1` and `summand2`,computes the bitwise xor of `carryIn`, `summand1` and `summand2` in the qubit`summand2`.

```Q#
Sum (carryIn : Qubit, summand1 : Qubit, summand2 : Qubit) : Unit
```


## Input

### carryIn : Qubit

Carry-in qubit.


### summand1 : Qubit

First summand qubit.


### summand2 : Qubit

Second summand qubit, is replaced with the lower bit of the sum of`summand1` and `summand2`.



## Remarks

In contrast to the `Carry` operation, this does not compute the carry-out bit.
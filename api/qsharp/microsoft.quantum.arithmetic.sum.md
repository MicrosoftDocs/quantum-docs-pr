---
uid: Microsoft.Quantum.Arithmetic.Sum
title: Sum operation
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Implements a reversible sum gate. Given a carry-in bit encoded inqubit `carryIn` and two summand bits encoded in `summand1` and `summand2`,computes the bitwise xor of `carryIn`, `summand1` and `summand2` in the qubit`summand2`.

```qsharp
operation Sum (carryIn : Qubit, summand1 : Qubit, summand2 : Qubit) : Unit is Adj + Ctl
```


## Input

### carryIn : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Carry-in qubit.


### summand1 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

First summand qubit.


### summand2 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Second summand qubit, is replaced with the lower bit of the sum of`summand1` and `summand2`.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

In contrast to the `Carry` operation, this does not compute the carry-out bit.
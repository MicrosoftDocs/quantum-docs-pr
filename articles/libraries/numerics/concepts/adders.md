---
title: Integer Addition | Microsoft Docs
description: Integer Addition Conceptual Docs
author: Martin Roetteler
ms.author: martinro
ms.date: 4/16/2019
uid: microsoft.quantum.numerics.concepts.adders
---

WIP

# Quantum Circuits To Add Integers 

One of the basic building blocks of arithmetic operations is integer addition. Some quantum algorithms require that two integers are added together in superposition. This can be done in place, which means that two $n$-qubit registers are given and the sum of the two integers encoded in them is written to one of them, say the second one. Of course, the sum of two $n$-bit integers can have $n+1$ bits, so an additional bit is needed to keep track of the carry bit. This means that the addition of two $n$-qubit integers $x$ and $y$ can be considered as being the operation
$$
\ket x\ket y \ket 0\mapsto \ket x\ket{x+y \mod 2^n} \ket c.
$$
Both registers $\ket x$ and $\ket y$ are $n$-qubit registers and the carry out qubit initialized as $\ket 0$ holds the carry bit $c$ after the addition. As integers, the identity $x + y = (x+y \mod 2^n) + c\cdot 2^n$ holds.

## Ripple-carry Addition

The signature of such an operation is shown here.

```qsharp
operation RippleCarryAdderD (xs : LittleEndian, ys : LittleEndian, carry : Qubit) : Unit
```

The two input $n$-qubit integers have the type `LittleEndian`, the carry qubit is a single `Qubit`.


Such a quantum addition algorithm can be implemented mirroring classical integer addition while making sure that the computation is reversible. In the first part of the algorithm, a sequence of carry operations propagate the carry bit from the least significant bits up to the carry bit $c$. Then, in the reverse order, it actually computes the sum and reverses the carry operations by using their adjoint counterparts. The carry and sum operations as they are used in `RippleCarryAdderD` are shown below.

```qsharp
operation Carry (carryIn: Qubit, summand1: Qubit, summand2: Qubit, carryOut: Qubit) : Unit
{
    body (...) {
        CCNOT (summand1, summand2, carryOut);
        CNOT (summand1, summand2);
        CCNOT (carryIn, summand2, carryOut);
    }
    adjoint auto;
    controlled auto;
    adjoint controlled auto;
}
```

```qsharp
operation Sum (carryIn: Qubit, summand1: Qubit, summand2: Qubit) : Unit
{
    body (...) {
        CNOT (summand1, summand2);
        CNOT (carryIn, summand2);
    }
    adjoint auto;
    controlled auto;
    adjoint controlled auto;
}
```

The core of `RippleCarryAdderD` consists of the code shown below. It uses $n$ auxiliary qubits that are used for propagating the carry bit. This code allows to be controlled on a qubit array `controls`. The `Carry` operations in the first and the second loop cancel out when the controls do not trigger the operation and do not need to be controlled separately. 

```qsharp
using ( ancillas = Qubit[nQubits] ) {
    for (idx in 0..(nQubits-2) ) {
        Carry (ancillas[idx], xs![idx], ys![idx], ancillas[idx+1]);           // (1)
    }
    (Controlled Carry) (controls, (ancillas[nQubits-1], xs![nQubits-1], ys![nQubits-1], carry));
    (Controlled CNOT) (controls, (xs![nQubits-1], ys![nQubits-1]));
    (Controlled Sum) (controls, (ancillas[nQubits-1], xs![nQubits-1], ys![nQubits-1]));
    for (idx in (nQubits-2)..(-1)..0 ) {
        (Adjoint Carry) (ancillas[idx], xs![idx], ys![idx], ancillas[idx+1]); // cancels with (1)
        (Controlled Sum) (controls, (ancillas[idx], xs![idx], ys![idx]));
    }
}
```

## Addition with Fewer Auxiliary Qubits
Cuccaro-Draper-Kutin-Moulton 

Takahashi-Tani-Kunihiro



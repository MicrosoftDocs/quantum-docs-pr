---
title: Integer Addition | Microsoft Docs
description: Integer Addition Conceptual Docs
author: cryptosidh
ms.author: mnaehrig
ms.date: 4/16/2019
uid: microsoft.quantum.numerics.concepts.adders
---

WIP

# Quantum Circuits To Add Integers 

One of the basic building blocks of arithmetic operations is integer addition. Some quantum algorithms require that two integers are added together in superposition. This can be done in place, which means that two $n$-qubit registers are given and the sum of the two integers encoded in them is written to one of them, say the second one. Of course, the sum of two $n$-bit integers can have $n+1$ bits, so an additional bit is needed to keep track of the carry bit. This means that the addition of two $n$-qubit integers $x$ and $y$ can be considered as the operation
$$
\ket x\ket y \ket 0\mapsto \ket x\ket{x+y \mod 2^n} \ket c.
$$
Both registers $\ket x$ and $\ket y$ are $n$-qubit registers and the carry-out qubit initialized as $\ket 0$ holds the carry bit $c$ after the addition. As integers, the result can be written as $x + y = (x+y \mod 2^n) + c\cdot 2^n$.

## Ripple-carry Addition

The signature of such an operation is shown here. The two input $n$-qubit integers have the type `LittleEndian`, the carry qubit is a single `Qubit`.

```qsharp
operation RippleCarryAdderD (xs : LittleEndian, ys : LittleEndian, carry : Qubit) : Unit
```

Such a quantum addition algorithm can be implemented mirroring classical integer addition while making sure that the computation is reversible. The classical way of carry propagation for addition leads to a quantum ripple carry addition algorithm. In the first part of the algorithm, a sequence of carry operations propagate the carry bit from the least significant bits up to the carry bit `carry`. Now, the carry-out bit is set and, in the reverse order, the algorithm then computes the sum while uncomputing the carry bits by reversing the carry operations using their adjoint counterparts. The carry opreration `Carry` as used in `RippleCarryAdderD` is shown below.

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
All four inputs are single 'Qubit' types. When acting on qubit registers that encode classical bits, the operation flips the qubit `carryOut` if the carry bit in the addition of the bits encoded in `summand1`, `summand2` and `carryIn` is 1. The qubit in `summand2` is changed because of the `CNOT` gate acting on it. The `Sum` operation is a bitwise sum without carry. 


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

 `RippleCarryAdderD` computes the integer addition with the code shown below. It uses $n$ auxiliary qubits that are used for propagating the carry bit. This code allows to be controlled on a qubit array `controls`. The `Carry` operations in the first cancel out with their adjoint counterparts in the second loop when the controls do not trigger the operation and do not need to be controlled separately. 

```qsharp
using ( ancillas = Qubit[nQubits] ) {
    for (idx in 0..(nQubits-2) ) {
        Carry (ancillas[idx], xs![idx], ys![idx], ancillas[idx+1]);           // (1)
    }
    (Controlled Carry) (controls, (ancillas[nQubits-1], xs![nQubits-1], ys![nQubits-1], carry));
    (Controlled CNOT) (controls, (ancillas[nQubits-1], ys![nQubits-1]));
    for (idx in (nQubits-2)..(-1)..0 ) {
        (Adjoint Carry) (ancillas[idx], xs![idx], ys![idx], ancillas[idx+1]); // cancels with (1)
        (Controlled Sum) (controls, (ancillas[idx], xs![idx], ys![idx]));
    }
}
```

## Addition with Fewer Auxiliary Qubits
Cuccaro-Draper-Kutin-Moulton 

Takahashi-Tani-Kunihiro

## Using Integer Addition


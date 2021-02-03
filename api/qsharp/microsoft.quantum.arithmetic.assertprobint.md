---
uid: Microsoft.Quantum.Arithmetic.AssertProbInt
title: AssertProbInt operation
ms.date: 2/3/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: AssertProbInt
qsharp.summary: >-
  Asserts that the probability of a specific state of a quantum register has the
  expected value.
---

# AssertProbInt operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Asserts that the probability of a specific state of a quantum register has theexpected value.

```qsharp
operation AssertProbInt (stateIndex : Int, expected : Double, qubits : Microsoft.Quantum.Arithmetic.LittleEndian, tolerance : Double) : Unit
```


## Description

Given an $n$-qubit quantum state $\ket{\psi}=\sum^{2^n-1}_{j=0}\alpha_j \ket{j}$,asserts that the probability $|\alpha_j|^2$ of the state $\ket{j}$ indexed by $j$has the expected value.

## Input

### stateIndex : [Int](xref:microsoft.quantum.lang-ref.int)

The index $j$ of the state $\ket{j}$ represented by a `LittleEndian`register.


### expected : [Double](xref:microsoft.quantum.lang-ref.double)

The expected value of $|\alpha_j|^2$.


### qubits : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

The qubit register that stores $\ket{\psi}$ in little-endian format.


### tolerance : [Double](xref:microsoft.quantum.lang-ref.double)

Absolute tolerance on the difference between actual and expected.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Example

Suppose that the `qubits` register encodes a 3-qubit quantum state$\ket{\psi}=\sqrt{1/8}\ket{0}+\sqrt{7/8}\ket{6}$ in little-endian format.This means that the number states $\ket{0}\equiv\ket{0}\ket{0}\ket{0}$and $\ket{6}\equiv\ket{0}\ket{1}\ket{1}$. Then the following asserts succeed:```qsharpAssertProbInt(0, 0.125, qubits, 10e-10);AssertProbInt(6, 0.875, qubits, 10e-10);```
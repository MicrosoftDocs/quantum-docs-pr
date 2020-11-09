---
uid: Microsoft.Quantum.Arithmetic.AssertProbInt
title: AssertProbInt operation
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: AssertProbInt
qsharp.summary: >-
  Asserts that the probability of a specific state of a quantum register has the
  expected value.
---

# AssertProbInt operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


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


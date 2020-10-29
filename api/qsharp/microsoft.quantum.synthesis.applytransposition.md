---
uid: Microsoft.Quantum.Synthesis.ApplyTransposition
title: ApplyTransposition operation
ms.date: 10/29/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: ApplyTransposition
qsharp.summary: ''
---

# ApplyTransposition operation

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [](https://nuget.org/packages/)




```qsharp
operation ApplyTransposition (a : Int, b : Int, qubits : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit
```


## Description

This operation swaps the amplitude at index `a` with theamplitude at index `b` in the given state-vector of`register` of length $n$.  If `a` equals `b`, the state-vectoris not changed.

## Input

### a : [Int](xref:microsoft.quantum.lang-ref.int)

First index (must be a value from 0 to $2^n - 1$)


### b : [Int](xref:microsoft.quantum.lang-ref.int)

Second index (must be a value from 0 to $2^n - 1$)


### qubits : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

A list of $n$ qubits to which the transposition is applied to.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


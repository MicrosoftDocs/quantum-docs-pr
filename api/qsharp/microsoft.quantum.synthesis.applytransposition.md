---
uid: Microsoft.Quantum.Synthesis.ApplyTransposition
title: ApplyTransposition operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: ApplyTransposition
qsharp.summary: ''
---

# ApplyTransposition operation

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [](https://nuget.org/packages/)




```Q#
ApplyTransposition (a : Int, b : Int, qubits : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit
```


## Description

This operation swaps the amplitude at index `a` with theamplitude at index `b` in the given state-vector of`register` of length $n$.  If `a` equals `b`, the state-vectoris not changed.

## Input

### a : Int

First index (must be a value from 0 to $2^n - 1$)


### b : Int

Second index (must be a value from 0 to $2^n - 1$)


### qubits : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

A list of $n$ qubits to which the transposition is applied to.


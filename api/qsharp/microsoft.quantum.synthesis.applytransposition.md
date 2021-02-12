---
uid: Microsoft.Quantum.Synthesis.ApplyTransposition
title: ApplyTransposition operation
ms.date: 2/12/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: ApplyTransposition
qsharp.summary: ''
---

# ApplyTransposition operation

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)




```qsharp
operation ApplyTransposition (a : Int, b : Int, qubits : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit is Adj + Ctl
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



## Example

Prepare a uniform superposition of number states $|1\rangle$, $|2\rangle$, and$|3\rangle$ on 2 qubits.```qsharpusing (qubits = Qubit[2]) {  let register = LittleEndian(qubits);  PrepareUniformSuperposition(3, register);  ApplyTransposition(0, 3, register);}```
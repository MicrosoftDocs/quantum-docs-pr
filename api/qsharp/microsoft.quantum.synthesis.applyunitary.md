---
uid: Microsoft.Quantum.Synthesis.ApplyUnitary
title: ApplyUnitary operation
ms.date: 1/27/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: ApplyUnitary
qsharp.summary: >-
  Applies gate defined by 2^n x 2^n unitary matrix.

  Fails if matrix is not unitary, or has wrong size.
---

# ApplyUnitary operation

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies gate defined by 2^n x 2^n unitary matrix.Fails if matrix is not unitary, or has wrong size.

```qsharp
operation ApplyUnitary (unitary : Microsoft.Quantum.Math.Complex[][], qubits : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit is Adj + Ctl
```


## Input

### unitary : [Complex](xref:Microsoft.Quantum.Math.Complex)[][]

2^n x 2^n unitary matrix describing the operation.If matrix is not unitary or not of suitable size, throws an exception.


### qubits : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

Qubits to which apply the operation - register of length n.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


---
uid: Microsoft.Quantum.Arithmetic.FixedPoint
title: FixedPoint user defined type
ms.date: 2/5/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: FixedPoint
qsharp.summary: >-
  Represents a register of qubits encoding a fixed-point number. Consists of an integer that is equal to the number of
  qubits to the left of the binary point, i.e., qubits of weight greater
  than or equal to 1, and a quantum register.
---

# FixedPoint user defined type

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Numerics](https://nuget.org/packages/Microsoft.Quantum.Numerics)


Represents a register of qubits encoding a fixed-point number. Consists of an integer that is equal to the number ofqubits to the left of the binary point, i.e., qubits of weight greaterthan or equal to 1, and a quantum register.

```qsharp

newtype FixedPoint = (Int, Qubit[]);
```


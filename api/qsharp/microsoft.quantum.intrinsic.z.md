---
uid: Microsoft.Quantum.Intrinsic.Z
title: Z operation
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: Z
qsharp.summary: Applies the Pauli $Z$ gate.
---

# Z operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Applies the Pauli $Z$ gate.

```qsharp
operation Z (qubit : Qubit) : Unit is Adj + Ctl
```


## Description

\begin{align}\sigma_z \mathrel{:=}\begin{bmatrix}1 & 0 \\\\0 & -1\end{bmatrix}.\end{align}

## Input

### qubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit to which the gate should be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


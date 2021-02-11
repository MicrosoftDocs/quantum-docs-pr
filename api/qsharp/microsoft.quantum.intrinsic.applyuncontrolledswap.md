---
uid: Microsoft.Quantum.Intrinsic.ApplyUncontrolledSWAP
title: ApplyUncontrolledSWAP operation
ms.date: 2/11/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: ApplyUncontrolledSWAP
qsharp.summary: >-
  Applies the SWAP gate to a pair of qubits. Note that the Controlled functor
  is not supported.
---

# ApplyUncontrolledSWAP operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [Microsoft.Quantum.Type3.Core](https://nuget.org/packages/Microsoft.Quantum.Type3.Core)


Applies the SWAP gate to a pair of qubits. Note that the Controlled functoris not supported.

```qsharp
operation ApplyUncontrolledSWAP (qubit1 : Qubit, qubit2 : Qubit) : Unit is Adj
```


## Description

\begin{align}\operatorname{SWAP} \mathrel{:=}\begin{bmatrix}1 & 0 & 0 & 0 \\\\0 & 0 & 1 & 0 \\\\0 & 1 & 0 & 0 \\\\0 & 0 & 0 & 1\end{bmatrix},\end{align}where rows and columns are ordered as in the quantum concepts guide.

## Input

### qubit1 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

First qubit to be swapped.


### qubit2 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Second qubit to be swapped.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Equivalent to:```qsharpCNOT(qubit1, qubit2);CNOT(qubit2, qubit1);CNOT(qubit1, qubit2);```
---
uid: Microsoft.Quantum.Intrinsic.CNOT
title: CNOT operation
ms.date: 11/2/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: CNOT
qsharp.summary: >-
  Applies the controlled-NOT (CNOT) gate to a pair of qubits.

  \begin{align}
  \operatorname{CNOT} \mathrel{:=}
  \begin{bmatrix}
  1 & 0 & 0 & 0 \\\\
  0 & 1 & 0 & 0 \\\\
  0 & 0 & 0 & 1 \\\\
  0 & 0 & 1 & 0
  \end{bmatrix},
  \end{align}

  where rows and columns are ordered as in the quantum concepts guide.
---

# CNOT operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [](https://nuget.org/packages/)


Applies the controlled-NOT (CNOT) gate to a pair of qubits.\begin{align}\operatorname{CNOT} \mathrel{:=}\begin{bmatrix}1 & 0 & 0 & 0 \\\\0 & 1 & 0 & 0 \\\\0 & 0 & 0 & 1 \\\\0 & 0 & 1 & 0\end{bmatrix},\end{align}where rows and columns are ordered as in the quantum concepts guide.

```qsharp
operation CNOT (control : Qubit, target : Qubit) : Unit
```


## Input

### control : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Control qubit for the CNOT gate.


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Target qubit for the CNOT gate.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Equivalent to:```qsharpControlled X([control], target);```
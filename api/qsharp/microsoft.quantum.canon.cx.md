---
uid: Microsoft.Quantum.Canon.CX
title: CX operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: CX
qsharp.summary: >-
  Applies the controlled-X (CX) gate to a pair of qubits.

  $$
  \begin{align}
  1 & 0 & 0 & 0 \\\\
  0 & 1 & 0 & 0 \\\\
  0 & 0 & 0 & 1 \\\\
  0 & 0 & 1 & 0
  \end{align},
  $$
  where rows and columns are organized as in the quantum concepts guide.
---

# CX operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies the controlled-X (CX) gate to a pair of qubits.$$\begin{align}1 & 0 & 0 & 0 \\\\0 & 1 & 0 & 0 \\\\0 & 0 & 0 & 1 \\\\0 & 0 & 1 & 0\end{align},$$where rows and columns are organized as in the quantum concepts guide.

```Q#
CX (control : Qubit, target : Qubit) : Unit
```


## Input

### control : Qubit

Control qubit for the CX gate.


### target : Qubit

Target qubit for the CX gate.



## Remarks

Equivalent to:```qsharpControlled X([control], target);```and to:```qsharpCNOT(control, target);```
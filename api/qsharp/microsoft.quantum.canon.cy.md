---
uid: Microsoft.Quantum.Canon.CY
title: CY operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: CY
qsharp.summary: >-
  Applies the controlled-Y (CY) gate to a pair of qubits.

  $$
  \begin{align}
  1 & 0 & 0 & 0 \\\\
  0 & 1 & 0 & 0 \\\\
  0 & 0 & 0 & -i \\\\
  0 & 0 & i & 0
  \end{align},
  $$
  where rows and columns are organized as in the quantum concepts guide.
---

# CY operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies the controlled-Y (CY) gate to a pair of qubits.$$\begin{align}1 & 0 & 0 & 0 \\\\0 & 1 & 0 & 0 \\\\0 & 0 & 0 & -i \\\\0 & 0 & i & 0\end{align},$$where rows and columns are organized as in the quantum concepts guide.

```qsharp
operation CY (control : Qubit, target : Qubit) : Unit is Adj + Ctl
```


## Input

### control : [Qubit](xref:microsoft.quantum.concepts.the-qubit)

Control qubit for the CY gate.


### target : [Qubit](xref:microsoft.quantum.concepts.the-qubit)

Target qubit for the CY gate.



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## Remarks

Equivalent to:```qsharpControlled Y([control], target);```
---
uid: Microsoft.Quantum.Canon.CX
title: CX operation
ms.date: 2/16/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: CX
qsharp.summary: >-
  Applies the controlled-X (CX) gate to a pair of qubits.

  $$
  \begin{align}
  \left(\begin{matrix}
  1 & 0 & 0 & 0 \\\\
  0 & 1 & 0 & 0 \\\\
  0 & 0 & 0 & 1 \\\\
  0 & 0 & 1 & 0
  \end{matrix}\right)
  \end{align},
  $$
  where rows and columns are organized as in the quantum concepts guide.
---

# CX operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies the controlled-X (CX) gate to a pair of qubits.$$\begin{align}\left(\begin{matrix}1 & 0 & 0 & 0 \\\\0 & 1 & 0 & 0 \\\\0 & 0 & 0 & 1 \\\\0 & 0 & 1 & 0\end{matrix}\right)\end{align},$$where rows and columns are organized as in the quantum concepts guide.

```qsharp
operation CX (control : Qubit, target : Qubit) : Unit is Adj + Ctl
```


## Input

### control : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Control qubit for the CX gate.


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Target qubit for the CX gate.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Equivalent to:```qsharpControlled X([control], target);```and to:```qsharpCNOT(control, target);```
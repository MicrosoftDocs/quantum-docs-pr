---
uid: Microsoft.Quantum.Canon.CZ
title: CZ operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: CZ
qsharp.summary: >-
  Applies the controlled-Z (CZ) gate to a pair of qubits.

  $$
  \begin{align}
  1 & 0 & 0 & 0 \\\\
  0 & 1 & 0 & 0 \\\\
  0 & 0 & 1 & 0 \\\\
  0 & 0 & 0 & -1
  \end{align},
  $$
  where rows and columns are organized as in the quantum concepts guide.
---

# CZ operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies the controlled-Z (CZ) gate to a pair of qubits.$$\begin{align}1 & 0 & 0 & 0 \\\\0 & 1 & 0 & 0 \\\\0 & 0 & 1 & 0 \\\\0 & 0 & 0 & -1\end{align},$$where rows and columns are organized as in the quantum concepts guide.

```qsharp
operation CZ (control : Qubit, target : Qubit) : Unit
```


## Input

### control : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Control qubit for the CZ gate.


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Target qubit for the CZ gate.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Equivalent to:```qsharpControlled Z([control], target);```
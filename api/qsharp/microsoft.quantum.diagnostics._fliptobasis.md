---
uid: Microsoft.Quantum.Diagnostics._flipToBasis
title: _flipToBasis operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: _flipToBasis
qsharp.summary: >-
  Applies unitaries that map $\ket{0}\otimes\cdots\ket{0}$
  to $\ket{\psi_0} \otimes \ket{\psi_{n - 1}}$,
  where $\ket{\psi_k}$ depends on `basis[k]`.

  The correspondence between
  value of `basis[k]` and $\ket{\psi_k}$ is the following:

  - `basis[k]=0` $\rightarrow \ket{0}$.
  - `basis[k]=1` $\rightarrow \ket{1}$.
  - `basis[k]=2` $\rightarrow \ket{+}$.
  - `basis[k]=3` $\rightarrow \ket{i}$ ( +1 eigenstate of Pauli Y ).
---

# _flipToBasis operation

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Applies unitaries that map $\ket{0}\otimes\cdots\ket{0}$to $\ket{\psi_0} \otimes \ket{\psi_{n - 1}}$,where $\ket{\psi_k}$ depends on `basis[k]`.The correspondence betweenvalue of `basis[k]` and $\ket{\psi_k}$ is the following:- `basis[k]=0` $\rightarrow \ket{0}$.- `basis[k]=1` $\rightarrow \ket{1}$.- `basis[k]=2` $\rightarrow \ket{+}$.- `basis[k]=3` $\rightarrow \ket{i}$ ( +1 eigenstate of Pauli Y ).

```Q#
_flipToBasis (basis : Int[], qubits : Qubit[]) : Unit
```


## Input

### qubits : Qubit[]

Qubit to be operated on.


### basis : Int[]

Array of single-qubit basis state IDs (0 <= id <= 3), one for each element ofqubits.


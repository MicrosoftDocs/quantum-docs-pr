---
uid: Microsoft.Quantum.Preparation.PreparePauliEigenstate
title: PreparePauliEigenstate operation
ms.date: 1/23/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: PreparePauliEigenstate
qsharp.summary: >-
  Prepares a qubit in the positive eigenstate of a given Pauli operator.
  If the identity operator is given, then the qubit is prepared in the maximally
  mixed state.
---

# PreparePauliEigenstate operation

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Prepares a qubit in the positive eigenstate of a given Pauli operator.If the identity operator is given, then the qubit is prepared in the maximallymixed state.

```qsharp
operation PreparePauliEigenstate (basis : Pauli, qubit : Qubit) : Unit
```


## Description

If the qubit was initially in the $\ket{0}$ state, this operation prepares thequbit in the $+1$ eigenstate of a given Pauli operator, or, for `PauliI`,in the maximally mixed state instead (see <xref:microsoft.quantum.preparation.preparesinglequbitidentity>).If the qubit was in a state other than $\ket{0}$, this operation applies the following gates:$H$ for `PauliX`, $HS$ for `PauliY`, $I$ for `PauliZ` and<xref:microsoft.quantum.preparation.preparesinglequbitidentity> for `PauliI`.

## Input

### basis : [Pauli](xref:microsoft.quantum.lang-ref.pauli)

A Pauli operator $P$.


### qubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

A qubit to be prepared.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Example

To prepare a qubit in the $\ket{+}$ state:```qsharpusing (q = Qubit()) {    PreparePauliEigenstate(PauliX, qubit);    // ...}```
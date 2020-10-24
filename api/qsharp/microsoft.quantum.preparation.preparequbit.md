---
uid: Microsoft.Quantum.Preparation.PrepareQubit
title: PrepareQubit operation
ms.date: 10/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: PrepareQubit
qsharp.summary: >-
  Prepares a qubit in the +1 (`Zero`) eigenstate of the given Pauli operator.
  If the identity operator is given, then the qubit is prepared in the maximally
  mixed state.

  If the qubit was initially in the $\ket{0}$ state, this operation prepares the
  qubit in the $+1$ eigenstate of a given Pauli operator, or, for `PauliI`,
  in the maximally mixed state instead (see <xref:microsoft.quantum.preparation.preparesinglequbitidentity>).

  If the qubit was in a state other than $\ket{0}$, this operation applies the following gates:
  $H$ for `PauliX`, $HS$ for `PauliY`, $I$ for `PauliZ` and
  <xref:microsoft.quantum.preparation.preparesinglequbitidentity> for `PauliI`.
---

# PrepareQubit operation

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [](https://nuget.org/packages/)


Prepares a qubit in the +1 (`Zero`) eigenstate of the given Pauli operator.If the identity operator is given, then the qubit is prepared in the maximallymixed state.If the qubit was initially in the $\ket{0}$ state, this operation prepares thequbit in the $+1$ eigenstate of a given Pauli operator, or, for `PauliI`,in the maximally mixed state instead (see <xref:microsoft.quantum.preparation.preparesinglequbitidentity>).If the qubit was in a state other than $\ket{0}$, this operation applies the following gates:$H$ for `PauliX`, $HS$ for `PauliY`, $I$ for `PauliZ` and<xref:microsoft.quantum.preparation.preparesinglequbitidentity> for `PauliI`.

```qsharp
operation PrepareQubit (basis : Pauli, qubit : Qubit) : Unit
```


## Input

### basis : [Pauli](xref:microsoft.quantum.lang-ref.pauli)

A Pauli operator $P$.


### qubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

A qubit to be prepared.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


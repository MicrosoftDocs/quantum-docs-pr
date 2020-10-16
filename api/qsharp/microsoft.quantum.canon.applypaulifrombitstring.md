---
uid: Microsoft.Quantum.Canon.ApplyPauliFromBitString
title: ApplyPauliFromBitString operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyPauliFromBitString
qsharp.summary: >-
  Applies a Pauli operator on each qubit in an array if the corresponding
  bit of a Boolean array matches a given input.
---

# ApplyPauliFromBitString operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a Pauli operator on each qubit in an array if the correspondingbit of a Boolean array matches a given input.

```Q#
ApplyPauliFromBitString (pauli : Pauli, bitApply : Bool, bits : Bool[], qubits : Qubit[]) : Unit
```


## Input

### pauli : Pauli

Pauli operator to apply to `qubits[idx]` where `bitsApply == bits[idx]`


### bitApply : Bool

apply Pauli if bit is this value


### bits : Bool[]

Boolean register specifying which corresponding qubit in `qubits` should be operated on


### qubits : Qubit[]

Quantum register on which to selectively apply the specified Pauli operator



## Remarks

The Boolean array and the quantum register must be of equal length.
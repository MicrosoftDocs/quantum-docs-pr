---
uid: Microsoft.Quantum.Canon.ApplyPauliFromBitString
title: ApplyPauliFromBitString operation
ms.date: 11/25/2020 12:00:00 AM
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies a Pauli operator on each qubit in an array if the correspondingbit of a Boolean array matches a given input.

```qsharp
operation ApplyPauliFromBitString (pauli : Pauli, bitApply : Bool, bits : Bool[], qubits : Qubit[]) : Unit is Adj + Ctl
```


## Input

### pauli : [Pauli](xref:microsoft.quantum.user-guide.language.types)

Pauli operator to apply to `qubits[idx]` where `bitsApply == bits[idx]`


### bitApply : [Bool](xref:microsoft.quantum.user-guide.language.types)

apply Pauli if bit is this value


### bits : [Bool](xref:microsoft.quantum.user-guide.language.types)[]

Boolean register specifying which corresponding qubit in `qubits` should be operated on


### qubits : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[]

Quantum register on which to selectively apply the specified Pauli operator



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## Remarks

The Boolean array and the quantum register must be of equal length.
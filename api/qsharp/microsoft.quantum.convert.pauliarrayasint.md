---
uid: Microsoft.Quantum.Convert.PauliArrayAsInt
title: PauliArrayAsInt function
ms.date: 2/3/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Convert
qsharp.name: PauliArrayAsInt
qsharp.summary: >-
  Encodes a multi-qubit Pauli operator represented as an array of
  single-qubit Pauli operators into an integer.
---

# PauliArrayAsInt function

Namespace: [Microsoft.Quantum.Convert](xref:Microsoft.Quantum.Convert)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Encodes a multi-qubit Pauli operator represented as an array ofsingle-qubit Pauli operators into an integer.

```qsharp
function PauliArrayAsInt (paulis : Pauli[]) : Int
```


## Input

### paulis : [Pauli](xref:microsoft.quantum.lang-ref.pauli)[]

An array of at most 31 single-qubit Pauli operators.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

An integer uniquely identifying `paulis`, as described below.

## Remarks

Each Pauli operator can be encoded using two bits:$$\begin{align}\boldone \mapsto 00, \quad X \mapsto 01, \quad Y \mapsto 11,\quad Z \mapsto 10.\end{align}$$Given an array of Pauli operators `[P0, ..., Pn]`, this function returns aninteger with binary expansion formed by concatenatingthe mappings of each Pauli operator in big-endian order`bits(Pn) ... bits(P0)`.
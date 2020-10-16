---
uid: Microsoft.Quantum.Canon.EmbedPauli
title: EmbedPauli function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: EmbedPauli
qsharp.summary: >-
  Given a single-qubit Pauli operator and the index of a qubit,
  returns a multi-qubit Pauli operator with the given single-qubit
  operator at that index and `PauliI` at every other index.
---

# EmbedPauli function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Given a single-qubit Pauli operator and the index of a qubit,returns a multi-qubit Pauli operator with the given single-qubitoperator at that index and `PauliI` at every other index.

```Q#
EmbedPauli (pauli : Pauli, location : Int, n : Int) : Pauli[]
```


## Input

### pauli : Pauli

A single-qubit Pauli operator to be placed at the given location.


### location : Int

An index such that `output[location] == pauli`, where `output` isthe output of this function.


### n : Int

Length of the array to be returned.


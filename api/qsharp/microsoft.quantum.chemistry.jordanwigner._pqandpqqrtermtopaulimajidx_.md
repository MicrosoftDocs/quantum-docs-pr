---
uid: Microsoft.Quantum.Chemistry.JordanWigner._PQandPQQRTermToPauliMajIdx_
title: _PQandPQQRTermToPauliMajIdx_ function
ms.date: 11/5/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner
qsharp.name: _PQandPQQRTermToPauliMajIdx_
qsharp.summary: >-
  Converts a GeneratorIndex describing a PQ or PQQR term to
  an expression 'GeneratorIndex[]' in terms of Paulis
---

# _PQandPQQRTermToPauliMajIdx_ function

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner](xref:Microsoft.Quantum.Chemistry.JordanWigner)

Package: [](https://nuget.org/packages/)


Converts a GeneratorIndex describing a PQ or PQQR term toan expression 'GeneratorIndex[]' in terms of Paulis

```qsharp
function _PQandPQQRTermToPauliMajIdx_ (term : Microsoft.Quantum.Simulation.GeneratorIndex) : Microsoft.Quantum.Chemistry.JordanWigner.OptimizedBETermIndex
```


## Input

### term : [GeneratorIndex](xref:Microsoft.Quantum.Simulation.GeneratorIndex)

`GeneratorIndex` representing a PQ or PQQR term.



## Output : [OptimizedBETermIndex](xref:Microsoft.Quantum.Chemistry.JordanWigner.OptimizedBETermIndex)

'GeneratorIndex[]' expressing PQ or PQQR term as Pauli terms.
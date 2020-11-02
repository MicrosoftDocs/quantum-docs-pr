---
uid: Microsoft.Quantum.ErrorCorrection.TableLookupRecovery
title: TableLookupRecovery function
ms.date: 11/2/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: TableLookupRecovery
qsharp.summary: >-
  For a given table of Pauli operations on a given register of qubits, this function
  returns an object of type `RecoveryFn` which contains all information needed to
  perform a table-lookup decoding with respect to the given array of Pauli operations.
---

# TableLookupRecovery function

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [](https://nuget.org/packages/)


For a given table of Pauli operations on a given register of qubits, this functionreturns an object of type `RecoveryFn` which contains all information needed toperform a table-lookup decoding with respect to the given array of Pauli operations.

```qsharp
function TableLookupRecovery (table : Pauli[][]) : Microsoft.Quantum.ErrorCorrection.RecoveryFn
```


## Input

### table : [Pauli](xref:microsoft.quantum.lang-ref.pauli)[][]

Table of Pauli operations that operate on a given qubit register



## Output : [RecoveryFn](xref:Microsoft.Quantum.ErrorCorrection.RecoveryFn)

An object of type `RecoveryFn`, i.e., a map `Syndrome -> Pauli[]` that associateswith a given syndrome array a corresponding Pauli correction operation.
---
uid: Microsoft.Quantum.Research.Chemistry._DeltaParityCNOTbitstring
title: _DeltaParityCNOTbitstring function
ms.date: 11/17/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Research.Chemistry
qsharp.name: _DeltaParityCNOTbitstring
qsharp.summary: >-
  Classical processing step of `ApplyDeltaParity`.
  This computes a list of control qubits for evaluating parity
  difference between any two PQRS... terms of even length.
---

# _DeltaParityCNOTbitstring function

Namespace: [Microsoft.Quantum.Research.Chemistry](xref:Microsoft.Quantum.Research.Chemistry)

Package: [Microsoft.Quantum.Research.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Research.Chemistry)


Classical processing step of `ApplyDeltaParity`.This computes a list of control qubits for evaluating paritydifference between any two PQRS... terms of even length.

```qsharp
function _DeltaParityCNOTbitstring (prevFermionicTerm : Int[], nextFermionicTerm : Int[]) : (Int, Bool[])
```


## Input

### prevFermionicTerm : [Int](xref:microsoft.quantum.lang-ref.int)[]




### nextFermionicTerm : [Int](xref:microsoft.quantum.lang-ref.int)[]





## Output : ([Int](xref:microsoft.quantum.lang-ref.int),[Bool](xref:microsoft.quantum.lang-ref.bool)[])



## Remarks

This assumes that the length of terms is even.Computes list of controls for parity difference between any two terms.This assumes that the input lists is sorted in ascending order.
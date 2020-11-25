---
uid: Microsoft.Quantum.Chemistry.JordanWigner._ComputeJordanWignerBitString
title: _ComputeJordanWignerBitString function
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner
qsharp.name: _ComputeJordanWignerBitString
qsharp.summary: >-
  Computes Z component of Jordan–Wigner string between
  fermion indices in a fermionic operator with an even
  number of creation / annihilation operators.
---

# _ComputeJordanWignerBitString function

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner](xref:Microsoft.Quantum.Chemistry.JordanWigner)

Package: [Microsoft.Quantum.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Chemistry)


Computes Z component of Jordan–Wigner string betweenfermion indices in a fermionic operator with an evennumber of creation / annihilation operators.

```qsharp
function _ComputeJordanWignerBitString (nFermions : Int, idxFermions : Int[]) : Bool[]
```


## Input

### nFermions : [Int](xref:microsoft.quantum.user-guide.language.types)

The Number of fermions in the system.


### idxFermions : [Int](xref:microsoft.quantum.user-guide.language.types)[]

fermionic operator indices.



## Output : [Bool](xref:microsoft.quantum.user-guide.language.types)[]

Bitstring `Bool[]` that is `true` where a `PauliZ` should be applied.
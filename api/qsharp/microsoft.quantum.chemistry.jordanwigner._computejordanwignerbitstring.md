---
uid: Microsoft.Quantum.Chemistry.JordanWigner._ComputeJordanWignerBitString
title: _ComputeJordanWignerBitString function
ms.date: 10/16/2020 12:00:00 AM
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

Package: [](https://nuget.org/packages/)


Computes Z component of Jordan–Wigner string betweenfermion indices in a fermionic operator with an evennumber of creation / annihilation operators.

```Q#
_ComputeJordanWignerBitString (nFermions : Int, idxFermions : Int[]) : Bool[]
```


## Input

### nFermions : Int

The Number of fermions in the system.


### idxFermions : Int[]

fermionic operator indices.



## Output

Bitstring `Bool[]` that is `true` where a `PauliZ` should be applied.
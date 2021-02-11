---
uid: Microsoft.Quantum.Simulation.BlockEncodingToReflection
title: BlockEncodingToReflection function
ms.date: 2/11/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: BlockEncodingToReflection
qsharp.summary: >-
  Converts a `BlockEncoding` into an equivalent `BLockEncodingReflection`.

  That is, given a `BlockEncoding` unitary $U$ that encodes some
  operator $H$ of interest, converts it into a `BlockEncodingReflection` $U'$ that
  encodes the same operator, but also satisfies $U'^\dagger = U'$.
  This increases the size of the auxiliary register of $U$ by one qubit.
---

# BlockEncodingToReflection function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Converts a `BlockEncoding` into an equivalent `BLockEncodingReflection`.That is, given a `BlockEncoding` unitary $U$ that encodes someoperator $H$ of interest, converts it into a `BlockEncodingReflection` $U'$ thatencodes the same operator, but also satisfies $U'^\dagger = U'$.This increases the size of the auxiliary register of $U$ by one qubit.

```qsharp
function BlockEncodingToReflection (blockEncoding : Microsoft.Quantum.Simulation.BlockEncoding) : Microsoft.Quantum.Simulation.BlockEncodingReflection
```


## Input

### blockEncoding : [BlockEncoding](xref:Microsoft.Quantum.Simulation.BlockEncoding)

A `BlockEncoding` unitary $U$ to be converted into a reflection.



## Output : [BlockEncodingReflection](xref:Microsoft.Quantum.Simulation.BlockEncodingReflection)

A unitary $U'$ acting jointly on registers `a` and `s` that block-encodes $H$, and satisfies $U'^\dagger = U'$.

## Remarks

This increases the size of the auxiliary register of $U$ by one qubit.

## References

- Hamiltonian Simulation by Qubitization  Guang Hao Low, Isaac L. Chuang  https://arxiv.org/abs/1610.06546

## See Also

- [Microsoft.Quantum.Simulation.BlockEncoding](xref:Microsoft.Quantum.Simulation.BlockEncoding)
- [Microsoft.Quantum.Simulation.BlockEncodingReflection](xref:Microsoft.Quantum.Simulation.BlockEncodingReflection)
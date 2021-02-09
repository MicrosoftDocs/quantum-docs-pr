---
uid: Microsoft.Quantum.Synthesis.ApplyPermutationUsingDecompositionWithVariableOrder
title: ApplyPermutationUsingDecompositionWithVariableOrder operation
ms.date: 2/9/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: ApplyPermutationUsingDecompositionWithVariableOrder
qsharp.summary: >-
  Permutes the amplitudes in a quantum state given a permutation
  using decomposition-based synthesis.
---

# ApplyPermutationUsingDecompositionWithVariableOrder operation

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Permutes the amplitudes in a quantum state given a permutationusing decomposition-based synthesis.

```qsharp
operation ApplyPermutationUsingDecompositionWithVariableOrder (perm : Int[], variableOrder : Int[], qubits : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit is Adj + Ctl
```


## Description

This operation is a more general version of @"microsoft.quantum.synthesis.applypermutationusingdecomposition"in which the variable order can be specified. A different variable orderchanges the decomposition sequence and the truth tables used for thecontrolled @"microsoft.quantum.intrinsic.x" gates.  Therefore, changing thevariable order changes the number of overall gates used to realize thepermutation.

## Input

### perm : [Int](xref:microsoft.quantum.lang-ref.int)[]

A permutation of $2^n$ elements starting from 0.


### variableOrder : [Int](xref:microsoft.quantum.lang-ref.int)[]

A permutation of $n$ elements starting from 0.


### qubits : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

A list of $n$ qubits to which the permutation is applied to.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Example

To synthesize a `SWAP` operation:```qsharpusing (qubits = Qubit[2]) {  ApplyPermutationUsingDecompositionWithVariableOrder([0, 2, 1, 3], [1, 0], LittleEndian(qubits));}```

## See Also

- [Microsoft.Quantum.Synthesis.ApplyPermutationUsingDecomposition](xref:Microsoft.Quantum.Synthesis.ApplyPermutationUsingDecomposition)
- [Microsoft.Quantum.Synthesis.ApplyPermutationUsingTransformation](xref:Microsoft.Quantum.Synthesis.ApplyPermutationUsingTransformation)
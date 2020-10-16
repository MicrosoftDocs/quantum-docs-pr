---
uid: Microsoft.Quantum.Diagnostics.AssertOperationsEqualInPlace
title: AssertOperationsEqualInPlace operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: AssertOperationsEqualInPlace
qsharp.summary: >-
  Given two operations, asserts that they act identically for all input states.

  This assertion is implemented by checking the action of the operations
  on all states of the form $V_0 \otimes ... \otimes V_{n-1}$, where
  $V_k$ is one of the states $\ket{0}$, $\ket{1}$, $\ket{+}$ and $\ket{i}$ (+1 eigenstate of Pauli Y operator).

  This assertion uses $n$ qubits and requires multiple calls of the operations being compared.
---

# AssertOperationsEqualInPlace operation

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Given two operations, asserts that they act identically for all input states.This assertion is implemented by checking the action of the operationson all states of the form $V_0 \otimes ... \otimes V_{n-1}$, where$V_k$ is one of the states $\ket{0}$, $\ket{1}$, $\ket{+}$ and $\ket{i}$ (+1 eigenstate of Pauli Y operator).This assertion uses $n$ qubits and requires multiple calls of the operations being compared.

```Q#
AssertOperationsEqualInPlace (nQubits : Int, givenU : (Qubit[] => Unit), expectedU : (Qubit[] => Unit is Adj)) : Unit
```


## Input

### nQubits : Int

The number of qubits $n$ that the operations `givenU` and `expectedU` operate on.


### givenU : Qubit[] => Unit 

Operation on $n$ qubits to be checked.


### expectedU : Qubit[] => Unit Adj

Reference operation on $n$ qubits that `givenU` is to be compared against.



## References

The basis of states $\ket{0}$, $\ket{1}$, $\ket{+}$ and $\ket{i}$ is the Chuang-Nielsen basis,described in [ *I. L. Chuang, M. A. Nielsen* ](https://arxiv.org/abs/quant-ph/9610001).

## See Also

- [Microsoft.Quantum.Diagnostics.AssertOperationsEqualReferenced](xref:Microsoft.Quantum.Diagnostics.AssertOperationsEqualReferenced)
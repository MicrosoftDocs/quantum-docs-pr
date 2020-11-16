---
uid: Microsoft.Quantum.Diagnostics.AssertOperationsEqualReferenced
title: AssertOperationsEqualReferenced operation
ms.date: 11/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: AssertOperationsEqualReferenced
qsharp.summary: >-
  Given two operations, asserts that they act identically for all input states.

  This assertion is implemented by using the Choi–Jamiołkowski isomorphism to reduce
  the assertion to one of a qubit state assertion on two entangled registers.
  Thus, this operation needs only a single call to each operation being tested,
  but requires twice as many qubits to be allocated.
  This assertion can be used to ensure, for instance, that an optimized version of an
  operation acts identically to its naïve implementation, or that an operation
  which acts on a range of non-quantum inputs agrees with known cases.
---

# AssertOperationsEqualReferenced operation

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Given two operations, asserts that they act identically for all input states.This assertion is implemented by using the Choi–Jamiołkowski isomorphism to reducethe assertion to one of a qubit state assertion on two entangled registers.Thus, this operation needs only a single call to each operation being tested,but requires twice as many qubits to be allocated.This assertion can be used to ensure, for instance, that an optimized version of anoperation acts identically to its naïve implementation, or that an operationwhich acts on a range of non-quantum inputs agrees with known cases.

```qsharp
operation AssertOperationsEqualReferenced (nQubits : Int, actual : (Qubit[] => Unit), expected : (Qubit[] => Unit is Adj)) : Unit
```


## Input

### nQubits : [Int](xref:microsoft.quantum.lang-ref.int)

Number of qubits to pass to each operation.


### actual : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) 

Operation to be tested.


### expected : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj

Operation defining the expected behavior for the operation under test.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

This operation requires that the operation modeling the expected behavior isadjointable, so that the inverse can be performed on the target register alone.Formally, one can specify a transpose operation, which relaxes this requirement,but the transpose operation is not in general physically realizable for arbitraryquantum operations and thus is not included here as an option.
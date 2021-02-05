---
uid: Microsoft.Quantum.ErrorCorrection.MeasureStabilizerGenerators
title: MeasureStabilizerGenerators operation
ms.date: 2/5/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: MeasureStabilizerGenerators
qsharp.summary: Measures the given set of generators of a stabilizer group.
---

# MeasureStabilizerGenerators operation

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Measures the given set of generators of a stabilizer group.

```qsharp
operation MeasureStabilizerGenerators (stabilizerGroup : Pauli[][], logicalRegister : Microsoft.Quantum.ErrorCorrection.LogicalRegister, gadget : ((Pauli[], Qubit[]) => Result)) : Microsoft.Quantum.ErrorCorrection.Syndrome
```


## Input

### stabilizerGroup : [Pauli](xref:microsoft.quantum.lang-ref.pauli)[][]

An array of multiqubit Pauli operators.For example, `stabilizerGroup[0]` is a list of single-qubit Pauli matrices,the tensor product of which is a stabilizer generator.


### logicalRegister : [LogicalRegister](xref:Microsoft.Quantum.ErrorCorrection.LogicalRegister)

An array of qubits where the stabilizer code is defined.


### gadget : ([Pauli](xref:microsoft.quantum.lang-ref.pauli)[],[Qubit](xref:microsoft.quantum.lang-ref.qubit)[]) => __invalid<Result>__ 

An operation that specifies how to measure a multiqubit Pauli operator.



## Output : [Syndrome](xref:Microsoft.Quantum.ErrorCorrection.Syndrome)

The result of measurements.

## Remarks

This does not check if the given set of generators are commuting.If they are not commuting, the result of measurements may be arbitrary.
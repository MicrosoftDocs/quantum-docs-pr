---
uid: Microsoft.Quantum.Diagnostics.AssertMeasurement
title: AssertMeasurement operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: AssertMeasurement
qsharp.summary: >-
  Asserts that measuring the given qubits in the given Pauli basis will
  always have the given result.
---

# AssertMeasurement operation

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Asserts that measuring the given qubits in the given Pauli basis willalways have the given result.

```Q#
AssertMeasurement (bases : Pauli[], qubits : Qubit[], result : Result, msg : String) : Unit
```


## Input

### bases : Pauli[]

A measurement effect to assert the probability of, expressed as amulti-qubit Pauli operator.


### qubits : Qubit[]

A register on which to make the assertion.


### result : __invalid<Result>__

The expected result of `Measure(bases, qubits)`.


### msg : String

A message to be reported if the assertion fails.



## Remarks

Note that the Adjoint and Controlled versions of this operation will notcheck the condition.

## See Also

- [Microsoft.Quantum.Diagnostics.AssertMeasurementProbability](xref:Microsoft.Quantum.Diagnostics.AssertMeasurementProbability)
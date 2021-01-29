---
uid: Microsoft.Quantum.Diagnostics.AssertMeasurement
title: AssertMeasurement operation
ms.date: 1/29/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: AssertMeasurement
qsharp.summary: >-
  Asserts that measuring the given qubits in the given Pauli basis will
  always have the given result.
---

# AssertMeasurement operation

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Asserts that measuring the given qubits in the given Pauli basis willalways have the given result.

```qsharp
operation AssertMeasurement (bases : Pauli[], qubits : Qubit[], result : Result, msg : String) : Unit is Adj + Ctl
```


## Input

### bases : [Pauli](xref:microsoft.quantum.lang-ref.pauli)[]

A measurement effect to assert the probability of, expressed as amulti-qubit Pauli operator.


### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A register on which to make the assertion.


### result : __invalid<Result>__

The expected result of `Measure(bases, qubits)`.


### msg : [String](xref:microsoft.quantum.lang-ref.string)

A message to be reported if the assertion fails.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Note that the Adjoint and Controlled versions of this operation will notcheck the condition.

## See Also

- [Microsoft.Quantum.Diagnostics.AssertMeasurementProbability](xref:Microsoft.Quantum.Diagnostics.AssertMeasurementProbability)
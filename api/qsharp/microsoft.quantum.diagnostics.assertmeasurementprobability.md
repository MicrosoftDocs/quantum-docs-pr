---
uid: Microsoft.Quantum.Diagnostics.AssertMeasurementProbability
title: AssertMeasurementProbability operation
ms.date: 2/11/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: AssertMeasurementProbability
qsharp.summary: >-
  Asserts that measuring the given qubits in the given Pauli basis will have the given result
  with the given probability, within some tolerance.
---

# AssertMeasurementProbability operation

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Asserts that measuring the given qubits in the given Pauli basis will have the given resultwith the given probability, within some tolerance.

```qsharp
operation AssertMeasurementProbability (bases : Pauli[], qubits : Qubit[], result : Result, prob : Double, msg : String, tol : Double) : Unit is Adj + Ctl
```


## Input

### bases : [Pauli](xref:microsoft.quantum.lang-ref.pauli)[]

A measurement effect to assert the probability of, expressed as amulti-qubit Pauli operator.


### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A register on which to make the assertion.


### result : __invalid<Result>__

An expected result of `Measure(bases, qubits)`.


### prob : [Double](xref:microsoft.quantum.lang-ref.double)

The probability with which the given result is expected.


### msg : [String](xref:microsoft.quantum.lang-ref.string)

A message to be reported if the assertion fails.


### tol : [Double](xref:microsoft.quantum.lang-ref.double)





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Example

```qsharpusing (register = Qubit()) {    H(register);    AssertProb([PauliZ], [register], One, 0.5,        "Measuring in conjugate basis did not give 50/50 results.", 1e-5);}```

## Remarks

Note that the Adjoint and Controlled versions of this operation will notcheck the condition.

## See Also

- [Microsoft.Quantum.Diagnostics.AssertMeasurement](xref:Microsoft.Quantum.Diagnostics.AssertMeasurement)
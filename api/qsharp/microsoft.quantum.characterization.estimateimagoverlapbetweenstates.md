---
uid: Microsoft.Quantum.Characterization.EstimateImagOverlapBetweenStates
title: EstimateImagOverlapBetweenStates operation
ms.date: 12/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Characterization
qsharp.name: EstimateImagOverlapBetweenStates
qsharp.summary: >-
  Given two operations which each prepare copies of a state, estimates
  the imaginary part of the overlap between the states prepared by each
  operation.
---

# EstimateImagOverlapBetweenStates operation

Namespace: [Microsoft.Quantum.Characterization](xref:Microsoft.Quantum.Characterization)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given two operations which each prepare copies of a state, estimatesthe imaginary part of the overlap between the states prepared by eachoperation.

```qsharp
operation EstimateImagOverlapBetweenStates (commonPreparation : (Qubit[] => Unit is Adj), preparation1 : (Qubit[] => Unit is Adj + Ctl), preparation2 : (Qubit[] => Unit is Adj + Ctl), nQubits : Int, nMeasurements : Int) : Double
```


## Input

### commonPreparation : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj

An operation that prepares a fixed input state.


### preparation1 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

The first of the two state preparation operations to be compared.


### preparation2 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

The second of the two state preparation operations to be compared.


### nQubits : [Int](xref:microsoft.quantum.lang-ref.int)

The number of qubits on which `commonPreparation`, `preparation1`, and`preparation2` all act.


### nMeasurements : [Int](xref:microsoft.quantum.lang-ref.int)

The number of measurements to use in estimating the overlap.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)



## Remarks

This operation uses the Hadamard test to find the imaginary part of$$\begin{align}\braket{\psi | V^{\dagger} U | \psi}\end{align}$$where $\ket{\psi}$ is the state prepared by `commonPreparation`,$U$ is the unitary representation of the action of `preparation1`,and where $V$ corresponds to `preparation2`.

## References

- Aharonov *et al.* [quant-ph/0511096](https://arxiv.org/abs/quant-ph/0511096).

## See Also

- [Microsoft.Quantum.Characterization.EstimateRealOverlapBetweenStates](xref:Microsoft.Quantum.Characterization.EstimateRealOverlapBetweenStates)
- [Microsoft.Quantum.Characterization.EstimateOverlapBetweenStates](xref:Microsoft.Quantum.Characterization.EstimateOverlapBetweenStates)
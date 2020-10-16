---
uid: Microsoft.Quantum.Characterization.EstimateRealOverlapBetweenStates
title: EstimateRealOverlapBetweenStates operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Characterization
qsharp.name: EstimateRealOverlapBetweenStates
qsharp.summary: >-
  Given two operations which each prepare copies of a state, estimates
  the real part of the overlap between the states prepared by each
  operation.
---

# EstimateRealOverlapBetweenStates operation

Namespace: [Microsoft.Quantum.Characterization](xref:Microsoft.Quantum.Characterization)

Package: [](https://nuget.org/packages/)


Given two operations which each prepare copies of a state, estimatesthe real part of the overlap between the states prepared by eachoperation.

```Q#
EstimateRealOverlapBetweenStates (commonPreparation : (Qubit[] => Unit is Adj), preparation1 : (Qubit[] => Unit is Adj + Ctl), preparation2 : (Qubit[] => Unit is Adj + Ctl), nQubits : Int, nMeasurements : Int) : Double
```


## Input

### commonPreparation : Qubit[] => Unit Adj

An operation that prepares a fixed input state.


### preparation1 : Qubit[] => Unit Adj + Ctl

The first of the two state preparation operations to be compared.


### preparation2 : Qubit[] => Unit Adj + Ctl

The second of the two state preparation operations to be compared.


### nQubits : Int

The number of qubits on which `commonPreparation`, `preparation1`, and`preparation2` all act.


### nMeasurements : Int

The number of measurements to use in estimating the overlap.



## Remarks

This operation uses the Hadamard test to find the real part of$$\begin{align}\braket{\psi | V^{\dagger} U | \psi}\end{align}$$where $\ket{\psi}$ is the state prepared by `commonPreparation`,$U$ is the unitary representation of the action of `preparation1`,and where $V$ corresponds to `preparation2`.

## References

- Aharonov *et al.* [quant-ph/0511096](https://arxiv.org/abs/quant-ph/0511096).

## See Also

- [Microsoft.Quantum.Characterization.EstimateImagOverlapBetweenStates](xref:Microsoft.Quantum.Characterization.EstimateImagOverlapBetweenStates)
- [Microsoft.Quantum.Characterization.EstimateOverlapBetweenStates](xref:Microsoft.Quantum.Characterization.EstimateOverlapBetweenStates)
---
uid: Microsoft.Quantum.Characterization.EstimateOverlapBetweenStates
title: EstimateOverlapBetweenStates operation
ms.date: 12/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Characterization
qsharp.name: EstimateOverlapBetweenStates
qsharp.summary: >-
  Given two operations which each prepare copies of a state, estimates
  the squared overlap between the states prepared by each
  operation.
---

# EstimateOverlapBetweenStates operation

Namespace: [Microsoft.Quantum.Characterization](xref:Microsoft.Quantum.Characterization)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given two operations which each prepare copies of a state, estimatesthe squared overlap between the states prepared by eachoperation.

```qsharp
operation EstimateOverlapBetweenStates (preparation1 : (Qubit[] => Unit is Adj), preparation2 : (Qubit[] => Unit is Adj), nQubits : Int, nMeasurements : Int) : Double
```


## Input

### preparation1 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj

The first of the two state preparation operations to be compared.


### preparation2 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj

The second of the two state preparation operations to be compared.


### nQubits : [Int](xref:microsoft.quantum.lang-ref.int)

The number of qubits on which `commonPreparation`, `preparation1`, and`preparation2` all act.


### nMeasurements : [Int](xref:microsoft.quantum.lang-ref.int)

The number of measurements to use in estimating the overlap.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)



## Remarks

This operation uses the SWAP test to find$$\begin{align}\left| \braket{00\cdots 0 | V^{\dagger} U | 00\cdots 0} \right|^2\end{align}$$where $U$ is the unitary representation of the action of `preparation1`,and where $V$ corresponds to `preparation2`.

## See Also

- [Microsoft.Quantum.Characterization.EstimateRealOverlapBetweenStates](xref:Microsoft.Quantum.Characterization.EstimateRealOverlapBetweenStates)
- [Microsoft.Quantum.Characterization.EstimateImagOverlapBetweenStates](xref:Microsoft.Quantum.Characterization.EstimateImagOverlapBetweenStates)
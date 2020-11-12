---
uid: Microsoft.Quantum.Research.Characterization.RandomWalkPhaseEstimation
title: RandomWalkPhaseEstimation operation
ms.date: 11/12/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Research.Characterization
qsharp.name: RandomWalkPhaseEstimation
qsharp.summary: >-
  Performs iterative phase estimation using a random walk to approximate
  Bayesian inference on the classical measurement results from a given
  oracle and eigenstate.
---

# RandomWalkPhaseEstimation operation

Namespace: [Microsoft.Quantum.Research.Characterization](xref:Microsoft.Quantum.Research.Characterization)

Package: [Microsoft.Quantum.Research.Characterization](https://nuget.org/packages/Microsoft.Quantum.Research.Characterization)


Performs iterative phase estimation using a random walk to approximateBayesian inference on the classical measurement results from a givenoracle and eigenstate.

```qsharp
operation RandomWalkPhaseEstimation (initialMean : Double, initialStdDev : Double, nMeasurements : Int, maxMeasurements : Int, unwind : Int, oracle : Microsoft.Quantum.Oracles.ContinuousOracle, targetState : Qubit[]) : Double
```


## Input

### initialMean : [Double](xref:microsoft.quantum.lang-ref.double)

Mean of the initial normal prior distribution over $\phi$.


### initialStdDev : [Double](xref:microsoft.quantum.lang-ref.double)

Standard deviation of the initial normal prior distribution over $\phi$.


### nMeasurements : [Int](xref:microsoft.quantum.lang-ref.int)

Number of measurements to be accepted into the final posterior estimate.


### maxMeasurements : [Int](xref:microsoft.quantum.lang-ref.int)

Total number of measurements than can be taken before the operation is considered to have failed.


### unwind : [Int](xref:microsoft.quantum.lang-ref.int)

Number of results to forget when consistency checks fail.


### oracle : [ContinuousOracle](xref:Microsoft.Quantum.Oracles.ContinuousOracle)

An operation representing a unitary $U$ such that $U(t)\ket{\phi} = e^{i t \phi}\ket{\phi}$for eigenstates $\ket{\phi}$ with unknown phase $\phi \in \mathbb{R}^+$.


### targetState : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A register that $U$ acts on.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)

The final estimate $\hat{\phi} \mathrel{:=} \expect[\phi]$ , wherethe expectation is over the posterior given all accepted data.

## Remarks

### Iterative Phase Estimation and EigenstatesIn general, the input register `eigenstate` need not be aneigenstate $\ket{\phi}$ of $U$, but can be a superposition overeigenstates. Suppose that the input state is given by\begin{align}\ket{\psi} & = \sum\_{j} \alpha\_j \ket{\phi\_j},\end{align}where $\{\alpha\_j\}$ are complex coefficients such that$\sum\_j |\alpha\_j|^2 = 1$ and where $U\ket{\phi\_j} = \phi\_j\ket{\phi\_j}$.Then, performing iterative phase estimation will eventually convergeto a single eigenstate, as described in the[development guide](xref:microsoft.quantum.libraries.characterization#iterative-phase-estimation-without-eigenstates).### Experiment DesignThe measurement times $t$ and inversion angles $\theta$passed to `oracle` are chosen according tothe *particle guess heuristic*,\begin{align}\theta \sim \Pr(\phi),\quad t \approx \frac{1}{\variance{\phi}}.\end{align}This heuristic is optimal for reducing the expected posterior variancein iterative phase estimation under the assumption of a normal prior.### OptimalityThis operation approximates the optimal estimator for the phase$\phi$, as evaluated using thequadratic loss $L(\phi, \hat{\phi}) \mathrel{:=} (\phi - \hat{\phi})^2$.See [Bayesian Phase Estimation](xref:microsoft.quantum.libraries.characterization#bayesian-phase-estimation)for more details on the statistics of iterative phase estimation.

## References

- Ferrie *et al.* 2011 [doi:10/tfx](https://doi.org/10.1007/s11128-012-0407-6),  [arXiv:1110.3067](https://arxiv.org/abs/1110.3067).- Wiebe *et al.* 2013 [doi:10/tf3](https://doi.org/10.1103/PhysRevLett.112.190501),  [arXiv:1309.0876](https://arxiv.org/abs/1309.0876)- Wiebe and Granade 2018 *(in preparation)*.
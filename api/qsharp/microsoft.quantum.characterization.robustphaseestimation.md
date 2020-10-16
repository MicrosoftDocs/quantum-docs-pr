---
uid: Microsoft.Quantum.Characterization.RobustPhaseEstimation
title: RobustPhaseEstimation operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Characterization
qsharp.name: RobustPhaseEstimation
qsharp.summary: >-
  Performs the robust non-iterative quantum phase estimation algorithm for a given oracle `U` and eigenstate,
  and provides a single real-valued estimate of the phase with variance scaling at the Heisenberg limit.
---

# RobustPhaseEstimation operation

Namespace: [Microsoft.Quantum.Characterization](xref:Microsoft.Quantum.Characterization)

Package: [](https://nuget.org/packages/)


Performs the robust non-iterative quantum phase estimation algorithm for a given oracle `U` and eigenstate,and provides a single real-valued estimate of the phase with variance scaling at the Heisenberg limit.

```Q#
RobustPhaseEstimation (bitsPrecision : Int, oracle : Microsoft.Quantum.Oracles.DiscreteOracle, targetState : Qubit[]) : Double
```


## Input

### oracle : [DiscreteOracle](xref:Microsoft.Quantum.Oracles.DiscreteOracle)

An operation implementing $U^m$ for given integer powers $m$.


### targetState : Qubit[]

A quantum register that $U$ acts on. If it stores an eigenstate$\ket{\phi}$ of $U$, then $U\ket{\phi} = e^{i\phi} \ket{\phi}$for $\phi\in(-\pi,\pi]$ an unknown phase.


### bitsPrecision : Int

This provides an estimate of $\phi$ with standard deviation$\sigma \le 2\pi / 2^\text{bitsPrecision}$ using a number of queries scaling like $\sigma \le 10.7 \pi / \text{# of queries}$.



## Remarks

In the limit of a large number of queries, Cramer-Rao lower boundsfor the standard deviation of the estimate of $\phi$ satisfy$\sigma \ge 2 \pi / \text{# of queries}$.

## References

- Robust Calibration of a Universal Single-Qubit Gate-Set via Robust Phase Estimation  Shelby Kimmel, Guang Hao Low, Theodore J. Yoder  https://arxiv.org/abs/1502.02677
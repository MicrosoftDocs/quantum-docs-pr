---
uid: Microsoft.Quantum.Characterization.SingleQubitProcessTomographyMeasurement
title: SingleQubitProcessTomographyMeasurement operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Characterization
qsharp.name: SingleQubitProcessTomographyMeasurement
qsharp.summary: >-
  Performs a single-qubit process tomography measurement in the Pauli
  basis, given a particular channel of interest.
---

# SingleQubitProcessTomographyMeasurement operation

Namespace: [Microsoft.Quantum.Characterization](xref:Microsoft.Quantum.Characterization)

Package: [](https://nuget.org/packages/)


Performs a single-qubit process tomography measurement in the Paulibasis, given a particular channel of interest.

```Q#
SingleQubitProcessTomographyMeasurement (preparation : Pauli, measurement : Pauli, channel : (Qubit => Unit)) : Result
```


## Input

### preparation : Pauli

The Pauli basis element $P$ in which a qubit is to be prepared.


### measurement : Pauli

The Pauli basis element $Q$ in which a qubit is to be measured.


### channel : Qubit => Unit 

A single qubit channel $\Lambda$ whose behavior is being estimatedwith process tomography.



## Output

The Result `Zero` with probability$$\begin{align}\Pr(\texttt{Zero} | \Lambda; P, Q) = \operatorname{Tr}\left(\frac{\boldone + Q}{2} \Lambda\left[\frac{\boldone + P}{2}\right]\right).\end{align}$$

## Remarks

The distribution over results returned by this operation is a specialcase of two-qubit state tomography. Let $\rho = J(\Lambda) / 2$ bethe Choi–Jamiłkowski state for $\Lambda$. Then, the distribution aboveis identical to$$\begin{align}\Pr(\texttt{Zero} | \rho; M) = \operatorname{Tr}(M \rho),\end{align}$$where $M = 2 (\boldone + P)^\mathrm{T} / 2 \cdot (\boldone + Q) / 2$is the effective measurement corresponding to $P$ and $Q$.
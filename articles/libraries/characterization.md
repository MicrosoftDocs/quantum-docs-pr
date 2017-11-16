---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: "Q# standard libraries | Microsoft Docs"
description: 115-145 characters including spaces. Edit the intro para describing article intent to fit here. This abstract displays in the search result.
services: service-name-with-dashes-AZURE-ONLY 
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: QuantumWriter
ms.author: MSFT-alias-person-or-DL
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# ms.service: service-name-from-white-list
# product-name-from-white-list

# Optional fields. Don't forget to remove # if you need a field.
# ms.custom: can-be-multiple-comma-separated
# ms.devlang:devlang-from-white-list
# ms.suite: 
# ms.tgt_pltfrm:
# ms.reviewer:
# manager: MSFT-alias-manager-or-PM-counterpart
---


# Quantum Characterization and Statistics #

In developing quantum algorithms, it is critical to be able to characterize the effects of operations.
This is made challenging by the fact that quantum states cannot be learned directly, reflected in that Q# does not expose or even define what a state *is* to quantum programs.
We thus approach quantum characterization by treating operations and states as black-box; this approach shares much in common with the experimental practice of quantum characterization, verification and validation (QCVV).

## Learning Quantum Processes ##

## Iterative Phase Estimation ##

Viewing quantum programming in terms of quantum characterization suggests a useful alternative to [quantum phase estimation](algorithms#quantum-phase-estimation).
That is, instead of preparing an $n$-qubit register to contain a binary representation of the phase as in quantum phase estimation, we can view phase estimation as the process by which a *classical* agent learns properties of a quantum system through measurements.
This has the advantage that we only require a single additional qubit to perform the phase kickback described in the quantum case, as we then measure the control bit and use it to learn the phase in an iterative fashion.

In discussing iterative phase estimation, we will consider a unitary $U$ given as a black-box operation.
As described in the section on [oracles](data-structures#oracles), the Q# canon models such operations by the <xref:microsoft.quantum.canon.discreteoracle> user-defined type, defined by the tuple type `((Int, Qubit[]) => () : Adjoint, Controlled)`.
Concretely, if `U : DiscreteOracle`, then `U(m)` implements $U^m$ for `m : Int`.

With this definition in place, each step of iterative phase estimation proceeds by preparing an auxillary qubit in the $\ket{+}$ state, then using a controlled application of `U(m)` to prepare $R_1(m \phi) \ket{+}$.
The auxillary qubit used as a control for `U(m)` is then measured in the $X$ basis to obtain a single classical `Result`.

At this point, reconstructing the phase from the `Result` values obtained through iterative phase estimation is a classical statistical inference problem.
We emphasize this by briefly describing iterative phase estimation at a theoretical level in the Bayesian parameter estimation formalism before proceeding to describe the statistical algorithms provided in the Q# canon for solving this classical inference problem.

### Bayesian Phase Estimation ###

> [!TIP]
> For more details on Bayesian phase estimation in practice, please see the [**PhaseEstimation**](TODO: link) sample.

Following the above procedure, we can find the probability of observing a `Zero` result.
Note that $X = \ket{+}\bra{+} - \ket{-}\bra{-}$, such that $\ket{+}$ is the only positive eigenstate of $X$ corresponding to `Zero`.
The probability of observing `Zero` for a `PauliX` measurement given an arbitrary state $\ket{\psi}$ is thus
\begin{equation}
    \Pr(\texttt{Zero} | \psi) = \left| \braket{+ | \psi} \right|^2.
\end{equation}
In the case of iterative phase estimation, we have that $\ket{\psi} = R_1(m \phi) \ket{+}$, such that
\begin{align}
    \Pr(\texttt{Zero} | \phi; m)
        & = \left| \braket{+ | R_1(m \phi) | +} \right|^2 \\\\
        & = \left|
            \frac12 \left( \bra{0} + \bra{1} \right) \left( \ket{0} + e^{i m \phi} \ket{1} \right)
            \right|^2 \\\\
        & = \left| \frac{1 + e^{i m \phi}}{2} \right|^2 \\\\
        & = \cos^2(m \phi / 2) \tag{★} \label{eq:phase-est-likelihood}.
\end{align}
That is, iterative phase estimation consists of learning the oscillation frequency of a sinusoidal function, given the ability to flip a coin with a bias given by that sinusoid.
Following traditional classical terminology, we call $\eqref{eq:phase-est-likelihood}$ the *likelihood function* for iterative phase estimation.

Having observed a `Result` from the iterative phase estimation likelihood function, we can then use Bayes' rule to prescribe what we should believe the phase to be following that observation.
Concretely,
\begin{equation}
    \Pr(\phi | d) = \frac{\Pr(d | \phi) \Pr(\phi)}{\int \Pr(d | \phi) \Pr(\phi)\,d\phi} \Pr(\phi),
\end{equation}
where $d \in \\{\texttt{Zero}, \texttt{One}\\}$ is a `Result`, and where $\Pr(\phi)$ describes our prior beliefs about $\phi$.
This then makes the iterative nature of iterative phase estimation explicit, as the posterior distribution $\Pr(\phi | d)$ describes our beliefs immediately preceeding our observation of the next `Result`.

### Robust Phase Estimation ###
<!-- FIXME: though RPE is the correct name of this algorithm, in context it reads as though Bayesian PE is the opposite of robust, which is not the case. -->

### Continuous Oracles ###

### Random Walk Phase Estimation ###

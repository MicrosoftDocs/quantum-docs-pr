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
uid: microsoft.quantum.libraries.characterization
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

It is critical to be able to characterize the effects of operations in order to develop useful quantum algorithms.
This is made challenging by the fact that quantum states cannot be learned directly, reflected in that Q# does not expose or even define what a state *is* to quantum programs.
We thus approach quantum characterization by treating operations and states as black-box; this approach shares much in common with the experimental practice of quantum characterization, verification and validation (QCVV).

## Learning Quantum Processes ##

## Iterative Phase Estimation ##

Viewing quantum programming in terms of quantum characterization suggests a useful alternative to [quantum phase estimation](algorithms#quantum-phase-estimation).
That is, instead of preparing an $n$-qubit register to contain a binary representation of the phase as in quantum phase estimation, we can view phase estimation as the process by which a *classical* agent learns properties of a quantum system through measurements.
We proceed as in the [quantum case](algorithms#quantum-phase-estimation) by using phase kickback to turn applications of a black-box operation into rotations by an unknown angle, but will measure the ancilla qubit that we rotate at each step immediately following the rotation.
This has the advantage that we only require a single additional qubit to perform the phase kickback described in the quantum case, as we then learn the phase from the measurement results at each step in an iterative fashion.
Moreover, it is much easier to include prior information in iterative phase estimation, as we will see below.

In discussing iterative phase estimation, we will consider a unitary $U$ given as a black-box operation.
As described in the section on [oracles](data-structures#oracles), the Q# canon models such operations by the <xref:microsoft.quantum.canon.discreteoracle> user-defined type, defined by the tuple type `((Int, Qubit[]) => () : Adjoint, Controlled)`.
Concretely, if `U : DiscreteOracle`, then `U(m)` implements $U^m$ for `m : Int`.

With this definition in place, each step of iterative phase estimation proceeds by preparing an ancilla qubit in the $\ket{+}$ state, then using a controlled application of `U(m)` to prepare $R_1(m \phi) \ket{+}$.
As in the quantum case, the effect of a controlled application of the oracle `U(m)` is precisely the same as the effect of applying $R_1$ for the unknown phase, such that we can describe the effects of $U$ in this simpler fashion.
The ancilla qubit used as a control for `U(m)` is then measured in the $X$ basis to obtain a single classical `Result`.

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
    \Pr(\phi | d) = \frac{\Pr(d | \phi) \Pr(\phi)}{\int \Pr(d | \phi) \Pr(\phi){\mathrm d}\phi} \Pr(\phi),
\end{equation}
where $d \in \\{\texttt{Zero}, \texttt{One}\\}$ is a `Result`, and where $\Pr(\phi)$ describes our prior beliefs about $\phi$.
This then makes the iterative nature of iterative phase estimation explicit, as the posterior distribution $\Pr(\phi | d)$ describes our beliefs immediately preceeding our observation of the next `Result`.

At any point during this procedure, we can report the phase $\hat{\phi}$ inferred by the classical controller as
\begin{equation}
    \hat{\phi} \mathrel{:=} \expect[\phi | \text{data}] = \int \phi \Pr(\phi | \text{data}) {\mathrm d}\phi,
\end{equation}
where $\text{data}$ stands for the entire record of all `Result` values obtained.

### Calling Phase Estimation Algorithms ###

Each phase estimation operation provided with the Q# canon takes a different set of inputs parameterizing the quality that we demand out of the final estimate $\hat{\phi}$.
These various inputs, however, all share several inputs in common, such that partial application over the quality parameters results in a common signature.
For example, the <xref:microsoft.quantum.canon.robustphaseestimation> operation discussed in the next section has the following signature:

```qsharp
operation RobustPhaseEstimation(bitsPrecision : Int, oracle : DiscreteOracle, eigenstate : Qubit[])  : Double
```

The `bitsPrecision` input is unique to `RobustPhaseEstimation`, while `oracle` and `eigenstate` are in common.
Thus, as seen in **H2Sample**, an operation can accept an iterative phase estimation algorithm with an input of the form `(DiscreteOracle, Qubit[]) => ()` to allow a user to specify arbitrary phase estimation algorithms:

```qsharp
operation H2EstimateEnergy(
        idxBondLength: Int, trotterStepSize: Double,
        phaseEstAlgorithm : ((DiscreteOracle, Qubit[]) => Double)
    ) : Double
```
### Robust Phase Estimation ###

These myriad phase estimation algorithms are optimized for different properties and input parameters, which must be understood to make the best choice for the target application. For instance, some phase estimation algorithms are adaptive, meaning that future steps are classically controlled by the measurement results of previous steps. Some require the ability to exponentiate its black-box unitary oracle by arbitrary real powers, and others only require integer powers but are only able to resolve a phase estimate modulo $2\pi$. Some require many ancilla qubits, and other require only one.

For instance, given a unitary black-box $U$ and an input eigenstate $U\ket{\psi}=e^{-i\phi}\ket{\psi}$, the robust phase estimation algorithm has the following features:
* Inputs
    * Discrete queries of type `DiscreteOracle`. The algorithm only queries integer powers of controlled-$\hat{U}$.
    * A quantum register `Qubit[]` storing the input quantum state.
    * A classical `Int` parameter for the desired accuracy of the estimate, as defined below.
* Output
    * A real number representing an estimate $\hat{\phi}$ of $\phi$.
* Complexity.
    * Heisenberg limited. The standard-deviation $\sigma$ of $\hat{\phi}$ scales like $2.0 \pi / Q \le \sigma \le 2\pi / 2^{n} \le 10.7\pi / Q$, where $Q$ is the number of queries to $\hat{U}$. Here, variance is defined as $\sigma^2 = \mathbb{E}\_\hat{\phi}[(\mod\_{2\pi,-\pi}(\hat{\phi}-\phi))^2]$, and $n$ is the `Int` parameter of the function. Note that the lower bound is reached in the limit of asymptotically large $Q$, and the upper bound is guaranteed even for small sample sizes. 
    * Quadratic scaling in measurements. The number of measurements performed scales like $\mathcal{O}((\log{\sigma})^2)$.
    * Efficient classical post-processing. The classical algorithm that infers $\hat{\phi}$ from the measurement outcomes requires the computation of only $\mathcal{O}(\log{(1/\sigma)})$ trigonometric functions on $\mathcal{O}(\log{(1/\sigma)})$ classical bits.
    * Small space overhead. The algorithm only requires $1$ ancilla qubit.
* Remarks
    * Non-adaptive. The required sequence of quantum experiments is independent of the intermediate measurement outcomes.
    * Uniform prior. It is assumed that $\phi\in[0,2\pi)$ is uniformly distributed.

In this and forthcoming examples where the choice of phase estimation algorithm is important, one should one should refer to the documentation such as @"microsoft.quantum.canon.robustphaseestimation" and the referenced publications therein for details on the implementation.

> [!TIP]
> There are many samples where robust phase estimation is used. For phase estimation in extracting the ground state energy of various physical system, please see the [molecular Hydrogen sample](TODO:Link), the [Ising model samples](TO:Link), and the [Hubbard model sample](TO:Link).


### Continuous Oracles ###

We can also generalize from the oracle model used above to allow for continuous-time oracles, modeled by the canon type <xref:microsoft.quantum.canon.continuousoracle>.
Consider that instead of a single unitary operator $U$, we have a family of unitary operators $U(t)$ for $t \in \mathbb{R}$ such that $U(t) U(s)$ = $U(t + s)$.
This is a weaker statement than in the discrete case, since we can construct a <xref:microsoft.quantum.canon.discreteoracle> by restricting $t = m\,\delta t$ for some fixed $\delta t$.
By [Stone's theorem](https://en.wikipedia.org/wiki/Stone%27s_theorem_on_one-parameter_unitary_groups), $U(t) = \exp(i H t)$ for some operator $H$, where $\exp$ is the [matrix exponential](../quantum-concepts-3-MatrixAdvanced#matrix-exponentials).
An eigenstate $\ket{\phi}$ of $H$ such that $H \ket{\phi} = \phi \ket{\phi}$ is then also an eigenstate of $U(t)$ for all $t$,
\begin{equation}
    U(t) \ket{\phi} = e^{i \phi t} \ket{\phi}.
\end{equation}
The exact same argument as in [the Bayesian case](#bayesian-phase-estimation) thus holds, and the likelihood function is the precisely the same for this more general oracle model.
Moreover, if $U$ is a simulation of a dynamical generator, as is the case for [Hamiltonian simulation](applications#hamiltonian-simulation), we interpret $\phi$ as an energy.
Thus, using continuous oracles with phase estimation allows us to learn the energy structure of Hamiltonian models.

### Random Walk Phase Estimation ###

Q# provides a useful approximation of Bayesian phase estimation designed for use close to quantum devices that operates by conditioning a random walk on the data record obtained from iterative phase estimation.
This method is both adaptive and entirely deterministic, allowing for near-optimal scaling of errors in the estimated phase $\hat{\phi}$ with very low memory overheads.
In practice, using random walk phase estimation proceeds in much the same way as for other algorithms provided with the canon:

```qsharp
operation ExampleOracle(eigenphase : Double, time : Double, register : Qubit[]) : () {
    body {
        Rz(2.0 * eigenphase * time, register[0]);
    }
    adjoint auto
    controlled auto
    controlled adjoint auto
}

operation BayesianPhaseEstimationCanonSample(eigenphase : Double) : Double {
    body {
        let oracle = ContinuousOracle(ExampleOracle(eigenphase, _, _));
        mutable est = Float(0);
        using (eigenstate = Qubit[1]) {
            X(eigenstate[0]);
            // The additional inputs here specify the mean and variance of the prior, the number of
            // iterations to perform, how many iterations to perform as a maximum, and how many
            // steps to roll back on an approximation failure.
            set est = RandomWalkPhaseEstimation(0.0, 1.0, 61, 100000, 1, oracle, eigenstate);
            Reset(eigenstate[0]);
        }
        return est;
    }
}
```

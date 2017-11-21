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
This is challenging because every measurement of a quantum system yields at most one bit of information.
In order to learn an eigenvalue, let alone a quantum state, the results of many measurements must be stitched together so that the user can glean the many bits of information needed to represent these concepts.
Quantum states are especially vexing because the [no-cloning theorem](../quantum-concepts-7-PauliMeasurements.md) states that there is no way to learn an arbitrary quantum state from a single copy of the state, because doing so would let you make copies of the state.
This obfuscation of the quantum state from the user is reflected in the fact that Q# does not expose or even define what a state *is* to quantum programs.
We thus approach quantum characterization by treating operations and states as black-box; this approach shares much in common with the experimental practice of quantum characterization, verification and validation (QCVV).

Characterization is distinct from many of the other libraries discussed previously.
The aim here is less to learn classical information about the system, rather than to perform a unitary transformation on a state vector.
These libraries must therefore blend both classical and quantum information processing.


## Iterative Phase Estimation ##

Viewing quantum programming in terms of quantum characterization suggests a useful alternative to [quantum phase estimation](algorithms#quantum-phase-estimation).
That is, instead of preparing an $n$-qubit register to contain a binary representation of the phase as in quantum phase estimation, we can view phase estimation as the process by which a *classical* agent learns properties of a quantum system through measurements.
We proceed as in the [quantum case](algorithms#quantum-phase-estimation) by using phase kickback to turn applications of a black-box operation into rotations by an unknown angle, but will measure the ancilla qubit that we rotate at each step immediately following the rotation.
This has the advantage that we only require a single additional qubit to perform the phase kickback described in the quantum case, as we then learn the phase from the measurement results at each step in an iterative fashion.  
Each of the methods proposed below uses a different strategy for designing experiments and different data processing methods to learn the phase.  They each have unique advantage ranging from having rigorous error bounds, to the abilities to incorporate prior information, tolerate errors or run on memory limitted classical computers.

In discussing iterative phase estimation, we will consider a unitary $U$ given as a black-box operation.
As described in the section on [oracles](data-structures#oracles), the Q# canon models such operations by the <xref:microsoft.quantum.canon.discreteoracle> user-defined type, defined by the tuple type `((Int, Qubit[]) => () : Adjoint, Controlled)`.
Concretely, if `U : DiscreteOracle`, then `U(m)` implements $U^m$ for `m : Int`.

With this definition in place, each step of iterative phase estimation proceeds by preparing an ancilla qubit in the $\ket{+}$ state along with the initial state $\ket{\phi}$ that we assume is an [eigenvector](../quantum-concepts-3-MatrixAdvanced.md) of $U(m)$, i.e. $U(m)\ket{\phi}= e^{im\phi}\ket{\phi}$.  
A controlled application of `U(m)` is then used which prepares the state $\left(R\_1(m \phi) \ket{+}\right)\ket{\phi}$.
As in the quantum case, the effect of a controlled application of the oracle `U(m)` is precisely the same as the effect of applying $R_1$ for the unknown phase on $\ket{+}$, such that we can describe the effects of $U$ in this simpler fashion.
Optionally, the algorithm then rotates the control qubit by applying $R_1(m\theta)$ to obtain a state $\ket{\psi}=\left(R\_1(m [\phi-\theta]) \ket{+}\right)\ket{\phi}$$.
The ancilla qubit used as a control for `U(m)` is then measured in the $X$ basis to obtain a single classical `Result`.

At this point, reconstructing the phase from the `Result` values obtained through iterative phase estimation is a classical statistical inference problem.
Finding the value of $m$ that maximizes the information gained, given a fixed inference method, is simply a problem in statistics.
We emphasize this by briefly describing iterative phase estimation at a theoretical level in the Bayesian parameter estimation formalism before proceeding to describe the statistical algorithms provided in the Q# canon for solving this classical inference problem.

### Iterative Phase Estimation Without Eigenstates ###

If an input state is provided that is not an eigenstate, which is to say that if $U(m)\ket{\phi\_j} = e^{im\phi\_j}$ then the process of phase estimation non-deterministically guides the quantum state towards a single energy eigenstate.  The eigenstate it ultimately converges to is the eigenstate that is most likely to produce the observed `Result`.  

Specifically, a single step of PE performs the following non-unitary transformation on a state
$$
\sum_j \sqrt{\Pr(\phi\_j)} \ket{\phi\_j} \mapsto \sum\_j\frac{\sqrt{\Pr(\phi\_j)}\sqrt{\Pr(\text{Result}|\phi\_j)}\ket{\phi\_j}}{\sqrt{\Pr(\phi\_j)\sum\_j \Pr(\text{Result}|\phi\_j)}}.
$$
As this process is iterated over multiple `Results', eigenstates that do not have maximal values of $\prod_k\Pr(\text{Result}\_k|\phi\_j)$ will be exponentially suppressed.  As a result, the inference process will tend to converge to states with a single eigenvalue if the experiments are chosen properly.

Bayes' theorem further suggests that the state that results from phase estimation be written in the form 
$$\frac{\sqrt{\Pr(\phi\_j)}\sqrt{\Pr(\text{Result}|\phi\_j)}\ket{\phi\_j}}{\sqrt{\Pr(\phi\_j)\sum\_j \Pr(\text{Result}|\phi\_j)}}=\sum_j \sqrt{\Pr(\phi\_j|\text{Result})} \ket{\phi\_j}.$$
 Here $\Pr(\phi\_j|\text{Result})$ can be interpretted as the probability that one would ascribe to each hypothesis about the eigenstates given 1) knowledge of the quantum state prior to measurement 2) knowledge of the eigenstates of $U$ and 3) knowledge of the eigenvalues of $U$.  
Learning these three things is often exponentially hard on a classical computer.
The utility of phase estimation arises, to no small extent, from the fact that it can perform such a quantum learning task without knowing any of them.
Phase estimation for this reason appears within a number of quantum algorithms that provide exponential speedups.
### Bayesian Phase Estimation ###

> [!TIP]
> For more details on Bayesian phase estimation in practice, please see the [**PhaseEstimation**](TODO: link) sample.

Following the above procedure, we can find the probability of observing a `Zero` result.
Note that $X = \ket{+}\bra{+} - \ket{-}\bra{-}$, such that $\ket{+}$ is the only positive eigenstate of $X$ corresponding to `Zero`.
The probability of observing `Zero` for a [`PauliX` measurement](../quantum-concepts-7-PauliMeasurements.md) on the first qubit given an input state $\ket{\psi}\ket{\phi}$ is thus
\begin{equation}
    \Pr(\texttt{Zero} | \psi) = \left| \braket{+ | \psi} \right|^2.
\end{equation}
In the case of iterative phase estimation, we have that $\ket{\psi} = R_1(m \phi) \ket{+}$, such that
\begin{align}
    \Pr(\texttt{Zero} | \phi; m)
        & = \left| \braket{+ | R_1(m [\phi-\theta]) | +} \right|^2 \\\\
        & = \left|
            \frac12 \left( \bra{0} + \bra{1} \right) \left( \ket{0} + e^{i m [\phi-\theta]} \ket{1} \right)
            \right|^2 \\\\
        & = \left| \frac{1 + e^{i m [\phi-\theta]}}{2} \right|^2 \\\\
        & = \cos^2(m [\phi-\theta] / 2) \tag{★} \label{eq:phase-est-likelihood}.
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

Exact Bayesian inference is in practice intractable.
To see this imagine we wish to learn an $n$-bit variable $x$.
The prior distribution $\Pr(x)$ has support over $2^n$ hypothetical values of $x$.
This means that if we need a highly accurate estimate of $x$ then Bayesian phase estimation may need prohibitive memory and processing time.
While for some applications, such as quantum simulation, the limitted accuracy required does not preclude such methods other applications,
such as Shor's algorithm, cannot use exact Bayesian inference within its phase estimation step.  For this reason, we also provide implementations
for approximate Bayesian methods such as random walk phase estimation (RWPE) and also non-Bayesian approaches such as robust phase estimation.

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
<!-- FIXME: though RPE is the correct name of this algorithm, in context it reads as though Bayesian PE is the opposite of robust, which is not the case. -->
<!-- TODO -->

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

The protocol uses an approximate Bayesian inference method that assumes the prior distribution is Gaussian.
This Gaussian assumption allows us to use an analytical formula for the experiment that minimizes the posterior variance.
The algorithm then, based on the outcome of that experiment, shifts the estimate of $\phi$ left or right by a pre-determined amount and shrinks the variance by a pre-determined amount.
This mean and variance give all the information that is needed to specify a Gaussian prior on $\phi$ for the next experiment.
Unexpected measurement failures, or the true result being on the tails of the initial prior, can cause this method to fail.
It recovers from failure by performing experiments to test whether the current mean and standard deviation are appropriate for the system.
If they are not then the algorithm does an inverse step of the walk and the process continues.
The ability to step backwards also allows the algorithm to learn even if the initial prior standard deviation is innapropriately small.

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

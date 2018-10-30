---
title: Quantum Dynamics | Microsoft Docs
description: Quantum Dynamics Conceptual Docs
author: Nathan Wiebe
ms.author: nawiebe@microsoft.com
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
uid: microsoft.quantum.chemistry.concepts.quantumdynamics
---

# Quantum Dynamics

Quantum mechanics is largely the study of quantum dynamics, which seeks to understand how an initial quantum state (in Dirac notation, see [conceptual docs](xref:microsoft.quantum.concepts.dirac-notation) on quantum computing for more info) $|\psi(0)\rangle$ varies over time.  Specifically, given this initial condition a quantum state, an evolution time and a specification of the quantum dynamical system, a quantum state $|\psi(t)\rangle$ is sought.  Before proceeding to explain quantum dynamics, it is useful to take a step back and think about classical dynamics since it provides insights into how quantum mechanics is really not that different from classical dynamics.

In classical dynamics, we know from Newton's second law of motion that the position of a particle evolves according to $F(x,t)=ma=m\frac{\dd^2}{\dd t^2}{x}(t)$, where $F(x,t)$ is the force, $m$ is the mass and $a$ is the acceleration.  Then, given an initial position $x(0)$, evolution time $t$, and description of the forces that act on the particle, we can then find $x(t)$ by solving the differential equation given by Newton's equations for $x(t)$.  Specifying the forces in this way is a bit of a pain.  So we often express the forces in terms of the potential energy of the system, which gives us $-\partial_x V(x,t) = m \frac{\dd^2}{\dd t^2}{x}(t)$.  Thus, for a particle, the dynamics of the system are specified only by the potential energy function, the particle mass, and the evolution time.

A broader language is often introduced for classical dynamics that goes beyond $F=ma$.  One formulation, which is particularly useful in quantum mechanics, is Hamiltonian mechanics.  In Hamiltonian mechanics, the total energy of a system and the (generalized) positions and momenta give all the information needed to describe the motion of an arbitrary classical object.  Specifically, let $f(x,p,t)$ be some function of the generalized positions $x$ and momenta $p$ of a system and let $H(x,p,t)$ be the Hamiltonian function.  For example, if we take $f(x,p,t)= x(t)$ and $H(x,p,t)=p^2(t)/2m - V(x,t)$, then we would recover the above case of Newtonian dynamics.  In generality, we then have that 
\begin{align}
\frac{d}{dt} f &= \partial_t f- (\partial_x H\partial_p f + \partial_p H\partial_x f)\\\\
&\defeq \partial_t f + \\{f,H\\}.
\end{align}
Here $\\{f,H\\}$ is called the [Poisson bracket](https://en.wikipedia.org/wiki/Poisson_bracket) and appears ubiquitously in classical dynamics because of the central role it plays in defining dynamics.

Quantum dynamics can be described using exactly the same language.  The Hamiltonian, or total energy, completely specifies the dynamics of any closed quantum system.  There are, however, some substantial differences between the two theories.  In classical mechanics $x$ and $p$ are just numbers, whereas in quantum mechanics they are not.  Indeed, they do not even commute: $xp \ne px$.

The right mathematical concept to describe these non-commuting objects is an operator, which in cases where $x$ and $p$ can only take a discrete set of values coincides with the concept of a matrix.  Thus for simplicity, we will assume that our quantum system is finite so that it can be described using [vectors and matrices](xref:microsoft.quantum.concepts.vectors).  We further require that these matrices be Hermitian (meaning that the conjugate transpose of the matrix is the same as the original matrix).  This guarantees that the eigenvalues of the matrices are real-valued; a condition which we impose to ensure that when we measure a quantity like position that we don't get back out an imaginary number.

Just as the analogues of position and momentum in quantum mechanics need to be replaced by operators, the Hamiltonian function needs to be similarly replaced by an operator.  For example, for a particle in free space we have that $H(x,p) = p^2/2m$ whereas in quantum mechanics the Hamiltonian operator $\hat{H}$ is $\hat{H}= \hat{p}^2/2m$ where $\hat{p}$ is the momentum operator.  From this perspective, going from classical to quantum dynamics merely involves replacing the variables used in ordinary dynamics with operators.  Once we have constructed the Hamiltonian operator by translating the ordinary classical Hamiltonian over to quantum language, we can express the dynamics of an arbitrary quantum mechanical quantity (i.e. quantum mechanical operator) $\hat{f}(t)$ via
\begin{align}
\frac{d}{dt} \hat{f} = \partial_t \hat{f} + [\hat{f},\hat{H}],
\end{align}
where $[f,H] = fH -Hf$ is known as the commutator.  This expression is exactly like the classical expression given above with the difference that the Poisson bracket $\\{f,H\\}$ being replaced with the commutator between $f$ and $H$.  This process of taking a classical Hamiltonian and using it to find a quantum Hamiltonian is known in quantum jargon as canonical quantization.

What operators $f$ are we most interested in?  The answer to this depends on the problem that we want to solve.  Perhaps the most useful quantity to find is the quantum state operator, which as discussed in the earlier conceptual documentation can be used to extract everything that we would like learn about the dynamics.  After doing this (and simplifying the result to the case where one has a pure state), the Schrödinger equation for the quantum state is found
\begin{align}
i\partial_t \ket{\psi(t)} = \hat{H}(t) \ket{\psi(t)}.
\end{align}

This equation, though perhaps less intuitive than that given above, yields perhaps the simplest expression for understanding how to simulate quantum dynamics on either a quantum or classical computer.  This is because the solution to the differential equation can be expressed in the following form (for the case where the Hamiltonian is constant in $t$)
\begin{align}
\ket{\psi(t)} = e^{-iHt}\ket{\psi(0)}.
\end{align}
Here $e^{-iHt}$ is a unitary matrix.  This means that there exists a quantum circuit that can be designed to perform it because quantum computers can closely approximate any unitary matrix.  This act of finding a quantum circuit to implement the quantum time evolution operator $e^{-iHt}$ is what is often called quantum simulation, or in particular dynamical quantum simulation.

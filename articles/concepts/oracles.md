---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Quantum oracles
description: Learn how to work with and define quantum oracles, black box operations that are used as input to another algorithm.
author: cgranade
uid: microsoft.quantum.concepts.oracles
ms.author: Christopher.Granade@microsoft.com
ms.date: 07/11/2018
ms.topic: article
no-loc: ['$$', '$', '\cdots', 'bmatrix', '\ddots', '\equiv', '\sum', '\begin', '\end', '\sqrt', '\otimes', '{', '}', '\text', '\phi', '\kappa', '\psi', '\alpha', '\beta', '\gamma', '\delta', '\omega', '\bra', '\ket', '\boldone', '\\\\', '\\', '=', '\frac', '\text', '\mapsto', '\dagger', '\to', '\begin{cases}', '\end{cases}', '\operatorname', '\braket', '\id', '\expect', '\defeq', '\variance', '\dd', '&', '\begin{align}', '\end{align}', '\Lambda', '\lambda', '\Omega', '\mathrm', '\left', '\right', '\qquad', '\times', '\big', '\langle', '\rangle', '\bigg', '\Big', '|', '\mathbb', '\vec', '\in', '\texttt', '\ne', '<', '>', '\leq', '\geq', '~~', '~']
---
# Quantum Oracles

An oracle $O$ is a "black box" operation that is used as input to another algorithm.
Often, such operations are defined using a classical function $f : \\{0, 1\\}^n \to \\{0, 1\\}^m$ which takes an $n$-bit binary input and produces an $m$-bit binary output.
To do so, consider a particular binary input $x = (x_{0}, x_{1}, \dots, x_{n-1})$.
We can label qubit states as $\ket{\vec{x}} = \ket{x_{0}} \otimes \ket{x_{1}} \otimes \cdots \otimes \ket{x_{n-1}}$.

We may first attempt to define $O$ so that $O\ket{x} = \ket{f(x)}$, but this has a couple problems.
First, $f$ may have a different size of input and output ($n \ne m$), such that applying $O$ would change the number of qubits in the register.
Second, even if $n = m$, the function may not be invertible:
if $f(x) = f(y)$ for some $x \ne y$, then $O\ket{x} = O\ket{y}$ but $O^\dagger O\ket{x} \ne O^\dagger O\ket{y}$.
This means we won't be able to construct the adjoint operation $O^\dagger$, and oracles have to have an adjoint defined for them.

## Defining an oracle by its effect on computational basis states
We can deal with both of these problems by introducing a second register of $m$ qubits to hold our answer.
Then we will define the effect of the oracle on all computational basis states: for all $x \in \\{0, 1\\}^n$ and $y \in \\{0, 1\\}^m$,

$$
\begin{align}
    O(\ket{x} \otimes \ket{y}) = \ket{x} \otimes \ket{y \oplus f(x)}.
\end{align}
$$

Now $O = O^\dagger$ by construction, thus we have resolved both of the earlier problems.

> [!TIP]
> To see that $O = O^{\dagger}$, note that $O^2 = \boldone$ since $a \oplus b \oplus b = a$ for all $a, b \in \{0, 1\}$.
> As a result, $O \ket{x} \ket{y \oplus f(x)} = \ket{x} \ket{y \oplus f(x) \oplus f(x)} = \ket{x} \ket{y}$.

Importantly, defining an oracle this way for each computational basis state $\ket{x}\ket{y}$ also defines how $O$ acts for any other state.
This follows immediately from the fact that $O$, like all quantum operations, is linear in the state that it acts on.
Consider the Hadamard operation, for instance, which is defined by $H \ket{0} = \ket{+}$ and $H \ket{1} = \ket{-}$.
If we wish to know how $H$ acts on $\ket{+}$, we can use that $H$ is linear,

$$
\begin{align}
H\ket{+} & = \frac{1}{\sqrt{2}} H(\ket{0} + \ket{1}) = \frac{1}{\sqrt{2}} (H\ket{0} + H\ket{1}) \\\\
           & = \frac{1}{\sqrt{2}} (\ket{+} + \ket{-}) = \frac12 (\ket{0} + \ket{1} + \ket{0} - \ket{1}) = \ket{0}.
\end{align}
$$

In the case of defining our oracle $O$, we can similarly use that any state $\ket{\psi}$ on $n + m$ qubits can be written as

$$
\begin{align}
\ket{\psi} & = \sum_{x \in \\{0, 1\\}^n, y \in \\{0, 1\\}^m} \alpha(x, y) \ket{x} \ket{y}
\end{align}
$$

where $\alpha : \\{0, 1\\}^n \times \\{0, 1\\}^m \to \mathbb{C}$ represents the coefficients of the state $\ket{\psi}$. Thus,

$$
\begin{align}
O \ket{\psi} & = O \sum_{x \in \\{0, 1\\}^n, y \in \\{0, 1\\}^m} \alpha(x, y) \ket{x} \ket{y} \\\\
             & = \sum_{x \in \\{0, 1\\}^n, y \in \\{0, 1\\}^m} \alpha(x, y) O \ket{x} \ket{y} \\\\
             & = \sum_{x \in \\{0, 1\\}^n, y \in \\{0, 1\\}^m} \alpha(x, y) \ket{x} \ket{y \oplus f(x)}.
\end{align}
$$

## Phase oracles
Alternatively, we can encode $f$ into an oracle $O$ by applying a _phase_ based on the input to $O$.
For instance, we might define $O$ such that
$$
\begin{align}
    O \ket{x} = (-1)^{f(x)} \ket{x}.
\end{align}
$$
If a phase oracle acts on a register initially in a computational basis state $\ket{x}$, then this phase is a global phase and hence not observable.
But such an oracle can be a very powerful resource if applied to a superposition or as a controlled operation.
For example, consider a phase orcale $O_f$ for a single-qubit function $f$.
Then,
$$
\begin{align}
    O_f \ket{+}
        & = O_f (\ket{0} + \ket{1}) / \sqrt{2} \\\\
        & = ((-1)^{f(0)} \ket{0} + (-1)^{f(1)} \ket{1}) / \sqrt{2} \\\\
        & = (-1)^{f(0)} (\ket{0} + (-1)^{f(1) - f(0)} \ket{1}) / \sqrt{2} \\\\
        & = (-1)^{f(0)} Z^{f(0) - f(1)} \ket{+}.
\end{align}
$$

More generally, both views of oracles can be broadened to represent classical functions which return real numbers instead of only a single bit.

Choosing the best way to implement an oracle depends heavily on how this oracle will be used within a given algorithm.
For example, [Deutsch-Jozsa algorithm](https://en.wikipedia.org/wiki/Deutsch%E2%80%93Jozsa_algorithm) relies on the oracle implemented in the first way, while [Grover's algorithm](https://en.wikipedia.org/wiki/Grover's_algorithm) relies on the oracle implemented in the second way.


For more details, we suggest the discussion in [Gilyén *et al*. 1711.00465](https://arxiv.org/abs/1711.00465).

---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Quantum oracles | Microsoft Docs 
description: Quantum oracles
author: cgranade
uid: microsoft.quantum.concepts.oracles
ms.author: Christopher.Granade@microsoft.com
ms.date: 07/11/2018
ms.topic: article
---
# Quantum Oracles

An oracle $O$ is a "black box" operation that is used as input to another algorithm.
Often, such operations are defined using a classical function $f : \{0, 1\}^n \to \{0, 1\}^m$ which takes an $n$-bit binary input and produces an $m$-bit binary output.
To do so, consider a particular binary input $x = (x_{0}, x_{1}, \dots, x_{n-1})$.
We can label qubit states as $\ket{\vec{x}} = \ket{x_{0}} \otimes \ket{x_{1}} \otimes \cdots \otimes \ket{x_{n-1}}$.

We may first attempt to define $O$ so that $O\ket{x} = \ket{f(x)}$, but this has a couple problems.
First, $f$ may have a different size of input and output ($n \ne m$), such that applying $O$ would change the number of qubits in the register.
Second, even if $n = m$, the function may not be invertible:
if $f(x) = f(y)$ for some $x \ne y$, then $O\ket{x} = O\ket{y}$ but $O^\dagger O\ket{x} \ne O^\dagger O\ket{y}$.
This means we won't be able to construct the adjoint operation $O^\dagger$, and oracles have to have an adjoint defined for them.

We can deal with both of these problems by introducing a second register of $m$ qubits to hold our answer.
Then we will define the effect of the oracle on all computational basis states: for all $x \in \{0, 1\}^n$ and $y \in \{0, 1\}^m$,

$$
\begin{align}
    O(\ket{x} \otimes \ket{y}) = \ket{x} \otimes \ket{y \oplus f(x)}.
\end{align}
$$

Now $O = O^\dagger$ by construction, thus we have resolved both of the earlier problems.

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
\ket{\psi} & = \sum_{x \in \{0, 1\}^n, y \in \{0, 1\}^m} \alpha(x, y) \ket{x} \ket{y},
    \intertext{
        where $\alpha : \{0, 1\}^n \times \{0, 1\}^m \to \mathbb{C}$ represents the coefficients of the state $\ket{\psi}$.
        Thus,
    }
    O \ket{\psi} & = O \sum_{x \in \{0, 1\}^n, y \in \{0, 1\}^m} \alpha(x, y) \ket{x} \ket{y} \\\\
                    & = \sum_{x \in \{0, 1\}^n, y \in \{0, 1\}^m} \alpha(x, y) O \ket{x} \ket{y} \\
                    & = \sum_{x \in \{0, 1\}^n, y \in \{0, 1\}^m} \alpha(x, y) \ket{x} \ket{y \oplus f(x)}.
\end{align}
$$

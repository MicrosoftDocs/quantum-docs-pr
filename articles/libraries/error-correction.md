# Error Correction #

## Introduction ##

In classical computing, if one wants to protect a bit against errors, it can often suffice to represent that bit by a *logical bit* by repeating the data bit.
For instance, let $\overline{0} = 000$ be the encoding of the data bit 0, where we use the a line above the label 0 to indicate that it is an encoding of a bit in the 0 state.
If we similarly let $\overline{1} = 111$, then we have a simple repetition code that protects against any one bit flip error.
That is, if any of the three bits are flipped, then we can recover the state of the logical bit by taking a majority vote.
Though classical error correction is a much richer subject that this particular example (we recommend [Lint's introduction to coding theory](https://www.springer.com/us/book/9783540641339)), the repetition code above already points to a possible problem in protecting quantum information.
Namely, by the [no-cloning theorem](xref:microsoft.quantum.concepts.dirac#the-no-cloning-theorem), we have no way to take a majority vote in this way.

Since it is the measurement that is problematic, we can still implement the encoding above.
It is helpful to do so to see how we can generalize error correction to the quantum case.
Thus, let $\ket{\overline} = \ket{000} = \ket{0} \otimes \ket{0} \otimes \ket{0}$, and let $\ket{\overline{1}} = \ket{111}$.
Then, by linearity, we have defined our repetition code for all inputs; for instance, $\ket{\overline{+}} = (\ket{\overline{0} + \ket{\overline{1}}) / \sqrt{2}} = (\ket{000} + \ket{111}) / \sqrt{2}$.
In particular, letting a bit-flip error $X_1$ act on the middle qubit, we see that the correction needed in both branches is precisely $X_1$:
$$
\begin{align}
    X_1 \ket{\overline{+}} & = \frac{1}{\sqrt{2}} \left(
        X_1 \ket{000} + X_1 \ket{111}
    \right) \\\\
    & = \frac{1}{\sqrt{2}} \left(
        \ket{010} + \ket{101}
    \right).
\end{align}
$$

To see how we can identify that this is the case without measuring the very state we are trying to protect, it is helpful to write down what each different bit flip error does to our logical states:

| Error $E$ | $E\ket{\overline{0}}$ | $E\ket{\overline{1}}$ |
| --- | --- | --- |
| $\boldone$ | $\ket{000}$ | $\ket{111}$ |
| $X_0$ | $\ket{100}$ | $\ket{011}$ |
| $X_1$ | $\ket{010}$ | $\ket{101}$ |
| $X_2$ | $\ket{001}$ | $\ket{110}$ |

In order to protect the state that we're encoding, we need to be able to distinguish the three errors from each other and from the identity $\boldone$ without distinguishing between $\ket{\overline{0}}$ and $\ket{\overline{1}}$.
For example, if we measure $Z_0$, we get a different result for $\ket{\overline{0}}$ and $\ket{\overline{1}}$ in the no-error case, so that collapses the encoded state.
On the other hand, consider measuring $Z_0 Z_1$, the parity of the first two bits in each computational basis state.
Recall that each measurement of a Pauli operator checks the eigenvalue of that the state being measured corresponds to, so for each state $\ket{\psi}$ in the table above, we can compute $Z_0 Z_1 \ket{\psi}$ to see if we get $\pm\ket{\psi}$.
Note that $Z_0 Z_1 \ket{000} = \ket{000}$ and that $Z_0 Z_1 \ket{111} = \ket{111}$, so that we conclude that this measurement does the same thing to both encoded states.
On the other hand, $Z_0 Z_1 \ket{100} = - \ket{100}$ and $Z_0 Z_1 \ket{011} = -\ket{011}$, so the result of measuring $Z_0 Z_1$ reveals useful information about which error occured.

To emphasize this, we repeat the table above, but add the results of measuring $Z_0 Z_1$ and $Z_1 Z_2$ on each row:

| Error $E$ | $E\ket{\overline{0}}$ | $E\ket{\overline{1}}$ | Result of $Z_0 Z_1$ | Result of $Z_1 Z_2$ |
| --- | --- | --- | --- | --- |
| $\boldone$ | $\ket{000}$ | $\ket{111}$ | $+$ | $+$ |
| $X_0$ | $\ket{100}$ | $\ket{011}$ | $-$ | $+$ |
| $X_1$ | $\ket{010}$ | $\ket{101}$ | $-$ | $-$ |
| $X_2$ | $\ket{001}$ | $\ket{110}$ | $+$ | $-$ |

Thus, the results of the two measurements uniquely determines which bit-flip error occured, but without revealing any information about which state we encoded.
This insight, that we can describe measurements in quantum error correction that act the same way on all code states, is the essense of the *stabilizer formalism*.
The Q# canon provides a framework for describing encoding into and decoding from stabilizer codes, and for describing how one recovers from errors.
In this section, we describe this framework and its application to a few simple quantum error-correcting codes.

> [!TIP]
> A full introduction to the stabilizer formalism is beyond the scope of this section.
> We refer readers interested in learning more to [Gottesman 2009](https://arxiv.org/abs/0904.2557).

## Representing Error Correcting Codes in Q# ##



Qubits, by their very nature, are prone to errors. In classical systems we can create codes that allow us to recover from bit errors by using more physical bits to represent desired logical bits that are more resistant to errors (e.g., Hamming codes). The same is true in the case of quantum systems. In many cases the codes we need will have to be much more sophisticated and use many more physical qubits than the classical case to reach a desired level of fidelity.

The canon contains several examples of quantum codes that you can use as templates for your own work. These include encoders and decoders for:

- The Five Qubit Code (see: [Kliunchnikov and Maslov](https://arxiv.org/abs/1305.08))
- The Seven Qubit CSS Steane Code (see: [Gottesman](https://arxiv.org/abs/quant-ph/9705052))
- The Bit Flip code (see: [Criger, Moussa, and Laflamme]

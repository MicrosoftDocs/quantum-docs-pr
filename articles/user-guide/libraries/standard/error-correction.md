---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Error correction in the Q# standard libraries
description: Learn how to use error-correcting codes in your Q# programs while protecting the state of the qubits.  
author: QuantumWriter
uid: microsoft.quantum.libraries.error-correction
ms.author: martinro
ms.date: 9/24/2020
ms.topic: article
no-loc: ['Q#', '$$v']
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# For Quantum products none of these categories have been defined  yet.
# ms.service: service-name-from-allow-list
# ms.prod: product-name-from-allow-list
# ms.technology: tech-name-from-allow-list
---

# Error correction in Q#

This article looks at the unique problems of error correction in quantum computing, how it differs from classical computing, and the error correction resources provided by Q#. 

## Quantum error correction vs. classical error correction

In classical computing, if one wants to protect a data bit against errors, it can often suffice to represent that bit by repeating it using a *logical bit*.
For instance, let $\overline{0} = 000$ be the encoding of the data bit 0, where you use a line above the label 0 to indicate that it is an encoding of a bit in the 0 state.
If you similarly let $\overline{1} = 111$, then you have a simple repetition code that protects against any one-bit flip error.
That is, if any of the three bits are flipped, then you can recover the state of the logical bit by taking a majority vote.
Though classical error correction is a much richer subject that this particular example, the code here points to a possible problem in protecting quantum information.
Namely, the [no-cloning theorem](xref:microsoft.quantum.concepts.pauli#the-no-cloning-theorem) implies that if you measure each qubit and take a majority vote by analogy to classical code in the example, then you have lost the precise information that you are trying to protect.

> [!TIP]
> For a background in classical error correction, see [Lint's introduction to coding theory](https://www.springer.com/us/book/9783540641339).

In the quantum setting, the measurement is problematic. However, you can still implement the encoding example.
It is helpful to do so to see how you can generalize error correction to the quantum case.
Thus, let $\ket{\overline{0}} = \ket{000} = \ket{0} \otimes \ket{0} \otimes \ket{0}$, and let $\ket{\overline{1}} = \ket{111}$.
Then, by linearity, you have defined your repetition code for all inputs; for example, $\ket{\overline{+}} = (\ket{\overline{0}} + \ket{\overline{1}}) / \sqrt{2} = (\ket{000} + \ket{111}) / \sqrt{2}$.
In particular, letting a bit-flip error $X_1$ act on the middle qubit, you see that the correction needed in both branches is precisely $X_1$:
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

You can identify that this is the case without measuring the very state you are trying to protect by writing down what each bit-flip error does to your logical states.

| Error $E$ | $E\ket{\overline{0}}$ | $E\ket{\overline{1}}$ |
| --- | --- | --- |
| $\boldone$ | $\ket{000}$ | $\ket{111}$ |
| $X_0$ | $\ket{100}$ | $\ket{011}$ |
| $X_1$ | $\ket{010}$ | $\ket{101}$ |
| $X_2$ | $\ket{001}$ | $\ket{110}$ |

To protect the state that you're encoding, you need to be able to distinguish the three errors from each other and the identity $\boldone$ without distinguishing between $\ket{\overline{0}}$ and $\ket{\overline{1}}$.
For example, if you measure $Z_0$, you get a different result for $\ket{\overline{0}}$ and $\ket{\overline{1}}$ in the no-error case, so that collapses the encoded state.
On the other hand, consider measuring $Z_0 Z_1$, which is the parity of the first two bits in each computational basis state.
Recall that each measurement of a Pauli operator checks which eigenvalue the state being measured corresponds to, so for each state $\ket{\psi}$ in the example table, you can compute $Z_0 Z_1 \ket{\psi}$ to see if you get $\pm\ket{\psi}$.
Note that $Z_0 Z_1 \ket{000} = \ket{000}$ and that $Z_0 Z_1 \ket{111} = \ket{111}$, so you can conclude that this measurement does the same thing to both encoded states.
On the other hand, $Z_0 Z_1 \ket{100} = - \ket{100}$ and $Z_0 Z_1 \ket{011} = -\ket{011}$, so the result of measuring $Z_0 Z_1$ reveals useful information about which error occurred.

To emphasize this, repeat the example table, but add the results of measuring $Z_0 Z_1$ and $Z_1 Z_2$ to each row.
Denote the results of each measurement by the sign of the eigenvalue that is observed, either $+$ or $-$, corresponding to the Q# `Result` values of `Zero` and `One`, respectively.

| Error $E$ | $E\ket{\overline{0}}$ | $E\ket{\overline{1}}$ | Result of $Z_0 Z_1$ | Result of $Z_1 Z_2$ |
| --- | --- | --- | --- | --- |
| $\boldone$ | $\ket{000}$ | $\ket{111}$ | $+$ | $+$ |
| $X_0$ | $\ket{100}$ | $\ket{011}$ | $-$ | $+$ |
| $X_1$ | $\ket{010}$ | $\ket{101}$ | $-$ | $-$ |
| $X_2$ | $\ket{001}$ | $\ket{110}$ | $+$ | $-$ |

Thus, the results of the two measurements uniquely determine which bit-flip error occurred, but without revealing any information about which state you encoded.
These results are called a *syndrome*, and the process of mapping a syndrome back to the error that caused it is called *recovery*.
In particular, recovery is a *classical* inference procedure that takes as its input the syndrome that occurred and returns a prescription for how to fix any errors that may have occurred.

> [!NOTE]
> The bit-flip code example can only correct against single bit-flip errors; that is, an `X` operation acting on a single qubit.
> Applying `X` to more than one qubit will map $\ket{\overline{0}}$ to $\ket{\overline{1}}$ following recovery.
> Similarly, applying a phase-flip operation `Z` will map $\ket{\overline{1}}$ to $-\ket{\overline{1}}$, and hence will map $\ket{\overline{+}}$ to $\ket{\overline{-}}$.
> More generally, you can create codes to handle a larger number of errors and to handle $Z$ errors as well as $X$ errors.

The insight that you can describe measurements in quantum error correction that act the same way on all code states is the essence of the *stabilizer formalism*.
Q# provides a framework for describing encoding into, and decoding from, stabilizer codes and for describing how one recovers from errors.
This section describes this framework and its application to a few simple quantum error-correcting codes.

> [!TIP]
> A full introduction to the stabilizer formalism is beyond the scope of this section.
> For more information, see [Gottesman 2009](https://arxiv.org/abs/0904.2557).

## Representing error-correcting codes in Q# ##

To help specify error-correcting codes, Q# provides several distinct user-defined types:

- <xref:microsoft.quantum.errorcorrection.logicalregister> `= Qubit[]`: Denotes that a register of qubits should be interpreted as the code block of an error-correcting code.
- <xref:microsoft.quantum.errorcorrection.syndrome> `= Result[]`: Denotes that an array of measurement results should be interpreted as the syndrome measured on a code block.
- <xref:microsoft.quantum.errorcorrection.recoveryfn> `= (Syndrome -> Pauli[])`: Denotes that a *classical* function should be used to interpret a syndrome and return a correction that should be applied.
- <xref:microsoft.quantum.errorcorrection.encodeop> `= ((Qubit[], Qubit[]) => LogicalRegister)`: Denotes that an operation takes qubits representing data along with fresh ancilla qubits to produce a code block of an error-correcting code.
- <xref:microsoft.quantum.errorcorrection.decodeop> `= (LogicalRegister => (Qubit[], Qubit[]))`: Denotes than an operation decomposes a code block of an error-correcting code into the data qubits and the ancilla qubits used to represent syndrome information.
- <xref:microsoft.quantum.errorcorrection.syndromemeasop> `= (LogicalRegister => Syndrome)`: Denotes an operation that should be used to extract syndrome information from a code block, without disturbing the state protected by the code.

Finally, Q# provides the <xref:microsoft.quantum.errorcorrection.qecc> type to collect the other types required to define a quantum error-correcting code. Associated with each stabilizer quantum code is the code length $n$, the number $k$ of logical qubits, and the minimum distance $d$, often grouped in the notation ⟦$n$, $k$, $d$⟧. For example, the <xref:microsoft.quantum.errorcorrection.bitflipcode> function defines the ⟦3, 1, 1⟧ bit-flip code:

```qsharp
let encodeOp = EncodeOp(BitFlipEncoder);
let decodeOp = DecodeOp(BitFlipDecoder);
let syndMeasOp = SyndromeMeasOp(MeasureStabilizerGenerators([
    [PauliZ, PauliZ, PauliI],
    [PauliI, PauliZ, PauliZ]
], _, MeasureWithScratch));
let code = QECC(encodeOp, decodeOp, syndMeasOp);
```

Notice that the `QECC` type does *not* include a recovery function.
This allows you to change the recovery function used in correcting errors without changing the definition of the code itself; this ability is particularly useful when incorporating feedback from characterization measurements into the model assumed by recovery.

Once a code is defined in this way, you can use the <xref:microsoft.quantum.errorcorrection.recover> operation to recover from errors:

```qsharp
let code = BitFlipCode();
let fn = BitFlipRecoveryFn();
let X0 = ApplyPauli([PauliX, PauliI, PauliI], _);
using (scratch = Qubit[nScratch]) {
    let logicalRegister = encode(data, scratch);
    // Cause an error.
    X0(logicalRegister);
    Recover(code, fn, logicalRegister);
    let (decodedData, decodedScratch) = decode(logicalRegister);
    ApplyToEach(Reset, decodedScratch);
}
```

You can explore this concept in more detail in the Quantum Development Kit [bit-flip code sample](https://github.com/microsoft/Quantum/tree/main/samples/error-correction/bit-flip-code).

Aside from the bit-flip code, Q# provides implementations of the [five-qubit perfect code](https://arxiv.org/abs/quant-ph/9602019), and the [seven-qubit code](https://arxiv.org/abs/quant-ph/9705052), both of which can correct an arbitrary single-qubit error.

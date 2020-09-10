---
title: Diagnostics in the Q# standard libraries
description: Learn about the diagnostic functions and operations in the Q# standard libraries used to catch mistakes or errors in quantum programs. 
author: cgranade
uid: microsoft.quantum.libraries.diagnostics
ms.author: chgranad 
ms.topic: article
no-loc: ['Q#', '$$v']
---

# Diagnostics #

As with classical development, it is important to be able to diagnose mistakes and errors in quantum programs.
The Q# standard libraries provide a variety of different ways to ensure the correctness of quantum programs, as detailed in <xref:microsoft.quantum.guide.testingdebugging>.
Largely speaking, this support comes in the form of functions and operations that either instruct the target machine to provide additional diagnostic information to the host program or developer, or enforce the correctness of conditions and invariants expressed by the function or operation call.

## Machine Diagnostics ##

Diagnostics about classical values can be obtained by using the <xref:microsoft.quantum.intrinsic.message> function to log a message in a machine-dependent way.
By default, this writes the string to the console.
Used together with interpolated strings, <xref:microsoft.quantum.intrinsic.message> makes it easy to report diagnostic information about classical values:

```Q#
let angle = Microsoft.Quantum.Math.PI() * 2.0 / 3.0;
Message($"About to rotate by an angle of {angle}...");
```

> [!NOTE]
> `Message` has signature `(String -> Unit)`, again representing that emitting a debug log message cannot be observed from within Q#.

The <xref:microsoft.quantum.diagnostics.dumpmachine> and <xref:microsoft.quantum.diagnostics.dumpregister> callables instruct target machines to provide diagnostic information about all currently allocated qubits or about a specific register of qubits, respectively.
Each target machine varies in what diagnostic information is provided in response to a dump instruction.
The [full state simulator](xref:microsoft.quantum.machines.full-state-simulator) target machine, for instance, provides the host program with the state vector that it uses internally to represent a register of qubits.
By comparison, the [Toffoli simulator](xref:microsoft.quantum.machines.toffoli-simulator) target machine provides a single classical bit for each qubit.

 To learn more about the [full state simulator's](xref:microsoft.quantum.machines.full-state-simulator) `DumpMachine` output, take a look at the dump functions section of our [testing and debugging article](xref:microsoft.quantum.guide.testingdebugging#dump-functions).


## Facts and Assertions ##

As discussed in [Testing and Debugging](xref:microsoft.quantum.guide.testingdebugging), a function or operation with signature `Unit -> Unit` or `Unit => Unit`, respectively, can be marked as a *unit test*.
Each unit test generally consists of a small quantum program, along with one or more conditions that check the correctness of that program.
These conditions can come in the form of either _facts_, which check the values of their inputs, or _assertions_, which check the states of one or more qubits passed as input.

For example, `EqualityFactI(1 + 1, 2, "1 + 1 != 2")` represents the mathematical fact that $1 + 1 = 2$, while `AssertQubit(One, qubit)` represents the condition that measuring `qubit` will return a `One` with certainty.
In the former case, we can check the correctness of the condition given only its values, while in the latter, we must know something about the state of the qubit in order to evaluate the assertion.

The Q# standard libraries provide several different functions for representing facts, including:

- <xref:microsoft.quantum.diagnostics.fact>
- <xref:microsoft.quantum.diagnostics.equalitywithintolerancefact>
- <xref:microsoft.quantum.diagnostics.nearequalityfactc>
- <xref:microsoft.quantum.diagnostics.equalityfacti>


### Testing Qubit States ###

In practice, assertions rely on the fact that classical simulations of quantum mechanics need not obey the [no-cloning theorem](https://arxiv.org/abs/quant-ph/9607018), such that we can make unphysical measurements and assertions when using a simulator for our target machine.
Thus, we can test individual operations on a classical simulator before deploying on hardware.
On target machines which do not allow evaluation of assertions, calls to <xref:microsoft.quantum.diagnostics.assertmeasurement> can be safely ignored.

More generally, the <xref:microsoft.quantum.diagnostics.assertmeasurement> operation asserts that measuring the given qubits in the
given Pauli basis will always have the given result.
If the assertion fails, the execution ends by calling `fail` with the
given message.
By default, this operation is not implemented; simulators that can support it
should provide an implementation that performs runtime checking.
`AssertMeasurement` has signature `((Pauli[], Qubit[], Result, String) -> ())`.
Since `AssertMeasurement` is a function with an empty tuple as its output type, no effects from having called `AssertMeasurement` are observable within a Q# program.

The <xref:microsoft.quantum.diagnostics.assertmeasurementprobability> operation function asserts that measuring the given qubits in the
given Pauli basis will have the given result with the given probability,
within some tolerance.
Tolerance is additive (e.g. `abs(expected-actual) < tol`).
If the assertion fails, the execution ends by calling `fail`
with the given message.
By default, this operation is not implemented; simulators that can support it
should provide an implementation that performs runtime checking.
`AssertMeasurementProbability` has signature `((Pauli[], Qubit[], Result, Double, String, Double) -> Unit)`. The first of `Double` parameters gives the desired probability of the result, and the second one the tolerance.

We can do more than assert a single measurement, using that the classical information used by a simulator to represent the internal state of a qubit is amenable to copying, such that we do not need to actually perform a measurement to test our assertion.
In particular, this allows us to reason about *incompatible* measurements that would be impossible on actual hardware.

Suppose that `P : Qubit => Unit` is an operation intended to prepare the state $\ket{\psi}$ when its input is in the state $\ket{0}$.
Let $\ket{\psi'}$ be the actual state prepared by `P`.
Then, $\ket{\psi} = \ket{\psi'}$ if and only if measuring $\ket{\psi'}$ in the axis described by $\ket{\psi}$ always returns `Zero`.
That is,
\begin{align}
    \ket{\psi} = \ket{\psi'} \text{ if and only if } \braket{\psi | \psi'} = 1.
\end{align}
Using the primitive operations defined in the prelude, we can directly perform a measurement that returns `Zero` if $\ket{\psi}$ is an eigenstate of one of the Pauli operators.


The operation <xref:microsoft.quantum.diagnostics.assertqubit> provides a particularly useful shorthand to do so in the case that we wish to test the assertion $\ket{\psi} = \ket{0}$.
This is common, for instance, when we have uncomputed to return ancilla qubits to $\ket{0}$ before releasing them.
Asserting against $\ket{0}$ is also useful when we wish to assert that two state preparation `P` and `Q` operations both prepare the same state, and when `Q` supports `Adjoint`.
In particular,

```qsharp
using (register = Qubit()) {
    P(register);
    Adjoint Q(register);

    AssertQubit(Zero, register);
}
```

More generally, however, we may not have access to assertions about states that do not coincide with eigenstates of Pauli operators.
For example, $\ket{\psi} = (\ket{0} + e^{i \pi / 8} \ket{1}) / \sqrt{2}$ is not an eigenstate of any Pauli operator, such that we cannot use <xref:microsoft.quantum.diagnostics.assertmeasurementprobability> to uniquely determine that a state $\ket{\psi'}$ is equal to $\ket{\psi}$.
Instead, we must decompose the assertion $\ket{\psi'} = \ket{\psi}$ into assumptions that can be directly tested using  the primitives supported by our simulator.
To do so, let $\ket{\psi} = \alpha \ket{0} + \beta \ket{1}$ for complex numbers $\alpha = a\_r + a\_i i$ and $\beta$.
Note that this expression requires four real numbers $\{a\_r, a\_i, b\_r, b\_i\}$ to specify, as each complex number can be expressed as the sum of a real and imaginary part.
Due to the global phase, however, we can choose $a\_i = 0$, such that we only need three real numbers to uniquely specify a single-qubit state.

Thus, we need to specify three assertions which are independent of each other in order to assert the state that we expect.
We do so by finding the probability of observing `Zero` for each Pauli measurement given $\alpha$ and $\beta$, and asserting each independently.
Let $x$, $y$, and $z$ be `Result` values for Pauli $X$, $Y$, and $Z$ measurements respectively.
Then, using the likelihood function for quantum measurements,
\begin{align}
    \Pr(x = \texttt{Zero} | \alpha, \beta) & = \frac12 + a\_r b\_r + a\_i b\_i \\\\
    \Pr(y = \texttt{Zero} | \alpha, \beta) & = \frac12 + a\_r b\_i - a\_i b\_r \\\\
    \Pr(z = \texttt{Zero} | \alpha, \beta) &
        = \frac12\left(
            1 + a\_r^2 + a\_i^2 + b\_r^2 + b\_i^2
        \right).
\end{align}

The <xref:microsoft.quantum.diagnostics.assertqubitisinstatewithintolerance> operation implements these assertions given representations of $\alpha$ and $\beta$ as values of type <xref:microsoft.quantum.math.complex>.
This is helpful when the expected state can be computed mathematically.

### Asserting Equality of Quantum Operations ###

Thus far, we have been concerned with testing operations which are intended to prepare particular states.
Often, however, we are interested in how an operation acts for arbitrary inputs rather than for a single fixed input.
For example, suppose we have implemented an operation `U : ((Double, Qubit[]) => () : Adjoint)` corresponding to a family of unitary operators $U(t)$, and have provided an explicit `adjoint` block instead of using `adjoint auto`.
We may be interested in asserting that $U^\dagger(t) = U(-t)$, as expected if $t$ represents an evolution time.

Broadly speaking, there are two different strategies that we can follow in making the assertion that two operations `U` and `V` act identically.
First, we can check that `U(target); (Adjoint V)(target);` preserves each state in a given basis.
Second, we can check that `U(target); (Adjoint V)(target);` acting on half of an entangled state preserves that entanglement.
These strategies are implemented by the canon operations <xref:microsoft.quantum.diagnostics.assertoperationsequalinplace> and <xref:microsoft.quantum.diagnostics.assertoperationsequalreferenced>, respectively.

> [!NOTE]
> The referenced assertion discussed above works based on the [Choi–Jamiłkowski isomorphism](https://en.wikipedia.org/wiki/Channel-state_duality), a mathematical framework which relates operations on $n$ qubits to entangled states on $2n$ qubits.
> In particular, the identity operation on $n$ qubits is represented by $n$ copies of the entangled state $\ket{\beta_{00}} \mathrel{:=} (\ket{00} + \ket{11}) / \sqrt{2}$.
> The operation <xref:microsoft.quantum.preparation.preparechoistate> implements this isomorphism, preparing a state that represents a given operation.

Roughly, these strategies are distinguished by a time–space tradeoff.
Iterating through each input state takes additional time, while using entanglement as a reference requires storing additional qubits.
In cases where an operation implements a reversible classical operation, such that we are only interested in its behavior on computational basis states, <xref:microsoft.quantum.diagnostics.assertoperationsequalinplacecompbasis> tests equality on this restricted set of inputs.

> [!TIP]
> The iteration over input states is handled by the enumeration operations <xref:microsoft.quantum.canon.iteratethroughcartesianproduct> and <xref:microsoft.quantum.canon.iteratethroughcartesianpower>.
> These operations are useful more generally for applying an operation to each element of the Cartesian product between two or more sets.

More critically, however, the two approaches test different properties of the operations under examination.
Since the in-place assertion calls each operation multiple times, once for each input state, any random choices and measurement results might change between calls.
By contrast, the referenced assertion calls each operation exactly once, such that it checks that the operations are equal *in a single shot*.
Both of these tests are useful in ensuring the correctness of quantum programs.


## Further Reading ##

- <xref:microsoft.quantum.guide.testingdebugging>
- <xref:microsoft.quantum.diagnostics>

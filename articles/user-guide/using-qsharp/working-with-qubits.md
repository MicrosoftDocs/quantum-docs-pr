---
title: Working with qubits
description: fill description
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.date: 03/05/2020
ms.topic: article
uid: microsoft.quantum.guide.using.qubits
---

# Working with qubits

## from 'Going Further'
## Borrowing Qubits ##

The borrowing mechanism allows the allocation of qubits that can be used as scratch space during a computation. These qubits are generally not in a clean state, i.e., they are not necessarily initialized in a known state such as $\ket{0}$. One also speaks of "dirty" qubits as their state is unknown and can even be entangled with other parts of the quantum computer's memory. Among the known use cases of dirty qubits are implementations of multi-controlled CNOT gates that require only very few qubits and implementation of incrementers.

In the canon there are examples that use the `borrowing` keyword, for instance the function `MultiControlledXBorrow` defined below.
If `controls` denotes the control qubits that should be added to an `X` operation, then an overall of `Length(controls)-2` many dirty ancillas will be added by this implementation.

```qsharp
operation MultiControlledXBorrow ( controls : Qubit[] , target : Qubit ) : Unit
is Adj + Ctl {

    body (...) {
        ... // skipping some case handling here
        let numberOfDirtyQubits = numberOfControls - 2;
        borrowing( dirtyQubits = Qubit[ numberOfDirtyQubits ] ) {

            let allQubits = [ target ] + dirtyQubits + controls;
            let lastDirtyQubit = numberOfDirtyQubits;
            let totalNumberOfQubits = Length(allQubits);

            let outerOperation1 = 
                CCNOTByIndexLadder(
                    numberOfDirtyQubits + 1, 1, 0, numberOfDirtyQubits , _ );
            
            let innerOperation = 
                CCNOTByIndex(
                    totalNumberOfQubits - 1, totalNumberOfQubits - 2, lastDirtyQubit, _ );
            
            WithA(outerOperation1, innerOperation, allQubits);
            
            let outerOperation2 = 
                CCNOTByIndexLadder(
                    numberOfDirtyQubits + 2, 2, 1, numberOfDirtyQubits - 1 , _ );
            
            WithA(outerOperation2, innerOperation, allQubits);
        }
    }

    controlled(extraControls, ...) {
        MultiControlledXBorrow( extraControls + controls, target );
    }
}
```

Note that extensive use of the `With` combinator---in its form that is applicable for operations that support adjoint, i.e., `WithA`---was made in this example which is good programming style as adding control to structures involving `With` only propagates control to the inner operation. Further note that here in addition to the `body` of the operation an implementation of the `controlled` body of the operation was explicitly provided, rather than resorting to a `controlled auto` statement. The reason for this is that we know from the structure of the circuit how to easily add further controls which is beneficial compared to adding control to each and every individual gate in the `body`. 

It is instructive to compare this code with another canon function `MultiControlledXClean` which achieves the same goal of implementing a multiply-controlled `X` operation, however, which uses several clean qubits using the `using` mechanism. 



## from 'Working with Qubits'
Having now seen a variety of different parts of the Q# language, let us get into the thick of it and see how to use qubits themselves.

## Allocating Qubits

First, to obtain a qubit that we can use in Q#, we *allocate* qubits within a `using` block:

```qsharp
using (register = Qubit[5]) {
    // Do stuff...
}
```

Any qubits allocated in this way start off in the $\ket{0}$ state; in the example above, `register` is thus in the state $\ket{00000} = \ket{0} \otimes \ket{0} \otimes \cdots \otimes \ket{0}$.
At the end of the `using` block, any qubits allocated by that block are immediately deallocated and cannot be used further.

> [!WARNING]
> Target machines expect that qubits are in the $\ket{0}$ state immediately before deallocation, so that they can be reused and offered to other `using` blocks for allocation.
> Whenever possible, use unitary operations to return any allocated qubits to $\ket{0}$.
> If need be, the @"microsoft.quantum.intrinsic.reset" operation can be used to measure a qubit instead, and to use that measurement result to ensure that the measured qubit is returned to $\ket{0}$. Such a measurement will destroy any entanglement with the remaining qubits and can thus impact the computation.

## Intrinsic Operations

Once allocated, a qubit can then be passed to functions and operations.
In some sense, this is all that a Q# program can do with a qubit, as the actions that can be taken are all defined as operations.
We will see these operations in more detail in [Intrinsic Operations and Functions](xref:microsoft.quantum.libraries.standard.prelude), but for now, we mention a few useful operations that can be used to interact with qubits.

First, the single-qubit Pauli operators $X$, $Y$, and $Z$ are represented in Q# by the intrinsic operations `X`, `Y`, and `Z`, each of which has type `(Qubit => Unit is Adj + Ctl)`.
As described in [Intrinsic Operations and Functions](xref:microsoft.quantum.libraries.standard.prelude), we can think of $X$ and hence of `X` as a bit-flip operation or NOT gate.
The `X` operation lets us prepare states of the form $\ket{s_0 s_1 \dots s_n}$ for some classical bit string $s$:

```qsharp
operation PrepareBitString(bitstring : Bool[], register : Qubit[]) : Unit
is Adj + Ctl {
    let nQubits = Length(register);
    for (idxQubit in 0..nQubits - 1) {
        if (bitstring[idxQubit]) {
            X(register[idxQubit]);
        }
    }
}

operation RunExample() : Unit {
    using (register = Qubit[8]) {
        PrepareBitString(
            [true, true, false, false, true, false, false, true],
            register
        );
        // At this point, register now has the state |11001001〉.
        // Resetting the qubits will allow us to deallocate them properly.
        ResetAll(register);
    }
}
```

> [!TIP]
> Later, we will see more compact ways of writing this operation that do not require manual flow control.

We can also prepare states such as $\ket{+} = \left(\ket{0} + \ket{1}\right) / \sqrt{2}$ and $\ket{-} = \left(\ket{0} - \ket{1}\right) / \sqrt{2}$ by using the Hadamard transform $H$, which is represented in Q# by the intrinsic operation `H : (Qubit => Unit is Adj + Ctl)`:

```qsharp
operation PreparePlusMinusState(bitstring : Bool[], register : Qubit[]) : Unit {
    // First, get a computational basis state of the form
    // |s_0 s_1 ... s_n〉 by using PrepareBitString, above.
    PrepareBitString(bitstring, register);
    // Next, we use that |+〉 = H|0〉 and |-〉 = H|1〉 to
    // prepare the state we want.
    for (idxQubit in IndexRange(register)) {
        H(register[idxQubit]);
    }
}
```

## Measurements

Using the `Measure` operation, which is a built-in intrinsic non-unitary operation, we can extract classical information from an object of type `Qubit` and assign a classical value as a result, which has a reserved type `Result`, indicating that the result is no longer a quantum state.
The input to `Measure` is a Pauli axis on the Bloch sphere, represented by a value of type `Pauli` (for instance `PauliX`) and an value of type `Qubit`.

A simple example is the following operation, which allocates one qubit in the $\ket{0}$ state, then applies a Hadamard operation `H` to it and measures the result in the `PauliZ` basis.

```qsharp
operation MeasureOneQubit() : Result {
    // The following using block creates a fresh qubit and initializes it
    // in the |0〉 state.
    using (qubit = Qubit()) {
        // We apply a Hadamard operation H to the state, thereby preparing the
        // state 1 / sqrt(2) (|0〉 + |1〉).
        H(qubit);
        // Now we measure the qubit in Z-basis.
        let result = M(qubit);
        // As the qubit is now in an eigenstate of the measurement operator,
        // we reset the qubit before releasing it.
        if (result == One) { X(qubit); }
        // Finally, we return the result of the measurement.
        return result;
    }
}
```

A slightly more complicated example is given by the following operation, which returns the Boolean value `true` if all qubits in a register of type `Qubit[]` are in the state zero when measured in a specified Pauli basis, and which returns `false` otherwise.

```qsharp
operation MeasureIfAllQubitsAreZero(qubits : Qubit[], pauli : Pauli) : Bool {
    mutable value = true;
    for (qubit in qubits) {
        if (Measure([pauli], [qubit]) == One) {
            set value = false;
        }
    }
    return value;
}
```

The Q# language allows classical control flow to depend on the results of measuring qubits.
This capability in turn enables implementing powerful probabilistic gadgets that can reduce the computational cost for implementing unitaries.
As an example, it is easy to implement so-called *Repeat-Until-Success* (RUS) patterns in Q#.
These RUS patterns are probabilistic programs that have an *expected* low cost in terms of elementary gates, but for which the true cost depends on an actual run and an actual interleaving of various possible branchings.

To facilitate Repeat-Until-Success (RUS) patterns, Q# supports the construct

```qsharp
repeat {
    statementBlock1
}
until (expression)
fixup {
    statementBlock2
}
```

where `statementBlock1` and `statementBlock2` are zero or more Q# statements, and `expression` any valid expression that evaluates to a value of type `Bool`.
In a typical use case, the following Q# operation implements a rotation around an irrational axis of $(I + 2i Z)/\sqrt{5}$ on the Bloch sphere. This is accomplished by using a known RUS pattern:

```qsharp
operation ApplyVRotationUsingRUS(qubit : Qubit) : Unit {
    using (controls = Qubit[2]) {
        ApplyToEachA(H, controls);
        mutable finished = false;
        repeat {
            Controlled X(controls, qubit);
            S(qubit);
            Controlled X(controls, qubit);
            Z(qubit);
        }
        until (finished)
        fixup {
            if (MeasureIfAllQubitsAreZero(controls, PauliX)) {
                set finished = true;
            }
        }
    }
}
```

This example shows the use of a mutable variable `finished` which is in scope of the entire repeat-until-fixup loop and which gets initialized before the loop and updated in the fixup step.

Finally, we show an example of a RUS pattern to prepare a quantum state $\frac{1}{\sqrt{3}}\left(\sqrt{2}\ket{0}+\ket{1}\right)$, starting from the $\ket{+}$ state.
See also the [unit testing sample provided with the standard library](https://github.com/microsoft/Quantum/blob/master/samples/diagnostics/unit-testing/RepeatUntilSuccessCircuits.qs):

```qsharp
operation PrepareStateUsingRUS(target : Qubit) : Unit {
    using (auxiliary = Qubit()) {
        H(auxiliary);
        repeat {
            // We expect the target and auxiliary qubits to each be in
            // the |+⟩ state.
            AssertProb(
                [PauliX], [target], Zero, 1.0,
                "target qubit should be in the |+⟩ state", 1e-10 );
            AssertProb(
                [PauliX], [auxiliary], Zero, 1.0,
                "auxiliary qubit should be in the |+⟩ state", 1e-10 );

            Adjoint T(auxiliary);
            CNOT(target, auxiliary);
            T(auxiliary);

            // The probability of measuring |+⟩ state on the auxiliary qubit
            // is 3/4.
            AssertProb(
                [PauliX], [auxiliary], Zero, 3. / 4.,
                "Error: the probability to measure |+⟩ in the first
                auxiliary must be 3/4",
                1e-10);

            // If we get the measurement outcome Zero, we prepare the
            // required state.
            let outcome = Measure([PauliX], [auxiliary]);
        }
        until (outcome == Zero)
        fixup {
            // Bring the auxiliary and target qubits back to |+⟩ state.
            if (outcome == One) {
                Z(auxiliary);
                X(target);
                H(target);
            }
        }
        // Return the auxiliary qubit back to the Zero state.
        H(auxiliary);
    }
}
```

Notable programmatic features shown in this operation are a more complex `fixup` part of the loop, which involves quantum operations, and the use of `AssertProb` statements to ascertain the probability of measuring the quantum state at certain specified points in the program.
See also [Testing and debugging](xref:microsoft.quantum.techniques.testing-and-debugging) for more information about the [`Assert`](xref:microsoft.quantum.intrinsic.assert) and [`AssertProb`](xref:microsoft.quantum.intrinsic.assertprob) operations.


## from 'Statements'
## Qubit Management

Note that none of these statements are allowed within the body of a function.
They are only valid within operations.

### Clean Qubits

The `using` statement is used to acquire new qubits for use during a statement block.
The qubits are guaranteed to be initialized to the computational `Zero` state.
The qubits should be in the computational `Zero` state at the
end of the statement block; simulators are encouraged to enforce this.

The statement consists of the keyword `using`, followed by an open
parenthesis `(`, a binding, a close parenthesis `)`, and
the statement block within which the qubits will be available.
The binding follows the same pattern as `let` statements: either a single
symbol or a tuple of symbols, followed by an equals sign `=`, and either a
single value or a matching tuple of initializers.
Initializers are available either for a single qubit, indicated as `Qubit()`, or
an array of qubits, indicated by `Qubit[`, an `Int` expression, and `]`.

For example,

```qsharp
using (qubit = Qubit()) {
    // ...
}
using ((auxiliary, qubits) = (Qubit(), Qubit[bits * 2 + 3])) {
    // ...
}
```

### Borrowed Qubits

The `borrowing` statement is used to obtain qubits for temporary use. 
The statement consists of the keyword `borrowing`, followed by an open
parenthesis `(`, a binding, a close parenthesis `)`, and
the statement block within which the qubits will be available.
The binding follows the same pattern and rules as the one in a `using` statement.

For example,

```qsharp
borrowing (qubit = Qubit()) {
    // ...
}
borrowing ((auxiliary, qubits) = (Qubit(), Qubit[bits * 2 + 3])) {
    // ...
}
```

The borrowed qubits are in an unknown state and go out of scope at the end of the statement block.
The borrower commits to leaving the qubits in the same state they were in when they were borrowed, 
i.e. their state at the beginning and at the end of the statement block is expected to be the same.
This state in particular is not necessarily a classical state, such that in most cases, 
borrowing scopes should not contain measurements. 

See [*Factoring using 2n+2 qubits with Toffoli based modular multiplication*](https://arxiv.org/abs/1611.07995)
(Haner, Roetteler, and Svore 2017) for an example of borrowed qubit use.

When borrowing qubits, the system will first try to fill the request
from qubits that are in use but that are not accessed during the body of the `borrowing` statement.
If there aren't enough such qubits, then it will allocate new qubits
to complete the request.

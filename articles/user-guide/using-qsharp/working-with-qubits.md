---
title: Working with qubits
description: fill description
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.date: 03/05/2020
ms.topic: article
uid: microsoft.quantum.guide.qubits
---

# Working with qubits

Qubits are the fundamental object of information in quantum computing. For a general introduction to qubits, see [Understanding quantum computing](xref:microsoft.quantum.overview.understanding), and to dive deeper, see [The Qubit](xref:microsoft.quantum.concepts.qubit). 

This article explores how to use and work with qubits in a Q# program. 

> [!IMPORTANT]
>None of the statements discussed in this article are valid within the body of a function. They are only valid within operations.

## Allocating Qubits

Because physical qubits don't exist on a quantum simulator, you need to tell Q# to *allocate* a qubit, or qubits, for your statement block. You can allocate qubits as a single qubit, or as an array of qubits, known as a *register*. 

### Clean qubits

Use the `using` statement to allocate new qubits for use during a statement block.

The statement consists of the keyword `using`, followed by a binding enclosed in parentheses `( )` and the statement block within which the qubits are available.
The binding follows the same pattern as `let` statements: either a single symbol or a tuple of symbols, followed by an equals sign `=`, and either a single value or a matching tuple of *initializers*.

Initializers are available either for a single qubit, indicated as `Qubit()`, or an array of qubits, `Qubit[n]`, where `n` is an `Int` expression.
For example,

```qsharp
using (qubit = Qubit()) {
    // ...
}
using ((auxiliary, register) = (Qubit(), Qubit[5])) {
    // ...
}
```

Any qubits allocated in this way start off in the $\ket{0}$ state; in the previous example, `register` is thus in the state $\ket{00000} = \ket{0} \otimes \ket{0} \otimes \cdots \otimes \ket{0}$.
At the end of the `using` block, any qubits allocated by that block are immediately deallocated and cannot be used further.

> [!WARNING]
> Target machines can reuse deallocated qubits and offer them to other `using` blocks for allocation. As such, the target machine expects that qubits are in the $\ket{0}$ state immediately before deallocation.
> Whenever possible, use unitary operations to return any allocated qubits to $\ket{0}$.
> If need be, use the @"microsoft.quantum.intrinsic.reset" operation to measure a qubit instead, and to use that measurement result to ensure that the measured qubit returns to the $\ket{0}$ state. Such a measurement destroys any entanglement with the remaining qubits and can thus impact the computation.


### Borrowed Qubits

Use the `borrowing` statement to allocate qubits for temporary use, which do not need to be in a specific state.

You can use borrowed qubits as scratch space during a computation.
These qubits are generally not in a clean state, that is, the `borrowing` statement does not necessarily initialize them in a known state such as $\ket{0}$.
These are often referred to as "dirty" qubits because their state is unknown and can even be entangled with other parts of the quantum computer's memory.

The binding follows the same pattern and rules as the `using` statement.
For example,
```qsharp
borrowing (qubit = Qubit()) {
    // ...
}
borrowing ((auxiliary, register) = (Qubit(), Qubit[5])) {
    // ...
}
```
The borrowed qubits are in an unknown state and go out of scope at the end of the statement block.
The borrower commits to leaving the qubits in the same state they were in when they borrowed them; that is, you can expect their state at the beginning and the end of the statement block to be the same.
This state, in particular, is not necessarily a classical state, such that in most cases, borrowing scopes should not contain measurements. 

When borrowing qubits, the system first tries to fill the request from qubits that are in use but not accessed during the body of the `borrowing` statement.
If there aren't enough such qubits, then it allocates new qubits to complete the request.

Among the known use cases of dirty qubits are implementations of multi-controlled CNOT gates that require only very few qubits and implementation of incrementers.
For an example of their use in Q#, see [Borrowing Qubits Example](#borrowing-qubits-example) in this article, or the paper [*Factoring using 2n+2 qubits with Toffoli based modular multiplication*](https://arxiv.org/abs/1611.07995)
(Haner, Roetteler, and Svore 2017) for an algorithm which utilizes borrowed qubits.

## Intrinsic Operations

Once allocated, you can pass a qubit to functions and operations.
In some sense, this is all that a Q# program can do with a qubit, as the actions that can be taken are all defined as operations.
For more detail about these operations, see [Intrinsic Operations and Functions](xref:microsoft.quantum.libraries.standard.prelude). This article discusses a few useful operations that you can use to interact with qubits.

First, the single-qubit Pauli operators $X$, $Y$, and $Z$ are represented in Q# by the intrinsic operations `X`, `Y`, and `Z`, each of which has type `(Qubit => Unit is Adj + Ctl)`.
As described in [Intrinsic Operations and Functions](xref:microsoft.quantum.libraries.standard.prelude), think of $X$ and hence of `X` as a bit-flip operation or NOT gate.
The `X` operation prepares states of the form $\ket{s_0 s_1 \dots s_n}$ for some classical bit string $s$:

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
        // After resetting the qubits, you can deallocate them properly.
        ResetAll(register);
    }
}
```

> [!TIP]
> Later, you will see more compact ways of writing this operation that do not require manual flow control.

You can also prepare states such as $\ket{+} = \left(\ket{0} + \ket{1}\right) / \sqrt{2}$ and $\ket{-} = \left(\ket{0} - \ket{1}\right) / \sqrt{2}$ by using the Hadamard transform $H$, which is represented in Q# by the intrinsic operation `H : (Qubit => Unit is Adj + Ctl)`:

```qsharp
operation PreparePlusMinusState(bitstring : Bool[], register : Qubit[]) : Unit {
    // First, get a computational basis state of the form
    // |s_0 s_1 ... s_n〉 by using PrepareBitString in the earlier example.
    PrepareBitString(bitstring, register);
    // Next, use that |+〉 = H|0〉 and |-〉 = H|1〉 to
    // prepare the desired state.
    for (idxQubit in IndexRange(register)) {
        H(register[idxQubit]);
    }
}
```

## Measurements

Use the `Measure` operation, which is a built-in intrinsic non-unitary operation, to extract classical information from an object of type `Qubit` and assign a classical value as a result. `Measure` has a reserved type `Result`, indicating that the result is no longer a quantum state.
The input to `Measure` is a Pauli axis on the [Bloch sphere](xref:microsoft.quantum.glossary#bloch-sphere), represented by a value of type `Pauli` (for example, `PauliX`) and a value of type `Qubit`.

A simple example is the following operation, which allocates one qubit in the $\ket{0}$ state, then applies a Hadamard operation `H` to it and measures the result in the `PauliZ` basis.

```qsharp
operation MeasureOneQubit() : Result {
    // The following using block creates a fresh qubit and initializes it
    // in the |0〉 state.
    using (qubit = Qubit()) {
        // Apply a Hadamard operation H to the state, thereby preparing the
        // state 1 / sqrt(2) (|0〉 + |1〉).
        H(qubit);
        // Now measure the qubit in Z-basis.
        let result = M(qubit);
        // As the qubit is now in an eigenstate of the measurement operator,
        // reset the qubit before releasing it.
        if (result == One) { X(qubit); }
        // Finally, return the result of the measurement.
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

## Borrowing Qubits Example

There are examples in the canon that use the `borrowing` keyword, such as the following function `MultiControlledXBorrow`. If `controls` denotes the control qubits to add to an `X` operation, then the number of dirty [ancillas](xref:microsoft.quantum.glossary#ancilla) added by this implementation is `Length(controls)-2`.

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

Note that this example used extensive use of the `With` combinator, in its form that is applicable for operations that support adjoint, for example, `WithA`.
This is good programming style, because adding control to structures involving `With` propagates control only to the inner operation.
Also note that, in addition to the `body` of the operation, an implementation of the `controlled` body of the operation was explicitly provided, rather than resorting to a `controlled auto` statement.
The reason for this is that, because of the structure of the circuit, it is easy to add further controls, which is beneficial compared to adding control to each gate in the `body`. 

It is instructive to compare this code with another canon function `MultiControlledXClean` which achieves the same goal of implementing a multiply-controlled `X` operation, however, which uses several clean qubits using the `using` mechanism. 

## Next steps

Learn about [Control Flow](xref:microsoft.quantum.guide.controlflow) in Q#.
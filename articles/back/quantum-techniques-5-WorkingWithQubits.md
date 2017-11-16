---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Intent and product brand in a unique string of 43-59 chars including spaces | Microsoft Docs 
description: 115-145 characters including spaces. Edit the intro para describing article intent to fit here. This abstract displays in the search result.
services: service-name-with-dashes-AZURE-ONLY 
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: QuantumWriter
ms.author: MSFT-alias-person-or-DL
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
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

# Working with Qubits #

Having now seen a variety of different parts of the Q# language, let us get into the thick of it and see how to use qubits themselves.

## Allocating Qubits ##

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
> If need be, the @"microsoft.quantum.canon.reset" operation can be used to measure a qubit instead, and to use that measurement result to ensure that the measured qubit is returned to $\ket{0}$.

## Primitive Gates ##

Once allocated, a qubit can then be passed to functions and operations.
In some sense, this is all that a Q# program can do with a qubit, as the actions that can be taken are all defined as operations.
We will see these operations in more detail in <!-- TODO: link to primitive operations in stdlib_techniques. -->, but for now, we mention a few useful primitive operations that can be used to interact with qubits.

First, the single-qubit Pauli operators $X$, $Y$, and $Z$ are represented in Q# by the primitive operations `X`, `Y`, and `Z`, each of which as type `(Qubit => () : Adjoint, Controlled)`.
As described in @qc_concepts <!-- TODO: more specific link -->, we can think of $X$ and hence of `X` as a bit-flip operation or NOT gate.
This lets us prepare states of the form $\ket{s_0 s_1 \dots s_n}$ for some classical bit string $s$:

```qsharp
operation PrepareBitString(bitstring : Bool[], register : Qubit[]) : () {
    body {
        let nQubits = length(register);
        for (idxQubit in 0..nQubits - 1) {
            if (bitstring[idxQubit]) {
                X(register[idxQubit]);
            }
        }
    }
    adjoint auto
    controlled auto
    controlled adjoint auto
}

operation Example() : () {
    body {
        using (register = Qubit[8]) {
            PrepareBitString(
                [true; true; false; false; true; false; false; true],
                register
            );
            // At this point, register now has the state |11001001〉.
        }
    }
}
```

> [!TIP]
> Later, we will see more compact ways of writing this operation that do not require manual flow control.

We can also prepare states such as $\ket{=} \defeq \left(\ket{0} + \ket{1}\right) / \sqrt{2}$ and $\ket{-} \defeq \left(\ket{0} - \ket{1}\right) / \sqrt{2}$ by using the Hadamard transform $H$, represented in Q# by the primitive operation `H : (Qubit => () : Adjoint, Controlled)`:

```qsharp
operation PreparePlusMinusState(bitstring : Bool[], register : Qubit[]) : () {
    body {
        // First, get a computational basis state of the form
        // |s_0 s_1 ... s_n〉 by using PrepareBitString, above.
        PrepareBitString(bitstring, register);
        // Next, we use that |+〉 = H|0〉 and |-〉 = H|1〉 to
        // prepare the state we want.
        for (idxQubit in 0..Length(register) - 1) {
            H(register[idxQubit]);
        }
    }
}
```

## Measurements ##

Using the `Measure` operation, which is a built in primitive gate, we can extract classical information from an object of type `Qubit` and assign a classical value as a result, which has a reserved type `Result`, indicating that the result is no longer a quantum state. 
The input to `Measure` is a Pauli axis on the Bloch sphere, representated by an object of type `Pauli` (i.e., for instance `PauliX`) and an object of type `Qubit`. 

A simple example is the following operation which creates one qubits in the $\ket{0}$ state, then applies a Hadamard gate ``H`` to it and then measures the result in the `PauliZ` basis. 

```qsharp
operation Measurement () : Result {
Body {
    mutable result = Zero;
    using(qubits = Qubit[1]) {
        let qubit = qubits[0];        
        H(qubit);
        let result = M(qubit);
    }
    return result;
}
```

A slightly more complicated example is given by the following operation which returns the Boolean value `true` of all qubits in a register of type `Qubit[]` are in the state zero, when measured in a specified Pauli basis and `false` otherwise. 

```qsharp
 operation AllMeasurementsZero (qs : Qubit[], pauli : Pauli) : Bool {
     Body {
         mutable value = true;
         for (i in 0..Length(qs)-1) {
             if ( Measure([pauli], [qs[i]]) == One ) {
                 set value = false;
             }
         }
         return value;
     }
 }
```

The Q# language allows dependencies of classical control flow on measurement results of qubits. This in turn enables to implement powerful probabilistic gadgets that can reduce the computational cost for implementing unitaries. As an example, it is easy to implement so-called *Repeat-Until-Success* in Q# which are probabilistic circuits that have an *expected* low cost in terms of elementary gates, but for which the true cost depends on an actual run and an actual interleaving of various possible branchings. 

To facilitate Repeat-Until-Success (RUS) patterns, the Q# supports the construct
```qsharp
repeat {
    statement1 
}
until (expression)
fixup {
    statement2
}
```
where `statement1` and `statement2` can be any valid Q# statement, and `expression` any valid expression that evaluates to a value of type `Bool`. In a typical use case, the following circuit implements a rotation around an irrational axis of $(I + 2i Z)/\sqrt{5}$ on the Bloch sphere. This is accomplished by using a known RUS pattern: 

```qsharp
operation RUScircuitV1 (qubit : Qubit) : () {
    Body {
        using(ancillas = Qubit[2]) {
            ApplyToEachA(H, ancillas);
            mutable finished = false;
            repeat {
                (Controlled X)(ancillas, qubit);
                S(qubit);
                (Controlled X)(ancillas, qubit);
                Z(qubit);
            }
            until(finished)
            fixup {
                if AllMeasurementsZero(ancillas, Xpauli) {
                    set finished = true;
                }
            }
        }
    }
}
```

This examples shows the use of a mutable variable `finished` which is in scope of the entire repeat-until-fixup loop and which gets initialized before the loop and updated in the fixup step.
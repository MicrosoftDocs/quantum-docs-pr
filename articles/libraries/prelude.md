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

# The Prelude #

## Primitive Operations and Functions ##

The primitive operations defined in the standard library roughly fall into one of several categories:

- Essential classical functions.
- Operations representing elements of the Clifford group and the $T$ gate. <!-- TODO: link to qconcepts -->
- Operations representing rotations about various operators.
- Operations implementing measurements.

Since the Clifford + $T$ gate set is universal for quantum computing, these operations suffice to implement any quantum algorithm.
By also providing rotations as well, Q# does not require the programmer to directly express the Clifford + $T$ decomposition in cases where highly efficient circuits are known and can be implemented by the compiler.

<!-- TODO: discuss rotation conventions more here. -->

Where possible, the operations defined in the prelude which act on qubits allow for applying the `Controlled` variant, such that the target machine will perform the appropriate decomposition.

All of the functions and operations defined in this portion of the prelude are in the @"microsoft.quantum.primitive" namespace, such that most Q# source files will have an `open Microsoft.Quantum.Primitive` directive immediately following the initial namespace declaration.

### Essential classical functions ###

These functions are primarily used to work with the Q# built-in data types Int, Double, and Range.

<!-- NB: Random might best be documented elsewhere -- and, indeed, best located in a different namespace -->
The <xref:microsoft.quantum.primitive.random> function has signature `(Double[] -> Int)`.
It takes an array of doubles as input, and returns a randomly-selected index into the array as an `Int`.
The probability of selecting a specific index is proportional to the value of the array element at that index.
Array elements that are equal to zero are ignored and their indices are never returned.
If any array element is less than zero, or if no array element is greater than zero, then the operation fails.

The `Floor` function has signature `(Double -> Int)`.
It returns the greatest integer less than or equal to the argument.
It is a wrapper around the .NET `System.Math.Floor` function.

The `Float` function has signature `(Int -> Double)`.
It returns a floating-point number equal to the input integer.

The `Start` function has signature `(Range -> Int)`.
It returns the starting value for a range.

The `Step` function has  signature `(Range -> Int)`.
It returns the step value for a range.

The `Stop` function has signature `(Range -> Int)`.
It returns the stopping value for a range.

### Common single-qubit unitary operations ###

All of these operations allow both the Controlled and Adjoint functors.

#### Pauli operators ####

The `X` operation implements the Pauli `X` operator.
This is sometimes also known as the `NOT` gate.
It has signature `(Qubit => () : Adjoint, Controlled)`.
It corresponds to the single-qubit unitary:

[ 0 1<br>&nbsp; 1 0 ] <!-- This should be done in LaTex -->

The `Y` operation implements the Pauli `Y` operator.
It has signature `(Qubit => () : Adjoint, Controlled)`.
It corresponds to the single-qubit unitary:

[&nbsp; 0 -_i_<br>&nbsp;&nbsp;&nbsp; _i_&nbsp; 0 ] <!-- This should be done in LaTex -->

The `Z` operation implements the Pauli `Z` operator.
It has signature `(Qubit => () : Adjoint, Controlled)`.
It corresponds to the single-qubit unitary:

[ 1&nbsp; 0<br>&nbsp; 0 -1 ] <!-- This should be done in LaTex -->

#### Other single-qubit Cliffords ####

The `H` operation implements the Hadamard gate.
This interchanges the Pauli `X` and `Z` axes of the target qubit.
It has signature `(Qubit => () : Adjoint, Controlled)`,
and corresponds to the single-qubit unitary:

1/√2 [ 1&nbsp; 1 <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 1 -1 ]

The `HY` operation implements a variation of the Hadamard gate, sometimes known as the Y-basis gate.
This interchanges the Pauli `Y` and `Z` axes of the target qubit.
It has signature `(Qubit => () : Adjoint, Controlled)`,
and corresponds to the single-qubit unitary:

1/√2 [ 1&nbsp; 1 <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _i_&nbsp; -_i_ ]

The `S` operation implements the phase gate.
This is the square root of the Pauli `Z` operation..
It has signature `(Qubit => () : Adjoint, Controlled)`,
and corresponds to the single-qubit unitary:

[ 1 0 <br>&nbsp;&nbsp; 0 _i_ ]

#### Rotations ####

The `T` operation implements the T or π/8 gate.
This is the square root of the `S` operation.
It has signature `(Qubit => () : Adjoint, Controlled)`,
and corresponds to the single-qubit unitary 

[ 1&nbsp;&nbsp;&nbsp; 0 <br>&nbsp; 0 exp(_i_ π/4) ]

The `R` operation implements a rotation around a specified Pauli axis.
It has signature `((Pauli, Double, Qubit) => () : Adjoint, Controlled)`,
and implements the single-qubit unitary exp(-_i_ ϕσ/2),
ahere σ is the Pauli matrix corresponding to the first argument and ϕ is the second argument.
> [!Note]
> The `R` operation divides the input angle by 2 and multiplies it by -1.
> For Z rotations, this means that the 0 eigenstate is rotated by -ϕ/2 and the
> 1 eigenstate is rotated by +ϕ/2, so that the 1 eigenstate is rotated by ϕ
> relative to the 0 eigenstate.
>
> In particular, this means that `T` and `R(PauliZ, π/8, _)` differ by a global phase
> of exp(-_i_ π/8).
>
> Note also that rotating around `PauliI` simply applies a global phase of -ϕ/2.

The `RFrac` operation implements a rotation around a specified Pauli axis.
It differs from `R` in that the rotation angle is specified as a fraction of a
power of two, rather than as a Double.
`RFrac` has signature `((Pauli, Int, Int, Qubit) => () : Adjoint, Controlled)`.
It implements the single-qubit unitary exp(_i_ πkσ/2^n), where σ is the Pauli matrix
corresponding to the first argument, k is the second argument, and n is the third argument.
`RFrac(_,k,n,_)` is the same as `R(_,-πk/2^n,_)`; note that the angle is the *negative*
of the fraction.

The `Rx` operation implements a rotation around the Pauli X axis.
It has signature `((Double, Qubit) => () : Adjoint, Controlled)`.
`Rx(_,_)` is the same as `R(PauliX,_,_)`.

The `Ry` operation implements a rotation around the Pauli Y axis.
It has signature `((Double, Qubit) => () : Adjoint, Controlled)`.
`Ry(_,_)` is the same as `R(PauliY,_,_)`.

The `Rz` operation implements a rotation around the Pauli Z axis.
It has signature `((Double, Qubit) => () : Adjoint, Controlled)`.
`Rz(_,_)` is the same as `R(PauliZ,_,_)`.

The `R1` operation implements a rotation by the given amount around the
Z=1 eigenstate.
It has signature `((Double, Qubit) => () : Adjoint, Controlled)`.
`R1(phi,_)` is the same as `R(PauliZ,phi,_)` followed by `R(PauliI,-phi,_)`.

The `R1Frac` operation implements a fractional rotation by the given amount around the
Z=1 eigenstate.
It has signature `((Int,Int, Qubit) => () : Adjoint, Controlled)`.
`R1Frac(k,n,_)` is the same as `RFrac(PauliZ,-k.n+1,_)` followed by `RFrac(PauliI,k,n+1,_)`.

The `Exp` operation performs a rotation based on a tensor product of Pauli matrices.
It has signature `((Pauli[], Double, Qubit[]) => () : Adjoint, Controlled)`.

The `ExpFrac` operation performs a fractional rotation based on a tensor product of Pauli matrices.
It has signature `((Pauli[], Int, Int, Qubit[]) => () : Adjoint, Controlled)`.

#### Multi-qubit operations ####

The `CNOT` operation performs a standard controlled-`NOT` gate.
It has signature `((Qubit, Qubit) => () : Adjoint, Controlled)`.
`CNOT(q1,q2)` is the same as `Controlled(X)([q1], q2)`.

The `CCNOT` operation performs the Toffoli, or doubly-controlled NOT, gate.
It has signature `((Qubit, Qubit, Qubit) => () : Adjoint, Controlled)`.
`CCNOT(q1,q2,q3)` is the same as `Controlled(X)([q1;q2], q3)`.

The `SWAP` operation swaps the quantum states of two qubits.
That is, it implements the unitary matrix:

[ 1 0 0 0<br>&nbsp; 0 0 1 0<br>&nbsp; 0 1 0 0<br>&nbsp; 0 0 0 1 ]

It has signature `((Qubit, Qubit) => () : Adjoint, Controlled)`.
`SWAP(q1,q2)` is equivalent to `CNOT(q1, q2)` followed by `CNOT(q2, q1)` and then `CNOT(q1, q2)`.

The `MultiX` operation performs a tensor product of Pauli X gates to the array of qubits.
It has signature `(Qubit[] => () : Adjoint, Controlled)`.
`MultiX(qs)` is equivalent to:

```qsharp
for (index in 0..length(qs)-1)
{
    X(qs[index])
}
```

### Measurements ###

When measuring, the +1 eigenvalue of the operator being measured
corresponds to a `Zero` result, and the -1 eigenvalue to a `One` result.

Measurement operations support neither the `Adjoint` nor the `Controlled` functor.

The `Measure` operation performs a joint measurement of one or more qubits
in the specified product of Pauli operators.
If the Pauli array and qubit array are different lengths,
then the operation fails.
`Measure` has signature `((Pauli[], Qubit[]) => Result)`.

The `M` operation measures the Pauli Z operator on a single qubit.
It has signature `(Qubit => Result)`.
`M(q)` is equivalent to `Measure([PauliZ], [q])`.

The `MultiM` measures the Pauli Z operator separately on each of an array of qubits.
In some cases this can be optimized. 
It has signature (`Qubit[] => Result[])`.
`MultiM(qs)` is equivalent to:

```qsharp
mutable rs = new Result[length(qs)];
for (index in 0..length(qs)-1)
{
    set rs[index] = M(qs[index]);
}
return rs;
```

### Debugging ###

The `Assert` function asserts that measuring the given qubits in the
given Pauli basis will always have the given result.
If the assertion fails, the execution ends by calling `fail` with the
given message.
By default, this operation is not implemented; simulators that can support it
should provide an implementation that performs runtime checking.
`Assert` has signature `((Pauli[], Qubit[], Result, String) -> ())`.

The `AssertProb` function asserts that measuring the given qubits in the
given Pauli basis will have the given result with the given probability,
within some tolerance.
Tolerance is additive (e.g. `abs(expected-actual) < tol`).
If the assertion fails, the execution ends by calling `fail`
with the given message.
By default, this operation is not implemented; simulators that can support it
should provide an implementation that performs runtime checking.
`AssertProb` has signature `((Pauli[], Qubit[], Result, Double, String, Double) -> ())`.

The `Message` function logs a message in a machine-dependent way.
By default, this writes the string to the console.
`Message` has signature `((String) -> ())`.

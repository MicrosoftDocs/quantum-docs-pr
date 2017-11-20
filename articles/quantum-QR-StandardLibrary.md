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
    
# The Standard Library

Q# includes a large number of operations in its standard library. 
While the semantics of a particular operation is specified here, 
different Q# execution environments may provide different implementations 
of these operations, and may leave some of them unimplemented.

## Functions

These functions are all in the `Microsoft.Quantum.Primitives` namespace.

Name | Signature | Description
-----|-----------|------------
`Random` | `Double[] -> Int` | The random operation takes an array of doubles as input, and returns a randomly-selected index into the array as an `Int`. The probability of selecting a specific index is proportional to the value of the array element at that index. Array elements that are equal to zero are ignored and their indices are never returned. If any array element is less than zero, or if no array element is greater than zero, then the operation fails.
`Floor` | `Double -> Int` | Returns the greatest integer less than or equal to the argument. This is the .NET `System.Math.Floor` function.
`Float` | `Int -> Double` | Returns a floating-point number equal to the input integer.
`Start` | `Range -> Int` | Returns the starting value for a range.
`Step` | `Range -> Int` | Returns the step value for a range.
`Stop` | `Range -> Int` | Returns the stopping value for a range.


## Clifford and Related Operations

These operations are all in the `Microsoft.Quantum.Primitives` namespace.

All of these operations allow both the Controlled and Adjoint functors.

Name | Signature | Unitary | Description
-----|-----------|---------|------------
`X` | `Qubit => ()` | [ 0 1<br>&nbsp; 1 0 ] | The Pauli X gate.
`Y` | `Qubit => ()` | [&nbsp; 0 -_i_<br>&nbsp;&nbsp;&nbsp; _i_&nbsp; 0 ] | The Pauli Y gate.
`Z` | `Qubit => ()` | [ 1&nbsp; 0<br>&nbsp; 0 -1 ] | The Pauli Z gate.
`H` | `Qubit => ()` | 1/√2 [ 1&nbsp; 1 <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 1 -1 ] | The Hadamard gate.
`HY` | `Qubit => ()` | 1/√2 [ 1&nbsp; 1 <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _i_&nbsp; -_i_ ] | The "Hadamard Y" or Y-basis gate.
`S` | `Qubit => ()` | [ 1 0 <br>&nbsp;&nbsp; 0 _i_ ] | The S (phase) gate.
`T` | `Qubit => ()` | [ 1&nbsp;&nbsp;&nbsp; 0 <br>&nbsp; 0 exp(_i_ π/4) ] | The T (π/8) gate.
`CNOT` | `(Qubit, Qubit) => ()` | `Controlled(X)([q1], q2)` | The Controlled NOT gate.
`CCNOT` | `(Qubit, Qubit, Qubit) => ()` | `Controlled(X)([q1;q2], q3)` | The Toffoli, or doubly-controlled NOT, gate. 
`SWAP` | `(Qubit, Qubit) => ()` | [ 1 0 0 0<br>&nbsp; 0 0 1 0<br>&nbsp; 0 1 0 0<br>&nbsp; 0 0 0 1 ]  | Swaps the state of two qubits. This is equivalent to <br>`CNOT(q1, q2)`<br>`CNOT(q2, q1)`<br>`CNOT(q1, q2)`
`MultiX` | `Qubit[] => ()` | | Performs a tensor product of Pauli X gates to the array of qubits. MultiX(qs) is equivalent to <br>`for (index in 0..length(qs)-1)`<br>&nbsp;&nbsp;&nbsp; `X(qs[index])`


## Rotations

These operations are all in the `Microsoft.Quantum.Primitives` namespace.

All of these operations allow both the Controlled and Adjoint functors.

Name | Signature | Unitary | Description
-----|-----------|---------|------------
`R` | `(Pauli, Double, Qubit) => ()` | exp(-_i_ ϕσ/2)  | Rotation by the given amount around the given Pauli axis. σ is the Pauli matrix corresponding to the first argument and ϕ is the second argument.
`RFrac` | `(Pauli, Int, Int, Qubit) => ()` | exp(_i_ πkσ/2^n) | Rotation by the given fraction of π around the given Pauli axis. σ is a Pauli matrix corresponding to the first argument, k is the second argument, and n is the third argument. Note that the sign convention is different than for `R`.
`Rx` | `(Double, Qubit) => ()` | R(PauliX,a,q) | Rotation by the given amount around the Pauli X axis.
`Ry` | `(Double, Qubit) => ()` | R(PauliY,a,q) | Rotation by the given amount around the Pauli Y axis.
`Rz` | `(Double, Qubit) => ()` | R(PauliZ,a,q) | Rotation by the given amount around the Pauli Z axis.
`R1` | `(Double, Qubit) => ()` | | Rotation by the given amount around the \|1> state. This is equivalent to <br>`R(PauliZ,phi,q)`<br>`R(PauliI,-phi,q)`
`R1Frac` | `(Int, Int, Qubit) => ()` | | Rotation by the given fraction around the \|1> state. This is equivalent to <br>`RFrac(PauliZ,-k,n+1,q)`<br>`RFrac(PauliI,k,n+1,q)`
`Exp` | `(Pauli[], Double, Qubit[]) => ()` |  | Performs a rotation based on a tensor product of Pauli matrices to the array of qubits. 
`ExpFrac` | `(Pauli[], Int, Int, Qubit[]) => ()` | | Performs a fractional rotation based on a tensor product of Pauli matrices to the array of qubits. 

## Measurements

These operations are all in the `Microsoft.Quantum.Primitives` namespace.

None of these operations allow any functors.

Name | Signature | Description
-----|-----------|------------
`Measure` | `(Pauli[], Qubit[]) => Result` | Joint measurement of one or more qubits in the specified Pauli bases. If the basis array and qubit array are different lengths, then the operation fails. <br/>When measuring, the +1 eigenvalue of the specified (possibly multi-qubit) Pauli operator corresponds to a `Zero` measurement, and the -1 eigenvalue to a `One` measurement.
`M` | `Qubit => Result` | Measurement of a single qubit in the computational (Pauli Z) basis. `M(q)` is equivalent to `Measure([PauliZ], [q])`.
`MultiM` | `Qubit[] => Result[]` | Individual measurement of an array of qubits in the computational (Pauli Z) basis, in array index order. In some cases this can be optimized. It is equivalent to <br>`mutable rs = New Result[length(qs)]`<br>`for (index in 0..length(qs)-1)`<br>&nbsp;&nbsp;&nbsp; `set rs[index] = M(qs[index])`<br>`return rs`

## Debugging

These operations are all in the `Microsoft.Quantum.Primitives` namespace.

None of these functions or operations allow any functors.

Name | Signature | Description
-----|-----------|------------
`Assert` | `(Pauli[], Qubit[], Result, String) => ()` | Asserts that measuring the given qubits in the given Pauli basis will always have the given result. If the assertion fails, the execution ends by calling `fail` with the given message. By default, this operation is not implemented; simulators that can support it should provide an implementation that performs runtime checking.
`AssertProb` | `(Pauli[], Qubit[], Result, Double, String, Double) => ()` | Asserts that measuring the given qubits in the given Pauli basis will have the given result with the given probability, within some tolerance. Tolerance is additive (e.g. `abs(expected-actual) < tol`). If the assertion fails, the execution ends by calling `fail` with the given message. By default, this operation is not implemented; simulators should provide an implementation that performs runtime checking.
`AssertEqual` | `('A, 'A, String) -> ()` | Asserts that the two values are the same, and fails if not. The first `'A` value is the expected value, the second is the actual value.
`Log` | `(String) -> ()` | Logs a string. By default, this writes the string to the console.


---
title: Quantum computing glossary
description: A glossary of common terms, actions and objects used in quantum computing.
author: bradben
ms.author: v-benbra 
ms.date: 9/1/2020
ms.topic: reference
uid: microsoft.quantum.glossary
no-loc: ['Q#', '$$v', '$$', "$$", '$', "$", $, $$, '\cdots', 'bmatrix', '\ddots', '\equiv', '\sum', '\begin', '\end', '\sqrt', '\otimes', '{', '}', '\text', '\phi', '\kappa', '\psi', '\alpha', '\beta', '\gamma', '\delta', '\omega', '\bra', '\ket', '\boldone', '\\\\', '\\', '=', '\frac', '\text', '\mapsto', '\dagger', '\to', '\begin{cases}', '\end{cases}', '\operatorname', '\braket', '\id', '\expect', '\defeq', '\variance', '\dd', '&', '\begin{align}', '\end{align}', '\Lambda', '\lambda', '\Omega', '\mathrm', '\left', '\right', '\qquad', '\times', '\big', '\langle', '\rangle', '\bigg', '\Big', '|', '\mathbb', '\vec', '\in', '\texttt', '\ne', '<', '>', '\leq', '\geq', '~~', '~', '\begin{bmatrix}', '\end{bmatrix}', '\_']
---

# Quantum computing glossary

## Adjoint

The complex conjugate transpose of an [operation](xref:microsoft.quantum.glossary#operation). For operations that implement a [unitary](xref:microsoft.quantum.glossary#unitary-operator) operator, the adjoint is the inverse of the operation and is indicated by a dagger symbol. For example, if the operation `U` represents the unitary operator $U$, then `Adjoint U` represents $U^\dagger$. For more information, see [Functor application](xref:microsoft.quantum.qsharp.functorapplication#functor-application).

## Ancilla

A [qubit](xref:microsoft.quantum.glossary#qubit) that serves as temporary memory for a quantum computer and is allocated and de-allocated as needed.  For more information, see [Multiple qubits](xref:microsoft.quantum.concepts.multiple-qubits).

## Bell state

One of four specific maximally [entangled](xref:microsoft.quantum.glossary#entanglement) [quantum states](xref:microsoft.quantum.glossary#quantum-state) of two qubits. The four states are defined $\ket{\beta_{ij}} = (\mathbb{I} \otimes X^iZ^j) (\ket{00} + \ket{11}) / \sqrt{2}$. A Bell state is also known as an [EPR pair](xref:microsoft.quantum.glossary#epr-pair).

## Bloch sphere

A graphical representation of a single-[qubit](xref:microsoft.quantum.glossary#qubit) [quantum state](xref:microsoft.quantum.glossary#quantum-state) as a point in a three-dimensional unit sphere. For more information, see  [Visualizing Qubits and Transformations using the Bloch Sphere](xref:microsoft.quantum.concepts.qubit#visualizing-qubits-and-transformations-using-the-bloch-sphere).

## Callable

An [operation](xref:microsoft.quantum.glossary#operation) or [function](xref:microsoft.quantum.glossary#function) in the [Q# language](https://github.com/microsoft/qsharp-language/tree/main/Specifications/Language#q-language).
For more information, see [Q# programs](xref:microsoft.quantum.guide.programs)

## Clifford group

The set of operations that occupy the octants of the [Bloch sphere](xref:microsoft.quantum.glossary#bloch-sphere) and effect permutations of the [Pauli operators](xref:microsoft.quantum.glossary#pauli-operators). These include the operations [$X$](xref:Microsoft.Quantum.Intrinsic.X), [$Y$](xref:Microsoft.Quantum.Intrinsic.Y), [$Z$](xref:Microsoft.Quantum.Intrinsic.Z), [$H$](xref:Microsoft.Quantum.Intrinsic.H) and [$S$](xref:Microsoft.Quantum.Intrinsic.S).

## Controlled

A quantum [operation](xref:microsoft.quantum.glossary#operation) that takes one or more [qubits](xref:microsoft.quantum.glossary#qubit) as enablers for the target operation. For more information, see [Functor application](xref:microsoft.quantum.qsharp.functorapplication#functor-application).

## Dirac Notation

A symbolic shorthand that simplifies the representation of [quantum states](xref:microsoft.quantum.glossary#quantum-state), also called *bra-ket* notation.  The *bra* portion represents a row vector, for example  $\bra{A} = \begin{bmatrix} A{_1} & A{_2} \end{bmatrix}$ and the *ket* portion represents a column vector, $\ket{B} = \begin{bmatrix} B{_1} \\\\ B{_2} \end{bmatrix}$. For more information, see [Dirac Notation](xref:microsoft.quantum.concepts.dirac).

## Eigenvalue

The factor by which the magnitude of an [eigenvector](xref:microsoft.quantum.glossary#eigenvector) of a given transformation is changed by the application of the transformation.  Given a square matrix $M$ and an eigenvector $v$, then $Mv = cv$, where $c$ is the eigenvalue and can be a complex number of any argument. For more information, see [Advanced matrix concepts](xref:microsoft.quantum.concepts.matrix-advanced).

## Eigenvector

A vector whose direction is unchanged by a given transformation and whose magnitude is changed by a factor corresponding to that vector's [eigenvalue](xref:microsoft.quantum.glossary#eigenvalue). Given a square matrix $M$ and an eigenvalue $c$, then $Mv = cv$, where $v$ is an eigenvector of the matrix and can be a complex number of any argument. For more information, see [Advanced matrix concepts](xref:microsoft.quantum.concepts.matrix-advanced).

## Entanglement

Quantum particles, such as [qubits](xref:microsoft.quantum.glossary#qubit), can be connected or *entangled* such that they cannot be described independently from each other. Their measurement results are correlated even when they are separated infinitely far away. Entanglement is essential to [measuring](xref:microsoft.quantum.glossary#measurement) the [state](xref:microsoft.quantum.glossary#quantum-state) of a qubit.  For more information, see [Advanced matrix concepts](xref:microsoft.quantum.concepts.matrix-advanced).

## EPR pair

One of four specific maximally entangled [quantum states](xref:microsoft.quantum.glossary#quantum-state) of two [qubits](xref:microsoft.quantum.glossary#qubit). The four states are defined $\ket{\beta_{ij}} = (\mathbb{1} \otimes X^iZ^j) (\ket{00} + \ket{11}) / \sqrt{2}$. An EPR pair is also known as a [Bell state](xref:microsoft.quantum.glossary#bell-state)

## Evolution

How a [quantum state](xref:microsoft.quantum.glossary#quantum-state) changes over time. For more information, see [Matrix exponentials](xref:microsoft.quantum.concepts.matrix-advanced#matrix-exponentials).

## Function
A type of subroutine in the Q# language that is purely deterministic. While functions are used within quantum algorithms, they cannot act on [qubits](xref:microsoft.quantum.glossary#qubit) or call [operations](xref:microsoft.quantum.glossary#operation). 
For more information, see [Q# programs](xref:microsoft.quantum.guide.programs)

## Gate

A legacy term for certain intrinsic quantum [operations](xref:microsoft.quantum.glossary#operation), based on the concept of classical logic gates. A [quantum circuit](xref:microsoft.quantum.glossary#quantum-circuit-diagram) is a network of gates, based on the similar concept of classical logic circuits.

## Global phase

When two [states](xref:microsoft.quantum.glossary#quantum-state) are identical up to a multiple of a complex number $e^{i\phi}$, they are said to differ up to a global phase. Unlike local phases, global phases cannot be observed through any [measurment](xref:microsoft.quantum.glossary#measurement). For more information, see [The Qubit](xref:microsoft.quantum.concepts.qubit).

## Hadamard

The Hadamard operation (also referred to as the Hadamard gate or transform) acts on a single [qubit](xref:microsoft.quantum.glossary#qubit) and puts it in an even [superposition](xref:microsoft.quantum.glossary#superposition) of $\ket{0}$ or $\ket{1}$ if the qubit is initially in the $\ket{0}$ state. In Q#, this operation is applied by the pre-defined [`H`](xref:Microsoft.Quantum.Intrinsic.H) operation.

## Immutable

A variable whose value cannot be changed. An immutable variable in Q# is created using the `let` keyword. To declare variables that *can* be changed, use the [mutable](xref:microsoft.quantum.glossary#immutable) keyword to declare and the `set` keyword to modify the value. 

## Measurement

A manipulation of a [qubit](xref:microsoft.quantum.glossary#qubit) (or set of qubits) that yields the result of an observation, in effect obtaining a classical bit. For more information, see [The Qubit](xref:microsoft.quantum.concepts.qubit#measuring-a-qubit).

## Mutable

A variable whose value may be changed after it is created. A mutable variable in Q# is declared using the `mutable` keyword and modified using the `set` keyword. Variables created with the `let` keyword are [immutable](xref:microsoft.quantum.glossary#immutable) and their value cannot be changed.

## Namespace

A label for a collection of related names (i.e., [operations](xref:microsoft.quantum.glossary#operation), [functions](xref:microsoft.quantum.glossary#function), and [user-defined types](xref:microsoft.quantum.glossary#user-defined-type)). For instance the namespace [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation) labels all of the symbols defined in the standard library that help with preparing initial states.

## Operation

The basic unit of quantum computation in Q#. It is roughly equivalent to a function in C, C++ or Python, or a static method in C# or Java. For more information, see [Q# programs](xref:microsoft.quantum.guide.programs).

## Oracle

A subroutine that provides data-dependent information to a quantum algorithm at runtime. Typically, the goal is to provide a [superposition](xref:microsoft.quantum.glossary#superposition) of outputs corresponding to inputs that are in superposition. For more information, see [Oracles](xref:microsoft.quantum.libraries.data-structures#oracles).

## Partial application

Calling a [function](xref:microsoft.quantum.glossary#function) or [operation](xref:microsoft.quantum.glossary#operation) without all the required inputs. This returns a new [callable](xref:microsoft.quantum.glossary#callable) that only needs the missing parameters (indicated by an underscore) to be supplied during a future application. For more information, see [Partial application](xref:microsoft.quantum.qsharp.partialapplication).

## Pauli operators

A set of three 2 x 2 unitary matrices known as the `X`, `Y` and `Z` quantum operations. The identity matrix, $I$, is often included in the set as well.  $I = \begin{bmatrix} 1 & 0 \\\\ 0 & 1 \end{bmatrix}$, $X = \begin{bmatrix} 0 & 1 \\\\ 1 & 0 \end{bmatrix}$, $Y = \begin{bmatrix} 0 & -i \\\\ i & 0 \end{bmatrix}$, $Z = \begin{bmatrix} 1 & 0 \\\\ 0 & -1 \end{bmatrix}$.   For more information, see [Single-qubit operations](xref:microsoft.quantum.concepts.qubit#single-qubit-operations).

## Quantum circuit diagram

A method to graphically represent the sequence of [gates](xref:microsoft.quantum.glossary#gate) for simple quantum programs, for example 

![Sample circuit diagram](~/media/qpe.png). 

For more information, see [Quantum circuits](xref:microsoft.quantum.concepts.circuits).

## Quantum libraries

Collections of [operations](xref:microsoft.quantum.glossary#operation), [functions](xref:microsoft.quantum.glossary#function) and [user-defined types](xref:microsoft.quantum.glossary#user-defined-type) for creating Q# programs. The [Standard library](xref:microsoft.quantum.libraries.standard.intro) is installed by default. Other libraries available are the [Chemistry library](xref:microsoft.quantum.chemistry.concepts.intro), the [Numerics library](xref:microsoft.quantum.numerics.intro) and the [Machine learning library](xref:microsoft.quantum.machine-learning.concepts.intro).

## Quantum state

The precise state of an isolated quantum system, from which [measurement](xref:microsoft.quantum.glossary#measurement) probabilities can be extracted. In quantum computing, the quantum simulator uses this information to simulate how qubits respond to operations. For more information, see [The Qubit](xref:microsoft.quantum.concepts.qubit).

## Qubit

A basic unit of quantum information, analogous to a *bit* in classical computing. For more information, see [The Qubit](xref:microsoft.quantum.concepts.qubit).

## Repeat-until-success

A concept often used in quantum algorithms that consists of repeatedly applying a computation until a certain condition is satisfied. When the condition is not satisfied, often a fixup is required before retrying by entering the next iteration. For more information, see the [Q# user guide](xref:microsoft.quantum.guide)

## Standard libraries

[Operations](xref:microsoft.quantum.glossary#operation), [functions](xref:microsoft.quantum.glossary#function) and [user-defined types](xref:microsoft.quantum.glossary#user-defined-type) that are installed along with the Q# compiler during installation. The standard library implementation is agnostic with respect to target machines. For more information, see [Standard libraries](xref:microsoft.quantum.libraries.standard.intro).

## Superposition

The concept in quantum computing that a [qubit](xref:microsoft.quantum.glossary#qubit) is a linear combination of two states, $\ket{0}$ and $\ket{1}$, until it is [measured](xref:microsoft.quantum.glossary#measurement).  For more information, see [Understanding quantum computing](xref:microsoft.quantum.overview.understanding).

## Target machine

A compilation target that lowers an abstract quantum program towards hardware or simulation. This typically include re-writes for many purposes including gate replacement, encoding for error correction, geometric layout and others. For more information, see [Quantum simulators and host applications](xref:microsoft.quantum.machines).

## Teleportation

A method for regenerating data, or the [quantum state](xref:microsoft.quantum.glossary#quantum-state), of one [qubit](xref:microsoft.quantum.glossary#qubit) from one place to another without physically moving the qubit, using [entanglement](xref:microsoft.quantum.glossary#entanglement) and [measurement](xref:microsoft.quantum.glossary#measurement).  For more information, see [Quantum circuits](xref:microsoft.quantum.concepts.circuits) and the respective kata at [Quantum Katas](xref:microsoft.quantum.overview.katas).

## Tuple

A collection of comma-separated values that acts as a single value. The *type* of a tuple is defined by the types of values it contains. In Q#, tuples are [immutable](xref:microsoft.quantum.glossary#immutable) and can be nested, contain arrays, or used in an array. For more information, see [Tuples](xref:microsoft.quantum.qsharp.valueliterals#tuple-literals).

## Unitary operator

An operator whose inverse is equal to its [adjoint](xref:microsoft.quantum.glossary#adjoint), i.e., $UU^{\dagger} = \id$.

## User-defined type

A custom type that may contain one or more named or anonymous items. For more information, see  [Type declarations]microsoft.quantum.qsharp.typedeclarations#type-declarations).

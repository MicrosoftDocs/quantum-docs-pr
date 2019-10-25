---
title: Quantum computing glossary | Microsoft Docs 
description: Quantum terms glossary
author: QuantumWriter
ms.author: Alan.Geller@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
uid: microsoft.quantum.glossary
---

# Quantum computing glossary

|Term|Definition|
|-------------|----------|
|Adjoint|The complex conjugate transpose of the operation. For operations that implement a unitary operator, the adjoint is the inverse of the operation.|
|Callable|Operations and functions are collectively known as *callables*.|
|Standard|Operations and functions defined in Q# building on the logic defined in the prelude. The standard library implementation is agnostic with respect to target machines.|
|Clifford group|The set of operations that occupy the octants of the Bloch sphere. These include: `X`, `Y`, `Z`, `H` and `S`|
|Controlled|A quantum operation that takes one or more qubits as enablers for the target operation.|
|Dirac Notation|A shorthand representation of quantum state. See the [Dirac Notation](xref:microsoft.quantum.concepts.dirac) section for more details.|
|Eigenvalues and Eigenvectors|See the [Advanced Matrix section](xref:microsoft.quantum.concepts.matrix-advanced) for details.|
|EPR pair|Also known as a [Bell State](https://en.wikipedia.org/wiki/Bell_state)|
|Evolution|How the state changes over time. See the section on <xref:microsoft.quantum.concepts.matrix-advanced#matrix-exponentials> for an example. |
|Function|Purely classical routines in the Q# language|
| <a id="global-phase"></a>Global phase | Two states that are identical up to a multiple of a complex number $e^{i\phi}$ are said to differ up to a global phase. Unlike local phases, global phases cannot be observed through any measurement. See [Pauli measurements](xref:microsoft.quantum.concepts.pauli) for more details. |
|Measurement|Obtaining a classical bit from a qubit (or set of qubits). See the [Qubit Concepts](xref:microsoft.quantum.concepts.qubit) section for more details.|
|Mutable|A variable whose value may be changed after it is created.|
|Namespace|A label for a collection of related names (typically operations, functions, and types). For instance the namespace [`Microsoft.Quantum.Preparation`](xref:microsoft.quantum.preparation) labels all of the symbols defined in the standard library that help with preparing initial states.|
|Operation|The basic unit of quantum execution in Q#. It is roughly equivalent to a function in C or C++ or Python, or a static method in C# or Java.|
|Operator Application|Performing a quantum operation. This typically applies a unitary matrix to the current state vector. See [Introduction to Quantum Concepts](xref:microsoft.quantum.concepts.intro) for more detail.|
|Oracle|A subroutine that provides data-dependent information to a quantum algorithm at runtime. Typically, the goal is to provide a superposition of outputs corresponding to inputs that are in superposition.   |
|Partial Application|Calling a function or operation without all the required parameters. The returns a new callable that only needs the missing parameters supplied during a future application.|
|Pauli Operators|The `X`, `Y` and `Z` quantum gates.|
|Prelude|The set of primitive and classical operations and functions defined by each individual target machine, rather than at the Q# level.|
|Quantum Circuit|The representation of a program for a quantum computer. See the <xref:microsoft.quantum.concepts.circuits> section for more details.|
|Quantum State|A representation of the qubits in the system. This is usually denoted as a complex column vector. For more information, see <xref:microsoft.quantum.concepts.vectors>. |
|Qubit|Unit of quantum storage. See the <xref:microsoft.quantum.concepts.qubit> section for more details.|
|Repeat-until-success|A quantum algorithm that probabilistically succeeds. Upon failure, the routine will re-try until successful (or a limit has been reached). |
|Software Stack|The complete set of classical and quantum software as well as the compilers, simulators and runtimes necessary to operate a quantum computer. See the <xref:microsoft.quantum.concepts.software-stack> section for more details. |
|Target machine|A compilation target that lowers an abstract quantum program towards hardware or simulation. This typically include re-writes for many purposes including gate replacement, encoding for error correction, geometric layout and others.|
|Tuple|Comma separated types grouped together via parenthesis. |
|User-defined type|Collection of built-in or previously defined types that may be referred to as a single unit.|


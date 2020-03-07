---
title: Quantum computing glossary
description: A glossary of common terms, actions and objects used in quantum computing.
author: QuantumWriter
ms.author: Alan.Geller@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
uid: microsoft.quantum.glossary
---

# Quantum computing glossary

|Term|Definition|
|-------------|----------|
|<a id="adjoint"></a>Adjoint|The complex conjugate transpose of an operation. For operations that implement a unitary operator, the adjoint is the inverse of the operation. Adjoints are indicated by dagger symbol, for example the adjoint of vector $v$ is $v^\dagger$. For more information, see [Adjoint](xref:microsoft.quantum.language.file-structure#adjoint).|
|<a id="bell-state"></a>Bell state|A maximally entangled quantum state of two qubits. Also known as an [EPR pair](xref:microsoft.quantum.glossary#epr)|
|<a id="callable"></a>Callable|In the Q# language, operations and functions are collectively known as *callables*. For more information, see [Operation and function types](xref:microsoft.quantum.language.type-model#operation-and-function-types).|
|<a id="clifford"></a>Clifford group|The set of operations that occupy the octants of the Bloch sphere and effect permutations of the Pauli operators. These include: `X`, `Y`, `Z`, `H` and `S`|
|<a id="controlled"></a>Controlled|A quantum operation that takes one or more qubits as enablers for the target operation. For more information, see [Controlled](xref:microsoft.quantum.language.type-model#controlled).|
|<a id="dirac"></a>Dirac Notation|A shorthand representation of quantum states, for example $$\frac{1}{\sqrt{2}}\begin{bmatrix} 1 \\\\  1 \end{bmatrix}=H\ket{0} = \ket{+}$$. For more information, see [Dirac Notation](xref:microsoft.quantum.concepts.dirac).|
|<a id="eigenvalue"></a>Eigenvalue| The factor by which the magnitude of an [eigenvector](xref:microsoft.quantum.glossary#eigenvector) is changed by a given transformation. For more information, see [Advanced matrix concepts](xref:microsoft.quantum.concepts.matrix-advanced).|
|<a id="eigenvector"></a>Eigenvector|A vector whose direction is unchanged by a given transformation and whose magnitude is changed by a factor corresponding to that vector's [eigenvalue](xref:microsoft.quantum.glossary#eigenvalue). For more information, see [Advanced matrix concepts](xref:microsoft.quantum.concepts.matrix-advanced).|
|<a id="epr"></a>EPR pair|A maximally entangled quantum state of two qubits. Also known as a [Bell state](xref:microsoft.quantum.glossary#bell-state)|
|<a id="evolution"></a>Evolution|How a quantum state changes over time. For more information, see [Matrix exponentials](xref:microsoft.quantum.concepts.matrix-advanced#matrix-exponentials).|
|<a id="function"></a>Function|A purely classical (non-quantum) routine in the Q# language. For more information, see [Operation and function types](xref:microsoft.quantum.language.type-model#operation-and-function-types).|
|<a id="global-phase"></a>Global phase|When two states are identical up to a multiple of a complex number $e^{i\phi}$, they are said to differ up to a global phase. Unlike local phases, global phases cannot be observed through any measurement. For more information, see [The Qubit](xref:microsoft.quantum.concepts.qubit).|
|<a id="measurment"></a>Measurement|Obtaining a classical bit from a qubit (or set of qubits). FOr more information, see [The Qubit](xref:microsoft.quantum.concepts.qubit#measuring-a-qubit).|
|<a id="mutable"></a>Mutable|A variable whose value may be changed after it is created.|
|<a id="namespace"></a>Namespace|A label for a collection of related names (typically operations, functions, and types). For instance the namespace [Microsoft.Quantum.Preparation](xref:microsoft.quantum.preparation) labels all of the symbols defined in the standard library that help with preparing initial states.|
|<a id="operation"></a>Operation|The basic unit of quantum execution in Q#. It is roughly equivalent to a function in C, C++ or Python, or a static method in C# or Java. For more information, see [Operation and function types](xref:microsoft.quantum.language.type-model#operation-and-function-types).|
|<a id="operator-application"></a>Operator application|Performing a quantum operation. This typically applies a unitary matrix to the current quantum   state vector.|
|<a id="oracle"></a>Oracle|A subroutine that provides data-dependent information to a quantum algorithm at runtime. Typically, the goal is to provide a superposition of outputs corresponding to inputs that are in superposition. For more information, see [Oracles](xref:microsoft.quantum.libraries.data-structures#oracles).|
|<a id="partial-app"></a>Partial application|Calling a function or operation without all the required parameters. The returns a new callable that only needs the missing parameters supplied during a future application. For more information, see [Partial application](xref:microsoft.quantum.libraries.data-structures#partial-application).|
|<a id="pauli"></a>Pauli operators|The `X`, `Y` and `Z` quantum gates. For more information, see [Single-qubit operations](xref:microsoft.quantum.concepts.qubit#single-qubit-operations).|
|<a id="prelude"></a>Prelude|The set of primitive and classical operations and functions defined by each individual target machine, rather than at the Q# level For more information, see [The prelude](xref:microsoft.quantum.libraries.standard.prelude).|
|<a id="circuit"></a>Quantum circuit|A diagrammatical representation of a program for a quantum computer. FOr more information, see [Quantum circuits](xref:microsoft.quantum.concepts.circuits).|
|<a id="quantum-state"></a>Quantum state|A representation of the qubits in a system, usually denoted as a complex column vector called the *quantum state vector*. For more information, see [The Qubit](xref:microsoft.quantum.concepts.qubit).|
|<a id="qubit"></a>Qubit|A basic unit of quantum storage. For more information, see [The Qubit](xref:microsoft.quantum.concepts.qubit).|
|<a id="rus"></a>Repeat-until-success|A quantum algorithm that probabilistically succeeds. Upon failure, the routine will re-try until successful (or a limit has been reached). For more information, see [Repeat ntil Success (RUS)](xref:microsoft.quantum.techniques.qubits#measurements)|
|<a id="standard"></a>Standard|Operations and functions defined in Q# that build on the logic defined in the [prelude](xref:microsoft.quantum.glossary#prelude). The standard library implementation is agnostic with respect to target machines. For more information, see [Standard libraries](xref:microsoft.quantum.libraries.standard.intro).|
|<a id="target"></a>Target machine|A compilation target that lowers an abstract quantum program towards hardware or simulation. This typically include re-writes for many purposes including gate replacement, encoding for error correction, geometric layout and others. For more information, see [Quantum simulators and host applications](xref:microsoft.quantum.machines).|
|<a id="tuple"></a>Tuple|Comma separated types grouped together via parenthesis. For more information, see [Tuple types](xref:microsoft.quantum.language.type-model#tuple-types).|
|<a id="unitary"></a>Unitary operator|An operator whose inverse is equal to its adjoints.|
|<a id="user-def"></a>User-defined type|A collection of built-in or previously defined types that may be referred to as a single unit. For more information, see [User-defined types](xref:microsoft.quantum.language.type-model#user-defined-types).|

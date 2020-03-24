---
title: Quantum development techniques
description: Learn the basics of Q# program development, work with operations, functions, variables and qubits, and create a simple quantum program. 
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: QuantumWriter
ms.author: MSFT-alias-person-or-DL
ms.date: 9/20/2019
ms.topic: article-type-from-white-list
uid: microsoft.quantum.techniques.intro
---


# Quantum Development Techniques

This section of our documentation details the core concepts used to create quantum programs in Q#, and to interact with those programs from classical applications.
We assume *some* knowledge of quantum computing concepts, like those described in [Quantum computing concepts](xref:microsoft.quantum.concepts.intro), but you need not be an expert in quantum computing to get a lot from these sections.

Their contents are as follows.

- [Q# program overview](xref:microsoft.quantum.techniques.file-structure) provides an overview of the purpose and functionality of the Q# programming language. 
	In particular, it clarifies how Q# is *not* a language for merely simulating quantum mechanics---though that functionality is of course provided by our full state simulator. 
	Rather, Q# was designed with an eye on the future, and its programs describe how a classical control computer *interacts* with qubits. 

- [Operations and functions](xref:microsoft.quantum.techniques.opsandfunctions) details the two callable types of the Q# language: *operations*, which include action on qubits and quantum systems; and *functions*, which strictly work with classical information. 
	Without both classical and quantum information working in tandem, quantum computing would remain out of reach. 
	This section describes how to define and use these callables within the control flow of a Q# program.

- [Local variables](xref:microsoft.quantum.techniques.local-variables) describes the role of variables within Q# programs and how to leverage them effectively. 
	In particular, you will learn the difference between immutable/mutable variables and how to assign/re-assign them.

- [Working with qubits](xref:microsoft.quantum.techniques.qubits) describes the features of Q# that you can use to address individual qubits and systems of qubits. 
	Specifically, that entails their allocation, performing operations on them, and ultimately their measurement. 
	Additionally, you will learn some useful control flow techniques.

- In [Putting it all together](xref:microsoft.quantum.techniques.puttingittogether), you will leverage the techniques from the sections above to create a program which performs **quantum teleportation**: using two classical bits to "teleport" the full state of one qubit onto another.

- [Going further](xref:microsoft.quantum.techniques.going-further) introduces advanced techniques that can prove helpful as you move toward more complex quantum programming. 
	In particular, we discuss the use of *type-parameterized* operations and functions in Q#, which enable higher-order control flow by remaining agnostic to the specific types of their input/output, as well as *borrowing* qubits. 
	The latter differs from basic qubit allocation in that a Q# operation may use "dirty" qubits---qubits not necessarily initialized to a known state---to assist computations.

- [Testing and debugging](xref:microsoft.quantum.techniques.testing-and-debugging) details some techniques for making sure your code is doing what it is supposed to do. 
	Due to the general opacity of quantum information, debugging a quantum program can require specialized techniques. 
	Fortunately, Q# supports many of the classical debugging techniques programmers are used to, as well as those that are quantum-specific. These include creating/running unit tests in Q#, embedding *assertions* on values and probabilities in your code, and the `Dump` functions which output the state of target machine. 
	The latter can be used alongside our full state simulator to debug certain parts of computations by skirting some quantum limitations (e.g. the no-cloning theorem).


![Quantum](~/media/mobius_strip_preview.png)

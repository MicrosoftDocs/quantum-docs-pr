---
title: The Q# User Guide
description: Overview of the User Guide's purpose and contents
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.date: 03/05/2020
ms.topic: article
uid: microsoft.quantum.guide
---

# The Q# User Guide

Welcome to the Q# User Guide! 

Here we detail the core concepts of the Q# language and all the information you need to write quantum programs.

## User Guide Contents

- [Q# basics](xref:microsoft.quantum.guide.basics): an introductory overview of the purpose and functionality of the Q# programming language. 

- [Ways to run a Q# program](xref:microsoft.quantum.guide.host-programs): describes how a Q# program is executed, and provides an overview of the various ways you can call the program: from the command line, in Q# Jupyter Notebooks, or from a classical host program written in Python or a .NET language.

### Q# Language

- [Types in Q#](xref:microsoft.quantum.guide.types): lays out the Q# type model and describes the syntax for specifying and working with types.

- [Type expressions](xref:microsoft.quantum.guide.expressions): details how to specify, reference, combine, and operate on values of each type in Q#. 

### Using Q#

- [Q# file structure](xref:microsoft.quantum.guide.filestructure): describes the structure and syntax of a `*.qs` Q# file.

- [Operations and functions](xref:microsoft.quantum.guide.operationsfunctions): details the two callable types of the Q# language: *operations*, which include action on qubit registers and *functions*, which strictly work with classical information. 
    Here you see how to define and call them, including the adjoint and controlled versions of quantum operations.

- [Variables](xref:microsoft.quantum.guide.variables): describes the role of variables within Q# programs and how to leverage them effectively. 
    For example, you can find information about binding scopes, as well as the difference between immutable/mutable variables and how to assign/re-assign them.

- [Working with qubits](xref:microsoft.quantum.guide.qubits): describes the features of Q# used to address individual qubits and systems of qubits. 
    Specifically, that entails their allocation, performing operations on them, and ultimately their measurement. 

- [Control flow](xref:microsoft.quantum.guide.controlflow): details the programming control flow patterns available in Q#, which includes many standard techniques (conditional execution, for loops, while loops, etc.) as well as the quantum-specific "Repeat-Until-Success" pattern.

- [Testing and debugging](xref:microsoft.quantum.guide.testingdebugging): details some techniques for making sure your code is doing what it is supposed to do. 
    Due to the general opacity of quantum information, debugging a quantum program can require specialized techniques. 
    Fortunately, Q# supports many of the classical debugging techniques programmers are used to, as well as those that are quantum-specific. These include creating/running unit tests in Q#, embedding *assertions* on values and probabilities in your code, and the `Dump` functions which output the state of target machine. 
    The latter can be used alongside our full-state simulator to debug certain parts of computations by skirting some quantum limitations (e.g. the no-cloning theorem).

### Quantum Simulators and Resource Estimators

- [Quantum simulators and host applications](xref:microsoft.quantum.machines): an overview of the different simulators available, as well as the general execution model between host program and target machines.

- [Full state simulator](xref:microsoft.quantum.machines.full-state-simulator): the target machine which simulates the full quantum state. Useful for fully executing or debugging smaller scale programs (less than a couple dozen qubits)

- [Resources estimator](xref:microsoft.quantum.machines.resources-estimator): estimates the resources required to run a given instance of a Q# operation on a quantum computer.

- [Trace simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro): executes a quantum program without actually simulating the state of a quantum computer, and therefore can execute quantum programs that use thousands of qubits. Useful for debugging classical code within a quantum program, as well as estimating resources required.

- [Toffoli simulator](xref:microsoft.quantum.machines.toffoli-simulator): a special purpose quantum simulator that can be used with millions of qubits, but only for programs with a restricted set of quantum operations (namely X, CNOT, and multi-controlled X).

### Quick Reference Pages

- [IQ# Magic Commands](xref:microsoft.quantum.guide.quickref.iqsharp): Quick reference page for IQ# magic commands within Q# Jupyter Notebooks.

---
title: The Q# User Guide
description: Overview of the User Guide's purpose and contents
author: gillenhaalb
ms.author: a-gibec
ms.date: 03/05/2020
ms.topic: article
uid: microsoft.quantum.guide
no-loc: ['Q#', '$$v']
---

# The Q# User Guide

Welcome to the Q# User Guide! 

In the different topics of this guide, we introduce some of the basics for developing quantum programs using the Q# programming language.

We refer to the [Q# GitHub repository](https://github.com/microsoft/qsharp-language/tree/main/Specifications/Language#q-language) for a full specification and documentation of the Q#. 

## User Guide Contents

- [Q# programs](xref:microsoft.quantum.guide.programs): An quick introduction to quantum programs in Q#. 

- [Ways to run a Q# program](xref:microsoft.quantum.guide.host-programs): describes how a Q# program is run, and provides an overview of the various ways you can call the program: from the command line, in Q# Jupyter Notebooks, or from a classical host program written in Python or a .NET language.

- [Testing and debugging](xref:microsoft.quantum.guide.testingdebugging): Details some techniques for making sure your code is doing what it is supposed to do. 
    Due to the general opacity of quantum information, debugging a quantum program can require specialized techniques. 
    Fortunately, Q# supports many of the classical debugging techniques programmers are familiar with, as well as those that are quantum-specific. These include creating and running unit tests in Q#, embedding *assertions* on values and probabilities in your code, and the `Dump` functions which output the states of target machines. 
    The latter can be used alongside our full-state simulator to debug certain parts of computations by skirting some quantum limitations, for example, the [no-cloning theorem](xref:microsoft.quantum.concepts.pauli).

### Quantum Simulators and Resource Estimators

- [Quantum simulators and host applications](xref:microsoft.quantum.machines): An overview of the different simulators available, as well of how host programs and target machines work together to run Q# programs.

- [Full state simulator](xref:microsoft.quantum.machines.full-state-simulator): The target machine which simulates the full quantum state. Useful for fully running or debugging smaller-scale programs (less than a few dozen qubits)

- [Resources estimator](xref:microsoft.quantum.machines.resources-estimator): Estimates the resources required to run a given instance of a Q# operation on a quantum computer.

- [Trace simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro): Runs a quantum program without actually simulating the state of a quantum computer, and therefore can run quantum programs that use thousands of qubits. Useful for debugging classical code within a quantum program, as well as estimating resources required.

- [Toffoli simulator](xref:microsoft.quantum.machines.toffoli-simulator): A special-purpose quantum simulator that can be used with millions of qubits, but only for programs with a restricted set of quantum operations - X, CNOT, and multi-controlled X.

### Quick Reference Pages

- [IQ# Magic Commands](xref:microsoft.quantum.guide.quickref.iqsharp): Quick reference page for IQ# magic commands within Q# Jupyter Notebooks.

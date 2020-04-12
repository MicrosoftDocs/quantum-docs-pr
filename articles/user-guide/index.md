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

Here we detail the core concepts of the Q# language as well provide all the information you need to start writing your own quantum programs.

## User Guide Contents

- [Q# Basics](xref:microsoft.quantum.techniques.file-structure): an introductory overview of the purpose and functionality of the Q# programming language.  

### Q# Language

- [Types in Q#](xref:microsoft.quantum.guide.types): lays out the Q# type model and describes the syntax for specifying and working with types.

- [Type Expressions](xref:microsoft.quantum.guide.expressions): details how to specify, reference, combine, and operate on values of each type in Q#. 

### Using Q#

- [Host Programs](xref:microsoft.quantum.guide.hosts): describes the role that classical host programs play in executing Q# programs, as well as how to implement them for various classical host languages (C#, Python, etc.).

- [Q# Libraries](xref:microsoft.quantum.guide.libraries): introduces the available Q# Libraries and their role as part of the QDK, allowing you to get straight into developing quantum programs for a wide range of uses. 
    These include numerics, quantum chemistry, quantum machine learning, as well as the standard libraries which provide general tools for writing Q# programs.

- [Structure of a Q# File](xref:microsoft.quantum.guide.filestructure): describes the structure and syntax of a `.qs` Q# file.

- [Operations and Functions](xref:microsoft.quantum.guide.operationsfunctions) details the two callable types of the Q# language: *operations*, which include action on qubits and quantum systems; and *functions*, which strictly work with classical information. 
    Here you see how to define and call them, including the adjoint and controlled versions of quantum operations.

- [Variables](xref:microsoft.quantum.guide.variables): describes the role of variables within Q# programs and how to leverage them effectively. 
    For example, you will learn about binding scopes, as well as the difference between immutable/mutable variables and how to assign/re-assign them.

- [Working with qubits](xref:microsoft.quantum.guide.qubits): describes the features of Q# that you can use to address individual qubits and systems of qubits. 
    Specifically, that entails their allocation, performing operations on them, and ultimately their measurement. 

- [Control Flow](xref:microsoft.quantum.guide.controlflow): details the programming control flow patterns available in Q#, which includes many standard techniques (conditional execution, for loops, while loops, etc.) as well as the quantum-specific "Repeat-Until-Success" pattern.

- [Testing and debugging](xref:microsoft.quantum.guide.testingdebugging) details some techniques for making sure your code is doing what it is supposed to do. 
    Due to the general opacity of quantum information, debugging a quantum program can require specialized techniques. 
    Fortunately, Q# supports many of the classical debugging techniques programmers are used to, as well as those that are quantum-specific. These include creating/running unit tests in Q#, embedding *assertions* on values and probabilities in your code, and the `Dump` functions which output the state of target machine. 
    The latter can be used alongside our full-state simulator to debug certain parts of computations by skirting some quantum limitations (e.g. the no-cloning theorem).

### Quantum Simulators and Resource Estimators

- fill if/when get this moved in TOC added

### Quick Reference Pages

- [IQ# Magic Commands](xref:microsoft.quantum.guide.quickref.iqsharp): Quick reference page for IQ# magic commands within Q# Jupyter Notebooks.

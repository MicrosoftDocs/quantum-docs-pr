---
title: Software stack | Microsoft Docs 
description: Software stack
author: QuantumWriter
uid: microsoft.quantum.concepts.software-stack
ms.author: nawiebe@microsoft.com
ms.date: 12/11/2017
ms.topic: article
---

# Software stack for quantum computing
Normally when we think of a computer we envision a single device running an application, but modern computing environments are much more complex and advanced. The application we interact with typically rests on multiple layers of software that provide for the application's execution down to the hardware level. These software layers are necessary to abstract the development of an application solution from the underlying complexity of the complete computing system. If a developer had to think about bus, cache architectures, communication protocols, and more while writing a simple smartphone app, the task would become much more complex.  The concept of a *software stack* was developed in classical computing to address these issues.  Borrowing from the classical concept, a software stack is also a key part of the vision behind quantum computing with Q#.

## Conventional stack
The key idea behind a software stack is recursion.  It consists of several nested layers of interfaces that abstract the details of the lower levels of the device away from the developer.  For example, a commonly used software stack involves running ASP.NET (a programming language), on top of SQL server (a relational database management system), which runs on top of Internet Information Services (a web server), which runs on top of Windows server (an operating system), which drives the computer hardware.  By looking at software as a hierarchy, one can write software in ASP.NET without needing to understand the low-level details of all the software below it.

## Quantum stack

The software stack in quantum computing is no different in principle, and in practice operates at a lower level than traditional stacks.  What does a quantum stack look like?  A quantum computer is not a replacement for traditional (often called classical) computers.  In fact, quantum computers will almost certainly work in tandem with classical computers to solve computational problems.  In part, this arises because of the fragility of quantum data.  Quantum data is so fragile that if you even look at it you almost certainly damage the information being observed.  Quantum computers will thus need to be designed with quantum error correction in mind so that stray interactions from its physical environment do not inadvertently damage the information and computation. For this reason, a natural target for Q# is an error-corrected quantum computer (often called a *fault-tolerant* quantum computer) that accepts a list of quantum instructions (called gates or gate operations) and applies those instructions to the quantum data stored within it.  Note that if the number of qubits and gate operations in a quantum algorithm or program is small enough, error correction may not be absolutely necessary.  However as the number of qubits and gate operations grow, it will more certainly be a requirement, thus we architect our software stack and Q# to aptly and efficiently handle error correction and enable scalable, fault-tolerant quantum computing.

### Error correction
Error correction requires a fast and reliable classical computer to be run in concert with the quantum computer to correct errors as they appear in the quantum computation.  In practice, components such as field-programmable gate arrays (FPGAs) or fast cryogenic processors may be needed to identify and correct the errors faster than they naturally accumulate in the quantum computer.  As a result, a quantum computer is a hybrid machine comprised of several different computational devices that operate over a wide range of temperatures.  For this reason, it is much more helpful to think about programming a quantum computer through the lens of a software stack, as there are many layers of hardware and software (classical and quantum) required to ultimately achieve the implementation of a quantum algorithm on a quantum computer.

### Quantum conceptual stack
A conceptual stack that illustrates the functional flow of factoring 8704143553785700723 in a quantum computing environment is shown below:

![Software stack](~/media/concepts_stack.png)
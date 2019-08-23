---
title: Q# Manual | Microsoft Docs 
description: Q# Manual
author: E. Gonzalez
ms.author: v-edsanc@microsoft.com 
ms.date: 07/31/2019
ms.topic: article
uid: microsoft.quantum.manual.intro
---

# Q# Manual

## What is Q#?

Q# (Q-sharp) is a domain-specific programming language used for
expressing quantum algorithms.
It is to be used for writing subroutines that execute on an adjunct
quantum processor, under the control of a classical host program and computer.
Until quantum processors are widely available, Q# subroutines execute on a simulator.

A natural model for quantum computation is to treat the quantum computer
as a coprocessor, similar to that used for GPUs, FPGAs, and other adjunct
processors.
The primary control logic runs classical code on a classical "host" computer.
When appropriate and necessary, the host program can invoke a subroutine
that runs on the adjunct processor.
When the subroutine completes, the host program gets access to the
subroutine's results.

Q# provides a small set of primitive types, along with two ways
(arrays and tuples) for creating new, structured types.
It supports a basic procedural model for writing programs,
with loops and if/then statements.
The top-level constructs in Q# are user defined types, operations,
and functions.

Q# is scalable: it can be used to write simple demonstration programs like teleport that run on a few qubits, but also supports writing large, sophisticated programs such as simulations of complex molecules that will require large machines with millions of qubits. Even though large physical machines are still in the future, Q# allows a programmer to program complex quantum algorithms now. What is more, Q# supports various tasks such as debugging, profiling, resource estimation, and certain special-purpose simulations in a scalable way.

## Why Q#?

> [!VIDEO https://www.youtube.com/embed/cOUrzxyng04]

 While quantum hardware is still in early development, we need to build software for quantum computers to take advantage
 of the quantum power of computation when the time comes. Q# is a tool made to provide a platform where developers can write and test programs to be run on a future generation of quantum computers.

For more information about the foundations and motivation of Q# check out [Why do we need Q#?](https://devblogs.microsoft.com/qsharp/why-do-we-need-q/).

## How to learn Q#?

### Pre-required knowledge to use Q#

There is no need to be an expert on quantum physics to start writing your first quantum programs. However, there are some concepts that are essential to understand quantum computing:

* **Complex numbers:** quantum mechanics makes use of complex numbers to express quantum states. Some experience with complex numbers is crucial to
understand the basics of quantum computation.
* **Linear algebra (vectors and matrices):** quantum states are vectors 
  in a vector space over the complex numbers. Quantum computing makes 
  intense use of linear operators acting on these states. Therefore 
  some level of expertise in linear algebra is indispensable to use Q#.
* **Dirac notation:** most quantum computing texts use Dirac notation 
  to express the mathematical concepts. Dirac notation is just a simple 
  notation for linear algebra widely used in quantum physics.
* **Basic concepts of quantum mechanics:** while it is not required to
  have a deep understanding of quantum mechanics to use Q#, it is highly
  recommended to be familiar with some basic concepts, namely
  *quantum state*, *qubit*, *observable*, *measurement*, *Hamiltonian*,
  *superposition*, *entanglement*, *interference*, among others.  

### Learning materials

Quantum computing is an emerging field and fortunately, there is an immense amount of learning resources online. Sometimes so many options can get overwhelming, so here we gather a few of them.

#### Quantum computing concepts

On this list you can find resources for learning concepts related with quantum computation:

* A good place to start is our guide for [Quantum computing concepts](xref:microsoft.quantum.concepts.intro), a compilation of basic concepts for quantum computing.
* The book *Learn Quantum Computing with Python and Q#* (Sarah C. Kaiser and Christopher E. Granade) provides an excellent introduction for people who have little to no experience with quantum mechanics, but some programming background.
* MIT OpenCourseWare has an excellent [online course](https://www.youtube.com/playlist?list=PLUl4u3cNGP61-9PEhRognw5vryrSEVLPr) imparted by Allan Adams for learning the basics of quantum mechanics.
* In parternship with Microsft's quantum team, Brilliant has launched an interactive 
  course called ["Quantum Computing"](https://cloudblogs.microsoft.com/quantum/2019/05/23/microsoft-brilliant-team-up-to-offer-quantum-curriculum/).
* The book *Quantum Computation and Quantum Information* (Michael A. Nielsen, Isaac L. Chuang) being the most cited text in the field of quantum computation is regarded as the standard text on the subject. The book assumes minimal prior experience with quantum mechanics and with computer science. It is an excellent choice for those readers who want a rigorous introduction to the topic as well as for those who are looking for references for advanced concepts.

#### Learning Q#

On this list you can find resources for learning the Q# programming language:

* The easiest way to learn Q# is through the [Quantum Katas](https://github.com/Microsoft/QuantumKatas/), an open-source
  project containing programming exercises aimed at teaching quantum computing.
  In particular, the [online version](https://mybinder.org/v2/gh/Microsoft/QuantumKatas/master?filepath=index.ipynb) of
  the Quantum Katas in form of Q# Jupyter Notebooks is specially easy to use. In less that 5 min you can start
  to write your first quantum program without needing to install anything.
* You can find more tutorials to get started with Q# in [Getting Started](xref:microsoft.quantum.install) and
  [Quickstart - your first quantum program](xref:microsoft.quantum.write-program).
* Check out [Q# blog](https://devblogs.microsoft.com/qsharp/) and [Microsoft Quantum Blog](https://cloudblogs.microsoft.com/quantum/?ext) to stay up to date of the latest news and resources about Q#.

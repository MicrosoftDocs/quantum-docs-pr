---
title: Quantum computing and the Q# programming language| Microsoft Docs 
description: Quantum computing stages and Q#
author: MikeDodaro
uid: microsoft.quantum.concepts.quantum-computing-q#
ms.author: cathy.palmerbe@microsoft.com
ms.date: 05/1/2019
ms.topic: article
---

# Quantum computing and the Q# programming language
There are several broad stages of programming a quantum computation.  The first stages are described in the [previous article](xref:microsoft.quantum.concepts.software-stack) as in the following figure showing a conceptual stack that illustrates factoring 8704143553785700723 in a quantum computing environment

![Software stack](~/media/concepts_stack.png)

## Specification and algorithm
Arguably most challenging stage, is specifying the problem that one wishes to solve.  A problem, for example, is to factor the number 8704143553785700723 into a product of two prime numbers.  The next stage involves designing an algorithm for solving this computational problem.  In this case, Shor's famous quantum factoring algorithm can be used to find the factors.  Then the algorithm is expressed in Q# and a sequence of quantum operations is output that could be run on an idealized error-free quantum computer.  

## Physical qubits
In this example, assume nature is not so kind as to provide an error-free quantum computer so the subsequent step takes the operations emitted by Q# and translates them using templates specified by the quantum error correction method chosen into physical gates that the basic hardware can execute.  This process involves replacing every logical qubit described in the previous model with a host of physical qubits that are used to store and protect the information within a single qubit in a redundant fashion.  The redundancy is needed to resist local errors on the constituent physical qubits long enough for such errors to be detected and corrected.  

## Physical gates
Just as the logical qubits described by the Q# code need to be replaced with many physical qubits, similarly, each quantum gate described in the output needs to be translated into a sequence of physical gates that act upon the physical qubits.  For this reason, the output of Q# is seldom the final target for quantum computing, and further levels of abstraction are needed to execute the code on hardware in an oblivious fashion.

## Control computer
The physical gate sequence is then loaded into an ordinary computer that sends these instructions down to a control computer that interfaces directly with the quantum computer.  This layer within the software stack is often handled by experimental control software such as [QCoDeS](http://qcodes.github.io/Qcodes/).

## Interface computer
The final step in this process involves the interface computer first streaming the gates as needed to a fast control computer. Then the fast control computer applies the voltages needed--commonly called pulses--to implement the required gates on qubits. This has to be done while correcting any errors through quantum error correction.  Cryogenic FPGAs or other exotic hardware may be needed to perform these steps within the stringent time requirements imposed by the rate at which errors appear in the quantum computer.  The target language on this level is often [VHDL](https://en.wikipedia.org/wiki/VHDL), which requires a distinct way of thinking from that which is used at the top end of the stack to parse a description of a quantum algorithm.

## The Q# quantum programming language
Q# provides a simple language that allows developers to write code that targets a wealth of quantum computing platforms and interface with the intervening layers of software that stand between the user and the quantum device.  The language facilitates this by embracing the notion of a software stack and abstracting many of the details of the underlying quantum computer while allowing other levels of the stack, exposed through a language such as C#, to perform the necessary translations from Q# code to fundamental operations.  Developers focus on what they do best: designing algorithms and solving problems.


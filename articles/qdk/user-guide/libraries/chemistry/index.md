---
title: Introduction to the Quantum Chemistry Library
description: Learn about the Microsoft Quantum Chemistry Library and how it is used to simulate electronic structure problems on quantum computers.  
author: QuantumWriter
ms.author: Alan.Geller@microsoft.com
ms.date: 12/11/2017
ms.topic: article
uid: microsoft.quantum.chemistry.concepts.intro
---

# Introduction to the Quantum Chemistry Library

Simulation of physical systems has long played a central role in quantum computing.  This is because quantum dynamics are widely believed to be intractable to simulate on quantum computers, meaning that the complexity of simulating the system scales exponentially with the size of the quantum system in question.  Simulating problems in chemistry and material science remains perhaps the most evocative application of quantum computing and would allow us to probe chemical reaction mechanisms that hitherto were beyond our ability to measure or simulate.  It would also allow us to simulate correlated electronic materials such as high-temperature superconductors. The list of applications in this space is vast.

The purpose of this documentation is to provide a concise introduction to simulating electronic structure problems on quantum computers in order to help the reader understand the role that many aspects of the Hamiltonian simulation library play within the space.  We begin with a brief introduction to quantum mechanics and then proceed to discuss how electronic systems are modeled in it.  We will then discuss how such quantum dynamics can be emulated using a quantum computer.  Once this is complete we will discuss two methods used to compile the quantum dynamics to sequences of elementary gates: Trotter-Suzuki decompositions and qubitization.

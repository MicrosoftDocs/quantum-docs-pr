---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Quantum Computing Concepts
description: What is quantum computing?
services: service-name-with-dashes-AZURE-ONLY 
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: QuantumWriter
ms.author: MSFT-alias-person-or-DL
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
uid: microsoft.quantum.concepts.intro
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# ms.service: service-name-from-white-list
# product-name-from-white-list

# Optional fields. Don't forget to remove # if you need a field.
# ms.custom: can-be-multiple-comma-separated
# ms.devlang:devlang-from-white-list
# ms.suite: 
# ms.tgt_pltfrm:
# ms.reviewer:
# manager: MSFT-alias-manager-or-PM-counterpart
---

<!---
Purpose of an Overview article: 
1. To give a TECHNICAL overview of a service/product: What is it? Why should I use it? It's a "learn" topic that describes key benefits and our competitive advantage. It's not a "do" topic.
2. To help audiences who are new to service but who may be familiar with related concepts. 
3. To compare the service to another service/product that has some similar functionality, ex. SQL Database / SQL Data Warehouse, if appropriate. This info can be in a short list or table. 
-->

# What is quantum computing?

A host of new computer technologies have emerged within the last few years, and quantum computing is arguably the technology requiring the greatest paradigm shift on the part of developers.  Quantum computers were proposed in the 1980s by Richard Feynman and Yuri Manin.  The intuition behind quantum computing stemmed from what was often seen as one of the greatest embarrassments of physics: remarkable scientific progress faced with an inability to model even simple systems. You see, quantum mechanics was developed between 1900 and 1925 and it remains the cornerstone on which chemistry, condensed matter physics and technologies ranging from computer chips to LED lighting ultimately rests.  Yet despite these successes, even some of the simplest systems seemed to be beyond the human ability to model with quantum mechanics.  This is because simulating systems of even a few dozen interacting particles requires more computing power than any conventional computer can provide over thousands of years!

There are many ways to understand why quantum mechanics is hard to simulate.  Perhaps the simplest is to see that quantum theory can be interpreted as saying that matter, at a quantum level, is simultaneously in a host of different possible configurations (known as *states*) at the same time.  Unlike classical probability theory, these many configurations of the quantum state, which can be potentially observed, may interfere with each other like waves in a tidepool.  This interference prevents the use of statistical sampling to obtain the quantum state configurations.  Rather, we have to track *every possible* configuration a quantum system could be in if we want to understand the quantum evolution.  

Consider a system of electrons where electrons can be in any of say $40$ positions.  The electrons therefore may be in any of $2^{40}$ configurations (since each position can either have or not have an electron). To store the quantum state of the electrons in a conventional computer memory would require in excess of 130 Gb of memory!  This is substantial, but within the reach of some computers.  If we allowed the particles to be in any of $41$ postions, there would be twice as many configurations at $2^{41}$ which inturn would require more than $260$Gb of memory to store the quantum state. This game of increasing the number of positions cannot be played indefinitely if we want to store the state conventionally as we quickly exceed memory capacities of the world's most powerful machines.  At a few hundred electrons the memory required to store the system exceeds the number of particles in the universe; thus there is no hope with our conventional computers to ever simulate their quantum dynamics. And yet in nature, such systems readily evolve in time according to quantum mechanical laws, blissfully unaware of the inability to engineer and simulate their evolution with conventional computing power.

This observation lead those with an early vision of quantum computing to ask a simple yet powerful question: can we turn this difficulty into an opportunity?  Specifically, if quantum dynamics are hard to simulate what would happen if we were to build hardware that had quantum effects as fundamental operations?  Could we simulate systems of interacting particles using a system that exploits exactly the same laws that govern them naturally? Could we investigate tasks that are entirely absent from nature, yet follow or benefit from quantum mechanical laws?  These questions led to the genesis of quantum computing.

The foundational core of quantum computing is to store information in quantum states of matter and to use quantum gate operations to compute on that information, by harnessing and learning to "program" quantum interference.  An early example of programming interference to solve a problem thought to be hard on our conventional computers was done by Peter Shor in 1994 for a problem known as factoring.  Solving factoring brings with it the ability to break many of our public key cryptosystems underlying the security of e-commerce today, including RSA and ECDLP.  Since that time, fast and efficient quantum computer algorithms have been developed for many of our hard classical tasks: simulating physical systems in chemistry, physics, and materials science, searching an unordered database, solving systems of linear equations, and machine learning.

Designing a quantum program to harness interference may sound like a daunting challenge, and while it is, many techniques and tools, including our Microsoft Quantum Development Kit, have been introduced to make quantum programming and algorithm development more accessible. There are a handful of basic strategies that can be used to manipulate quantum interference in a way useful for computing, while at the same time not causing the solution to be lost in a tangle of quantum possibilities. Quantum programming is a distinct art from classical programming requiring very different tools to understand and express quantum algorithmic thinking. Indeed, without general tools to aid a quantum developer in tackling the art of quantum programming, quantum algorithmic development is not so easy.

We present our Microsoft Quantum Development Kit to empower a growing community with tools to unlock the quantum revolution for their tasks, problems, and solutions. Our high-level programming language, Q#, was designed to address the challenges of quantum information processing; it is integrated in a software stack that enables a quantum algorithm to be compiled down to the primitive operations of a quantum computer.  Before approaching the programming language, it's helpful to review the basic principles on which quantum computing is based. We will take the fundamental rules of quantum computing to be axioms, rather than detailing their foundations in quantum mechanics. Additionally, we will assume basic familiarity with linear algebra (vectors, matrices etc). If a deeper study of quantum computing history and principles is desired, we refer you to the  [reference section](quantum-ForMoreInfo.md) containing more information.

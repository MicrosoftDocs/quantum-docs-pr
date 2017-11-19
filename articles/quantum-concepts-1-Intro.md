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

A host of new computer technologies have emerged within the last few years, but quantum computing is the technology that  requires the greatest paradigm shift on the part of developers.  Quantum computers were proposed in the 1980s by Richard Feynman and Yuri Manin.  The intuition behind quantum computing stemmed from what was often seen as one of the greatest embarrassments of physics.  Quantum mechanics was developed between 1900 and 1925 and it remains the cornerstone on which chemistry, condensed matter physics and technologies ranging from from computer chips to LED lighting ultimately rests.  Yet despite these successes, even some of the simplest systems seemed to be beyond the human ability to model with quantum mechanics.  This is because simulating systems of even a few dozen interacting particles  require more computing power than any conventional computer can provide over thousands of years.

There are many ways to understand why quantum mechanics is hard to simulate.  Perhaps the simplest is to see that quantum theory can be interpreted as saying that matter, at a quantum level, is simultaneously is in a host of different possible configurations (known as states) at the same time.  Unlike classical probability theory, these configurations the quantum state could be potentially observed in can interfere with each other like waves on the beach.  This interference prevents us from using statistical sampling to solve such problems and means that we have to track every possible configuration that a quantum system could be in if we want to understand its evolution.  

Consider a system of electrons where electrons can be in any of $40$ positions.  The electrons can therefore be in any of $2^{40}$ configurations (since each position can either have or not have an electron). We would therefore need in excess of 130 Gb of memory to store the quantum state of those electrons.  This is substantial, but within the reach of some computers.  If we allowed the particles to be in any of $41$ postions there would be now $2^{41}$ configurations which means we would need more than $260$Gb of memory to store the quantum state. This game of increasing the number of positions cannot be played indefinitely.  At a few hundred electrons the memory required to store the system exceeds the number of particles in the universe and we lose all hope of simulating their quantum dynamics by adding more hardware.    And yet, in nature such systems to evolve in time according to these laws blissfully unaware of all the computing power they would need to follow them.

This observation lead the creators of quantum computing to ask a question: can we turn this difficulty into an opportunity?  Specifically, if quantum dynamics are hard to simulate what would happen if we were to build hardware that had quantum effects as fundamental operations?  Could we simulate systems of interacting particles using the same laws that govern them naturally? Could we investigate other tasks that are entirely absent from nature?  These questions were the genesis of quantum computing.

The core idea behind quantum computing is to store data in quantum states of matter and use quantum gate operations to bend quantum interference to our will.  One of the first examples of a quantum algorithm was Shor's algorithm for factoring integers, which promised to break the public key cryptosystems that keep e-commerce secure.  Further investigation revealed that simulating physical systems, search problems, solving systems of equations, and machine learning tasks can all be modeled using quantum operations.

Designing a quantum program to harness interference may sound like a daunting challenge, and it is. Only a handful of basic strategies have been discovered that can manipulate quantum interference in a way that is useful for computing, and at the same time do not cause the data to be lost in a tangle of quantum possibilities. Quantum programming is therefore a distinct art from classical programming and requires very different tools to understand and express quantum algorithmic thinking. Indeed, not having general tools to aid the quantum developer tackle such challenges is one of the biggest obstacles faced in quantum computer programming.

Q# was designed to address these challenges by providing a high-level programming language capable of quantum information processing while running on a software stack that enables a quantum algorithm to be compiled down to the primitive operations of a quantum computer.  Before approaching the programming language, it's helpful to review the basic principles on which quantum computing is based. We will take the fundamental rules of quantum computing to be axioms, rather than detailing their foundations in quantum mechanics. Additionally, basic familiarity with linear algebra (vectors, matrices, etc.) will be helpful, although we provide a brief review. If a deeper study of quantum computing history and principles is desired, please see the [reference section](quantum-ForMoreInfo.md)  containing more information.

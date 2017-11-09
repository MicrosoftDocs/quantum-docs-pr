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

A host of new computer technologies have emerged within the last few years, but quantum computing is the technology that  requires the greatest paradigm shift on the part of developers.  Quantum computers were proposed in the 1980s by Richard Feynman and Yuri Manin.  The intuition behind quantum computing stemmed from what was often seen as one of the greatest embarrassments of physics.  Quantum mechanics was developed between 1900 and 1925 and it remains the cornerstone on which chemistry, condensed matter physics and technologies ranging from from computer chips to LED lighting ultimately rests.  Yet despite these successes, even some of the simplest systems seemed to be beyond quantum mechanics power to explain.  This is because the laws that describe systems of even a few dozen interacting particles  require such immense computing power to simulate that no conceivable computer can accurately simulate their dynamics within the lifetime of the universe.

There are many ways to understand why quantum mechanics is hard to simulate.  Perhaps the simplest is to see that quantum theory can be interpreted as saying that matter, at a quantum level, is simultaneously is in a host of different possible configurations (known as states) at the same time.  Unlike classical probability theory, these potential configurations can interfere with each other like waves on the beach.  This interference prevents us from using statistical sampling to solve such problems and means that we have to track every possible configuration that a quantum system could be in if we want to understand its evolution.  Tracking such information typically needs memory that grows exponentially with the number of particles in the system, meaning that if you are given a supercomputer that can simulate a system of 40 interacting electrons you would need a supercomputer with twice the memory to simulate 41 interacting electrons.  This game cannot be played forever.  Soon (at a few hundred electrons), the memory required to store the system exceeds the number of particles in the universe and we lose all hope of simulating their quantum dynamics with such methods.  And yet, in nature such systems to evolve in time according to these laws blissfully unaware of all the computing power they would need to follow them.

This observation lead the creators of quantum computing to ask a question: can we turn this embarrassment into an opportunity?  Specifically, if quantum dynamics are hard to simulate what would happen if we were to build hardware that had quantum effects as fundamental operations?  Could we simulate systems of interacting particles with the simplicity that nature seems to do it with?  Could there be other tasks that are entirely absent from nature that such a device could speed up?  These questions were the genesis of quantum computing.

The core idea behind quantum computing is to store data in quantum states of matter and use quantum gate operations to bend quantum interference to our will and thereby use it to solve problems that would otherwise be beyond the reach of existing computers.  The first example of such an algorithm was Shor's algorithm for factoring, which promised to break the public key cryptosystems that keep e-commerce secure.  Further investigation revealed that simulating physical systems, search problems, sampling tasks, solving systems of equations and machine learning tasks all can benefit strongly from such quantum operations.

Designing a quantum program to harness interference to solve problems may sound like a daunting challenge, and in fact it is. Only a handful of basic strategies have been discovered that can be used to manipulate quantum interference in a way that is useful for computing and do not cause the data to be lost in a tangle of quantum possibilities that would be near impossible to measure let alone understand.  Quantum programming is therefore a distinct art from classical programming and requires very different tools to understand and express quantum algorithmic thinking. Indeed, not having general tools to aid the quantum developer tackle such challenges is one of the biggest obstacles faced in quantum computer programming.

Q# was designed to help address these challenges by providing a high-level programming language capable of concisely expressing quantum information processing while also providing a solution that can be used within a complete software stack to allow a quantum algorithm to be compiled all the way down to primitive operations on the quantum computer.  Before we delve into the details of the programming language, we provide a brief review of quantum computing. We will take the fundamental rules of quantum computing to be axioms, rather than explaining how they arise from more basic postulates of quantum mechanics. Additionally, we will assume basic familiarity with linear algebra (vectors, matrices etc) in our discussion.  We recommend the following introductory materials on quantum computing listed at the end of this review for those seeking more comprehensive background on quantum computing.

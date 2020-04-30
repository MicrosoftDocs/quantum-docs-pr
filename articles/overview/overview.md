---
title: Introduction to quantum computing
description: Learn what quantum computing is, what quantum computers can do, and how you can learn quantum computing.
author: bradben
ms.author:  bradben
ms.date: 04/22/2020
ms.topic: overview
uid: microsoft.quantum.overview.introduction
---

# Introduction to quantum computing and the Quantum Development Kit

The Microsoft Quantum Development Kit (QDK) is a set of open-source tools designed to help developers learn quantum algorithms and write quantum programs. Quantum computing holds the promise to solve some of our planet's biggest challenges - in the areas of environment, agriculture, health, energy, climate, materials science, and others we haven't encountered yet.  

For some of these problems, even our most powerful computers run into problems. While quantum technology is just beginning to impact the computing world, it could be far-reaching and change the way we think about computing.

## What is quantum computing?

In modern usage, the word quantum means the smallest possible discrete unit of any physical property, usually referring to properties of atomic or sub-atomic particles. Quantum computers use actual quantum particles, artificial atoms, or collective properties of quantum particles as processing units, and are large, complex, and expensive devices.

Harnessing the unique behavior of quantum physics and applying it to computing, quantum computers introduce new concepts to traditional programming methods, making use of quantum physics behaviors such as superposition, entanglement, and quantum interference.

## What can a quantum computer do?

A quantum computer isn't a supercomputer that can do everything faster: it just does some select things exceptionally well.

### Quantum simulation

Since quantum computers use quantum phenomena in computation, they are well-suited for modeling other quantum systems. Photosynthesis, superconductivity, and complex molecular formations are examples of quantum mechanisms that quantum programs can simulate.

### Cryptography and Shor’s algorithm

In 1994, Peter Shor showed that a scalable quantum computer could break every widely used encryption technique. Classical cryptography relies on the intractability of operations on large numbers, such as factorization of large numbers into two prime numbers, and quantum computers excel at factorization.

### Search and Grover’s algorithm

In 1996, Lov Grover developed a quantum algorithm that dramatically sped up the solution to unstructured data searches, running the search in fewer steps than any classical algorithm could. This increased speed becomes significant in lists that contain millions or billions of items.

> [!NOTE] 
> Ready to try it out? Jump to the Q# tutorial [Implement Grover's search algorithm in Q#](xref:microsoft.quantum.quickstarts.search).

### Machine Learning

A majority of numerical calculations in classical computing consists of solving linear systems of equations. This is especially true in the field of machine learning where most of the computation cost goes into calculating the inverse of huge matrices.

Fortunately, there is a quantum algorithm that allows us to approximate a solution exponentially faster than a classical computer. Reducing computation times in these areas will help address the energy crisis, climate change, food scarcity, and personal and precise medical diagnosis.

### Quantum-inspired computing and optimization

Quantum-inspired algorithms use quantum principles for increased speed and accuracy but implement on classical computer systems. This approach allows developers to leverage the power of new quantum techniques today without waiting for quantum hardware, which is still an emerging industry.

Optimization is the task of balancing a system for maximum efficiency and minimum cost and is a crucial issue for industry and science. Quantum-inspired optimization algorithms running on today's classical computers can find solutions that up to now have not been possible. In addition to optimizing traffic flow to reduce congestion, there is airplane gate assignment, package delivery, job scheduling and more. With breakthroughs in materials science, there will be new forms of energy, batteries with larger capacity, and lighter and more durable materials.

> [!NOTE]
> Read more about how Microsoft quantum-inspired computing is being used in [materials science](https://cloudblogs.microsoft.com/quantum/2020/01/21/oti-lumionics-accelerating-materials-design-microsoft-azure-quantum/), [risk management](https://cloudblogs.microsoft.com/quantum/2019/05/22/microsoft-quantum-collaborates-with-willis-towers-watson-to-transform-risk-management-solutions/), and [medicine](https://blogs.microsoft.com/blog/2018/05/18/microsoft-quantum-helps-case-western-reserve-university-advance-mri-research/).

### Machine learning

Machine learning on classical computers is revolutionizing the world of science and business. However, the high computational cost of training the models hinders the development and scope of the field. The field of quantum machine learning explores how to devise and implement quantum software that could enable machine learning that is faster than that of classical computers.

The Quantum Development Kit comes with the Quantum Machine Learning Library that gives you the ability to run hybrid quantum/classical machine learning experiments. The library includes samples and tutorials, and provides the necessary tools to implement a new hybrid quantum-classical algorithm, the circuit-centric quantum classifier, to solve supervised classification problems.

## Q# and the Microsoft Quantum Development Kit (QDK)

Q# is Microsoft's open-source programming language for developing and running quantum algorithms. It is part of the QDK, a full-featured development kit for Q# that you can use with standard tools and languages to develop quantum applications that you can run in various environments, including the built-in full-state quantum simulator.

There are extensions for Visual Studio and VS Code, and packages for use with Python and Jupyter Notebooks.

The QDK includes a standard library along with customized chemistry, machine learning, and numerics libraries.

The documentation includes a Q# language guide, tutorials, and sample code to get you started quickly, and rich articles to help you dive deeper into quantum computing concepts.  

## Microsoft quantum hardware partners

Microsoft is partnering with quantum hardware companies to provide developers with cloud access to quantum computers. Leveraging the [Azure Quantum](https://azure.microsoft.com/en-us/services/quantum/) platform and the Q# language, developers will be able to explore quantum algorithms and run their quantum programs on different types of quantum hardware.

[IonQ](https://ionq.com/news/november-4-2019-microsoft-partnership) and [Honeywell](https://www.honeywell.com/en-us/newsroom/news/2019/11/the-future-of-quantum-computing) both use **trapped ion** based processors, utilizing individual ions trapped in an electronic field, whereas [QCI](https://quantumcircuits.com/news-and-publications/quantum-circuits-partners-with-microsoft-on-azure-quantum) uses superconducting metal circuits.

## Next steps
Key concepts for quantum computing
Quickstarts
<!-- >> [!div class="nextstepaction"]
> [Next steps button](contribute-get-started-mvc.md) -->

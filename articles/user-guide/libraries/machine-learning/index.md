---
title: Introduction to the Quantum Machine Learning Package | Microsoft Docs
description: Introduction to the Quantum Machine Learning Package
author: QuantumWriter
ms.author: alexeib
ms.date: 12/5/2019
ms.topic: article
uid: microsoft.quantum.machine-learning.concepts.intro
no-loc: ['Q#', '$$v']
---

# Introduction to the Quantum Machine Learning Library

The Quantum Machine Learning Library is an API, written in Q#, that gives you the ability to run hybrid quantum/classical machine learning experiments. The library gives you the ability to:

- Load your own data to classify with quantum simulators

- Use samples and tutorials to get introduced to the field of quantum machine learning

You can expect low performance compared to current classical machine learning frameworks (remember that everything is running on top of the simulation of a quantum device that is already computationally expensive).

The purpose of this documentation is:

- A concise introduction to machine learning tools (written in Q\#) for hybrid quantum/classical learning.
- Introduce machine learning concepts and specifically their realization in quantum circuit centric classifiers (also known as quantum sequential classifiers).
- Provide a set of tutorials on the basics to start using the tools provided by the library.
- Discuss the training and validation methods for such classifiers and how they translate into specific Q\# operations provided by the library.

The model implemented in this library is based on the quantum-classical training scheme presented in [Circuit-centric quantum classifiers](https://arxiv.org/abs/1804.00633)

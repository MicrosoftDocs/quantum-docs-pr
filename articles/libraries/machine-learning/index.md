---
title: Introduction to the Quantum Machine Learning Package | Microsoft Docs
description: Introduction to the Quantum Machine Learning Package
author: QuantumWriter
ms.author: alexeib@microsoft.com
ms.date: 12/5/2019
ms.topic: article
uid: microsoft.quantum.machine-learning.concepts.intro
---

# Introduction to the Quantum Machine Learning Library

The Quantum Machine Learning Library is a high-level API, written in Q#, that provides the first playground to run hybrid quantum/classical machine learning experiments. From this library you can expect:

- Basic tools to load your own data to classify with quantum simulators.
- Slow performance compared to current classical machine learning frameworks (remember that everything is running on top of the simulation of a quantum device that is already computationally expensive).
- Samples and tutorials to get introduced to the field of quantum machine learning.

The purpose of this documentation is to provide a concise introduction to machine learning tools (written in Q\#) for hybrid quantum/classical learning. We begin with a brief introduction to machine learning concepts and specifically their realization in quantum circuit centric classifiers (also known as quantum sequential classifiers). We then introduce with a set of tutorials the basics to start using the tools provided by the library. We also discuss the training and validation methods for such classifiers and how they translate into specific Q\# operations provided by the library.

The model implemented in this library is based on the quantum-classical training scheme presented in [Circuit-centric quantum classifiers](https://arxiv.org/abs/1804.00633)

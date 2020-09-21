---
title: Quantum Development Kit Libraries
description: Overview of the standard, chemistry, and numerics libraries included in the Microsoft Quantum Development Kit.

author: bradben
ms.author: v-benbra
ms.date: 08/26/2020

ms.topic: article
uid: microsoft.quantum.libraries
no-loc: ['Q#', '$$v']
---

# Overview of Q# Libraries
The Quantum Development Kit includes several libraries to make it easier to develop quantum applications in Q#.
The following topics describe these libraries and how to use them in your programs.

- [**Standard libraries**](xref:microsoft.quantum.libraries.standard.intro):
  This topic describes the **prelude**, which defines the interface between Q# programs and target machines, and the **canon**, a Q# library that provides general-purpose operations and functions for use in writing Q# programs.
- [**Quantum chemistry library**](xref:microsoft.quantum.chemistry.concepts.intro):
  This topic describes the quantum chemistry library, which provides a data model for loading representations of fermionic Hamiltonians, and quantum simulation operations and functions that act on these representations.
- [**Quantum numerics library**](xref:microsoft.quantum.numerics.intro):
  This topic describes the quantum numerics library, which provides implementations for many mathematical functions. It supports integer (signed and unsigned) and fixed-point representations.
- [**Quantum machine learning library**](xref:microsoft.quantum.machine-learning.concepts.intro):
  This topic describes the quantum machine learning library, which provides an implementation of the sequential classifiers that take advantage of quantum computing to understand data.

Sources for the [libraries](https://github.com/Microsoft/QuantumLibraries), as well as Q# [code samples](https://docs.microsoft.com/samples/browse/?languages=qsharp), are available on GitHub. For more information, see [Licensing](xref:microsoft.quantum.libraries.licensing). Note that package references (or *binaries*) are also available for the libraries and offer another way of including the libraries in projects.
A convenient way of obtaining them is via [NuGet](https://nuget.org).

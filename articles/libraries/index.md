---
title: Quantum Development Kit Libraries | Microsoft Docs
author: cgranade
ms.author: chgranad@microsoft.com
ms.date: 10/17/2018
ms.topic: article
uid: microsoft.quantum.libraries
---
# Overview of Q# Libraries
The Quantum Development Kit is provided with several libraries to make it easier to develop quantum applications in Q#.
In this section of the documentation, we describe these libraries and how to use them in your programs.

- [**Standard libraries**](xref:microsoft.quantum.libraries.standard.intro):
  This section describes the prelude, which defines the interface between Q# programs and target machines, and the canon, a Q# library that provides general-purpose operations and functions for use in writing Q# programs.
- [**Quantum chemistry library**](xref:microsoft.quantum.chemistry.concepts.intro):
  This section describes the quantum chemistry library, which provides a data model for loading representations of fermionic Hamiltonians and quantum simulation operations and functions which act on these representations.
- [**Quantum numerics library**](xref:microsoft.quantum.numerics.intro):
  This section describes the quantum numerics library, which provides implementations for a host of mathematical functions. It supports integer (signed & unsigned) and fixed-point representations.

Sources of the libraries as well as code samples can be obtained from GitHub. See also the [licensing](xref:microsoft.quantum.libraries.licensing) section for further information. It should be noted that package references ("binaries") are available also for the libraries which offers another way of including the libraries in projects. A convenient way of obtaining them is via [nuget](https://nuget.org).  
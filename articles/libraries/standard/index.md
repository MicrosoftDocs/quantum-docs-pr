---
title: Q# standard libraries - introduction | Microsoft Docs
description: Q# standard libraries - introduction
author: QuantumWriter
ms.author: martinro@microsoft.com
ms.date: 12/11/2017
ms.topic: article
uid: microsoft.quantum.libraries.standard.intro
---
# Introduction to the Q# Standard Libraries #

Q# is supported by a range of different useful operations, functions, and user-defined types that comprise the Q# *standard library*.
The Q# standard library is split into two main parts:

- **The prelude**: operations and functions defined as a part of the target machine and compiler, typically in classical native .NET code.
  In general, different target machines may have different implementations of the prelude appropriate to each system.
- **The canon**: operations and functions defined in Q# building on the logic defined in the prelude.
  The canon implementation is agnostic with respect to target machines.

The `Microsoft.Quantum.Development.Kit` NuGet package installed during [installation and validation](xref:microsoft.quantum.install) provides a target machine which implements the prelude by calling into a local simulator, while the `Microsoft.Quantum.Canon` package provides an implementation of the canon that references definitions in the prelude.

The symbols defined by each of the prelude and the canon are defined in much greater and more exhaustive detail in the [API documentation](xref:microsoft.quantum.standardlibsintro).

In the following sections, we will outline the most salient features of each part of the standard library and provide some context about how each feature might be used in practice.
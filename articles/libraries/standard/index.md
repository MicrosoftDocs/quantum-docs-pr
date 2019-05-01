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

Q# is supported by a range of different useful operations, functions, and user-defined types that comprise the Q# *standard libraries*.
The [`Microsoft.Quantum.Development.Kit` NuGet package](https://www.nuget.org/packages/microsoft.quantum.development.kit) installed during [installation and validation](xref:microsoft.quantum.install) provides the Q# compiler, and parts of the standard library that are implemented by the target machines.
The [`Microsoft.Quantum.Standard` package](https://www.nuget.org/packages/microsoft.quantum.standard) provides the portion of the Q# standard libraries that are portable across target machines.

The symbols defined by the Q# standard libraries are defined in much greater and more exhaustive detail in the [API documentation](xref:microsoft.quantum.standardlibsintro).

In the following sections, we will outline the most salient features of each part of the standard library and provide some context about how each feature might be used in practice.

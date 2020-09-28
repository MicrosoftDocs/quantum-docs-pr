---
title: Introduction to Microsoft Q# standard libraries
description: Learn about the Microsoft Q# standard libraries that define the operations, functions and data types used in quantum programs. 
author: QuantumWriter
ms.author: martinro
ms.date: 9/24/2020
ms.topic: article
uid: microsoft.quantum.libraries.standard.intro
no-loc: ['Q#', '$$v']
---

# Introduction to the Q# standard libraries

Q# is supported by a range of different useful operations, functions, and user-defined types that comprise the Q# *standard libraries*.
The [`Microsoft.Quantum.Development.Kit` NuGet package](https://www.nuget.org/packages/microsoft.quantum.development.kit), installed during [installation and validation](xref:microsoft.quantum.install), provides the Q# compiler and the parts of the standard library that are implemented by the [quantum simulators](xref:microsoft.quantum.machines), or target machines.
The [`Microsoft.Quantum.Standard` package](https://www.nuget.org/packages/microsoft.quantum.standard) provides the portion of the Q# standard libraries that are portable across the target machines.

The symbols defined by the Q# standard libraries are documented in greater detail in the [API documentation](xref:microsoft.quantum.apiref-intro).

The following topics outline the most salient features of each part of the standard library and provide some context about how each feature might be used in practice.

- [The prelude](xref:microsoft.quantum.libraries.standard.prelude)
- [Classical mathematics](xref:microsoft.quantum.libraries.math)
- [Type conversions](xref:microsoft.quantum.libraries.convert)
- [Higher-order control flow](xref:microsoft.quantum.concepts.control-flow)
- [Data structures and modeling](xref:microsoft.quantum.libraries.data-structures)
- [Quantum algorithms](xref:microsoft.quantum.libraries.standard.algorithms)
- [Diagnostics](xref:microsoft.quantum.libraries.diagnostics)
- [Characterization](xref:microsoft.quantum.libraries.characterization)
- [Error correction](xref:microsoft.quantum.libraries.error-correction)
- [Applications](xref:microsoft.quantum.libraries.applications)
- [OSS licensing](xref:microsoft.quantum.libraries.licensing)

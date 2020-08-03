---
title: Azure Quantum Release Notes
description: Learn about the latest updates of the Azure Quantum service. 
author: geduardo
ms.author: v-edsanc@microsoft.com
ms.date: 07/27/2020
ms.topic: article
uid: microsoft.azure.quantum.relnotes
---

# Azure Quantum Release Notes

This article contains information on each Quantum Development Kit release affecting Azure Quantum.

For installation instructions, please refer to the [install guide](xref:microsoft.quantum.install).

For update instructions, please refer to the [update guide](xref:microsoft.quantum.update).

*Release date: July 1st, 2020*

This release contains the following:

- IQ# support for Azure Quantum to [submit jobs from Q# Jupyter Notebooks](xref:microsoft.azure.quantum.submit-jobs.jupyter) & [Python](xref:microsoft.azure.quantum.submit-jobs.python) with Q#
- Support for initial design-time diagnostics to determine whether a program can execute on the set target
- New support for executing a targeted Q# application on quantum simulators & resource estimator
- New `qdk-chem` tool for converting legacy electronic structure problem serialization formats (e.g.: FCIDUMP) to [Broombridge](xref:todo)
- New functions and operations in the [`Microsoft.Quantum.Synthesis` namespace](xref:microsoft.quantum.synthesis) for coherently applying classical oracles using transformation- and decomposition-based synthesis algorithms.
- IQ# now allows arguments to the `%simulate`, `%estimate`, and other magic commands. See the [`%simulate` magic command reference](xref:microsoft.quantum.iqsharp.magic-ref.simulate) for more details.
- New phase display options in IQ#. See the [`%config` magic command reference](xref:microsoft.quantum.iqsharp.magic-ref.config) for more details.
- IQ# is now provided as a [`conda` package](https://anaconda.org/quantum-engineering/iqsharp) for IQ# installation to support local installation to a conda environment.
- When using the simulator, qubits no longer need to be in the |0⟩ state upon release, but can be automatically reset if they were measured immediately before releasing.
- Updates to make it easier for IQ# users to consume library packages with different QDK versions, requiring only major & minor version numbers match rather than the exact same version
- Bug fixes 

See the full list of closed PRs for [libraries](https://github.com/Microsoft/QuantumLibraries/pulls?q=is%3Apr+is%3Aclosed), [compiler](https://github.com/microsoft/qsharp-compiler/pulls?q=is%3Apr+is%3Aclosed), [runtime](https://github.com/microsoft/qsharp-runtime/pulls?q=is%3Apr+is%3Aclosed), [samples](https://github.com/Microsoft/Quantum/pulls?q=is%3Apr+is%3Aclosed), [IQ#](https://github.com/microsoft/iqsharp/pulls?q=is%3Apr+is%3Aclosed) and [Katas](https://github.com/microsoft/QuantumKatas/pulls?q=is%3Apr+is%3Aclosed).  

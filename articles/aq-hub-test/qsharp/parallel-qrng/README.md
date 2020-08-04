---
title: Parallel quantum random number generator (QRNG)
author: geduardo
description: Sample for Parallel quantum random number generator on Azure Quantum
ms.author: v-edsanc@microsoft.com
ms.date: 06/25/2020
ms.topic: article
---

# Parallel quantum random number generator (QRNG)

This sample demonstrates how to use Q# and Azure Quantum together to build a quantum random number generator (QRNG).
In particular, this sample uses a register of qubits rather than a single qubit to draw random numbers several bits at a time, avoiding the need for intermediate measurement.

This sample is implemented as a _standalone executable_, such that no C# or Python host is needed.
The program takes one command-line option, `--n-qubits`, to control the number of qubits used to sample a random number.

## Running the sample on a local simulator

```dotnetcli
dotnet run -- --simulator QuantumSimulator --n-qubits=4
```

## Running the sample on Azure Quantum

Make sure that you have [created and selected a quantum workspace](~/how-to-guides/create-quantum-workspaces-with-the-azure-portal.md), and then run the following at the command line:

```azcli
az quantum execute --target-id ionq.simulator -- --n-qubits=4
```

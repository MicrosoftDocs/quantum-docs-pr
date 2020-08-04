---
title: Simple Grover's search
description: Sample of Grover's algorithm for Azure Quantum.
author: geduardo
ms.author: v-edsanc@microsoft.com
ms.date: 06/25/2020
ms.topic: article
---

# Simple Grover's search

This sample demonstrates how to use Q# and Azure Quantum together to search for data with Grover's algorithm, also known as amplitude amplification.
By applying a sequence of reflections, this state prepares a register of qubits in a state marked by a given quantum operation known as an _oracle_.
The oracle used in this sample checks if its input matches a given integer, so that the computational basis state corresponding to that index is prepared with high probability.

This sample is implemented as a _standalone executable_, such that no C# or Python host is needed.
The program takes one command-line option, `--n-qubits`, to control the number of qubits that are prepared using amplitude amplification.

## Running the sample on a local simulator

```dotnetcli
dotnet run -- --simulator QuantumSimulator --n-qubits=4 --idx-marked=6
```

## Running the sample on Azure Quantum

Make sure that you have [created and selected a quantum workspace](~/how-to-guides/create-quantum-workspaces-with-the-azure-portal.md), and then run the following at the command line:

```azcli
az quantum execute --target-id ionq.simulator -- --n-qubits=4 --idx-marked=6
```

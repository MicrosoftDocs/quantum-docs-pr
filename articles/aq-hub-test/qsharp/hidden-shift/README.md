---
title: Hidden shift
description: Hidden shift sample for Azure Quantum.
author: geduardo
ms.author: v-edsanc@microsoft.com
ms.date: 06/25/2020
ms.topic: article
---

# Hidden shift

This sample demonstrates how to use Q# and Azure Quantum together to learn the hidden shift of bent functions.

This sample is implemented as a _standalone executable_, such that no C# or Python host is needed.
The program takes one command-line option, `--n-qubits`, to control the number of qubits used to sample a random number.

## Running the sample on a local simulator

```dotnetcli
dotnet run -- --simulator QuantumSimulator --pattern-int 6 --register-size 4
```

## Running the sample on Azure Quantum

Make sure that you have [created and selected a quantum
workspace](~/how-to-guides/create-quantum-workspaces-with-the-azure-portal.md),
and then run the following at the command line:

```azcli
az quantum execute --target-id ionq.simulator -- --pattern-int 6 --register-size 4
```

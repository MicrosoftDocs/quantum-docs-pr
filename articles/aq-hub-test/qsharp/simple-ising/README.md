---
title: Ising Model Simulation
author: geduardo
description: Sample for Ising model simulation in Azure Quantum.
ms.author: v-edsanc@microsoft.com
ms.date: 06/25/2020
ms.topic: article
---

# Ising Model Simulation

This sample walks through manually constructing and simulating the time-evolution operator for the Ising model.
This time-evolution operator is applied to adiabatically prepare the ground state of the Ising model, and a sample of the final magnetization is then measured.

## Running the sample on a local simulator

```dotnetcli
dotnet run -- --simulator QuantumSimulator --n-sites=4 --time=10.0 --dt=0.1
```

## Running the sample on Azure Quantum

Make sure that you have [created and selected a quantum workspace](~/how-to-guides/create-quantum-workspaces-with-the-azure-portal.md), and then run the following at the command line:

```azcli
az quantum execute --target-id ionq.simulator -- --n-sites=4 --time=10.0 --dt=0.1
```

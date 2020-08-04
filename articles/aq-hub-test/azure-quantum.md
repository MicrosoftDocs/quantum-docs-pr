---
title: Azure Quantum provider 
description: This document provides the technical details of the Azure Quantum provider
author: KittyYeungQ
ms.author: kitty
ms.date: 06/29/2020
ms.topic: article
uid: microsoft.azure.quantum.providers.azure-quantum
---

# Azure Quantum provider

The Azure Quantum provider is enabled in every Quantum Workspace.

- Publisher: [Microsoft](https://microsoft.com)
- Provider ID: `microsoft`

## Targets

The following targets are available from this provider:

- [Solver: Simulated Annealing (Parameter
  Free)](#parameter-free-simulated-annealing)
- [Solver: Simulated Annealing](#simulated-annealing)
- [Solver: Parallel Tempering (Parameter
  Free)](#parameter-free-parallel-tempering)
- [Solver: Parallel Tempering](#parallel-tempering)

### Parameter Free Simulated Annealing

Parameter-free (up to a time out) solver for binary optimization problems with
k-local interactions on an all-to-all graph topology with double precision
support for the coupler weights. To use the parameter-free simulated annealing
solver, specify only the `timeout` and/or `seed` parameters when instantiating
the `SimulatedAnnealing` class.

- Job type: `Quantum-Inspired Optimization Problem`
- Data Format: `microsoft.qio.v1`
- Target ID: `microsoft.simulatedannealing-parameterfree`
- Python Solver class name: `SimulatedAnnealing`

Billing information: **Free in Private Preview**

Monthly quota: **50 hours per month**

| Parameter Name | Type     | Required | Description |
|----------------|----------|----------|-------------|
| `timeout`      | int      | Required | Maximum number of seconds to run the core solver loop. Initialization time does not respect this value, so the solver may run longer than the value specified. |
| `seed`         | int      | Optional | Seed value  |

### Simulated Annealing

Solver for binary optimization problems with k-local interactions on an
all-to-all graph topology with double precision support for the coupler weights.
To use the parameterized simulated annealing solver, specify one or more of the
below parameters when instantiating the `SimulatedAnnealing` class.

- Job type: `Quantum-Inspired Optimization Problem`
- Data Format: `microsoft.qio.v1`
- Target ID: `microsoft.simulatedannealing`
- Python Solver class name: `SimulatedAnnealing`

Billing information: **Free in Private Preview**

Monthly quota: **50 hours per month**

| Parameter Name | Type     | Required | Description |
|----------------|----------|----------|-------------|
| `beta_start`   | float    | Required | Inverse starting temperature. |
| `beta_stop`    | float    | Required | Inverse stopping temperature. |
| `sweeps`       | int      | Required | Number of sweeps to run. |
| `restarts`     | int      | Required | Number of restarts. |

### Parameter Free Parallel Tempering

Parameter-free solver for binary optimization problems with k-local interactions
on an all-to-all graph topology with double precision support for the coupler
weights. To use the parameter-free parallel tempering solver, specify only the
`timeout` and/or `seed` parameters when instantiating the `ParallelTempering`
class.

- Job type: `Quantum-Inspired Optimization Problem`
- Data Format: `microsoft.qio.v1`
- Target ID: `microsoft.paralleltempering-parameterfree`
- Python Solver class name: `ParallelTempering`

Billing information: **Free in Private Preview**

Monthly quota: **50 hours per month**

| Parameter Name | Type     | Required | Description |
|----------------|----------|----------|-------------|
| `timeout`      | int      | Required | Maximum number of seconds to run the core solver loop. Initialization time does not respect this value, so the solver may run longer than the value specified. |
| `seed`         | int      | Optional | Seed value  |

### Parallel Tempering

Solver for binary optimization problems with k-local interactions on an
all-to-all graph topology with double precision support for the coupler weights.
To use the parameterized parallel tempering solver, specify one or more of the
below parameters when instantiating the `ParallelTempering` class.

- Job type: `Quantum-Inspired Optimization Problem`
- Data Format: `microsoft.qio.v1`
- Target ID: `microsoft.paralleltempering`
- Python Solver class name: `ParallelTempering`

Billing information: **Free in Private Preview**

Monthly quota: **50 hours per month**

| Parameter Name | Type        | Required | Description |
|----------------|-------------|----------|-------------|
| `sweeps`       | int         | Required | Number of sweeps to run. |
| `replicas`     | int         | Required | Number of replicas. |
| `all_betas`    | List[float] | Required | List of inverse temperatures. Must be equal in length to the `replicas` parameters. |

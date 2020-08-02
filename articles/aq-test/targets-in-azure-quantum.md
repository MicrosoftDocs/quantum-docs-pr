---
title: Targets in Azure Quantum
description: Article describing the different types of targets existing in Azure Quantum
author: KittyYeungQ
ms.author: kitty
ms.date: 06/29/2020
ms.topic: article
uid: microsoft.azure.quantum.concepts.targets
---

# Targets in Azure Quantum

In this article we will introduce the different type of targets available in
Azure Quantum and the Quantum Development Kit.

## Targets as quantum devices

Targets in Azure Quantum can be solvers for quantum inspired optimization (QIO)
problems or quantum devices (either physical or simulated) that you can use to
execute Q# quantum applications.

Each provider in Azure Quantum offers a range of targets to cover different
aspects of quantum computing. For example, some providers offer quantum hardware
to test your quantum algorithms in real quantum computers, and quantum
simulators and validators to test your algorithm in noise-free simulated quantum
devices.

### Different types of targets

For the moment, Azure Quantum includes the following types of targets:

#### Quantum Inspired Optimization solver

Platform to run algorithms inspired by quantum physics on classical CPUs, or
hardware accelerated on FPGAs, GPUs or hardware annealers.

#### Quantum Processing Unit (QPU): different profiles

A quantum processing unit (QPU) is a physical or simulated processor that
contains a number of interconnected qubits that can be manipulated to execute
quantum algorithms. It's the central component of a quantum computer. For the
moment, Azure Quantum and the Quantum Development Kit manage three different
profiles for QPUs:

- **Full:** this profile has the ability to execute any Q# program within the
  limits of memory for simulated QPUs or the number of qubtis for physical
  quantum hardware.
- **No Control Flow:** this profile can execute any Q# program that doesn't
  require the use of the results from qubit measurements to control the
  execution flow. Within a Q# program targeted for this kind of QPU, values of
  type `Result` do not support equality comparison.
- **Basic Measurement Feedback:** this profile has limited ability to use the
  results from qubit measurements to control the execution. Within a Q# program
  targeted for this kind of QPU, values of type `Result` can only be compared as
  part of conditions within if-statements in operations. The corresponding
  conditional blocks may not contain return- or set-statements.

## Next steps

Before learning how to submit jobs to execute in Azure Quantum targets, prepare
your environment to use Azure Quantum following the [Prepare your environment
guide](xref:microsoft.azure.quantum.setup.cli)

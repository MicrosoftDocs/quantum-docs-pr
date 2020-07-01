---
title: Quantum simulators and Q# programs
description: Describes how Q# programs are passed to quantum simulators to test quantum algorithms.
author: QuantumWriter
ms.author: Alan.Geller@microsoft.com 
ms.date: 6/17/2020
ms.topic: article
uid: microsoft.quantum.machines
---

# Quantum simulators

Quantum simulators are software programs that run on classical computers and act as the *target machine* for a Q# program, making it possible to run and test quantum programs in an environment that predicts how qubits will react to different operations. This article describes which quantum simulators are included with the Quantum Development Kit (QDK), and different ways that you can pass a Q# program to the quantum simulators, for example, via the command line or by using driver code written in a classical language.  

## Prerequisite

If you haven't already, it is recommended to walk through the [Quantum random number generator](xref:microsoft.quantum.quickstarts.qrng) tutorial to understand the basic structure and operation of a Q# program. This article uses the tutorial as a reference.

## The Quantum Development Kit (QDK) quantum simulators

The quantum simulator is responsible for providing implementations of quantum primitives for an algorithm. This includes primitive operations such as `H`, `CNOT`, and `Measure`, as well as qubit management and tracking. The QDK includes different classes of quantum simulators representing different execution models for the same quantum algorithm. 

For example, in the random number generator tutorial, the C# example runs the quantum algorithm `SampleQuantumRandomNumberGenerator` by passing a `QuantumSimulator` object to the algorithm class's `Run` method. The `QuantumSimulator` object runs the quantum algorithm by fully simulating the [quantum state vector](xref:microsoft.quantum.glossary#quantum-state).

Each type of quantum simulator can provide different implementations of these primitives. For example, the [quantum computer trace simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro) included in the
QDK doesn't do any simulation at all. Rather, it tracks gate, qubit, and other resource usage for the algorithm.

### Quantum machine classes

In the future, the QDK will define additional quantum machine classes to support other types of simulation and to support execution on topological quantum computers. Allowing the algorithm to stay constant while varying the underlying machine implementation makes it easy to test and debug an algorithm in simulation and then run it on real hardware with confidence
that the algorithm hasn't changed.

The QDK includes several quantum machine classes, all defined in the `Microsoft.Quantum.Simulation.Simulators` namespace.

|Simulator |Class|Description|
|-----|------|---|
|[Full state simulator](xref:microsoft.quantum.machines.full-state-simulator)| `QuantumSimulator` | Runs and debugs quantum algorithms, and is limited to about 30 qubits. |
|[Simple resources estimator](xref:microsoft.quantum.machines.resources-estimator)| `ResourcesEstimator` | Performs a top level analysis of the resources needed to run a quantum algorithm, and supports thousands of qubits.|
|[Trace-based resource estimator](xref:microsoft.quantum.machines.qc-trace-simulator.intro)|  `QCTraceSimulator` |Runs advanced analysis of resources consumptions for the algorithm's entire call-graph, and supports thousands of qubits.|
|[Toffoli simulator](xref:microsoft.quantum.machines.toffoli-simulator)| `ToffoliSimulator` |Simulates quantum algorithms that are limited to `X`, `CNOT`, and multi-controlled `X` quantum operations, and supports million of qubits. |

## Invoking the quantum simulator

In the [Quantum random number generator](xref:microsoft.quantum.quickstarts.qrng) tutorial, three ways of passing the Q# code to the quantum simulator are demonstrated: 

* Using the command line
* Using Python driver code
* Using C# driver code.

Quantum machines are instances of normal .NET classes, so they are created by invoking their constructor, just like any .NET class. How you do this depends on how you run the Q# program.

**Command line** - By default, running a Q# program from the command line invokes the full state simulator. However, you can specify a different simulator on the command line using the `--simulator` parameter (or `-s` shorthand). For example, 

`dotnet run -s ResourcesEstimator`.

**Python host** - In Python, the target machine is specified by using different Python methods on the imported quantum operation. In the following example from the random number generator tutorial, the operation uses the `.simulate()` method to run the full state simulator `QuantumSimulator`,

`SampleQuantumRandomNumberGenerator.simulate()`

**C# host** - With a C# host driver, there are two steps involved: create an instance of the quantum simulator, and then run the Q# program.

* To create a `QuantumSimulator` instance, use the C# `using` statement, <br>`using (var sim = new QuantumSimulator())`.

* To run the operation, use the `.run` method fo the Q# operation, specifying the `QuantumSimulator` instance that you created,<br>`SampleQuantumRandomNumberGenerator.Run(sim)`

For further details about how Q# programs run in different environments, see Run Q# with standalone applications or host programs.

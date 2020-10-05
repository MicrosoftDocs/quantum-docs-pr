---
title: Quantum simulators and Q# programs
description: Describes the quantum simulators available as target machines for Q# programs.
author: QuantumWriter
ms.author: v-benbra 
ms.date: 6/17/2020
ms.topic: article
uid: microsoft.quantum.machines
no-loc: ['Q#', '$$v']
---

# Quantum simulators

Quantum simulators are software programs that run on classical computers and act as the *target machine* for a Q# program, making it possible to run and test quantum programs in an environment that predicts how qubits will react to different operations. This article describes which quantum simulators are included with the Quantum Development Kit (QDK), and different ways that you can pass a Q# program to the quantum simulators, for example, via the command line or by using driver code written in a classical language.  



## The Quantum Development Kit (QDK) quantum simulators

The quantum simulator is responsible for providing implementations of quantum primitives for an algorithm. This includes primitive operations such as `H`, `CNOT`, and `Measure`, as well as qubit management and tracking. The QDK includes different classes of quantum simulators representing different simulation techniques for the same quantum algorithm. 


Each type of quantum simulator can provide different implementations of these primitives. For example, the [full state simulator](xref:microsoft.quantum.machines.full-state-simulator) runs the quantum algorithm by fully simulating the [quantum state vector](xref:microsoft.quantum.glossary#quantum-state), whereas the [quantum computer trace simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro) 
doesn't consider the actual quantum state at all. Rather, it tracks gate, qubit, and other resource usage for the algorithm.

### Quantum machine classes

In the future, the QDK will define additional quantum machine classes to support other types of simulation and to support running on quantum hardware. Allowing the algorithm to stay constant while varying the underlying machine implementation makes it easy to test and debug an algorithm in simulation and then run it on real hardware with confidence
that the algorithm hasn't changed.

The QDK includes several quantum machine classes, all defined in the `Microsoft.Quantum.Simulation.Simulators` namespace.

|Simulator |Class|Description|
|-----|------|---|
|[Full state simulator](xref:microsoft.quantum.machines.full-state-simulator)| `QuantumSimulator` | Runs and debugs quantum algorithms, and is limited to about 30 qubits. |
|[Simple resources estimator](xref:microsoft.quantum.machines.resources-estimator)| `ResourcesEstimator` | Performs a top level analysis of the resources needed to run a quantum algorithm, and supports thousands of qubits.|
|[Trace-based resource estimator](xref:microsoft.quantum.machines.qc-trace-simulator.intro)|  `QCTraceSimulator` |Runs advanced analysis of resources consumptions for the algorithm's entire call-graph, and supports thousands of qubits.|
|[Toffoli simulator](xref:microsoft.quantum.machines.toffoli-simulator)| `ToffoliSimulator` |Simulates quantum algorithms that are limited to `X`, `CNOT`, and multi-controlled `X` quantum operations, and supports million of qubits. |

## Invoking the quantum simulator

In [Ways to run a Q# program](xref:microsoft.quantum.guide.host-programs), three ways of passing the Q# code to the quantum simulator are demonstrated: 

* Using the command line
* Using a Python host program
* Using a C# host program

Quantum machines are instances of normal .NET classes, so they are created by invoking their constructor, just like any .NET class. How you do this depends on how you run the Q# program.

## Next steps

* For details about how to invoke target machines for Q# programs in different environments, see [Ways to run a Q# program](xref:microsoft.quantum.guide.host-programs).

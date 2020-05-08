---
title: Quantum computers and quantum simulators
description: Learn about quantum hardware, quantum simulators, and how quantum operations work.
author: bradben
ms.author:  bradben
ms.date: 5/5/2020
ms.topic: overview
uid: microsoft.quantum.overview.simulators
---

# Quantum computers and quantum simulators

Quantum computers are still in the infancy of their development. The hardware and maintenance are expensive, and most systems are located in universities and research labs. The technology is advancing, though, and limited public access to some systems is available.

Quantum simulators are software programs that run on classical computers and make it possible to run and test quantum programs in an environment that predicts how qubits will react to different operations.

## Quantum hardware

A quantum computer has three primary parts: an area that houses the qubits, a method for transferring signals to the qubits, and a classical computer to run a program and send instructions.

- The quantum material used for qubits is fragile and highly sensitive to environmental interferences. For some methods of qubit storage, the unit that houses the qubits is kept at a temperature just above absolute zero to maximize their coherence. Other types of qubit housing use a vacuum chamber to help minimize vibrations and stabilize the qubits.  
- Signals can be sent to the qubits using a variety of methods including microwaves, laser, and voltage.

Quantum computers face a multitude of challenges to operate correctly. Error correction in quantum computers is a significant issue, and scaling up (adding more qubits) increases the error rate. Because of these limitations, a quantum PC for your desktop is far in the future, but a commercially-viable lab-based quantum computer is closer.

## Quantum simulators

Quantum simulators that run on classical computers allow you to simulate the execution of quantum algorithms on a quantum system.  Microsoft’s Quantum Development Kit (QDK) includes a full-state vector simulator along with other specialized quantum simulators.

## Topological qubit

Microsoft is developing a quantum computer based on topological qubits. A topological qubit will be less impacted by changes in its environment, therefore reducing the degree of external error correction required.

Topological qubits feature increased stability and resistance to environmental noise, which means they can more readily scale and remain reliable longer.

## Microsoft and quantum hardware partnerships

Microsoft is partnering with quantum hardware manufacturers IonQ, Honeywell, and QCI to make quantum computers accessible to developers in the future. Leveraging the Azure Quantum platform, developers will be able to use Microsoft’s Quantum Development Kit (QDK) and Q# to write quantum programs and run them remotely.

## Quantum computations

Performing computations on a quantum computer or quantum simulator follow a basic process:

- Access the qubits
- Initialize the qubits to the desired state
- Perform operations to transform the states of the qubits
- Measure the new states of the qubits

Initializing and transforming qubits is done using **quantum operations** (sometimes called quantum gates). Quantum operations are similar to logic operations in classical computing, such as AND, OR, NOT, and XOR. An operation can be as basic as flipping a qubit's state from 1 to 0 or entangling a pair of qubits, to using multiple operations in series to affect the probability of a superposed qubit collapsing one way or the other.

> [!NOTE] 
> The [Q# libraries](xref:microsoft.quantum.libraries) provide built-in operations that define complex combinations of lower-level quantum operations. You can use the library operations to transform qubits and to create more complex user-defined operations.  

Measuring the result of the computation tells us an answer, but for some quantum algorithms, not necessarily the correct answer. Because the result of some quantum algorithms is based on the probability that was configured by the quantum operations, these computations are run multiple times to get a probability distribution and refine the accuracy of the results.  Assurance that an operation returned a correct answer is known as quantum verification and is a significant challenge in quantum computing.

## Summary

Quantum computing shares some of the same concepts as classical computing but adds a few new twists. Here are some key takeaways:

- Quantum hardware is expensive and fragile to work with, so quantum simulators are used to write and test programs.
- Both classical and quantum computers use logic operations (or gates) to prepare computations.
- Quantum computations return probabilities.

Advancements in quantum hardware and techniques is rapidly changing the field. Here are just a few of the [current developments](https://phys.org/search/?search=quantum+computer&s=0).

## Next steps

> [!div class="nextstepaction"]
> [What is the Q# programming language and QDK?](xref:microsoft.quantum.overview.q-sharp)
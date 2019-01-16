---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Quantum Development Kit Toffoli Simulator | Microsoft Docs 
description: Overview of Microsoft's Quantum Development Kit Toffoli Simulator 
author: alan-geller
ms.author: ageller@microsoft.com 
ms.date: 1/16/20179
ms.topic: article
uid: microsoft.quantum.machines.toffoli-simulator
---

# Quantum Development Kit Toffoli Simulator

The Quantum Development Kit provides a Toffoli simulator,
which is a special-purpose simulator that can simulate quantum algorithms
that are limited to X, CNOT, and multi-controlled X operations.
This simulator can be used to execute and debug a limited set of
quantum algorithms written in Q# on your computer.

While the Toffoli simulator is much more restricted in operation than the
[full state simulator](xref:microsoft.quantum.machines.full-state-simulator),
it can simulate far more qubits.
The Toffoli simulator can be used with millions of qubits, while the
full state simulator is generally limited to about 30.

This quantum simulator is exposed via the `ToffoliSimulator` class.
To use the simulator, simply create an instance of this class and pass it
to the `Run` method of the quantum operation you want to execute along
with the rest of the parameters:

```csharp
    var sim = new ToffoliSimulator();
    var res = myOperation.Run(sim).Result;
    ///...
```

## QubitCount

By default, the `ToffoliSimulator` allocates space for 1,000 qubits.
If your algorithm requires more than this, you can change the qubit count
by providing a value for the `qubitCount` parameter to the
`ToffoliSimulator` constructor.
Each additional qubit requires an additional byte of memory, so there is
no significant cost to overestimating the number of qubits you'll need.

For example:

```csharp
    var sim = new ToffoliSimulator(qubitCount: 1000000);
    var res = myLargeOperation.Run(sim).Result;
```

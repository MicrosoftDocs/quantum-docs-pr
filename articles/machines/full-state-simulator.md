---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Quantum Development Kit Full State Simulator | Microsoft Docs 
description: Overview of Microsoft's Quantum Development Kit Full State Simulator 
author: anpaz-msft
ms.author: anpaz@microsoft.com 
ms.date: 12/7/2017 
ms.topic: article
uid: microsoft.quantum.machines.full-state-simulator
---

# Quantum Development Kit Full State Simulator

The Quantum Development Kit provides a full state quantum simulator 
similar to [LIQ$Ui|\rangle$](http://stationq.github.io/Liquid/) from Microsoft Research.
This simulator can be used to execute and debug quantum algorithms written in Q#
on your computer.

This quantum simulator is exposed via the `QuantumSimulator` class. 
To use the simulator, simply create an instance of this class and pass it to the `Run` method
of the quantum operation you want to execute along with the rest of the parameters:

```csharp
    using (var sim = new QuantumSimulator())
    {
        var res = myOperation.Run(sim).Result;
        ///...
    }
```

## IDisposable

The `QuantumSimulator` class implements <xref:System.IDisposable>, thus the `Dispose` method
should be called once the instance of the simulator is not used anymore. The best way 
to do this is to wrap the simulator within a `using` statement, as in the example above.

## Seed

The `QuantumSimulator` uses a random number generator to simulate quantum randomness. 
For testing purposes, it is sometimes useful to have deterministic results. This can 
be accomplished by providing a seed for the random number generator in the 
`QuantumSimulator`'s constructor via the `randomNumberGeneratorSeed`
parameter:

```csharp
    using (var sim = new QuantumSimulator(randomNumberGeneratorSeed: 42))
    {
        var res = myOperationTest.Run(sim).Result;
        ///...
    }
```

## Threads

The `QuantumSimulator` uses [OpenMP](http://www.openmp.org/) to parallelize the 
linear algebra required. By default OpenMP uses all available hardware threads, which means 
that programs with small numbers of qubits will often run slowly because the coordination 
required will dwarf the actual work. This can be fixed by setting the environment variable 
`OMP_NUM_THREADS` to a small number. As a very rough rule of thumb, 1 thread is good for up 
to about 4 qubits, and then an additional thread per qubit is good, although this is 
highly dependent on your algorithm.


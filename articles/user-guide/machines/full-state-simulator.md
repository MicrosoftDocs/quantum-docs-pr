---
title: Full state quantum simulator - Quantum Development Kit
description: Learn how to run your Q# programs on the Microsoft Quantum Development Kit full state simulator.
author: anpaz-msft
ms.author: anpaz
ms.date: 06/26/2020 
ms.topic: conceptual
uid: microsoft.quantum.machines.full-state-simulator
no-loc: ['Q#', '$$v']
---

# Quantum Development Kit (QDK) full state simulator

The QDK provides a full state simulator that simulates a quantum machine on your local computer. You can use the full state simulator to run and debug quantum algorithms written in Q#, utilizing up to 30 qubits. The full state simulator is similar to the quantum simulator used in the  [LIQ$Ui|\rangle$](http://stationq.github.io/Liquid/) platform from Microsoft Research.

## Invoking and running the full state simulator

You expose the full state simulator via the `QuantumSimulator` class. For additional details, see [Ways to run a Q# program](xref:microsoft.quantum.guide.host-programs).

### Invoking the simulator from C#

Create an instance of the `QuantumSimulator` class and then pass it to the `Run` method
of a quantum operation, along with any additional parameters.
```csharp
    using (var sim = new QuantumSimulator())
    {
        var res = myOperation.Run(sim).Result;
        ///...
    }
```

Because the `QuantumSimulator` class implements the <xref:System.IDisposable> interface, you must call the `Dispose` method once you do not need the instance of the simulator anymore. The best way to do this is to wrap the simulator declaration and operations within a [using](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/using-statement) statement, which automatically calls the `Dispose` method.

### Invoking the simulator from Python

Use the [simulate()](https://docs.microsoft.com/python/qsharp-core/qsharp.loader.qsharpcallable) method from the Q# Python library with the imported Q# operation:

```python
qubit_result = myOperation.simulate()
```

### Invoking the simulator from the command line

When running a Q# program from the command line, the full state simulator is the default target machine. Optionally, you can use the **--simulator** (or **-s** shortcut) parameter to specify the desired target machine. Both of the following commands run a program using the full state simulator. 

```dotnetcli
dotnet run
dotnet run -s QuantumSimulator
```

### Invoking the simulator from Juptyer Notebooks

Use the IQ# magic command [%simulate](xref:microsoft.quantum.iqsharp.magic-ref.simulate) to run the Q# operation.

```
%simulate myOperation
```
## Seeding the simulator

By default, the full state simulator uses a random number generator to simulate quantum randomness. For testing purposes, it is sometimes useful to have deterministic results. In a C# program, you can accomplish this by providing a seed for the random number generator in the `QuantumSimulator` constructor via the `randomNumberGeneratorSeed` parameter.

```csharp
    using (var sim = new QuantumSimulator(randomNumberGeneratorSeed: 42))
    {
        var res = myOperationTest.Run(sim).Result;
        ///...
    }
```

## Configuring threads

The full state simulator uses [OpenMP](http://www.openmp.org/) to parallelize the linear algebra required. By default, OpenMP uses all available hardware threads, which means that programs with small numbers of qubits often runs slowly because the coordination that is required dwarfs the actual work. You can fix this by setting the environment variable `OMP_NUM_THREADS` to a small number. As a rule of thumb, configure one thread for up to four qubits, and then one additional thread per qubit. You might need to adjust the variable depending on your algorithm.

## See also

- [Quantum resources estimator](xref:microsoft.quantum.machines.resources-estimator)
- [Quantum Toffoli simulator](xref:microsoft.quantum.machines.toffoli-simulator)
- [Quantum trace simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro)
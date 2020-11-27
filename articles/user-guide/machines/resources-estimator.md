---
title: Quantum resources estimator - Quantum Development Kit
description: Learn about the Microsoft QDK resources estimator, which estimates the resources required to run a given instance of a Q# operation on a quantum computer.
author: anpaz-msft
ms.author: anpaz 
ms.date: 06/26/2020
ms.topic: article
uid: microsoft.quantum.machines.resources-estimator
no-loc: ['Q#', '$$v']
---

# Quantum Development Kit (QDK) resources estimator

As the name implies, the `ResourcesEstimator` class estimates the resources required to run a given instance of a Q# operation on a quantum computer. It accomplishes this by running the quantum operation without actually simulating the state of a quantum computer; for this reason, it estimates resources for Q# operations that use thousands of qubits, provided that the classical part of the code runs in a reasonable time.

The resources estimator is built on top of the [Quantum trace simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro), which provides a richer set of metrics and tools to help debug Q# programs.

## Invoking and running the resources estimator

You can use the resources estimator to run any Q# operation. For additional details, see [Ways to run a Q# program](xref:microsoft.quantum.guide.host-programs).

### Invoking the resources estimator from C# 

As with other target machines, you first create an instance of the `ResourcesEstimator` class and then pass it as the first parameter of an operation's `Run` method.

Note that, unlike the `QuantumSimulator` class, the `ResourcesEstimator` class does not implement the <xref:System.IDisposable> interface, and thus you do not need to enclose it within a `using` statement.

```csharp
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.MyProgram
{
    class Driver
    {
        static void Main(string[] args)
        {
            ResourcesEstimator estimator = new ResourcesEstimator();
            MyQuantumProgram.Run(estimator).Wait();
            Console.WriteLine(estimator.ToTSV());
        }
    }
}
```

As the example shows, `ResourcesEstimator` provides the `ToTSV()` method, which generates a table with tab-separated values (TSV). You can save the table to a file or display it to the console for analysis. The following is a sample output from the preceding program:

```output
Metric          Sum
CNOT            1000
QubitClifford   1000
R               0
Measure         4002
T               0
Depth           0
Width           2
BorrowedWidth   0
```

> [!NOTE]
> A `ResourcesEstimator` instance does not reset its calculations on every run. If you use the same instance to run another operation, it aggregates the new results with the existing results. If you need to reset calculations between runs, create a new instance for every run.

### Invoking the resources estimator from Python

Use the [estimate_resources()](https://docs.microsoft.com/python/qsharp-core/qsharp.loader.qsharpcallable) method from the Python library with the imported Q# operation:

```python
qubit_result = myOperation.estimate_resources()
```

### Invoking the resources estimator from the command line

When running a Q# program from the command line, use the **--simulator** (or **-s** shortcut) parameter to specify the `ResourcesEstimator` target machine. The following command runs a program using the resources estimator: 

```dotnetcli
dotnet run -s ResourcesEstimator
```

### Invoking the resources estimator from Juptyer Notebooks

Use the IQ# magic command [%estimate](xref:microsoft.quantum.iqsharp.magic-ref.simulate) to run the Q# operation.

```
%estimate myOperation
```

## Programmatically retrieving the estimated data

In addition to a TSV table, you can programmatically retrieve the resources estimated during the run via the `Data` property of the resources estimator. The `Data` property provides a `System.DataTable` instance with two columns: `Metric` and `Sum`, indexed by the metrics' names.

The following code shows how to retrieve and print the total number of `QubitClifford`, `T` and `CNOT` operations used by a Q# operation:

```csharp
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.MyProgram
{
    class Driver
    {
        static void Main(string[] args)
        {
            ResourcesEstimator estimator = new ResourcesEstimator();
            MyQuantumProgram.Run(estimator).Wait();

            var data = estimator.Data;
            Console.WriteLine($"QubitCliffords: {data.Rows.Find("QubitClifford")["Sum"]}");
            Console.WriteLine($"Ts: {data.Rows.Find("T")["Sum"]}");
            Console.WriteLine($"CNOTs: {data.Rows.Find("CNOT")["Sum"]}");
        }
    }
}
```

## Metrics Reported

The resources estimator tracks the following metrics:

|Metric|Description|
|----|----|
|__CNOT__    |The run count of `CNOT` operations (also known as Controlled Pauli X operations).|
|__QubitClifford__ |The run count of any single qubit Clifford and Pauli operations.|
|__Measure__    |The run count of any measurements.  |
|__R__    |The run count of any single-qubit rotations, excluding `T`, Clifford and Pauli operations.  |
|__T__    |The run count of `T` operations and their conjugates, including the `T` operations, T_x = H.T.H, and T_y = Hy.T.Hy.  |
|__Depth__|Depth of the quantum circuit run by the Q# operation (see [below](#depth-width-and-qubitcount)). By default, the depth metric only counts `T` gates. For more details, see [Depth Counter](xref:microsoft.quantum.machines.qc-trace-simulator.depth-counter).   |
|__Width__|Width of the quantum circuit run by the Q# operation (see [below](#depth-width-and-qubitcount)). By default, the depth metric only counts `T` gates. For more details, see [Depth Counter](xref:microsoft.quantum.machines.qc-trace-simulator.depth-counter).   |
|__QubitCount__    |The lower bound for the maximum number of qubits allocated during the run of the Q# operation. This metric might not be compatible with __Depth__ (see below).  |
|__BorrowedWidth__    |The maximum number of qubits borrowed inside the Q# operation.  |


## Depth, Width, and QubitCount

Reported Depth and Width estimates are compatible with each other.
(Previously both numbers were achievable, but different circuits would be required for Depth and for Width.)
Currently both metrics in this pair can be achieved by the same circuit at the same time.

The following metrics are reported:

__Depth:__
For the root operation - time it takes to execute it assuming specific gate times.
For operations called or subsequent operations - time difference between latest qubit availability time at the beginning and the end of the operation.

__Width:__
For the root operation - number of qubits actually used to execute it (and operation it calls).
For operations called or subsequent operations - how many more qubits were used in addition to the qubits already used at the beginning of the operation.

Please note, that reused qubits do not contribute to this number.
I.e. if a few qubits have been released before operation A starts, and all qubit demanded by this operation A (and operations called from A) were satisfied by reusing previously release qubits, the Width of operation A is reported as 0. Successfully borrowed qubits do not contribute to the Width either.

__QubitCount:__
For the root operation - minimum number of qubits that would be sufficient to execute this operation (and operations called from it).
For operations called or subsequent operations - minimum number of qubits that would be sufficient to execute this operation separately. This number doesn't include input qubits. It does include borrowed qubits.

Two modes of operation are supported. Mode is selected by setting QCTraceSimulatorConfiguration.OptimizeDepth.

__OptimizeDepth=true:__
QubitManager is discouraged from qubit reuse and allocates new qubit every time it is asked for a qubit. For the root operation __Depth__ becomes the minimum depth (lower bound). Compatible __Width__ is reported for this depth (both can be achieved at the same time). Note, that this width will likely be not optimal given this depth. __QubitCount__ may be lower than Width for the root operation because it assumes reuse.

__OptimizeDepth=false:__
QubitManager is encouraged to reuse qubits and will reuse released qubits before allocating new ones. For the root operation __Width__ becomes the minimal width (lower bound). Compatible __Depth__ is reported on which it can be achieved. __QubitCount__ will be the same as __Width__ for the root operation assuming no borrowing.

## Providing the probability of measurement outcomes

You can use <xref:Microsoft.Quantum.Diagnostics.AssertMeasurementProbability> from the <xref:Microsoft.Quantum.Diagnostics> namespace to provide information about the expected probability of a measurement operation. For more information, see [Quantum Trace Simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro)

## See also

- [Quantum trace simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro)
- [Quantum Toffoli simulator](xref:microsoft.quantum.machines.toffoli-simulator)
- [Quantum full state simulator](xref:microsoft.quantum.machines.full-state-simulator) 

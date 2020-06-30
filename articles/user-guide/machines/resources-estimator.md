---
title: Quantum Resources Estimator - Quantum Development Kit
description: Learn about the Microsoft QDK Resources Estimator, which estimates the resources required to run a given instance of a Q# operation on a quantum computer.
author: anpaz-msft
ms.author: anpaz@microsoft.com 
ms.date: 06/26/2020
ms.topic: article
uid: microsoft.quantum.machines.resources-estimator
---

# Quantum Development Kit (QDK) Resources Estimator

As the name implies, the `ResourcesEstimator` class estimates the resources required to run a given instance of a Q# operation on a quantum computer. It accomplishes this by executing the quantum operation without actually simulating the state of a quantum computer; for this reason, it estimates resources for Q# operations that use thousands of qubits, provided that the classical part of the code runs in a reasonable time.

## Invoking and running the Resources Estimator

You can use the Resources Estimator to run any Q# operation.

### Invoking the Resources Estimator from C# 

As with other target machines, you first create an instance of the `ResourceEstimator` class and then pass it as the first parameter of an operation's `Run` method.

Note that, unlike the `QuantumSimulator` class, the `ResourceEstimator` class does not implement the <xref:System.IDisposable> interface, and thus you do not need to enclose it within a `using` statement.

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

### Invoking the Resources Estimator from Python

Use the [estimate_resources()](https://docs.microsoft.com/en-us/python/qsharp/qsharp.loader.qsharpcallable) method from the Python library with the imported Q# operation:

```python
qubit_result = myOperation.estimate_resources()
```

### Invoking the Resources Estimator from the command line

When running a Q# program from the command line, use the *--simulator* (or *-s* shortcut) parameter to specify the `ResourcesEstimator` target machine. The following command runs a program using the Resources Estimator: 

```dotnetcli
dotnet run -s ResourcesEstimator

```

### Invoking the Resources Estimator from Juptyer Notebooks

Use the IQ# magic command [%estimate](xref:microsoft.quantum.iqsharp.magic-ref.simulate) to run the Q# operation.

```dotnetcli
%estimate myOperation
```

## Programmatically retrieving the estimated data

In addition to a TSV table, you can programmatically retrieve the resources estimated during the run via the `Data` property of the Resources Estimator. The `Data` property provides a `System.DataTable` instance with two columns: `Metric` and `Sum`, indexed by the metrics' names.

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
|__Depth__|The lower bound for the depth of the quantum circuit run by the Q# operation. By default, the depth metric only counts `T` gates. For more details, see [Depth Counter](xref:microsoft.quantum.machines.qc-trace-simulator.depth-counter).   |
|__Width__    |The lower bound for the maximum number of qubits allocated during the run of the Q# operation. It might not be possible to achieve both __Depth__ and __Width__ lower bounds simultaneously.  |
|__BorrowedWidth__    |The maximum number of qubits borrowed inside the Q# operation.  |

## Providing the probability of measurement outcomes

You can use <xref:microsoft.quantum.intrinsic.assertprob> from the <xref:microsoft.quantum.intrinsic> namespace to provide information about the expected probability of a measurement operation. For more information, see [Quantum Trace Simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro)

## See also

- [Quantum trace simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro). The Resources Estimator is built on top of the Quantum Trace Simulator, which provides a richer set of metrics and tools to help debug Q# programs.
- [Quantum Toffoli Simulator](xref:microsoft.quantum.machines.toffoli-simulator)
- [Quantum Full State Simulator](xref:microsoft.quantum.machines.full-state-simulator) 
---
# Mandatory fields. 
title: Quantum trace simulator - Quantum Development Kit
description: Learn how to use the Microsoft quantum computer trace simulator to debug classical code and to estimate resource requirements of a Q# program. 
author: vadym-kl 
ms.author: vadym 
ms.date: 06/25/2020 
ms.topic: conceptual
uid: microsoft.quantum.machines.qc-trace-simulator.intro
no-loc: ['Q#', '$$v']
---

# Microsoft Quantum Development Kit (QDK) quantum trace simulator

The QDK <xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulator> class runs a quantum program without actually simulating the state of a quantum computer. For this reason, the quantum trace simulator is able to run quantum programs that use thousands of qubits.  It is useful for two main purposes: 

* Debugging classical code that is part of a quantum program. 
* Estimating the resources required to run a given instance of a quantum program
  on a quantum computer. In fact, the [Resources estimator](xref:microsoft.quantum.machines.resources-estimator), which provides a more limited set of metrics, is built upon the trace simulator.

## Invoking the quantum trace simulator

You can use the quantum trace simulator to run any Q# operation.

As with other target machines, you first create an instance of the `QCTraceSimulator` class and then pass it as the first parameter of an operation's `Run` method.

Note that, unlike the `QuantumSimulator` class, the `QCTraceSimulator` class does not implement the <xref:System.IDisposable> interface, and thus you do not need to enclose it within a `using` statement.

```csharp
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators;

namespace Quantum.MyProgram
{
    class Driver
    {
        static void Main(string[] args)
        {
            QCTraceSimulator sim = new QCTraceSimulator();
            var res = MyQuantumProgram.Run(sim).Result;
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }
    }
}
```

## Providing the probability of measurement outcomes

Because the quantum trace simulator does not simulate the actual quantum state, it cannot calculate the probability of measurement outcomes within an operation. 

Therefore, if an operation includes measurements, you must explicitly provide these probabilities using the <xref:Microsoft.Quantum.Diagnostics.AssertMeasurementProbability> operation from the <xref:Microsoft.Quantum.Diagnostics> namespace. The following example illustrates this:

```qsharp
operation TeleportQubit(source : Qubit, target : Qubit) : Unit {
    using (qubit = Qubit()) {
        H(qubit);
        CNOT(qubit, target);
        CNOT(source, qubit);
        H(source);

        AssertMeasurementProbability([PauliZ], [source], Zero, 0.5, "Outcomes must be equally likely", 1e-5);
        AssertMeasurementProbability([PauliZ], [q], Zero, 0.5, "Outcomes must be equally likely", 1e-5);

        if (M(source) == One)  { Z(target); X(source); }
        if (M(q) == One) { X(target); X(q); }
    }
}
```

When the quantum trace simulator encounters `AssertMeasurementProbability` it records that measuring `PauliZ` on `source` and `q` should give an outcome of `Zero`, with probability **0.5**. When it runs the `M` operation later, it finds the recorded values of the outcome probabilities, and `M` returns `Zero` or `One`, with probability **0.5**. When the same code runs on a simulator that keeps track of the quantum state, that simulator checks that the provided probabilities in `AssertMeasurementProbability` are correct.

Note that if there is at least one measurement operation that is not annotated using `AssertMeasurementProbability`, the simulator throws an [`UnconstrainedMeasurementException`](https://docs.microsoft.com/dotnet/api/microsoft.quantum.simulation.simulators.qctracesimulators.unconstrainedmeasurementexception).

## Quantum trace simulator tools

The QDK includes five tools that you can use with the quantum trace simulator to detect bugs in your programs and perform quantum program resource estimates: 

|Tool | Description |
|-----| -----|
|[Distinct inputs checker](xref:microsoft.quantum.machines.qc-trace-simulator.distinct-inputs) |Checks for potential conflicts with shared qubits |
|[Invalidated qubits use checker](xref:microsoft.quantum.machines.qc-trace-simulator.invalidated-qubits)  |Checks if the program applies an operation to a qubit that is already released |
|[Primitive operations counter](xref:microsoft.quantum.machines.qc-trace-simulator.primitive-counter)  | Counts the number of primitives used by every operation invoked in a quantum program  |
|[Depth counter](xref:microsoft.quantum.machines.qc-trace-simulator.depth-counter)  |Gathers counts that represent the lower bound of the depth of every operation invoked in a quantum program   |
|[Width counter](xref:microsoft.quantum.machines.qc-trace-simulator.width-counter)  |Counts the number of qubits allocated and borrowed by each operation in a quantum program |

Each of these tools is enabled by setting appropriate flags in `QCTraceSimulatorConfiguration` and then passing the configuration to the `QCTraceSimulator` declaration. For information on using each of these tools, see the links in the preceding list. For more information about configuring `QCTraceSimulator`, see [QCTraceSimulatorConfiguration](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration).

## QCTraceSimulator methods

`QCTraceSimulator` has several built-in methods to retrieve the values of the metrics tracked during a quantum operation. Examples of the [QCTraceSimulator.GetMetric](https://docs.microsoft.com/dotnet/api/microsoft.quantum.simulation.simulators.qctracesimulators.qctracesimulator.getmetric) and the [QCTraceSimulator.ToCSV](https://docs.microsoft.com/dotnet/api/microsoft.quantum.simulation.simulators.qctracesimulators.qctracesimulator.tocsv) methods can be found in the [Primitive operations counter](xref:microsoft.quantum.machines.qc-trace-simulator.primitive-counter), [Depth counter](xref:microsoft.quantum.machines.qc-trace-simulator.depth-counter), and [Width counter](xref:microsoft.quantum.machines.qc-trace-simulator.width-counter) articles. For more information on all available methods, see [QCTraceSimulator](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulator) in the Q# API reference.  

## See also

- [Quantum resources estimator](xref:microsoft.quantum.machines.resources-estimator)
- [Quantum Toffoli simulator](xref:microsoft.quantum.machines.toffoli-simulator)
- [Quantum full state simulator](xref:microsoft.quantum.machines.full-state-simulator) 
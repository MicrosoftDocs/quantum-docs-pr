---
# Mandatory fields. 
title: Quantum Trace Simulator - Quantum Development Kit
description: Learn how to use the Microsoft Quantum computer trace simulator to debug classical code and to estimate resource requirements of a Q# program. 
author: vadym-kl 
ms.author: vadym@microsoft.com 
ms.date: 06/25/2020 
ms.topic: article
uid: microsoft.quantum.machines.qc-trace-simulator.intro
---

# Microsoft Quantum Development Kit (QDK) Quantum Trace Simulator

The QDK [QCTraceSimulator](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulator) class runs a quantum program without actually simulating the state of a quantum computer.  For this reason, the Quantum Trace Simulator is able to run quantum programs that use thousands of qubits.  It is useful for two main purposes: 

* Debugging classical code that is part of a quantum program. 
* Estimating the resources required to run a given instance of a quantum program
  on a quantum computer.

## Invoking the Quantum Trace Simulator

You can use the Quantum Trace Simulator to run any Q# operation.

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

For measurement operations where you usually know the probability of the outcomes, you can use <xref:microsoft.quantum.intrinsic.assertprob> from the <xref:microsoft.quantum.intrinsic> namespace to express this knowledge. The following example illustrates this:

```qsharp
operation TeleportQubit(source : Qubit, target : Qubit) : Unit {
    using (qubit = Qubit()) {
        H(qubit);
        CNOT(qubit, target);
        CNOT(source, qubit);
        H(source);

        AssertProb([PauliZ], [source], Zero, 0.5, "Outcomes must be equally likely", 1e-5);
        AssertProb([PauliZ], [q], Zero, 0.5, "Outcomes must be equally likely", 1e-5);

        if (M(source) == One)  { Z(target); X(source); }
        if (M(q) == One) { X(target); X(q); }
    }
}
```

When the Quantum Trace Simulator encounters `AssertProb` it records that measuring `PauliZ` on `source` and `q` should give an outcome of `Zero`, with probability **0.5**. When it runs the `M` operation later, it finds the recorded values of the outcome probabilities, and `M` returns `Zero` or `One`, with probability **0.5**. When the same code runs on a simulator that keeps track of the quantum state, that simulator checks that the provided probabilities in `AssertProb` are correct.

Note that if there is at least one measurement operation that is not annotated using `AssertProb`, the simulator throws an [`UnconstrainedMeasurementException`](xref:microsoft.quantum.simulation.simulators.QCTraceSimulators.UnconstrainedMeasurementException).

## Quantum Trace Simulator tools

The QDK includes five tools that you can use with the Quantum Trace Simulator to detect bugs in your programs and perform quantum program resource estimates: 

|Tool | Description |
|-----| -----|
|[Distinct Inputs Checker](xref:microsoft.quantum.machines.qc-trace-simulator.distinct-inputs) |Checks for potential conflicts with shared qubits |
|[Invalidated Qubits Use Checker](xref:microsoft.quantum.machines.qc-trace-simulator.invalidated-qubits)  |Checks if the program applies an operation to a qubit that is already released |
|[Primitive Operations Counter](xref:microsoft.quantum.machines.qc-trace-simulator.primitive-counter)  | Counts the number of primitive executions used by every operation invoked in a quantum program  |
|[Depth Counter](xref:microsoft.quantum.machines.qc-trace-simulator.depth-counter)  |Gathers counts that represent the lower bound of the depth of every operation invoked in a quantum program   |
|[Width Counter](xref:microsoft.quantum.machines.qc-trace-simulator.width-counter)  |Counts the number of qubits allocated and borrowed by each operation in a quantum program |

Each of these tools is enabled by setting appropriate flags in `QCTraceSimulatorConfiguration` and then passing the configuration to the `QCTraceSimulator` declaration. For information on using each of these tools, see the links in the preceding list. For more information about configuring `QCTraceSimulator`, see [QCTraceSimulatorConfiguration](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration).

## QCTraceSimulator methods

`QCTraceSimulator` has several built-in methods to retrieve the values of the metrics tracked during a quantum operation. Examples of the [QCTraceSimulator.GetMetric](xref:microsoft.quantum.simulation.simulators.QCTraceSimulators.QCTraceSimulator.GetMetric) and the [QCTraceSimulator.ToCSV](xref:microsoft.quantum.simulation.simulators.QCTraceSimulators.QCTraceSimulator.ToCSV) methods can be found in the [Primitive Operations Counter](xref:microsoft.quantum.machines.qc-trace-simulator.primitive-counter), [Depth Counter](xref:microsoft.quantum.machines.qc-trace-simulator.depth-counter), and [Width Counter](xref:microsoft.quantum.machines.qc-trace-simulator.width-counter) articles. For more information on all available methods, see [QCTraceSimulator](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulator) in the Q# API reference.  

## See also

- [Quantum Resources Estimator](xref:microsoft.quantum.machines.resources-estimator)
- [Quantum Toffoli Simulator](xref:microsoft.quantum.machines.toffoli-simulator)
- [Quantum Full State Simulator](xref:microsoft.quantum.machines.full-state-simulator) 
---
title: Width Counter - Quantum Development Kit 
description: Learn about the Microsoft QDK Width Counter, which uses the Quantum Trace Simulator to count the number of qubits allocated and borrowed by operations in a Q# program. 
author: vadym-kl
ms.author: vadym@microsoft.com
ms.date: 06/25/2020
ms.topic: article
uid: microsoft.quantum.machines.qc-trace-simulator.width-counter
---

# Quantum Trace Simulator: Width Counter

The Width Counter is a part of the Quantum Development Kit [Quantum Trace Simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro). You can use it to count the number of qubits allocated and borrowed by each operation in a Q# program. Some primitive operations can allocate extra qubits, for example, multiply controlled `X` operations or controlled `T` operations.

## Invoking the Width Counter

To run the Quantum Trace Simulator with the Width Counter, you must create a [`QCTraceSimulatorConfiguration`](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration) instance, set the `UseWidthCounter` property to **true**, and then create a new [`QCTraceSimulator`](xref:microsoft.quantum.simulation.simulators.QCTraceSimulators.QCTraceSimulator) instance with the `QCTraceSimulatorConfiguration` as the parameter. 

```csharp
var config = new QCTraceSimulatorConfiguration();
config.UseWidthCounter = true;
var sim = new QCTraceSimulator(config);
```

## Using the Width Counter in a C# host program

The C# example that follows in this section computes the number of extra qubits allocated by the implementation of a multiply controlled <xref:microsoft.quantum.intrinsic.x> operation, based on the following Q# sample code:

```qsharp
open Microsoft.Quantum.Intrinsic;
open Microsoft.Quantum.Arrays;
operation ApplyMultiControlledX( numberOfQubits : Int ) : Unit {
    using(qubits = Qubit[numberOfQubits]) {
        Controlled X (Rest(qubits), Head(qubits));
    } 
}
```

The multiply controlled <xref:microsoft.quantum.intrinsic.x> operation acts on a total of five qubits, allocates two [ancillary qubits](xref:microsoft.quantum.glossary#ancilla), and has an input width of **5**. Use the following C# program to verify the counts:

```csharp 
var config = new QCTraceSimulatorConfiguration();
config.UseWidthCounter = true;
var sim = new QCTraceSimulator(config);
int totalNumberOfQubits = 5;
var res = ApplyMultiControlledX.Run(sim, totalNumberOfQubits).Result;

double allocatedQubits = 
    sim.GetMetric<Primitive.X, ApplyMultiControlledX>(
        WidthCounter.Metrics.ExtraWidth,
        functor: OperationFunctor.Controlled); 

double inputWidth =
    sim.GetMetric<Primitive.X, ApplyMultiControlledX>(
        WidthCounter.Metrics.InputWidth,
        functor: OperationFunctor.Controlled);
```

The first part of the program runs the `ApplyMultiControlledX` operation. The second part uses the [`QCTraceSimulator.GetMetric`](xref:microsoft.quantum.simulation.simulators.QCTraceSimulators.QCTraceSimulator.GetMetric) method to retrieve the number of allocated qubits as well as the number of qubits that the `Controlled X` operation received as input. 

Finally, you can output all the statistics collected by the Width Counter in CSV format using the following:
```csharp
string csvSummary = sim.ToCSV()[MetricsCountersNames.widthCounter];
```

## See also

- The Quantum Development Kit [Quantum Trace Simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro) overview.
- The [QCTraceSimulator](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulator) API reference.
- The [QCTraceSimulatorConfiguration](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration) API reference.
- The [MetricsNames.WidthCounter](xref:microsoft.quantum.simulation.simulators.QCTraceSimulators.MetricsNames.WidthCounter) API reference.


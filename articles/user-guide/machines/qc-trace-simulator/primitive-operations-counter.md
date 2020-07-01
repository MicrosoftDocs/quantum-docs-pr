---
title: Primitive Operation Counter - Quantum Development Kit
description: Learn about the Microsoft QDK Primitive Operation Counter, which uses the Quantum Trace Simulator to track primitive executions used by operations in a Q# program. 
author: vadym-kl
ms.author: vadym@microsoft.com
ms.date: 06/25/2020
ms.topic: article
uid: microsoft.quantum.machines.qc-trace-simulator.primitive-counter
---

# Quantum Trace Simulator: Primitive Operations Counter

The Primitive Operations Counter is a part of the Quantum Development Kit [Quantum Trace Simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro). It counts the number of primitive executions used by every operation invoked in a quantum program. 

All <xref:microsoft.quantum.intrinsic> operations are expressed in terms of single-qubit rotations, T operations, single-qubit Clifford operations, CNOT operations, and measurements of multi-qubit Pauli observables. The Primitive Operations Counter aggregates and collects statistics over all the edges of the operation's [call graph](https://en.wikipedia.org/wiki/Call_graph).

## Invoking the Primitive Operations Counter

To run the Quantum Trace Simulator with the Primitive Operations Counter, you must create a [`QCTraceSimulatorConfiguration`](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration) instance, set the `UsePrimitiveOperationsCounter` property to **true**, and then create a new [`QCTraceSimulator`](xref:microsoft.quantum.simulation.simulators.QCTraceSimulators.QCTraceSimulator) instance with the `QCTraceSimulatorConfiguration` as the parameter.

```csharp
var config = new QCTraceSimulatorConfiguration();
config.UsePrimitiveOperationsCounter = true;
var sim = new QCTraceSimulator(config);
```

## Using the Primitive Operations Counter in a C# host program

The C# example that follows in this section counts how many <xref:microsoft.quantum.intrinsic.t> operations are needed to implement the <xref:microsoft.quantum.intrinsic.ccnot> operation, based on the following Q# sample code:

```qsharp
open Microsoft.Quantum.Intrinsic;
operation ApplySampleWithCCNOT() : Unit {

    using (qubits = Qubit[3]) {
        CCNOT(qubits[0], qubits[1], qubits[2]);
        T(qubits[0]);
    }
}
```

To check that `CCNOT` requires seven `T` operations and that `ApplySampleWithCCNOT` runs eight `T` operations, use the following C# code:

```csharp 
// using Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators;
// using System.Diagnostics;
var config = new QCTraceSimulatorConfiguration();
config.UsePrimitiveOperationsCounter = true;
var sim = new QCTraceSimulator(config);
var res = ApplySampleWithCCNOT.Run(sim).Result;

double tCountAll = sim.GetMetric<ApplySampleWithCCNOT>(PrimitiveOperationsGroupsNames.T);
double tCount = sim.GetMetric<Primitive.CCNOT, ApplySampleWithCCNOT>(PrimitiveOperationsGroupsNames.T);
```

The first part of the program runs `ApplySampleWithCCNOT`. The second part uses the [`QCTraceSimulator.GetMetric`](xref:microsoft.quantum.simulation.simulators.QCTraceSimulators.QCTraceSimulator.GetMetric) method to retrieve the number of `T` operations run by `ApplySampleWithCCNOT`: 

```csharp
double tCount = sim.GetMetric<Primitive.CCNOT, ApplySampleWithCCNOT>(PrimitiveOperationsGroupsNames.T);
double tCountAll = sim.GetMetric<ApplySampleWithCCNOT>(PrimitiveOperationsGroupsNames.T);
```

When you call `GetMetric` with two type parameters, it returns the value of the metric associated with a given call graph edge. In the preceding example, the program calls the `Primitive.CCNOT` operation  within `ApplySampleWithCCNOT` and therefore the call graph contains the edge `<Primitive.CCNOT, ApplySampleWithCCNOT>`. 

To retrieve the number of `CNOT` operations used, add the following line:
```csharp
double cxCount = sim.GetMetric<Primitive.CCNOT, ApplySampleWithCCNOT>(PrimitiveOperationsGroupsNames.CX);
```

Finally, you can output all the statistics collected by the Primitive Operations Counter in CSV format using the following:
```csharp
string csvSummary = sim.ToCSV()[MetricsCountersNames.primitiveOperationsCounter];
```

## See also

- The Quantum Development Kit [Quantum Trace Simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro) overview.
- The [QCTraceSimulator](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulator) API reference.
- The [QCTraceSimulatorConfiguration](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration) API reference.
- The [PrimitiveOperationsGroupNames](xref:microsoft.quantum.simulation.simulators.QCTraceSimulators.PrimitiveOperationsGroupsNames) API reference.

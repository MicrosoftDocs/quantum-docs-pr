---
title: Depth Counter | Quantum computer trace simulator | Microsoft Docs
description: Overview of quantum computer trace simulator
author: vadym-kl
ms.author: vadym@microsoft.com
ms.date: 12/11/2017
ms.topic: article
uid: microsoft.quantum.machines.qc-trace-simulator.depth-counter
---
# Depth Counter

The `Depth Counter` is a part of the quantum computer [Trace
Simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro).
It is used to gather counts of the depth of
every operation invoked in a quantum program. All operations from
<xref:microsoft.quantum.intrinsic> are expressed in terms of single qubit rotations,
T gates, single qubit Clifford gates, CNOT gates and measurements of multi-qubit
Pauli observables. Users can set the depth for each of the primitive operations via the `gateTimes` field of <xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration>.

By default, all operations have depth 0 except the T gate which has depth 1. This means 
that by default, only the T depth of operations is computed (which is often desirable). Collected statistics
are aggregated over all the edges of the operations call graph. 

Let us now compute the <xref:microsoft.quantum.intrinsic.t> depth
of the <xref:microsoft.quantum.intrinsic.ccnot> operation. We will use the following Q# driver code: 

```qsharp
open Microsoft.Quantum.Primitive;
operation CCNOTDriver() : Unit {

    using (qubits = Qubit[3]) {
        CCNOT(qubits[0], qubits[1], qubits[2]);
        T(qubits[0]);
    }
}
```

## Using Depth Counter within a C# Program

To check that `CCNOT` has `T` depth 5 and `CCNOTDriver` has `T` depth 6
we can use the following C# code:

```csharp 
using Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators;
using System.Diagnostics;
var config = new QCTraceSimulatorConfiguration();
config.useDepthCounter = true;
var sim = new QCTraceSimulator(config);
var res = CCNOTDriver.Run(sim).Result;

double tDepth = sim.GetMetric<Primitive.CCNOT, CCNOTDriver>(DepthCounter.Metrics.Depth);
double tDepthAll = sim.GetMetric<CCNOTDriver>(DepthCounter.Metrics.Depth);
```

The first part of the program executes `CCNOTDriver`. In the second part, we use the method
`QCTraceSimulator.GetMetric` to get the `T` depth of `CCNOT` and `CCNOTDriver`: 

```csharp
double tDepth = sim.GetMetric<Primitive.CCNOT, CCNOTDriver>(DepthCounter.Metrics.Depth);
double tDepthAll = sim.GetMetric<CCNOTDriver>(DepthCounter.Metrics.Depth);
```

Finally, to output all the statistics collected by `Depth Counter` in CSV format we can 
use the following:
```csharp
string csvSummary = sim.ToCSV()[MetricsCountersNames.depthCounter];
```

## See also ##

- The quantum computer [Trace Simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro) overview.

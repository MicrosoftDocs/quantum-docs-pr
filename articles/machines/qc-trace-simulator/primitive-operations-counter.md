---
title: Primitive Operations Counter
description: Learn about the Microsoft QDK Primitive Operation Counter, which tracks the number of primitive executions used by operations in a quantum program. 
author: vadym-kl
ms.author: vadym@microsoft.com
ms.date: 12/11/2017
ms.topic: article
uid: microsoft.quantum.machines.qc-trace-simulator.primitive-counter
---

# Primitive Operations Counter	

The `Primitive Operations Counter` is a part of the quantum computer [Trace
Simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro). It counts the number of primitive executions used by
every operation invoked in a quantum program. All operations from
`Microsoft.Quantum.Intrinsic` are expressed in terms of single qubit rotations,
T gates, single qubit Clifford gates, CNOT gates and measurements of multi-qubit
Pauli observables. Collected statistics are aggregated over the edges of the operations
call graph. Let us now count how many `T` gates are needed to implement the `CCNOT`
operation. 

```qsharp
open Microsoft.Quantum.Intrinsic;
operation ApplySampleWithCCNOT() : Unit {

    using (qubits = Qubit[3]) {
        CCNOT(qubits[0], qubits[1], qubits[2]);
        T(qubits[0]);
    } 
}
```

## Using the Primitive Operations Counter within a C# Program

To check that `CCNOT` indeed requires 7 `T` gates and that `ApplySampleWithCCNOT` executes 8 `T` 
gates we can use the following C# code:

```csharp 
// using Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators;
// using System.Diagnostics;
var config = new QCTraceSimulatorConfiguration();
config.usePrimitiveOperationsCounter = true;
var sim = new QCTraceSimulator(config);
var res = ApplySampleWithCCNOT.Run(sim).Result;

double tCountAll = sim.GetMetric<ApplySampleWithCCNOT>(PrimitiveOperationsGroupsNames.T);
double tCount = sim.GetMetric<Primitive.CCNOT, ApplySampleWithCCNOT>(PrimitiveOperationsGroupsNames.T);
```

The first part of the program executes `ApplySampleWithCCNOT`. In the second part, we use the method
`QCTraceSimulator.GetMetric` to get the number of T gates executed by `ApplySampleWithCCNOT`: 

```csharp
double tCount = sim.GetMetric<Primitive.CCNOT, ApplySampleWithCCNOT>(PrimitiveOperationsGroupsNames.T);
double tCountAll = sim.GetMetric<ApplySampleWithCCNOT>(PrimitiveOperationsGroupsNames.T);
```

When `GetMetric` is called with two type parameters it returns the value of the
metric associated with a given call graph edge. In our example operation
`Primitive.CCNOT` is called within `ApplySampleWithCCNOT` and therefore the call graph contains
the edge `<Primitive.CCNOT, ApplySampleWithCCNOT>`. 

To get the number of `CNOT` gates used, we can add the following line:
```csharp
double cxCount = sim.GetMetric<Primitive.CCNOT, ApplySampleWithCCNOT>(PrimitiveOperationsGroupsNames.CX);
```

Finally, to output all the statistics collected by the gate counter in CSV format we can 
use the following:
```csharp
string csvSummary = sim.ToCSV()[MetricsCountersNames.primitiveOperationsCounter];
```

## See also ##

- The quantum computer [Trace Simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro) overview.

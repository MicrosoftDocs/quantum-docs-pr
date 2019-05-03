---
title: Width Counter | Quantum computer trace simulator | Microsoft Docs
description: Overview of quantum computer trace simulator
author: vadym-kl
ms.author: vadym@microsoft.com
ms.date: 12/11/2017
ms.topic: article
uid: microsoft.quantum.machines.qc-trace-simulator.width-counter
---

# Width Counter

The `Width Counter` counts the number of qubits allocated and borrowed by each operation.
 All operations from the `Microsoft.Quantum.Primitive` namespace are expressed in terms of single qubit rotations,
T gates, single qubit Clifford gates, CNOT gates and measurements of multi-qubit
Pauli observables. Some of the primitive operations can allocate extra qubits. For example, multiply controlled `X` gates or controlled `T` gates. Let us compute the number of extra qubits allocated 
by the implementation of a multiply controlled `X` gate:

```qsharp
open Microsoft.Quantum.Primitive;
open Microsoft.Quantum.Arrays;
operation MultiControlledXDriver( numberOfQubits : Int ) : Unit {

    using(qubits = Qubit[numberOfQubits]) {
        Controlled X (Rest(qubits), Head(qubits));
    } 
}
```

# Using Width Counter within a C# Program

Multiply controlled `X` acting on a total of 5 qubits will allocate 2 ancillary qubits 
and its input width will be 5. To check that this is the case, we can use the following 
C# program:

```csharp 
var config = new QCTraceSimulatorConfiguration();
config.useWidthCounter = true;
var sim = new QCTraceSimulator(config);
int totalNumberOfQubits = 5;
var res = MultiControlledXDriver.Run(sim, totalNumberOfQubits).Result;

double allocatedQubits = 
    sim.GetMetric<Primitive.X, MultiControlledXDriver>(
        WidthCounter.Metrics.ExtraWidth,
        functor: OperationFunctor.Controlled); 

double inputWidth =
    sim.GetMetric<Primitive.X, MultiControlledXDriver>(
        WidthCounter.Metrics.InputWidth,
        functor: OperationFunctor.Controlled);
```

The first part of the program executes `MultiControlledXDriver`. In the second part we use the method
`QCTraceSimulator.GetMetric` to get the number of allocated qubits as well as the number of qubits that Controlled `X`
received as input. 

Finally, to output all the statistics collected by width counter in CSV format we can 
use the following:
```csharp
string csvSummary = sim.ToCSV()[MetricsCountersNames.widthCounter];
```

## See also ##

- The quantum computer [Trace Simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro) overview.

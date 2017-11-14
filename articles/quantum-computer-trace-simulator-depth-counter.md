---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Primitive Operations Counter | Quantum computer trace simulator | Microsoft Docs 
description: Overview of quantum computer trace simulator 
#keywords: Don’t add or edit keywords without consulting your SEO champ. 
author: Vadym 
ms.author: vadym@microsoft.com 
ms.date: 11/12/2017 
ms.topic: article-type-from-white-list 
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field. 
# ms.service: service-name-from-white-list
# product-name-from-white-list

# Optional fields. Don't forget to remove # if you need a field.
# ms.custom: can-be-multiple-comma-separated
# ms.devlang:devlang-from-white-list
# ms.suite: 
# ms.tgt_pltfrm:
# ms.reviewer:
# manager: MSFT-alias-manager-or-PM-counterpart
---

# Overview

Primitive Depth Counter counts the of depth of
every operations invoked in quantum program. All operations from
`Microsoft.Quantum.Primitive` are expressed in terms of single qubit rotations,
T gate, single qubit Clifford gates, CNOT gate and measurements of multi-qubit
Pauli observables. User can set the depth for each of the primitive operations. By 
default all operations have depth 0 except T gate which has depth 1.This means 
that by default the T depth of operations is computed. Collected statistics
are aggregated over edges of operations call graph. Let us now compute T depth 
of CCNOT. We use the following Q# driver code: 

```qsharp
open Microsoft.Quantum.Primitive;
operation CCNOTDriver() : () {
    body {
        using( qubits = Qubit[3] ) {
            CCNOT(qubits[0],qubits[1],qubits[2]);
            T(qubits[0]);
        } 
    }
}
```

# Using Depth Counter within C# program

To check that CCNOT has T depth 5 and `CCNOTDriver` has T depth 6
we can use the following C# code:

```csharp 
//using Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators;
//using System.Diagnostics;
var config = new QCTraceSimulatorConfiguration();
config.useDepthCounter = true;
QCTraceSimulator sim = new QCTraceSimulator(config);
var res = CCNOTDriver.Run(sim).Result;

double tDepth = sim.GetMetric<Primitive.CCNOT, CCNOTDriver>(DepthCounter.Metrics.Depth);
double tDepthAll = sim.GetMetric<CCNOTDriver>(DepthCounter.Metrics.Depth);
```

First part of the program executes CCNOTDriver. In the second part we use method
`QCTraceSimulator.GetMetric` to get T depth of `CCNOT` and `CCNOTDriver`: 

```csharp
double tDepth = sim.GetMetric<Primitive.CCNOT, CCNOTDriver>(DepthCounter.Metrics.Depth);
double tDepthAll = sim.GetMetric<CCNOTDriver>(DepthCounter.Metrics.Depth);
```

Finally, co output all the statistics collected by depth counter in CSV format we can 
use the following:
```csharp
string csvSummary = sim.ToCSV()[MetricCalculatorsNames.depthCounter];
```
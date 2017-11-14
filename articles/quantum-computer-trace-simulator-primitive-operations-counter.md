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

Primitive Operations Counter counts the number of primitive operations used by
every operations invoked in quantum program. All operations from
`Microsoft.Quantum.Primitive` are expressed in terms of single qubit rotations,
T gate, single qubit Clifford gates, CNOT gate and measurements of multi-qubit
Pauli observables. Collected statistics are aggregated over edges of operations
call graph. Let us now count how many T gates are needed to implement `CCNOT`
operation. 

```qsharp
open Microsoft.Quantum.Primitive;
operation CCXDriver() : () {
    body {
        using( qubits = Qubit[3] ) {
            CCNOT(qubits[0],qubits[1],qubits[2]);
            T(qubits[0]);
        } 
    }
}
```

# Using Primitive Operations Counter within C# program

To check that CCNOT indeed requires 7 T gates and that `CCXDriver` executes 8 T 
gates we can use the following C# code:

```csharp 
// using Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators;
// using System.Diagnostics;
var config = new QCTraceSimulatorConfiguration();
config.usePrimitiveOperationsCounter = true;
var sim = new QCTraceSimulator(config);
var res = CCXDriver.Run(sim).Result;

string metric = PrimitiveOperationsGroups.T.ToString(); // this is just "T"
double tCount = sim.GetMetric<Primitive.CCNOT, CCXDriver>(metric);
double tCountAll = sim.GetMetric<CCXDriver>(metric);
Debug.Assert(tCount == 7.0);
Debug.Assert(tCountAll == 8.0);
```

First part of the program executes CCXDriver. In the second part we use method
`QCTraceSimulator.GetMetric` to get number of T gates executed by `CCXDriver`: 

```csharp 
double tCountAll = sim.GetMetric<CCXDriver>(tCountMetric);
```

When `GetMetric` is called with two type parameters it returns the value of the
metric associated with a given call graph edge. In our example operation
`Primitive.CCNOT` is called within `CCXDriver` and therefore call graph contains
edge `<Primitive.CCNOT,CCXDriver>`. 

To get number of CNOT gates used we can add the following two lines
```csharp
string metricCX = PrimitiveOperationsGroups.CX.ToString();
double cxCount = sim.GetMetric<Primitive.CCNOT, CCXDriver>(metricCX);
```
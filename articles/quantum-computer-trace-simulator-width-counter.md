---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Width Counter | Quantum computer trace simulator | Microsoft Docs 
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

Width Counter counts the number of qubits allocate and borrowed by each operation.
 All operations from `Microsoft.Quantum.Primitive` are expressed in terms of single qubit rotations,
T gate, single qubit Clifford gates, CNOT gate and measurements of multi-qubit
Pauli observables. Some of the primitive operations can allocate extra qubits. For example, this 
includes multiply controlled X gate or controlled T gate. Let us compute the number of extra qubits allocated 
by the implementation of multiply controlled X gate.

```qsharp
open Microsoft.Quantum.Primitive;
operation MultiControlledXDriver( numberOfQubits : Int ) : () {
    body {
        using( qubits = Qubit[numberOfQubits] ) {
            (Controlled X)(qubits[ 1 .. numberOfQubits - 1] ,qubits[0]);
        } 
    }
}
```

# Using Width counter within C# program

Multiply controlled X acting on total of 5 qubits will allocate 2 ancillary qubits 
and its input width will be 5. To check that this is the case we can use the following 
C# program. 

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

First part of the program executes MultiControlledXDriver. In the second part we use method
`QCTraceSimulator.GetMetric` to get the number of allocated qubits and qubits that Controlled X
received as an input. 

Finally, co output all the statistics collected by width counter in CSV format we can 
use the following:
```csharp
string csvSummary = sim.ToCSV()[MetricCalculatorsNames.widthCounter];
```
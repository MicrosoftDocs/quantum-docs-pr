---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Invalidated qubits use checker | Quantum computer trace simulator | Microsoft Docs 
description: Overview of quantum computer trace simulator 
keywords: Don’t add or edit keywords without consulting your SEO champ. 
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

Invalidated qubits use checker is a part of [quantum computer trace
simulator](quantum-computer-trace-simulator-1.md) designed for detecting
potential bugs in the code. Consider the following piece of Q# code to
illustrate the issues detected by invalidated qubits use checker.

```qsharp
operation UseReleasedQubitTest () : () {
    body {
        mutable q = new Qubit[1];
        using( ans = Qubit[1] ) {
            set q[0]= ans[0];
        }
        H(q[0]);
    }
}
```

When `H` is applied to `q[0]` it points to already released qubits. This can cause an undefined behavior. When invalidated qubits use checker is enabled the exception `InvalidatedQubitsUseCheckerException` will be thrown if an operation is applied to an already released qubit. 

`[TODO: add reference to Microsoft.Quantum.Simulation.QCTraceSimulatorRuntime.InvalidatedQubitsUseCheckerException ]`

# Using Invalidated qubits use checker in your C# program

The following is an example of C# driver code for using Quantum computer trace
simulator with Distinct inputs checker enabled: 

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
            var traceSimCfg = new QCTraceSimulatorConfiguration();
            traceSimCfg.useInvalidatedQubitsUseChecker = true; // enables useInvalidatedQubitsUseChecker
            QCTraceSimulator sim = new QCTraceSimulator(traceSimCfg);
            var res = MyQuantumProgram.Run().Result;
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }
    }
}
```

Class `QCTraceSimulatorConfiguration` stores the configuration of the quantum
computer trace simulator and can be provided as an argument for
`QCTraceSimulator` constructor. When `useInvalidatedQubitsUseChecker` is set to true
distinct inputs checker is enabled.

`[TODO: Add reference to
Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulator]`

`[TODO: Add reference to
Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration]`

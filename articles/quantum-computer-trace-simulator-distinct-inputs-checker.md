---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Distinct inputs checker | Quantum computer trace simulator | Microsoft Docs 
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
Distinct inputs checker is a part of [quantum computer trace
simulator](quantum-computer-trace-simulator-1.md) designed for detecting
potential bugs in the code. Consider the following piece of Q# code to
illustrate the issues detected by distinct inputs checker.

```qsharp
operation DoBoth( q1 : Qubit, q2 : Qubit, op1 : (Qubit=>()), op2 : (Qubit=>()) ) : () {
    body {
        op1(q1);
        op2(q2);
    }
}
```

When the user looks at the program above, they assume that order in which `op1`
and `op2` are called does not matter because `q1` and `q2` are different qubits
and operations acting on different qubits commute. Let us now consider an
example, where the operation above is used: 

```qsharp
operation DisctinctQubitCaptured2Test () : () {
    body {
        using( q = Qubit[3] ) {
            let op1 = CNOT(_,q[1]);
            let op2 = CNOT(q[1],_);
            DoBoth( q[0],q[2],op1,op2);
        }
    }
}
```

Now `op1` and `op2` are both obtained using partial application and share a
qubit. When user calls `DoBoth` in the example above the result of the operation
will depend on the order of `op1` and `op2` inside `DoBoth`. This is definitely
not what user would expects to happen. The distinct inputs checker will detect
such situation when enabled and will throw `DistinctInputsCheckerException`. 

`[TODO: Add reference to
Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.DistinctInputsCheckerException
]`

# Using Distinct inputs checker in your C# program

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
            traceSimCfg.useDistinctInputsChecker = true; //enables distinct inputs checker
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
`QCTraceSimulator` constructor. When `useDistinctInputsChecker` is set to true
distinct inputs checker is enabled.

`[TODO: Add reference to
Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulator]`

`[TODO: Add reference to
Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration]`

# See also
[Quantum computer trace simulator
overview](quantum-computer-trace-simulator-1.md)
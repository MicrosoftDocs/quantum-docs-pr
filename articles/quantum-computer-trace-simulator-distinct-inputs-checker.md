---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Distinct inputs checker | Quantum computer trace simulator | Microsoft Docs 
description: Overview of quantum computer trace simulator 
author: vadym-kl 
ms.author: vadym@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# For Quantum products none of these categories have been defined  yet.
# ms.service: service-name-from-white-list
# ms.prod: product-name-from-white-list
# ms.technology: tech-name-from-white-list
---

# Distinct Inputs Checker

The `Distinct Inputs Checker` is a part of the quantum computer [Trace
Simulator](quantum-computer-trace-simulator-1.md). It is designed for detecting
potential bugs in the code. Consider the following piece of Q# code to
illustrate the issues detected by this package:

```qsharp
operation DoBoth( q1 : Qubit, q2 : Qubit, op1 : (Qubit=>()), op2 : (Qubit=>()) ) : () {
    body {
        op1(q1);
        op2(q2);
    }
}
```

When the user looks at this program, they assume that the order in which `op1`
and `op2` are called does not matter because `q1` and `q2` are different qubits
and operations acting on different qubits commute. Let us now consider an
example, where this operation is used: 

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
qubit. When the user calls `DoBoth` in the example above the result of the operation
will depend on the order of `op1` and `op2` inside `DoBoth`. This is definitely
not what the user would expect to happen. The `Distinct Inputs Checker` will detect
such situations when enabled and will throw `DistinctInputsCheckerException`. See the API documentation on [DistinctInputsCheckerException](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.DistinctInputsCheckerException) for more details.

## Using the Distinct Inputs Checker in your C# Program

The following is an example of C# driver code for using the quantum computer trace
simulator with the `Distinct Inputs Checker` enabled: 

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

The class `QCTraceSimulatorConfiguration` stores the configuration of the quantum
computer trace simulator and can be provided as an argument for the
`QCTraceSimulator` constructor. When `useDistinctInputsChecker` is set to true
the `Distinct Inputs C
hecker` is enabled. See the API documentation on [QCTraceSimulator](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulator) and [QCTraceSimulatorConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration?) for more details.

## See also

- The quantum computer [Trace Simulator](quantum-computer-trace-simulator-1.md) overview.

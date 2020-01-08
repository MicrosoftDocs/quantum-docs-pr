---
title: Invalidated qubits use checker | Quantum computer trace simulator | Microsoft Docs 
description: Overview of quantum computer trace simulator 
author: vadym-kl
ms.author: vadym@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
uid: microsoft.quantum.machines.qc-trace-simulator.invalidated-qubits
---

# Invalidated Qubits Use Checker

The `Invalidated Qubits Use Checker` is a part of the quantum computer [TraceSimulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro) designed for detecting potential bugs in the code. Consider the following piece of Q# code to illustrate the issues detected by the `Invalidated Qubits Use Checker`.

```qsharp
operation UseReleasedQubit() : Unit {
    mutable q = new Qubit[1];
    using (ans = Qubit()) {
        set q w/= 0 <- ans;
    }
    H(q[0]);
}
```

When `H` is applied to `q[0]` it points to an already released qubit. This can cause undefined behavior. When the `Invalidated Qubits Use Checker` is enabled, the exception `InvalidatedQubitsUseCheckerException` will be thrown if an operation is applied to an already released qubit. See the API documentation on [InvalidatedQubitsUseCheckerException](https://docs.microsoft.com/dotnet/api/Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.InvalidatedQubitsUseCheckerException) for more details.

## Using the Invalidated Qubits Use Checker in your C# Program

The following is an example of C# driver code for using the quantum computer `Trace
Simulator` with the `Invalidated Qubits Use Checker` enabled: 

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

The class `QCTraceSimulatorConfiguration` stores the configuration of the quantum
computer trace simulator and can be provided as an argument for
the `QCTraceSimulator` constructor. When `useInvalidatedQubitsUseChecker` is set to true
the `Invalidated Qubits Use Checker` is enabled. See the API documentation on [QCTraceSimulator](https://docs.microsoft.com/dotnet/api/Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulator) and [QCTraceSimulatorConfiguration](https://docs.microsoft.com/dotnet/api/Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration) for more details.

## See also ##

- The quantum computer [Trace Simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro) overview.

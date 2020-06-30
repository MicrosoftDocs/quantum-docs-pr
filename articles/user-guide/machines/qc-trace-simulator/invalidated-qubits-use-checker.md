---
title: Invalidated Qubits Use Checker - Quantum Development Kit
description: Learn about the Microsoft QDK Invalidated Qubits Use Checker, which uses the Quantum Trace Simulator to check your Q# code for potentially invalid qubits.
author: vadym-kl
ms.author: vadym@microsoft.com 
ms.date: 06/25/2020
ms.topic: article
uid: microsoft.quantum.machines.qc-trace-simulator.invalidated-qubits
---

# Quantum Trace Simulator: Invalidated Qubits Use Checker

The Invalidated Qubits Use Checker is a part of the Quantum Development Kit [Quantum Trace Simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro). You can use it to detect potential bugs in the code caused by invalid qubits. 

## Invalid qubits

Consider the following piece of Q# code to illustrate the issues detected by the Invalidated Qubits Use Checker:

```qsharp
operation UseReleasedQubit() : Unit {
    mutable q = new Qubit[1];
    using (ans = Qubit()) {
        set q w/= 0 <- ans;
    }
    H(q[0]);
}
```

When you apply the `H` operation to `q[0]`, it points to an already released qubit, which can cause undefined behavior. When the Invalidated Qubits Use Checker is enabled, it throws the exception `InvalidatedQubitsUseCheckerException` if the program applies an operation to an already released qubit. For more information, see [InvalidatedQubitsUseCheckerException](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.InvalidatedQubitsUseCheckerException).

## Invoking the Invalidated Qubits Use Checker

To run the Quantum Trace Simulator with the invalidated qubits use checker you must create a [`QCTraceSimulatorConfiguration`](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration) instance, set the `UseInvalidatedQubitsUseChecker` property to **true**, and then create a new [`QCTraceSimulator`](xref:microsoft.quantum.simulation.simulators.QCTraceSimulators.QCTraceSimulator) instance with `QCTraceSimulatorConfiguration` as the parameter. 

```csharp
var config = new QCTraceSimulatorConfiguration();
config.UseInvalidatedQubitsUseChecker = true;
var sim = new QCTraceSimulator(config);
```


## Using the Invalidated Qubits Use Checker in a C# host program

The following is an example of C# host programs that uses the Quantum Trace Simulator with the Invalidated Qubits Use Checker enabled: 

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
            traceSimCfg.UseInvalidatedQubitsUseChecker = true; // enables UseInvalidatedQubitsUseChecker
            QCTraceSimulator sim = new QCTraceSimulator(traceSimCfg);
            var res = MyQuantumProgram.Run().Result;
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }
    }
}
```

## ## See also

- The Quantum Development Kit [Quantum Trace Simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro) overview.
- The [QCTraceSimulator](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulator) API reference.
- The [QCTraceSimulatorConfiguration](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration) API reference.
- The [InvalidatedQubitsUseCheckerException](xref:microsoft.quantum.simulation.simulators.QCTraceSimulators.InvalidatedQubitsUseCheckerException) API reference.
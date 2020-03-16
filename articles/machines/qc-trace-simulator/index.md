---
# Mandatory fields. 
title: Quantum computer trace simulator
description: Learn how to use the Microsoft Quantum computer trace simulator to debug classical code and to estimate resource requirements of a quantum program. 
author: vadym-kl 
ms.author: vadym@microsoft.com 
ms.date: 12/11/2017 
ms.topic: article
uid: microsoft.quantum.machines.qc-trace-simulator.intro
---

# Quantum Trace Simulator

The Microsoft quantum computer trace simulator executes a quantum program without actually simulating the state of a quantum computer.  For this reason, the trace simulator can execute quantum programs that use thousands of qubits.  It is useful for two main purposes: 

* Debugging classical code that is part of a quantum program. 
* Estimating the resources required to run a given instance of a quantum program
  on a quantum computer.

The trace simulator relies on additional information provided by the user when
measurements must be performed. See Section [Providing the probability of
measurement outcomes](#providing-the-probability-of-measurement-outcomes) for more
details on this. 

## Providing the Probability of Measurement Outcomes

There are two kinds of measurements that appear in quantum algorithms. The first
kind plays an auxiliary role where the user usually knows the
probability of the outcomes. In this case the user can write
<xref:microsoft.quantum.intrinsic.assertprob> from the <xref:microsoft.quantum.intrinsic> namespace to express this knowledge. The following example illustrates this:

```qsharp
operation TeleportQubit(source : Qubit, target : Qubit) : Unit {
    using (qubit = Qubit()) {
        H(qubit);
        CNOT(qubit, target);
        CNOT(source, qubit);
        H(source);

        AssertProb([PauliZ], [source], Zero, 0.5, "Outcomes must be equally likely", 1e-5);
        AssertProb([PauliZ], [q], Zero, 0.5, "Outcomes must be equally likely", 1e-5);

        if (M(source) == One)  { Z(target); X(source); }
        if (M(q) == One) { X(target); X(q); }
    }
}
```

When the trace simulator executes `AssertProb` it will record that measuring
`PauliZ` on `source` and `q` should be given an outcome of `Zero` with probability
0.5. When the simulator executes `M` later, it will find the recorded values of
the outcome probabilities and `M` will return `Zero` or `One` with probability
0.5. When the same code is executed on a simulator that keeps track of the
quantum state, such a simulator will check that the provided probabilities in
`AssertProb` are correct.

## Running your Program with the Quantum Computer Trace Simulator 

The quantum computer trace simulator may be viewed as just another target machine. The C# driver program for using it is very similar to the one for any other quantum Simulator: 

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
            QCTraceSimulator sim = new QCTraceSimulator();
            var res = MyQuantumProgram.Run().Result;
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }
    }
}
```

Note that if there is at least one measurement not annotated using `AssertProb`,
the simulator will throw `UnconstrainedMeasurementException`
from the `Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators` namespace. See the API documentation on 
[UnconstrainedMeasurementException](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.UnconstrainedMeasurementException) for more details.

In addition to running quantum programs, the trace simulator comes with five
components for detecting bugs in programs and performing quantum program
resource estimates: 

* [Distinct Inputs Checker](xref:microsoft.quantum.machines.qc-trace-simulator.distinct-inputs)
* [Invalidated Qubits Use Checker](xref:microsoft.quantum.machines.qc-trace-simulator.invalidated-qubits)
* [Primitive Operations Counter](xref:microsoft.quantum.machines.qc-trace-simulator.primitive-counter)
* [Circuit Depth Counter](xref:microsoft.quantum.machines.qc-trace-simulator.depth-counter)
* [Circuit Width Counter](xref:microsoft.quantum.machines.qc-trace-simulator.width-counter)

Each of these components may be enabled by setting appropriate flags in
`QCTraceSimulatorConfiguration`. More details about using each of these
components are provided in the corresponding reference files. See the API documentation on [QCTraceSimulatorConfiguration](https://docs.microsoft.com/dotnet/api/Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration) for specific details.

## See also
The quantum computer [trace simulator](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulator) C# reference 


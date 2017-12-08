---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Quantum computer trace simulator | Microsoft Docs 
description: Overview of quantum computer trace simulator 
#keywords: Don’t add or edit keywords without consulting your SEO champ. 
author: vadym-kl 
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

# Quantum trace simulator

The Microsoft quantum computer trace simulator executes a quantum program without actually simulating the state of a quantum computer.  For this reason, the trace simulator can execute quantum programs that use thousands of qubits.  It is useful for two main purposes: 

* Debugging classical code that is part of a quantum program. 
* Estimating the resources required to run a given instance of a quantum program
  on a quantum computer.

The trace simulator relies on additional information provided by the user when
measurements must be performed. See Section [Providing the probability of
measurement outcomes](#providing-the-probability-of-measurement-outcomes) for more
details on this. 

## Providing the probability of measurement outcomes

There are two kinds of measurements that appear in quantum algorithms. The first
kind plays an auxiliary role where the user usually knows the
probability of the outcomes. In this case the user can write
`AssertProb` from the `Microsoft.Quantum.Primitive` namespace to express this knowledge. The following example illustrates this: 

```qsharp
operation Teleportation (source : Qubit, target : Qubit) : () {
    body {
        using (ancillaRegister = Qubit[1]) {
            let ancilla = ancillaRegister[0];

            H(ancilla);
            CNOT(ancilla, target);

            CNOT(source, ancilla);
            H(source);

            AssertProb([PauliZ], [source], Zero, 0.5, "Outcomes must be equally likely", 1e-5);
            AssertProb([PauliZ], [ancilla], Zero, 0.5, "Outcomes must be equally likely", 1e-5);

            if (M(source) == One)  { Z(target); X(source); }
            if (M(ancilla) == One) { X(target); X(ancilla); }
        }
    }
}
```

When the trace simulator executes `AssertProb` it will record that measuring
`PauliZ` on `source` and `ancilla` should be given an outcome of `Zero` with probability
0.5. When the simulator executes `M` later, it will find the recorded values of
the outcome probabilities and `M` will return `Zero` or `One` with probability
0.5. When the same code is executed on a simulator that keeps track of the
quantum state, such a simulator will check that the provided probabilities in
`AssertProb` are correct. 

The second kind of measurement is used to read out the answer of the quantum
algorithm where the user usually does not know the probability of such measurement
outcomes. The quantum computer trace simulator provides a function `ForceMeasure` in
namespace `Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators` to force
the simulator to take the measurement outcome preferred by the user. See [ForceMeasure](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.ForceMeasure) for more information.

## Running your program with the quantum computer trace simulator 

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

Note that if there is at least one measurement not annotated using `AssertProb`
or `ForceMeasure` the simulator will throw `UnconstraintMeasurementException`
from the `Microsoft.Quantum.Simulation.QCTraceSimulatorRuntime` namespace. See the API documentation on [UnconstraintMeasurementException](https://review.docs.microsoft.com/en-us/dotnet/api/microsoft.quantum.simulation.simulators.qctracesimulators.unconstraintmeasurementexception?view=qsharp-preview&branch=master) for more details.

In addition to running quantum programs, the trace simulator comes with five
components for detecting bugs in programs and performing quantum program
resource estimates: 

* [Distinct Inputs Checker](quantum-computer-trace-simulator-distinct-inputs-checker.md)
* [Invalidated Qubits Use Checker](quantum-computer-trace-simulator-invalidated-qubits-use-checker.md)
* [Primitive Operations Counter](quantum-computer-trace-simulator-primitive-operations-counter.md)
* [Circuit Depth Counter](quantum-computer-trace-simulator-depth-counter.md)
* [Circuit Width Counter](quantum-computer-trace-simulator-width-counter.md)

Each of these components may be enabled by setting appropriate flags in
`QCTraceSimulatorConfiguration`. More details about using each of these
components are provided in the corresponding reference files. See the API documentation on [QCTraceSimulatorConfiguration](https://review.docs.microsoft.com/en-us/dotnet/api/Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration?view=qsharp-preview&branch=master) for specific details.

## See also
The quantum computer [trace simulator
](quantum-computer-trace-simulator-1.md) overview


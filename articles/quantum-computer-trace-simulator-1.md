# Quantum computer trace simulator 

## Overview 

Quantum computer trace simulator executes a quantum program without simulating a state of a quantum computer.  For this reason, trace simulator can execute quantum programs that use thousands of qubits.  It is useful for two main purposes: 

* Debugging classical code that is a part of quantum programs 
* Estimating the resources required to run given instance of a quantum program on a quantum computer

The trace simulator relies on additional information provided by the user when the measurement must be performed. See Section [Providing probability of measurement outcomes](#providing-probability-of-measurement-outcomes) for more details on this. 

## Providing probability of measurement outcomes

There are two kinds of measurements that appear in quantum algorithms. The first kind of measurements plays an auxiliary role and the user usually knows the probability of these measurements outcomes. In this case user can write `AssertProb` from `Microsoft.Quantum.Primitive` to express this knowledge. The following example illustrates this: 

```qsharp
operation Teleportation (source : Qubit, target : Qubit) : () {
    body {
        using (ancillaRegister = Qubit[1]) {
            let ancilla = ancillaRegister[0];

            H(ancilla);
            CNOT(ancilla, target);

            CNOT(source, ancilla);
            H(source);

            AssertProb([PauliZ], [source], Zero, 0.5, "All outcomes of the Bell measurement must be equally likely", 1e-5);
            AssertProb([PauliZ], [ancilla], Zero, 0.5, "All outcomes of the Bell measurement must be equally likely", 1e-5);

            if (M(source) == One)  { Z(target); X(source); }
            if (M(ancilla) == One) { X(target); X(ancilla); }
        }
    }
}
```

When the trace simulator executes `AssertProb` it will record that measuring `PauliZ` on `source` and `ancilla` should given outcome `Zero` with probability 0.5. When the simulator executes `M` later, it will find the recorded values of the outcomes probabilities and `M` will return `Zero` or `One` with probability 0.5. When the same code is executed on a simulator that keeps track of the quantum state, such simulator will check that that provided probabilities in `AssertProb` are correct. 

The second kind of measurements is used to read out the answer of the quantum algorithm and user usually does not know the probability of such measurements outcomes. Quantum computer trace simulator provides a function `ForceMeasure` in namespace `Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators` to force the simulator take the measurement outcome preferred by the user. 

`[TODO: add reference to Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.ForceMeasure qsharp API doc.]`

## Running you program with quantum computer trace simulator 

Quantum computer trace simulator is just another simulator. C# driver program for using it is very similar to the one for Quantum Simulator: 

```csharp
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators;

namespace Quantum.Teleport
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

Note that if there is at least one measurement not annotated using `AssertProb` or `ForceMeasure` the simulator will throw `UnconstraintMeasurementException` from `Microsoft.Quantum.Simulation.QCTraceSimulatorRuntime` namespace. 

`[TODO: add reference to Microsoft.Quantum.Simulation.QCTraceSimulatorRuntime.UnconstraintMeasurementException csharp API doc.]`

In addition to just running quantum programs the trace simulator comes with five components for detecting bugs in the programs and performing quantum program resource estimates: 

* Distinct Inputs Checker `[TODO: Add reference to the documentation file here]`
* Invalidated Qubits Use Checker `[TODO: Add reference to the documentation file here]`
* Gate Counter `[TODO: Add reference to the documentation file here]`
* Circuit Depth Counter `[TODO: Add reference to the documentation file here]`
* Circuit Width Counter `[TODO: Add reference to the documentation file here]`

Each of these components can be enabled by setting appropriate flags in `QCTraceSimulatorConfiguration`. More details about using each 
of this components are provided in the corresponding reference files.

`[TODO: add reference to Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulatorConfiguration csharp API doc. ]`

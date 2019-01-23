---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Quantum Development Kit Resources Estimator | Microsoft Docs 
description: Overview of Microsoft's Quantum Development Kit Resources estimator 
author: anpaz-msft
ms.author: anpaz@microsoft.com 
ms.date: 1/22/2019
ms.topic: article
uid: microsoft.quantum.machines.resources-estimator
---

# Resources estimator

As the name implies, the `ResourcesEstimator` estimates the resources 
required to run a given instance of a quantum program on a quantum computer.
It accomplishes this by executing the quantum program without actually 
simulating the state of a quantum computer; for this reason, 
it can estimate resources for quantum programs that use thousands of qubits.

## Usage

The `ResourcesEstimator` is just another type of target machine, thus 
it can be used to run any Q# program. 

As other target machines, to use it on a C# host program create an instance and pass it
as the first parameter of the operation's `Run` method to estimate:

```csharp
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.MyProgram
{
    class Driver
    {
        static void Main(string[] args)
        {
            ResourcesEstimator estimator = new ResourcesEstimator();
            var res = MyQuantumProgram.Run(estimator).Result;
            Console.WriteLine(estimator.ToTSV());
        }
    }
}
```

As the example shows, the `ResourcesEstimator` provides a `ToTSV()` method to generate
a table with tab-seperated-values (TSV) that can be saved into a file
or written to the console for analysis.


## Programmatically Retrieving the Results

On top of a TSV table, the resources estimated can be retrieved programmatically
via the `ResourcesEstimator`'s `Data` property. `Data` returns a `System.DataTable` 
instance, indexed by the metrics names, and the statistics of each metric (sum, average, etc)
as the columns; the statistics reported are:
  * Sum
  * Average
  * Variance
  * Min
  * Max
  * SecondMoment

The following code shows how to retrieve and print the total number of `QubitClifford`, `T` and `CNOT` 
gates used by a Q# operation:

```csharp
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.MyProgram
{
    class Driver
    {
        static void Main(string[] args)
        {
            ResourcesEstimator estimator = new ResourcesEstimator();
            var res = MyQuantumProgram.Run(estimator).Result;

            var data = estimator.Data;
            Console.WriteLine($"QubitCliffords: {data.Rows.Find("QubitClifford")["Sum"]}");
            Console.WriteLine($"Ts: {data.Rows.Find("T")["Sum"]}");
            Console.WriteLine($"CNOTs: {data.Rows.Find("CNOT")["Sum"]}");
        }
    }
}
```

## Metrics Reported



## Providing the Probability of Measurement Outcomes

There are two kinds of measurements that appear in quantum algorithms. The first
kind plays an auxiliary role where the user usually knows the
probability of the outcomes. In this case the user can write
<xref:microsoft.quantum.primitive.assertprob> from the <xref:microsoft.quantum.primitive> namespace to express this knowledge. The following example illustrates this:

```qsharp
operation Teleportation (source : Qubit, target : Qubit) : Unit {
    body (...) {
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

## Running your Program with the Quantum Computer Trace Simulator 


Note that if there is at least one measurement not annotated using `AssertProb`
or `ForceMeasure` the simulator will throw `UnconstraintMeasurementException`
from the `Microsoft.Quantum.Simulation.QCTraceSimulatorRuntime` namespace. See the API documentation on [UnconstraintMeasurementException](https://docs.microsoft.com/dotnet/api/microsoft.quantum.simulation.simulators.qctracesimulators.unconstraintmeasurementexception) for more details.

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
The quantum computer [trace simulator
](https://docs.microsoft.com/dotnet/api/Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators.QCTraceSimulator) C# reference 

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

# The ResourcesEstimator Target Machine

As the name implies, the `ResourcesEstimator` estimates the resources 
required to run a given instance of a Q# operation on a quantum computer.
It accomplishes this by executing the quantum operation without actually 
simulating the state of a quantum computer; for this reason, 
it can estimate resources for Q# operations that use thousands of qubits.

## Usage

The `ResourcesEstimator` is just another type of target machine, thus 
it can be used to run any Q# operation. 

As other target machines, to use it on a C# host program create an instance and pass it
as the first parameter of the operation's `Run` method:

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
            MyQuantumProgram.Run(estimator).Wait();
            Console.WriteLine(estimator.ToTSV());
        }
    }
}
```

As the example shows, the `ResourcesEstimator` provides a `ToTSV()` method to generate
a table with tab-seperated-values (TSV) that can be saved into a file
or written to the console for analysis. The output of the above program should look something like this:

```Output
Metric          Sum
CNOT            1000
QubitClifford   1000
R               0
Measure         4002
T               0
Depth           0
Width           2
BorrowedWidth   0
```

> [!NOTE]
> The `ResourcesEstimator` does not reset its calculations on every run, if the same instance is
> used to execute another operation it will keep aggregating counts on top of existing results.
> If you need to reset calculations between runs, create a new instance for every execution.


## Programmatically Retrieving the Estimated Data

In addition to a TSV table, the resources estimated can be retrieved programmatically
via the `ResourcesEstimator`'s `Data` property. `Data` provides a `System.DataTable` 
instance with two columns: `Metric` and `Sum`, indexed by the metrics names.

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
            MyQuantumProgram.Run(estimator).Wait();

            var data = estimator.Data;
            Console.WriteLine($"QubitCliffords: {data.Rows.Find("QubitClifford")["Sum"]}");
            Console.WriteLine($"Ts: {data.Rows.Find("T")["Sum"]}");
            Console.WriteLine($"CNOTs: {data.Rows.Find("CNOT")["Sum"]}");
        }
    }
}
```

## Metrics Reported

The following is the list of metrics estimated by the `ResourcesEstimator`:

* __CNOT__: The count of CNOT (also known as the Controlled Pauli X gate) gates executed.
* __QubitClifford__: The count of any single qubit Clifford and Pauli gates executed.
* __Measure__:  The count of any measurements executed.
* __R__: The count of any single qubit rotations executed, excluding T, Clifford and Pauli gates.
* __T__: The count of T gates and their conjugates, including the T gate, T_x = H.T.H, and T_y = Hy.T.Hy, executed.
* __Depth__: Depth of the quantum circuit executed by the Q# operation. By default, only T gates are counted in the depth, see [depth counter](xref:microsoft.quantum.machines.qc-trace-simulator.depth-counter) for details.
* __Width__: Maximum number of qubits allocated during the execution of the Q# operation.
* __BorrowedWidth__: Maximum number of qubits borrowed inside the Q# operation.


## Providing the Probability of Measurement Outcomes

<xref:microsoft.quantum.primitive.assertprob> from the <xref:microsoft.quantum.primitive> namespace can 
be used to provide information about the expected probability of a measurement to help drive the execution 
of the Q# program. The following example illustrates this:

```qsharp
operation Teleportation (source : Qubit, target : Qubit) : Unit {

    using (ancilla = Qubit()) {

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
```

When the `ResourcesEstimator` encounters `AssertProb` it will record that measuring
`PauliZ` on `source` and `ancilla` should be given an outcome of `Zero` with probability
0.5. When it executes `M` later, it will find the recorded values of
the outcome probabilities and `M` will return `Zero` or `One` with probability
0.5.


## See also

The `ResourcesEstimator` is built on top of the quantum computer [trace simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro), which provides a richer set of metrics, 
the ability to report metrics on the full call-graph, and features like [distinct inputs checker](xref:microsoft.quantum.machines.qc-trace-simulator.distinct-inputs) to help find bugs on Q# programs. 
Please refer to the [trace simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro)
documentation for more information.


---
title: Quantum Toffoli simulator - Quantum Development Kit
description: Learn about the Microsoft QDK Toffoli simulator, a special purpose quantum simulator that can be used with millions of qubits. 
author: alan-geller
ms.author: ageller 
ms.date: 6/25/2020
ms.topic: conceptual
uid: microsoft.quantum.machines.toffoli-simulator
no-loc: ['Q#', '$$v']
---

# Quantum Development Kit (QDK) Toffoli simulator

The QDK Toffoli simulator is a special-purpose simulator with a limited scope and only supports `X`, `CNOT`, and multi-controlled `X` quantum operations. All classical logic and computations are available.

While the Toffoli simulator is more restricted in functionality than the [full state simulator](xref:microsoft.quantum.machines.full-state-simulator), it has the advantage of being able to simulate far more qubits. The Toffoli simulator can be used with millions of qubits, while the full state simulator is limited to about 30 qubits. This is useful, for example, with oracles that evaluate Boolean functions - they can be implemented using the limited set of supported algorithms and tested on a large number of qubits.

## Invoking the Toffoli simulator

You expose the Toffoli simulator via the `ToffoliSimulator` class. For additional details, see [Ways to run a Q# program](xref:microsoft.quantum.guide.host-programs).

### Invoking the Toffoli simulator from C#

As with other target machines, you first create an instance of the `ToffoliSimulator` class and then pass it as the first parameter of an operation's `Run` method.

Note that, unlike the `QuantumSimulator` class, the `ToffoliSimulator` class does not implement the <xref:System.IDisposable> interface, and thus you do not need to enclose it within a `using` statement.

```csharp
    var sim = new ToffoliSimulator();
    var res = myOperation.Run(sim).Result;
    ///...
```

### Invoking the Toffoli simulator from Python

Use the [toffoli_simulate()](https://docs.microsoft.com/python/qsharp-core/qsharp.loader.qsharpcallable) method from the Python library with the imported Q# operation:

```python
qubit_result = myOperation.toffoli_simulate()
```

### Invoking the Toffoli simulator from the command line

When running a Q# program from the command line, use the **--simulator** (or **-s** shortcut) parameter to specify the Toffoli simulator target machine. The following command runs a program using the resources estimator: 

```dotnetcli
dotnet run -s ToffoliSimulator
```

### Invoking the Toffoli simulator from Juptyer Notebooks

Use the IQ# magic command [%toffoli](xref:microsoft.quantum.iqsharp.magic-ref.toffoli) to run the Q# operation.

```
%toffoli myOperation
```

## Supported operations

The Toffoli simulator supports:

* Rotations and exponentiated Paulis, such as `R` and `Exp`, when the resulting operation equals `X` or the identity matrix.
* Measurement and [assert](xref:Microsoft.Quantum.Diagnostics.AssertMeasurement) operations, but only in the Pauli `Z` basis. 
Note that a measurement operation's probability is always either **0** or **1**;
there is no randomness in the Toffoli simulator.
* `DumpMachine` and `DumpRegister` functions.
Both functions output the current `Z`-basis state of each qubit,
one qubit per line.

## Specifying the number of qubits

By default, a `ToffoliSimulator` instance allocates space for 65,536 qubits.
If your algorithm requires more qubits than this, you can specify the qubit count by providing a value for the `qubitCount` parameter to the constructor.
Each additional qubit requires only one byte of memory, so there is
no significant cost to overestimating the number of qubits you'll need.

For example:

```csharp
    var sim = new ToffoliSimulator(qubitCount: 1000000);
    var res = myLargeOperation.Run(sim).Result;
```

## See also

- [Quantum Resources Estimator](xref:microsoft.quantum.machines.resources-estimator)
- [Quantum Trace simulator](xref:microsoft.quantum.machines.qc-trace-simulator.intro)
- [Quantum Full State simulator](xref:microsoft.quantum.machines.full-state-simulator) 
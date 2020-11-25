---
uid: Microsoft.Quantum.Diagnostics.DumpRegister
title: DumpRegister function
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: DumpRegister
qsharp.summary: Dumps the current target machine's status associated with the given qubits.
---

# DumpRegister function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Dumps the current target machine's status associated with the given qubits.

```qsharp
function DumpRegister<'T> (location : 'T, qubits : Qubit[]) : Unit
```


## Input

### location : 'T

Provides information on where to generate the state's dump.


### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

The list of qubits to report.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

None.

## Type Parameters

### 'T



## Remarks

This method allows you to dump the information associated with the state of thegiven qubits into a file or some other location.The actual information generated and the semantics of `location`are specific to each target machine. However, providing an empty tuple as a location (`()`)typically means to generate the output to the console.For the local full state simulator distributed as part of theQuantum Development Kit, this method  expects a string withthe path to a file in which it will write thestate of the given qubits (i.e. the wave function of the corresponding  subsystem) as aone-dimensional array of complex numbers, in which each element representsthe amplitudes of the probability of measuring the corresponding state.If the given qubits are entangled with some other qubit and theirstate can't be separated, it just reports that the qubits are entangled.
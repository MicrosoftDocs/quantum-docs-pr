---
uid: Microsoft.Quantum.Diagnostics.DumpMachine
title: DumpMachine function
ms.date: 12/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: DumpMachine
qsharp.summary: Dumps the current target machine's status.
---

# DumpMachine function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Dumps the current target machine's status.

```qsharp
function DumpMachine<'T> (location : 'T) : Unit
```


## Input

### location : 'T

Provides information on where to generate the machine's dump.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

None.

## Type Parameters

### 'T



## Remarks

This method allows you to dump information about the current status of thetarget machine into a file or some other location.The actual information generated and the semantics of `location`are specific to each target machine. However, providing an empty tuple as a location (`()`)or just omitting the `location` parameter typically means to generate the output to the console.For the local full state simulator distributed as part of theQuantum Development Kit, this method  expects a string withthe path to a file in which it will write the wave function as aone-dimensional array of complex numbers, in which each element representsthe amplitudes of the probability of measuring the corresponding state.
---
uid: Microsoft.Quantum.Canon.ApplyToPartition
title: ApplyToPartition operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToPartition
qsharp.summary: Applies a pair of operations to a given partition of a register into two parts.
---

# ApplyToPartition operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a pair of operations to a given partition of a register into two parts.

```Q#
ApplyToPartition (op : ((Qubit[], Qubit[]) => Unit), numberOfQubitsToFirstArgument : Int, target : Qubit[]) : Unit
```


## Input

### op : (Qubit[],Qubit[]) => Unit 

The pair of operations to be applied to the given partition.


### numberOfQubitsToFirstArgument : Int

Number of qubits from target to put into the first part of the partition.The remaining qubits constitute the second part of the partition.


### target : Qubit[]

A register of qubits that are being partitioned and operated on by thegiven two operation.



## See Also

- [microsoft.quantum.canon.applytopartitiona](xref:microsoft.quantum.canon.applytopartitiona)
- [microsoft.quantum.canon.applytopartitionc](xref:microsoft.quantum.canon.applytopartitionc)
- [microsoft.quantum.canon.applytopartitionca](xref:microsoft.quantum.canon.applytopartitionca)
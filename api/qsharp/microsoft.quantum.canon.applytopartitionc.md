---
uid: Microsoft.Quantum.Canon.ApplyToPartitionC
title: ApplyToPartitionC operation
ms.date: 11/11/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToPartitionC
qsharp.summary: >-
  Applies a pair of operations to a given partition of a register into two parts.
  The modifier `C` indicates that the operation is controllable.
---

# ApplyToPartitionC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies a pair of operations to a given partition of a register into two parts.The modifier `C` indicates that the operation is controllable.

```qsharp
operation ApplyToPartitionC (op : ((Qubit[], Qubit[]) => Unit is Ctl), numberOfQubitsToFirstArgument : Int, target : Qubit[]) : Unit is Ctl
```


## Input

### op : ([Qubit](xref:microsoft.quantum.lang-ref.qubit)[],[Qubit](xref:microsoft.quantum.lang-ref.qubit)[]) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Ctl

The pair of operations to be applied to the given partition.


### numberOfQubitsToFirstArgument : [Int](xref:microsoft.quantum.lang-ref.int)

Number of qubits from target to put into the first part of the partition.The remaining qubits constitute the second part of the partition.


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A register of qubits that are being partitioned and operated on by thegiven two operation.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Canon.ApplyToPartition](xref:Microsoft.Quantum.Canon.ApplyToPartition)
---
uid: Microsoft.Quantum.Canon.ApplyToPartition
title: ApplyToPartition operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToPartition
qsharp.summary: Applies a pair of operations to a given partition of a register into two parts.
---

# ApplyToPartition operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies a pair of operations to a given partition of a register into two parts.

```qsharp
operation ApplyToPartition (op : ((Qubit[], Qubit[]) => Unit), numberOfQubitsToFirstArgument : Int, target : Qubit[]) : Unit
```


## Input

### op : ([Qubit](xref:microsoft.quantum.concepts.the-qubit)[],[Qubit](xref:microsoft.quantum.concepts.the-qubit)[]) => [Unit](xref:microsoft.quantum.user-guide.language.types) 

The pair of operations to be applied to the given partition.


### numberOfQubitsToFirstArgument : [Int](xref:microsoft.quantum.user-guide.language.types)

Number of qubits from target to put into the first part of the partition.The remaining qubits constitute the second part of the partition.


### target : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[]

A register of qubits that are being partitioned and operated on by thegiven two operation.



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## See Also

- [Microsoft.Quantum.Canon.ApplyToPartitionA](xref:Microsoft.Quantum.Canon.ApplyToPartitionA)
- [Microsoft.Quantum.Canon.ApplyToPartitionC](xref:Microsoft.Quantum.Canon.ApplyToPartitionC)
- [Microsoft.Quantum.Canon.ApplyToPartitionCA](xref:Microsoft.Quantum.Canon.ApplyToPartitionCA)
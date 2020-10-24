---
uid: Microsoft.Quantum.Canon.ApplyToPartitionA
title: ApplyToPartitionA operation
ms.date: 10/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToPartitionA
qsharp.summary: >-
  Applies a pair of operations to a given partition of a register into two parts.
  The modifier `A` indicates that the operation is adjointable.
---

# ApplyToPartitionA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a pair of operations to a given partition of a register into two parts.The modifier `A` indicates that the operation is adjointable.

```qsharp
operation ApplyToPartitionA (op : ((Qubit[], Qubit[]) => Unit is Adj), numberOfQubitsToFirstArgument : Int, target : Qubit[]) : Unit
```


## Input

### op : ([Qubit](xref:microsoft.quantum.lang-ref.qubit)[],[Qubit](xref:microsoft.quantum.lang-ref.qubit)[]) => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj

The pair of operations to be applied to the given partition.


### numberOfQubitsToFirstArgument : [Int](xref:microsoft.quantum.lang-ref.int)

Number of qubits from target to put into the first part of the partition.The remaining qubits constitute the second part of the partition.


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A register of qubits that are being partitioned and operated on by thegiven two operation.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Canon.ApplyToPartition](xref:Microsoft.Quantum.Canon.ApplyToPartition)
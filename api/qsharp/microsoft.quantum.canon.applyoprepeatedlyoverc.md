---
uid: Microsoft.Quantum.Canon.ApplyOpRepeatedlyOverC
title: ApplyOpRepeatedlyOverC operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyOpRepeatedlyOverC
qsharp.summary: Applies the same op over a qubit register multiple times.
---

# ApplyOpRepeatedlyOverC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies the same op over a qubit register multiple times.

```qsharp
operation ApplyOpRepeatedlyOverC (op : (Qubit[] => Unit is Ctl), targets : Int[][], register : Qubit[]) : Unit is Ctl
```


## Input

### op : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[] => [Unit](xref:microsoft.quantum.user-guide.language.types)  is Ctl

An operation to be applied multiple times on the qubit register


### targets : [Int](xref:microsoft.quantum.user-guide.language.types)[][]

Nested arrays describing the targets of the op. Each array should contain a list of ints describingthe qubits to be used.


### register : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[]

Qubit register to be acted upon.



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## See Also

- [Microsoft.Quantum.Canon.ApplySeriesOfOps](xref:Microsoft.Quantum.Canon.ApplySeriesOfOps)
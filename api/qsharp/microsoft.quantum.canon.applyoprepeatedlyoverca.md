---
uid: Microsoft.Quantum.Canon.ApplyOpRepeatedlyOverCA
title: ApplyOpRepeatedlyOverCA operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyOpRepeatedlyOverCA
qsharp.summary: Applies the same op over a qubit register multiple times.
---

# ApplyOpRepeatedlyOverCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies the same op over a qubit register multiple times.

```qsharp
operation ApplyOpRepeatedlyOverCA (op : (Qubit[] => Unit is Adj + Ctl), targets : Int[][], register : Qubit[]) : Unit is Adj + Ctl
```


## Input

### op : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[] => [Unit](xref:microsoft.quantum.user-guide.language.types)  is Adj + Ctl

An operation to be applied multiple times on the qubit register


### targets : [Int](xref:microsoft.quantum.user-guide.language.types)[][]

Nested arrays describing the targets of the op. Each array should contain a list of ints describingthe qubits to be used.


### register : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[]

Qubit register to be acted upon.



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## See Also

- [Microsoft.Quantum.Canon.ApplySeriesOfOps](xref:Microsoft.Quantum.Canon.ApplySeriesOfOps)
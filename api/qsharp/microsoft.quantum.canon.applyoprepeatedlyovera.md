---
uid: Microsoft.Quantum.Canon.ApplyOpRepeatedlyOverA
title: ApplyOpRepeatedlyOverA operation
ms.date: 2/12/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyOpRepeatedlyOverA
qsharp.summary: Applies the same op over a qubit register multiple times.
---

# ApplyOpRepeatedlyOverA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies the same op over a qubit register multiple times.

```qsharp
operation ApplyOpRepeatedlyOverA (op : (Qubit[] => Unit is Adj), targets : Int[][], register : Qubit[]) : Unit is Adj
```


## Input

### op : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj

An operation to be applied multiple times on the qubit register


### targets : [Int](xref:microsoft.quantum.lang-ref.int)[][]

Nested arrays describing the targets of the op. Each array should contain a list of ints describingthe qubits to be used.


### register : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubit register to be acted upon.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Canon.ApplySeriesOfOps](xref:Microsoft.Quantum.Canon.ApplySeriesOfOps)
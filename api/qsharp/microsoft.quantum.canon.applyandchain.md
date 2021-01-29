---
uid: Microsoft.Quantum.Canon.ApplyAndChain
title: ApplyAndChain operation
ms.date: 1/29/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyAndChain
qsharp.summary: Computes a chain of AND gates
---

# ApplyAndChain operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Computes a chain of AND gates

```qsharp
operation ApplyAndChain (auxRegister : Qubit[], ctrlRegister : Qubit[], target : Qubit) : Unit is Adj
```


## Description

The auxiliary qubits to compute temporary results must be specified explicitly.The length of that register is `Length(ctrlRegister) - 2`, if there are at leasttwo controls, otherwise the length is 0.

## Input

### auxRegister : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]




### ctrlRegister : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]




### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


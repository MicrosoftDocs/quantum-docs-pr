---
uid: Microsoft.Quantum.ErrorCorrection.EncodeIntoFiveQubitCode
title: EncodeIntoFiveQubitCode operation
ms.date: 11/6/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: EncodeIntoFiveQubitCode
qsharp.summary: Encodes into the ⟦5, 1, 3⟧ quantum code.
---

# EncodeIntoFiveQubitCode operation

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [](https://nuget.org/packages/)


Encodes into the ⟦5, 1, 3⟧ quantum code.

```qsharp
operation EncodeIntoFiveQubitCode (physRegister : Qubit[], auxQubits : Qubit[]) : Microsoft.Quantum.ErrorCorrection.LogicalRegister
```


## Input

### physRegister : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A qubit representing an unencoded state. This array `Qubit[]` is oflength 1.


### auxQubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A register of auxiliary qubits that will be used to represent theencoded state.



## Output : [LogicalRegister](xref:Microsoft.Quantum.ErrorCorrection.LogicalRegister)

An array of physical qubits of type `LogicalRegister` that store theencoded state.

## See Also

- [Microsoft.Quantum.ErrorCorrection.LogicalRegister](xref:Microsoft.Quantum.ErrorCorrection.LogicalRegister)
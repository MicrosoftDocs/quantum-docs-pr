---
uid: Microsoft.Quantum.ErrorCorrection.EncodeIntoBitFlipCode
title: EncodeIntoBitFlipCode operation
ms.date: 1/22/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: EncodeIntoBitFlipCode
qsharp.summary: Encodes into the [3, 1, 3] / ⟦3, 1, 1⟧ bit-flip code.
---

# EncodeIntoBitFlipCode operation

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Encodes into the [3, 1, 3] / ⟦3, 1, 1⟧ bit-flip code.

```qsharp
operation EncodeIntoBitFlipCode (physRegister : Qubit[], auxQubits : Qubit[]) : Microsoft.Quantum.ErrorCorrection.LogicalRegister
```


## Input

### physRegister : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A register of physical qubits representing the data to be protected.


### auxQubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A register of auxiliary qubits initially in the $\ket{00}$ state to beused in encoding the data to be protected.



## Output : [LogicalRegister](xref:Microsoft.Quantum.ErrorCorrection.LogicalRegister)

The physical and auxiliary qubits used in encoding, represented as alogical register.

## See Also

- [Microsoft.Quantum.ErrorCorrection.LogicalRegister](xref:Microsoft.Quantum.ErrorCorrection.LogicalRegister)
---
uid: Microsoft.Quantum.ErrorCorrection.DecodeFromFiveQubitCode
title: DecodeFromFiveQubitCode operation
ms.date: 2/12/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: DecodeFromFiveQubitCode
qsharp.summary: Decodes the ⟦5, 1, 3⟧ quantum code.
---

# DecodeFromFiveQubitCode operation

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Decodes the ⟦5, 1, 3⟧ quantum code.

```qsharp
operation DecodeFromFiveQubitCode (logicalRegister : Microsoft.Quantum.ErrorCorrection.LogicalRegister) : (Qubit[], Qubit[])
```


## Input

### logicalRegister : [LogicalRegister](xref:Microsoft.Quantum.ErrorCorrection.LogicalRegister)

An array of qubits representing the encoded 5-qubit code logical state.



## Output : ([Qubit](xref:microsoft.quantum.lang-ref.qubit)[],[Qubit](xref:microsoft.quantum.lang-ref.qubit)[])

A qubit array of length 1 representing the unencoded state in thefirst parameter, together with auxiliary qubits in the second parameter.

## See Also

- [Microsoft.Quantum.ErrorCorrection.FiveQubitCodeEncoder](xref:Microsoft.Quantum.ErrorCorrection.FiveQubitCodeEncoder)
- [Microsoft.Quantum.ErrorCorrection.LogicalRegister](xref:Microsoft.Quantum.ErrorCorrection.LogicalRegister)
---
uid: Microsoft.Quantum.ErrorCorrection.DecodeFromSteaneCode
title: DecodeFromSteaneCode operation
ms.date: 11/19/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: DecodeFromSteaneCode
qsharp.summary: >-
  An inverse encoding operation that maps an unencoded quantum register to an encoded quantum
  register under the ⟦7, 1, 3⟧ Steane quantum code.
---

# DecodeFromSteaneCode operation

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


An inverse encoding operation that maps an unencoded quantum register to an encoded quantumregister under the ⟦7, 1, 3⟧ Steane quantum code.

```qsharp
operation DecodeFromSteaneCode (logicalRegister : Microsoft.Quantum.ErrorCorrection.LogicalRegister) : (Qubit[], Qubit[])
```


## Input

### logicalRegister : [LogicalRegister](xref:Microsoft.Quantum.ErrorCorrection.LogicalRegister)

An array of qubits representing the encoded 5-qubit code logical state.



## Output : ([Qubit](xref:microsoft.quantum.lang-ref.qubit)[],[Qubit](xref:microsoft.quantum.lang-ref.qubit)[])

A qubit array of length 1 representing the unencoded state in thefirst parameter, together with auxiliary qubits in the second parameter.

## Remarks

The chosen decoder uses the CSS code property of the ⟦7, 1, 3⟧ Steane code, i.e., it corrects X errorsand Z errors separately. A property of the code is that the location of the X, respectively, Z correctionto be applied is the 3-bit encoding of the X, respectively, Z syndrome when considered an integer.

## References

- D. Gottesman, "Stabilizer Codes and Quantum Error Correction," Ph.D. Thesis, Caltech, 1997;  https://arxiv.org/abs/quant-ph/9705052

## See Also

- [Microsoft.Quantum.ErrorCorrection.SteaneCodeEncoder](xref:Microsoft.Quantum.ErrorCorrection.SteaneCodeEncoder)
- [Microsoft.Quantum.ErrorCorrection.SteaneCodeDecoder](xref:Microsoft.Quantum.ErrorCorrection.SteaneCodeDecoder)
- [Microsoft.Quantum.ErrorCorrection.LogicalRegister](xref:Microsoft.Quantum.ErrorCorrection.LogicalRegister)
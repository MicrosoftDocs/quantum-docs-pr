---
uid: Microsoft.Quantum.ErrorCorrection.SteaneCodeRecoveryX
title: SteaneCodeRecoveryX function
ms.date: 11/10/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: SteaneCodeRecoveryX
qsharp.summary: Decoder for the X-part of the stabilizer group of the ⟦7, 1, 3⟧ Steane quantum code.
---

# SteaneCodeRecoveryX function

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Decoder for the X-part of the stabilizer group of the ⟦7, 1, 3⟧ Steane quantum code.

```qsharp
function SteaneCodeRecoveryX (syndrome : Microsoft.Quantum.ErrorCorrection.Syndrome) : Pauli[]
```


## Input

### syndrome : [Syndrome](xref:Microsoft.Quantum.ErrorCorrection.Syndrome)

A syndrome array obtained from measuring the X-part of the stabilizer.



## Output : [Pauli](xref:microsoft.quantum.lang-ref.pauli)[]

An array of Pauli operations which, when applied to the encoded quantum systemcorrects the error corresponding to `syndrome`.

## Remarks

The chosen decoder uses the CSS code property of the ⟦7, 1, 3⟧ Steane code, i.e., it corrects X errorsand Z errors separately. A property of the code is that the location of the X, respectively, Z correctionto be applied is the 3-bit encoding of the X, respectively, Z syndrome when considered an integer.

## References

- D. Gottesman, "Stabilizer Codes and Quantum Error Correction," Ph.D. Thesis, Caltech, 1997;  https://arxiv.org/abs/quant-ph/9705052

## See Also

- [Microsoft.Quantum.ErrorCorrection.SteaneCodeRecoveryX](xref:Microsoft.Quantum.ErrorCorrection.SteaneCodeRecoveryX)
- [Microsoft.Quantum.ErrorCorrection.SteaneCodeRecoveryFns](xref:Microsoft.Quantum.ErrorCorrection.SteaneCodeRecoveryFns)
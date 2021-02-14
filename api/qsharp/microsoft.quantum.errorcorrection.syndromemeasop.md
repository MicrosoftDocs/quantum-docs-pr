---
uid: Microsoft.Quantum.ErrorCorrection.SyndromeMeasOp
title: SyndromeMeasOp user defined type
ms.date: 2/14/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: SyndromeMeasOp
qsharp.summary: >-
  Represents an operation that is used to measure the syndrome
  of an error-correcting code block.
---

# SyndromeMeasOp user defined type

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents an operation that is used to measure the syndromeof an error-correcting code block.

```qsharp

newtype SyndromeMeasOp = ((Microsoft.Quantum.ErrorCorrection.LogicalRegister => Microsoft.Quantum.ErrorCorrection.Syndrome));
```



## Example

Measure syndromes for the bit-flip code$S = \langle ZZI, IZZ \rangle$ using scratch qubits in anon–fault tolerant manner:```qsharp    let syndMeasOp = SyndromeMeasOp(MeasureStabilizerGenerators([            [PauliZ, PauliZ, PauliI],            [PauliI, PauliZ, PauliZ]        ], _, MeasureWithScratch));```

## Remarks

The signature `(LogicalRegister => Syndrome)` represents an operationthat acts jointly on the qubits in `LogicalRegister` and some auxiliaryqubits followed by a measurements of the auxiliary qubits to extract a`Syndrome` value representing the `Result[]` of these measurements.

## See Also

- [Microsoft.Quantum.ErrorCorrection.LogicalRegister](xref:Microsoft.Quantum.ErrorCorrection.LogicalRegister)
- [Microsoft.Quantum.ErrorCorrection.Syndrome](xref:Microsoft.Quantum.ErrorCorrection.Syndrome)
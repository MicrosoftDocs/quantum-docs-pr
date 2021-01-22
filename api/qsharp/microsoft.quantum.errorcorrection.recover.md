---
uid: Microsoft.Quantum.ErrorCorrection.Recover
title: Recover operation
ms.date: 1/22/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: Recover
qsharp.summary: >-
  Performs a single round of error correction by a quantum code
  described by a `QECC` type.
---

# Recover operation

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Performs a single round of error correction by a quantum codedescribed by a `QECC` type.

```qsharp
operation Recover (code : Microsoft.Quantum.ErrorCorrection.QECC, fn : Microsoft.Quantum.ErrorCorrection.RecoveryFn, logicalRegister : Microsoft.Quantum.ErrorCorrection.LogicalRegister) : Unit
```


## Input

### code : [QECC](xref:Microsoft.Quantum.ErrorCorrection.QECC)

A quantum error-correcting code packaged as a `QECC` type describesthe encoding and decoding of quantum data, and how error syndromesare to be measured.


### fn : [RecoveryFn](xref:Microsoft.Quantum.ErrorCorrection.RecoveryFn)

A `RecoveryFn` that maps each error syndrome to the `Pauli[]` operationsthat correct the detected error.


### logicalRegister : [LogicalRegister](xref:Microsoft.Quantum.ErrorCorrection.LogicalRegister)

An array of qubits where the stabilizer code is defined.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.ErrorCorrection.QECC](xref:Microsoft.Quantum.ErrorCorrection.QECC)
- [Microsoft.Quantum.ErrorCorrection.RecoveryFn](xref:Microsoft.Quantum.ErrorCorrection.RecoveryFn)
- [Microsoft.Quantum.ErrorCorrection.LogicalRegister](xref:Microsoft.Quantum.ErrorCorrection.LogicalRegister)
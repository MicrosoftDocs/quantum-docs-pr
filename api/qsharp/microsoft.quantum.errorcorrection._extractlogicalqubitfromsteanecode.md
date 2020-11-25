---
uid: Microsoft.Quantum.ErrorCorrection._ExtractLogicalQubitFromSteaneCode
title: _ExtractLogicalQubitFromSteaneCode operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: _ExtractLogicalQubitFromSteaneCode
qsharp.summary: >-
  Syndrome measurement and the inverse of embedding.

  $X$- and $Z$-stabilizers are not treated equally,
  which is due to the particular choice of the encoding circuit.
  This asymmetry leads to a different syndrome extraction routine.
  One could measure the syndrome by measuring multi-qubit Pauli operator
  directly on the code state, but for the distillation purpose
  the logical qubit is returned into a single qubit,
  in course of which the syndrome measurements can be done without further ancillas.
---

# _ExtractLogicalQubitFromSteaneCode operation

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Syndrome measurement and the inverse of embedding.$X$- and $Z$-stabilizers are not treated equally,which is due to the particular choice of the encoding circuit.This asymmetry leads to a different syndrome extraction routine.One could measure the syndrome by measuring multi-qubit Pauli operatordirectly on the code state, but for the distillation purposethe logical qubit is returned into a single qubit,in course of which the syndrome measurements can be done without further ancillas.

```qsharp
operation _ExtractLogicalQubitFromSteaneCode (code : Microsoft.Quantum.ErrorCorrection.LogicalRegister) : (Qubit, Int, Int)
```


## Input

### code : [LogicalRegister](xref:Microsoft.Quantum.ErrorCorrection.LogicalRegister)





## Output : ([Qubit](xref:microsoft.quantum.concepts.the-qubit),[Int](xref:microsoft.quantum.user-guide.language.types),[Int](xref:microsoft.quantum.user-guide.language.types))

The logical qubit and a pair of integers for $X$-syndrome and $Z$-syndrome.They represent the index of the code qubit on which a single $X$- or $Z$-errorwould have caused the measured syndrome.

## Remarks

Note that this operation is not marked as `internal`, as unit testsdirectly depend on this operation. As a future improvement, unit testsshould be refactored to depend only on public callables directly.> [!WARNING]> This routine is tailored> to a particular encoding circuit for Steane's 7 qubit code;> if the encoding circuit is modified then the syndrome outcome> might have to be interpreted differently.
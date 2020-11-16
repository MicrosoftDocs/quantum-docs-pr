---
uid: Microsoft.Quantum.ErrorCorrection.BitFlipCode
title: BitFlipCode function
ms.date: 11/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: BitFlipCode
qsharp.summary: >-
  Returns a QECC value representing the ⟦3, 1, 1⟧ bit flip code encoder and
  decoder with in-place syndrome measurement.
---

# BitFlipCode function

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns a QECC value representing the ⟦3, 1, 1⟧ bit flip code encoder anddecoder with in-place syndrome measurement.

```qsharp
function BitFlipCode () : Microsoft.Quantum.ErrorCorrection.QECC
```


## Output : [QECC](xref:Microsoft.Quantum.ErrorCorrection.QECC)

Returns an implementation of a quantum error correction code byspecifying a `QECC` type.
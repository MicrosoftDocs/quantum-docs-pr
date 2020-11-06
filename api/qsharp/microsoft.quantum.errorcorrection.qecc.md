---
uid: Microsoft.Quantum.ErrorCorrection.QECC
title: QECC user defined type
ms.date: 11/6/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: QECC
qsharp.summary: >-
  Represents an error-correcting code as defined by its encoder,
  decoder, and syndrome measurement procedure.
---

# QECC user defined type

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents an error-correcting code as defined by its encoder,decoder, and syndrome measurement procedure.

```qsharp

newtype QECC = (Microsoft.Quantum.ErrorCorrection.EncodeOp, Microsoft.Quantum.ErrorCorrection.DecodeOp, Microsoft.Quantum.ErrorCorrection.SyndromeMeasOp);
```


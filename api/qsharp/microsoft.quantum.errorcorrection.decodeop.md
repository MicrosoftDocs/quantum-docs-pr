---
uid: Microsoft.Quantum.ErrorCorrection.DecodeOp
title: DecodeOp user defined type
ms.date: 11/17/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: DecodeOp
qsharp.summary: >-
  Represents an operation which decodes an encoded register into a
  physical register and the scratch qubits used to record a syndrome.

  The argument to a DecodeOp is the same as the return from an
  EncodeOp, and vice versa.
---

# DecodeOp user defined type

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents an operation which decodes an encoded register into aphysical register and the scratch qubits used to record a syndrome.The argument to a DecodeOp is the same as the return from anEncodeOp, and vice versa.

```qsharp

newtype DecodeOp = ((Microsoft.Quantum.ErrorCorrection.LogicalRegister => (Qubit[], Qubit[])));
```


---
uid: Microsoft.Quantum.ErrorCorrection.ApplyBitFlipEncoder
title: ApplyBitFlipEncoder operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: ApplyBitFlipEncoder
qsharp.summary: >-
  Private operation used to implement both the bit flip encoder and decoder.

  Note that this encoder can make use of in-place coherent recovery,
  in which case it will "cause" the error described
  by the initial state of `auxQubits`.
  In particular, if `auxQubits` are initially in the state $\ket{10}$, this
  will cause an $X_1$ error on the encoded qubit.
---

# ApplyBitFlipEncoder operation

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [](https://nuget.org/packages/)


Private operation used to implement both the bit flip encoder and decoder.Note that this encoder can make use of in-place coherent recovery,in which case it will "cause" the error describedby the initial state of `auxQubits`.In particular, if `auxQubits` are initially in the state $\ket{10}$, thiswill cause an $X_1$ error on the encoded qubit.

```Q#
ApplyBitFlipEncoder (coherentRecovery : Bool, data : Qubit[], scratch : Qubit[]) : Unit
```


## References

- doi:10.1103/PhysRevA.85.044302
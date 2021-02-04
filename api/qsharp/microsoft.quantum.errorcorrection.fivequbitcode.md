---
uid: Microsoft.Quantum.ErrorCorrection.FiveQubitCode
title: FiveQubitCode function
ms.date: 2/4/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: FiveQubitCode
qsharp.summary: >-
  Returns a QECC value representing the ⟦5, 1, 3⟧ code encoder and
  decoder with in-place syndrome measurement.
---

# FiveQubitCode function

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns a QECC value representing the ⟦5, 1, 3⟧ code encoder anddecoder with in-place syndrome measurement.

```qsharp
function FiveQubitCode () : Microsoft.Quantum.ErrorCorrection.QECC
```


## Output : [QECC](xref:Microsoft.Quantum.ErrorCorrection.QECC)

Returns an implementation of a quantum error correction code byspecifying a `QECC` type.

## Remarks

This code was found independently in the following two papers:- C. H. Bennett, D. DiVincenzo, J. A. Smolin and W. K. Wootters, "Mixed state entanglement and quantum error correction," Phys. Rev. A, 54 (1996) pp. 3824-3851; https://arxiv.org/abs/quant-ph/9604024 and- R. Laflamme, C. Miquel, J. P. Paz and W. H. Zurek, "Perfect quantum error correction code," Phys. Rev. Lett. 77 (1996) pp. 198-201; https://arxiv.org/abs/quant-ph/9602019
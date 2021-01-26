---
uid: Microsoft.Quantum.ErrorCorrection.SteaneCode
title: SteaneCode function
ms.date: 1/26/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: SteaneCode
qsharp.summary: >-
  Returns a CSS value representing the ⟦7, 1, 3⟧ Steane code encoder and
  decoder with in-place syndrome measurement.
---

# SteaneCode function

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns a CSS value representing the ⟦7, 1, 3⟧ Steane code encoder anddecoder with in-place syndrome measurement.

```qsharp
function SteaneCode () : Microsoft.Quantum.ErrorCorrection.CSS
```


## Output : [CSS](xref:Microsoft.Quantum.ErrorCorrection.CSS)

An object of CSS type which collects all relevant data to perform encoding anderror correction for the ⟦7, 1, 3⟧ Steane code.

## Remarks

This code was found in the following paper:- A. Steane, "Multiple Particle Interference and Quantum Error Correction", Proc. Roy. Soc. Lond. A452 (1996) pp. 2551; https://arxiv.org/abs/quant-ph/9601029.
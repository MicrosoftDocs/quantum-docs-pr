---
uid: Microsoft.Quantum.ErrorCorrection.SteaneCodeEncoderImpl
title: SteaneCodeEncoderImpl operation
ms.date: 2/15/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: SteaneCodeEncoderImpl
qsharp.summary: Private operation used to implement both the Steane code encoder and decoder.
---

# SteaneCodeEncoderImpl operation

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Private operation used to implement both the Steane code encoder and decoder.

```qsharp
operation SteaneCodeEncoderImpl (data : Qubit[], scratch : Qubit[]) : Unit is Adj
```


## Input

### data : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

an array holding 1 qubit which is the input qubit.


### scratch : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

an array holding 6 qubits which add redundancy.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


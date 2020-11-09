---
uid: Microsoft.Quantum.Preparation.PrepareIdentity
title: PrepareIdentity operation
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: PrepareIdentity
qsharp.summary: >-
  Given a register, prepares that register in the maximally mixed state.

  The register is prepared in the $\boldone / 2^N$ state by applying the
  complete depolarizing
  channel to each qubit, where $N$ is the length of the register.
---

# PrepareIdentity operation

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [](https://nuget.org/packages/)


Given a register, prepares that register in the maximally mixed state.The register is prepared in the $\boldone / 2^N$ state by applying thecomplete depolarizingchannel to each qubit, where $N$ is the length of the register.

```qsharp
operation PrepareIdentity (register : Qubit[]) : Unit
```


## Input

### register : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A register whose state is to be depolarized in the mannerdescribed above.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Preparation.PrepareSingleQubitIdentity](xref:Microsoft.Quantum.Preparation.PrepareSingleQubitIdentity)
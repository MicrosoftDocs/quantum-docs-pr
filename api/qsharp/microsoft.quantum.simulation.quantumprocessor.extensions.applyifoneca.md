---
uid: Microsoft.Quantum.Simulation.QuantumProcessor.Extensions.ApplyIfOneCA
title: ApplyIfOneCA operation
ms.date: 10/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Simulation.QuantumProcessor.Extensions
qsharp.name: ApplyIfOneCA
qsharp.summary: ''
---

# ApplyIfOneCA operation

Namespace: [Microsoft.Quantum.Simulation.QuantumProcessor.Extensions](xref:Microsoft.Quantum.Simulation.QuantumProcessor.Extensions)

Package: [](https://nuget.org/packages/)




```qsharp
operation ApplyIfOneCA<'T> (measurementResult : Result, (onResultOneOp : ('T => Unit is Ctl + Adj), oneArg : 'T)) : Unit
```


## Input

### measurementResult : __invalid<Result>__




### onResultOneOp : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Ctl + Adj




### oneArg : 'T





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T


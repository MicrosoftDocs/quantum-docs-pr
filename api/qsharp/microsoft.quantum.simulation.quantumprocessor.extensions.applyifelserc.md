---
uid: Microsoft.Quantum.Simulation.QuantumProcessor.Extensions.ApplyIfElseRC
title: ApplyIfElseRC operation
ms.date: 11/4/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Simulation.QuantumProcessor.Extensions
qsharp.name: ApplyIfElseRC
qsharp.summary: ''
---

# ApplyIfElseRC operation

Namespace: [Microsoft.Quantum.Simulation.QuantumProcessor.Extensions](xref:Microsoft.Quantum.Simulation.QuantumProcessor.Extensions)

Package: [](https://nuget.org/packages/)




```qsharp
operation ApplyIfElseRC<'T, 'U> (measurementResult : Result, (onResultZeroOp : ('T => Unit is Ctl), zeroArg : 'T), (onResultOneOp : ('U => Unit is Ctl), oneArg : 'U)) : Unit
```


## Input

### measurementResult : __invalid<Result>__




### onResultZeroOp : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Ctl




### zeroArg : 'T




### onResultOneOp : 'U => [Unit](xref:microsoft.quantum.lang-ref.unit) Ctl




### oneArg : 'U





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T


### 'U


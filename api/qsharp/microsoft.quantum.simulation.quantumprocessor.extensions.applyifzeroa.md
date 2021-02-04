---
uid: Microsoft.Quantum.Simulation.QuantumProcessor.Extensions.ApplyIfZeroA
title: ApplyIfZeroA operation
ms.date: 2/4/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Simulation.QuantumProcessor.Extensions
qsharp.name: ApplyIfZeroA
qsharp.summary: ''
---

# ApplyIfZeroA operation

Namespace: [Microsoft.Quantum.Simulation.QuantumProcessor.Extensions](xref:Microsoft.Quantum.Simulation.QuantumProcessor.Extensions)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)




```qsharp
operation ApplyIfZeroA<'T> (measurementResult : Result, (onResultZeroOp : ('T => Unit is Adj), zeroArg : 'T)) : Unit is Adj
```


## Input

### measurementResult : __invalid<Result>__




### onResultZeroOp : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj




### zeroArg : 'T





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T


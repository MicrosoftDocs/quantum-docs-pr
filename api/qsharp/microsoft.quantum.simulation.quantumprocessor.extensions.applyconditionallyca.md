---
uid: Microsoft.Quantum.Simulation.QuantumProcessor.Extensions.ApplyConditionallyCA
title: ApplyConditionallyCA operation
ms.date: 2/5/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Simulation.QuantumProcessor.Extensions
qsharp.name: ApplyConditionallyCA
qsharp.summary: ''
---

# ApplyConditionallyCA operation

Namespace: [Microsoft.Quantum.Simulation.QuantumProcessor.Extensions](xref:Microsoft.Quantum.Simulation.QuantumProcessor.Extensions)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)




```qsharp
operation ApplyConditionallyCA<'T, 'U> (measurementResults : Result[], resultsValues : Result[], (onEqualOp : ('T => Unit is Ctl + Adj), equalArg : 'T), (onNonEqualOp : ('U => Unit is Ctl + Adj), nonEqualArg : 'U)) : Unit is Adj + Ctl
```


## Input

### measurementResults : __invalid<Result>__[]




### resultsValues : __invalid<Result>__[]




### onEqualOp : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl




### equalArg : 'T




### onNonEqualOp : 'U => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl




### nonEqualArg : 'U





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T


### 'U


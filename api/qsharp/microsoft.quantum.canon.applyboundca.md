---
uid: Microsoft.Quantum.Canon.ApplyBoundCA
title: ApplyBoundCA operation
ms.date: 12/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyBoundCA
qsharp.summary: ''
---

# ApplyBoundCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)




```qsharp
operation ApplyBoundCA<'T> (operations : ('T => Unit is Adj + Ctl)[], target : 'T) : Unit is Adj + Ctl
```


## Input

### operations : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl[]




### target : 'T





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T



## See Also

- [Microsoft.Quantum.Canon.BoundCA](xref:Microsoft.Quantum.Canon.BoundCA)
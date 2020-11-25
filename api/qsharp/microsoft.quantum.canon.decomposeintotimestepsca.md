---
uid: Microsoft.Quantum.Canon.DecomposeIntoTimeStepsCA
title: DecomposeIntoTimeStepsCA function
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: DecomposeIntoTimeStepsCA
qsharp.summary: >+
  > [!WARNING]

  > DecomposeIntoTimeStepsCA has been deprecated. Please use <xref:Microsoft.Quantum.Canon.DecomposedIntoTimeStepsCA> instead.

---

# DecomposeIntoTimeStepsCA function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


> [!WARNING]
> DecomposeIntoTimeStepsCA has been deprecated. Please use <xref:Microsoft.Quantum.Canon.DecomposedIntoTimeStepsCA> instead.



```qsharp
function DecomposeIntoTimeStepsCA<'T> ((nSteps : Int, op : ((Int, Double, 'T) => Unit is Adj + Ctl)), trotterOrder : Int) : ((Double, 'T) => Unit is Adj + Ctl)
```


## Input

### nSteps : [Int](xref:microsoft.quantum.user-guide.language.types)




### op : ([Int](xref:microsoft.quantum.user-guide.language.types),[Double](xref:microsoft.quantum.user-guide.language.types),'T) => [Unit](xref:microsoft.quantum.user-guide.language.types)  is Adj + Ctl




### trotterOrder : [Int](xref:microsoft.quantum.user-guide.language.types)





## Output : ([Double](xref:microsoft.quantum.user-guide.language.types),'T) => [Unit](xref:microsoft.quantum.user-guide.language.types)  is Adj + Ctl



## Type Parameters

### 'T


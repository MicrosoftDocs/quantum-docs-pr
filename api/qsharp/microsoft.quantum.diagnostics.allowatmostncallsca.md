---
uid: Microsoft.Quantum.Diagnostics.AllowAtMostNCallsCA
title: AllowAtMostNCallsCA operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: AllowAtMostNCallsCA
qsharp.summary: >-
  Between a call to this operation and its adjoint, asserts that
  a given operation is called at most a certain number of times.
---

# AllowAtMostNCallsCA operation

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Between a call to this operation and its adjoint, asserts thata given operation is called at most a certain number of times.

```qsharp
operation AllowAtMostNCallsCA<'TInput, 'TOutput> (nTimes : Int, op : ('TInput => 'TOutput is Adj + Ctl), message : String) : Unit is Adj
```


## Input

### nTimes : [Int](xref:microsoft.quantum.user-guide.language.types)

The maximum number of times that `op` may be called.


### op : 'TInput => 'TOutput  is Adj + Ctl

An operation whose calls are to be restricted.


### message : [String](xref:microsoft.quantum.user-guide.language.types)

A message to be displayed upon failure.



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## Type Parameters

### 'TInput


### 'TOutput



## Remarks

This operation may be replaced by a no-op on targets which do notsupport it.
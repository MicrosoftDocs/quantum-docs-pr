---
uid: Microsoft.Quantum.Diagnostics.AllowAtMostNCallsCA
title: AllowAtMostNCallsCA operation
ms.date: 2/14/2021 12:00:00 AM
ms.topic: managed-reference
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

### nTimes : [Int](xref:microsoft.quantum.lang-ref.int)

The maximum number of times that `op` may be called.


### op : 'TInput => 'TOutput  is Adj + Ctl

An operation whose calls are to be restricted.


### message : [String](xref:microsoft.quantum.lang-ref.string)

A message to be displayed upon failure.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'TInput


### 'TOutput



## Example

The following snippet will fail when executed on machines whichsupport this diagnostic:```qsharpusing (register = Qubit[4]) {    within {        AllowAtMostNCallsCA(3, H, "Too many calls to H.");    } apply {        // Fails since this calls H four times, rather than the        // allowed maximum of three.        ApplyToEach(H, register);    }}```

## Remarks

This operation may be replaced by a no-op on targets which do notsupport it.
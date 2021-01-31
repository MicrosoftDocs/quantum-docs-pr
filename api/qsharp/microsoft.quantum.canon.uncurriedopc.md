---
uid: Microsoft.Quantum.Canon.UncurriedOpC
title: UncurriedOpC function
ms.date: 1/31/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: UncurriedOpC
qsharp.summary: >-
  Given a function which returns operations,
  returns a new operation which takes both inputs
  as a tuple.
  The modifier `C` indicates that the operations are controllable.
---

# UncurriedOpC function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given a function which returns operations,returns a new operation which takes both inputsas a tuple.The modifier `C` indicates that the operations are controllable.

```qsharp
function UncurriedOpC<'T, 'U> (curriedOp : ('T -> ('U => Unit is Ctl))) : (('T, 'U) => Unit is Ctl)
```


## Input

### curriedOp : 'T -> 'U => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Ctl

A function which returns operations.



## Output : ('T,'U) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Ctl

A new operation `op` such that `op(t, u)` is equivalentto `(curriedOp(t))(u)`.

## Type Parameters

### 'T

The type of the first argument of a curried function.
### 'U

The type of the second argument of a curried function.

## See Also

- [Microsoft.Quantum.Canon.UncurriedOp](xref:Microsoft.Quantum.Canon.UncurriedOp)
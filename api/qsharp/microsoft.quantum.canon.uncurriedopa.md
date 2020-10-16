---
uid: Microsoft.Quantum.Canon.UncurriedOpA
title: UncurriedOpA function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: UncurriedOpA
qsharp.summary: >-
  Given a function which returns operations,
  returns a new operation which takes both inputs
  as a tuple.
  The modifier `A` indicates that the operations are adjointable.
---

# UncurriedOpA function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Given a function which returns operations,returns a new operation which takes both inputsas a tuple.The modifier `A` indicates that the operations are adjointable.

```Q#
UncurriedOpA<'T, 'U> (curriedOp : ('T -> ('U => Unit is Adj))) : (('T, 'U) => Unit is Adj)
```


## Input

### curriedOp : 'T -> 'U => Unit Adj

A function which returns operations.



## Output

A new operation `op` such that `op(t, u)` is equivalentto `(curriedOp(t))(u)`.

## Type Parameters

### 'T

The type of the first argument of a curried function.


### 'U

The type of the second argument of a curried function.



## See Also

- [microsoft.quantum.canon.uncurryop](xref:microsoft.quantum.canon.uncurryop)
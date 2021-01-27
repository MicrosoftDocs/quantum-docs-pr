---
uid: Microsoft.Quantum.Canon.Fst
title: Fst function
ms.date: 1/27/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: Fst
qsharp.summary: Given a pair, returns its first element.
---

# Fst function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given a pair, returns its first element.

```qsharp
function Fst<'T, 'U> (pair : ('T, 'U)) : 'T
```


## Input

### pair : ('T,'U)

A tuple with two elements.



## Output : 'T

The first element of `pair`.

## Type Parameters

### 'T

The type of the pair's first member.
### 'U

The type of the pair's second member.
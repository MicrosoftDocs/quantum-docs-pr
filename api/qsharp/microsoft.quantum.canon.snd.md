---
uid: Microsoft.Quantum.Canon.Snd
title: Snd function
ms.date: 12/4/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: Snd
qsharp.summary: Given a pair, returns its second element.
---

# Snd function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given a pair, returns its second element.

```qsharp
function Snd<'T, 'U> (pair : ('T, 'U)) : 'U
```


## Input

### pair : ('T,'U)

A tuple with two elements.



## Output : 'U

The second element of `pair`.

## Type Parameters

### 'T

The type of the pair's first member.
### 'U

The type of the pair's second member.
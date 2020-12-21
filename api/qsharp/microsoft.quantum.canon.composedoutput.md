---
uid: Microsoft.Quantum.Canon.ComposedOutput
title: ComposedOutput function
ms.date: 12/21/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ComposedOutput
qsharp.summary: >-
  Returns the output of the composition of `inner` and `outer`
  for a given input.
---

# ComposedOutput function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns the output of the composition of `inner` and `outer`for a given input.

```qsharp
function ComposedOutput<'T, 'U, 'V> (outer : ('U -> 'V), inner : ('T -> 'U), target : 'T) : 'V
```


## Input

### outer : 'U -> 'V




### inner : 'T -> 'U




### target : 'T





## Output : 'V



## Type Parameters

### 'T


### 'U


### 'V


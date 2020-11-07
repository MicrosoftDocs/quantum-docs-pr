---
uid: Microsoft.Quantum.Canon.CurriedOp
title: CurriedOp function
ms.date: 11/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: CurriedOp
qsharp.summary: >-
  Returns a curried version of an operation on two inputs.

  That is, given an operation with two inputs, this function applies Curry's isomorphism
  $f(x, y) \equiv f(x)(y)$ to return an operation of one input which
  returns an operation of one input.
---

# CurriedOp function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Returns a curried version of an operation on two inputs.That is, given an operation with two inputs, this function applies Curry's isomorphism$f(x, y) \equiv f(x)(y)$ to return an operation of one input whichreturns an operation of one input.

```qsharp
function CurriedOp<'T, 'U> (op : (('T, 'U) => Unit)) : ('T -> ('U => Unit))
```


## Input

### op : ('T,'U) => [Unit](xref:microsoft.quantum.lang-ref.unit) 

An operation whose input is a pair.



## Output : 'T -> 'U => [Unit](xref:microsoft.quantum.lang-ref.unit) 

An operation which accepts the first element of a pair and returnsan operation which accepts as its input the second element of theoriginal operation's input.

## Type Parameters

### 'T

The type of the first component of a function defined on pairs.
### 'U

The type of the second component of a function defined on pairs.

## Remarks

The following are equivalent:```qsharpop(x, y);let curried = CurriedOp(op);let partial = curried(x);partial(y);```
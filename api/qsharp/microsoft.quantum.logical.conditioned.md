---
uid: Microsoft.Quantum.Logical.Conditioned
title: Conditioned function
ms.date: 10/29/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: Conditioned
qsharp.summary: Returns one of two values, depending on the value of a Boolean condition.
---

# Conditioned function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns one of two values, depending on the value of a Boolean condition.

```qsharp
function Conditioned<'T> (condition : Bool, ifTrue : 'T, ifFalse : 'T) : 'T
```


## Input

### condition : [Bool](xref:microsoft.quantum.lang-ref.bool)

A condition used to control which input is returned.


### ifTrue : 'T

The value to be returned when `condition` is `true`.


### ifFalse : 'T

The value to be returned when `condition` is `false`.



## Output : 'T

`ifTrue` if `condition` is `true`, and `ifFalse` otherwise.

## Type Parameters

### 'T



## Remarks

Unlike the `?|` operator, this function does not short-circuit, such thatboth inputs are fully evaluated.Up to short-circuiting behavior, the following are equivalent:```Q#let x = condition ? ifTrue | ifFalse;let x = Conditioned(condition, ifTrue, ifFalse);```
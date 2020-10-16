---
uid: Microsoft.Quantum.Canon.ControlledOnInt
title: ControlledOnInt function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ControlledOnInt
qsharp.summary: >-
  Returns a unitary operator that applies an oracle on the target register
  if the control register state corresponds to a specified positive integer.
---

# ControlledOnInt function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Returns a unitary operator that applies an oracle on the target registerif the control register state corresponds to a specified positive integer.

```Q#
ControlledOnInt<'T> (numberState : Int, oracle : ('T => Unit is Adj + Ctl)) : ((Qubit[], 'T) => Unit is Adj + Ctl)
```


## Input

### numberState : Int

Positive integer.


### oracle : 'T => Unit Adj + Ctl

Unitary operator.



## Output

A unitary operator that applies `oracle` on the target register if thecontrol register state corresponds to the number state `numberState`.

## Remarks

The value of `numberState` is interpreted using a little-endian encoding.
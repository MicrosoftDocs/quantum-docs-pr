---
uid: Microsoft.Quantum.Canon.ControlledOnInt
title: ControlledOnInt function
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ControlledOnInt
qsharp.summary: >-
  Returns a unitary operator that applies an oracle on the target register
  if the control register state corresponds to a specified positive integer.
---

# ControlledOnInt function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns a unitary operator that applies an oracle on the target registerif the control register state corresponds to a specified positive integer.

```qsharp
function ControlledOnInt<'T> (numberState : Int, oracle : ('T => Unit is Adj + Ctl)) : ((Qubit[], 'T) => Unit is Adj + Ctl)
```


## Input

### numberState : [Int](xref:microsoft.quantum.lang-ref.int)

Positive integer.


### oracle : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

Unitary operator.



## Output : ([Qubit](xref:microsoft.quantum.lang-ref.qubit)[],'T) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

A unitary operator that applies `oracle` on the target register if thecontrol register state corresponds to the number state `numberState`.

## Type Parameters

### 'T



## Remarks

The value of `numberState` is interpreted using a little-endian encoding.
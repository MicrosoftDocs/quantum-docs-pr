---
uid: Microsoft.Quantum.Canon.ApplyControlledOnInt
title: ApplyControlledOnInt operation
ms.date: 10/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyControlledOnInt
qsharp.summary: >-
  Applies a unitary operation on the target register if the control
  register state corresponds to a specified positive integer.
---

# ApplyControlledOnInt operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a unitary operation on the target register if the controlregister state corresponds to a specified positive integer.

```qsharp
operation ApplyControlledOnInt<'T> (numberState : Int, oracle : ('T => Unit is Adj + Ctl), controlRegister : Qubit[], targetRegister : 'T) : Unit
```


## Input

### numberState : [Int](xref:microsoft.quantum.lang-ref.int)

A nonnegative integer on which the operation `oracle` should becontrolled.


### oracle : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl

A unitary operation to be controlled.


### controlRegister : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A quantum register that controls application of `oracle`.


### targetRegister : 'T

A register on which to apply `oracle`.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T



## Remarks

The value of `numberState` is interpreted using a little-endian encoding.`numberState` must be at most $2^\texttt{Length(controlRegister)} - 1$.For example, `numberState = 537` means that `oracle`is applied if and only if `controlRegister` is in the state $\ket{537}$.
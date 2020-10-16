---
uid: Microsoft.Quantum.Canon.ApplyControlledOnBitString
title: ApplyControlledOnBitString operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyControlledOnBitString
qsharp.summary: >-
  Applies a unitary operation on the target register, controlled on a a state specified by a given
  bit mask.
---

# ApplyControlledOnBitString operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a unitary operation on the target register, controlled on a a state specified by a givenbit mask.

```Q#
ApplyControlledOnBitString<'T> (bits : Bool[], oracle : ('T => Unit is Adj + Ctl), controlRegister : Qubit[], targetRegister : 'T) : Unit
```


## Input

### bits : Bool[]

The bit string to control the given unitary operation on.


### oracle : 'T => Unit Adj + Ctl

The unitary operation to be applied on the target register.


### targetRegister : 'T

The target register to be passed to `oracle` as an input.


### controlRegister : Qubit[]

A quantum register that controls application of `oracle`.



## Remarks

The pattern given by `bits` may be shorter than `controlRegister`,in which case additional control qubits are ignored (that is, neithercontrolled on $\ket{0}$ nor $\ket{1}$).If `bits` is longer than `controlRegister`, an error is raised.For example, `bits = [0,1,0,0,1]` means that `oracle` is applied if and only if `controlRegister`is in the state $\ket{0}\ket{1}\ket{0}\ket{0}\ket{1}$.
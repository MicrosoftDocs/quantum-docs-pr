---
uid: Microsoft.Quantum.Canon.ControlledOnBitString
title: ControlledOnBitString function
ms.date: 11/3/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ControlledOnBitString
qsharp.summary: Returns a unitary operation that applies an oracle on the target register if the control register state corresponds to a specified bit mask.
---

# ControlledOnBitString function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Returns a unitary operation that applies an oracle on the target register if the control register state corresponds to a specified bit mask.

```qsharp
function ControlledOnBitString<'T> (bits : Bool[], oracle : ('T => Unit is Adj + Ctl)) : ((Qubit[], 'T) => Unit is Adj + Ctl)
```


## Description

The output of this function is an operation that can be represented by aunitary transformation $U$ such that\begin{align}U \ket{b_0 b_1 \cdots b_{n - 1}} \ket{\psi} = \ket{b_0 b_1 \cdots b_{n-1}} \otimes\begin{cases}V \ket{\psi} & \textrm{if} (b_0 b_1 \cdots b_{n - 1}) = \texttt{bits} \\\\\ket{\psi} & \textrm{otherwise}\end{cases},\end{align}where $V$ is a unitary transformation that represents the action of the`oracle` operation.

## Input

### bits : [Bool](xref:microsoft.quantum.lang-ref.bool)[]

The bit string to control the given unitary operation on.


### oracle : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl

The unitary operation to be applied on the target register.



## Output : ([Qubit](xref:microsoft.quantum.lang-ref.qubit)[],'T) => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl

A unitary operation that applies `oracle` on the target register if the control register state corresponds to the bit mask `bits`.

## Type Parameters

### 'T



## Remarks

The pattern given by `bits` may be shorter than `controlRegister`,in which case additional control qubits are ignored (that is, neithercontrolled on $\ket{0}$ nor $\ket{1}$).If `bits` is longer than `controlRegister`, an error is raised.Given a Boolean array `bits` and a unitary operation `oracle`, the output of this functionis an operation that performs the following steps:* apply an `X` operation to each qubit of the control register that corresponds to `false` element of the `bits`;* apply `Controlled oracle` to the control and target registers;* apply an `X` operation to each qubit of the control register that corresponds to `false` element of the `bits` again to return the control register to the original state.The output of the `Controlled` functor is a special case of `ControlledOnBitString` where `bits` is equal to `[true, ..., true]`.
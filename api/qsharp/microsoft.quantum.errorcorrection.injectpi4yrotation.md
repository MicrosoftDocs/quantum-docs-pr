---
uid: Microsoft.Quantum.ErrorCorrection.InjectPi4YRotation
title: InjectPi4YRotation operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: InjectPi4YRotation
qsharp.summary: Rotates a single qubit by π/4 about the Y-axis.
---

# InjectPi4YRotation operation

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [](https://nuget.org/packages/)


Rotates a single qubit by π/4 about the Y-axis.

```Q#
InjectPi4YRotation (data : Qubit, magic : Qubit) : Unit
```


## Description

Performs a π/4 rotation about `Y`.The rotation is performed by consuming a magicstate; that is, a copy of the state$$\begin{align}\cos\frac{\pi}{8} \ket{0} + \sin \frac{\pi}{8} \ket{1}.\end{align}$$

## Input

### data : Qubit

A qubit to be rotated about $Y$ by $\pi / 4$.


### magic : Qubit

A qubit initially in the magic state. Following applicationof this operation, `magic` is returned to the $\ket{0}$ state.



## Remarks

The following are equivalent:```qsharpRy(PI() / 4.0, data);```and```qsharpusing (magic = Qubit()) {    Ry(PI() / 4.0, magic);    InjectPi4YRotation(data, magic);    Reset(magic);}```This operation supports the `Adjoint` functor, in whichcase the same magic state is consumed, but the effecton the data qubit is a $-\pi/4$ $Y$-rotation.
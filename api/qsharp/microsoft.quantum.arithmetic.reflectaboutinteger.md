---
uid: Microsoft.Quantum.Arithmetic.ReflectAboutInteger
title: ReflectAboutInteger operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: ReflectAboutInteger
qsharp.summary: Reflects a quantum register about a given classical integer.
---

# ReflectAboutInteger operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Reflects a quantum register about a given classical integer.

```Q#
ReflectAboutInteger (index : Int, reg : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit
```


## Description

Given a quantum register initially in the state $\sum_i \alpha_i \ket{i}$,where each $\ket{i}$ is a basis state representing an integer $i$,reflects the state of the register about the basis state for a giveninteger $\ket{j}$,$$\sum_i (-1)^{ \delta_{ij} } \alpha_i \ket{i}$$

## Input

### index : Int

The classical integer indexing the basis state about which to reflect.



## Remarks

This operation is implemented in-place, without explicit allocation ofadditional auxiliary qubits.
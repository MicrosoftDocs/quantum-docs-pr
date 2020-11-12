---
uid: Microsoft.Quantum.Arithmetic.ReflectAboutInteger
title: ReflectAboutInteger operation
ms.date: 11/12/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: ReflectAboutInteger
qsharp.summary: Reflects a quantum register about a given classical integer.
---

# ReflectAboutInteger operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Reflects a quantum register about a given classical integer.

```qsharp
operation ReflectAboutInteger (index : Int, reg : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit is Adj + Ctl
```


## Description

Given a quantum register initially in the state $\sum_i \alpha_i \ket{i}$,where each $\ket{i}$ is a basis state representing an integer $i$,reflects the state of the register about the basis state for a giveninteger $\ket{j}$,$$\sum_i (-1)^{ \delta_{ij} } \alpha_i \ket{i}$$

## Input

### index : [Int](xref:microsoft.quantum.lang-ref.int)

The classical integer indexing the basis state about which to reflect.


### reg : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

This operation is implemented in-place, without explicit allocation ofadditional auxiliary qubits.
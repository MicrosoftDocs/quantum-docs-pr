---
uid: Microsoft.Quantum.Simulation.BlockEncodingByLCU
title: BlockEncodingByLCU function
ms.date: 12/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: BlockEncodingByLCU
qsharp.summary: >-
  Encodes an operator of interest into a `BlockEncoding`.

  This constructs a `BlockEncoding` unitary $U=P\cdot V\cdot P^\dagger$ that encodes some
  operator $H=\sum_{j}|\alpha_j|U_j$ of interest that is a linear combination of
  unitaries. Typically, $P$ is a state preparation unitary such that
  $P\ket{0}\_a=\sum_j\sqrt{\alpha_j/\|\vec\alpha\|\_2}\ket{j}\_a$,
  and $V=\sum_{j}\ket{j}\bra{j}\_a\otimes U_j$.
---

# BlockEncodingByLCU function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Encodes an operator of interest into a `BlockEncoding`.This constructs a `BlockEncoding` unitary $U=P\cdot V\cdot P^\dagger$ that encodes someoperator $H=\sum_{j}|\alpha_j|U_j$ of interest that is a linear combination ofunitaries. Typically, $P$ is a state preparation unitary such that$P\ket{0}\_a=\sum_j\sqrt{\alpha_j/\|\vec\alpha\|\_2}\ket{j}\_a$,and $V=\sum_{j}\ket{j}\bra{j}\_a\otimes U_j$.

```qsharp
function BlockEncodingByLCU<'T, 'S> (statePreparation : ('T => Unit is Adj + Ctl), selector : (('T, 'S) => Unit is Adj + Ctl)) : (('T, 'S) => Unit is Adj + Ctl)
```


## Input

### statePreparation : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

A unitary $P$ that prepares some target state.


### selector : ('T,'S) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

A unitary $V$ that encodes the component unitaries of $H$.



## Output : ('T,'S) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

A unitary $U$ acting jointly on registers `a` and `s` that block-encodes $H$, and satisfies $U^\dagger = U$.

## Type Parameters

### 'T


### 'S



## Remarks

This `BlockEncoding` implementation gives it the properties of a`BlockEncodingReflection`.

## See Also

- [Microsoft.Quantum.Simulation.BlockEncoding](xref:Microsoft.Quantum.Simulation.BlockEncoding)
- [Microsoft.Quantum.Simulation.BlockEncodingReflection](xref:Microsoft.Quantum.Simulation.BlockEncodingReflection)
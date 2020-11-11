---
uid: Microsoft.Quantum.Canon.ApplyIfElseBA
title: ApplyIfElseBA operation
ms.date: 11/11/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyIfElseBA
qsharp.summary: >-
  Applies one of two adjointable operations, depending on the value of a
  classical bit.
---

# ApplyIfElseBA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies one of two adjointable operations, depending on the value of aclassical bit.

```qsharp
operation ApplyIfElseBA<'T, 'U> (bit : Bool, (trueOp : ('T => Unit is Adj), trueInput : 'T), (falseOp : ('U => Unit is Adj), falseInput : 'U)) : Unit is Adj
```


## Description

Given a bit `bit`, applies the operation `trueOp` with `trueInput` asits input when `bit` is `true`, and applies `falseOp(falseInput)`when `bit` is `false`.

## Input

### bit : [Bool](xref:microsoft.quantum.lang-ref.bool)

The boolean value used to determine whether `trueOp` or `falseOp` isapplied.


### trueOp : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj

The adjointable operation to be applied when `bit` is `true`.


### trueInput : 'T

The input to be provided to `trueOp` when `bit` is `true`.


### falseOp : 'U => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj

The adjointable operation to be applied when `bit` is `false`.


### falseInput : 'U

The input to be provided to `falseOp` when `bit` is `false`.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The input type of the operation `trueOp` to be conditionally applied.
### 'U

The input type of the operation `falseOp` to be conditionally applied.

## See Also

- [Microsoft.Quantum.Canon.ApplyIfZero](xref:Microsoft.Quantum.Canon.ApplyIfZero)
- [Microsoft.Quantum.Canon.ApplyIfOne](xref:Microsoft.Quantum.Canon.ApplyIfOne)
- [Microsoft.Quantum.Canon.ApplyIfElseRC](xref:Microsoft.Quantum.Canon.ApplyIfElseRC)
- [Microsoft.Quantum.Canon.ApplyIfElseRA](xref:Microsoft.Quantum.Canon.ApplyIfElseRA)
- [Microsoft.Quantum.Canon.ApplyIfElseRCA](xref:Microsoft.Quantum.Canon.ApplyIfElseRCA)
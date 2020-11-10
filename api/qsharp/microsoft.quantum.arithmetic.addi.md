---
uid: Microsoft.Quantum.Arithmetic.AddI
title: AddI operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: AddI
qsharp.summary: >-
  Automatically chooses between addition with
  carry and without, depending on the register size of `ys`.
---

# AddI operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Automatically chooses between addition withcarry and without, depending on the register size of `ys`.

```qsharp
operation AddI (xs : Microsoft.Quantum.Arithmetic.LittleEndian, ys : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit
```


## Input

### xs : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

$n$-bit addend.


### ys : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

Addend with at least $n$ qubits. Will hold the result.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


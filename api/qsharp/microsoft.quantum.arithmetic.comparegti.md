---
uid: Microsoft.Quantum.Arithmetic.CompareGTI
title: CompareGTI operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: CompareGTI
qsharp.summary: 'Wrapper for integer comparison: `result = x > y`.'
---

# CompareGTI operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Wrapper for integer comparison: `result = x > y`.

```qsharp
operation CompareGTI (xs : Microsoft.Quantum.Arithmetic.LittleEndian, ys : Microsoft.Quantum.Arithmetic.LittleEndian, result : Qubit) : Unit
```


## Input

### xs : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

First $n$-bit number


### ys : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

Second $n$-bit number


### result : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Will be flipped if $x > y$



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


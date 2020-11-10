---
uid: Microsoft.Quantum.Arithmetic.CompareGTSI
title: CompareGTSI operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: CompareGTSI
qsharp.summary: 'Wrapper for signed integer comparison: `result = xs > ys`.'
---

# CompareGTSI operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Wrapper for signed integer comparison: `result = xs > ys`.

```qsharp
operation CompareGTSI (xs : Microsoft.Quantum.Arithmetic.SignedLittleEndian, ys : Microsoft.Quantum.Arithmetic.SignedLittleEndian, result : Qubit) : Unit
```


## Input

### xs : [SignedLittleEndian](xref:Microsoft.Quantum.Arithmetic.SignedLittleEndian)

First $n$-bit number


### ys : [SignedLittleEndian](xref:Microsoft.Quantum.Arithmetic.SignedLittleEndian)

Second $n$-bit number


### result : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Will be flipped if $xs > ys$



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


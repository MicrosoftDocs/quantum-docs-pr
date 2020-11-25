---
uid: Microsoft.Quantum.Math.InverseModL
title: InverseModL function
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: InverseModL
qsharp.summary: Returns $b$ such that $a \cdot b = 1 (\operatorname{mod} \texttt{modulus})$.
---

# InverseModL function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns $b$ such that $a \cdot b = 1 (\operatorname{mod} \texttt{modulus})$.

```qsharp
function InverseModL (a : BigInt, modulus : BigInt) : BigInt
```


## Input

### a : [BigInt](xref:microsoft.quantum.user-guide.language.types)

The number being inverted


### modulus : [BigInt](xref:microsoft.quantum.user-guide.language.types)

The modulus according to which the numbers are inverted



## Output : [BigInt](xref:microsoft.quantum.user-guide.language.types)

Integer $b$ such that $a \cdot b = 1 (\operatorname{mod} \texttt{modulus})$.
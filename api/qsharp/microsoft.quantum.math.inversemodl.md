---
uid: Microsoft.Quantum.Math.InverseModL
title: InverseModL function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: InverseModL
qsharp.summary: Returns $b$ such that $a \cdot b = 1 (\operatorname{mod} \texttt{modulus})$.
---

# InverseModL function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [](https://nuget.org/packages/)


Returns $b$ such that $a \cdot b = 1 (\operatorname{mod} \texttt{modulus})$.

```Q#
InverseModL (a : BigInt, modulus : BigInt) : BigInt
```


## Input

### a : BigInt

The number being inverted


### modulus : BigInt

The modulus according to which the numbers are inverted



## Output

Integer $b$ such that $a \cdot b = 1 (\operatorname{mod} \texttt{modulus})$.
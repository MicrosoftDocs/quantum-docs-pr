---
uid: Microsoft.Quantum.Math.InverseModI
title: InverseModI function
ms.date: 12/17/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: InverseModI
qsharp.summary: Returns $b$ such that $a \cdot b = 1 (\operatorname{mod} \texttt{modulus})$.
---

# InverseModI function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns $b$ such that $a \cdot b = 1 (\operatorname{mod} \texttt{modulus})$.

```qsharp
function InverseModI (a : Int, modulus : Int) : Int
```


## Input

### a : [Int](xref:microsoft.quantum.lang-ref.int)

The number being inverted


### modulus : [Int](xref:microsoft.quantum.lang-ref.int)

The modulus according to which the numbers are inverted



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

Integer $b$ such that $a \cdot b = 1 (\operatorname{mod} \texttt{modulus})$.
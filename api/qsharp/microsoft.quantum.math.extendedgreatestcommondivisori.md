---
uid: Microsoft.Quantum.Math.ExtendedGreatestCommonDivisorI
title: ExtendedGreatestCommonDivisorI function
ms.date: 10/31/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: ExtendedGreatestCommonDivisorI
qsharp.summary: >-
  Computes a tuple $(u,v)$ such that $u \cdot a + v \cdot b = \operatorname{GCD}(a, b)$,
  where $\operatorname{GCD}$ is $a$
  greatest common divisor of $a$ and $b$. The GCD is always positive.
---

# ExtendedGreatestCommonDivisorI function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [](https://nuget.org/packages/)


Computes a tuple $(u,v)$ such that $u \cdot a + v \cdot b = \operatorname{GCD}(a, b)$,where $\operatorname{GCD}$ is $a$greatest common divisor of $a$ and $b$. The GCD is always positive.

```qsharp
function ExtendedGreatestCommonDivisorI (a : Int, b : Int) : (Int, Int)
```


## Input

### a : [Int](xref:microsoft.quantum.lang-ref.int)

the first number of which extended greatest common divisor is being computed


### b : [Int](xref:microsoft.quantum.lang-ref.int)

the second number of which extended greatest common divisor is being computed



## Output : ([Int](xref:microsoft.quantum.lang-ref.int),[Int](xref:microsoft.quantum.lang-ref.int))

Tuple $(u,v)$ with the property $u \cdot a + v \cdot b = \operatorname{GCD}(a, b)$.

## References

- This implementation is according to https://en.wikipedia.org/wiki/Extended_Euclidean_algorithm
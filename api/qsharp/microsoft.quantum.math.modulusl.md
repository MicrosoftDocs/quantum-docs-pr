---
uid: Microsoft.Quantum.Math.ModulusL
title: ModulusL function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: ModulusL
qsharp.summary: Computes the canonical residue of `value` modulo `modulus`.
---

# ModulusL function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [](https://nuget.org/packages/)


Computes the canonical residue of `value` modulo `modulus`.

```Q#
ModulusL (value : BigInt, modulus : BigInt) : BigInt
```


## Input

### value : BigInt

The value of which residue is computed


### modulus : BigInt

The modulus by which residues are take, must be positive



## Output

Integer $r$ between 0 and `modulus - 1` such that `value - r` is divisible by modulus

## Remarks

This function behaves different to how the operator `%` behaves in C# and Q# as in the resultis always a positive integer between 0 and `modulus - 1`, even if value is negative.
---
uid: Microsoft.Quantum.Math.ModulusL
title: ModulusL function
ms.date: 2/5/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: ModulusL
qsharp.summary: Computes the canonical residue of `value` modulo `modulus`.
---

# ModulusL function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Computes the canonical residue of `value` modulo `modulus`.

```qsharp
function ModulusL (value : BigInt, modulus : BigInt) : BigInt
```


## Input

### value : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The value of which residue is computed


### modulus : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The modulus by which residues are take, must be positive



## Output : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

Integer $r$ between 0 and `modulus - 1` such that `value - r` is divisible by modulus

## Remarks

This function behaves different to how the operator `%` behaves in C# and Q# as in the resultis always a non-negative integer between 0 and `modulus - 1`, even if value is negative.
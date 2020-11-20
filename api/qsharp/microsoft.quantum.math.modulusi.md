---
uid: Microsoft.Quantum.Math.ModulusI
title: ModulusI function
ms.date: 11/20/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: ModulusI
qsharp.summary: Computes the canonical residue of `value` modulo `modulus`.
---

# ModulusI function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Computes the canonical residue of `value` modulo `modulus`.

```qsharp
function ModulusI (value : Int, modulus : Int) : Int
```


## Input

### value : [Int](xref:microsoft.quantum.lang-ref.int)

The value of which residue is computed


### modulus : [Int](xref:microsoft.quantum.lang-ref.int)

The modulus by which residues are take, must be positive



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

Integer $r$ between 0 and `modulus - 1` such that `value - r` is divisible by modulus

## Remarks

This function behaves different to how the operator `%` behaves in C# and Q# as in the resultis always a positive integer between 0 and `modulus - 1`, even if value is negative.
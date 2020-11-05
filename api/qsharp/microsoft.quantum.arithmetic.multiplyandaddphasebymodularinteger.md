---
uid: Microsoft.Quantum.Arithmetic.MultiplyAndAddPhaseByModularInteger
title: MultiplyAndAddPhaseByModularInteger operation
ms.date: 11/5/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: MultiplyAndAddPhaseByModularInteger
qsharp.summary: >-
  The same as MultiplyAndAddByModularInteger, but assumes that the summand encodes
  integers in QFT basis.
---

# MultiplyAndAddPhaseByModularInteger operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


The same as MultiplyAndAddByModularInteger, but assumes that the summand encodesintegers in QFT basis.

```qsharp
operation MultiplyAndAddPhaseByModularInteger (constMultiplier : Int, modulus : Int, multiplier : Microsoft.Quantum.Arithmetic.LittleEndian, phaseSummand : Microsoft.Quantum.Arithmetic.PhaseLittleEndian) : Unit
```


## Input

### constMultiplier : [Int](xref:microsoft.quantum.lang-ref.int)

An integer $a$ to be added to each basis state label.


### modulus : [Int](xref:microsoft.quantum.lang-ref.int)

The modulus $N$ which addition and multiplication is taken with respect to.


### multiplier : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

A quantum register representing an unsigned integer whose value is tobe added to each basis state label of `summand`.


### phaseSummand : [PhaseLittleEndian](xref:Microsoft.Quantum.Arithmetic.PhaseLittleEndian)

A quantum register representing an unsigned integer to use as the targetfor this operation.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Assumes that `phaseSummand` has the highest bit set to 0.Also assumes that the value of `phaseSummand` is less than $N$.

## See Also

- [Microsoft.Quantum.Arithmetic.MultiplyAndAddByModularInteger](xref:Microsoft.Quantum.Arithmetic.MultiplyAndAddByModularInteger)
---
uid: Microsoft.Quantum.Arithmetic.AssertMostSignificantBit
title: AssertMostSignificantBit operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: AssertMostSignificantBit
qsharp.summary: >-
  Asserts that the most significant qubit of a qubit register
  representing an unsigned integer is in a particular state.
---

# AssertMostSignificantBit operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Asserts that the most significant qubit of a qubit registerrepresenting an unsigned integer is in a particular state.

```qsharp
operation AssertMostSignificantBit (value : Result, number : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit
```


## Input

### value : __invalid<Result>__

The value of the highest bit being asserted.


### number : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

Unsigned integer of which the highest bit is checked.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

The controlled version of this operation ignores controls.

## See Also

- [Microsoft.Quantum.Intrinsic.Assert](xref:Microsoft.Quantum.Intrinsic.Assert)
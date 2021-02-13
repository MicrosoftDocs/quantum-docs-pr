---
uid: Microsoft.Quantum.Arithmetic.AssertMostSignificantBit
title: AssertMostSignificantBit operation
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: AssertMostSignificantBit
qsharp.summary: >-
  Asserts that the most significant qubit of a qubit register
  representing an unsigned integer is in a particular state.
---

# AssertMostSignificantBit operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Asserts that the most significant qubit of a qubit registerrepresenting an unsigned integer is in a particular state.

```qsharp
operation AssertMostSignificantBit (value : Result, number : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit is Adj + Ctl
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
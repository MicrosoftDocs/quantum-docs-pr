---
uid: Microsoft.Quantum.Bitwise.XBits
title: XBits function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Bitwise
qsharp.name: XBits
qsharp.summary: >-
  Returns an integer representing the X bits of an array
  of Pauli operators.
---

# XBits function

Namespace: [Microsoft.Quantum.Bitwise](xref:Microsoft.Quantum.Bitwise)

Package: [](https://nuget.org/packages/)


Returns an integer representing the X bits of an arrayof Pauli operators.

```qsharp
function XBits (paulis : Pauli[]) : Int
```


## Input

### paulis : [Pauli](xref:microsoft.quantum.lang-ref.pauli)[]

An array of Pauli operators to be represented as an integer.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

An integer $x$ with binary representation $(p_{62}\,p_{61}\,\dots\,p_0)$,where $p_i = 0$ if `paulis[i]` is `PauliI` or `PauliZ` and where$p_i = 1$ if `paulis[i]` is `PauliX` or `PauliY`.

## Remarks

The function will throw if the length of `paulis` array is greater than 63.

## See Also

- [Microsoft.Quantum.Bitwise.ZBits](xref:Microsoft.Quantum.Bitwise.ZBits)
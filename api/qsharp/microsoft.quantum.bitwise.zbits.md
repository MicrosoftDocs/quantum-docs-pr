---
uid: Microsoft.Quantum.Bitwise.ZBits
title: ZBits function
ms.date: 11/12/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Bitwise
qsharp.name: ZBits
qsharp.summary: >-
  Returns an integer representing the Z bits of an array
  of Pauli operators.
---

# ZBits function

Namespace: [Microsoft.Quantum.Bitwise](xref:Microsoft.Quantum.Bitwise)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Returns an integer representing the Z bits of an arrayof Pauli operators.

```qsharp
function ZBits (paulis : Pauli[]) : Int
```


## Input

### paulis : [Pauli](xref:microsoft.quantum.lang-ref.pauli)[]

An array of Pauli operators to be represented as an integer.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

An integer $x$ with binary representation $(p_{62}\,p_{61}\,\dots\,p_0)$,where $p_i = 0$ if `paulis[i]` is `PauliI` or `PauliX` and where$p_i = 1$ if `paulis[i]` is `PauliY` or `PauliZ`.

## Remarks

The function will throw if the length of `paulis` array is greater than 63.

## See Also

- [Microsoft.Quantum.Bitwise.XBits](xref:Microsoft.Quantum.Bitwise.XBits)
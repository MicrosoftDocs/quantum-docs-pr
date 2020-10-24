---
uid: Microsoft.Quantum.Intrinsic.RFrac
title: RFrac operation
ms.date: 10/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: RFrac
qsharp.summary: >-
  Applies a rotation about the given Pauli axis by an angle specified
  as a dyadic fraction.

  \begin{align}
  R_{\mu}(n, k) \mathrel{:=}
  e^{i \pi n \sigma_{\mu} / 2^k},
  \end{align}
  where $\mu \in \{I, X, Y, Z\}$.

  > [!WARNING]
  > This operation uses the **opposite** sign convention from
  > @"microsoft.quantum.intrinsic.r".
---

# RFrac operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [](https://nuget.org/packages/)


Applies a rotation about the given Pauli axis by an angle specifiedas a dyadic fraction.\begin{align}R_{\mu}(n, k) \mathrel{:=}e^{i \pi n \sigma_{\mu} / 2^k},\end{align}where $\mu \in \{I, X, Y, Z\}$.> [!WARNING]> This operation uses the **opposite** sign convention from> @"microsoft.quantum.intrinsic.r".

```qsharp
operation RFrac (pauli : Pauli, numerator : Int, power : Int, qubit : Qubit) : Unit
```


## Input

### pauli : [Pauli](xref:microsoft.quantum.lang-ref.pauli)

Pauli operator to be exponentiated to form the rotation.


### numerator : [Int](xref:microsoft.quantum.lang-ref.int)

Numerator in the dyadic fraction representation of the angleby which the qubit is to be rotated.


### power : [Int](xref:microsoft.quantum.lang-ref.int)

Power of two specifying the denominator of the angle by whichthe qubit is to be rotated.


### qubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit to which the gate should be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Equivalent to:```qsharp// PI() is a Q# function that returns an approximation of π.R(pauli, -PI() * IntAsDouble(numerator) / IntAsDouble(2 ^ (power - 1)), qubit);```
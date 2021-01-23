---
uid: Microsoft.Quantum.Chemistry.JordanWigner.VQE.ExpandedCoefficients
title: ExpandedCoefficients function
ms.date: 1/23/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner.VQE
qsharp.name: ExpandedCoefficients
qsharp.summary: >-
  Expands the compact representation of the Jordan-Wigner coefficients in order
  to obtain a one-to-one mapping between these and Pauli terms.
---

# ExpandedCoefficients function

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner.VQE](xref:Microsoft.Quantum.Chemistry.JordanWigner.VQE)

Package: [Microsoft.Quantum.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Chemistry)


Expands the compact representation of the Jordan-Wigner coefficients in orderto obtain a one-to-one mapping between these and Pauli terms.

```qsharp
function ExpandedCoefficients (coeff : Double[], termType : Int) : Double[]
```


## Input

### coeff : [Double](xref:microsoft.quantum.lang-ref.double)[]

An array of coefficients, as read from the Jordan-Wigner Hamiltonian data structure.


### termType : [Int](xref:microsoft.quantum.lang-ref.int)

The type of the Jordan-Wigner term.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)[]

Expanded arrays of coefficients, one per Pauli term.
---
uid: Microsoft.Quantum.Chemistry.JordanWigner.VQE.ExpandedCoefficients
title: ExpandedCoefficients function
ms.date: 10/16/2020 12:00:00 AM
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

Package: [](https://nuget.org/packages/)


Expands the compact representation of the Jordan-Wigner coefficients in orderto obtain a one-to-one mapping between these and Pauli terms.

```Q#
ExpandedCoefficients (coeff : Double[], termType : Int) : Double[]
```


## Input

### coeff : Double[]

An array of coefficients, as read from the Jordan-Wigner Hamiltonian data structure.


### termType : Int

The type of the Jordan-Wigner term.



## Output

Expanded arrays of coefficients, one per Pauli term.
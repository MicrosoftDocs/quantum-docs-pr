---
uid: Microsoft.Quantum.Diagnostics._assertEqualOnBasisVector
title: _assertEqualOnBasisVector operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: _assertEqualOnBasisVector
qsharp.summary: >-
  Checks if the result of applying two operations `givenU` and `expectedU` to
  a basis state is the same. The basis state is described by `basis` parameter.
  See <xref:microsoft.quantum.extensions.fliptobasis> function for more details on this
  description.
---

# _assertEqualOnBasisVector operation

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Checks if the result of applying two operations `givenU` and `expectedU` toa basis state is the same. The basis state is described by `basis` parameter.See <xref:microsoft.quantum.extensions.fliptobasis> function for more details on thisdescription.

```Q#
_assertEqualOnBasisVector (basis : Int[], givenU : (Qubit[] => Unit), expectedU : (Qubit[] => Unit is Adj)) : Unit
```


## Input

### basis : Int[]

Basis state specified by a single-qubit basis state ID (0 <= id <= 3) for each of$n$ qubits.


### givenU : Qubit[] => Unit 

Operation on $n$ qubits to be checked.


### expectedU : Qubit[] => Unit Adj

Reference operation on $n$ qubits that givenU is to be compared against.


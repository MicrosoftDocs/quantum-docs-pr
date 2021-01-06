---
uid: Microsoft.Quantum.Diagnostics._assertEqualOnBasisVector
title: _assertEqualOnBasisVector operation
ms.date: 1/5/2021 12:00:00 AM
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

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Checks if the result of applying two operations `givenU` and `expectedU` toa basis state is the same. The basis state is described by `basis` parameter.See <xref:microsoft.quantum.extensions.fliptobasis> function for more details on thisdescription.

```qsharp
operation _assertEqualOnBasisVector (basis : Int[], givenU : (Qubit[] => Unit), expectedU : (Qubit[] => Unit is Adj)) : Unit
```


## Input

### basis : [Int](xref:microsoft.quantum.lang-ref.int)[]

Basis state specified by a single-qubit basis state ID (0 <= id <= 3) for each of$n$ qubits.


### givenU : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) 

Operation on $n$ qubits to be checked.


### expectedU : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj

Reference operation on $n$ qubits that givenU is to be compared against.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


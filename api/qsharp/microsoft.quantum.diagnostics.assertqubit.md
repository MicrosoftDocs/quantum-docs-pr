---
uid: Microsoft.Quantum.Diagnostics.AssertQubit
title: AssertQubit operation
ms.date: 1/5/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: AssertQubit
qsharp.summary: Asserts that the qubit `q` is in the expected eigenstate of the Pauli Z operator.
---

# AssertQubit operation

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Asserts that the qubit `q` is in the expected eigenstate of the Pauli Z operator.

```qsharp
operation AssertQubit (expected : Result, q : Qubit) : Unit
```


## Input

### expected : __invalid<Result>__

Which state the qubit is expected to be in: `Zero` or `One`.


### q : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

The qubit whose state is asserted.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

<xref:microsoft.quantum.diagnostics.assertqubitisinstatewithintolerance> allows for assertingarbitrary qubit states rather than only $Z$ eigenstates.

## See Also

- [Microsoft.Quantum.Diagnostics.AssertQubitIsInStateWithinTolerance](xref:Microsoft.Quantum.Diagnostics.AssertQubitIsInStateWithinTolerance)
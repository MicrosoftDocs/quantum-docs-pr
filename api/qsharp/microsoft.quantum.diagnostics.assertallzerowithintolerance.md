---
uid: Microsoft.Quantum.Diagnostics.AssertAllZeroWithinTolerance
title: AssertAllZeroWithinTolerance operation
ms.date: 10/29/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: AssertAllZeroWithinTolerance
qsharp.summary: Assert that given qubits are all in $\ket{0}$ state up to a given tolerance.
---

# AssertAllZeroWithinTolerance operation

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Assert that given qubits are all in $\ket{0}$ state up to a given tolerance.

```qsharp
operation AssertAllZeroWithinTolerance (qubits : Qubit[], tolerance : Double) : Unit
```


## Input

### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubits that are asserted to be in $\ket{0}$ state.


### tolerance : [Double](xref:microsoft.quantum.lang-ref.double)

Accuracy with which the state should be in $\ket{0}$ state



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Diagnostics.AssertQubitWithinTolerance](xref:Microsoft.Quantum.Diagnostics.AssertQubitWithinTolerance)
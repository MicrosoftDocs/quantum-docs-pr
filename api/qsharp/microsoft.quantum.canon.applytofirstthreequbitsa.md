---
uid: Microsoft.Quantum.Canon.ApplyToFirstThreeQubitsA
title: ApplyToFirstThreeQubitsA operation
ms.date: 12/13/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToFirstThreeQubitsA
qsharp.summary: >-
  Applies an operation to the first three qubits in the register.
  The modifier `A` indicates that the operation is adjointable.
---

# ApplyToFirstThreeQubitsA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation to the first three qubits in the register.The modifier `A` indicates that the operation is adjointable.

```qsharp
operation ApplyToFirstThreeQubitsA (op : ((Qubit, Qubit, Qubit) => Unit is Adj), register : Qubit[]) : Unit is Adj
```


## Input

### op : ([Qubit](xref:microsoft.quantum.lang-ref.qubit),[Qubit](xref:microsoft.quantum.lang-ref.qubit),[Qubit](xref:microsoft.quantum.lang-ref.qubit)) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj

An operation to be applied to the first three qubits


### register : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubit array to the first three qubits of which the operation is applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

This is equivalent to:```qsharpop(register[0], register[1], register[2]);```

## See Also

- [Microsoft.Quantum.Canon.ApplyToFirstThreeQubits](xref:Microsoft.Quantum.Canon.ApplyToFirstThreeQubits)
---
uid: Microsoft.Quantum.Canon.LogicalANDMeasAndFix
title: LogicalANDMeasAndFix operation
ms.date: 10/28/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: LogicalANDMeasAndFix
qsharp.summary: Computes the logical AND of multiple qubits.
---

# LogicalANDMeasAndFix operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Computes the logical AND of multiple qubits.

```qsharp
operation LogicalANDMeasAndFix (ctrlRegister : Qubit[], target : Qubit) : Unit
```


## Input

### ctrlRegister : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubits input to the multiple-input AND gate.


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit on which output of AND is written to. This isassumed to always start in the $\ket{0}$ state.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

When `ctrlRegister` has exactly $2$ qubits,this is equivalent to the `CCNOT` operation but phase with a phase$e^{i\Pi/2}$ on $\ket{001}$ and $-e^{i\Pi/2}$ on $\ket{101}$ and $\ket{011}$.The Adjoint is also measure-and-fixup approach that is the inverseof the original operation only in special cases (see references),but uses fewer T-gates.

## References

- [ *Craig Gidney*, 1709.06648](https://arxiv.org/abs/1709.06648)
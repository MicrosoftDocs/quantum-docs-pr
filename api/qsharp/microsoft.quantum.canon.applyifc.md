---
uid: Microsoft.Quantum.Canon.ApplyIfC
title: ApplyIfC operation
ms.date: 2/5/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyIfC
qsharp.summary: Applies a controllable operation conditioned on a classical bit.
---

# ApplyIfC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies a controllable operation conditioned on a classical bit.

```qsharp
operation ApplyIfC<'T> (op : ('T => Unit is Ctl), bit : Bool, target : 'T) : Unit is Ctl
```


## Description

Given an operation `op` and a bit value `bit`, applies `op` to the `target`if `bit` is `true`. If `false`, nothing happens to the `target`.The suffix `C` indicates that the operation to be applied is controllable.

## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Ctl

An operation to be conditionally applied.


### bit : [Bool](xref:microsoft.quantum.lang-ref.bool)

a boolean that controls whether op is applied or not.


### target : 'T

The input to which the operation is applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The input type of the operation to be conditionally applied.

## Example

The following prepares a register of qubits into a computational basisstate represented by a classical bit string given as an array of `Bool`values:```qsharplet bitstring = [true, false, true];using (register = Qubit(3)) {    ApplyToEach(ApplyIf(X, _, _), Zipped(bitstring, register));    // register should now be in the state |101⟩.    ...}```

## See Also

- [Microsoft.Quantum.Canon.ApplyIfC](xref:Microsoft.Quantum.Canon.ApplyIfC)
- [Microsoft.Quantum.Canon.ApplyIfA](xref:Microsoft.Quantum.Canon.ApplyIfA)
- [Microsoft.Quantum.Canon.ApplyIfCA](xref:Microsoft.Quantum.Canon.ApplyIfCA)
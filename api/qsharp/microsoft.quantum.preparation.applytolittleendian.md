---
uid: Microsoft.Quantum.Preparation.ApplyToLittleEndian
title: ApplyToLittleEndian operation
ms.date: 10/31/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: ApplyToLittleEndian
qsharp.summary: >-
  Applies an operation to the underlying qubits making up a little-endian
  register. This operation is marked as internal, as a little-endian
  register is intended to be "opaque," such that this is an implementation
  detail only.
---

# ApplyToLittleEndian operation

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [](https://nuget.org/packages/)


Applies an operation to the underlying qubits making up a little-endianregister. This operation is marked as internal, as a little-endianregister is intended to be "opaque," such that this is an implementationdetail only.

```qsharp
operation ApplyToLittleEndian (bareOp : (Qubit[] => Unit is Adj + Ctl), register : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit
```


## Input

### bareOp : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl




### register : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


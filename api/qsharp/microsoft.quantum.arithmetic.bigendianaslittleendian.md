---
uid: Microsoft.Quantum.Arithmetic.BigEndianAsLittleEndian
title: BigEndianAsLittleEndian function
ms.date: 2/3/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: BigEndianAsLittleEndian
qsharp.summary: >-
  Converts a `BigEndian` qubit register to a `LittleEndian` qubit
  register by reversing the qubit ordering.
---

# BigEndianAsLittleEndian function

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Converts a `BigEndian` qubit register to a `LittleEndian` qubitregister by reversing the qubit ordering.

```qsharp
function BigEndianAsLittleEndian (input : Microsoft.Quantum.Arithmetic.BigEndian) : Microsoft.Quantum.Arithmetic.LittleEndian
```


## Input

### input : [BigEndian](xref:Microsoft.Quantum.Arithmetic.BigEndian)

Qubit register in `BigEndian` format.



## Output : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

Qubit register in `LittleEndian` format.
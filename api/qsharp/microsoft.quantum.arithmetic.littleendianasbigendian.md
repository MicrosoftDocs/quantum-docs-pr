---
uid: Microsoft.Quantum.Arithmetic.LittleEndianAsBigEndian
title: LittleEndianAsBigEndian function
ms.date: 11/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: LittleEndianAsBigEndian
qsharp.summary: >-
  Converts a `LittleEndian` qubit register to a `BigEndian` qubit
  register by reversing the qubit ordering.
---

# LittleEndianAsBigEndian function

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Converts a `LittleEndian` qubit register to a `BigEndian` qubitregister by reversing the qubit ordering.

```qsharp
function LittleEndianAsBigEndian (input : Microsoft.Quantum.Arithmetic.LittleEndian) : Microsoft.Quantum.Arithmetic.BigEndian
```


## Input

### input : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

Qubit register in `LittleEndian` format.



## Output : [BigEndian](xref:Microsoft.Quantum.Arithmetic.BigEndian)

Qubit register in `BigEndian` format.
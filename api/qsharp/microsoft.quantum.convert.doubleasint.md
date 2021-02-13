---
uid: Microsoft.Quantum.Convert.DoubleAsInt
title: DoubleAsInt function
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Convert
qsharp.name: DoubleAsInt
qsharp.summary: >-
  Converts a floating-point number to an integer by
  returning the truncation to its integral part.
---

# DoubleAsInt function

Namespace: [Microsoft.Quantum.Convert](xref:Microsoft.Quantum.Convert)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Converts a floating-point number to an integer byreturning the truncation to its integral part.

```qsharp
function DoubleAsInt (a : Double) : Int
```


## Input

### a : [Double](xref:microsoft.quantum.lang-ref.double)

The value whose truncation is to be returned.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

The truncation of the input.

## Example

```Message($"{Truncate(3.1)}");   //  3.0Message($"{Truncate(3.7)}");   //  3.0Message($"{Truncate(-3.1)}");  // -3.0Message($"{Truncate(-3.7)}");  // -3.0```

## See Also

- [Microsoft.Quantum.Math.Truncate](xref:Microsoft.Quantum.Math.Truncate)
- [Microsoft.Quantum.Math.Ceiling](xref:Microsoft.Quantum.Math.Ceiling)
- [Microsoft.Quantum.Math.Floor](xref:Microsoft.Quantum.Math.Floor)
- [Microsoft.Quantum.Math.Round](xref:Microsoft.Quantum.Math.Round)
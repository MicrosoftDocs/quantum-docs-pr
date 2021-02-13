---
uid: Microsoft.Quantum.Math.Truncate
title: Truncate function
ms.date: 2/12/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: Truncate
qsharp.summary: Returns the integral part of a number.
---

# Truncate function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Returns the integral part of a number.

```qsharp
function Truncate (a : Double) : Int
```


## Input

### a : [Double](xref:microsoft.quantum.lang-ref.double)

The value whose truncation is to be returned.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

The truncation of the input.

## Example

```Message($"{Truncate(3.1)}");   //  3Message($"{Truncate(3.7)}");   //  3Message($"{Truncate(-3.1)}");  // -3Message($"{Truncate(-3.7)}");  // -3```

## See Also

- [Microsoft.Quantum.Convert.DoubleAsInt](xref:Microsoft.Quantum.Convert.DoubleAsInt)
- [Microsoft.Quantum.Math.Ceiling](xref:Microsoft.Quantum.Math.Ceiling)
- [Microsoft.Quantum.Math.Floor](xref:Microsoft.Quantum.Math.Floor)
- [Microsoft.Quantum.Math.Round](xref:Microsoft.Quantum.Math.Round)
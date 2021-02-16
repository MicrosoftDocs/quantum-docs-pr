---
uid: Microsoft.Quantum.Math.Ceiling
title: Ceiling function
ms.date: 2/16/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: Ceiling
qsharp.summary: Returns the smallest integer greater than or equal to the specified number.
---

# Ceiling function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Returns the smallest integer greater than or equal to the specified number.

```qsharp
function Ceiling (value : Double) : Int
```


## Input

### value : [Double](xref:microsoft.quantum.lang-ref.double)

The value whose ceiling is to be returned.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

The ceiling of the input.

## Example

```Message($"{Ceiling(3.1)}");   //  4Message($"{Ceiling(3.7)}");   //  4Message($"{Ceiling(-3.1)}");  // -3Message($"{Ceiling(-3.7)}");  // -3```
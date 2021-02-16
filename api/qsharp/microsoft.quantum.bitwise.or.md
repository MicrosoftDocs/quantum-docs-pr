---
uid: Microsoft.Quantum.Bitwise.Or
title: Or function
ms.date: 2/16/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Bitwise
qsharp.name: Or
qsharp.summary: >-
  Returns the bitwise OR of two integers.
  This performs the same computation as the built-in `|||` operator.
---

# Or function

Namespace: [Microsoft.Quantum.Bitwise](xref:Microsoft.Quantum.Bitwise)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Returns the bitwise OR of two integers.This performs the same computation as the built-in `|||` operator.

```qsharp
function Or (a : Int, b : Int) : Int
```


## Input

### a : [Int](xref:microsoft.quantum.lang-ref.int)




### b : [Int](xref:microsoft.quantum.lang-ref.int)





## Output : [Int](xref:microsoft.quantum.lang-ref.int)



## Example

```qsharplet a = 248;      //                 11111000₂let b = 63;       //                 00111111₂let x = Or(a, b); // x : Int = 255 = 11111111₂.```

## Remarks

See the [C# | Operator](https://docs.microsoft.com/dotnet/csharp/language-reference/operators/or-operator) for more details.
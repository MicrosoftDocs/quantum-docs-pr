---
uid: Microsoft.Quantum.Bitwise.Not
title: Not function
ms.date: 2/4/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Bitwise
qsharp.name: Not
qsharp.summary: >-
  Returns the bitwise NOT of an integer.
  This performs the same computation as the built-in `~~~` operator.
---

# Not function

Namespace: [Microsoft.Quantum.Bitwise](xref:Microsoft.Quantum.Bitwise)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Returns the bitwise NOT of an integer.This performs the same computation as the built-in `~~~` operator.

```qsharp
function Not (a : Int) : Int
```


## Input

### a : [Int](xref:microsoft.quantum.lang-ref.int)





## Output : [Int](xref:microsoft.quantum.lang-ref.int)



## Example

```qsharplet a = 248;let x = Not(a); // x : Int = -249, due to two's complement representation.```

## Remarks

See the [C# ~ Operator](https://docs.microsoft.com/dotnet/csharp/language-reference/operators/bitwise-complement-operator) for more details.
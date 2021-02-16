---
uid: Microsoft.Quantum.Math.AbsL
title: AbsL function
ms.date: 2/16/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: AbsL
qsharp.summary: Returns the absolute value of an integer.
---

# AbsL function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Returns the absolute value of an integer.

```qsharp
function AbsL (a : BigInt) : BigInt
```


## Input

### a : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The number whose absolute value is to be returned.



## Output : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The absolute value of `a`.

## Example

```qsharpMessage($"{AbsD(314L)}");   // 314LMessage($"{AbsD(-271L)}");  // 271L```

## See Also

- [Microsoft.Quantum.Math.AbsD](xref:Microsoft.Quantum.Math.AbsD)
- [Microsoft.Quantum.Math.AbsI](xref:Microsoft.Quantum.Math.AbsI)
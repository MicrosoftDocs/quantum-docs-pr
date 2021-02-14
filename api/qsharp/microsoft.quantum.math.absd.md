---
uid: Microsoft.Quantum.Math.AbsD
title: AbsD function
ms.date: 2/14/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: AbsD
qsharp.summary: Returns the absolute value of a double-precision floating-point number.
---

# AbsD function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Returns the absolute value of a double-precision floating-point number.

```qsharp
function AbsD (a : Double) : Double
```


## Input

### a : [Double](xref:microsoft.quantum.lang-ref.double)

The number whose absolute value is to be returned.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)

The absolute value of `a`.

## Example

```qsharpMessage($"{AbsD(3.14)}");   // 3.14Message($"{AbsD(-2.71)}");  // 2.71```

## See Also

- [Microsoft.Quantum.Math.AbsI](xref:Microsoft.Quantum.Math.AbsI)
- [Microsoft.Quantum.Math.AbsL](xref:Microsoft.Quantum.Math.AbsL)
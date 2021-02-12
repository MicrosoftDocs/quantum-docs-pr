---
uid: Microsoft.Quantum.Math.ExpD
title: ExpD function
ms.date: 2/12/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: ExpD
qsharp.summary: Returns the natural logarithmic base raised to a specified power.
---

# ExpD function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Returns the natural logarithmic base raised to a specified power.

```qsharp
function ExpD (a : Double) : Double
```


## Input

### a : [Double](xref:microsoft.quantum.lang-ref.double)

The power to which $e$ should be raised.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)

The natural logarithmic base raised to the power `a`, $e^a$.

## Remarks

Note that on some execution targets, this function may be implementedby a limited-precision algorithm.
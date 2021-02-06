---
uid: Microsoft.Quantum.Math.SignD
title: SignD function
ms.date: 2/6/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: SignD
qsharp.summary: Returns an integer that indicates the sign of a number.
---

# SignD function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Returns an integer that indicates the sign of a number.

```qsharp
function SignD (a : Double) : Int
```


## Input

### a : [Double](xref:microsoft.quantum.lang-ref.double)

The number whose sign is to be returned.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

The sign of `a` represented as an integer, as shown in the followingtable:|Return value  |Meaning                  ||--------------|-------------------------|| -1           |`a` is less than zero    || 0            |`a` is equal to zero     || +1           |`a` is greater than zero |

## See Also

- [Microsoft.Quantum.Math.SignI](xref:Microsoft.Quantum.Math.SignI)
- [Microsoft.Quantum.Math.SignL](xref:Microsoft.Quantum.Math.SignL)
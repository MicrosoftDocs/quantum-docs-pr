---
uid: Microsoft.Quantum.Arrays.ElementAt
title: ElementAt function
ms.date: 11/11/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: ElementAt
qsharp.summary: Returns the at the given index of an array.
---

# ElementAt function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns the at the given index of an array.

```qsharp
function ElementAt<'T> (index : Int, array : 'T[]) : 'T
```


## Input

### index : [Int](xref:microsoft.quantum.lang-ref.int)

Index of element


### array : 'T[]

The array being indexed.



## Output : 'T



## Type Parameters

### 'T

The type of each element of `array`.

## See Also

- [Microsoft.Quantum.Arrays.LookupFunction](xref:Microsoft.Quantum.Arrays.LookupFunction)
- [Microsoft.Quantum.Arrays.ElementsAt](xref:Microsoft.Quantum.Arrays.ElementsAt)
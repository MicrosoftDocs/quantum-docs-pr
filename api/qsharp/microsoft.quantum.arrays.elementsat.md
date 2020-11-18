---
uid: Microsoft.Quantum.Arrays.ElementsAt
title: ElementsAt function
ms.date: 11/18/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: ElementsAt
qsharp.summary: >-
  Returns the array's elements at a given range
  of indices.
---

# ElementsAt function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns the array's elements at a given rangeof indices.

```qsharp
function ElementsAt<'T> (range : Range, array : 'T[]) : 'T[]
```


## Input

### range : [Range](xref:microsoft.quantum.lang-ref.range)

Range of array indexes


### array : 'T[]

Array



## Output : 'T[]



## Type Parameters

### 'T

The type of each element of `array`.

## See Also

- [Microsoft.Quantum.Arrays.ElementAt](xref:Microsoft.Quantum.Arrays.ElementAt)
- [Microsoft.Quantum.Arrays.LookupFunction](xref:Microsoft.Quantum.Arrays.LookupFunction)
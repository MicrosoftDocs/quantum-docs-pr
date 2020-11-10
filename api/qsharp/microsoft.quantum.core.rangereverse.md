---
uid: Microsoft.Quantum.Core.RangeReverse
title: RangeReverse function
ms.date: 11/10/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Core
qsharp.name: RangeReverse
qsharp.summary: Returns a new range which is the reverse of the input range.
---

# RangeReverse function

Namespace: [Microsoft.Quantum.Core](xref:Microsoft.Quantum.Core)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Returns a new range which is the reverse of the input range.

```qsharp
function RangeReverse (r : Range) : Range
```


## Input

### r : [Range](xref:microsoft.quantum.lang-ref.range)

Input range.



## Output : [Range](xref:microsoft.quantum.lang-ref.range)

A new range that is the reverse of the given range.

## Remarks

Note that the reverse of a range is not simply `end`..`-step`..`start`, becausethe actual last element of a range may not be the same as `end`.
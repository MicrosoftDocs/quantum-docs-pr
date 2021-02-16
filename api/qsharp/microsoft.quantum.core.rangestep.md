---
uid: Microsoft.Quantum.Core.RangeStep
title: RangeStep function
ms.date: 2/16/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Core
qsharp.name: RangeStep
qsharp.summary: Returns the integer that specifies how the next value of a range is calculated.
---

# RangeStep function

Namespace: [Microsoft.Quantum.Core](xref:Microsoft.Quantum.Core)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Returns the integer that specifies how the next value of a range is calculated.

```qsharp
function RangeStep (range : Range) : Int
```


## Input

### range : [Range](xref:microsoft.quantum.lang-ref.range)

Input range.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

The defined step value of the given range.

## Remarks

A range expression's first element is `start`,its second element is `start+step`, third element is `start+step+step`, etc.,until `end` is passed.
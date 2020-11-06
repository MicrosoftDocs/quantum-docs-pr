---
uid: Microsoft.Quantum.Arrays.TupleArrayAsNestedArray
title: TupleArrayAsNestedArray function
ms.date: 11/6/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: TupleArrayAsNestedArray
qsharp.summary: Turns a list of 2-tuples into a nested array.
---

# TupleArrayAsNestedArray function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Turns a list of 2-tuples into a nested array.

```qsharp
function TupleArrayAsNestedArray<'T> (tupleList : ('T, 'T)[]) : 'T[][]
```


## Input

### tupleList : ('T,'T)[]

List of 2-tuples to be turned into a nested array.



## Output : 'T[][]

A nested array with length matching the tupleList.## Example```qsharp// The following returns [[2, 3], [4, 5]]TupleArrayAsNestedArray([(2, 3), (4, 5)]);```

## Type Parameters

### 'T


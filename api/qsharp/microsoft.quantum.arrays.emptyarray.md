---
uid: Microsoft.Quantum.Arrays.EmptyArray
title: EmptyArray function
ms.date: 1/29/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: EmptyArray
qsharp.summary: Returns the empty array of a given type.
---

# EmptyArray function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Returns the empty array of a given type.

```qsharp
function EmptyArray<'TElement> () : 'TElement[]
```


## Output : 'TElement[]

The empty array.

## Type Parameters

### 'TElement

The type of elements of the array.

## Example

```qsharplet empty = EmptyArray<Int>();```
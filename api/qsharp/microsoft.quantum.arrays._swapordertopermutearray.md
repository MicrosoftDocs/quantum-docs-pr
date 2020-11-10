---
uid: Microsoft.Quantum.Arrays._SwapOrderToPermuteArray
title: _SwapOrderToPermuteArray function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: _SwapOrderToPermuteArray
qsharp.summary: >-
  Returns the order elements in an array need to be swapped to produce an ordered array.
  Assumes swaps occur in place.
---

# _SwapOrderToPermuteArray function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Returns the order elements in an array need to be swapped to produce an ordered array.Assumes swaps occur in place.

```qsharp
function _SwapOrderToPermuteArray (newOrder : Int[]) : (Int, Int)[]
```


## Input

### newOrder : [Int](xref:microsoft.quantum.lang-ref.int)[]

Array with the permutation of the indices of the new array. There should be $n$ elements,each being a unique integer from $0$ to $n-1$.



## Output : ([Int](xref:microsoft.quantum.lang-ref.int),[Int](xref:microsoft.quantum.lang-ref.int))[]

The tuple represents the two indices to be swapped. The swaps begin at the lowest index.

## Remarks

## Psuedocodefor (index in 0..Length(newOrder) - 1) {while newOrder[index] != index {Switch newOrder[index] with newOrder[newOrder[index]]}}
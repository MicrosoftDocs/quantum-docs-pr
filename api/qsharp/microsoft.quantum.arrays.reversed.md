---
uid: Microsoft.Quantum.Arrays.Reversed
title: Reversed function
ms.date: 11/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Reversed
qsharp.summary: >-
  Create an array that contains the same elements as an input array but in Reversed
  order.
---

# Reversed function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Create an array that contains the same elements as an input array but in Reversedorder.

```qsharp
function Reversed<'T> (array : 'T[]) : 'T[]
```


## Input

### array : 'T[]

An array whose elements are to be copied in Reversed order.



## Output : 'T[]

An array containing the elements `array[Length(array) - 1]` .. `array[0]`.

## Type Parameters

### 'T

The type of the array elements.
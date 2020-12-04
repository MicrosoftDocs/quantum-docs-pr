---
uid: Microsoft.Quantum.Arrays.ConstantArray
title: ConstantArray function
ms.date: 12/4/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: ConstantArray
qsharp.summary: Creates an array of given length with all elements equal to given value.
---

# ConstantArray function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Creates an array of given length with all elements equal to given value.

```qsharp
function ConstantArray<'T> (length : Int, value : 'T) : 'T[]
```


## Input

### length : [Int](xref:microsoft.quantum.lang-ref.int)

Length of the new array.


### value : 'T

The value of each element of the new array.



## Output : 'T[]

A new array of length `length`, such that every element is `value`.

## Type Parameters

### 'T


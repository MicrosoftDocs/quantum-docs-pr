---
uid: Microsoft.Quantum.Arrays.ConstantArray
title: ConstantArray function
ms.date: 2/15/2021 12:00:00 AM
ms.topic: managed-reference
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



## Example

The following code creates an array of 3 Boolean values, each equal to `true`:```qsharplet array = ConstantArray(3, true);```
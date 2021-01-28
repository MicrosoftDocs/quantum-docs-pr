---
uid: Microsoft.Quantum.Math.PlusA
title: PlusA function
ms.date: 1/27/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: PlusA
qsharp.summary: Returns the sum (concatenation) of two inputs.
---

# PlusA function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns the sum (concatenation) of two inputs.

```qsharp
function PlusA<'Element> (a : 'Element[], b : 'Element[]) : 'Element[]
```


## Input

### a : 'Element[]

The first input $a$ to be summed.


### b : 'Element[]

The second input $b$ to be summed.



## Output : 'Element[]

The sum $a + b$.

## Type Parameters

### 'Element

The type of each element in each of the two input arrays.
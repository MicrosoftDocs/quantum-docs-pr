---
uid: Microsoft.Quantum.Synthesis.WithZeroInsertedAt
title: WithZeroInsertedAt function
ms.date: 10/30/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: WithZeroInsertedAt
qsharp.summary: Insert a 0-bit into an integer
---

# WithZeroInsertedAt function

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [](https://nuget.org/packages/)


Insert a 0-bit into an integer

```qsharp
function WithZeroInsertedAt (position : Int, value : Int) : Int
```


## Description

This operation takes an integer, inserts a 0 at bit `position`, and returnsthe updated value as an integer.  For example, inserting a 0 at position 2in the number 10 ($10_{10} = 1010_{2}$) returns the number 18 ($18_{10} = 10010_{2}$).

## Input

### position : [Int](xref:microsoft.quantum.lang-ref.int)

The position at which 0 is inserted


### value : [Int](xref:microsoft.quantum.lang-ref.int)

The value that is modified



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

Modified value
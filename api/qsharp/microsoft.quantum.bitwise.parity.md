---
uid: Microsoft.Quantum.Bitwise.Parity
title: Parity function
ms.date: 1/28/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Bitwise
qsharp.name: Parity
qsharp.summary: Returns the bitwise PARITY of an integer (1 if its binary representation contains odd number of ones and 0 otherwise).
---

# Parity function

Namespace: [Microsoft.Quantum.Bitwise](xref:Microsoft.Quantum.Bitwise)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Returns the bitwise PARITY of an integer (1 if its binary representation contains odd number of ones and 0 otherwise).

```qsharp
function Parity (a : Int) : Int
```


## Input

### a : [Int](xref:microsoft.quantum.lang-ref.int)





## Output : [Int](xref:microsoft.quantum.lang-ref.int)



## Example

```qsharplet a = 248;let x = Parity(a); // x : Int = 1.```
---
uid: Microsoft.Quantum.Synthesis.Encoded
title: Encoded function
ms.date: 1/27/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: Encoded
qsharp.summary: Encode truth table in {1,-1} coding
---

# Encoded function

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Encode truth table in {1,-1} coding

```qsharp
function Encoded (table : Bool[]) : Int[]
```


## Input

### table : [Bool](xref:microsoft.quantum.lang-ref.bool)[]

Truth table as array of truth values



## Output : [Int](xref:microsoft.quantum.lang-ref.int)[]

Truth table as array of {1,-1} integers

## Example

```Q#Encoded([false, false, false, true]); // [1, 1, 1, -1]```
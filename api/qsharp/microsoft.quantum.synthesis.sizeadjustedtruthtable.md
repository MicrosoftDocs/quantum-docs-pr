---
uid: Microsoft.Quantum.Synthesis.SizeAdjustedTruthTable
title: SizeAdjustedTruthTable function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: SizeAdjustedTruthTable
qsharp.summary: >-
  Adjusts truth table from array of Booleans according to number of variables

  A new array is returned of length `2^numVars`, possibly
  requiring to extend `table`'s size with `false` entries
  or truncating it to `2^numVars` elements.
---

# SizeAdjustedTruthTable function

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [](https://nuget.org/packages/)


Adjusts truth table from array of Booleans according to number of variablesA new array is returned of length `2^numVars`, possiblyrequiring to extend `table`'s size with `false` entriesor truncating it to `2^numVars` elements.

```Q#
SizeAdjustedTruthTable (table : Bool[], numVars : Int) : Bool[]
```


## Input

### table : Bool[]

Truth table as array of truth values


### numVars : Int

Number of variables



## Output

Size adjusted truth table
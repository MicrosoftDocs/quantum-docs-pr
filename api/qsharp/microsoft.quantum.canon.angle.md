---
uid: Microsoft.Quantum.Canon.Angle
title: Angle function
ms.date: 1/28/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: Angle
qsharp.summary: >-
  Returns 1, if `index` has an odd number of 1s and -1, if `index` has an
  even number of 1s.
---

# Angle function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns 1, if `index` has an odd number of 1s and -1, if `index` has aneven number of 1s.

```qsharp
function Angle (index : Int) : Int
```


## Description

Value corresponds to the sign of the coefficient of the Rademacher-Walshspectrum of the n-variable AND function for a given assignment thatdecides the angle of the rotation.

## Input

### index : [Int](xref:microsoft.quantum.lang-ref.int)

Input assignment as integer (from 0 to 2^n - 1)



## Output : [Int](xref:microsoft.quantum.lang-ref.int)


---
uid: Microsoft.Quantum.Synthesis.Extended
title: Extended function
ms.date: 1/27/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: Extended
qsharp.summary: Extends a spectrum by inverted coefficients
---

# Extended function

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Extends a spectrum by inverted coefficients

```qsharp
function Extended (spectrum : Int[]) : Int[]
```


## Input

### spectrum : [Int](xref:microsoft.quantum.lang-ref.int)[]

Spectral coefficients



## Output : [Int](xref:microsoft.quantum.lang-ref.int)[]

Coefficients followed by inverted copy

## Example

```Q#Extended([2, 2, 2, -2]); // [2, 2, 2, -2, -2, -2, -2, 2]```
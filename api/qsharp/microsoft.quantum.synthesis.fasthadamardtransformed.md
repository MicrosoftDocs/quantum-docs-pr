---
uid: Microsoft.Quantum.Synthesis.FastHadamardTransformed
title: FastHadamardTransformed function
ms.date: 11/20/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: FastHadamardTransformed
qsharp.summary: >-
  Computes Hadamard transform of a Boolean function in {-1,1} encoding
  using Yates's method
---

# FastHadamardTransformed function

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Computes Hadamard transform of a Boolean function in {-1,1} encodingusing Yates's method

```qsharp
function FastHadamardTransformed (func : Int[]) : Int[]
```


## Input

### func : [Int](xref:microsoft.quantum.lang-ref.int)[]

Truth table in {-1,1} encoding



## Output : [Int](xref:microsoft.quantum.lang-ref.int)[]

Spectral coefficients of the function
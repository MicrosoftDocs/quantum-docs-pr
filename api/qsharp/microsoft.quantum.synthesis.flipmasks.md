---
uid: Microsoft.Quantum.Synthesis.FlipMasks
title: FlipMasks function
ms.date: 1/28/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: FlipMasks
qsharp.summary: >-
  For every 2-level unitary calculates "flip mask", which denotes qubits which should
  be inverted before and after applying corresponding 1-qubit gate.
  For convenience prepends result with 0.
---

# FlipMasks function

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


For every 2-level unitary calculates "flip mask", which denotes qubits which shouldbe inverted before and after applying corresponding 1-qubit gate.For convenience prepends result with 0.

```qsharp
function FlipMasks (decomposition : (Microsoft.Quantum.Math.Complex[][], Int, Int)[], allQubitsMask : Int) : Int[]
```


## Input

### decomposition : ([Complex](xref:Microsoft.Quantum.Math.Complex)[][],[Int](xref:microsoft.quantum.lang-ref.int),[Int](xref:microsoft.quantum.lang-ref.int))[]




### allQubitsMask : [Int](xref:microsoft.quantum.lang-ref.int)





## Output : [Int](xref:microsoft.quantum.lang-ref.int)[]


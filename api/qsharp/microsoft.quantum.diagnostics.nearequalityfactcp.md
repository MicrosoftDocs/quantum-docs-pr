---
uid: Microsoft.Quantum.Diagnostics.NearEqualityFactCP
title: NearEqualityFactCP function
ms.date: 12/2/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: NearEqualityFactCP
qsharp.summary: >-
  Asserts that a classical complex number has the expected value up to a
  small tolerance of 1e-10.
---

# NearEqualityFactCP function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Asserts that a classical complex number has the expected value up to asmall tolerance of 1e-10.

```qsharp
function NearEqualityFactCP (actual : Microsoft.Quantum.Math.ComplexPolar, expected : Microsoft.Quantum.Math.ComplexPolar) : Unit
```


## Input

### actual : [ComplexPolar](xref:Microsoft.Quantum.Math.ComplexPolar)

The number to be checked.


### expected : [ComplexPolar](xref:Microsoft.Quantum.Math.ComplexPolar)

The expected value.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


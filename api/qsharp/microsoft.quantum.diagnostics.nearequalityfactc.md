---
uid: Microsoft.Quantum.Diagnostics.NearEqualityFactC
title: NearEqualityFactC function
ms.date: 11/12/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: NearEqualityFactC
qsharp.summary: >-
  Asserts that a classical complex number has the expected value up to a
  small tolerance of 1e-10.
---

# NearEqualityFactC function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Asserts that a classical complex number has the expected value up to asmall tolerance of 1e-10.

```qsharp
function NearEqualityFactC (actual : Microsoft.Quantum.Math.Complex, expected : Microsoft.Quantum.Math.Complex) : Unit
```


## Input

### actual : [Complex](xref:Microsoft.Quantum.Math.Complex)

The number to be checked.


### expected : [Complex](xref:Microsoft.Quantum.Math.Complex)

The expected value.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)


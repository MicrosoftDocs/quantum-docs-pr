---
uid: Microsoft.Quantum.Diagnostics.Contradiction
title: Contradiction function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: Contradiction
qsharp.summary: Declares that a classical condition is false.
---

# Contradiction function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Declares that a classical condition is false.

```Q#
Contradiction (actual : Bool, message : String) : Unit
```


## Input

### actual : Bool

The condition to be declared.


### message : String

Failure message string to be printed in the case that the classicalcondition is true.



## See Also

- [Microsoft.Quantum.Diagnostics.Fact](xref:Microsoft.Quantum.Diagnostics.Fact)
---
uid: Microsoft.Quantum.Diagnostics.Fact
title: Fact function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: Fact
qsharp.summary: Declares that a classical condition is true.
---

# Fact function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Declares that a classical condition is true.

```Q#
Fact (actual : Bool, message : String) : Unit
```


## Input

### actual : Bool

The condition to be declared.


### message : String

Failure message string to be printed in the case that the classicalcondition is false.



## See Also

- [Microsoft.Quantum.Diagnostics.Contradiction](xref:Microsoft.Quantum.Diagnostics.Contradiction)
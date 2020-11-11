---
uid: Microsoft.Quantum.Diagnostics.Fact
title: Fact function
ms.date: 11/11/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: Fact
qsharp.summary: Declares that a classical condition is true.
---

# Fact function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Declares that a classical condition is true.

```qsharp
function Fact (actual : Bool, message : String) : Unit
```


## Input

### actual : [Bool](xref:microsoft.quantum.lang-ref.bool)

The condition to be declared.


### message : [String](xref:microsoft.quantum.lang-ref.string)

Failure message string to be printed in the case that the classicalcondition is false.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Diagnostics.Contradiction](xref:Microsoft.Quantum.Diagnostics.Contradiction)
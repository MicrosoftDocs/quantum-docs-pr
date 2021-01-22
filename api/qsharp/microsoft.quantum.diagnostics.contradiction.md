---
uid: Microsoft.Quantum.Diagnostics.Contradiction
title: Contradiction function
ms.date: 1/22/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: Contradiction
qsharp.summary: Declares that a classical condition is false.
---

# Contradiction function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Declares that a classical condition is false.

```qsharp
function Contradiction (actual : Bool, message : String) : Unit
```


## Input

### actual : [Bool](xref:microsoft.quantum.lang-ref.bool)

The condition to be declared.


### message : [String](xref:microsoft.quantum.lang-ref.string)

Failure message string to be printed in the case that the classicalcondition is true.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Example

The following Q# code will print "Hello, world":```Q#Contradiction(2 == 3, "2 is not equal to 3.");Message("Hello, world.");```

## See Also

- [Microsoft.Quantum.Diagnostics.Fact](xref:Microsoft.Quantum.Diagnostics.Fact)
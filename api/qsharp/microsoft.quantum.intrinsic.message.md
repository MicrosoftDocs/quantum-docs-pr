---
uid: Microsoft.Quantum.Intrinsic.Message
title: Message function
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: Message
qsharp.summary: Logs a message.
---

# Message function

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Logs a message.

```qsharp
function Message (msg : String) : Unit
```


## Input

### msg : [String](xref:microsoft.quantum.lang-ref.string)

The message to be reported.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

The specific behavior of this function is simulator-dependent,but in most cases the given message will be written to the console.
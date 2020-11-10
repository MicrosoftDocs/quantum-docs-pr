---
uid: Microsoft.Quantum.Intrinsic.Message
title: Message function
ms.date: 11/10/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: Message
qsharp.summary: Logs a message.
---

# Message function

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [](https://nuget.org/packages/)


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
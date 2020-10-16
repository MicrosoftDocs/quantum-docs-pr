---
uid: Microsoft.Quantum.Intrinsic.Message
title: Message function
ms.date: 10/16/2020 12:00:00 AM
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

```Q#
Message (msg : String) : Unit
```


## Input

### msg : String

The message to be reported.



## Remarks

The specific behavior of this function is simulator-dependent,but in most cases the given message will be written to the console.
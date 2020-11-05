---
uid: Microsoft.Quantum.Environment.GetQubitsAvailableToUse
title: GetQubitsAvailableToUse operation
ms.date: 11/5/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Environment
qsharp.name: GetQubitsAvailableToUse
qsharp.summary: Returns the number of qubits currently available to use.
---

# GetQubitsAvailableToUse operation

Namespace: [Microsoft.Quantum.Environment](xref:Microsoft.Quantum.Environment)

Package: [](https://nuget.org/packages/)


Returns the number of qubits currently available to use.

```qsharp
operation GetQubitsAvailableToUse () : Int
```


## Output : [Int](xref:microsoft.quantum.lang-ref.int)

The number of qubits that could be allocated in a `using` statement.If the target machine being used does not provide this information, then`-1` is returned.

## See Also

- [Microsoft.Quantum.Environment.GetQubitsAvailableToBorrow](xref:Microsoft.Quantum.Environment.GetQubitsAvailableToBorrow)
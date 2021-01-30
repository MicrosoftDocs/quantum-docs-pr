---
uid: Microsoft.Quantum.Environment.GetQubitsAvailableToBorrow
title: GetQubitsAvailableToBorrow operation
ms.date: 1/30/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Environment
qsharp.name: GetQubitsAvailableToBorrow
qsharp.summary: Returns the number of qubits currently available to borrow.
---

# GetQubitsAvailableToBorrow operation

Namespace: [Microsoft.Quantum.Environment](xref:Microsoft.Quantum.Environment)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Returns the number of qubits currently available to borrow.

```qsharp
operation GetQubitsAvailableToBorrow () : Int
```


## Output : [Int](xref:microsoft.quantum.lang-ref.int)

The number of qubits that could be borrowed andwon't be allocated as part of a `borrowing` statement.If the target machine being used does not provide this information, then`-1` is returned.

## See Also

- [Microsoft.Quantum.Environment.GetQubitsAvailableToUse](xref:Microsoft.Quantum.Environment.GetQubitsAvailableToUse)
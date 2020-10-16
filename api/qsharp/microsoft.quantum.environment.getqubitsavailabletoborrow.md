---
uid: Microsoft.Quantum.Environment.GetQubitsAvailableToBorrow
title: GetQubitsAvailableToBorrow operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Environment
qsharp.name: GetQubitsAvailableToBorrow
qsharp.summary: >-
  Returns the number of qubits currently available to borrow.
  This includes unused qubits; that is, this includes the qubits
  returned by `GetQubitsAvailableToUse`.
---

# GetQubitsAvailableToBorrow operation

Namespace: [Microsoft.Quantum.Environment](xref:Microsoft.Quantum.Environment)

Package: [](https://nuget.org/packages/)


Returns the number of qubits currently available to borrow.This includes unused qubits; that is, this includes the qubitsreturned by `GetQubitsAvailableToUse`.

```Q#
GetQubitsAvailableToBorrow () : Int
```


## Output

The number of qubits that could be allocated in a `borrowing` statement.If the target machine being used does not provide this information, then`-1` is returned.

## See Also

- [Microsoft.Quantum.Environment.GetQubitsAvailableToUse](xref:Microsoft.Quantum.Environment.GetQubitsAvailableToUse)
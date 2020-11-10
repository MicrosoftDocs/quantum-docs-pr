---
uid: Microsoft.Quantum.Chemistry.HTerm
title: HTerm user defined type
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Chemistry
qsharp.name: HTerm
qsharp.summary: >-
  Format of data passed from C# to Q# to represent a term of the Hamiltonian.
  The meaning of the data represented is determined by the algorithm that receives it.
---

# HTerm user defined type

Namespace: [Microsoft.Quantum.Chemistry](xref:Microsoft.Quantum.Chemistry)

Package: [](https://nuget.org/packages/)


Format of data passed from C# to Q# to represent a term of the Hamiltonian.The meaning of the data represented is determined by the algorithm that receives it.

```qsharp

newtype HTerm = (Int[], Double[]);
```


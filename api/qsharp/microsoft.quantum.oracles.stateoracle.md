---
uid: Microsoft.Quantum.Oracles.StateOracle
title: StateOracle user defined type
ms.date: 11/11/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Oracles
qsharp.name: StateOracle
qsharp.summary: >-
  Represents an oracle for state preparation.

  The inputs to the oracle $O$ are:

  - An integer indexing the flag qubit $f$.
  - The system register $s$ that will store the desired quantum state $\ket{\psi}\_s$.
---

# StateOracle user defined type

Namespace: [Microsoft.Quantum.Oracles](xref:Microsoft.Quantum.Oracles)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents an oracle for state preparation.The inputs to the oracle $O$ are:- An integer indexing the flag qubit $f$.- The system register $s$ that will store the desired quantum state $\ket{\psi}\_s$.

```qsharp

newtype StateOracle = (((Int, Qubit[]) => Unit is Adj + Ctl));
```



## Remarks

This oracle defined by$$O\ket{0}\_{f}\ket{0}\_s= \lambda\ket{1}\_f\ket{\psi}\_s + \sqrt{1-|\lambda|^2}\ket{0}\_f\cdots,$$acts on the on computational basis state $\ket{0}\_{f}\ket{0}\_s$ to create the target state $\ket{\psi}\_s$ with amplitude $\lambda$ in the basis flagged by $\ket{1}\_f$.The first parameter is an index to the qubit register of $\ket{0}\_f$. The second parameter encompassed both registers.
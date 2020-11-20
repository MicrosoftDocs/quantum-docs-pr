---
uid: Microsoft.Quantum.Intrinsic.M
title: M operation
ms.date: 11/20/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: M
qsharp.summary: >-
  Performs a measurement of a single qubit in the
  Pauli $Z$ basis.

  The output result is given by
  the distribution
  \begin{align}
  \Pr(\texttt{Zero} | \ket{\psi}) =
  \braket{\psi | 0} \braket{0 | \psi}.
  \end{align}
---

# M operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Performs a measurement of a single qubit in thePauli $Z$ basis.The output result is given bythe distribution\begin{align}\Pr(\texttt{Zero} | \ket{\psi}) =\braket{\psi | 0} \braket{0 | \psi}.\end{align}

```qsharp
operation M (qubit : Qubit) : Result
```


## Input

### qubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit to be measured.



## Output : __invalid<Result>__

`Zero` if the $+1$ eigenvalue is observed, and `One` ifthe $-1$ eigenvalue is observed.

## Remarks

Equivalent to:```qsharpMeasure([PauliZ], [qubit]);```
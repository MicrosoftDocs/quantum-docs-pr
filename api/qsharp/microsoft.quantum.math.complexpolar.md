---
uid: Microsoft.Quantum.Math.ComplexPolar
title: ComplexPolar user defined type
ms.date: 12/4/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: ComplexPolar
qsharp.summary: >-
  Represents a complex number in polar form.

  The polar representation of a complex number is $c=r e^{i t}$.
---

# ComplexPolar user defined type

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents a complex number in polar form.The polar representation of a complex number is $c=r e^{i t}$.

```qsharp

newtype ComplexPolar = (Magnitude : Double, Argument : Double);
```



## Named Items

### Magnitude : [Double](xref:microsoft.quantum.lang-ref.double)

The absolute value $r \ge 0$ of $c$.
### Argument : [Double](xref:microsoft.quantum.lang-ref.double)

The phase $t \in \mathbb R$ of $c$.
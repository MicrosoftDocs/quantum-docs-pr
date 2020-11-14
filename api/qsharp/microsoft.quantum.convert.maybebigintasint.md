---
uid: Microsoft.Quantum.Convert.MaybeBigIntAsInt
title: MaybeBigIntAsInt function
ms.date: 11/14/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Convert
qsharp.name: MaybeBigIntAsInt
qsharp.summary: >-
  Converts a given big integer to an equivalent integer, if possible.
  The function returns a pair of the resulting integer and a Boolean flag
  which is true, if and only if the conversion was possible.
---

# MaybeBigIntAsInt function

Namespace: [Microsoft.Quantum.Convert](xref:Microsoft.Quantum.Convert)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Converts a given big integer to an equivalent integer, if possible.The function returns a pair of the resulting integer and a Boolean flagwhich is true, if and only if the conversion was possible.

```qsharp
function MaybeBigIntAsInt (a : BigInt) : (Int, Bool)
```


## Input

### a : [BigInt](xref:microsoft.quantum.lang-ref.bigint)





## Output : ([Int](xref:microsoft.quantum.lang-ref.int),[Bool](xref:microsoft.quantum.lang-ref.bool))



## Remarks

See [C# BigInteger constructor](https://docs.microsoft.com/dotnet/api/system.numerics.biginteger.-ctor?view=netframework-4.7.2#System_Numerics_BigInteger__ctor_System_Int64_) for more details.
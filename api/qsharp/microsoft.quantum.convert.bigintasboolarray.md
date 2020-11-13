---
uid: Microsoft.Quantum.Convert.BigIntAsBoolArray
title: BigIntAsBoolArray function
ms.date: 11/13/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Convert
qsharp.name: BigIntAsBoolArray
qsharp.summary: >-
  Converts a given big integer to an array of Booleans.
  The 0 element of the array is the least significant bit of the big integer.
---

# BigIntAsBoolArray function

Namespace: [Microsoft.Quantum.Convert](xref:Microsoft.Quantum.Convert)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Converts a given big integer to an array of Booleans.The 0 element of the array is the least significant bit of the big integer.

```qsharp
function BigIntAsBoolArray (a : BigInt) : Bool[]
```


## Input

### a : [BigInt](xref:microsoft.quantum.lang-ref.bigint)





## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)[]



## Remarks

See [C# BigInteger constructor](https://docs.microsoft.com/dotnet/api/system.numerics.biginteger.-ctor?view=netframework-4.7.2#System_Numerics_BigInteger__ctor_System_Int64_) for more details.
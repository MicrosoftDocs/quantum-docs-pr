---
uid: Microsoft.Quantum.Convert.BoolArrayAsBigInt
title: BoolArrayAsBigInt function
ms.date: 12/2/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Convert
qsharp.name: BoolArrayAsBigInt
qsharp.summary: >-
  Converts a given array of Booleans to an equivalent big integer.
  The 0 element of the array is the least significant bit of the big integer.
---

# BoolArrayAsBigInt function

Namespace: [Microsoft.Quantum.Convert](xref:Microsoft.Quantum.Convert)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Converts a given array of Booleans to an equivalent big integer.The 0 element of the array is the least significant bit of the big integer.

```qsharp
function BoolArrayAsBigInt (a : Bool[]) : BigInt
```


## Input

### a : [Bool](xref:microsoft.quantum.lang-ref.bool)[]





## Output : [BigInt](xref:microsoft.quantum.lang-ref.bigint)



## Remarks

See [C# BigInteger constructor](https://docs.microsoft.com/dotnet/api/system.numerics.biginteger.-ctor?view=netframework-4.7.2#System_Numerics_BigInteger__ctor_System_Int64_) for more details.
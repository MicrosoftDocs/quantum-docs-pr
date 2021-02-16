---
uid: Microsoft.Quantum.Math.ModPowL
title: ModPowL function
ms.date: 2/16/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: ModPowL
qsharp.summary: Performs modular division on a number raised to the power of another number.
---

# ModPowL function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Performs modular division on a number raised to the power of another number.

```qsharp
function ModPowL (value : BigInt, exponent : BigInt, modulus : BigInt) : BigInt
```


## Input

### value : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The value to be raised to the given exponent.


### exponent : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The exponent to which `value` is to be raised.


### modulus : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The modulus with respect to which `value ^ exponent` is to be computed.



## Output : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The result of `(value ^ exponent) % modulus`.

## Example

The following snippet computs $11^31415 \bmod 13$:```qsharplet result = ModPowL(11, 31415, 13);  // 6```

## Remarks

The implementation of this function takes the modulus at each step,making it much more efficient than `(value ^ exponent) % modulus` forlarge values of `value` and `exponent`.
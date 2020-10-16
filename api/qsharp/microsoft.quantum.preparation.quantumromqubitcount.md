---
uid: Microsoft.Quantum.Preparation.QuantumROMQubitCount
title: QuantumROMQubitCount function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: QuantumROMQubitCount
qsharp.summary: >-
  Returns the total number of qubits that must be allocated
  to the operation returned by `QuantumROM`.
---

# QuantumROMQubitCount function

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [](https://nuget.org/packages/)


Returns the total number of qubits that must be allocatedto the operation returned by `QuantumROM`.

```Q#
QuantumROMQubitCount (targetError : Double, nCoeffs : Int) : (Int, (Int, Int))
```


## Input

### targetError : Double

The target error $\epsilon$.


### nCoeffs : Int

Number of coefficients specified in `QuantumROM`.



## Output

## First parameterA tuple `(x,(y,z))` where `x = y + z` is the total number of qubits allocated,`y` is the number of qubits for the `LittleEndian` register, and `z` is the Numberof garbage qubits.
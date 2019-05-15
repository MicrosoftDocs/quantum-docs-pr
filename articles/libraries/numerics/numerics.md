---
title: Numerics Library Examples | Microsoft Docs
description: Numerics Library Examples
author: thomashaener
ms.author: thhaner
ms.date: 5/14/2019
ms.topic: article
uid: microsoft.quantum.numerics.concepts.examples
---

# Using the Numerics library

## Overview

The Numerics library consists of three components

1. **Basic integer arithmetic** with integer adders and comparators
1. **High-level integer functionality** that is built on top of the basic 
    functionality; it includes multiplication, division, inversion, etc.
    for signed and unsigned integers.
1. **Fixed-point arithmetic functionality** with fixed-point initialization,
    addition, multiplication, reciprocal, polynomial evaluation, and measurement.

All of these components can be accessed using a single `open` statement:
```qsharp
open Microsoft.Quantum.Arithmetic
```

## Types

The Numerics library supports the following types

1. **`LittleEndian`**: A qubit array `qArr : Qubit[]` that represents an integer where `qArr[0]` denotes the least significant
bit.
1. **`SignedLittleEndian`**: Same as `LittleEndian` except that it represents a signed integer stored in two's complement.
1. **`FixedPoint`**: Represents a real number consisting of a qubit array `qArr2 : Qubit[]` and a
binary point position `pos`, which counts the number of binary digits to the left of the binary point. `qArr2` is stored
in the same way as `SignedLittleEndian`.

## Operations

For each of the three types above, there are a variety of operations available:

1. **`LittleEndian`**
    1. **`AddI`**: Add two quantum integers
    1. **`CompareGTI`**: Check if the first quantum integer is greater than the second
    1. **`MultiplyI`**: Multiply two quantum integers
    1. **`SquareI`**: Compute the square of a quantum integer
    1. **`DivideI`**: Divide first quantum integer by the second (integer division with remainder)

1. **`SignedLittleEndian`**
    1. **`AddI`**: Also works for signed (2's complement) quantum integers (conversion to `LittleEndian` required)
    1. **`CompareGTSI`**: Check if the first signed quantum integer is greater than the second
    1. **`Invert2sSI`**: Invert a quantum integer modulo 2's complement
    1. **`MultiplySI`**: Multiply two signed quantum integers
    1. **`SquareSI`**: Compute the square of a signed quantum integer

1. **`FixedPoint`**
    1. **`InitFxP`**: Initialize a fixed-point number to a classical constant (double)
    1. **`AddConstantFxP`**: Add a constant to a quantum fixed-point number
    1. **`AddFxP`**: Add two fixed-point numbers
    1. **`CompareGTFxP`**: Check if the first quantum fixed-point number if greater than the second
    1. **`MultiplyFxP`**: Multiply two fixed-point numbers
    1. **`SquareFxP`**: Square a fixed-point number
    1. **`EvaluatePolynomialFxP`**: Evaluate a polynomial in fixed-point. For even/odd polynomials, there are the specializations `Evaluate[Even/Odd]PolynomialFxP`.
    1. **`ComputeReciprocalFxP`**: Compute 1/x for a quantum fixed-point number `x`
    1. **`MeasureFxP`**: Measure a fixed-point number and return a Double

For more information and detailed documentation for each of these operations, see the Q# library reference docs at [docs.microsoft.com](https://docs.microsoft.com/en-us/quantum)

## Sample: Integer addition

As a basic example, consider the operation
$$
\ket x\ket y\mapsto \ket x\ket{x+y}
$$
that is, an operation that takes an n-qubit integer $x$ and an n- or (n+1)-qubit
register $y$ as input, the latter of which it maps to the sum $(x+y)$. Note that the
sum is computed modulo $2^n$ if $y$ is stored in an $n$-bit register.

Using the QDK, this operation can be applied as follows
```qsharp
operation MyAdditionTest (xInt : Int, yInt : Int, n : Int) : Unit
{
    using ((xQubits, yQubits) = (Qubit[n], Qubit[n]))
    {
        x = LittleEndian(xQubits); // define bit order
        y = LittleEndian(yQubits);
        
        ApplyXorInPlace(xInt, x); // initialize values
        ApplyXorInPlace(yInt, y);
        
        AddI(x, y); // perform addition x+y into y
        
        // ... (use the result)
    }
}
```

## More samples

You can find more samples in the [main samples repository](https://github.com/Microsoft/Quantum).

To get started, clone the repo and open the `Numerics` subfolder:

```bash
git clone https://github.com/Microsoft/Quantum.git
cd Quantum/Numerics
```

Then, `cd` into one of the sample folders and run the sample via

```bash
cd [SampleFolder]
dotnet run
```
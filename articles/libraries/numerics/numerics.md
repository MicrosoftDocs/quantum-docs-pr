---
title: Using the Numerics Library | Microsoft Docs
description: Using the Numerics Library
author: thomashaener
ms.author: thhaner
ms.date: 5/14/2019
ms.topic: article
uid: microsoft.quantum.numerics.usage
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
open Microsoft.Quantum.Arithmetic;
```

## Types

The numerics library supports the following types

1. **`LittleEndian`**: A qubit array `qArr : Qubit[]` that represents an integer where `qArr[0]` denotes the least significant
bit.
1. **`SignedLittleEndian`**: Same as `LittleEndian` except that it represents a signed integer stored in two's complement.
1. **`FixedPoint`**: Represents a real number consisting of a qubit array `qArr2 : Qubit[]` and a
binary point position `pos`, which counts the number of binary digits to the left of the binary point. `qArr2` is stored
in the same way as `SignedLittleEndian`.

## Operations

For each of the three types above, a variety of operations is available:

1. **`LittleEndian`**
    - Addition
    - Comparison
    - Multiplication
    - Squaring
    - Division (with remainder)

1. **`SignedLittleEndian`**
    - Addition
    - Comparison
    - Inversion modulo 2's complement
    - Multiplication
    - Squaring

1. **`FixedPoint`**
    - Preparation / initialization to a classical values
    - Addition (classical constant or other quantum fixed-point)
    - Comparison
    - Multiplication
    - Squaring
    - Polynomial evaluation with specialization for even and odd functions
    - Reciprocal (1/x)
    - Measurement (classical Double)

For more information and detailed documentation for each of these operations, see the Q# library reference docs at [docs.microsoft.com](https://docs.microsoft.com/quantum)

## Sample: Integer addition

As a basic example, consider the operation
$$
\ket x\ket y\mapsto \ket x\ket{x+y}
$$
that is, an operation that takes an n-qubit integer $x$ and an n- or (n+1)-qubit
register $y$ as input, the latter of which it maps to the sum $(x+y)$. Note that the
sum is computed modulo $2^n$ if $y$ is stored in an $n$-bit register.

Using the Quantum Development Kit, this operation can be applied as follows:
```qsharp
operation TestMyAddition(xValue : Int, yValue : Int, n : Int) : Unit {
    using ((xQubits, yQubits) = (Qubit[n], Qubit[n]))
    {
        x = LittleEndian(xQubits); // define bit order
        y = LittleEndian(yQubits);
        
        ApplyXorInPlace(xValue, x); // initialize values
        ApplyXorInPlace(yValue, y);
        
        AddI(x, y); // perform addition x+y into y
        
        // ... (use the result)
    }
}
```

## Sample: Evaluating smooth functions

To evaluate smooth functions such as $\sin(x)$ on a quantum computer, where $x$ is a quantum `FixedPoint` number,
the Quantum Development Kit numerics library provides the operations `EvaluatePolynomialFxP` and `Evaluate[Even/Odd]PolynomialFxP`.

The first, `EvaluatePolynomialFxP`, allows to evaluate a polynomial of the form
$$
P(x) = a_0 + a_1x + a_2x^2 + \cdots + a_dx^d,
$$
where $d$ denotes the *degree*. To do so, all that is needed are the polynomial coefficients `[a_0,..., a_d]` (of type `Double[]`),
the input `x : FixedPoint` and the output `y : FixedPoint` (initially zero):
```qsharp
EvaluatePolynomialFxP([1.0, 2.0], x, y);
```
The result, $P(x)=1+2x$, will be stored in `yFxP`.

The second, `EvaluateEvenPolynomialFxP`, and the third, `EvaluateOddPolynomialFxP`, are specializations
for the cases of even and odd functions, respectively. That is, for an even/odd function $f(x)$ and
$$
P_{even}(x)=a_0 + a_1 x^2 + a_2 x^4 + \cdots + a_d x^{2d},
$$
$f(x)$ is approximated well by $P_{even}(x)$ or $P_{odd}(x) := x\cdot P_{even}(x)$, respectively.
In Q#, these two cases can be handled as follows:
```qsharp
EvaluateEvenPolynomialFxP([1.0, 2.0], x, y);
```
which evaluates $P_{even}(x) = 1 + 2x^2$, and
```qsharp
EvaluateOddPolynomialFxP([1.0, 2.0], x, y);
```
which evaluates $P_{odd}(x) = x + 2x^3$.

## More samples

You can find more samples in the [main samples repository](https://github.com/Microsoft/Quantum).

To get started, clone the repo and open the `Numerics` subfolder:

```bash
git clone https://github.com/Microsoft/Quantum.git
cd Quantum/Numerics
```

Then, `cd` into one of the sample folders and run the sample via

```bash
dotnet run
```

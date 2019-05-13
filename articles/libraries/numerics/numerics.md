---
title: Numerics Library Examples | Microsoft Docs
description: Numerics Library Examples
author: thomashaener
ms.author: thhaner
ms.date: 3/29/2019
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
        
        IntegerAddition(x, y); // perform addition
        
        // ... (use the result)
    }
}
```

---
title: '%kata (magic command)'
description: Executes a single test.
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.kata
ms.author: ryansha
ms.date: 11/10/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.Katas.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%kata", "Documentation": {"Summary": "Executes a single test.", "Full": null, "Description": "Executes a single test, and reports whether the test passed successfully.", "Remarks": null, "Examples": ["To run a test called `Test`:\n```\nIn []: %kata T101_StateFlip \n", "  ...: operation StateFlip (q : Qubit) : Unit is Adj + Ctl {\n", "           // The Pauli X gate will change the |0\u27e9 state to the |1\u27e9 state and vice versa.\n", "           // Type X(q);\n", "           // Then run the cell using Ctrl/\u2318+Enter.\n", "\n", "           // ...\n", "       }\nOut[]: Qubit in invalid state. Expecting: Zero\n       \tExpected:\t0\n       \tActual:\t0.5000000000000002\n       Try again!```\n"], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.Katas"}
-->

# `%kata`

## Summary

Executes a single test.

## Description

Executes a single test, and reports whether the test passed successfully.

## Examples for `%kata`

### Example 1

To run a test called `Test`:
```
In []: %kata T101_StateFlip

### Example 2

...: operation StateFlip (q : Qubit) : Unit is Adj + Ctl {

### Example 3

// The Pauli X gate will change the |0⟩ state to the |1⟩ state and vice versa.

### Example 4

// Type X(q);

### Example 5

// Then run the cell using Ctrl/⌘+Enter.

### Example 7

// ...

### Example 8

}
Out[]: Qubit in invalid state. Expecting: Zero
       	Expected:	0
       	Actual:	0.5000000000000002
       Try again!```

---
title: '%kata (magic command)'
uid: microsoft.quantum.iqsharp.magic-ref.kata
ms.date: '2020-06-02'
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.Katas.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%kata", "Documentation": {"Summary": "Executes a single test.", "Full": null, "Description": "Executes a single test, and reports whether the test passed successfully.", "Remarks": null, "Examples": ["To run a test called `Test`:\n```\nIn []: %kata T101_StateFlip_Test \n", "  ...: operation StateFlip (q : Qubit) : Unit is Adj + Ctl {\n", "           // The Pauli X gate will change the |0\u27e9 state to the |1\u27e9 state and vice versa.\n", "           // Type X(q);\n", "           // Then run the cell using Ctrl/\u2318+Enter.\n", "\n", "           // ...\n", "       }\nOut[]: Qubit in invalid state. Expecting: Zero\n       \tExpected:\t0\n       \tActual:\t0.5000000000000002\n       Try again!```\n"], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.Katas"}
-->

# `%kata`

## Summary

Executes a single test.

## Description

Executes a single test, and reports whether the test passed successfully.

## Example

To run a test called `Test`:
```
In []: %kata T101_StateFlip_Test

## Example

...: operation StateFlip (q : Qubit) : Unit is Adj + Ctl {

## Example

// The Pauli X gate will change the |0⟩ state to the |1⟩ state and vice versa.

## Example

// Type X(q);

## Example

// Then run the cell using Ctrl/⌘+Enter.

## Example

// ...

## Example

}
Out[]: Qubit in invalid state. Expecting: Zero
       	Expected:	0
       	Actual:	0.5000000000000002
       Try again!```

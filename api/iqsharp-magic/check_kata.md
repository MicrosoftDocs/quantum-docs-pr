---
title: '%check_kata (magic command)'
uid: microsoft.quantum.iqsharp.magic-ref.check_kata
ms.date: '2020-06-02'
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.Katas.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%check_kata", "Documentation": {"Summary": "Checks the reference implementation for a single kata's test.", "Full": null, "Description": "Substitutes the reference implementation for a single task into the cell, and reports whether the test passed successfully using the reference implementation.", "Remarks": null, "Examples": ["To check a test called `Test`:\n```\nIn []: %check_kata T101_StateFlip_Test \n", "  ...: operation StateFlip (q : Qubit) : Unit is Adj + Ctl {\n", "           // The Pauli X gate will change the |0\u27e9 state to the |1\u27e9 state and vice versa.\n", "           // Type X(q);\n", "           // Then run the cell using Ctrl/\u2318+Enter.\n", "\n", "           // ...\n", "       }\nOut[]: Success!```\n"], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.Katas"}
-->

# `%check_kata`

## Summary

Checks the reference implementation for a single kata's test.

## Description

Substitutes the reference implementation for a single task into the cell, and reports whether the test passed successfully using the reference implementation.

## Example

To check a test called `Test`:
```
In []: %check_kata T101_StateFlip_Test

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
Out[]: Success!```

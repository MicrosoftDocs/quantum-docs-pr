---
title: '%lsopen (magic command)'
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.lsopen
ms.author: rmshaffer
ms.date: 08/22/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.Kernel.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%lsopen", "Documentation": {"Summary": "Lists currently opened namespaces and their aliases.", "Full": null, "Description": "\r\nThis magic command lists any namespaces that have been made\r\navailable using `open` statements, along with any aliases\r\nthat may have been assigned to those namespaces.\r\n                ", "Remarks": null, "Examples": ["\r\nPrint a list of all currently opened namespaces:\r\n```\r\nIn []: %lsopen\r\nOut[]: Namespace                     Alias\r\n       ----------------------------- ----\r\n       Microsoft.Quantum.Canon\r\n       Microsoft.Quantum.Diagnostics Diag\r\n       Microsoft.Quantum.Intrinsic\r\n```\r\n                    "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.Kernel"}
-->

# `%lsopen`

## Summary

Lists currently opened namespaces and their aliases.

## Description

This magic command lists any namespaces that have been made
available using `open` statements, along with any aliases
that may have been assigned to those namespaces.

## Example

Print a list of all currently opened namespaces:
```
In []: %lsopen
Out[]: Namespace                     Alias
       ----------------------------- ----
       Microsoft.Quantum.Canon
       Microsoft.Quantum.Diagnostics Diag
       Microsoft.Quantum.Intrinsic
```

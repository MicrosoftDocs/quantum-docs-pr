---
title: '%who (magic command)'
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.who
ms.author: rmshaffer
ms.date: 08/27/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.Kernel.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%who", "Documentation": {"Summary": "Lists the Q# operations available in the current session.", "Full": null, "Description": "\r\nThis magic command returns a list of Q# operations and functions that are available\r\nin the current IQ# session for use with magic commands such as `%simulate`\r\nand `%estimate`.\r\n\r\nThe list will include Q# operations and functions which have been defined interactively\r\nwithin cells in the current notebook (after the cells have been executed),\r\nas well as any Q# operations and functions defined within .qs files in the current folder.\r\n                ", "Remarks": null, "Examples": ["\r\nDisplay the list of Q# operations and functions available in the current session:\r\n```\r\nIn []: %who\r\nOut[]: <list of Q# operation and function names>\r\n```\r\n                    "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.Kernel"}
-->

# `%who`

## Summary

Lists the Q# operations available in the current session.

## Description

This magic command returns a list of Q# operations and functions that are available
in the current IQ# session for use with magic commands such as `%simulate`
and `%estimate`.

The list will include Q# operations and functions which have been defined interactively
within cells in the current notebook (after the cells have been executed),
as well as any Q# operations and functions defined within .qs files in the current folder.

## Example

Display the list of Q# operations and functions available in the current session:
```
In []: %who
Out[]: <list of Q# operation and function names>
```

---
title: '%workspace (magic command)'
description: Provides actions related to the current workspace.
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.workspace
ms.author: ryansha
ms.date: 01/06/2021
ms.topic: managed-reference
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.Kernel.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%workspace", "Documentation": {"Summary": "Provides actions related to the current workspace.", "Full": null, "Description": "\r\nThis magic command allows for displaying and reloading the Q# operations and functions\r\ndefined within .qs files in the current folder.\r\n\r\nIf no parameters are provided, the command displays a list of Q# operations or functions\r\nwithin .qs files in the current folder which are available\r\nin the current IQ# session for use with magic commands such as `%simulate`\r\nand `%estimate`.\r\n\r\nThe command will also output any errors encountered while compiling the .qs files\r\nin the current folder.\r\n\r\n#### Optional parameters\r\n\r\n- `reload`: Causes the IQ# kernel to recompile all .qs files in the current folder.\r\n                ", "Remarks": null, "Examples": ["\r\nDisplay the list of Q# operations and functions available in the current folder:\r\n```\r\nIn []: %workspace\r\nOut[]: <list of Q# operation and function names>\r\n```\r\n                    ", "\r\nRecompile the .qs files in the current folder:\r\n```\r\nIn []: %workspace reload\r\nOut[]: <list of Q# operation and function names>\r\n```\r\n                    "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.Kernel"}
-->

# `%workspace`

## Summary

Provides actions related to the current workspace.

## Description

This magic command allows for displaying and reloading the Q# operations and functions
defined within .qs files in the current folder.

If no parameters are provided, the command displays a list of Q# operations or functions
within .qs files in the current folder which are available
in the current IQ# session for use with magic commands such as `%simulate`
and `%estimate`.

The command will also output any errors encountered while compiling the .qs files
in the current folder.

#### Optional parameters

- `reload`: Causes the IQ# kernel to recompile all .qs files in the current folder.

## Examples for `%workspace`

### Example 1

Display the list of Q# operations and functions available in the current folder:
```
In []: %workspace
Out[]: <list of Q# operation and function names>
```

### Example 2

Recompile the .qs files in the current folder:
```
In []: %workspace reload
Out[]: <list of Q# operation and function names>
```

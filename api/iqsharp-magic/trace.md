---
title: '%trace (magic command)'
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.trace
ms.author: rmshaffer
ms.date: 09/16/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.Kernel.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%trace", "Documentation": {"Summary": "Visualizes the execution path of the given operation.", "Full": null, "Description": "\r\nThis magic command renders an HTML-based visualization of a runtime execution path of the\r\ngiven operation using the QuantumSimulator.\r\n\r\n#### Required parameters\r\n\r\n- Q# operation or function name. This must be the first parameter, and must be a valid Q# operation\r\nor function name that has been defined either in the notebook or in a Q# file in the same folder.\r\n- Arguments for the Q# operation or function must also be specified as `key=value` pairs.\r\n\r\n#### Optional parameters\r\n\r\n- `--depth=<integer>` (default=1): The depth at which to render operations along\r\nthe execution path.\r\n                ", "Remarks": null, "Examples": ["\r\nVisualize the execution path of a Q# operation defined as `operation MyOperation() : Result`:\r\n```\r\nIn []: %trace MyOperation\r\nOut[]: <HTML visualization of the operation>\r\n```\r\n                    ", "\r\nVisualize the execution path of a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`:\r\n```\r\nIn []: %trace MyOperation a=5 b=10\r\nOut[]: <HTML visualization of the operation>\r\n```\r\n                    ", "\r\nVisualize operations at depth 2 on the execution path of a Q# operation defined\r\nas `operation MyOperation() : Result`:\r\n```\r\nIn []: %trace MyOperation --depth=2\r\nOut[]: <HTML visualization of the operation>\r\n```\r\n                    "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.Kernel"}
-->

# `%trace`

## Summary

Visualizes the execution path of the given operation.

## Description

This magic command renders an HTML-based visualization of a runtime execution path of the
given operation using the QuantumSimulator.

#### Required parameters

- Q# operation or function name. This must be the first parameter, and must be a valid Q# operation
or function name that has been defined either in the notebook or in a Q# file in the same folder.
- Arguments for the Q# operation or function must also be specified as `key=value` pairs.

#### Optional parameters

- `--depth=<integer>` (default=1): The depth at which to render operations along
the execution path.

## Example

Visualize the execution path of a Q# operation defined as `operation MyOperation() : Result`:
```
In []: %trace MyOperation
Out[]: <HTML visualization of the operation>
```

## Example

Visualize the execution path of a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`:
```
In []: %trace MyOperation a=5 b=10
Out[]: <HTML visualization of the operation>
```

## Example

Visualize operations at depth 2 on the execution path of a Q# operation defined
as `operation MyOperation() : Result`:
```
In []: %trace MyOperation --depth=2
Out[]: <HTML visualization of the operation>
```

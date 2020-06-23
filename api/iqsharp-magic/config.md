---
title: '%config (magic command)'
uid: microsoft.quantum.iqsharp.magic-ref.config
ms.date: '2020-06-02'
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.Kernel.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%config", "Documentation": {"Summary": "Allows setting or querying configuration options.", "Full": null, "Description": "\r\nThis magic command allows for setting or querying\r\nconfiguration options used to control the behavior of the\r\nIQ# kernel (e.g.: state visualization options), and to\r\nsave those options to a JSON file in the current working\r\ndirectory.\r\n                ", "Remarks": null, "Examples": ["\r\n                        Print a list of all currently set configuration options:\r\n                        ```\r\n                        In []: %config\r\n                        Out[]: Configuration key                 Value\r\n                               --------------------------------- -----------\r\n                               dump.basisStateLabelingConvention \"BigEndian\"\r\n                               dump.truncateSmallAmplitudes      true\r\n                        ```\r\n                    ", "\r\nConfigure the `DumpMachine` and `DumpRegister` callables\r\nto use big-endian convention:\r\n```\r\nIn []: %config dump.basisStateLabelingConvention = \"BigEndian\"\r\nOut[]: \"BigEndian\"\r\n```\r\n                    ", "\r\nSave current configuration options to `.iqsharp-config.json`\r\nin the current working directory:\r\n```\r\nIn []: %config --save\r\nOut[]: \r\n```\r\nNote that options saved this way will be applied automatically\r\nthe next time a notebook in the current working\r\ndirectory is loaded.\r\n                    "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.Kernel"}
-->

# `%config`

## Summary

Allows setting or querying configuration options.

## Description

This magic command allows for setting or querying
configuration options used to control the behavior of the
IQ# kernel (e.g.: state visualization options), and to
save those options to a JSON file in the current working
directory.

## Example

Print a list of all currently set configuration options:
                        ```
                        In []: %config
                        Out[]: Configuration key                 Value
                               --------------------------------- -----------
                               dump.basisStateLabelingConvention "BigEndian"
                               dump.truncateSmallAmplitudes      true
                        ```

## Example

Configure the `DumpMachine` and `DumpRegister` callables
to use big-endian convention:
```
In []: %config dump.basisStateLabelingConvention = "BigEndian"
Out[]: "BigEndian"
```

## Example

Save current configuration options to `.iqsharp-config.json`
in the current working directory:
```
In []: %config --save
Out[]:
```
Note that options saved this way will be applied automatically
the next time a notebook in the current working
directory is loaded.

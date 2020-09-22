---
title: '%performance (magic command)'
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.performance
ms.author: rmshaffer
ms.date: 09/22/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.Kernel.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%performance", "Documentation": {"Summary": "Reports current performance metrics for this kernel.", "Full": null, "Description": "\r\nReports various performance metrics for the current IQ# kernel process, including:\r\n\r\n- Managed RAM usage\r\n- Total RAM usage\r\n- Virtual memory size\r\n- User time\r\n- Total time\r\n                ", "Remarks": null, "Examples": ["\r\nDisplay performance metrics for the current IQ# kernel process:\r\n```\r\nIn []: %performance\r\nOut[]: Metric                        Value\r\n       ----------------------------  -------------\r\n       Managed RAM usage (bytes)     4.985 MiB\r\n       Total RAM usage (bytes)       54.543 MiB\r\n       Virtual memory size (bytes)   2.005 TiB\r\n       User time                     00:00:01.109\r\n       Total time                    00:00:01.437\r\n```\r\n                    "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.Kernel"}
-->

# `%performance`

## Summary

Reports current performance metrics for this kernel.

## Description

Reports various performance metrics for the current IQ# kernel process, including:

- Managed RAM usage
- Total RAM usage
- Virtual memory size
- User time
- Total time

## Example

Display performance metrics for the current IQ# kernel process:
```
In []: %performance
Out[]: Metric                        Value
       ----------------------------  -------------
       Managed RAM usage (bytes)     4.985 MiB
       Total RAM usage (bytes)       54.543 MiB
       Virtual memory size (bytes)   2.005 TiB
       User time                     00:00:01.109
       Total time                    00:00:01.437
```

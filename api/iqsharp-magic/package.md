---
title: '%package (magic command)'
description: Provides the ability to load a NuGet package.
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.package
ms.author: ryansha
ms.date: 11/11/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.Kernel.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%package", "Documentation": {"Summary": "Provides the ability to load a NuGet package.", "Full": null, "Description": "\r\nThis magic command allows for loading a NuGet package into the current IQ# kernel process.\r\nThe package must be available on the system's list of NuGet sources, which typically includes nuget.org.\r\nQ# operations, functions, and user-defined types defined in the loaded package,\r\nalong with functionality such as magic commands and result encoders,\r\nwill automatically become available for use in the current session.\r\n\r\nThe package can be specified by name only, or by name and version (using `name::version` syntax).\r\n\r\nIf no version is specified:\r\n\r\n- For packages that are part of the Microsoft Quantum Development Kit, IQ# will attempt to\r\nobtain the version of the package that matches the current IQ# version.\r\n- For other packages, IQ# will attempt to obtain the most recent version of the package.\r\n                ", "Remarks": null, "Examples": ["\r\nLoad the `Microsoft.Quantum.MachineLearning` package into the current IQ# session:\r\n```\r\nIn []: %package Microsoft.Quantum.MachineLearning\r\nOut[]: Adding package Microsoft.Quantum.MachineLearning: done!\r\n       <list of all loaded packages and versions>\r\n```\r\n                    ", "\r\nLoad a specific version of the `Microsoft.Quantum.Katas` package into the current IQ# session:\r\n```\r\nIn []: %package Microsoft.Quantum.Katas::0.11.2006.403\r\nOut[]: Adding package Microsoft.Quantum.Katas::0.11.2006.403: done!\r\n       <list of all loaded packages and versions>\r\n```\r\n                    ", "\r\nView the list of all packages that have been loaded into the current IQ# session:\r\n```\r\nIn []: %package\r\nOut[]: <list of all loaded packages and versions>\r\n```\r\n                    "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.Kernel"}
-->

# `%package`

## Summary

Provides the ability to load a NuGet package.

## Description

This magic command allows for loading a NuGet package into the current IQ# kernel process.
The package must be available on the system's list of NuGet sources, which typically includes nuget.org.
Q# operations, functions, and user-defined types defined in the loaded package,
along with functionality such as magic commands and result encoders,
will automatically become available for use in the current session.

The package can be specified by name only, or by name and version (using `name::version` syntax).

If no version is specified:

- For packages that are part of the Microsoft Quantum Development Kit, IQ# will attempt to
obtain the version of the package that matches the current IQ# version.
- For other packages, IQ# will attempt to obtain the most recent version of the package.

## Examples for `%package`

### Example 1

Load the `Microsoft.Quantum.MachineLearning` package into the current IQ# session:
```
In []: %package Microsoft.Quantum.MachineLearning
Out[]: Adding package Microsoft.Quantum.MachineLearning: done!
       <list of all loaded packages and versions>
```

### Example 2

Load a specific version of the `Microsoft.Quantum.Katas` package into the current IQ# session:
```
In []: %package Microsoft.Quantum.Katas::0.11.2006.403
Out[]: Adding package Microsoft.Quantum.Katas::0.11.2006.403: done!
       <list of all loaded packages and versions>
```

### Example 3

View the list of all packages that have been loaded into the current IQ# session:
```
In []: %package
Out[]: <list of all loaded packages and versions>
```

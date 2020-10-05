---
title: '%project (magic command)'
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.project
ms.author: rmshaffer
ms.date: 10/05/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.Kernel.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%project", "Documentation": {"Summary": "Provides the ability to view or add Q# project references.", "Full": null, "Description": "\r\nThis magic command allows for adding references to Q# projects to be compiled and loaded\r\ninto the current IQ# session.\r\n\r\nThe command accepts a single argument, which is the path to a .csproj file to be loaded.\r\nThe .csproj file must reference the Microsoft.Quantum.Sdk. The provided path may be either\r\nan absolute path or a path relative to the current workspace root folder (usually the\r\nfolder containing the current .ipynb file). The project file will be added to the session\r\nand then the workspace will be reloaded, which will automatically load any downstream\r\npackages or projects referenced by the specified .csproj file and will recompile all\r\nassociated .qs source files.\r\n\r\nIf no argument is provided, the command simply returns the list of projects loaded in\r\nthe current IQ# session.\r\n                ", "Remarks": null, "Examples": ["\r\nAdd a reference to the `C:\\Projects\\MyProject.csproj` Q# project into the current IQ# session:\r\n```\r\nIn []: %project C:\\Projects\\MyProject.csproj\r\nOut[]: Loading project C:\\Projects\\MyProject.csproj and dependencies...\r\n       <list of all loaded Q# project references>\r\n```\r\n                    ", "\r\nView the list of all Q# project references that have been loaded into the current IQ# session:\r\n```\r\nIn []: %project\r\nOut[]: <list of all loaded Q# project references>\r\n```\r\n                    "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.Kernel"}
-->

# `%project`

## Summary

Provides the ability to view or add Q# project references.

## Description

This magic command allows for adding references to Q# projects to be compiled and loaded
into the current IQ# session.

The command accepts a single argument, which is the path to a .csproj file to be loaded.
The .csproj file must reference the Microsoft.Quantum.Sdk. The provided path may be either
an absolute path or a path relative to the current workspace root folder (usually the
folder containing the current .ipynb file). The project file will be added to the session
and then the workspace will be reloaded, which will automatically load any downstream
packages or projects referenced by the specified .csproj file and will recompile all
associated .qs source files.

If no argument is provided, the command simply returns the list of projects loaded in
the current IQ# session.

## Example

Add a reference to the `C:\Projects\MyProject.csproj` Q# project into the current IQ# session:
```
In []: %project C:\Projects\MyProject.csproj
Out[]: Loading project C:\Projects\MyProject.csproj and dependencies...
       <list of all loaded Q# project references>
```

## Example

View the list of all Q# project references that have been loaded into the current IQ# session:
```
In []: %project
Out[]: <list of all loaded Q# project references>
```

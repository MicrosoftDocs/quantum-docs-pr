---
title: internal
description: Keyword reference internal
author: gillenhaalb
ms.author: a-gibec
ms.date: 09/20/2020
ms.topic: article
uid: microsoft.quantum.lang-ref.internal
---

# `internal`

In many cases, a callable or type name is intended strictly for use internal to a library or project, and is not a guaranteed part of the API offered by a library.
It is helpful to clearly indicate that this is the case when naming functions and operations so that accidental dependencies on internal-only code are made obvious.
If an operation or function is not intended for direct use, but rather should be used by a matching callable which acts by partial application, consider using a name starting with the `internal` keyword for the callable that is partially applied.

As per the Style Guide, we suggest:

- When a function, operation, or user-defined type is not a part of the public API for a Q# library or program, ensure that it is marked as internal by placing the `internal` keyword before the `function`, `operation`, or `newtype` declaration.

## Examples

```qsharp
internal operation OpName(...) : Unit {
    /// ...
}
```

The `internal` keyword at the beginning clearly indicates that this operation is for internal use only.


## Locations in documentation

- [Style Guide: Naming Conventions](xref:microsoft.quantum.contributing.style#private-or-internal-names). 

<!-- Maybe the following? page is empty so unsure -->
- Q# language repository: [Access Modifiers](https://github.com/microsoft/qsharp-language/blob/main/Specifications/Language/1_ProgramStructure/6_AccessModifiers.md#access-modifiers)
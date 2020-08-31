---
title: '%config (magic command)'
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.config
ms.author: rmshaffer
ms.date: 08/31/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.Kernel.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%config", "Documentation": {"Summary": "Allows setting or querying configuration options.", "Full": null, "Description": "\r\nThis magic command allows for setting or querying\r\nconfiguration options used to control the behavior of the\r\nIQ# kernel (such as state visualization options). It also\r\nallows for saving those options to a JSON file in the current\r\nworking directory (using the `--save` option).\r\n\r\n#### Configuration settings\r\n\r\n**`dump.basisStateLabelingConvention`**\r\n\r\n**Value:** `\"LittleEndian\"` (default), `\"BigEndian\"`, or `\"Bitstring\"`\r\n\r\nThe convention to be used when labeling computational\r\nbasis states in output from callables such as `DumpMachine` or `DumpRegister`.\r\n\r\n**`dump.truncateSmallAmplitudes`**\r\n\r\n**Value:** `true` or `false` (default)\r\n\r\nHides basis states of a state vector whose measurement probabilities\r\n(i.e., squared amplitudes) are smaller than a particular threshold, as determined by\r\nthe `dump.truncationThreshold` setting.\r\n\r\n**`dump.truncationThreshold`**\r\n\r\n**Value:** floating point number such as `0.001` or `1E-8` (default `1E-10`)\r\n\r\nIf `dump.truncateSmallAmplitudes` is set to `true`, determines the\r\nthreshold for measurement probabilities (i.e., squared amplitudes) below which to hide the display\r\nof basis states of a state vector.\r\n\r\n**`dump.phaseDisplayStyle`**\r\n\r\n**Value:** `\"ArrowOnly\"` (default), `\"NumberOnly\"`, `\"ArrowAndNumber\"`, or `\"None\"`\r\n\r\nConfigures the phase visualization style in output from callables such as\r\n`DumpMachine` or `DumpRegister`. Supports displaying phase as arrows, numbers (in radians), both, or neither.\r\n\r\n**`trace.defaultDepth`**\r\n\r\n**Value:** positive integer (default `1`)\r\n\r\nConfigures the default depth used in the `%trace` command for visualizing Q# operations.\r\n\r\n**`trace.style`**\r\n\r\n**Value:** `\"Default\"` (default), `\"BlackAndWhite\"`, or `\"Inverted\"`\r\n\r\nConfigures the default style used in generating the visualization of Q# operations with the `%trace` command.\r\n                ", "Remarks": null, "Examples": ["\r\nPrint a list of all currently set configuration options:\r\n```\r\nIn []: %config\r\nOut[]: Configuration key                 Value\r\n       --------------------------------- -----------\r\n       dump.basisStateLabelingConvention \"BigEndian\"\r\n       dump.truncateSmallAmplitudes      true\r\n```\r\n                    ", "\r\nConfigure the `DumpMachine` and `DumpRegister` callables\r\nto use big-endian convention:\r\n```\r\nIn []: %config dump.basisStateLabelingConvention=\"BigEndian\"\r\nOut[]: \"BigEndian\"\r\n```\r\n                    ", "\r\nSave current configuration options to `.iqsharp-config.json`\r\nin the current working directory:\r\n```\r\nIn []: %config --save\r\nOut[]: \r\n```\r\nNote that options saved this way will be applied automatically\r\nthe next time a notebook in the current working\r\ndirectory is loaded.\r\n                    "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.Kernel"}
-->

# `%config`

## Summary

Allows setting or querying configuration options.

## Description

This magic command allows for setting or querying
configuration options used to control the behavior of the
IQ# kernel (such as state visualization options). It also
allows for saving those options to a JSON file in the current
working directory (using the `--save` option).

#### Configuration settings

**`dump.basisStateLabelingConvention`**

**Value:** `"LittleEndian"` (default), `"BigEndian"`, or `"Bitstring"`

The convention to be used when labeling computational
basis states in output from callables such as `DumpMachine` or `DumpRegister`.

**`dump.truncateSmallAmplitudes`**

**Value:** `true` or `false` (default)

Hides basis states of a state vector whose measurement probabilities
(i.e., squared amplitudes) are smaller than a particular threshold, as determined by
the `dump.truncationThreshold` setting.

**`dump.truncationThreshold`**

**Value:** floating point number such as `0.001` or `1E-8` (default `1E-10`)

If `dump.truncateSmallAmplitudes` is set to `true`, determines the
threshold for measurement probabilities (i.e., squared amplitudes) below which to hide the display
of basis states of a state vector.

**`dump.phaseDisplayStyle`**

**Value:** `"ArrowOnly"` (default), `"NumberOnly"`, `"ArrowAndNumber"`, or `"None"`

Configures the phase visualization style in output from callables such as
`DumpMachine` or `DumpRegister`. Supports displaying phase as arrows, numbers (in radians), both, or neither.

**`trace.defaultDepth`**

**Value:** positive integer (default `1`)

Configures the default depth used in the `%trace` command for visualizing Q# operations.

**`trace.style`**

**Value:** `"Default"` (default), `"BlackAndWhite"`, or `"Inverted"`

Configures the default style used in generating the visualization of Q# operations with the `%trace` command.

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
In []: %config dump.basisStateLabelingConvention="BigEndian"
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

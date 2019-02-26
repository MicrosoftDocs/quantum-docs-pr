---
title: Getting Started with Python and Q#
author: cpalmer
uid: microsoft.quantum.install.python
ms.author: cpalmer@microsoft.com
ms.date: 2/25/19
ms.topic: article
---

# Getting Started with Python and the Quantum Development Kit #  

The qsharp package for Python provides interoperability with the Quantum Development Kit and with the Q# language, making it easy to simulate Q# operations and functions from within Python.  

## Installation ##

To get started with the `qsharp` package, you'll need a couple prerequisites:

- .NET Core SDK 2.1.3 or later,
- Python 3.6 or later,
- Jupyter, and
- The IQ# kernel for Jupyter.

To install the .NET Core SDK, please follow the instructions from the [.NET downloads page](https://www.microsoft.com/net/download).

To install Python and Jupyter, we recommend using the Anaconda distribution of Python.
Please see https://www.anaconda.com/distribution/ for more details.
On other distributions of Python, the Jupyter platform can be installed using `pip install jupyter`.

Finally, the IQ# kernel for Jupyter must be installed using the `dotnet` command line tool:

```
dotnet tool install -g Microsoft.Quantum.IQSharp
dotnet iqsharp install
```

## Usage ##

Please see the [README](https://github.com/Microsoft/Quantum/tree/master/Samples/src/PythonInterop/README.md) file provided with the Python sample for more details.

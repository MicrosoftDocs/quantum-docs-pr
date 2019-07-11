---
title: Getting Started with Jupyter Notebooks and Q#
uid: microsoft.quantum.install.jupyter
author: anpaz-msft
ms.author: anpaz@microsoft.com
ms.date: 3/27/19
ms.topic: article
---

# Getting Started with Jupyter Notebooks and the Quantum Development Kit #  

The Quantum Development Kit provides a Jupyter kernel for the Q# language, making it easy to write and simulate quantum algorithms using Q# interactively from a web browser.

## Pre-requisites ##

To get started you need:
- IQ#
- Jupyter,

### Installing IQ# ##

IQ# (pronounced i-q-sharp) provides the core functionality of compiling and simulating Q# operations for Jupyter and Python.
Installing IQ# on your machine typically takes less than 10 minutes; just follow these two steps:

1. Install the latest version of the [.NET Core SDK](https://dotnet.microsoft.com/) (2.2 or later) by 
  following the instructions from the [.NET downloads page](https://www.microsoft.com/net/download).
2. From the command line, execute:
   ```Command Prompt
   dotnet tool install -g Microsoft.Quantum.IQSharp
   ```

Your installation of the Quantum Development Kit is now complete!

To verify IQ# was correctly installed, from the command line type: `dotnet iqsharp --version`. You should see the IQ# version reported on the output, for example:
```
C:\>dotnet iqsharp --version
Language kernel: 0.5.1903.2501
Jupyter core: 1.1.12077.0
```

> [!NOTE]
> IQ# requires a 64-bit installation of Windows 10, macOS, or Linux.
>
> Microsoft's quantum simulator, installed with the Quantum Development Kit, utilizes Advance Vector Extensions (AVX), 
> and thus can run significantly more efficiently on an AVX-enabled CPU.
> The Quantum Development Kit will still run on non–AVX enabled CPUs, but may not be as efficient.
> Intel processors shipped in Q1 2011 (Sandy Bridge) or later support AVX.
>
> Microsoft's quantum simulator utilizes OpenMP at runtime, on Linux systems you might need to manually install `libgomp`.
> See [this thread](https://stackoverflow.com/questions/52428334/unable-to-load-dll-microsoft-quantum-simulator-runtime-dll-centos-7) at stackoverflow.

### Updating IQ# ###

To update IQ# to the latest version, from the command line, execute:
```Command Prompt
dotnet tool update -g Microsoft.Quantum.IQSharp
```

### Installing Jupyter ###

To install Jupyter, follow the instructions provided at https://jupyter.org/install.


## Installation ##

Install the `qsharp` Jupyter kernel from the command line using these two commands:

```Command Prompt
dotnet tool install -g Microsoft.Quantum.IQSharp
dotnet iqsharp install
```

To verify IQ# was correctly installed, from the command line type: `dotnet iqsharp --version`. You should see the IQ# version reported on the output, for example:
```
C:\>dotnet iqsharp --version
Language kernel: 0.5.1903.2501
Jupyter core: 1.1.12077.0
```

## Usage ##

Once installed, start jupyter notebook from the command line using:

```Command Prompt
jupyter notebook
```

Once started, on the web browser click "New" and select `Q#` to create a new Notebook using the `Q#` kernel.

For details on how to write an interactive Q# notebook, take a look at
[Q# Notebooks](https://github.com/Microsoft/Quantum/blob/master/Samples/src/IntroToIQSharp/Notebook.ipynb)
from our [GitHub Quantum repository](https://github.com/Microsoft/Quantum.git).


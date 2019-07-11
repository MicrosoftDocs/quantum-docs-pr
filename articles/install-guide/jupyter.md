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
- **.NET Core SDK 2.2 or later**,
- **Python 3.6 or later**,

To install the latest version of [.NET Core SDK](https://dotnet.microsoft.com/), follow the instructions from the [.NET downloads page](https://www.microsoft.com/net/download).
  
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


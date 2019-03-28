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

Before installing the Q# Jupyter kernel, you'll need the following pre-requisites:
- IQ#.
- Jupyter

IQ# provides the core functionality of compiling and simulating Q# operations.
Installing IQ# on your machine typically takes less than 10 minutes; just follow these two steps:
1. Install the latest version of [.NET Core SDK](https://dotnet.microsoft.com/) (2.1 or later) by 
  following the instructions from the [.NET downloads page](https://www.microsoft.com/net/download).
2. From the command line, execute:
   ```Command prompt
   dotnet tool install -g Microsoft.Quantum.IQSharp

To install Jupyter, follow the instructions provided at https://jupyter.org/install.


## Installation ##

Once IQ# and Jupyter are installed, install the `Q#` Jupyter kernel from the command line using:

```Command Prompt
dotnet iqsharp install
```


## Usage ##

Once the `Q#` Jupyter kernel is installed, start jupyter notebook from the command line using:

```Command Prompt
jupyter notebook
```

Once started, on the web browser click "New" and select `Q#` to create a new Notebook using the `Q#` kernel.

For details on how to write an interactive Q# notebook, take a look at
[Q# Notebooks](https://github.com/Microsoft/Quantum/blob/master/Samples/src/IntroToIQSharp/Notebook.ipynb)
from our [GitHub Quantum repository](https://github.com/Microsoft/Quantum.git).


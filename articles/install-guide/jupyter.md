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
- IQ#.
- Jupyter

[!INCLUDE [Installing IQ#](../installingiqsharp.md)]

To install Jupyter, follow the instructions provided at https://jupyter.org/install.


## Installation ##

Install the `qsharp` Jupyter kernel from the command line using:

```Command Prompt
dotnet iqsharp install
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


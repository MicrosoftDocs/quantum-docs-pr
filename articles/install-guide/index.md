---
title: Getting Started with the Microsoft Quantum Development Kit
author: anpaz-msft
ms.author: andres.paz@microsoft.com 
ms.date: 3/26/2019
ms.topic: article
uid: microsoft.quantum.install
---

# Getting Started with the Microsoft Quantum Development Kit #

A great way to get started with Q# before installing the Quantum Development Kit is via some of the Jupyter notebooks available in our [GitHub Quantum repository](https://github.com/Microsoft/Quantum.git).  In particular:

* **[Q# Notebooks](https://github.com/Microsoft/Quantum/tree/master/Samples/src/IntroToIQSharp/Notebook.ipynb)** [(Run online)](https://mybinder.org/v2/gh/Microsoft/Quantum/master?filepath=Samples%2Fsrc%2FIntroToIQSharp%2FNotebook.ipynb) : explains how to compile and simulate Q# operations inside a Jupyter notebook.
* **[Teleport](https://github.com/Microsoft/Quantum/tree/master/Samples/src/Teleportation/Notebook.ipynb)** ([Run online)](https://mybinder.org/v2/gh/microsoft/Quantum/master?filepath=Samples%2Fsrc%2FTeleportation%2FNotebook.ipynb): shows how to implement the teleport algorithm using Q#.

To run these interactively, install IQ# on your machine (see below) and take a look at our [Jupyter notebooks getting started guide](xref:microsoft.quantum.install.jupyter).



## Classical Hosts ##

Applications developed with Microsoft's Quantum Development Kit typically consists of two parts:
1. One or more quantum algorithms, implemented using the Q# quantum programming language.
2. A classical program, implemented in a classical programming language like Python or C#, 
  that serves as the main entry point and will invoke Q# operations 
  when it wants to execute a quantum algorithm.

Once you have installed IQ#, these articles explain how to enable interoperability between Q# and classical languages:

* [C# getting started](xref:microsoft.quantum.install.csharp)
* [Jupyter notebooks getting started](xref:microsoft.quantum.install.jupyter)
* [Python getting started](xref:microsoft.quantum.install.python)

## Editor extensions ##

The Quantum Development Kit offers extensions to [Visual Studio](https://visualstudio.microsoft.com/vs/) 
and [Visual Studio Code](https://code.visualstudio.com/) to improve the development experience. 
These extensions are available from [Visual Studio's Marketplace](https://marketplace.visualstudio.com/) 
and provide features like:
* Code colorization and highlighting
* Live diagnostics
* Document symbols
* Documentation on hover
* Signature help
* Go to symbol definition
* Find all references
* Rename of symbols
* Code actions (e.g. namespace import helper)
* Debug breakpoints (Visual Studio)

To install the extensions, follow the instructions at:
> [!div class="button"]
> [Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit)

> [!div class="button"]
> [Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode)



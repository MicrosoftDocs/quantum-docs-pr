---
title: Getting Started with the Microsoft Quantum Development Kit
author: anpaz-msft
ms.author: andres.paz@microsoft.com 
ms.date: 3/26/2019
ms.topic: article
uid: microsoft.quantum.install
---

# Getting Started with the Microsoft Quantum Development Kit #

A great way to get started with the Quantum Development Kit is via some of the Jupyter notebooks from our GitHub Quantum repository.
You can launch these notebooks from your browser without any installation using [binder](https://mybinder.org).  In particular:

* **[Q# Notebooks](https://mybinder.org/v2/gh/Microsoft/Quantum/master?filepath=Samples%2Fsrc%2FIntroToIQSharp%2FNotebook.ipynb)**: explains how to compile and simulate Q# operations inside a Jupyter notebook.
* **[Teleport](https://mybinder.org/v2/gh/Microsoft/Quantum/master?filepath=Samples%2Fsrc%2FTeleportation%2FNotebook.ipynb)**: shows how to implement the teleport algorithm using Q#.

To launch these notebooks from your computer, to create new ones, or to 
integrate Q# with other classical languages like C# or Python, 
you will need to install the Quantum Development Kit either via the command line or Visual Studio.


## Installation ##

#### [Command Line](#tab/tabid-cmdline)

IQ# (pronounced i-q-sharp) is a local service that provides the core functionality needed
to compile and simulate Q# operations.
Installing IQ# on your machine typically takes less than 10 minutes; just follow these two steps:

1. Install the latest version of [.NET Core SDK](https://dotnet.microsoft.com/) (2.1 or later) by 
  following the instructions from the [.NET downloads page](https://www.microsoft.com/net/download).
2. From the command line, execute:
   ```Command prompt
   dotnet tool install -g Microsoft.Quantum.IQSharp
   ```

**Your installation of the Quantum Development Kit is now complete!**

To verify IQ# was correctly installed, from the command line type: `dotnet iqsharp --version`. You should see the IQ# version reported on the output, for example:
```Sample
C:\>dotnet iqsharp --version
Language kernel: 0.5.1903.2902
Jupyter core: 1.1.12077.0
```


### Visual Studio and VS Code extensions ###

The Quantum Development Kit offers tight integration with [Visual Studio](https://visualstudio.microsoft.com/vs/) 
and [Visual Studio Code](https://code.visualstudio.com/) that improve the development experience. 
These extensions are available from [Visual Studio's Marketplace](https://marketplace.visualstudio.com/) 
and provide features like:
* Code highlighting
* Errors highlights
* Documentation on hover
* Goto symbol definition
* Rename of symbols
* Debug breakpoints (Visual Studio)

#### [VS Code](#tab/tabid-vscode)

To install the VS Code extensions, follow the instructions at:
> [!div class="button"]
> [Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode)


#### [Visual Studio](#tab/tabid-vs)

Q# is tightly integrated into Visual Studio. If you already have Visual Studio on your computer (version 15.8 or later), follow these steps to enable the Quantum Development Kit integration:
1. Download the [Microsoft Quantum Development Kit for Visual Studio](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit) extension from the Visual Studio Marketplace.
2. Once downloaded, double-click the VSIX file to install the extension.

> [!IMPORTANT]
> The Microsoft Quantum Development Kit does not support Visual Studio for Mac.
> To install on macOS, please use the instructions for [the command line](#tab/tabid-cmdline).
>
> The Quantum Development Kit requires **.NET Core**. Please make sure the
> **.NET Core cross-platform development** workload is installed as part of Visual Studio.

If you do not have Visual Studio installed, you can download the Visual Studio Community Edition for free.
For more information, visit the [Install Visual Studio](https://docs.microsoft.com/visualstudio/install/install-visual-studio) web site.

Once the extension is installed, take a look at the [quickstart guide](xref:microsoft.quantum.write-program) for information on how to write Q# operations and how to invoke them from C#.

***


> [!NOTE]
> The Quantum Development Kit requires a 64-bit installation of Windows 10, macOS, or Linux.
>
> Microsoft's quantum simulator utilizes OpenMP at runtime, on Linux systems you might need to manually install `libgomp`.
> See [this thread](https://stackoverflow.com/questions/52428334/unable-to-load-dll-microsoft-quantum-simulator-runtime-dll-centos-7) at stackoverflow.
>
> Microsoft's quantum simulator, installed with the Quantum Development Kit, utilizes Advance Vector Extensions (AVX), 
> and thus can run significantly more efficiently on an AVX-enabled CPU.
> The Quantum Development Kit will still run on non–AVX enabled CPUs, but may not be as efficient.
> Intel processors shipped in Q1 2011 (Sandy Bridge) or later support AVX.



## Classical Hosts ##

Applications developed with Microsoft's Quantum Development Kit typically consists of two parts:
1. One or more quantum algorithms, implemented using the Q# quantum programming language.
2. A classical program, implemented in a classical programming language like Python or C#, 
  that serves as the main entry point and will invoke Q# operations 
  when it wants to execute a quantum algorithm.

Once you have installed IQ#, there might be extra steps required to enable interoperability with the classical language.
The following articles explain how to enable this interoperability:

* [C# getting started](xref:microsoft.quantum.install.csharp)
* [Jupyter notebooks getting started](xref:microsoft.quantum.install.jupyter)
* [Python getting started](xref:microsoft.quantum.install.python)


## Updating IQ# ##

If you already have IQ# installed, to update it to the latest version, from the command line, execute:
```Command Prompt
dotnet tool update -g Microsoft.Quantum.IQSharp
```


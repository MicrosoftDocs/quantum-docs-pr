---
title: Install the Microsoft Quantum Development Kit (QDK)
description: How to install the Microsoft Quantum Development Kit for different environments.
author: bradben
ms.author: bradben
ms.date: 5/8/2020
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install
no-loc: ['Q#', '$$v']
---

# Install the Microsoft Quantum Development Kit (QDK)

Learn how to install the Microsoft Quantum Development Kit (QDK), so that you can get started with quantum programming. The QDK consists of:

- The Q# programming language
- A set of libraries that abstract complex functionality in Q#
- APIs for Python and .NET languages (C#, F#, and VB.NET) for running quantum programs written in Q#
- Tools to facilitate your development

Q# programs can run as standalone applications using Visual Studio Code or Visual Studio, through Jupyter Notebooks with the IQ# Jupyter kernel, or paired with a host program written in Python or a .NET language (C#, F#). You can also run Q# programs online using [Codespaces](https://online.visualstudio.com/), [MyBinder.org](https://mybinder.org/), or [Docker](#use-the-qdk-with-docker). 

## Installation options

You can use the QDK in three ways:

- [Install the QDK locally](#install-the-qdk-locally)
- [Use the QDK online](#use-the-qdk-online)
- [Use a QDK Docker image](#use-the-qdk-with-docker)

## Install the QDK locally

You can develop Q# code in most of your favorites IDEs, as well as integrate Q# with other languages such as Python and .NET (C#, F#).

|&nbsp; | **VS Code<br>(2019 or later)**| **Visual Studio<br>(2019 or later)** | **Jupyter Notebooks** | **Command line**|
|:-----|:-----:|:-----:|:-----:|:-----:|
|**OS** |Windows, macOS, Linux |Windows only |Windows, macOS, Linux |Windows, macOS, Linux |
|<br>**Q# standalone** |<br>[Install](#configure-for-vs-code) |<br> [Install](#configure-for-visual-studio)  |<br> [Install](#configure-for-jupyter-notebooks-and-python) |<br>[Install](#configure-for-vs-code) |
|**Q#  and Python** |[Install](#configure-for-jupyter-notebooks-and-python) |[Install](#configure-for-visual-studio) |[Install](#configure-for-jupyter-notebooks-and-python) |[Install](#configure-for-jupyter-notebooks-and-python) |
|**Q# and .NET (C#, F#)**|[Install](#configure-for-vs-code) |[Install](#configure-for-visual-studio)|&#10006; |[Install](#configure-for-visual-studio) |

### Configure for VS Code

#### Prerequisites 

- [.NET Core SDK 3.1 or later](https://dotnet.microsoft.com/download/dotnet-core/3.1)

To configure VS Code:

1. Download and install [VS Code](https://code.visualstudio.com/download) (Windows, Linux and macOS).
2. Install the [Microsoft QDK for VS Code](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode).

To start writing Q# code with VS Code, see [Develop with Q# applications](xref:microsoft.quantum.install.standalone). 

### Configure for Visual Studio

#### Prerequisites 

- [.NET Core SDK 3.1 or later](https://www.microsoft.com/net/download)

To configure Visual Studio:

1. Download and install [Visual Studio](https://visualstudio.microsoft.com/downloads/) 16.3 or greater, with the .NET Core cross-platform development workload enabled.
2. Download and install the [Microsoft QDK extension](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit).

To start writing Q# code with Visual Studio, see [Develop with Q# applications](xref:microsoft.quantum.install.standalone).

### Configure for Jupyter Notebooks and Python

Jupyter Notebooks allow running in-place code alongside instructions, notes, and other content. This environment is ideal for writing Q# code with embedded explanations or quantum computing interactive tutorials. 

IQ# (pronounced i-q-sharp) is an extension to the .NET Core SDK, primarily used by Jupyter and Python, that provides the core functionality for compiling and simulating Q# operations.

Here's what you need to do to start creating your own Q# notebooks.

### [Install using conda (recommended)](#tab/tabid-conda)

1. Install [Miniconda](https://docs.conda.io/en/latest/miniconda.html) or [Anaconda](https://www.anaconda.com/products/individual#Downloads). **Note:** 64-bit installation required.

1. On Windows, open an Anaconda Prompt, or on macOS or Linux, open a terminal window.
   - Or, if you prefer to use PowerShell or pwsh: open a shell, run `conda init powershell`, then close and re-open the shell.
1. Create and activate a new conda environment named `qsharp-env` with the required packages (including Jupyter Notebook and IQ#) by running the following commands:
    ```
    conda create -n qsharp-env -c quantum-engineering qsharp notebook
    conda activate qsharp-env
    ```
1. Run `python -c "import qsharp"` from the same terminal to verify your installation and populate your local package cache with all required QDK components.

To start writing Q# code with Python, see [Develop with Q# and Python](xref:microsoft.quantum.install.python).

### [Install using .NET CLI (advanced)](#tab/tabid-dotnetcli)

1. Prerequisites:

    - [Python](https://www.python.org/downloads/) 3.6 or later
    - [Jupyter Notebook](https://jupyter.readthedocs.io/en/latest/install.html)
    - [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

1. Install the `Microsoft.Quantum.IQSharp` package.

    ```dotnetcli
        dotnet tool install -g Microsoft.Quantum.IQSharp
        dotnet iqsharp install
    ```

To start writing Q# code with Jupyter Notebooks, see [Develop with Q# Jupyter Notebooks](xref:microsoft.quantum.install.jupyter).

    > [!NOTE]
    > - If you get an error during the `dotnet iqsharp install` step, open a new terminal window and try again.
    > - If this still doesn't work, locate the installed `dotnet-iqsharp` tool (on Windows, `dotnet-iqsharp.exe`) and run: <br>`<path to dotnet-iqsharp> install --user --path-to-tool=<path to dotnet-iqsharp>`,<br> where `<path to dotnet-iqsharp>` should be replaced by the absolute path to the `dotnet-iqsharp` tool in your file system.
     Typically this will be under `.dotnet/tools` in your user profile folder.
    > - For additional debugging help, see https://natemcmaster.com/blog/2018/02/02/dotnet-global-tool/.

*** 

You now have the IQ# kernel for Jupyter, which provides the core functionality for compiling and running Q# operations from Q# Jupyter Notebooks.

## Use the QDK Online

You can also develop Q# code without installing anything locally with these options:

|Resource|Advantages|Limitations|
|---|---|---|
|**Visual Studio Codespaces**|A rich online development environment  |Requires an Azure subscription and plan |
|**Binder** | Free online notebook experience |No persistence |

### Using Visual Studio Codespaces

To use Visual Studio Codespaces for Q# development:

1. Create an [Azure account](https://azure.microsoft.com/free/).
2. Create a Codespaces environment, following the [quickstart guide](https://docs.microsoft.com/visualstudio/codespaces/quickstarts/browser). When creating your codespace, we recommend using *microsoft/quantum* in the **Git Repository** field to load QDK-specific settings.
3. You can now launch your new environment and start developing in the browser via the [VS Codespaces Cloud IDE](https://online.visualstudio.com/environments). Alternatively, it is possible to use your local installation of VS Code and use Codespaces as a [remote environment](https://docs.microsoft.com/visualstudio/online/how-to/vscode).

### Using Binder

You can use Binder to run your Jupyter Notebooks online.

To configure Binder automatically and experiment with the QDK samples:

- Open a browser and run https://aka.ms/try-qsharp.

To configure Binder manually:

1. Go to [mybinder.org](https://mybinder.org).
1. Fill out the fields, using *microsoft/quantum* as the GitHub URL.

![MyBinder form](~/media/mybinder.png)

## Use the QDK with Docker

You can use our QDK Docker image in your local Docker installation or in the cloud via any service that supports Docker images, such as ACI.

You can download the IQ# Docker image from https://github.com/microsoft/iqsharp/#using-iq-as-a-container. 

You can also use Docker with a Visual Studio Code Remote Development Container to quickly define development environments. For more information about VS Code Development Containers, see https://github.com/microsoft/Quantum/tree/master/.devcontainer.

## Next steps

Start developing Q# programs on your desired platform:

- [Develop with Q# applications](xref:microsoft.quantum.install.standalone) - Choose this approach to work with Q# from the command prompt. This does not require a driver or a host program like the below options.
- [Develop with Q# Jupyter Notebooks](xref:microsoft.quantum.install.jupyter) - Select this environment to run Q# code in cells with embedded text or create quantum computing interactive tutorials. 
- [Develop with Q# and Python](xref:microsoft.quantum.install.python) - Enables you to combine Python and Q# to create a Python host program that calls Q# operations.
- [Develop with Q# and .NET](xref:microsoft.quantum.install.cs) - Combine C#, F#, or VB.NET with Q# to create a .NET host program that calls Q# operations.

The workflows for each of these setups are described and compared at [Ways to run a Q# program](xref:microsoft.quantum.guide.host-programs).

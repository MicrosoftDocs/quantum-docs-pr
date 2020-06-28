---
title: Develop with Q# and Python
author: bradben
ms.author: bradben
ms.date: 5/30/2020
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install.python
---

# Develop with Q# and Python

Install the QDK to develop Python host programs to call Q# operations.

## Install the `qsharp` Python package

### [Install using conda (recommended)](#tab/tabid-conda)

1. Install [Miniconda](https://docs.conda.io/en/latest/miniconda.html) or [Anaconda](https://www.anaconda.com/products/individual#Downloads).

1. Open an Anaconda Prompt.

   - Or, if you prefer to use PowerShell or pwsh: open a shell, run `conda init powershell`, then close and re-open the shell.

1. Create and activate a new conda environment named `qsharp-env` with the required packages (including Jupyter Notebook and IQ#) by running the following commands:

    ```
    conda create -n qsharp-env -c quantum-engineering qsharp notebook

    conda activate qsharp-env
    ```

1. Run `python -c "import qsharp"` from the same terminal to verify your installation and populate your local package cache with all required QDK components.

### [Install using .NET CLI and pip (advanced)](#tab/tabid-dotnetcli)

1. Prerequisites:

    - [Python](https://www.python.org/downloads/) 3.6 or later
    - The [PIP](https://pip.pypa.io/en/stable/installing) Python package manager
    - [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)


1. Install the `qsharp` package, a Python package that enables interop between Q# and Python.

    ```
    pip install qsharp
    ```

1. Install IQ#, a kernel used by Jupyter and Python that provides the core functionality for compiling and executing Q# operations.

    ```dotnetcli
    dotnet tool install -g Microsoft.Quantum.IQSharp
    dotnet iqsharp install
    ```

    > [!NOTE]
    > If you get an error during the `dotnet iqsharp install` step, open a new terminal window and try again.
    > If this still doesn't work, try locating the installed `dotnet-iqsharp` tool (on Windows, `dotnet-iqsharp.exe`) and running:
    > ```
    > /path/to/dotnet-iqsharp install --user --path-to-tool="/path/to/dotnet-iqsharp"
    > ```
    > where `/path/to/dotnet-iqsharp` should be replaced by the absolute path to the `dotnet-iqsharp` tool in your file system.
    > Typically this will be under `.dotnet/tools` in your user profile folder.
    
***

That's it! You now have both the `qsharp` Python package and the IQ# kernel for Jupyter, which provides the core functionality for compiling and executing Q# operations from Python and allows you to use Q# Jupyter Notebooks.

## Choose your IDE

While you can use Q# with Python in any IDE, we highly recommend using Visual Studio Code (VS Code) IDE for your Q# + Python applications. With the QDK Visual Studio Code extension you gain access to richer functionality such as warnings, syntax highlighting, project templates, and more.

If you would like to use VS Code:

- Install [VS Code](https://code.visualstudio.com/download) (Windows, Linux and Mac).
- Install the [QDK extension for VS Code](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode).

If you would like to use a different editor, the instructions above have you all set.

## Write your first Q# program

Now you are ready to verify your `qsharp` Python package installation by writing and executing a simple Q# program.

1. Create a minimal Q# operation by creating a file called `Operation.qs` and adding the following code to it:

    :::code language="qsharp" source="~/quantum/samples/interoperability/qrng/Qrng.qs" range="3-14":::

1. In the same folder as `Operation.qs`, create a Python program called `host.py` to simulate the Q# `SampleQuantumRandomNumberGenerator()` operation:

    ```python
    import qsharp
    from Qrng import SampleQuantumRandomNumberGenerator

    SampleQuantumRandomNumberGenerator.simulate()
    ```

1. From the environment you created during installation (i.e., the conda or Python environment where you installed `qsharp`), run the program:

    ```
    python host.py
    ```

1. You should see the result of the operation you invoked. In this case, because your operation generates a random result, you will see either `Zero` or `One` printed on the screen. If you execute the program repeatedly, you should see each result approximately half the time.

> [!NOTE]
> * The Python code is just a normal Python program. You can use any Python environment, including Python-based Jupyter Notebooks, to write the Python program and call Q# operations. The Python program can import Q# operations from any .qs files located in the same folder as the Python code itself.

## Next steps

Now that you have installed the Quantum Development Kit in your preferred environment, you can follow this tutorial to write and run [your first quantum program](xref:microsoft.quantum.quickstarts.qrng).

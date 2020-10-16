---
title: Develop with Q# Jupyter Notebooks
description: Learn how to create a Q# application using Jupyter Notebooks.
author: bradben
ms.author: v-benbra
ms.date: 8/20/2020
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install.jupyter
no-loc: ['Q#', '$$v']
---

# Develop with Q# Jupyter Notebooks

Install the QDK for developing Q# operations on Q# Jupyter Notebooks.

Jupyter Notebooks allow running code in-place alongside instructions, notes, and other content. This environment is ideal for writing Q# code with embedded explanations or quantum computing interactive tutorials. Here's what you need to do to start creating your own Q# notebooks.

## Install the IQ# Jupyter kernel

IQ# (pronounced i-q-sharp) is an extension primarily used by Jupyter and Python to the .NET Core SDK that provides the core functionality for compiling and simulating Q# operations.

### [Install using conda (recommended)](#tab/tabid-conda)

1. Install [Miniconda](https://docs.conda.io/en/latest/miniconda.html) or [Anaconda](https://www.anaconda.com/products/individual#Downloads). **Note:** 64-bit installation required.

1. Open an Anaconda Prompt.

   - Or, if you prefer to use PowerShell or pwsh: open a shell, run `conda init powershell`, then close and re-open the shell.

1. Create and activate a new conda environment named `qsharp-env` with the required packages (including Jupyter Notebook and IQ#) by running the following commands:

    ```
    conda create -n qsharp-env -c quantum-engineering qsharp notebook

    conda activate qsharp-env
    ```

1. Run `python -c "import qsharp"` from the same terminal to verify your installation and populate your local package cache with all required QDK components.

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

> [!NOTE]
> If you get an error during the `dotnet iqsharp install` step, open a new terminal window and try again.
> If this still doesn't work, try locating the installed `dotnet-iqsharp` tool (on Windows, `dotnet-iqsharp.exe`) and running:
> ```
> /path/to/dotnet-iqsharp install --user --path-to-tool="/path/to/dotnet-iqsharp"
> ```
> where `/path/to/dotnet-iqsharp` should be replaced by the absolute path to the `dotnet-iqsharp` tool in your file system.
> Typically this will be under `.dotnet/tools` in your user profile folder.
    
***

That's it! You now have the IQ# kernel for Jupyter, which provides the core functionality for compiling and running Q# operations from Q# Jupyter Notebooks.

## Create your first Q# notebook

Now you are ready to verify your Q# Jupyter Notebook installation by writing and running a simple Q# operation.

1. From the environment you created during installation (i.e., either the conda environment you created, or the Python environment where you installed Jupyter), run the following command to start the Jupyter Notebook server:

    ```
    jupyter notebook
    ```

    - If the Jupyter Notebook doesn't open automatically in your browser, copy and paste the URL provided by the command line into your browser.

1. Choose **New → Q#** to create a Jupyter Notebook with a Q# kernel, and add the following code to the first notebook cell:

    :::code language="qsharp" source="~/quantum/samples/interoperability/qrng/Qrng.qs" range="6-13":::

1. Run this cell of the notebook:

    ![Jupyter Notebook cell with Q# code](~/media/install-guide-jupyter.png)

    You should see `SampleQuantumRandomNumberGenerator` in the output of the cell. When running in Jupyter Notebook, the Q# code is compiled, and the cell outputs the name of any operations that it finds.

1. In a new cell, run the operation you just created (in a simulator) by using the `%simulate` command:

    ![Jupyter Notebook cell with %simulate magic](~/media/install-guide-jupyter-simulate.png)

    You should see the result of the operation you invoked. In this case, because your operation generates a random result, you will see either `Zero` or `One` printed on the screen. If you run the cell repeatedly, you should see each result approximately half the time.

## Next steps

Now that you have installed the QDK for Q# Jupyter Notebooks, you can write and run [your first quantum program](xref:microsoft.quantum.quickstarts.qrng) by writing Q# code directly within the Jupyter Notebook environment.

For more examples of what you can do with Q# Jupyter Notebooks, please take a look at:

- [Intro to Q# and Jupyter Notebook](https://docs.microsoft.com/samples/microsoft/quantum/intro-to-qsharp-jupyter/). There you will find a Q# Jupyter Notebook that provides more details on how to use Q# in the Jupyter environment.
- [Quantum Katas](xref:microsoft.quantum.overview.katas), an open-source collection of self-paced tutorials and sets of programming exercises in the form of Q# Jupyter Notebooks. The [Quantum Katas tutorial notebooks](https://github.com/microsoft/QuantumKatas#tutorial-topics) are a good starting point. The Quantum Katas are aimed at teaching you elements of quantum computing and Q# programming at the same time. They're an excellent example of what kind of content you can create with Q# Jupyter Notebooks.

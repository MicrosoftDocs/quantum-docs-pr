---
title: Develop with Q# Jupyter notebooks
author: natke
ms.author: nakersha
ms.date: 9/30/2019
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install.jupyter
---

# Develop with Q# Jupyter notebooks

> [!WARNING]
> * In Q# Jupyter Notebooks you only can run Q# code and you cannot call operations defined in the notebook from an external classical host program in Python or C#. This environment is not appropiate if your goal is to combine an external classical host program with the quantum program.

Commonplace in academic settings, scientific labs, and online-based collaborative programming, Jupyter Notebooks allow in-place code execution alongside instructions, notes, and other content. This environment is great for writing Q# code with embedded explanations or quantum computing interactive tutorials. Here's what you need to do to start creating your own Q# notebooks.

IQ# (pronounced i-q-sharp) is an extension primarily used by Jupyter and Python to the .NET Core SDK that provides the core functionality for compiling and simulating Q# operations.

1. Pre-requisites

    - [Python](https://www.python.org/downloads/) 3.6 or later
    - [Jupyter Notebook](https://jupyter.readthedocs.io/en/latest/install.html)
    - [.NET Core SDK 3.0 or later](https://www.microsoft.com/net/download)

1. Install the `iqsharp` package

    ```bash
    dotnet tool install -g Microsoft.Quantum.IQSharp
    dotnet iqsharp install
    ```

1. Verify the installation by creating a `Hello World` application

    - Run the following command to start the notebook server:

        ```bash
        jupyter notebook
        ```

    - Browse to the URL shown on the command line. For example: [http://localhost:8888/?token=c790a52ba54f0cf77465c3c8983d776348285b0280d91b85]

    - Create a Jupyter notebook with a Q# kernel, and add the following code to the first notebook cell:

        ```qsharp
        operation SayHello () : Unit {
            Message("Hello from quantum world!");
        }
        ```

    - Run this cell of the notebook:

        ![Jupyter notebook cell with Q# code](~/media/install-guide-jupyter.png)

        You should see `SayHello` in the output of the cell. When running in jupyter notebooks, the Q# code is compiled, and the notebook outputs the name of the operation(s) that it finds.


    - In a new cell, simulate the execution in a quantum computer of the operation you just created by using the `%simulate` magic:

        ![Jupyter notebook cell with %simulate magic](~/media/install-guide-jupyter-simulate.png)

        You should see the message printed on the screen along with the result of the operation you invoked (here, we see the empty tuple `()` because our operation simply returns a `Unit` type).

## What's next?

Now that you have installed the Quantum Development Kit in your preferred environment, you can write and run [your first quantum program](xref:microsoft.quantum.write-program).

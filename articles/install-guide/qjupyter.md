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

Install the QDK for developing Q# operations on Q# Jupyter Notebooks.

Jupyter Notebooks allow in-place code execution alongside instructions, notes, and other content. This environment is ideal for writing Q# code with embedded explanations or quantum computing interactive tutorials. Here's what you need to do to start creating your own Q# notebooks.

IQ# (pronounced i-q-sharp) is an extension primarily used by Jupyter and Python to the .NET Core SDK that provides the core functionality for compiling and simulating Q# operations.

> [!NOTE]
> * In Q# Jupyter Notebooks you can only run Q# code, and the operations cannot be called from external host programs (e.g. Python or C# files). This environment is not appropriate if your goal is to combine an external classical host program with the quantum program.

1. Pre-requisites

    - [Python](https://www.python.org/downloads/) 3.6 or later
    - [Jupyter Notebook](https://jupyter.readthedocs.io/en/latest/install.html)
    - [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

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

    - To open the Jupyter notebook copy and paste the URL provided by the command line into your browser.

    - Create a Jupyter notebook with a Q# kernel, and add the following code to the first notebook cell:

        ```qsharp
        operation SayHello () : Unit {
            Message("Hello from quantum world!");
        }
        ```

    - Run this cell of the notebook:

        ![Jupyter notebook cell with Q# code](~/media/install-guide-jupyter.png)

        You should see `SayHello` in the output of the cell. When running in jupyter notebooks, the Q# code is compiled, and the notebook outputs the name of the operation(s) that it finds.


    - In a new cell, execute the operation you just created (in a simulator) by using the `%simulate` command:

        ![Jupyter notebook cell with %simulate magic](~/media/install-guide-jupyter-simulate.png)

        You should see the message printed on the screen along with the result of the operation you invoked (here, we see the empty tuple `()` because our operation simply returns a `Unit` type).

## Next steps

Now that you have installed the Quantum Development Kit in your preferred environment, you can write and run [your first quantum program](xref:microsoft.quantum.quickstarts.qrng).

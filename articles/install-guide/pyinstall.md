---
title: Develop with Q# and Python
author: natke
ms.author: nakersha
ms.date: 9/30/2019
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install.python
---

# Develop with Q# and Python

Install the QDK to develop Python host programs to call Q# operations.

1. Prerequisites

    - [Python](https://www.python.org/downloads/) 3.6 or later
    - The [PIP](https://pip.pypa.io/en/stable/installing) Python package manager
    - [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)


1. Install the `qsharp` package, a Python package that enables interop between Q# and Python.

    ```bash
    pip install qsharp
    ```

1. Install IQ#, a kernel used by Jupyter and Python that provides the core functionality for compiling and executing Q# operations.

    ```bash
    dotnet tool install -g Microsoft.Quantum.IQSharp
    dotnet iqsharp install
    ```
  
1. While you can use Q# with Python in any IDE, we highly recommend using Visual Studio Code (VS Code) IDE for your Q# + Python applications. By using Visual Studio Code and the QDK Visual Studio Code extension you gain access to richer functionality.

    - Install [VS Code](https://code.visualstudio.com/download) (Windows, Linux and Mac)
    - Install the [QDK extension for VS Code](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode).

1. Verify the installation by creating a `Hello World` application

    - Create a minimal Q# operation, by creating a file called `Operation.qs`, and adding the following code to it:

        ```qsharp
        namespace HelloWorld {
            open Microsoft.Quantum.Intrinsic;
            open Microsoft.Quantum.Canon;

            operation SayHello() : Unit {
                Message("Hello from quantum world!");
            }
        }
        ```

    - Create a Python program called `hello_world.py` to call the Q# `SayHello()` operation:

        ```python
        import qsharp

        from HelloWorld import SayHello

        SayHello.simulate()
        ```

    - Run the program:

        ```bash
        python hello_world.py
        ```

    - Verify the output. Your program should output the following lines:

        ```bash
        Hello from quantum world!
       ```


> [!NOTE]
> * You can also use Python Jupyter notebooks to write the classical Python program and call Q# operations from the cells. The Python code is just a normal Python program.

## Next steps

Now that you have installed the Quantum Development Kit in your preferred environment, you can write and run [your first quantum program](xref:microsoft.quantum.quickstarts.qrng).

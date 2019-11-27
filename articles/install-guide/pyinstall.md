---
title: Develop with Q# + Python
author: natke
ms.author: nakersha
ms.date: 9/30/2019
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install.python
---

# Develop with Q# + Python

This is the installation guide for the QDK environment to program hybrid Q# and Python programs.

1. Pre-requisites

    - [Python](https://www.python.org/downloads/) 3.6 or later
    - The [PIP](https://pip.pypa.io/en/stable/installing) Python package manager
    - [.NET Core SDK 3.0 or later](https://www.microsoft.com/net/download)


1. Install the `qsharp` package, a Python package that allows the interoperation between Q# and Python.

    ```bash
    pip install qsharp
    ```

1. Install the `iqsharp`, an extension primarily used by Jupyter and Python that provides the core functionality for compiling and simulating Q# operations.

    ```bash
    dotnet tool install -g Microsoft.Quantum.IQSharp
    dotnet iqsharp install
    ```
  
1. Although it's not strictly necessary, we highly recommend to use the lightweight Visual Studio Code (VS Code) IDE to edit the Q# and Python files. Together with the QDK extension for VS Code this will provide code completion and syntax syntax highlighting features to make the coding easier.

    - Install [VS Code](https://code.visualstudio.com/download) (Windows, Linux and Mac)
    - Install the [QDK extension for VS Code](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode).

1. Verify the installation by creating a `Hello World` application

    - Create a minimal Q# operation, by creating a file called `Operation.qs`, and adding the following code to it:

        ```qsharp
        namespace HelloWorld
        {
            open Microsoft.Quantum.Intrinsic;
            open Microsoft.Quantum.Canon;

            operation SayHello() : Result {
                Message("Hello from quantum world!");
                return Zero;
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
> * You can also use Python Jupyter notebooks to write the classical Python program and call from the cells the Q# operations whenever they're needed. The Python code is just a normal Python program.

## What's next?

Now that you have installed the Quantum Development Kit in your preferred environment, you can write and run [your first quantum program](xref:microsoft.quantum.write-program).

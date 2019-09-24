---
title: Learn how to install the Microsoft Quantum Development Kit (QDK)
author: natke
ms.author: nakersha
ms.date: 9/23/2019
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install
---

# Install the Microsoft Quantum Development Kit (QDK)

Learn how to install the Microsoft Quantum Development Kit (QDK), so that you can get started with quantum programming. The QDK consists of:

- the Q# programming language
- a set of libraries that abstract complex functionality in Q#
- a host application (written in Python or a .NET language) that runs quantum operations written in Q#
- tools to facilitate your development

Depending on your chosen development environment, there are different installation steps. Choose your environment from the sections below.

## Develop with Python

1. Pre-requisites

    - [Python](https://www.python.org/downloads/) 3.6 or later
    - The [anaconda](https://docs.anaconda.com/anaconda/install/) package manager

1. Install the `qsharp` package

    ```bash
    conda install -c quantum-engineering qsharp
    ```

1. Install the `iqsharp` package

   ```bash
   conda install -c quantum-engineering iqsharp
   ```

1. Verify the installation

    - Create a minimal Q# operation, by creating a file called `Operation.qs`, and adding the following code to it:

        ```qsharp
        namespace HelloWorld
        {
            open Microsoft.Quantum.Intrinsic;
            open Microsoft.Quantum.Canon;

            operation HelloQ() : Result
            {
                Message($"Hello from quantum world!");
                return Zero;
            }
        }
        ```

    - Create a python program called `run_hello_q.py` to call the Q# `HelloQ()` operation:

        ```python
        from HelloWorld import HelloQ

        HelloQ.simulate()
        ```

    - Run the program:

        ```bash
        python run_hello_q.py
        ```

    - Verify the output. Your program should output the following lines:

        ```bash
        Hello from quantum world!
       0
       ```

## Develop with Jupyter notebooks

1. Pre-requisites

    - [Python](https://www.python.org/downloads/) 3.6 or later
    - [Jupyter notebooks](https://jupyter.readthedocs.io/en/latest/install.html)

1. Install the `iqsharp` package:

    ```bash
    conda install -c quantum-engineering iqsharp
    ```

1. Verify the installation:

    - Run the following command to start the notebook server:

        ```bash
        jupyter notebook
        ```

    - Browse to the URL shown on the command line. For example: http://localhost:8888

    - Create a jupyter notebook with a Q# kernel, and add the following code to the first notebook cell:

        ```qsharp
        operation HelloQ () : Unit {
            Message($"Hello from quantum world!");
        }
        ```

    - Run this cell of the notebook:

        You should see `HelloQ` in the output of the cell. When running in jupyter notebooks, the Q# code is compiled, and the notebook outputs the name of the operation(s) that it finds.

## Develop with C# on Windows, using Visual Studio

1. Pre-requisites

    - Visual Studio, version, with the .NET Core cross-platform development workload enabled

1. Install the Q# Visual Studio extension

    - Download the [Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit)
    - Add the extension to Visual Studio

1. Verify the installation:

    - Create a new Q# application

        - Go to **File** -> **New** -> **Project**
        - Type `Q#` in the search box
        - Select **Q# Application**
        - Select **Next**
        - Choose a name and location for your application
        - Select **Create**

    - Inspect the project

        You should see that two files have been created: `Driver.cs` which is the C# host application; and `Operation.qs`, which is a Q# program that defines a simple operation to print a message to the console.

    - Run the application

        - Select **Debug** -> **Start Without Debugging**
        - You should see the text `Hello quantum world!` printed to a console window.

## Develop with C#, using VS Code

1. Pre-requisites

   - [VS Code](https://code.visualstudio.com/download)
   - [.NET Core SDK 2.1 or later](https://www.microsoft.com/net/download)

1. Install the Quantum VS Code extension

    - Download the [VS Code extension](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode)
    - Add the extension to VS Code

1. Install the Quantum project templates:

    ```bash
    dotnet new -i Microsoft.Quantum.ProjectTemplates
    ```

    You now have the Quantum Development Kit installed and ready to use in your own applications and libraries.

1. Verify the installation

    - Create a new project:

        - Go to **View** -> **Command Palette**
        - Select **Q#: Create New Project**
        - Navigate to the location on the file system where you would like to create the application

    - Open the new project:

        - Back in VS Code, navigate to the new project
        - You should see two files, along with the project files: `Operation.qs` and `Driver.cs`

    - Run the application:

        - Go to **Debug** -> **Start Without Debugging**
        - You should see the following text in the output window `Hello quantum world!`

## Develop with C#, using the `dotnet` command-line tool

1. Pre-requisites

    - [.NET Core SDK 2.1 or later](https://www.microsoft.com/net/download)

1. Install the Quantum project templates for .NET

    ```bash
    dotnet new -i Microsoft.Quantum.ProjectTemplates
    ```

    You now have the Quantum Development Kit installed and ready to use in your own applications and libraries.

1. Verify the installation

    - Create a new application

    ```bash
    dotnet new console -lang Q# -o runHelloQ
    ```

    - Navigate to the new application directory

    ```bash
    cd runHelloQ
    ```

    You should see that two files have been created, along with the project files of the application: a Q# file (`Operation.qs`) and a C# host file (`Driver.cs`).

    - Run the application

        ```bash
        cd runHelloQ
        dotnet run
        ```

        You should see the following output: `Hello quantum world!`

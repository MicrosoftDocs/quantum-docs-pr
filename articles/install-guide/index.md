---
title: Learn how to install the Microsoft Quantum Development Kit (QDK)
author: natke
ms.author: nakersha
ms.date: 9/30/2019
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
    - The [PIP](https://pip.pypa.io/en/stable/installing) Python package manager
    - [.NET Core SDK 2.1 or later](https://www.microsoft.com/net/download)

1. Install the `iqsharp` package

    ```bash
    dotnet tool install -g Microsoft.Quantum.IQSharp
    dotnet iqsharp install
    ```

1. Install the `qsharp` package

    ```bash
    pip install qsharp
    ```

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
       0
       ```

## Develop with Jupyter notebooks

1. Pre-requisites

    - [Python](https://www.python.org/downloads/) 3.6 or later
    - [Jupyter Notebook](https://jupyter.readthedocs.io/en/latest/install.html)
    - [.NET Core SDK 2.1 or later](https://www.microsoft.com/net/download)

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

        ![Jupyter notebook cell](~/media/install-guide-jupyter.png)

        You should see `SayHello` in the output of the cell. When running in jupyter notebooks, the Q# code is compiled, and the notebook outputs the name of the operation(s) that it finds.

## Develop with C# on Windows, using Visual Studio

1. Pre-requisites

    - [Visual Studio](https://visualstudio.microsoft.com/downloads/) 16.3, with the .NET Core cross-platform development workload enabled

1. Install the Q# Visual Studio extension

    - Download the [Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit)
    - Add the extension to Visual Studio

1. Verify the installation by creating a `Hello World` application

    - Create a new Q# application

        - Go to **File** -> **New** -> **Project**
        - Type `Q#` in the search box
        - Select **Q# Application**
        - Select **Next**
        - Choose a name and location for your application
        - Select **Create**

    - Inspect the project

        You should see that two files have been created: `Driver.cs`, which is the C# host application; and `Operation.qs`, which is a Q# program that defines a simple operation to print a message to the console.

    - Run the application

        - Select **Debug** -> **Start Without Debugging**
        - You should see the text `Hello quantum world!` printed to a console window.

> [!NOTE]
> * If you have multiple projects within one Visual Studio solution, all projects contained in the solution need to be in the same folder as the solution, or in one of its subfolders.  

## Develop with C#, using VS Code

1. Pre-requisites

   - [VS Code](https://code.visualstudio.com/download)
   - [.NET Core SDK 2.1 or later](https://www.microsoft.com/net/download)

1. Install the Quantum VS Code extension

    - Install the [VS Code extension](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode)

1. Install the Quantum project templates:

   - Go to **View** -> **Command Palette**
   - Select **Q#: Install project templates**

    You now have the Quantum Development Kit installed and ready to use in your own applications and libraries.

1. Verify the installation by creating a `Hello World` application

    - Create a new project:

        - Go to **View** -> **Command Palette**
        - Select **Q#: Create New Project**
        - Navigate to the location on the file system where you would like to create the application
        - Click on the **Open new project...** button, once the project has been created

    - Run the application:

        - Go to **Debug** -> **Start Without Debugging**
        - You should see the following text in the output window `Hello quantum world!`

> [!NOTE]
> * > * Workspaces with multiple root folders are not currently supported by the Visual Studio Code extension. If you have multiple projects within one VS Code workspace, all projects need to be contained within the same root folder.

## Develop with C#, using the `dotnet` command-line tool

1. Pre-requisites

    - [.NET Core SDK 2.1 or later](https://www.microsoft.com/net/download)

1. Install the Quantum project templates for .NET

    ```bash
    dotnet new -i Microsoft.Quantum.ProjectTemplates
    ```

    You now have the Quantum Development Kit installed and ready to use in your own applications and libraries.

1. Verify the installation by creating a `Hello World` application

    - Create a new application

       ```bash
       dotnet new console -lang Q# -o runSayHello
       ```

    - Navigate to the new application directory

       ```bash
       cd runSayHello
       ```

    You should see that two files have been created, along with the project files of the application: a Q# file (`Operation.qs`) and a C# host file (`Driver.cs`).

    - Run the application

        ```bash
        dotnet run
        ```

        You should see the following output: `Hello quantum world!`

## What's next?

Now that you have installed the Quantum Development Kit in your preferred environment, you can write and run [your first quantum program](xref:microsoft.quantum.write-program).

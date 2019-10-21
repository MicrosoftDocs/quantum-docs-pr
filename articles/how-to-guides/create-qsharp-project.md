---
title: Learn how to create a Q# project with the Quantum Development Kit (QDK)
description: Initialize a project for quantum development with the QDK and Q# in the development environment of you choice
author: natke
ms.author: nakersha
ms.date: 10/19/2019
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.howto.createproject
---

# Create a Q# project in your development environment

Learn how to create a Q# project with the QDK.

A Q# project contains Q# files containing quantum code, as well as a host program to run the quantum program. You can write the host program in .NET languages such as C#, or in Python. You can also run Q# code in a Jupyter notebook using the IQ# kernel.

Choose your development environment and language from the sections below:

* [Python](#create-a-python-project)
* [Jupyter notebooks](#create-a-jupyter-notebook-project)
* [C# with Visual Studio](#create-a-c-project-on-windows-using-visual-studio)
* [C# with VS Code](#create-a-c-project-using-vs-code)
* [C# with the command line](#create-a-c-project-using-the-dotnet-command-line-tool)

## Create a Python project

1. Pre-requisites

     * The [Quantum Development Kit for Python](xref:microsoft.quantum.install#develop-with-python)

1. Create a folder for your project, and navigate to that folder

1. Create a Q# file called `Operation.qs`, and add your Q# code to it. For example:

    ```qsharp
    namespace HelloWorld {
        open Microsoft.Quantum.Intrinsic;
        open Microsoft.Quantum.Canon;

        operation SayHello() : Result {
            Message("Hello from quantum world!");
            return Zero;
        }
    }
    ```

1. Create a python host file called `host.py` to call your Q# operation. For example:

    ```python
    import qsharp

    from HelloWorld import SayHello

    SayHello.simulate()
    ```

1. Run the program:

    ```bash
    python host.py
    ```

1. Verify the output. Your program should output the following lines:

    ```bash
    Hello from quantum world!
    0
    ```

You can now continue to develop your quantum program.

## Create a Jupyter Notebook project

1. Pre-requisites

    * The [Quantum Development Kit for Jupyter notebooks](xref:microsoft.quantum.install#develop-with-jupyter-notebooks)

1. Run the following command to start the notebook server:

    ```bash
    jupyter notebook
    ```

1. Browse to the URL shown on the command line. For example: [http://localhost:8888/?token=c790a52ba54f0cf77465c3c8983d776348285b0280d91b85]

1. Create a Jupyter notebook with a Q# kernel, and add the following code to the first notebook cell:

    ```qsharp
    operation SayHello() : Unit {
        Message("Hello from quantum world!");
    }
    ```

1. Run the notebook:

    ![Jupyter notebook cell](~/media/install-guide-jupyter.png)

    You should see `SayHello` in the output of the cell. When running in Jupyter Notebooks, the Q# code is compiled, and the notebook outputs the name of the operation(s) that it finds.

You can now add other Q# operations to continue your quantum development.

## Create a C# project on Windows, using Visual Studio

1. Pre-requisites

    * The [Quantum Development Kit for Visual Studio](xref:microsoft.quantum.install#develop-with-c-on-windows-using-visual-studio)

1. Create a new Q# application

    * Go to **File** -> **New** -> **Project**
    * Type `Q#` in the search box
    * Select **Q# Application**
    * Select **Next**
    * Choose a name and location for your application
    * Select **Create**

1. Inspect the project

    You should see that two files have been created: `Driver.cs`, which is the C# host application; and `Operation.qs`, which is a Q# program that defines a simple operation to print a message to the console.

1. Run the application

    * Select **Debug** -> **Start Without Debugging**
    * You should see the text `Hello quantum world!` printed to a console window.

You can now continue your quantum development using Visual Studio

> [!NOTE]
> * If you have multiple projects within one Visual Studio solution, all projects contained in the solution need to be in the same folder as the solution, or in one of its subfolders.  

## Create a C# project, using VS Code

1. Pre-requisites

    * The [Quantum Development Kit for VS Code](xref:microsoft.quantum.install#develop-with-c-using-vs-code)

1. Create a new project:

    * Go to **View** -> **Command Palette**
    * Select **Q#: Create New Project**
    * Navigate to the location on the file system where you would like to create the application
    * Click on the **Open new project...** button, once the project has been created

1. Run the application:

    * Go to **Debug** -> **Start Without Debugging**
    * You should see the following text in the output window `Hello quantum world!`

You can now continue your quantum development using Visual Studio Code.

> [!NOTE]
> * Workspaces with multiple root folders are not currently supported by the Visual Studio Code extension. If you have multiple projects within one VS Code workspace, all projects need to be contained within the same root folder.

## Create a C# project, using the `dotnet` command-line tool

1. Pre-requisites

    * The [Quantum Development Kit for the Command Line](xref:microsoft.quantum.install#develop-with-c-using-the-dotnet-command-line-tool)

1. Create a new application

    ```bash
    dotnet new console -lang Q# -o <project name>
    ```

1. Navigate to the new application directory

    ```bash
    cd <project name>
    ```

    You should see that two files have been created, along with the project files of the application: a Q# file (`Operation.qs`) and a C# host file (`Driver.cs`).

1. Run the application

    ```bash
    dotnet run
    ```

    You should see the following output: `Hello quantum world!`

You now continue your quantum development, using command line tools.

## What's next?

Now that you have created a project in your preferred environment, you can continue your quantum development.

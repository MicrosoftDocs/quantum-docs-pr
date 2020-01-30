---
title: Develop with Q# + C#
author: natke
ms.author: nakersha
ms.date: 9/30/2019
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install.cs
---
# Develop with Q# + C#

Install the QDK to develop C# host programs to call Q# operations.

Q# is built to play well with .NET languages--specifically C#. You can work with this pairing inside different development environments:

- [Q# + C# using Visual Studio (Windows)](#VS)
- [Q# + C# using Visual Studio Code (Windows, Linux and Mac)](#VSC)
- [Q# + C# using the `dotnet` command-line tool](#command)

## Develop with Q# + C# using Visual Studio <a name="VS"></a>

Visual Studio offers a rich environment for developing Q# programs. The Q# Visual Studio extension contains templates for Q# files and projects as well as syntax highlighting, code completion and IntelliSense support.


1. Pre-requisites

    - [Visual Studio](https://visualstudio.microsoft.com/downloads/) 16.3, with the .NET Core cross-platform development workload enabled

1. Install the Q# Visual Studio extension

    - Download and install the [Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit)

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

## Develop with Q# + C# using Visual Studio Code <a name="VSC"></a>

Visual Studio Code (VS Code) offers a rich environment for developing Q# programs on Windows, Linux and Mac.  The Q# VS Code extension includes support for Q# syntax highlighting, code completion, and Q# code snippets.

1. Pre-requisites

   - [VS Code](https://code.visualstudio.com/download)
   - [.NET Core SDK 3.1 or later](https://www.microsoft.com/net/download)

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
        - Select **Standalone console application**
        - Navigate to the location on the file system where you would like to create the application
        - Click on the **Open new project...** button, once the project has been created

    - If you don't already have the C# extension for VS Code installed, a pop-up will appear. Install the extension. 

    - Run the application:

        - Go to **Terminal** -> **New Terminal**
		- Enter `dotnet run`
        - You should see the following text in the output window `Hello quantum world!`


> [!NOTE]
> * Workspaces with multiple root folders are not currently supported by the Visual Studio Code extension. If you have multiple projects within one VS Code workspace, all projects need to be contained within the same root folder.

## Develop with Q# + C# using the `dotnet` command-line tool <a name="command"></a>

Of course, you can also build and run Q# programs from the command line by simply installing the .NET Core SDK and the QDK project templates. 

1. Pre-requisites

    - [.NET Core SDK 3.1 or later](https://www.microsoft.com/net/download)

1. Install the Quantum project templates for .NET

    ```dotnetcli
    dotnet new -i Microsoft.Quantum.ProjectTemplates
    ```

    You now have the Quantum Development Kit installed and ready to use in your own applications and libraries.

1. Verify the installation by creating a `Hello World` application

    - Create a new application

       ```dotnetcli
       dotnet new console -lang "Q#" -o runSayHello
       ```

    - Navigate to the new application directory

       ```bash
       cd runSayHello
       ```

    You should see that two files have been created, along with the project files of the application: a Q# file (`Operation.qs`) and a C# host file (`Driver.cs`).

    - Run the application

        ```dotnetcli
        dotnet run
        ```

        You should see the following output: `Hello quantum world!`

    
## What's next?

Now that you have installed the Quantum Development Kit in your preferred environment, you can write and run [your first quantum program](xref:microsoft.quantum.write-program).

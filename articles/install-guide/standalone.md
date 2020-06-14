---
title: Develop with Q# command line applications
author: KittyYeungQ
ms.author: kitty
ms.date: 4/24/2020
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install.standalone
---

# Develop with Q# command line applications

Q# programs can be executed on their own, without a driver in a host language like C#, F#, or Python.

## Prerequisites

- [.NET Core SDK 3.1 or later](https://www.microsoft.com/net/download)

## Installation

While you can build Q# command line applications in any IDE, we recommend using Visual Studio Code (VS Code) or Visual Studio IDE for your Q# applications. Developing in these environments includes the rich functionality of the QDK extension, which includes warnings, syntax highlighting, project templates, and more.

To configure VS Code:

1. Download and install [VS Code](https://code.visualstudio.com/download) (Windows, Linux and Mac).
2. Install the [Microsoft QDK for VS Code](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode).

To configure Visual Studio:

1. Download and install [Visual Studio](https://visualstudio.microsoft.com/downloads/) 16.3 or greater, with the .NET Core cross-platform development workload enabled.
2. Download and install the [Microsoft QDK](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit).

To install the QDK for another environment, enter in the command line:

    `dotnet new -i Microsoft.Quantum.ProjectTemplates`

## Develop with Q#

Follow the instructions at the tab corresponding to your environment.

### [VS Code](#tab/tabid-vscode)

Install the Q# project templates:

1. Open VS Code.
2. Click **View** -> **Command Palette**.
3. Select **Q#: Install project templates**.

When **Project templates installed successfully** displays, the QDK is ready to use with your own applications and libraries.

To create a new project:

1. Click **View** -> **Command Palette** and select **Q#: Create New Project**.
2. Click **Standalone console application**.
3. Navigate to the location to save the project and click **Create Project**.
4. When the project is successfully created, click **Open new project...** in the lower right.
        
Inspect the project. You should see a source file named `Program.qs`, which is a Q# program that defines a simple operation to print a message to the console.

To run the application:
1. Click **Terminal** -> **New Terminal**.
2. At the terminal prompt, enter `dotnet run`.
3. You should see the following text in the output window `Hello quantum world!`


> [!NOTE]
> Workspaces with multiple root folders are not currently supported by the VS Code Q# extension. If you have multiple projects within one VS Code workspace, all projects need to be contained within the same root folder.

### [Visual Studio](#tab/tabid-vs)

Verify your Visual Studio installation by creating a Q# `Hello World` application.

To create a new Q# application:
1. Open Visual Studio and click **File** -> **New** -> **Project**.
2. Type `Q#` in the search box, select **Q# Application** and click **Next**.
3. Enter a name and location for your application and click **Create**.


Inspect the project. You should see a source file named `Program.qs`, which is a Q# program that defines a simple operation to print a message to the console.

To run the application:
1. Select **Debug** -> **Start Without Debugging**.
2. You should see the text `Hello quantum world!` printed to a console window.

> [!NOTE]
> If you have multiple projects within one Visual Studio solution, all projects contained in the solution need to be in the same folder as the solution, or in one of its sub-folders.  

### [Command line or other editors](#tab/tabid-cmdline)

Verify your installation by creating a Q# `Hello World` application.

1. Create a new application:
    ```dotnetcli
    dotnet new console -lang Q# -o runSayHello
    ```

2. Navigate to the application directory:
    ```dotnetcli
    cd runSayHello
    ```

    This directory should now contain a file `Program.qs`, which is a Q# program that defines a simple operation to print a message to the console.

3. Run the program:
    ```dotnetcli
    dotnet run
    ```

4. You should see the following text printed: `Hello quantum world!`

***

## Next steps

Now that you have installed the Quantum Development Kit in your preferred environment, you can write and run [your first quantum program](xref:microsoft.quantum.quickstarts.qrng).

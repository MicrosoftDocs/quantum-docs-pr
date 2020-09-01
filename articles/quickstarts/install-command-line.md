---
title: Develop with Q# applications
author: KittyYeungQ
ms.author: kitty
ms.date: 4/24/2020
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install.standalone
no-loc: ['Q#', '$$v']
---

# Develop with Q# applications

Q# programs can be executed on their own, without a driver in a host language like C#, F#, or Python.

## Prerequisites

- [.NET Core SDK 3.1 or later](https://www.microsoft.com/net/download)

## Installation

While you can build Q# applications in any IDE, we recommend using Visual Studio Code (VS Code) or Visual Studio IDE for developing your Q# applications locally. For developing in the Cloud via the web browser, we recommend Visual Studio Codespaces. Developing in these environments includes the rich functionality of the QDK extension, which includes warnings, syntax highlighting, project templates, and more. 

To configure VS Code:

1. Download and install [VS Code](https://code.visualstudio.com/download) (Windows, Linux and Mac).
2. Install the [Microsoft QDK for VS Code](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode).

To configure Visual Studio:

1. Download and install [Visual Studio](https://visualstudio.microsoft.com/downloads/) 16.3 or greater, with the .NET Core cross-platform development workload enabled.
2. Download and install the [Microsoft QDK](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit).

To configure Visual Studio Codespaces:

1. Create an [Azure account](https://azure.microsoft.com/free/).
2. Create a Codespaces environment. Please follow the [quickstart guide](https://docs.microsoft.com/visualstudio/codespaces/quickstarts/browser). When creating the Codespace, we recommend to enter `microsoft/Quantum` in the "Git Repository" field to load QDK-specific settings.
3. You can now launch your new environment and start developing in the browser via the [VS Codespaces Cloud IDE](https://online.visualstudio.com/environments). Alternatively, it is possible to use your local installation of VS Code and use Codespaces as a [remote environment](https://docs.microsoft.com/visualstudio/online/how-to/vscode).


To install the QDK for another environment, enter at the command prompt:

```dotnetcli
dotnet new -i Microsoft.Quantum.ProjectTemplates
```

## Develop with Q#

Follow the instructions at the tab corresponding to your environment.

### [VS Code](#tab/tabid-vscode)

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

### [Other editors with the command prompt](#tab/tabid-cmdline)

Verify your installation by creating a Q# `Hello World` application.

1. Install the project templates.

    ```dotnetcli
    dotnet new -i Microsoft.Quantum.ProjectTemplates
    ```

1. Create a new application:
    ```dotnetcli
    dotnet new console -lang Q# -o runSayHello
    ```

1. Navigate to the application directory:
    ```dotnetcli
    cd runSayHello
    ```

    This directory should now contain a file `Program.qs`, which is a Q# program that defines a simple operation to print a message to the console. You can modfiy this template with a text editor and overwrite it with your own quantum applications. 

1. Run the program:
    ```dotnetcli
    dotnet run
    ```

1. You should see the following text printed: `Hello quantum world!`

***

## Next steps

Now that you have installed the Quantum Development Kit in your preferred environment, you can write and run [your first quantum program](xref:microsoft.quantum.quickstarts.qrng).

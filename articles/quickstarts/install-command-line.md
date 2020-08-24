---
title: Develop with Q# applications
description: Learn how to create a Q# application that runs from the command prompt.
author: bradben
ms.author: v-benbra
ms.date: 8/20/2020
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install.standalone
no-loc: ['Q#', '$$v']
---

# Develop with Q# applications

Follow the instructions at the tab corresponding to your environment.

## Prerequisites

- Install the [Quantum Development Kit](xref:microsoft.quantum.install) for your environment. 

## [VS Code](#tab/tabid-vscode)

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

## [Visual Studio](#tab/tabid-vs)

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

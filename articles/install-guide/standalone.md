---
title: Execute Q# programs without a driver and a host language 
author: KittyYeungQ
ms.author: kitty
ms.date: 4/24/2020
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install.standalone
---

# Q# Command Line Applications

Q# programs can be executed on their own, without a driver in a host language like C#, F#, or Python.

## Pre-requisites

- [.NET Core SDK 3.1 or later](https://www.microsoft.com/net/download)

## Installation

While you can build Q# command line applications in any IDE, we highly recommend using Visual Studio Code (VS Code) or Visual Studio IDE for your Q# applications. By using VS Code or Visual Studio and the QDK Visual Studio Code extension you gain access to richer functionality.

- Install [VS Code](https://code.visualstudio.com/download) (Windows, Linux and Mac)
- Install the [QDK extension for VS Code](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode)
OR
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) 16.3, with the .NET Core cross-platform development workload enabled
- Download and install the [Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit)


## Develop with Q# using VS Code

Install the Quantum project templates:

- Go to **View** -> **Command Palette**
- Select **Q#: Install project templates**

You now have the Quantum Development Kit installed and ready to use in your own applications and libraries.
- Create a new project:
  - Go to **View** -> **Command Palette**
  - Select **Q#: Create New Project**
  - Select **Standalone console application**
  - Navigate to the location on the file system where you would like to create the application
  - Click on the **Open new project...** button, once the project has been created
        
- Inspect the project
  - You should see that a file called `Program.qs` created, which is a Q# program that defines a simple operation to print a message to the console.

- Run the application:
  - Go to **Terminal** -> **New Terminal**
  - Enter `dotnet run`
  - You should see the following text in the output window `Hello quantum world!`


> [!NOTE]
> * Workspaces with multiple root folders are not currently supported by the Visual Studio Code extension. If you have multiple projects within one VS Code workspace, all projects need to be contained within the same root folder.

## Develop with Q# using Visual Studio

Verify the installation by creating a `Hello World` application

- Create a new Q# application
  - Go to **File** -> **New** -> **Project**
  - Type `Q#` in the search box
  - Select **Q# Application**
  - Select **Next**
  - Choose a name and location for your application
  - Select **Create**

- Inspect the project
  - You should see that a file called `Program.qs` has been created, which is a Q# program that defines a simple operation to print a message to the console.

- Run the application
  - Select **Debug** -> **Start Without Debugging**
  - You should see the text `Hello quantum world!` printed to a console window.

> [!NOTE]
> * If you have multiple projects within one Visual Studio solution, all projects contained in the solution need to be in the same folder as the solution, or in one of its subfolders.  


## What's next?

Now that you have installed the Quantum Development Kit in your preferred environment, you can write and run [your first quantum program](xref:microsoft.quantum.write-program).

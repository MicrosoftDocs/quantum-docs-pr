---
title: Learn how to update the Microsoft Quantum Development Kit (QDK)
description: Describes how to update your Q# projects and the Microsoft Quantum Development Kit to the current version.  
author: natke
ms.author: nakersha
ms.date: 9/30/2019
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.update
---

# Update the Microsoft Quantum Development Kit (QDK)

Learn how to update the Microsoft Quantum Development Kit (QDK) to the latest version.

This article assumes that you already have the QDK installed. If you are installing for the first time, then please refer to the [installation guide](xref:microsoft.quantum.install).

We recommend keeping up to date with the latest QDK release. Follow this update guide to upgrade to the most recent QDK version. 
The process consists of two parts:
1. updating your existing Q# files and projects to align your code with any updated syntax
2. updating the QDK itself for your chosen development environment 

## Updating Q# Projects 

Regardless of whether you are using C# or Python to host Q# operations, follow these instructions to update your Q# projects.

1. First, check that you have the latest version of the [.NET Core SDK 3.1](https://dotnet.microsoft.com/download). Run the following command in the command prompt:

    ```dotnetcli
    dotnet --version
    ```

    Verify the output is `3.1.100` or higher. If not, install the [latest version](https://dotnet.microsoft.com/download) and check again. Then follow the instructions below depending on your setup (Visual Studio, Visual Studio Code, or directly the command line).

### Update Q# projects in Visual Studio
 
1. Update to the latest version of Visual Studio 2019, see [here](https://docs.microsoft.com/visualstudio/install/update-visual-studio?view=vs-2019) for instructions
2. Open your solution in Visual Studio
3. From the menu, select **Build** -> **Clean Solution**
4. In each of your .csproj files, update the target framework to `netcoreapp3.1` (or `netstandard2.1` if it is a library project).
    That is, edit lines of the form:

    ```xml
    <TargetFramework>netcoreapp3.1</TargetFramework>
    ```

    You can find more details on specifying target frameworks [here](https://docs.microsoft.com/dotnet/standard/frameworks#how-to-specify-target-frameworks).
5. Save and close all files in your solution
6. Select **Tools** -> **Command Line** -> **Developer Command Prompt**
7. For each project in the solution, run the following command:

    ```dotnetcli
    dotnet add [project_name].csproj package Microsoft.Quantum.Development.Kit
    ```

   If your projects use any other Microsoft.Quantum packages (e.g. Microsoft.Quantum.Numerics), run the command for these too.
8. Close the command prompt and select **Build** -> **Build Solution** (do *not* select Rebuild Solution)

You can now skip ahead to [update your Visual Studio QDK extension](#update-visual-studio-qdk-extension).


### Update Q# projects in Visual Studio Code

1. In Visual Studio Code, open the folder containing the project to update
2. Select **Terminal** -> **New Terminal**
3. Follow the instructions for updating using the command line (directly below)

### Update Q# projects using the command line

1. Navigate to the folder containing your project file
2. Run the following command:

    ```dotnetcli
    dotnet clean [project_name].csproj
    ```

3. In each of your .csproj files, update the target framework to `netcoreapp3.1` (or `netstandard2.1` if it is a library project).
    That is, edit lines of the form:

    ```xml
    <TargetFramework>netcoreapp3.1</TargetFramework>
    ```

    You can find more details on specifying target frameworks [here](https://docs.microsoft.com/dotnet/standard/frameworks#how-to-specify-target-frameworks).
4. Run the following command:

    ```dotnetcli
    dotnet add package Microsoft.Quantum.Development.Kit
    ```

    If your project uses any other Microsoft.Quantum packages (e.g. Microsoft.Quantum.Numerics), run the command for these too.
5. Save and close all files.
6. Repeat 1-4 for each project dependency, then navigate back to the folder containing your main project and run:

    ```dotnetcli
    dotnet build [project_name].csproj
    ```

With your Q# projects now updated, follow the instructions below to update the QDK itself.

## Updating the QDK

The process to update the QDK varies depending on your development language and environment.
Select your development environment below.

* [Python: update the IQ# extension](#update-iq-for-python)
* [Jupyter Notebooks: update the IQ# extension](#update-iq-for-jupyter-notebooks)
* [Visual Studio: update the QDK extension](#update-visual-studio-qdk-extension)
* [VS Code: update the QDK extension](#update-vs-code-qdk-extension)
* [Command-line and C#: update project templates](#c-using-the-dotnet-command-line-tool)


### Update IQ# for Python

1. Update the `iqsharp` kernel 

    ```dotnetcli
    dotnet tool update -g Microsoft.Quantum.IQSharp
    dotnet iqsharp install
    ```

2. Verify the `iqsharp` version

    ```dotnetcli
    dotnet iqsharp --version
    ```

    You should see the following output:

    ```bash
    iqsharp: 0.10.1912.501
    Jupyter Core: 1.2.20112.0
    ```

    Don't worry if your `iqsharp` version is higher, it should match the [latest release](xref:microsoft.quantum.relnotes).

3. Update the `qsharp` package

    ```bash
    pip install qsharp --upgrade
    ```

4. Verify the `qsharp` version

    ```bash
    pip show qsharp
    ```

    You should see the following output:

    ```bash
    Name: qsharp
    Version: 0.10.1912.501
    Summary: Python client for Q#, a domain-specific quantum programming language
    ...
    ```

5. Run the following command from the location of your `.qs` files

    ```bash
    python -c "import qsharp; qsharp.reload()"
    ```

6. You can now use the updated QDK version to run your existing quantum programs.

### Update IQ# for Jupyter Notebooks

1. Update the `iqsharp` kernel

    ```dotnetcli
    dotnet tool update -g Microsoft.Quantum.IQSharp
    dotnet iqsharp install
    ```

2. Verify the `iqsharp` version

    ```dotnetcli
    dotnet iqsharp --version
    ```

    Your output should be similar to the following:

    ```bash
    iqsharp: 0.10.1912.501
    Jupyter Core: 1.2.20112.0
    ```

    Don't worry if your `iqsharp` version is higher, it should match the [latest release](xref:microsoft.quantum.relnotes).

3. Run the following command from a cell in your Jupyter Notebook:

    ```
    %workspace reload
    ```

4. You can now open an existing Jupyter notebook and run it with the updated QDK.

### Update Visual Studio QDK extension

1. Update the Q# Visual Studio extension

    - Visual Studio prompts you to accept updates to the [Quantum Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit)
    - Accept the update

    > [!NOTE]
    > The project templates are updated with the extension. The updated templates apply to newly created projects only. The code for your existing projects is not updated when the extension is updated.

### Update VS Code QDK extension

1. Update the Quantum VS Code extension

    - Restart VS Code
    - Navigate to the **Extensions** tab
    - Select the **Microsoft Quantum Development Kit for Visual Studio Code** extension
    - Reload the extension

2. Update the Quantum project templates:

   - Go to **View** -> **Command Palette**
   - Select **Q#: Install project templates**
   - After a few seconds you should get a popup confirming "project templates installed successfully"

### C#, using the `dotnet` command-line tool

1. Update the Quantum project templates for .NET

    ```dotnetcli
    dotnet new -i Microsoft.Quantum.ProjectTemplates
    ```

## What's next?

Now that you have updated the Quantum Development Kit in your preferred environment, you can continue to develop and run your quantum programs. If you have not written a program yet, you can get started with [your first quantum program](xref:microsoft.quantum.write-program).

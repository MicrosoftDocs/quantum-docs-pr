---
title: Learn how to update the Microsoft Quantum Development Kit (QDK)
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


## Updating Q# Projects 

1. First, install the latest version of the [.NET Core SDK 3.0](https://dotnet.microsoft.com/download) and run the following command in the command prompt:
```bash
dotnet --version
```
 Verify the output is 3.0.100 or higher, then follow the instructions below depending on your setup.

### In Visual Studio
 
 1. Update to the latest version of Visual Studio 2019, see [here](https://docs.microsoft.com/visualstudio/install/update-visual-studio?view=vs-2019) for instructions
 2. Open your solution in Visual Studio
 3. From the menu, select Build > Clean Solution 
 4. [Update the target framework](https://docs.microsoft.com/en-us/visualstudio/ide/visual-studio-multi-targeting-overview?view=vs-2019#change-the-target-framework) in each of your .csproj files to netcoreapp3.0 (or netstandard2.1 if it is a library project)
 5. Save and close all files in your solution
 6. Select Tools > Command Line > Developer Command Prompt
 7. For each project in the solution, run the following command:
 ```bash
 dotnet add [path\to\project_name].csproj package Microsoft.Quantum.Development.Kit`
 ```
If your projects use any other Microsoft.Quantum packages, run the command for these too. 
 8. Close the command prompt and select Build > Build Solution (do *not* select Rebuild Solution, as rebuilding will initially fail)

### In Visual Studio Code

1. In Visual Studio Code, open the folder containing the project to update
1. Select Terminal > New Terminal
1. Follow the instructions for updating using the command line

### Using the command line

1. Navigate to the folder containing your project file
2. Run the following command:
```bash
dotnet clean [project_name].csproj
```

3. Update the target framework in each of your .csproj files to netcoreapp3.0 (or netstandard2.1 if it is a library project)
4. Run the following command:
```bash
dotnet add package Microsoft.Quantum.Development.Kit
```
if your project uses any other Microsoft.Quantum packages, run the command for these too.

5. Save and close all files
6. Repeat 1-4 for each project dependency, then navigate back to the folder containing your main project and run:
```bash
dotnet build [project_name].csproj
```

## Update IQ# for Python

1. Update the `iqsharp` kernel

    ```bash
    dotnet tool update -g Microsoft.Quantum.IQSharp
    dotnet iqsharp install
    ```

1. Verify the `iqsharp` version

    ```bash
    dotnet iqsharp --version
    ```

    You should see the following output:

    ```bash
    iqsharp: 0.10.1910.3107
    Jupyter Core: 1.2.20112.0
    ```

1. Update the `qsharp` package

    ```bash
    pip install qsharp --upgrade
    ```

1. Verify the `qsharp` version

    ```bash
    pip show qsharp
    ```

    You should see the following output:

    ```bash
    Name: qsharp
    Version: 0.10.1910.3107
    Summary: Python client for Q#, a domain-specific quantum programming language
    ...
    ```
1. Run the following command from the location of your `.qs` files
```bash
python -c "import qsharp; qsharp.reload()
```

1. You can now use the updated QDK version to run your existing quantum programs.

## Update IQ# for Jupyter notebooks

1. Update the `iqsharp` kernel

    ```bash
    dotnet tool update -g Microsoft.Quantum.IQSharp
    dotnet iqsharp install
    ```

1. Verify the `iqsharp` version

    ```bash
    dotnet iqsharp --version
    ```

    You should see the following output:

    ```bash
    iqsharp: 0.10.1910.3107
    Jupyter Core: 1.2.20112.0
    ```
1. Run the following command from a cell in your Jupyter Notebook:
```
%workspace reload
```

1. You can now open an existing Jupyter notebook and run it with the updated QDK.

## Update Visual Studio QDK extension

1. Update the Q# Visual Studio extension

    - Visual Studio prompts you to accept updates to the [Quantum Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit)
    - Accept the update

    > [!NOTE]
    > The project templates are updated with the extension. The updated templates apply to newly created projects only. The code for your existing projects is not updated when the extension is updated.

1. You can now run your application with the latest QDK.

## Update VS Code QDK extension

1. Update the Quantum VS Code extension

    - Restart VS Code
    - Navigate to the **Extensions** tab
    - Select the **Microsoft Quantum Development Kit for Visual Studio Code** extension
    - Reload the extension

1. Update the Quantum project templates:

   - Go to **View** -> **Command Palette**
   - Select **Q#: Install project templates**

1. You can now run your application with the latest QDK.

## C#, using the `dotnet` command-line tool

1. Update the Quantum project templates for .NET

    ```bash
    dotnet new -i Microsoft.Quantum.ProjectTemplates
    ```
    
1. You can now run your application with the latest QDK.

## What's next?

Now that you have updated the Quantum Development Kit in your preferred environment, you can continue to develop and run your quantum programs. If you have not written a program yet, you can get started with [your first quantum program](xref:microsoft.quantum.write-program).

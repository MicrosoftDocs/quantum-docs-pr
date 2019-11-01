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

The update steps depend on your development environment. Choose your environment from the following sections.

## Python

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
    iqsharp: 0.9.1909.3002
    Jupyter Core: 1.1.18837.0
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
    Version: 0.9.1909.3002
    Summary: Python client for Q#, a domain-specific quantum programming language
    ...
    ```

1. You can now use the updated QDK version to run your existing quantum programs.

## Jupyter notebooks

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
    iqsharp: 0.9.1909.3002
    Jupyter Core: 1.1.18837.0
    ```

1. You can now open an existing Jupyter notebook and run it with the updated QDK.

## C# on Windows, using Visual Studio

 > [!NOTE]
 > If you are updating to .NET Core SDK 3.0, you will need to go through these additional update instructions:
 > 1. Run Build > Clean Solution 
 > 2. Update the Q# Visual Studio extension using the instructions below
 > 3. Update the target framework in your .csproj file to netcoreapp3.0, save and close your solution
 > 4. Download and install [.NET Core SDK 3.0](https://docs.microsoft.com/en-us/quantum/relnotes/?view=qsharp-preview)
 > 5. Re-open your solution and run Build > Rebuild Solution

1. Update the Q# Visual Studio extension

    - Visual Studio prompts you to accept updates to the [Quantum Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit)
    - Accept the update

    > [!NOTE]
    > The project templates are updated with the extension. The updated templates apply to newly created projects only. The code for your existing projects is not updated when the extension is updated.

1. Update the QDK packages

    - Open an existing application
    - Select **Dependencies** in the Solution Explorer
    - Select **Manage NuGet Packages**
    - Update the **Microsoft.Quantum** packages to the latest version

1. You can now run your application with the latest QDK.

## C#, using VS Code

1. Update the Quantum VS Code extension

    - Restart VS Code
    - Navigate to the **Extensions** tab
    - Select the **Microsoft Quantum Development Kit for Visual Studio Code** extension
    - Reload the extension

1. Update the Quantum project templates:

   - Go to **View** -> **Command Palette**
   - Select **Q#: Install project templates**

1. Open an existing application in VS Code

   - Edit the .csproj file to add the new package versions

    ```xml
    <ItemGroup>
        <PackageReference Include="Microsoft.Quantum.Standard" Version="0.9.1909.3002" />
        <PackageReference Include="Microsoft.Quantum.Development.Kit" Version="0.9.1909.3002" />
    </ItemGroup>
    ```

    If you use other `Microsoft.Quantum` packages, update these too.

1. You can now run your application with the updated QDK

## C#, using the `dotnet` command-line tool

1. Update the Quantum project templates for .NET

    ```bash
    dotnet new -i Microsoft.Quantum.ProjectTemplates
    ```

1. Update and run an existing application

    - Update the QDK package versions in your application

        ```bash
        dotnet add package Microsoft.Quantum.Development.Kit
        dotnet add package Microsoft.Quantum.Standard
        ```

        If your application uses any other `Microsoft.Quantum` packages, update these too.

    - Run the application

        ```bash
        dotnet run
        ```

    - Your application will run with the new package versions

## What's next?

Now that you have updated the Quantum Development Kit in your preferred environment, you can continue to develop and run your quantum programs. If you have not written a program yet, you can get started with [your first quantum program](xref:microsoft.quantum.write-program).

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

This article assumes that you already have the QDK installed. If you are installing for the first time, then please refer to the [installation guide](xref:microsoft.quantum.install)

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
    iqsharp: 0.9.1908.2906
    Jupyter Core: 1.1.14623.0
    ```

1. Update the `qsharp` package

    ```bash
    pip install qsharp --upgrade
    ```

1. Verify the `qsharp` version

    ```bash
    pip show qsharp
    ```

    You see the following output:

    ```bash
    Name: qsharp
    Version: 0.9.1908.2906
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
    iqsharp: 0.9.1908.2906
    Jupyter Core: 1.1.14623.0
    ```

1. You can now open an existing Jupyter notebook and run it with the updated QDK.

## C# on Windows, using Visual Studio

1. Update the Q# Visual Studio extension

    - Download the [Quantum Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit)
    - Add the extension to Visual Studio

1. Open an existing Q# project in Visual Studio

    - TODO

## Develop with C#, using VS Code

1. Update the Quantum VS Code extension

    - Update the [Quantum VS Code extension](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode)

1. Update the Quantum project templates:

   - Go to **View** -> **Command Palette**
   - Select **Q#: Install project templates**

    You now have the Quantum Development Kit installed and ready to use in your own applications and libraries.

1. Open an existing application in VS Code

   - Edit the .csproj file to add the new package versions

    ```xml
    <ItemGroup>
        <PackageReference Include="Microsoft.Quantum.Standard" Version="0.9.1908.2906" />
        <PackageReference Include="Microsoft.Quantum.Development.Kit" Version="0.9.1908.2906" />
    </ItemGroup>
    ```

   - Run the application

## Develop with C#, using the `dotnet` command-line tool

1. Update the Quantum project templates for .NET

    ```bash
    dotnet new -i Microsoft.Quantum.ProjectTemplates
    ```

    You now have the Quantum Development Kit installed and ready to use in your own applications and libraries.

1. Update and run an existing application

    - Update the QDK package versions in your application

        ```bash
        dotnet add package Microsoft.Quantum.Development.Kit
        dotnet add package Microsoft.Quantum.Standard
        ```

    - Run the application

        ```bash
        dotnet run
        ```

    - Your application should run with the new package versions

## What's next?

Now that you have updated the Quantum Development Kit in your preferred environment, you can continue to develop and run your quantum programs. If you have not written a program yet, you can get started with [your first quantum program](xref:microsoft.quantum.write-program).

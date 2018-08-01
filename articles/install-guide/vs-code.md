---
title: Installing the Q# development environment for VS Code
author: cgranad
uid: microsoft.quantum.install.vs-code
ms.author: christopher.granade@microsoft.com
ms.date: 7/31/2018
ms.topic: article
---

# Installing the Quantum Development Kit for Visual Studio Code #

## Installing Visual Studio Code and the .NET Core SDK (Windows 10, macOS, Linux) ##

The Quantum Development Kit uses the .NET Core SDK (2.0 or later) to make it easy to create, build, and run Q# projects from the command line.
We recommend using the Quantum Development Kit together with Visual Studio Code.

1. Please see [Getting started with .NET](https://www.microsoft.com/net/learn/get-started) for how to download and install the .NET Core SDK.

2. Once the .NET Core SDK is installed, run the following command in your favorite command line (e.g.: PowerShell or Bash) to download the latest templates for creating new Q# applications and libraries:
   ```Bash
   $ dotnet new -i "Microsoft.Quantum.ProjectTemplates::0.2.1806.3001-preview"
   ```

3. Go to the [Visual Studio Code website](https://code.visualstudio.com/).

4. Pick the download for your platform and follow the installation prompts.

5. Once Visual Studio Code is installed, go to the [Microsoft Quantum Development Kit for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode) extension on the Visual Studio Marketplace and press Install.

> [!NOTE]
> When you run Visual Studio Code for the first time, you may be prompted to install Git if you have not already done so.
> Git is not required to use the Quantum Development Kit, but works great for managing and sharing Q# projects, and for contributing back to the Q# libraries and samples.

> [!TIP]
> You can also install the Quantum Development Kit extension for Visual Studio Code from the *Go to file...* palette.
> Press **Ctrl+P** or **⌘+P** from within Visual Studio Code, type or paste `ext install quantum.quantum-devkit-vscode`, and press **Enter**.

You should now have the Quantum Development Kit installed and ready to use in your own applications and libraries.

## Building the Quantum Samples and Libraries

In this section you will clone the quantum samples & libraries repository, and run a sample application to verify that your Q# environment is correctly installed and configured.

3. Clone and open the [Microsoft Quantum Developer Kit Samples and Libraries](https://github.com/microsoft/quantum) GitHub repository.
  ```bash
  $ git clone https://github.com/Microsoft/Quantum.git
  ```
  To continue at the command line, navigate into the newly cloned directory:
  ```bash
  $ cd Quantum
  ```
  If you would like to work with the new project in VS Code, run:
  ```bash
  $ code .
  ```
  You may be prompted to install the Microsoft Quantum Development Kit for Visual Studio Code and the Microsoft C# extension if you haven't already done so.

  > [!TIP]
  > If you are running on macOS and the `code` command is missing, you may need to [install the command line interface for Visual Studio Code](https://code.visualstudio.com/docs/editor/command-line).

4. From the terminal (standalone, or the embedded terminal in Visual Studio Code), run the teleport sample program:
  ```bash
  $ cd Samples/Teleportation/
  $ dotnet run
  ```

If the program runs and the output is similar to the following (has 8 rounds of successful teleportation with varying values True/False sent each round), your Q# environment is ready to support Q# development.

  ```
          Round 0:        Sent True,      got True.
          Teleportation successful!!
          Round 1:        Sent False,     got False.
          Teleportation successful!!
          ...
          Round 6:        Sent True,      got True.
          Teleportation successful!!
          Round 7:        Sent False,     got False.
          Teleportation successful!!
  ```


### Optional Dependencies ###

Some of the samples demonstrate using the Quantum Development Kit with other programming environments, and have additional installation requirement:

- Some samples use the Node.js Package Manager (NPM) to handle user interface dependencies.
  NPM can be installed [manually](https://nodejs.org/en/download/current/) or through a [package manager](https://nodejs.org/en/download/package-manager/).
- The Python interoperability feature (currently in Windows-only preview) has been developed for the [Anaconda distribution](https://www.anaconda.com/download/) of Python 3.6.
  Please see the [README](https://github.com/Microsoft/Quantum/tree/master/Samples/PythonInterop/README.md) file provided with the Python sample for more details.

Additionally, the Quantum Development Kit is provided along with libraries for non-commercial use.
These libraries may be found in the [Microsoft/Quantum-NC](https://github.com/microsoft/quantum-nc) repository on GitHub.

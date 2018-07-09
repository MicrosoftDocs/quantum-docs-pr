---
# Mandatory fields.
title: Setting up the Q# development environment 
author: QuantumWriter
ms.author: Alan.Geller@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# For Quantum products none of these categories have been defined  yet.
# ms.service: service-name-from-white-list
# ms.prod: product-name-from-white-list
# ms.technology: tech-name-from-white-list
---

# Installing the Quantum Development Kit

The Quantum Development Kit can be used either with the Visual Studio 2017 integrated development environment, or with the command line and a development editor such as Visual Studio Code.
We'll walk through both methods in this install guide.

> [!NOTE]
> The Quantum Development Kit requires a 64-bit installation of Windows 10, macOS, or Linux.
> Microsoft's quantum simulator, installed with the Quantum Development Kit, utilizes Advance Vector Extensions (AVX), and thus can run significantly more efficiently on an AVX-enabled CPU.
> The Quantum Development Kit will still run on non–AVX enabled CPUs, but may not be as efficient.
> Intel processors shipped in Q1 2011 (Sandy Bridge) or later support AVX.

### [Installing Visual Studio 2017 (Windows only)](#tab/tabid-vs2017)

> [!NOTE]
> Microsoft Quantum Development Kit does not support Visual Studio for Mac.
> For development on macOS, we recommend Visual Studio Code.

If you do not have Visual Studio installed, you can download Visual Studio 2017 Community Edition for free.
1. Go to the [Visual Studio download page](https://www.visualstudio.com/downloads/).
1. Click on the Visual Studio Community **Free download** button.
2. Navigate to your browser's download folder and double click on the executable file whose name begins with **vs_community**. The file name will contain a sequence of numbers that varies.
3. _**Important!**_ &nbsp;When you are presented with the option to select the tools for specific workloads, check the box for **.NET Core cross-platform development**.
   If there are any other workloads you would like to install, you can select them as well at this step.
4. After selecting your workloads, click **Install** to complete the installation.
5. Once you have installed Visual Studio 2017, download the [Microsoft Quantum Development Kit for Visual Studio](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit) extension from the Visual Studio Marketplace.
   Double-click the VSIX once it is downloaded to install the extension.

### [Installing Visual Studio Code and the .NET Core SDK (Windows, macOS, Linux)](#tab/tabid-vscode)

The Quantum Development Kit uses the .NET Core SDK (2.0 or later) to make it easy to create, build, and run Q# projects from the command line.
We recommend using the Quantum Development Kit together with Visual Studio Code.

1. Please see [Getting started with .NET](https://www.microsoft.com/net/learn/get-started) for how to download and install the .NET Core SDK.

2. Once the .NET Core SDK is installed, run the following command in your favorite command line (e.g.: PowerShell or Bash) to download the latest templates for creating new Q# applications and libraries:
   ```bash
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

****

You should now have the Quantum Development Kit installed and ready to use in your own applications and libraries.
The next section will cover how to build the samples and standard libraries provided along with the Quantum Development Kit.

## Building the Quantum Samples and Libraries

In this section you will clone the quantum samples & libraries repository, and run a sample application to verify that your Q# environment is correctly installed and configured.

#### [Visual Studio 2017](#tab/tabid-vs2017)

2. Clone and open the [Microsoft Quantum Developer Kit Samples and Libraries](https://github.com/microsoft/quantum) GitHub repository.
    1. Open Visual Studio.
    2. Open the **Connect** view in **Team Explorer** (`Team` > `Manage Connections`)
    3. Select **Clone** under **Local Git Repositories** and enter `https://github.com/Microsoft/Quantum.git`
    4. Click **Clone** to clone the repo.
    5. The repository will be cloned on your local computer and Visual Studio will switch to the **Solution Explorer** on the right populated with the libraries and samples.
    6. Open the `QsharpLibraries.sln` solution.
      - If prompted by the **Install Missing Features** pane, click **Install** to allow the installation of the necessary features. This is most often F# and tools used by some of the samples.
    7. (Optional) To install libraries for non-commercial use, navigate to [Microsoft/Quantum-NC](https://github.com/microsoft/quantum-nc) on GitHub. Then clone the repository and open the `Quantum-NC.sln` solution.

3. Validate your Q# environment by running the teleport sample program:
   1. Right click on the `TeleportationSample` project in `Samples` > `0.Introduction` folder of `QsharpLibraries` solution, and left click on "Set as Startup Project".
   2. Run the solution (F5.)

> [!Tip]
> If you receive a number of errors that reference NuGet packages, use the procedures in [NuGet package restore](https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore) to restore the packages.

#### [Command Line / Visual Studio Code](#tab/tabid-vscode)

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
****

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
- The Python interoperability feature has been developed for the [Anaconda distribution](https://www.anaconda.com/download/) of Python 3.6.
  Please see the [README](https://github.com/Microsoft/Quantum/tree/master/Samples/PythonInterop/README.md) file provided with the Python sample for more details.

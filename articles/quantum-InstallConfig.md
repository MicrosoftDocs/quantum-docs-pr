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

# Installing and Validating the Q# Development Environment

## Required Prerequisites

- A 64-bit installation of Windows, macOS, or Linux. (the Microsoft Quantum Development Kit has been tested under Ubuntu Linux, but may work on other distributions).
- The [.NET Core SDK 2.0](https://www.microsoft.com/net/learn/get-started) or later.


## Optional Prerequisites

- A development environment with .NET Core support:
    - For Windows: We recommend [Visual Studio 2017](https://www.visualstudio.com/) and the [Microsoft Quantum Development Kit](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit) extension. You can also use [Visual Studio Code](https://code.visualstudio.com/) and the [Microsoft Quantum Development Kit for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode) extension.
    - For macOS or Linux: We recommend [Visual Studio Code](https://code.visualstudio.com/) and the [Microsoft Quantum Development Kit for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode) extension.
- Microsoft's quantum simulator, installed with the Quantum Development Kit, utilizes Advance Vector Extensions (AVX), and thus can run significantly more efficiently on an AVX-enabled CPU.
  The Quantum Development Kit will still run on non–AVX enabled CPUs, but may not be as efficient.
  Intel processors shipped in Q1 2011 (Sandy Bridge) or later support AVX.
- Some samples use the Node.js Package Manager (NPM) to handle user interface dependencies.
  NPM can be installed [manually](https://nodejs.org/en/download/current/) or through a [package manager](https://nodejs.org/en/download/package-manager/).
- The Python interoperability feature has been developed for the [Anaconda distribution](https://www.anaconda.com/download/) of Python 3.6.
  Please see the [README](https://github.com/Microsoft/Quantum/tree/master/Samples/PythonInterop/README.md) file provided with the Python sample for more details.

#### [Installing Visual Studio 2017 (Windows only)](#tab/tabid-vs2017)

If you do not have Visual Studio installed, you can download Visual Studio 2017 Community Edition for free.
1. Go to the [Visual Studio download page](https://www.visualstudio.com/downloads/).
1. Click on the Visual Studio Community **Free download** button.
2. Navigate to your browser's download folder and double click on the executable file whose name begins with **vs_community**. The file name will contain a sequence of numbers that varies.
3. _**Important!**_ &nbsp;When you are presented with the option to select the tools for specific workloads, check the box for **.NET Core cross-platform development**. If there are any other workloads you would like to install, you can select them as well at this step.
4. After selecting your workloads, click **Install** to complete the installation.

#### [Installing Visual Studio Code (Windows, macOS, Linux)](#tab/tabid-vscode)

You can download Visual Studio Code for free for your platform.
1. Go to the [Visual Studio Code website](https://code.visualstudio.com/).
2. Pick the download for your platform and follow the installation prompts.

****

## Installing and Validating the Q# Development Environment

In this section you will clone the quantum samples & libraries repository, and run a sample application to verify that your Q# environment is correctly installed and configured.

#### [Visual Studio 2017](#tab/tabid-vs2017)

1. Install the [Microsoft Quantum Development Kit](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit) extension.

  > [!NOTE]
  > Microsoft Quantum Development Kit does not support Visual Studio for Mac. For development on macOS, we recommend Visual Studio Code.

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

1. If you intend to use Visual Studio Code, install the [Microsoft Quantum Development Kit for Visual Studio Code]( https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode) extension.

2. Install the Q# Development Kit project templates.
   From your favorite command line (e.g.: PowerShell or Bash), run the following command:
  ```bash
  $ dotnet new -i "Microsoft.Quantum.ProjectTemplates::0.2.1806.1503-preview"
  ```

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


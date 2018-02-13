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

- A 64-bit installation of Windows, macOS, or Linux.
  The Quantum Development Kit has been tested under Ubuntu Linux, but may work on other distributions.
- The [.NET Core SDK 2.0](https://www.microsoft.com/net/learn/get-started) or later.

## Optional Prerequisites

- Microsoft's quantum simulator, installed with the Quantum Development Kit, utilizes Advance Vector Extensions (AVX), and thus can run significantly more efficiently on an AVX-enabled CPU.
  Intel processors shipped in Q1 2011 (Sandy Bridge) or later support AVX.
- A development environment with .NET Core support:
    - For Windows, macOS or Linux: [Visual Studio Code](https://code.visualstudio.com/) and the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp).
    - For Windows: Visual Studio 2017.
      (NB: Visual Studio for Mac has not yet been tested.)
- Some samples use the Node.js Package Manager (NPM) to handle user interface dependencies.
  NPM can be installed [manually](https://nodejs.org/en/download/current/) or through a [package manager](https://nodejs.org/en/download/package-manager/).

If you do not have Visual Studio installed, you can download Visual Studio 2017 Community Edition for free.
1. Go to the [Visual Studio download page](https://www.visualstudio.com/downloads/).
1. Click on the Visual Studio Community **Free download** button.
2. Navigate to your browser's download folder and double click on the executable file whose name begins with **vs_community**. The file name will contain a sequence of numbers that varies.
3. _**Important!**_ &nbsp;When you are presented with the option to select the tools for specific workloads, check the boxes for **Universal Windows Platform development** and **.NET desktop development**
4. After selecting your workloads, click **Install** to complete the installation.

## Creating the Q# Development Environment

1. Install the Microsoft Quantum Development Kit

    1. Browse to the [Microsoft Quantum](https://www.microsoft.com/en-us/quantum/development-kit) page and click the **Download now** button in the upper left.
    2. On the Visual Studio Marketplace [Quantum Development Kit](https://marketplace.visualstudio.com/items?itemName=quantum.DevKit) page, click **Download**. 
    3. Your browser will ask you whether you wish to **Open** or **Save** the download, click **Open**.
    4. Your security software may present a confirmation pane. Click **Allow**, or the comparable term used by your browser.
    5. The Quantum Development Kit extension will be installed in Visual Studio 2017.

## Validating Your Environment

In this section you will clone the quantum samples & libraries, and run a sample application to verify that your Q# environment is correctly installed and configured. 

1. Clone the [Microsoft Quantum Developer Kit Samples and Libraries](https://github.com/microsoft/quantum) GitHub repository.
    1. Open Visual Studio.
    2. Open the **Connect** view in **Team Explorer** (`Team` > `Manage Connections`)
    3. Select **Clone** under **Local Git Repositories** and enter `https://github.com/Microsoft/Quantum.git`
    4. Click **Clone** to clone the repo.
    5. The repository will be cloned on your local computer and Visual Studio will switch to the **Solution Explorer** on the right populated with the libraries and samples.

2. Open the `QsharpLibraries.sln` solution. 
    - If prompted by the **Install Missing Features** pane, click **Install** to allow the installation of the necessary features. This is most often F# and tools used by some of the samples.

3. Validate your Q# environment by running the teleport sample program:
    
   1. Right click on the `TeleportationSample` project in `Samples` > `0.Introduction` folder of `QsharpLibraries` solution, and left click on "Set as Startup Project".
   2. Run the solution (F5.) If teleport runs and the output is similar to the following (has 8 rounds of successful teleportation with varying values True/False sent each round), your Q# environment is ready to support Q# development.

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

> [!Tip]
> If you receive a number of errors that reference NuGet packages, use the procedures in [NuGet package restore](https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore) to restore the packages.

---
title: Chemistry Library Installation and Validation | Microsoft Docs
description: Chemistry Library Installation and Validation
author: Guang Hao Low
ms.author: GuangHao.Low@microsoft.com
ms.date: 10/12/2018
ms.topic: article
uid: microsoft.quantum.chemistry.concepts.installation
---

# Chemistry Library Installation and Validation

The Quantum Development Kit provides support for quantum chemistry applications through the [`Microsoft.Quantum.Chemistry`](https://www.nuget.org/packages/Microsoft.Quantum.Chemistry) NuGet package.
As with other NuGet packages, it's straightforward to add the chemistry library to your project.

**Visual Studio 2017:** If you are using Visual Studio 2017, you can add the quantum chemistry packages by using the NuGet Package Manager.
To open the Package Manager, right-click on the project you'd like to add the chemistry library to and select "Manage NuGet Packages...," as in the screenshot below.

![](../../media/vs2017-nuget-manage-packages.png)

From the Browse tab, search for the package name "Microsoft.Quantum.Chemistry."

> [!NOTE]
> Make sure to tick "Include prerelease."

![](../../media/vs2017-nuget-package-search.png)

This will list the packages available for download.
Click on the "Microsoft.Quantum.Chemistry on the left-hand pane, select the latest pre-release version on the right-hand pane, and click "Install":

![](../../media/vs2017-nuget-select-chem.png)

For more details, see the [Package Manager UI guide](https://docs.microsoft.com/en-us/nuget/tools/package-manager-ui).

Alternatively, you can use the Package Manager Console to add the quantum chemistry library to your project with a command line interface.

![](../../media/vs2017-nuger-console-menu.png)

From the package manager console, run the following:

```
Install-Package Microsoft.Quantum.Chemistry
```

For more details, see the [Package Manager Console guide](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console).

**Command line or Visual Studio Code 2017:** Using the command line on its own or from within Visual Studio Code, you can use the `dotnet` command to add NuGet package reference to your project:

```bash
dotnet add package Microsoft.Quantum.Chemistry
```

## Using the Quantum Development Kit with NWChem ##

The quantum chemistry library for the Quantum Development Kit is designed to work well with computational chemistry packages, most notably the [**NWChem**](http://www.nwchem-sw.org/) computational chemistry platform developed by the Environmental Molecular Sciences Laboratory (EMSL) at Pacific Northwest National Laboratory.
In particular, the `Microsoft.Quantum.Chemistry` package provides tools for loading instances of quantum chemistry simulation problems represented in the [Broombridge schema](xref:quantum.libraries.chemistry.schema.intro), also supported for export by recent versions of NWChem.

To get up and running using NWChem together with the Quantum Development Kit, we suggest one of the following methods:
- Using existing Broombridge files provided with the samples at [IntegralData](https://github.com/Microsoft/Quantum/tree/master/Chemistry/IntegralData),
- Using the [EMSL Arrows Builder for the Microsoft Quantum Development Kit](https://arrows.emsl.pnnl.gov/api/qsharp_chem) which is a web-based frontend to NWChem,
- [Compiling NWChem](http://www.nwchem-sw.org/index.php/Compiling_NWChem) for your platform, or 
- Using the [Docker image](https://hub.docker.com/r/nwchemorg/nwchem-qc/) provided by PNNL.

Here, we provide details as to how to run NWChem locally by compiling from source, or by using Docker.

### Installing NWChem from Source

Full instructions on how to install NWChem from source [are provided by PNNL](http://www.nwchem-sw.org/index.php/Compiling_NWChem).

> [!TIP]
> If you wish to use NWChem from Windows 10, the Windows Subsystem for Linux is a great option.
> Once you have installed [Ubuntu 18.04 LTS for Windows](https://www.microsoft.com/en-us/p/ubuntu-1804-lts/9n9tngvndl3q#activetab=pivot:overviewtab), run `ubuntu18.04` from your favorite terminal and follow the instructions above to install NWChem from source.

Once you have compiled NWChem from source, you can run the `yaml_driver` script provided with NWChem to quickly produce Broombridge instances from NWChem input decks:

```bash
$NWCHEM_TOP/contrib/quasar/yaml_driver input.nw
```

This command will create a new `input.yaml` file in the Broombridge format within your current directory.

### Using NWChem with Docker

Pre-built images for using NWChem are available cross-platform via [Docker Hub](https://hub.docker.com).
To get started, follow the Docker installation instructions for your platform:

- [Install Docker for Ubuntu](https://docs.docker.com/install/linux/docker-ce/ubuntu/)
- [Install Docker for macOS](https://docs.docker.com/docker-for-mac/install/)
- [Install Docker for Windows 10](https://docs.docker.com/docker-for-windows/install/)

> [!TIP]
> If you are using Docker for Windows, you will need to share the drive containing your temporary directory (usually this is the `C:\` drive) with the Docker daemon. See the [Docker documentation](https://docs.docker.com/docker-for-windows/#shared-drives) for more details.

Once you have Docker installed, you can either use the PowerShell module provided with the Quantum Development Kit samples to run the image, or ou can run the image manually.
We detail using PowerShell here; if you would like to use the Docker image manually, please see the [documentation provided with the image](https://hub.docker.com/r/nwchemorg/nwchem-qc/).

#### Running NWChem through PowerShell Core

To use the NWChem Docker image with the Quantum Development Kit, we provide a small PowerShell module that handles moving files in and out of NWChem for you.
If you don't already have PowerShell Core installed, you can download it cross-platform from the [PowerShell repository on GitHub](https://github.com/PowerShell/PowerShell#get-powershell).

> [!NOTE]
> PowerShell Core is also used for some samples to demonstrate interoperability with data science and business analytics workflows.

Once you have PowerShell Core installed, import `InvokeNWChem.psm1` to make NWChem commands available in your current session:

```powershell
cd Quantum/utilities/
Import-Module ./InvokeNWChem.psm1
```

This will make the `Convert-NWChemToBroombridge` command available in your current PowerShell session.
To download any needed images from Docker and use them to run NWChem input decks and capture output to Broombridge, run the following:

```powershell
Convert-NWChemToBroombridge ./input.nw
```

This will create a Broombridge file by running NWChem on `input.nw`.
By default, the Broombridge output will have the same name and path as the input deck, with the `.nw` extension replaced by `.yaml`.
This can be overridden by using the `-DestinationPath` parameter to `Convert-NWChemToBroombridge`.
More information can be obtained by using PowerShell's built-in help functionality:

```powershell
Convert-NWChemToBroombridge -?
Get-Help Convert-NWChemToBroombridge -Full
```

# Verifying Your Installation

Like the rest of the Quantum Development Kit, the quantum chemistry library comes with a number of fully documented samples to help you get up and running quickly.
To test your installation using these samples, clone the [main samples repository](https://github.com/Microsoft/Quantum), then run one of the samples inside:

```bash
git clone https://github.com/Microsoft/Quantum.git
cd Quantum/Chemistry/MolecularHydrogen
dotnet run
```

To verify with using Microsoft Visual Studio after cloning the repository:
    1. Open 'Microsoft.Quantum.Chemistry.sln'.
    2. Select Samples/1. Simple Molecules/MolecularHydrogenGUI as the StartUp project.
    3. Press F5 to run the molecular Hydrogen quantum phase estimation demo.


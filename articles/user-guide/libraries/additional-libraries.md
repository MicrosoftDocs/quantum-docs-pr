---
title: Using additional Q# libraries
description: Learn how to add the Microsoft Quantum numerics library to your Visual Studio 2019 or later installation. 
author: cgranade
ms.author: chgranad
ms.date: 06/30/2020
ms.topic: article
uid: microsoft.quantum.libraries.using
---

# Using Additional Q# Libraries

The Quantum Development Kit provides additional domain-specific functionality through _NuGet packages_ that can be added to your Q# projects.

| Q# Library  | NuGet package | Notes |
|---------|---------|--------|
| [Q# standard library](xref:microsoft.quantum.libraries.standard.intro) | [**Microsoft.Quantum.Standard**](https://www.nuget.org/packages/Microsoft.Quantum.Standard) | Included by default |
| [Quantum chemistry library](xref:microsoft.quantum.chemistry.concepts.intro) | [**Microsoft.Quantum.Chemistry**](https://www.nuget.org/packages/Microsoft.Quantum.Chemistry) | |
| [Quantum numerics library](xref:microsoft.quantum.numerics.intro) | [**Microsoft.Quantum.Numerics**](https://www.nuget.org/packages/Microsoft.Quantum.Numerics) | |
| [Quantum machine learning library](xref:microsoft.quantum.libraries.machine-learning.intro) | [**Microsoft.Quantum.MachineLearning**](https://www.nuget.org/packages/Microsoft.Quantum.MachineLearning) | |

Once you have installed the Quantum Development Kit for use with your preferred environment and host language, you can easily add libraries to individual Q# projects without any further installation.

> [!NOTE]
> Some Q# libraries may work well with additional tools that work alongside your Q# programs, or that integrate with your host applications.
> For example, the [chemistry library installation instructions](xref:microsoft.quantum.chemistry.concepts.installation) describe how to use the [**Microsoft.Quantum.Chemistry** package](https://www.nuget.org/packages/Microsoft.Quantum.Chemistry) together with the NWChem computational chemistry platform, and how to install the `qdk-chem` command-line tools for working with quantum chemistry data.

## [Q# command-line applications or .NET interopability](#tab/tabid-csproj)

**Command line or Visual Studio Code:** Using the command line on its own or from within Visual Studio Code, you can use the `dotnet` command to add a NuGet package reference to your project.
For example, to add the [**Microsoft.Quantum.Numerics**](https://www.nuget.org/packages/Microsoft.Quantum.Numerics) package, run the following command:

```dotnetcli
dotnet add package Microsoft.Quantum.Numerics
```

**Visual Studio >=2019:** If you are using Visual Studio 2019 or later, you can add additional Q# packages using the NuGet Package Manager.
To load a package: 
1. With a project open in Visual Studio, select **Manage NuGet Packages...** from the **Project** menu.

2. Click ** Browse**, select **Include prerelease** and search for the package name "Microsoft.Quantum.Numerics". 


This will list the packages available for download.
3. Hover over **Microsoft.Quantum.Numerics** and click the downward-pointing arrow to the right of the version number to install the numerics package.

For more details, see the [Package Manager UI guide](https://docs.microsoft.com/nuget/tools/package-manager-ui).

Alternatively, you can use the Package Manager Console to add the numerics library to your project via the command line interface.

![Use the Package Manager Console from the command line](~/media/vs2017-nuget-console-menu.png)

From the Package Manager Console, run the following:

```
Install-Package Microsoft.Quantum.Numerics
```

For more details, see the [Package Manager Console guide](https://docs.microsoft.com/nuget/tools/package-manager-console).

## [IQ# Notebooks](#tab/tabid-notebook)

You can make additional packages available for use in an IQ# Notebook by using the [`%package` magic command](xref:microsoft.quantum.iqsharp.magic-ref.package).
For example, to add the [**Microsoft.Quantum.Numerics**](https://www.nuget.org/packages/Microsoft.Quantum.Numerics) package for use in an IQ# Notebook, run the following command in a notebook cell:

```
%package Microsoft.Quantum.Numerics
```

Following this command, the package is available to any cells within the notebook.
To make the package available from Q# code in the current workspace, reload the workspace after adding your package:

```
%workspace reload
```

## [Python interoperability](#tab/tabid-python)


Additional packages can be made available for use in a Python host program by using the `qsharp.packages.add` method.
For example, to add the [**Microsoft.Quantum.Chemistry**](https://www.nuget.org/packages/Microsoft.Quantum.Chemistry) package for use in an IQ# Notebook, run the following Python code:

```python
import qsharp
qsharp.packages.add("Microsoft.Quantum.Chemistry")
```

Following this command, the package will be made available to any Q# code compiled using `qsharp.compile`.
To make the package available from Q# code in the current workspace, reload the workspace after adding your package:

```python
qsharp.reload()
```

***

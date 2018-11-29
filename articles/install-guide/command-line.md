---
title: Installing the Q# development environment for VS Code
author: cgranade
uid: microsoft.quantum.install.cmd-line
ms.author: christopher.granade@microsoft.com
ms.date: 7/31/2018
ms.topic: article
---

# Installing the Quantum Development Kit for the Command Line #

## Installing the .NET Core SDK (Windows 10, macOS, Linux) ##

The Quantum Development Kit uses the .NET Core SDK (2.0 or later) to make it easy to create, build, and run Q# projects from the command line.

1. Download and install the **.NET Core SDK** 2.0 or later from the [.NET downloads page](https://www.microsoft.com/net/download).

2. Once the .NET Core SDK is installed, run the following command in your favorite command line (e.g.: PowerShell or Bash) to download the latest templates for creating new Q# applications and libraries:
   ```Bash
   dotnet new -i "Microsoft.Quantum.ProjectTemplates::0.3.1811.2802-preview"
   ```

You should now have the Quantum Development Kit installed and ready to use in your own applications and libraries.

## Optional Dependencies ##

Some of the samples demonstrate using the Quantum Development Kit with other programming environments, and have additional installation requirement:

- Some samples use the Node.js Package Manager (NPM) to handle user interface dependencies.
  NPM can be installed [manually](https://nodejs.org/en/download/current/) or through a [package manager](https://nodejs.org/en/download/package-manager/).
- The Python interoperability feature (currently in Windows-only preview) has been developed for the [Anaconda distribution](https://www.anaconda.com/download/) of Python 3.6.
  Please see the [README](https://github.com/Microsoft/Quantum/tree/master/Samples/PythonInterop/README.md) file provided with the Python sample for more details.


# Validating the Quantum Development Kit installation

In this section you will clone the quantum samples & libraries repository, and run a sample application to verify that your Q# environment is correctly installed and configured.

3. Clone and open the [Microsoft Quantum Developer Kit Samples and Libraries](https://github.com/microsoft/quantum) GitHub repository.
  ```bash
  git clone https://github.com/Microsoft/Quantum.git
  ```
  To continue at the command line, navigate into the newly cloned directory:
  ```bash
  cd Quantum
  ```

4. From the terminal, run the teleport sample program:
  ```bash
  cd Samples/src/Teleportation/
  dotnet run
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

In addition to these libraries and samples, the Quantum Development Kit is provided along with further libraries for non-commercial use.
These libraries may be found in the [Microsoft/Quantum-NC](https://github.com/microsoft/quantum-nc) repository on GitHub.

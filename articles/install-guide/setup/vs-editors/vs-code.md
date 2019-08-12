---
title: Installing the Q# development environment for VS Code
author: cgranade
uid: microsoft.quantum.install.vs-code
ms.author: christopher.granade@microsoft.com
ms.date: 7/31/2018
ms.topic: article
---

# Installing the Quantum Development Kit for Visual Studio Code #

The Quantum Development Kit can be used with Visual Studio Code, Microsoft's open-source cross-platform development environment, making it easy to use Q# with C# or Python. Visual Studio Code is available for Windows, Linux, and macOS.

Below, you will find the instructions to:
* Install Visual Studio Code 
* Install the Quantum Development Kit extension
* Validate the install with a sample application.
Upon successful validation, you will be ready to start developing!

## Installing Visual Studio Code ##

If you do not have Visual Studio Code installed, you can do so by visiting the [Visual Studio Code website](https://code.visualstudio.com/). Pick the download for your platform and follow the installation prompts.

> [!NOTE]
> When you run Visual Studio Code for the first time, you may be prompted to install Git if you have not already done so.
> Git is not required to use the Quantum Development Kit, but works great for managing and sharing Q# projects, and for contributing back to the Q# libraries and samples.
> If you would like to use Git, please download and run [Git for Windows](https://git-scm.com/download/win).


## Installing the Quantum Development Kit Extension ##

Once you have installed Visual Studio Code (and the latest version of the [.NET Core SDK](https://dotnet.microsoft.com/) (2.2 or later)), you can find the [Microsoft Quantum Development Kit for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode) extension in the Visual Studio Marketplace and press Install.

> [!TIP]
> You can also install the Quantum Development Kit extension for Visual Studio Code from the *Go to file...* palette.
> Press **Ctrl+P** or **⌘+P** from within Visual Studio Code, type or paste `ext install quantum.quantum-devkit-vscode`, and press **Enter**.

### Common Issues ###

- Depending on your network configuration, when using the Microsoft Quantum Development Kit for Visual Studio Code on Windows 10, you may see a popup from Windows Defender asking you to approve network access for the extension.
  The Visual Studio Code extension uses network access on the local machine to send information between Visual Studio Code and the Q# compiler framework, allowing for diagnostic information to be reported immediately through intelliSense.

# Validating the Quantum Development Kit installation #

In this section you will clone the quantum samples & libraries repository, and run a sample application to verify that your Q# environment is correctly installed and configured.

3. Clone and open the [Microsoft Quantum Developer Kit Samples and Libraries](https://github.com/microsoft/quantum) GitHub repository.
  ```bash
  git clone https://github.com/Microsoft/Quantum.git
  ```
  To continue at the command line, navigate into the newly cloned directory:
  ```bash
  cd Quantum
  ```

  > [!TIP]
  > If you would like to work with the libraries and samples project in VS Code, we recommend opening the folder containing the project rather than working with one file at a time.
  > This makes it much easier to see the whole project at once, save settings for each project, and so forth.
  > One quick way to open Visual Studio Code is to use the `code` command in your favorite terminal with the name of the folder you'd like to open.
  > For example, to open the `Quantum` repo that you cloned above, run the following:
  > ```bash
  > code .
  > ```
  > Since the folder comes with suggestions for different extensions, you may be prompted to install the Microsoft Quantum Development Kit for Visual Studio Code and the Microsoft C# extension if you haven't already done so.
  > 
  > If you are running on macOS and the `code` command is missing, you may need to [install the command line interface for Visual Studio Code](https://code.visualstudio.com/docs/editor/command-line).

4. From the terminal (standalone, or the embedded terminal in Visual Studio Code), run the teleport sample program:
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

## Optional Dependencies ##

Some of the samples demonstrate using the Quantum Development Kit with other programming environments, and have additional installation requirement:

- Some samples use the Node.js Package Manager (NPM) to handle user interface dependencies.
  NPM can be installed [manually](https://nodejs.org/en/download/current/) or through a [package manager](https://nodejs.org/en/download/package-manager/).
- The Python interoperability feature (currently in Windows-only preview) has been developed for the [Anaconda distribution](https://www.anaconda.com/download/) of Python 3.6.
  Please see the [README](https://github.com/Microsoft/Quantum/blob/master/Samples/src/PythonInterop/README.md) file provided with the Python sample for more details.

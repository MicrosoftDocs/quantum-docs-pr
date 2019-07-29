---
title: Setup Overview
author: gillenhaalb
ms.author: gillenhaalb@gmail.com
ms.date: 7/19/2019
ms.topic: article
uid: microsoft.quantum.install.setup
---

# Setup Overview #

To begin writing and running quantum programs on your own computer, follow these instructions for installing the Quantum Development Kit.
Whether on Windows, Linux, or macOS, you will need the right machinery in the background, so the first step below is to download the [.NET Core SDK](https://dotnet.microsoft.com/).
Then, our instructions will guide you through installing the Quantum Devleopment Kit for whichever classical host environment and language you prefer--the choice is yours, as the power of Q# will be at your fingertips regardless!

## Install .NET Core SDK ##

The Quantum Development Kit uses the [.NET Core SDK](https://dotnet.microsoft.com/) to make it easy to create, build, and run Q# projects from the command line.
Whatever your preferred editor or environment may be, to start working with Q# on your own computer, you will need the latest version (2.2 or later) installed.
You can do this by following the instructions from the [.NET downloads page](https://www.microsoft.com/net/download).

## Install the Quantum Development Kit for Your Preferred Environment ##

### Visual Studio Editors and the Command Line ###

With the .NET Core SDK now installed, you can implement Q# programs in editors such as Visual Studio Code and Visual Studio, or even directly in the command line.
To get started, install the Quantum Development Kit following these instructions for your preferred environment (links to download the corresponding editors are included within):
* [Installing the QDK for Visual Studio Code](xref:microsoft.quantum.install.vs-code) (Windows 10, Linux, macOS)
* [Installing the QDK for Visual Studio](xref:microsoft.quantum.install.vs-2017) (Windows 10 only)
* [Installing the QDK in the command line](xref:microsoft.quantum.install.cmd-line)

### Other Environments: C#, Python, and Jupyter Notebooks ###

If, however, you prefer to work within a different classical host environment, we provide interoperability allowing you to invoke Q# quantum algorithms using C#, Python, and Jupyter Notebooks.
Details and instructions are provided here:
* [Getting started with Q# and C#](xref:microsoft.quantum.install.csharp)
* [Getting started with Q# and Python](xref:microsoft.quantum.install.python)
* [Getting started with Q# and Jupyter Notebooks](xref:microsoft.quantum.install.jupyter)

Once your editor environment is installed and validated, you have all you need to write your first quantum program!
This [step-by-step guide](xref:microsoft.quantum.write-program) takes you through the process. 

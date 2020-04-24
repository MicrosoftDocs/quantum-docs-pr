---
title: Execute Q# programs without a driver in a host language 
author: 
ms.author: 
ms.date: 4/24/2020
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.update
---

# Q# Standalone Executables

Standalone executables allow Q# programs to executed without a driver in a host language like C#, F#, or Python.
The executable will run the operation or function marked with the `@EntryPoint()` attribute on a simulator, resource estimator, or submit it to Azure Quantum, depending on the project configuration and command-line options.

1. Pre-requisites

2. Installation
No installation is required? Any IDE needed?

While you can use the Q# standalone executables in any IDE, we highly recommend using Visual Studio Code (VS Code) IDE for your Q# applications. By using Visual Studio Code and the QDK Visual Studio Code extension you gain access to richer functionality.These are convenient tools for the Q# + C# and Q# + Python approaches if you choose to use them instead. 

    - Install [VS Code](https://code.visualstudio.com/download) (Windows, Linux and Mac)
    - Install the [QDK extension for VS Code](https://marketplace.visualstudio.com/items?itemName=quantum.quantum-devkit-vscode).

3. Run a simple command



## What's next?

Now that you have installed the Quantum Development Kit in your preferred environment, you can write and run [your first quantum program](xref:microsoft.quantum.write-program). 
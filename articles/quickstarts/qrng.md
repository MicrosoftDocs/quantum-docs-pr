---
title: Create a Quantum Random Number Generator
description: Build a Q# project that demonstrates fundamental quantum concepts like superposition by creating a quantum random number generator.
author: megbrow
ms.author: megbrow@microsoft.com
ms.date: 10/25/2019
ms.topic: article
uid: microsoft.quantum.quickstarts.qrng
---


# Quickstart: Implement a Quantum Random Number Generator in Q#
A simple example of a quantum algorithm written in Q# is a quantum random number generator. This algorithm leverages the nature of quantum mechanics to produce a random number. 

## Prerequisites

- The Microsoft [Quantum Development Kit][install].

## Setup

Applications developed with Microsoft's Quantum Development Kit consist of two parts:

1. One or more quantum algorithms, implemented using the Q# quantum programming language.
1. A host program, implemented in a programming language like Python or C# that serves as the main entry point and invokes Q# operations to execute a quantum algorithm.

#### [Python](#tab/tabid-python)

1. Choose a location for your application

1. Create a file called `Bell.qs`. This file will contain your Q# code.

1. Create a file called `host.py`. This file will contain your Python host code.

#### [C# Command Line](#tab/tabid-csharp)

1. Create a new Q# project:

    ```bash
    dotnet new console -lang Q# --output Bell
    cd Bell
    ```

    You should see a `.csproj` file, a Q# file called `Operation.qs`, and a host program file called `Driver.cs`

1. Rename the Q# file

    ```bash
    mv Operation.qs Bell.qs
    ```

#### [Visual Studio](#tab/tabid-vs2019)

1. Create a new project

   * Open Visual Studio
   * Go to the **File** menu and select **New** -> **Project...**
   * In the project template explorer, under `Installed` > `Visual C#`, select the `Q# Application` template
   * Make sure you have `.NET Framework 4.6.1` selected in the list at the bottom of the `New Project` dialog box
   * Give your project the name `Bell`

1. Rename the Q# file

   * Navigate to the **Solution Explorer**
   * Right click on the `Operation.qs` file
   * Rename it to `Bell.qs`

* * *

## Write a Q# operation

As mentioned in our [What is Quantum Computing?][xref:microsoft.quantum.overview.what] a qubit is a unit of quantum information that can be in superposition. When measured, a qubit can only be either 0 or 1, however during execution, the state of the qubit represents the probability of reading either a 0 or a 1 during measurement. We can use this probability to generate random numbers.

### Q# operation code

1. Replace the contents of the Operation.qs file with the following code:

    ```qsharp
    namespace Quantum {
    open Microsoft.Quantum.Intrinsic;

    operation QuantumRandomNumberGenerator() : Result {
        using(q = Qubit())  { // Allocate a qubit.
            H(q);             // Put the qubit to superposition. It now has a 50% chance of being 0 or 1.
            let r = M(q);     // Measure the qubit value.
            Reset(q);
            return r;
            }
        }
    }
    ```

Here we introduce the `Qubit` datatype, native to Q#. We can only allocate a `Qubit` with a `using` statement. When it gets allocated a qubit is always in the `Zero`  state. 

Using the `H` operation, we are able to put our `Qubit` in superposition. To measure a qubit and read its value you use the `M` intrinsic operation.

By putting our `Qubit` in superposition and measuring it, our result will be a different value each time the code is invoked. 

When a `Qubit` is de-allocated it must be explicitly set back to the `Zero` state, otherwise the simulator will report a runtime error. An easy way to achieve this is invoking `Reset`.

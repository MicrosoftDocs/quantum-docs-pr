---
title: Create a Quantum Random Number Generator
description: Build a Q# project that demonstrates fundamental quantum concepts like superposition by creating a quantum random number generator.
author: bromeg
ms.author: megbrow@microsoft.com
ms.date: 10/25/2019
ms.topic: article
uid: microsoft.quantum.quickstarts.qrng
---


# Quickstart: Implement a Quantum Random Number Generator in Q#
A simple example of a quantum algorithm written in Q# is a quantum random number generator. This algorithm leverages the nature of quantum mechanics to produce a random number. 

## Prerequisites

- The Microsoft [Quantum Development Kit](xref:microsoft.quantum.install).
- [Create a Q# Project](xref:microsoft.quantum.howto.createproject)


## Write a Q# operation

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

As mentioned in our [What is Quantum Computing?](xref:microsoft.quantum.overview.what) article, a qubit is a unit of quantum information that can be in superposition. When measured, a qubit can only be either 0 or 1. However, during execution the state of the qubit represents the probability of reading either a 0 or a 1 with a measurement. This probabilistic state is known as superposition. We can use this probability to generate random numbers.

In our Q# operation, we introduce the `Qubit` datatype, native to Q#. We can only allocate a `Qubit` with a `using` statement. When it gets allocated, a qubit is always in the `Zero`  state. 

Using the `H` operation, we are able to put our `Qubit` in superposition. To measure a qubit and read its value, you use the `M` intrinsic operation.

By putting our `Qubit` in superposition and measuring it, our result will be a different value each time the code is invoked. 

When a `Qubit` is de-allocated it must be explicitly set back to the `Zero` state, otherwise the simulator will report a runtime error. An easy way to achieve this is invoking `Reset`.

### Visualizing the code with the Bloch sphere

In the Bloch sphere, the north pole represents the classical value **0** and the south pole represents the classical value **1**. Any superposition can be represented by a point on the sphere (represented by an arrow). The closer the end of the arrow to a pole the higher the probability the qubit collapses into the classical value assigned to that pole when measured. For example, the qubit state represented by the red arrow below has a higher probability of giving the value **0** if we measure it.

<img src="~/media/qrng-Bloch.png" width="175">

We can use this representation to visualize what the code is doing:

* First we start with a qubit initalizated in the state **0** and apply `H` to create a superposition in which the probabilities for **0** and **1** are the same.

<img src="~/media/qrng-H.png" width="450">

* Then we measure the qubit and save the output:

<img src="~/media/qrng-meas.png" width="450">

Since the outcome of the measurement is completely random, we have obtained a random bit. We can call this operation several times to create integers. For example, if we call the operation three times to obtain three random bits, we can build random 3-bit numbers (that is, a random number between 0 and 7).

## Creating a complete random number generator using a host program

Now that we have a Q# operation that generates random bits, we can use it to build a complete quantum random number generator with a host program.

 ### [Python with Visual Studio Code or the Command Line](#tab/tabid-python)
 
 To run your new Q# program from Python, save the following code as `host.py`:
 
 [!code-python[](~/quantum/samples/getting-started/qrng/host.py)]

 You can then run your Python host program from the command line:
 ```bash
 $ python host.py
 Preparing Q# environment...
 ..The random number generated is 42
 ```
 ### [C# with Visual Studio Code or the Command Line](#tab/tabid-csharp)
 
 To run your new Q# program from C#, modify `Driver.cs` to include the following C# code:
 
 [!code-csharp[](~/quantum/samples/getting-started/qrng/Host.cs)]
 
 You can then run your C# host program from the command line:
 
 ```bash
 $ dotnet run
 The random number generated is 42
 ```

 ### [C# with Visual Studio 2019](#tab/tabid-vs2019)

 To run your new Q# program from C# in Visual Studio, modify `Driver.cs` to include the following C# code:

 :::code language="csharp" source="~/quantum/samples/getting-started/qrng/Host.cs" range="3-24,26":::

 Then press F5, the program will start execution and a new window will pop up with the random number generated: 

 ```bash
 $ dotnet run
 The random number generated is 42
 ```
 ***

---
title: "Q# quickstart: TODO"
description: TODO
author: cgranade
ms.author: chgranad@microsoft.com
ms.date: 10/9/2019
ms.topic: article
uid: microsoft.quantum.quickstarts.search
---

# Search for marked inputs with Grover's Algorithm

This introduction uses [Grover's Algorithm][grover] to search inputs to a function for a particular _marked input_.
This algorithm can be used to search for inputs with some special property, to find items in an unstructured list, and so forth.
Grover's algorithm lets us use a quantum computer to run this search in less steps than the number of items in the list that we're searching — something no classical algorithm can do.

In this introduction, we see how we can use Q# and the Quantum Development Kit to run Grover's algorithm with just a few lines of code.

## Prerequisites

- The Microsoft [Quantum Development Kit][install].

## Writing Grover's Algorithm

Using the Quantum Development Kit, create a new Q# project:

```
$ dotnet new console -lang Q# --output Grover
$ cd Grover
```

Grover's algorithm itself can be written using just a few lines.
Add the following code to the `Operations.qs` file in your new project:

[!code-qsharp[](~/quantum/samples/algorithms/simple-grover/SimpleGrover.qs?highlight=5,27)]

To define the list that we're searching, create a new file `Reflections.qs`, and paste in the following code:

[!code-qsharp[](~/quantum/samples/algorithms/simple-grover/Reflections.qs)]

The `ReflectAboutMarked` operation in this file represents the problem we're trying to solve with Grover's algorithm, in this case by reflecting bitstrings made up of alternating zeros and ones.

Next, run your new Q# program to find the item marked by `ReflectAboutMarked`.

### [Python with Visual Studio Code or the Command Line](#tab/tabid-python)

To run your new Q# program from Python, save the following code as `host.py`:

[!code-python[](~/quantum/samples/algorithms/simple-grover/host.py)]

You can then run your Python host program from the command line:

```bash
$ python host.py
Preparing Q# environment...
Reflecting about marked state...
Reflecting about marked state...
Reflecting about marked state...
Reflecting about marked state...
[0, 1, 0, 1, 0]
```

### [C# with Visual Studio Code or the Command Line](#tab/tabid-csharp)

To run your new Q# program from C#, modify `Driver.cs` to include the following C# code:

[!code-python[](~/quantum/samples/algorithms/simple-grover/Host.cs)]

You can then run your C# host program from the command line:

```bash
$ dotnet run
Result: [Zero,One,Zero,One,Zero]


Press any key to continue...
```

### [C# with Visual Studio 2019](#tab/tabid-vs2019)

<!-- TODO: write this tab -->

***

Note that the `ReflectAboutMarked` operation is called four times, but that your Q# program was able to find the "01010" input amongst $2^5 = 32$ possible inputs!

## Going Further

If you enjoyed this quickstart, checkout some of the resources below to learn more about how you can use Q# to write your own quantum applications today.

- [Quantum computing concepts](xref:microsoft.quantum.concepts.intro)
- [Quantum Development Kit Samples](https://docs.microsoft.com/en-us/samples/browse/?products=qdk)

<!-- LINKS -->

[install]: xref:microsoft.quantum.install
[grover]: TODO

---
title: Run Grover's search algorithm in Q# - Quantum Development Kit
description: Build a Q# project that demonstrates Grover's algorithm, one of the canonical quantum algorithms.
author: cgranade
ms.author: chgranad
ms.date: 10/19/2019
ms.topic: article
uid: microsoft.quantum.quickstarts.search
no-loc: ['Q#', '$$v']
---

# Tutorial: Implement Grover's search algorithm in Q\#

In this tutorial, you can learn how to build and run Grover search to speed up the search of unstructured data.  Grover's search is one of the most popular quantum computing algorithms, and this relatively small Q# implementation gives you a sense of some of the advantages of programming quantum solutions with a high-level Q# quantum programming language to express quantum algorithms.  At the end of the guide, you will see the simulation output demonstrates successfully finding a specific string among a list of unordered entries in a fraction of the time it would take to search the whole list on a classical computer.

Grover's algorithm searches a list of unstructured data for specific items. For example, it can answer the question: Is this card drawn from a pack of cards an ace of hearts? The labeling of the specific item is called _marked input_.

Using Grover's search algorithm, a quantum computer is guaranteed to run this search in fewer steps than the number of items in the list that you're searching — something no classical algorithm can do. The increased speed in the case of a pack of cards is negligible; however, in lists containing millions or billions of items, it becomes significant.

You can build Grover's search algorithm with just a few lines of code.

## Prerequisites

- The Microsoft [Quantum Development Kit][install].

## What does Grover's search algorithm do?

Grover's algorithm asks whether an item in a list is the one we are searching for. It does this by constructing a quantum superposition of the indexes of the list with each coefficient, or probability amplitude, representing the probability of that specific index being the one you are looking for.

At the heart of the algorithm are two steps that incrementally boost the coefficient of the index that we are looking for, until the probability amplitude of that coefficient approaches one.

The number of incremental boosts is fewer than the number of items in the list. This is why Grover's search algorithm performs the search in fewer steps than any classical algorithm.

![Functional diagram of Grover's search algorithm](~/media/grover.png)

## Write the code

1. Using the Quantum Development Kit, [create a new Q# project for the application](xref:microsoft.quantum.install.standalone). Title the project `Grover`.

1. Add the following code to the `Program.qs` file in your new project:

    :::code language="qsharp" source="~/quantum/samples/algorithms/simple-grover/SimpleGrover.qs" range="4-41":::

1. To define the list that we're searching, create a new file `Reflections.qs`, and paste in the following code:

    :::code language="qsharp" source="~/quantum/samples/algorithms/simple-grover/Reflections.qs" range="4-70":::

    The `ReflectAboutMarked` operation defines the marked input that you are searching for: the string of alternating zeros and ones. This sample hard-codes the marked input, and can be extended to search for different inputs or generalized for any input.

1. Next, run your new Q# program to find the item marked by `ReflectAboutMarked`.

### Q# applications with Visual Studio or Visual Studio Code

The executable will run the operation or function marked with the `@EntryPoint()` attribute on a simulator or resource estimator, depending on the project configuration and command-line options.

In Visual Studio, simply press Ctrl + F5 to execute the script.

In VS Code, build the `Program.qs` the first time by typing the below in the terminal:

```Command line
dotnet build
```

For subsequent runs, there is no need to build it again. To run it, type the following command and press enter:

```Command line
dotnet run --no-build
```

You should see the following message displayed in the terminal:

```
operations.qs:
This operation applies Grover's algorithm to search all possible inputs to an operation to find a particular marked state.
Usage:
operations.qs [options] [command]

--n-qubits <n-qubits> (REQUIRED)
-s, --simulator <simulator>         The name of the simulator to use.
--version                           Show version information
-?, -h, --help                      Show help and usage information
Commands:
```

This is because you didn't specify the number of qubits you wanted to use,
so the terminal tells you the commands available for the executable. If we
want to use 5 qubits we should type:

```Command line
dotnet run --n-qubits 5
```

Pressing enter you should see the following output:

```
Reflecting about marked state...
Reflecting about marked state...
Reflecting about marked state...
Reflecting about marked state...
[Zero,One,Zero,One,Zero]
```

## Next steps

If you enjoyed this tutorial, check out some of the resources below to learn more about how you can use Q# to write your own quantum applications:

- [Back to the Getting Started with QDK guide](xref:microsoft.quantum.welcome)
- Try a more general Grover's search algorithm [sample](https://github.com/microsoft/Quantum/tree/master/samples/algorithms/database-search)
- [Learn more about Grover's search with the Quantum Katas](xref:microsoft.quantum.overview.katas)
- Read more about [Amplitude amplification][amplitude-amplification], the quantum computing technique behind Grover's search algorithm
- [Quantum computing concepts](xref:microsoft.quantum.concepts.intro)
- [Quantum Development Kit Samples](https://docs.microsoft.com/samples/browse/?products=qdk)

<!-- LINKS -->

[install]: xref:microsoft.quantum.install
[amplitude-amplification]: xref:microsoft.quantum.libraries.standard.algorithms#amplitude-amplification

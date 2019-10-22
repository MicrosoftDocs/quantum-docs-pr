---
title: Run Grover's search algorithm in Q# - Quantum Development Kit
description: Build a Q# project that demonstrates Grover's algorithm, one of the canonical quantum algorithms.
author: cgranade
ms.author: chgranad@microsoft.com
ms.date: 10/19/2019
ms.topic: article
uid: microsoft.quantum.quickstarts.search
---

# Quickstart: Implement Grover's search algorithm in Q#

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

1. Using the Quantum Development Kit, [create a new Q# project](xref:microsoft.quantum.howto.createproject) called `Grover`, in your development environment of choice.

1. Add the following code to the `Operations.qs` file in your new project:

    [!code-qsharp[](~/quantum/samples/algorithms/simple-grover/SimpleGrover.qs?highlight=5,27)]

1. To define the list that we're searching, create a new file `Reflections.qs`, and paste in the following code:

    [!code-qsharp[](~/quantum/samples/algorithms/simple-grover/Reflections.qs)]

    The `ReflectAboutMarked` operation defines the marked input that you are searching for: the string of alternating zeros and ones. This sample hard-codes the marked input, and can be extended to search for different inputs or generalized for any input.

1. Next, run your new Q# program to find the item marked by `ReflectAboutMarked`.

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

    [!code-csharp[](~/quantum/samples/algorithms/simple-grover/Host.cs)]

    You can then run your C# host program from the command line:

    ```bash
    $ dotnet run
    Result: [Zero,One,Zero,One,Zero]

    Press any key to continue...
    ```

    ### [C# with Visual Studio 2019](#tab/tabid-vs2019)

    <!-- TODO: write this tab -->

    ***

    The `ReflectAboutMarked` operation is called only four times, but your Q# program was able to find the "01010" input amongst $2^{5} = 32$ possible inputs!

## Next steps

If you enjoyed this quickstart, check out some of the resources below to learn more about how you can use Q# to write your own quantum applications:

- [Quantum computing concepts](xref:microsoft.quantum.concepts.intro)
- [Quantum Development Kit Samples](https://docs.microsoft.com/en-us/samples/browse/?products=qdk)
- Try a more general Grover's search algorithm [sample](https://github.com/microsoft/Quantum/tree/master/samples/algorithms/database-search)
- Read more about [Amplitude amplification](xref:microsoft.quantum.libraries.standard.algorithms#amplitude-amplification)

<!-- LINKS -->

[install]: xref:microsoft.quantum.install

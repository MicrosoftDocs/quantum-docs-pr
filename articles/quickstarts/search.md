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

[!code-qsharp[](~/samples/samples/algorithms/simple-grover/SimpleGrover.qs?highlight=5,27)]

To define the list that we're searching, create a new file `Reflections.qs`, and paste in the following code:

[!code-qsharp[](~/samples/samples/algorithms/simple-grover/Reflections.qs?highlight=5,27)]

<!-- TODO: pick up here -->

<!-- LINKS -->

[install]: xref:microsoft.quantum.install
[grover]: TODO

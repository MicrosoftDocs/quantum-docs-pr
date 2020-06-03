---
title: Basic classification with the Quantum Machine Learning library
description: Learn how to execute a quantum sequential classifier written in Q# using the Quantum Machine Learning library of the Microsoft QDK.
author: geduardo
ms.author: v-edsanc@microsoft.com
ms.date: 02/16/2020
ms.topic: article
uid: microsoft.quantum.libraries.machine-learning.basics
---

# Basic classification: Classify data with the QDK

In this Quickstart, you will learn how to execute a quantum sequential classifier written in Q# using the Quantum Machine Learning library of the QDK. 

In this guide we will use the half-moon dataset, using a classifier structure defined in Q#.

## Prerequisites

- The Microsoft [Quantum Development Kit](xref:microsoft.quantum.install).
- Create a Q# project for either a [Python host program](xref:microsoft.quantum.install.python) or a [C# host program](xref:microsoft.quantum.install.cs).

## Host program

Your host program consists of three parts:

- Load the dataset and choose a set of starting parameters for your model.
- Execute training to determine the parameters and bias of the model.
- Validate the model to determine its accuracy

    ### [Python with Visual Studio Code or the Command Line](#tab/tabid-python)

    To run your the Q# classifier from Python, save the following code as `host.py`. Remember that you also need the Q# file `Training.qs` that is explained later in this tutorial.

    :::code language="python" source="~/quantum/samples/machine-learning/half-moons/host.py" range="3-42":::

    You can then run your Python host program from the command line:

    ```bash
    $ python host.py
    Preparing Q# environment...
    [...]
    Observed X.XX% misclassifications.
    ```

    ### [C# with Visual Studio Code or the Command Line](#tab/tabid-csharp)

    To run your the Q# classifier from C#, save the following code as `Host.cs`. Remember that you also need the Q# file `Training.qs` that is explained later in this tutorial.

    :::code language="csharp" source="~/quantum/samples/machine-learning/half-moons/Host.cs" range="4-86":::

    You can then run your C# host program from the command line:

    ```bash
    $ dotnet run
    [...]
    Observed X.XX% misclassifications.
    ```

    ### [C# with Visual Studio 2019](#tab/tabid-vs2019)

    To run your new Q# program from C# in Visual Studio, modify `Host.cs` to include the following C# code. Remember that you also need the Q# file `Training.qs` that is explained later in this tutorial.

    :::code language="csharp" source="~/quantum/samples/machine-learning/half-moons/Host.cs" range="4-86":::

    Then press F5, the program will start execution and a new windows will pop-up with the following results: 

    ```bash
    $ dotnet run
    [...]
    Observed X.XX% misclassifications.
    ```
    ***

## Q\# classifier code

Now let's see how the operations invoked by the host program are defined in Q#.
We save the following code in a file named `Training.qs`.

:::code language="qsharp" source="~/quantum/samples/machine-learning/half-moons/Training.qs" range="4-116":::

The most important functions and operations defined in the code above are:

- `ClassifierStructure() : ControlledRotation[]` : in this function we set the structure of our circuit model by adding the layers of the controlled gates we consider. This step is analogous to the declaration of layers of neurons in a sequential deep learning model.
- `TrainHalfMoonModel() : TrainWineModel() : (Double[], Double)` : this operation is the core part of the code and defines the training. Here we load the samples from the dataset included in the library, we set the hyper parameters and the initial parameters for the training and we start the training by calling the operation `TrainSequentialClassifier` included in the library. It outputs the parameters and the bias that determine the classifier.
- `ValidateHalfMoonModel(parameters : Double[], bias : Double) : Int` : this operation defines the validation process to evaluate the model. Here we load the samples for validation, the number of measurements per sample and the tolerance. It outputs the number of misclassifications on the chosen batch of samples for validation.

## Next steps

First, you can play with the code and try to change some parameters to see how it affects the training. Then, in the next tutorial, [Design your own classifier](xref:microsoft.quantum.libraries.machine-learning.design),  you will learn how to define the structure of the classifier.

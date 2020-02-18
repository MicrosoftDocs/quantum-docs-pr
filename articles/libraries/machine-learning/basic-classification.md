---
title: Quantum machine learning library
author: geduardo
ms.author: v-edsanc@microsoft.com
ms.date: 02/16/2020
ms.topic: article
uid: microsoft.quantum.libraries.machine-learning.basics
---

# Basic classification: classify wines with the QDK

In this Quickstart, you will learn how to execute a quantum sequential classifier written in Q# using the Quantum Machine Learning library of the QDK. It's okay if you don't understand everything, this is a quick overview of a complete QDK classifier. You will get more details explained as you go through the rest of the tutorials.

In this guide we will use the [wine dataset](https://archive.ics.uci.edu/ml/datasets/wine) from the [UCI Machine Learning Repository](https://archive.ics.uci.edu/ml/datasets/wine), using a classifier structure defined in Q#. This dataset is included in the collection of standard datasets in the Quantum Machine Learning library. This means that we can load it directly from Q#.

## Execute the classifier from the host program

First, let's take a look at the host programs to see what the process looks like. Your host program will consist of three parts:

- Initialization of the target machine, in this case a quantum simulator.
- Execution of the training to obtain the parameters and the bias that determine the model.
- Validation of the model to test the accuracy.

    ### [Python with Visual Studio Code or the Command Line](#tab/tabid-python)

    To run your the Q# classifier from Python, save the following code as `host.py`. Remember that you also need the Q# file `Training.qs` that is explained later in this tutorial.

    code language="python" source="~/quantum/samples/machine-learning/wine/host.py" range="9-14"

    You can then run your Python host program from the command line:

    ```bash
    $ python host.py
    Preparing Q# environment...
    (To be written)
    ```

    ### [C# with Visual Studio Code or the Command Line](#tab/tabid-csharp)

    To run your the Q# classifier from C#, save the following code as `Host.cs`. Remember that you also need the Q# file `Training.qs` that is explained later in this tutorial.

    code language="csharp" source="~/quantum/samples/machine-learning/wine/Host.cs" range="5-43"

    You can then run your C# host program from the command line:

    ```bash
    $ dotnet run
    Ready to train.
    Beginning training at start point #0...
    Beginning training at start point #1...
    Beginning training at start point #2...
    Beginning training at start point #3...
    Training complete, found optimal parameters: [1.69704, 1.139123, 2.3595, 4.037552, 1.63698, 1.27549, 0.328671, 0.302282]
    Observed X.XX% misclassifications.
    ```

    ### [C# with Visual Studio 2019](#tab/tabid-vs2019)

    To run your new Q# program from C# in Visual Studio, modify `Driver.cs` to include the following C# code. Remember that you also need the Q# file `Training.qs` that is explained later in this tutorial.

    code language="csharp" source="~/quantum/samples/machine-learning/wine/Host.cs" range="4-23"

    Then press F5, the program will start execution and a new windows will pop-up with the following results: 

    ```bash
    $ dotnet run
    Ready to train.
    Beginning training at start point #0...
    Beginning training at start point #1...
    Beginning training at start point #2...
    Beginning training at start point #3...
    Training complete, found optimal parameters: [1.69704, 1.139123, 2.3595, 4.037552, 1.63698, 1.27549, 0.328671, 0.302282]
    Observed X.XX% misclassifications.
    ```
    ***

## The Q\# code of the classifier

Now let's see how the functions invoked by the host program are defined in Q#. We save the following code in a file named `Training.qs`.

code language="qsharp" source="~/quantum/samples/machine-learning/wine/Host.cs" range="4-84"

The most important functions and operations defined in the code above are:

- `ClassifierStructure() : ControlledRotation[]` : in this function we set the structure of our circuit model by adding the layers of the controlled gates we consider. This step is analogous to the declaration of layers of neurons in a sequential deep learning model.
- `TrainWineModel() : TrainWineModel() : (Double[], Double)` : this operation is the core part of the code and defines the training. Here we load the samples from the dataset included in the library, we set the hyper parameters and the initial parameters for the training and we start the training by calling the operation `TrainSequentialClassifier` included in the library. It outputs the parameters and the bias that determine the classifier.
- `ValidateWineModel(parameters : Double[], bias : Double) : Int` : this operation defines the validation process for evaluating the model. Here we load the samples for validation, the number of measurements per sample and the tolerance. It outputs the number of misclassifications on the chosen batch of samples for validation.

## What's next?

First, you can play with the code and try to change some parameters to see how it affects the training. Then, in the next tutorial, [Design your own classifier](xref:microsoft.quantum.libraries.machine-learning.design),  you will learn how to define the structure of the classifier.

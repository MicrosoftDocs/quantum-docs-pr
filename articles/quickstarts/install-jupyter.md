---
title: Develop with Q# Jupyter Notebooks
description: Learn how to create a Q# application using Jupyter Notebooks.
author: bradben
ms.author: bradben
ms.date: 5/30/2020
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install.jupyter
no-loc: ['Q#', '$$v']
---

# Develop with Q# Jupyter Notebooks

Now you are ready to verify your Q# Jupyter Notebook installation by writing and running a simple Q# operation.

## Prerequisites

- Install the [Quantum Development Kit](xref:microsoft.quantum.install) for your environment. 

## Create your first Q# notebook

1. From the environment you created during installation (i.e., either the conda environment you created, or the Python environment where you installed Jupyter), run the following command to start the Jupyter Notebook server:

    ```
    jupyter notebook
    ```

    - If the Jupyter Notebook doesn't open automatically in your browser, copy and paste the URL provided by the command line into your browser.

1. Choose "New" → "Q#" to create a Jupyter Notebook with a Q# kernel, and add the following code to the first notebook cell:

    :::code language="qsharp" source="~/quantum/samples/interoperability/qrng/Qrng.qs" range="6-13":::

1. Run this cell of the notebook:

    ![Jupyter Notebook cell with Q# code](~/media/install-guide-jupyter.png)

    You should see `SampleQuantumRandomNumberGenerator` in the output of the cell. When running in Jupyter Notebook, the Q# code is compiled, and the cell outputs the name of any operations that it finds.

1. In a new cell, run the operation you just created (in a simulator) by using the `%simulate` command:

    ![Jupyter Notebook cell with %simulate magic](~/media/install-guide-jupyter-simulate.png)

    You should see the result of the operation you invoked. In this case, because your operation generates a random result, you will see either `Zero` or `One` printed on the screen. If you run the cell repeatedly, you should see each result approximately half the time.

## Next steps

Now that you have installed the QDK for Q# Jupyter Notebooks, you can write and run [your first quantum program](xref:microsoft.quantum.quickstarts.qrng) by writing Q# code directly within the Jupyter Notebook environment.

For more examples of what you can do with Q# Jupyter Notebooks, please take a look at:

- [Intro to Q# and Jupyter Notebook](https://docs.microsoft.com/samples/microsoft/quantum/intro-to-qsharp-jupyter/). There you will find a Q# Jupyter Notebook that provides more details on how to use Q# in the Jupyter environment.
- [Quantum Katas](xref:microsoft.quantum.overview.katas), an open-source collection of self-paced tutorials and sets of programming exercises in the form of Q# Jupyter Notebooks. The [Quantum Katas tutorial notebooks](https://github.com/microsoft/QuantumKatas#tutorial-topics) are a good starting point. The Quantum Katas are aimed at teaching you elements of quantum computing and Q# programming at the same time. They're an excellent example of what kind of content you can create with Q# Jupyter Notebooks.

---
title: Develop with Q# and Python
description: Learn how to create a Q# application using Python.
author: bradben
ms.author: v-benbra
ms.date: 8/20/2020
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install.python
no-loc: ['Q#', '$$v']
---

# Develop with Q# and Python

Verify your `qsharp` Python package installation by writing and running a simple Q# program.

## Prerequisites

- Install the [Quantum Development Kit](xref:microsoft.quantum.install) for your environment. 

## Write your first Q# program

1. Create a minimal Q# operation by creating a file called `Operation.qs` and adding the following code to it:

    :::code language="qsharp" source="~/quantum/samples/interoperability/qrng/Qrng.qs" range="3-14":::

1. In the same folder as `Operation.qs`, create a Python program called `host.py` to simulate the Q# `SampleQuantumRandomNumberGenerator()` operation:

    ```python
    import qsharp
    from Qrng import SampleQuantumRandomNumberGenerator

    print(SampleQuantumRandomNumberGenerator.simulate())
    ```

1. From the environment you created during installation (i.e., the conda or Python environment where you installed `qsharp`), run the program:

    ```
    python host.py
    ```

1. You should see the result of the operation you invoked. In this case, because your operation generates a random result, you will see either `0` or `1` printed on the screen. If you run the program repeatedly, you should see each result approximately half the time.

> [!NOTE]
> * The Python code is just a normal Python program. You can use any Python environment, including Python-based Jupyter Notebooks, to write the Python program and call Q# operations. The Python program can import Q# operations from any .qs files located in the same folder as the Python code itself.

## Next steps

Now that you have tested the Quantum Development Kit in your preferred environment, you can follow this tutorial to write and run [your first quantum program](xref:microsoft.quantum.quickstarts.qrng).

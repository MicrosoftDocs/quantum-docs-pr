---
title: Learn how to install the Microsoft Quantum Development Kit (QDK)
author: natke
ms.author: nakersha
ms.date: 9/30/2019
ms.topic: article
ms.custom: how-to
uid: microsoft.quantum.install
---

# Install the Microsoft Quantum Development Kit (QDK)

Learn how to install the Microsoft Quantum Development Kit (QDK), so that you can get started with quantum programming. The QDK consists of:

- the Q# programming language
- a set of libraries that abstract complex functionality in Q#
- a host application (written in Python or a .NET language) that runs quantum operations written in Q#
- tools to facilitate your development

Q# programs are often paired with a host program written in a .NET language (typically C#) or Python. This is useful to call quantum operations whenever we need it inside a classical code.
In addition the QDK provides Jupyter Notebook support with the IQ# Jupyter kernel.

You can choose the environment you are more comfortable with. Depending on your choice there are different installation steps. Choose your environment from the sections below:

- [Q# + Python:](xref:microsoft.quantum.install.python)choose this environment if you want to combine Python and Q# to create a Python host program that calls Q# operations whenever they are needed.
- [Q# Jupyter Notebooks:](xref:microsoft.quantum.install.jupyter) this environment is great for writing Q# code with embedded explanations or quantum computing interactive tutorials. Do not choose this environment if you want to combine Q# with a classical host program.
- [Q# + C#:](xref:microsoft.quantum.install.cs) choose this environment if you want to combine C# and Q# to crete hybrid quantum-classical programs.

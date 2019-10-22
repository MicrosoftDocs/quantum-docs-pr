---
title: What is Q#?
description: Learn about the Q#, a programming language created by Microsoft to develop applications for quantum computers
author: natke
ms.author:  nakersha
ms.date: 10/16/2019
ms.topic: article
uid: microsoft.quantum.overview.qsharp
---

# What is Q#?

Q# is a programming language created by Microsoft to develop applications for quantum computers.

The Q# programming language takes care of all the quantum computer's internal logic and provides you with an intuitive set of types, operations and logic expressions to develop algorithms without having to worry about the internal logic of the quantum computer.

## We want to code algorithms, not draw circuits

While the circuit model has been very useful for many years in quantum computing research, here at Microsoft, we believe that developers can go beyond quantum circuits and develop quantum algorithms and applications using Q#. The Q# language was built to take advantage of what we’ve learned through decades of classical software development, and empower quantum developers with the high-level language functionality they have become accustomed to in classical programming.

## How does Q# work?

Q# is a programming language designed to be great at writing quantum programs, by providing features that are special to quantum computing. Q# provides quantum programmers a framework that allows them to focus on the algorithms without having to care about technical details like gate sequence optimization or the physical implementation of a quantum computer.

For example, one of the fundamental building blocks of Q# is the `Qubit` type, which cannot be copied or directly accessed, just like a real qubit. Instead, we can measure it and store the outcome of the measurement in a `Result` variable, a Q# type that can take two possible values: `Zero` and `One`. Constructs like this one guarantee that algorithms always respect the laws of quantum mechanics and can run correctly on quantum computers or simulators.

Q# also includes classical logic features like conditionals or loops with some subtleties to make sure that all the quantum rules are being respected. For example, quantum operations need to be reversible. This enforces some constraints on the way loops are executed.

Q# programs are often paired with a host program written in C# or Python, which can provide convenient organization of classical and quantum code. In addition to supporting .NET languages such as C# and Python, the QDK provides Jupyter Notebook support with the IQ# Jupyter kernel.

## Use Q# to learn quantum computing

Until now, to learn quantum computing you needed to learn the circuit model to understand the algorithms in the form of ordered sequences of quantum gates and measurements. With Q# you can take another path: learn quantum computing by writing quantum programs.

Q# provides you with an increasing number of libraries and user-defined types that will help you to implement tools and functions already created by others to build advanced quantum algorithms. For example, you need to entangle two-qubits q1 and q2? Instead of applying individually the necessary gates to get the qubits entangled you can use the already built-in operation `PrepareEntangledState([q1], [q2])`.

## Next steps

Just as in classical computing, building programs on top of what others have already created will empower you to solve greater challenges. To know more about how you can learn quantum computing by coding in Q# check out [How to learn quantum computing](xref:microsoft.quantum.overview.learn).

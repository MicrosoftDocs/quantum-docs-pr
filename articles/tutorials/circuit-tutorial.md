---
title: Tutorial: Simulate a quantum circuit | Microsoft Docs
description: Step-by-step tutorial to simulate a basic quantum circuit in Q#. Explore quantum gates and superposition.
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.topic: tutorial 
ms.date: 10/06/2019
uid: microsoft.quantum.circuit-tutorial
# Customer intent: As a newcomer to the Q# (any amount of quantum experience), I want to know how to write and simulate a quantum circuit in Q# so that I can explore further on my own.
---



# Tutorial: Simulate a quantum circuit in Q#
Welcome to the Quantum Development Kit tutorial on setting up and simulating a basic quantum circuit. 
Having already [downloaded the QDK and set up your environment](xref:microsoft.quantum.install), you’re probably eager to get started. 
In this tutorial we will explore some key features of quantum-ness while showing you the necessary components of running an application with Q#.
By the end, you will be ready to take quantum circuits from paper and run them in Q#.


## In this tutorial, you'll learn how to:

> [!div class="checklist"]
> * Define quantum operations in Q#
> * Setup the classical driver to call and simulate Q# operations
> * Simulate a full circuit from qubit allocation to measurement output
> * Observe the simulated wavefunction of the full quantum system

Applications developed with Microsoft's Quantum Development Kit typically consists of two parts:
1. One or more quantum algorithms, implemented using the Q# quantum programming language.
2. A classical program, implemented in a classical programming language like Python or C#, 
  that serves as the main entry point and will invoke Q# operations 
  when it wants to execute a quantum algorithm.

In this tutorial we will first set up the classical driver file to call our Q# program on a target machine (in our case, the full state simulator) and display the output. 
We describe this process in both Python and C#.
Then, we will direct our attention to the Q# program itself, allocating qubits and seeing how basic gates and measurements affect our output. 
Lastly, we will show how the `DumpMachine` function can be used to print the wavefunction of our full simulated system.


## Define quantum operations

## Setup the classical driver

- In your development environment, create two files: driver.py (driver.cs), and Operations.qs
- The first part of this tutorial will consist of simulating single qubit "circuits" in which we instantiate a qubit, perform a single gate, and then measure it. We will then repeat this many times in order to get a more accurate depiction of the measurement statistics. The gates we will use are first none, and then the elementary 'X' and 'H' gates.
- In the section below, we will define the full circuits as operations in Q#, but here we will write the classical driver file that calls the Q# operations, and then processes the returned classical measurement data. 


```python
import qsharp
from Quantum.Operations import OneQubitNoGate, OneQubitX, OneQubitH

resNoGate = OneQubitNoGate.simulate(count=100)
resX = OneQubitX.simulate(count=100)
resH = OneQubitH.simulate(count=100)

print("Measured results: (# of |0>'s, # of |1>'s):\n"
      "No gate: " + str(resNoGate) +"\n"
      "X gate: " + str(resX) +"\n"
      "H gate: " + str(resH))

```
lkjdf;j

## Allocate qubits and define quantum operations













## Clean up resources

If you're not going to continue to use this application, delete
<resources> with the following steps:

1. From the left-hand menu...
2. ...click Delete, type...and then click Delete

<!---Required:
To avoid any costs associated with following the tutorial procedure, a
Clean up resources (H2) should come just before Next steps (H2)
--->

## Next steps

Advance to the next article to learn how to create...
> [!div class="nextstepaction"]
> [Next steps button](contribute-get-started-mvc.md)

<!--- Required:
Tutorials should always have a Next steps H2 that points to the next
logical tutorial in a series, or, if there are no other tutorials, to
some other cool thing the customer can do. A single link in the blue box
format should direct the customer to the next article - and you can
shorten the title in the boxes if the original one doesn’t fit.
Do not use a "More info section" or a "Resources section" or a "See also
section". --->
---
title: Running Q#: host programs vs. standalone applications
description: Overview of the different ways to run Q# programs: command line, Q# Jupyter Notebooks, and classical host programs in Python a .NET language.
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.date: 05/15/2020
ms.topic: article
uid: microsoft.quantum.guide.host-programs
---

# Running Q#: standalone applications vs. host programs

One of the Quantum Development Kit's greatest strengths is its flexibility across platforms and development environments.
However, this also means that new Q# users may find themselves confused or overwhelmed by the numerous options found in the [install guide](xref:microsoft.quantum.install).
On this page, we explain what happens when a Q# program is run, and compare the different ways in which users can do so.

A primary distinction is between running Q#:
    - as a standalone application, where Q# is the only language involved and the program is invoked directly, or
    - with an additional *host program*, written in Python or a .NET language (e.g. C# or F#), which then invokes the program and can further process returned results.

To best understand the process and differences, we consider a simple Q# program and compare the ways it can be executed.

## Basic Q# program

It would be very surprising if you've made it this far without hearing the word "superposition."
A very basic quantum program might consist of preparing a qubit in an equal superposition of states $\ket{0}$ and $\ket{1}$, measuring it, and returning the result, which will be randomly either one of the states with equal probability.
Indeed, this process is at the core of the [quantum random number generator](xref:microsoft.quantum.quickstarts.qrng) quickstart.

In Q#, this would be performed by the following code:

```qsharp
        using (q = Qubit()) {    // allocates qubit for use (automatically in |0>)
            H(q);                // puts qubit in superposition of |0> and |1>
            return MResetZ(q);   // measures qubit, returns result (and resets it to |0> before deallocation)
        }
```

However, this code alone can't be executed by Q#.
For that, it needs to make up the body of an [operation](xref:microsoft.quantum.guide.basics#q-operations-and-functions), which is then executed when called---either directly or by another operation. 
Hence it takes the form
```qsharp
    operation MeasureSuperposition() : Result {
        using (q = Qubit()) {
            H(q);
            return MResetZ(q);
        }
    }
```
and we now have defined an operation, `MeasureSuperposition`, which takes no arguments and returns a value of type [Result](xref:microsoft.quantum.guide.types).
More details on defining callables can be found at [Operations and functions](xref:microsoft.quantum.guide.operationsfunctions).

### Operation defined in a Q# file

The operation is precisely what's called and run by Q#.
However, it requires a few more additions to comprise a full `*.qs` Q# file.

All Q# types and callables are defined within *namespaces*, which the compiler can then open individually 

Firstly, the [`H`](xref:microsoft.quantum.intrinsic.h) and [`MResetZ`](xref:microsoft.quantum.measurements) actually belong to the [Q# Standard Libraries](xref:microsoft.quantum.qsharplibintro).
To be available for use, their respective *namespaces* need to be opened.
All Q# callables and types (both those you define and those intrinsic to the language) are defined within namespaces.
To access them, the compiler needs to be made aware of which namespaces to open.

So, the full Q# file containing our operation consists of defining our own namespace, opening the namespaces for the operations our operation uses, and then our operation:

```qsharp
namespace NamespaceName {
    open Microsoft.Quantum.Intrinsic;     // for the H operation
    open Microsoft.Quantum.Measurement;   // for MResetZ

    operation MeasureSuperposition() : Result {
        using (q = Qubit()) { 
            H(q);
            return MResetZ(q);
        }
    }
}
```

### Execution of a Q# program

Now the general execution model of a Q# program becomes clear.

<br/>
<img src="./images/general_execution_model.png" alt="Q# program execution diagram" width="300">

Firstly, the specific operation to be executed has access to any other callables and types defined in the same namespace.
Thanks to `open` statements, it can also access those from any of the [Q# libraries](xref:microsoft.quantum.libraries). 

The operation itself is then executed on a *target machine*.
In the future, one such target machine will be a real quantum computer, but there are currently multiple simulators available, each with a particular use.
For our purposes here, the target machine will simply be an instance of the full-state simulator, which calculates the program's behavior as if it were being executed on a noise-free quantum computer.

So far, we've described what happens when a specific Q# operation is being executed.
Regardless of whether Q# is used in a standalone application or with a host program, this general process is more or less the same---hence the QDK's flexibility.
The differences between the methods therefore reveal themselves in *how* that Q# operation is called to be executed, and in what manner any results are returned.

First, we discuss how this done with the Q# standalone application from the command line, and then proceed to using Python and C# host programs.
We reserve the standalone application of Q# Jupyter Notebooks for last, because unlike the first three, it does not actually require a Q# file.


## Q# from the command line
- diagram
- what are limitations of command line? Operations with arguments not possible?


## Q# with host programs
- diagram
- specify target machine (in C# we actually instantiate it before calling simulation)
- able to process returned data: e.g. plot it
FUTURE TO DO:
- cheat sheets for each host 

## Q# Jupyter Notebooks
- limitations?
- link to Q# sample code which details the nuances of Q# Jupyter Notebooks









































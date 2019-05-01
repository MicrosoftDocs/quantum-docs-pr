---
title: Quantum simulators and classical drivers | Microsoft Docs 
description: Describes how to drive quantum simulators with a classical computing .NET language, typically either C# or Q#.
author: QuantumWriter
ms.author: Alan.Geller@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
uid: microsoft.quantum.machines
---

# Classical Drivers and Machines

## What You'll Learn

> [!div class="checklist"]
> * How quantum algorithms are executed
> * What quantum simulators are included in this release
> * How to write a C# driver for your quantum algorithm

## The Quantum Development Kit Execution Model

In [Writing a quantum program](xref:microsoft.quantum.write-program),
we executed our quantum algorithm by passing a `QuantumSimulator` object
to the algorithm class's `Run` method.
The `QuantumSimulator` class executes the quantum algorithm by
fully simulating the quantum state vector, which is perfect for running and
testing `Teleport`.
See the [Concepts guide](xref:microsoft.quantum.concepts.intro) for more on quantum state vectors.

Other target machines may be used to run a quantum algorithm.
The machine is responsible for providing implementations of
quantum primitives for the algorithm.
This includes primitive operations such as H, CNOT, and Measure,
as well as qubit management and tracking.
Different classes of quantum machines represent different
execution models for the same quantum algorithm.

Each type of quantum machine may provide different implementations of
these primitives.
For instance, the quantum computer trace simulator included in the
development kit doesn't do any simulation at all.
Rather, it tracks gate, qubit, and other resource usage for the
algorithm.

### Quantum Machines

In the future, we will define additional quantum machine classes
to support other types of simulation and to support execution on
topological quantum computers.
Allowing the algorithm to stay constant while varying the underlying
machine implementation makes it easy to test and debug an algorithm
in simulation and then run it on real hardware with confidence
that the algorithm hasn't changed.

### What's Included in this Release

This release of the quantum developer kit includes several quantum machine classes.
All of them are defined in the `Microsoft.Quantum.Simulation.Simulators` namespace.

* A [full state vector simulator](xref:microsoft.quantum.machines.full-state-simulator), the `QuantumSimulator` class.
* A [simple resources estimator](xref:microsoft.quantum.machines.resources-estimator), the `ResourcesEstimator` class, it allows
  a top level analysis of the resources needed to run a quantum algorithm.
* A [trace-based resource estimator](xref:microsoft.quantum.machines.qc-trace-simulator.intro), the `QCTraceSimulator` class,
  it allows advanced analysis of resources consumptions for the algorithm's entire call-graph.
* A [Toffoli simulator](xref:microsoft.quantum.machines.toffoli-simulator), the `ToffoliSimulator` class.

## Writing a Classical Driver Program

In [Writing a quantum program](xref:microsoft.quantum.write-program), we wrote a simple C# driver for
our teleport algorithm. A C# driver has 4 main purposes:

* Constructing the target machine
* Computing any arguments required for the quantum algorithm
* Running the quantum algorithm using the simulator
* Processing the result of the operation

Here we'll discuss each step in more detail.

### Constructing the Target Machine

Quantum machines are instances of normal .NET classes, so they are created by
invoking their constructor, just like any .NET class.
Some simulators, including the `QuantumSimulator`, implement the .NET
<xref:System.IDisposable?displayProperty=nameWithType> interface, and so should be wrapped in a C# `using` statement.

### Computing Arguments for the Algorithm

In our `Teleport` example, we computed some relatively artificial arguments
to pass to our quantum algorithm.
More typically, however, there is significant data required by the quantum
algorithm, and it is easiest to provide it from the classical driver.

For instance, when doing chemical simulations, the quantum algorithm requires
a large table of molecular orbital interaction integrals.
Generally these are read in from a file that is provided when running the
algorithm.
Since Q# does not have a mechanism for accessing the file system, this sort
of data is best collected by the classical driver and then passed to the
quantum algorithm's `Run` method.

Another case where the classical driver plays a key role is in variational
methods.
In this class of algorithms, a quantum state is prepared based on some
classical parameters, and that state is used to compute some value of interest.
The parameters are adjusted based on some type of hill climbing or
machine learning algorithm and the quantum algorithm run again.
For such algorithms, the hill climbing algorithm itself is best implemented
as a purely classical function that is called by the classical driver;
the results of the hill climbing are then passed to the next execution of the
quantum algorithm.

### Running the Quantum Algorithm

This part is generally very straightforward.
Each Q# operation is compiled into a class that provides a static `Run` method.
The arguments to this method are given by the flattened argument tuple of the operation itself,
plus an additional first argument which is the simulator to execute with. For an operation that expects
the named tuple of type `(a: String, (b: Double, c: Double))` its flattened counterpart is of type `(String a, Double b, Double c)`.


There are some subtleties when passing arguments to a `Run` method:

* Arrays must be wrapped in a `Microsoft.Quantum.Simulation.Core.QArray<T>`
    object.
    A `QArray` class has a constructor that can take any ordered collection
    (`IEnumerable<T>`) of appropriate objects.
* The empty tuple, `()` in Q#, is represented by `QVoid.Instance` in C#.
* Non-empty tuples are represented as .NET `ValueType` instances.
* Q# user-defined types are passed as their base type.
* To pass an operation or a function to a `Run` method, you have to obtain an
    instance of the operation's or function's class, using the simulator's `Get<>` method.

### Processing the Results

The results of the quantum algorithm are returned from the `Run` method.
The `Run` method executes asynchronously thus it returns a 
[`Task<T>`](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1). 
There are multiple ways to get the actual operation's results. The simplest is
by using the `Task`'s [`Result` property](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1.result):

```csharp
    var res = BellTest.Run(sim, 1000, initial).Result;
```
but other techniques, like using the [`Wait` method](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task.wait)
or C# [`await` keyword](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/await)
will also work.

As with arguments, Q# tuples are represented as `ValueTuple` instances and
Q# arrays are represented as `QArray` instances.
User-defined types are returned as their base types.
The empty tuple, `()`, is returned as an instance of the `QVoid` class.

Many quantum algorithms require substantial post-processing to derive
useful answers.
For instance, the quantum part of Shor's algorithm is just the beginning
of a computation that finds the factors of a number.

In most cases, it is simplest and easiest to do this sort of post-processing
in the classical driver.
Only the classical driver can report results to the user or write them to disk.
The classical driver will have access to analytical libraries and other
mathematical functions that are not exposed in Q#.


## Failures

When the Q# `fail` statement is reached during the execution of an operation,
an `ExecutionFailException` is thrown.

Due to the use of `System.Task` in the `Run` method, the exception thrown as a result of a `fail` 
statement will be wrapped into a `System.AggregateException`.
To find the actual reason for the failure, you need to iterate into the `AggregateException` 
`InnerExceptions`, for example:

```csharp

            try
            {
                using(var sim = new QuantumSimulator())
                {
                    /// call your operations here...
                }
            }
            catch (AggregateException e)
            {
                // Unwrap AggregateException to get the message from Q# fail statement.
                // Go through all inner exceptions.
                foreach (Exception inner in e.InnerExceptions)
                {
                    // If the exception of type ExecutionFailException
                    if (inner is ExecutionFailException failException)
                    {
                        // Print the message it contains
                        Console.WriteLine($" {failException.Message}");
                    }
                }
            }
```

## Other Classical Languages

While the samples we have provided are in C#, F#, and Python, the Quantum Development Kit also supports writing classical host programs in other languages.
For example, if you want to write a host program in Visual Basic, [it should work just fine](https://github.com/tcNickolas/MiscQSharp/blob/master/Quantum_VBNet/README.md#using-q-with-visual-basic-net).

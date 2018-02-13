---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Write a quantum program | Microsoft Docs 
description: Learn how to write a quantum program in Q#. Develop a Bell  State application in Visual Studio.
author: QuantumWriter
ms.author: Alan.Geller@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# For Quantum products none of these categories have been defined  yet.
# ms.service: service-name-from-white-list
# ms.prod: product-name-from-white-list
# ms.technology: tech-name-from-white-list
---
# Writing a Quantum Program

## What You'll Learn

> [!div class="checklist"]
> * How to set up a quantum solution and project in Visual Studio
> * The components of a Q# operation
> * How to call a Q# operation from C#
> * How to build and execute your quantum algorithm

## Creating a Bell State in Q#

Now that you’ve installed the Microsoft Quantum Development Kit and seen
how it works, let’s write your first quantum application.
We'll start with the simplest program possible and build it up to demonstrate quantum superposition and quantum entanglement. We will start with a qubit in a basis state $\ket{0}$, perform some operations on it and then measure the result.

### Step 1: Create a Project and Solution

#### [Visual Studio 2017](#tab/tabid-vs2017-step1)

Open up Visual Studio 2017.
Go to the `File` menu and select `New` > `Project...`.
In the project template explorer, under `Installed` > `Visual C#`,
select the `Q# Application` template.
Make sure you have `.NET Framework 4.6.1` selected in the list at the top of the `New Project` dialog box.
Give your project the name `Bell`.

#### [Visual Studio Code](#tab/tabid-vscode-step1)

```bash
$ dotnet new console -lang Q# --output Bell
$ cd Bell
```

***

### Step 2 (optional): Update NuGet Packages

If you want to run the latest version, update the `Microsoft.Quantum.Development.Kit` and `Microsoft.Quantum.Canon` NuGet packages, as described in [Updating a Package](https://docs.microsoft.com/en-us/nuget/tools/package-manager-ui#updating-a-package).

### Step 3: Enter the Q# Code

Our goal is to create a [Bell State](https://en.wikipedia.org/wiki/Bell_state) showing entanglement. We will build this up piece by piece to show the concepts of qubit state, gates and measurement.

Visual Studio should have two files open:
`Driver.cs`, which will hold the C# driver for your quantum code,
and `Operation.qs`, which will hold the quantum code itself.

The first step is to rename the Q# file to `Bell.qs`.
Right-click on `Operation.qs` in the Visual Studio
Solution Explorer, and select the Rename option.
Replace `Operation` with `Bell` and hit return.

To enter the Q# code, make sure that you are editing the
`Bell.qs` window.
The `Bell.qs` file should have the following contents:

```qsharp
namespace Quantum.Bell
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

    operation Operation () : ()
    {
        body
        {

        }
    }
}
```

First, replace the string `Operation` with `Set`, and change the operation
parameters (the first pair of parentheses) to contain the string
`desired: Result, q1: Qubit`.
The file should now look like:

```qsharp
namespace Quantum.Bell
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

    operation Set (desired: Result, q1: Qubit) : ()
    {
        body
        {

        }
    }
}
```

Now, type the following between the braces that enclose the operation body:

```qsharp
            let current = M(q1);

            if (desired != current)
            {
                X(q1);
            }
```

The file should now look like:

```qsharp
namespace Quantum.Bell
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

    operation Set (desired: Result, q1: Qubit) : ()
    {
        body
        {
            let current = M(q1);
            if (desired != current)
            {
                X(q1);
            }
        }
    }
}
```

This operation may now be called to set a qubit in a known state (`Zero` or `One`). We measure the qubit, if it's in the state we want, we leave it alone, otherwise, we flip it with the `X` gate.

> [!NOTE]
> This code defines a Q# __operation__.
> An operation is the basic unit of quantum execution in Q#.
> It is roughly equivalent to a function in C or C++ or Python,
> or a static method in C# or Java.
>
> The arguments to an operation are specified as a tuple, within parentheses.
> The return type of the operation is specified after a colon.
> In this case, the `Set` operation has no return, so it is marked as
> returning an empty tuple, `()`.
> This is the Q# equivalent of `unit` in F#, which is roughly analogous to
> `void` in C#.
> 
> An operation has a __body__ section, which contains the implementation
> of the operation.
> An operation may also have __adjoint__, __controlled__, and 
> __controlled adjoint__ sections.
> These are used to specify specific variants of appropriate operations.
> See the [Q# language reference](quantum-QR-Intro.md) for more
> information.

Add the following operation to the namespace, after the end of the
`Set` operation:

```qsharp
    operation BellTest (count : Int, initial: Result) : (Int,Int)
    {
        body
        {
            mutable numOnes = 0;
            using (qubits = Qubit[1])
            {
                for (test in 1..count)
                {
                    Set (initial, qubits[0]);

                    let res = M (qubits[0]);

                    // Count the number of ones we saw:
                    if (res == One)
                    {
                        set numOnes = numOnes + 1;
                    }
                }
                Set(Zero, qubits[0]);
            }
            // Return number of times we saw a |0> and number of times we saw a |1>
            return (count-numOnes, numOnes);
        }
    }
```

This operation (`BellTest`) will loop for `count` iterations, set a specified `initial` value on a qubit and them measure (`M`) the result. It will gather statistics on how many zeros and ones we've measured and return them to the caller. It performs one other necessary operation. It resets the qubit to a known state (`Zero`) before returning it allowing others to allocate this qubit in a known state. This is required by the `using` statement.

All of these calls use primitive quantum operations that are
defined in the `Microsoft.Quantum.Primitive` namespace.
For instance, the `M` operation measures its argument qubit in the
computational (`Z`) basis, and `X` applies a state flip around the x axis
to its argument qubit.

> [!NOTE]
> As you can see, Q# uses C#-like semicolons and braces to indicate
> program structure.
>
> Q# has an __if__ statement that is very much like C#.
>
> Q# deals with variables in a unique way.
> By default, variables in Q# are immutable; their value may not be changed
> after they are bound.
> The `let` keyword is used to indicate the binding of an immutable variable.
> Operation arguments are always immutable.
>
> If you need a variable whose value can change, such as `numOnes`
> in the example, you can declare the variable with the `mutable` keyword.
> A mutable variable's value may be changed using a `set` statement.
>
> In both cases, the type of a variable is inferred by the compiler.
> Q# doesn't require any type annotations for variables.
>
> The `using` statement is also special to Q#.
> It is used to allocate an array of qubits for use in a block of code.
> In Q#, all qubits are dynamically allocated and released,
> rather than being fixed resources that are there for the entire
> lifetime of a complex algorithm.
> A `using` statement allocates a set of qubits at the start and releases
> those qubits at the end of the block.
> There is an analogous `borrowing` statement that is used to allocate
> potentially dirty ancilla qubits.
>
> A `for` loop in Q# always iterates through a range.
> There is no Q# equivalent to a traditional C-style computer __for__ statement.
> A range may be specified by the first and last integers in the range, as in
> the example: `1..10` is the range 1, 2, 3, 4, 5, 6, 7, 8, 9, and 10.
> If a step other than +1 is needed, then three integers with `..` between
> them is used: `1..2..10` is the range 1, 3, 5, 7, and 9.
> Note that ranges are inclusive at both ends.
>
> The `BellTest` operation returns two values as a tuple.
> The operation's return type is `(Int, Int)`, and the `return` statement
> has an explicit tuple containing two integer variables.
> Q# uses tuples as a way to pass multiple values, rather than using
> structures or records.

### Step 4: Enter the C# Driver Code

Switch to the `Driver.cs` file in Visual Studio.
This file should have the following contents:

```csharp
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.Bell
{
    class Driver
    {
        static void Main(string[] args)
        {

        }
    }
}
```

In the `Main` method, enter the following code:

```csharp
            using (var sim = new QuantumSimulator())
            {
                // Try initial values
                Result[] initials = new Result[] { Result.Zero, Result.One };
                foreach (Result initial in initials)
                {
                    var res = BellTest.Run(sim, 1000, initial).Result;
                    var (numZeros, numOnes) = res;
                    System.Console.WriteLine(
                        $"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4}");
                }
            }
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
```

> [!NOTE]
> The C# driver has four parts:
> * Construct a quantum simulator. 
>   In the example, `sim` is the simulator.
> * Compute any arguments required for the quantum algorithm.
>   In the example, `count` is fixed at a 1000 and `initial` is the initial value of the qubit.
> * Run the quantum algorithm.
>   Each Q# operation generates a C# class with the same name.
>   This class has a `Run` method that **asynchronously** executes the operation.
>   The execution is asynchronous because execution on actual hardware will be
>   asynchronous. 
>
>   Because the `Run` method is asynchronous, we fetch the `Result` property;
>   this blocks execution until the task completes and returns the result synchronously.
>   
> * Process the result of the operation.
>   In the example, `res` receives the result of the operation.
>   Here the result is a tuple of the number of zeros (`numZeros`) and number of ones (`numOnes`)
>   measured by the simulator. This is returned as a ValueTuple in C#.
>   We deconstruct the tuple to get the two fields, print the results,
>   and then wait for a keypress.

### Step 5: Build and Run

Just hit `F5`, and your program should build and run!

The results should be:

```Output
Init:Zero 0s=1000 1s=0
Init:One  0s=0    1s=1000
Press any key to continue...
```

The program will exit after you press a key.

### Step 6: Creating Superposition

Now we want to manipulate the qubit. First we'll just try to flip it. This is accomplished by performing an `X` gate before we measure it in `BellTest`:

```qsharp
                    X(qubits[0]);
                    let res = M (qubits[0]);
```

Now the results (after pressing `F5`) are reversed:

```Output
Init:Zero 0s=0    1s=1000
Init:One  0s=1000 1s=0
```

However, everything we've seen so far is classical. Let's get a quantum result. All we need to do is replace the `X` gate in the previous run with an `H` or Hadamard gate. Instead of flipping the qubit all the way from 0 to 1, we will only flip it halfway. The replaced lines in `BellTest` now look like:

```qsharp
                    H(qubits[0]);
                    let res = M (qubits[0]);
```

Now the results get more interesting:

```Output
Init:Zero 0s=484  1s=516
Init:One  0s=522  1s=478
```

Every time we measure, we ask for a classical value, but the qubit is halfway between 0 and 1, so we get (statistically) 0 half the time and 1 half the time. This is known as __superposition__ and gives us our first real view into a quantum state.

### Step 7: Creating Entanglement

Now we'll make the promised [Bell State](https://en.wikipedia.org/wiki/Bell_state) and show off __entanglement__. The first thing we'll need to do is allocate 2 qubits instead of one in `BellTest`:

```qsharp
            using (qubits = Qubit[2])
```

This will allow us to add a new gate (`CNOT`) before we measure  (`M`) in `BellTest`:

```qsharp
                    Set (initial, qubits[0]);
                    Set (Zero, qubits[1]);

                    H(qubits[0]);
                    CNOT(qubits[0],qubits[1]);
                    let res = M (qubits[0]);
```

We've added another `Set` operation to initialize qubit 1 to make sure that it's always in the `Zero` state when we start.

We also need to reset the second qubit before releasing it (this could also be done with a `for` loop). We'll add a line after qubit 0 is reset:

```qsharp
            Set(Zero, qubits[0]);
            Set(Zero, qubits[1]);
```

The full routine now looks like this:

```qsharp
    operation BellTest (count : Int, initial: Result) : (Int,Int)
    {
        body
        {
            mutable numOnes = 0;
            using (qubits = Qubit[2])
            {
                for (test in 1..count)
                {
                    Set (initial, qubits[0]);
                    Set (Zero, qubits[1]);

                    H(qubits[0]);
                    CNOT(qubits[0],qubits[1]);
                    let res = M (qubits[0]);

                    // Count the number of ones we saw:
                    if (res == One)
                    {
                        set numOnes = numOnes + 1;
                    }
                }
                Set(Zero, qubits[0]);
                Set(Zero, qubits[1]);
            }
            // Return number of times we saw a |0> and number of times we saw a |1>
            return (count-numOnes, numOnes);
        }
    }
```

If we run this, we'll get exactly the same 50-50 result we got before. However, what we're really interested in is how the second qubit reacts to the first being measured. We'll add this statistic with a new version of the `BellTest` operation:

```qsharp
    operation BellTest (count : Int, initial: Result) : (Int,Int,Int)
    {
        body
        {
            mutable numOnes = 0;
            mutable agree = 0;
            using (qubits = Qubit[2])
            {
                for (test in 1..count)
                {
                    Set (initial, qubits[0]);
                    Set (Zero, qubits[1]);

                    H(qubits[0]);
                    CNOT(qubits[0],qubits[1]);
                    let res = M (qubits[0]);

                    if (M (qubits[1]) == res) 
                    {
                        set agree = agree + 1;
                    }

                    // Count the number of ones we saw:
                    if (res == One)
                    {
                        set numOnes = numOnes + 1;
                    }
                }
            Set(Zero, qubits[0]);
            Set(Zero, qubits[1]);
            }
            // Return number of times we saw a |0> and number of times we saw a |1>
            return (count-numOnes, numOnes, agree);
        }
    }
```

There is now a new return value (`agree`) that will keep track of every time the measurement from the first qubit matches the measurement of the second qubit. Of course, we also have to update the __Driver.cs__ file accordingly:

```csharp
            using (var sim = new QuantumSimulator())
            {
                // Try initial values
                Result[] initials = new Result[] { Result.Zero, Result.One };
                foreach (Result initial in initials)
                {
                    var res = BellTest.Run(sim, 1000, initial).Result;
                    var (numZeros, numOnes, agree) = res;
                    System.Console.WriteLine(
                        $"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4} agree={agree,-4}");
                }
            }
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
```
Now when we run, we get something pretty amazing:

```Output
Init:Zero 0s=499  1s=501  agree=1000
Init:One  0s=490  1s=510  agree=1000
```

Our statistics for the first qubit haven't changed (50-50 chance of a 0 or a 1), but now when we measure the second qubit, it is __always__ the same as what we measured for the first qubit. Our `CNOT` has entangled the two qubits, so that whatever happens to one of them, happens to the other. If you reversed the measurements (did the second qubit before the first), the same thing would happen. The first measurement would be random and the second would be in lock step with whatever was discovered for the first.

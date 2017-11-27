---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Write a quantum program | Microsoft Docs 
description: Learn how to write a quantum program in Q#. Develop the quantum teleporation application in Visual Studio.
services: service-name-with-dashes-AZURE-ONLY 
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: QuantumWriter
ms.author: MSFT-alias-person-or-DL
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# ms.service: service-name-from-white-list
# product-name-from-white-list

# Optional fields. Don't forget to remove # if you need a field.
# ms.custom: can-be-multiple-comma-separated
# ms.devlang:devlang-from-white-list
# ms.suite: 
# ms.tgt_pltfrm:
# ms.reviewer:
# manager: MSFT-alias-manager-or-PM-counterpart
---

# Writing a quantum program

## What you'll learn

> [!div class="checklist"]
> * How to set up a quantum solution and project in Visual Studio
> * The components of a Q# operation
> * How to call a Q# operation from C#
> * How to build and execute your quantum algorithm

## Writing teleport in Q#

Now that you’ve installed the Microsoft Quantum Development Kit and seen
how it works, let’s write your first quantum application.
We'll start with the same simple teleport algorithm that you ran
earlier.

### Step 1: Create a project and solution

Open up Visual Studio 2017.
Go to the `File` menu and select `New` > `Project...`.
In the project template explorer, under `Installed` > `Visual C#`,
select the `Q# Application` template.
Give your project the name `Teleport`.

### Step 2 (optional): Update NuGet packages

If you want to get the latest version of Q# compiler, update `Microsoft.Quantum.Simulation.Simulators` NuGet package, as described in [Updating a Package](https://docs.microsoft.com/en-us/nuget/tools/package-manager-ui#updating-a-package). Note that you'll have to switch to QuArC beta NuGet feed as the package source before you can get the update.

### Step 3: Enter the Q# code

Visual Studio should have two files open:
`Driver.cs`, which will hold the C# driver for your quantum code,
and `Operation.qs`, which will hold the quantum code itself.

The first step is to rename the Q# file to `Teleport.qs`.
To do this, right-click on `Operation.qs` in the Visual Studio
Solution Explorer, and select the Rename option.
Replace `Operation` with `Teleport` and hit return.

To enter the Q# code, make sure that you are editing the
`Teleport.qs` window.
The `Teleport.qs` file should have the following contents:

```qsharp
namespace Quantum.Teleport
{
    open Microsoft.Quantum.Primitive;

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
namespace Quantum.Teleport
{
    open Microsoft.Quantum.Primitive;

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
namespace Quantum.Teleport
{
    open Microsoft.Quantum.Primitive;

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

Add the following operations to the namespace, after the end of the
`Set` operation:

```qsharp
    operation EPR (q1 : Qubit, q2 : Qubit) : ()
    {
        body 
        {
            // Apply a Hadamard to qubit 1 
            H (q1);
            // Apply a controlled NOT gate between qubit 1 and qubit 2
            CNOT (q1, q2);
        }
    }

    operation Teleport (msg : Qubit, here : Qubit, there : Qubit) : ()
    {
        body 
        {
            // Generate an EPR pair
            EPR (here, there);
            // Apply a controlled NOT between our message qubit and 
            // the local qubit of our EPR pair
            CNOT (msg, here);
            // Apply a Hadamard gate to the message qubit
            H (msg);

            // Measure the local qubit of the EPR pair. The (classical)
            // result of this measurement is sent to the remote party.
            let m_here = M (here);
            // If the measurement outcome is 1...
            if (m_here == One) {
                // ... do an X gate on the remote qubit of the EPR pair
                X (there);
            }
            // Measure the message qubit. The (classical) result is
            // sent to the remote party.
            let m_msg = M (msg);
            // If the measurement is 1...
            if (m_msg == One) {
                // ... do a Z gate on the remote qubit
                Z (there);
            }
        }
    }

    operation TeleportTest (theta : Double) : (Int, Int)
    {
        body
        {
            let count = 10;
            mutable successes = 0;
            using (qubits = Qubit[3])
            {
                for (test in 1..count)
                {
                    // Rotate the message qubit
                    Rz (theta, qubits[0]);

                    Teleport (qubits[0], qubits[1], qubits[2]);

                    // Un-rotate the target and measure
                    Rz (-theta, qubits[2]);
                    let res = M (qubits[2]);

                    // If the result was Zero, then we succeeded
                    if (res == Zero)
                    {
                        set successes = successes + 1;
                    }

                    // Reset the qubits
                    for (i in 0..2)
                    {
                        Set (Zero, qubits[i]);
                    }
                }
            }
            return (successes, count);
        }
    }
```

The file now defines four operations:

* `Set`, which sets the state of a qubit to a desired value in the
    computational basis.
* `EPR`, which entangles two qubits into an EPR pair.
* `Teleport`, which contains the actual teleportation algorithm.
* `TeleportTest`, which is a driver routine that takes the state of
    the qubit to be teleported and returns the measured state of
    the qubit that was the target of the teleportation.

All of these operations use primitive quantum operations that are
defined in the `Microsoft.Quantum.Primitive` namespace.
For instance, the `M` operation measures its argument qubit in the
computational (`Z`) basis, and `H` applies the quantum Hadamard gate
to its argument qubit.

> [!NOTE]
> As you can see, Q# uses C#-like semicolons and braces to indicate
> program structure.
>
> Q# has an __if__ statement that is very much like C#.
>
> Q# deals with variables in a unique way.
> By default, variables in Q# are immutable; their value may not be changed
> after it is bound.
> The `let` keyword is used to indicate the binding of an immutable variable.
> Operation arguments are always immutable.
>
> If you need a variable whose value can change, such as `successes`
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
> There is no Q# equivalent to a traditional C-style computer for statement.
> A range may be specified by the first and last integers in the range, as in
> the example: `1..10` is the range 1, 2, 3, 4, 5, 6, 7, 8, 9, and 10.
> If a step other than +1 is needed, then three integers with `..` between
> them is used: `1..2..10` is the range 1, 3, 5, 7, and 9.
> Note that ranges are inclusive at both ends.
>
> The `TeleportTest` operation returns two values as a tuple.
> The operation's return type is `(Int, Int)`, and the `return` statement
> has an explicit tuple containing two integer variables.
> Q# uses tuples as a way to pass multiple values, rather than using
> structures or records.

### Step 4: Enter the C# driver code

Switch to the `Driver.cs` file in Visual Studio.
This file should have the following contents:

```csharp
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.Teleport
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
                // Pick some angles and make sure teleportation works
                for (double theta = 0.1; theta < 1.0; theta += 0.2)
                {
                    var res = TeleportTest.Run(sim, theta).Result;
                    var (successes, count) = res;
                    System.Console.WriteLine($"Sending an angle of {theta} radians worked {successes} times out of {count}");
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
>   In the example, this is `theta`, the angle to rotate the message state
>   through before sending.
> * Run the quantum algorithm.
>   Each Q# operation generates a C# class with the same name.
>   This class has a `Run` method that asynchronously executes the operation.
>   The execution is asynchronous because execution on actual hardware will be
>   asynchronous.
> * Process the result of the operation.
>   In the example, `res` receives the result of the operation.
>   Here the result is a tuple of the number of successes and the total
>   count of trials, represented as a ValueTuple in C#.
>   We deconstruct the tuple to get the two fields, print the results,
>   and then wait for a keypress.

### Step 5: Build and run

Just hit `F5`, and your program should build and run!

The results should be:

```Output
Sending an angle of 0.1 radians worked 10 times out of 10
Sending an angle of 0.3 radians worked 10 times out of 10
Sending an angle of 0.5 radians worked 10 times out of 10
Sending an angle of 0.7 radians worked 10 times out of 10
Sending an angle of 0.9 radians worked 10 times out of 10
Press any key to continue...
```

The program will exit after you press a key.

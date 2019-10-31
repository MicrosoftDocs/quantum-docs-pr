---
title: Write your first quantum program
description: Learn how to write a quantum program in Q#. Develop a Bell State application using the Quantum Development Kit (QDK)
author: natke
ms.author: nakersha 
ms.date: 10/07/2019
ms.topic: tutorial
uid: microsoft.quantum.write-program
---
# Write your first quantum program

Learn how to write a quantum program using the Microsoft QDK. You will write an application to demonstrate quantum entanglement, which is called a **Bell state**.

You start with the simplest program possible and build it up to demonstrate [quantum superposition and quantum entanglement](xref:microsoft.quantum.overview.what#the-qubit).

## Pre-requisites

* [Install](xref:microsoft.quantum.install) the Quantum Development Kit using your preferred language and development environment
* If you already have the QDK installed, make sure you have [updated](xref:microsoft.quantum.update) to the latest version

## What You'll Learn

> [!div class="checklist"]
> * How to set up a quantum solution and project
> * The components of a Q# operation
> * How to call a Q# operation from a host program
> * How to entangle two qubits

## Setup

Applications developed with Microsoft's Quantum Development Kit consist of two parts:

1. One or more quantum algorithms, implemented using the Q# quantum programming language.
1. A host program, implemented in a programming language like Python or C# that serves as the main entry point and invokes Q# operations to execute a quantum algorithm.

#### [Python](#tab/tabid-python)

1. Choose a location for your application

1. Create a file called `Bell.qs`. This file will contain your Q# code.

1. Create a file called `host.py`. This file will contain your Python host code.

#### [C# Command Line](#tab/tabid-csharp)

1. Create a new Q# project:

    ```bash
    dotnet new console -lang Q# --output Bell
    cd Bell
    ```

    You should see a `.csproj` file, a Q# file called `Operations.qs`, and a host program file called `Driver.cs`

1. Rename the Q# file

    ```bash
    mv Operation.qs Bell.qs
    ```

#### [Visual Studio](#tab/tabid-vs2019)

1. Create a new project

   * Open Visual Studio
   * Go to the **File** menu and select **New** -> **Project...**
   * In the project template explorer, under `Installed` > `Visual C#`, select the `Q# Application` template
   * Make sure you have `.NET Framework 4.6.1` selected in the list at the bottom of the `New Project` dialog box
   * Give your project the name `Bell`

1. Rename the Q# file

   * Navigate to the **Solution Explorer**
   * Right click on the `Operations.qs` file
   * Rename it to `Bell.qs`

* * *

## Write a Q# operation

Our goal is to prepare two qubits in a [Bell state](https://en.wikipedia.org/wiki/Bell_state) showing entanglement. We will build this up piece by piece to demonstrate qubit states, gates, and measurement.

### Q# operation code

1. Replace the contents of the Bell.qs file with the following code:

    ```qsharp
    namespace Quantum.Bell {
        open Microsoft.Quantum.Intrinsic;
        open Microsoft.Quantum.Canon;

        operation Set(desired : Result, q1 : Qubit) : Unit {
            if (desired != M(q1)) {
                X(q1);
            }
        }
    }
    ```

    This operation may now be called to set a qubit to a known state (`Zero` or `One`).

    We measure the qubit, if it's in the state we want, we leave it alone, otherwise, we flip it with the `X` gate.

### About Q# operations

An operation is the basic unit of quantum execution in Q#. It is roughly equivalent to a function in C or C++ or Python, or a static method in C# or Java.

The arguments to an operation are specified as a tuple, within parentheses.

The return type of the operation is specified after a colon. In this case, the `Set` operation has no return, so it is marked as returning `Unit`. This is the Q# equivalent of `unit` in F#, which is roughly analogous to `void` in C#, and an empty tuple (`Tuple[()]`) in Python.

### About quantum gates

You have used two quantum gates in your first Q# operation:

* The [M](xref:microsoft.quantum.intrinsic.m) gate, which measures the state of the qubit
* The [X](xref:microsoft.quantum.intrinsic.x) gate, which flips the state of a qubit

A quantum gate transforms the state of a qubit. The name comes from the analogy of a classical logic gate such as a `NOT` gate, which inverts the state of a classical bit.

### Add Q# test code

1. Add the following operation to the `Bell.qs` file, inside the namespace, after the end of the
`Set` operation:

    ```qsharp
    operation TestBellState(count : Int, initial : Result) : (Int, Int) {

        mutable numOnes = 0;
        using (qubit = Qubit()) {

            for (test in 1..count) {
                Set(initial, qubit);
                let res = M(qubit);

                // Count the number of ones we saw:
                if (res == One) {
                    set numOnes += 1;
                }
            }
            Set(Zero, qubit);
        }

        // Return number of times we saw a |0> and number of times we saw a |1>
        return (count-numOnes, numOnes);
    }
    ```

    This operation (`TestBellState`) will loop for `count` iterations, set a specified `initial` value on a qubit and then measure (`M`) the result. It will gather statistics on how many zeros and ones we've measured and return them to the caller. It performs one other necessary operation. It resets the qubit to a known state (`Zero`) before returning it allowing others to allocate this qubit in a known state. This is required by the `using` statement.

### About variables in Q#

Q# deals with variables in a unique way. By default, variables in Q# are immutable; their value may not be changed after they are bound. The `let` keyword is used to indicate the binding of an immutable variable. Operation arguments are always immutable.

If you need a variable whose value can change, such as `numOnes` in the example, you can declare the variable with the `mutable` keyword. A mutable variable's value may be changed using a `set` statement.

In both cases, the type of a variable is inferred by the compiler. Q# doesn't require any type annotations for variables.

### About `using` statements in Q#

The `using` statement is also special to Q#. It is used to allocate qubits for use in a block of code. In Q#, all qubits are dynamically allocated and released, rather than being fixed resources that are there for the entire lifetime of a complex algorithm. A `using` statement allocates a set of qubits at the start, and releases those qubits at the end of the block.

## Create the host application code

#### [Python](#tab/tabid-python)

1. Open the `host.py` file and add the following code:

    ```python
    import qsharp

    from qsharp import Result
    from Quantum.Bell import TestBellState

    initials = (Result.Zero, Result.One)

    for i in initials:
      res = TestBellState.simulate(count=1000, initial=i)
      (num_zeros, num_ones) = res
      print(f'Init:{i: <4} 0s={num_zeros: <4} 1s={num_ones: <4}')
    ```

#### [C#](#tab/tabid-csharp)

1. Replace the contents of the `Driver.cs` file with the following code:

    ```csharp
    using System;

    using Microsoft.Quantum.Simulation.Core;
    using Microsoft.Quantum.Simulation.Simulators;

    namespace Quantum.Bell
    {
        class Driver
        {
            static void Main(string[] args)
            {
                using (var qsim = new QuantumSimulator())
                {
                    // Try initial values
                    Result[] initials = new Result[] { Result.Zero, Result.One };
                    foreach (Result initial in initials)
                    {
                        var res = TestBellState.Run(qsim, 1000, initial).Result;
                        var (numZeros, numOnes) = res;
                        System.Console.WriteLine(
                            $"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4}");
                    }
                }

                System.Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
    ```

#### [](#tab/tabid-vs2019)

* * *

### About the host application code

#### [Python](#tab/tabid-python)

The Python host application has three parts:

* Compute any arguments required for the quantum algorithm. In the example, `count` is fixed at a 1000 and `initial` is the initial value of the qubit.
* Run the quantum algorithm by calling the `simulate()` method of the imported Q# operation.
* Process the result of the operation. In the example, `res` receives the result of the operation. Here the result is a tuple of the number of zeros (`num_zeros`) and number of ones (`num_ones`) measured by the simulator. We deconstruct the tuple to get the two fields, and print the results.

#### [C#](#tab/tabid-csharp)

The C# host application has four parts:

* Construct a quantum simulator. In the example, `qsim` is the simulator.
* Compute any arguments required for the quantum algorithm. In the example, `count` is fixed at a 1000 and `initial` is the initial value of the qubit.
* Run the quantum algorithm. Each Q# operation generates a C# class with the same name. This class has a `Run` method that **asynchronously** executes the operation. The execution is asynchronous because execution on actual hardware will be asynchronous. Because the `Run` method is asynchronous, we fetch the `Result` property; this blocks execution until the task completes and returns the result synchronously.
* Process the result of the operation. In the example, `res` receives the result of the operation. Here the result is a tuple of the number of zeros (`numZeros`) and number of ones (`numOnes`) measured by the simulator. This is returned as a ValueTuple in C#. We deconstruct the tuple to get the two fields, print the results, and wait for a keypress.

#### [](#tab/tabid-vs2019)

* * *

## Build and run

#### [Python](#tab/tabid-python)

1. Run the following command at your terminal:

    ```
    python host.py
    ```

    This command runs the host application, which simulates the Q# operation.

The results should be:

```Output
Init:0    0s=1000 1s=0   
Init:1    0s=0    1s=1000
```

#### [Command Line / Visual Studio Code](#tab/tabid-csharp)

1. Run the following at your terminal:

    ```bash
    dotnet run
    ```

    This command will automatically download all required packages, build the application, then run it at the command line.

1. Alternatively, press **F1** to open the Command Palette and select **Debug: Start Without Debugging.**
You may be prompted to create a new ``launch.json`` file describing how to start the program.
The default ``launch.json`` should work well for most applications.

The results should be:

```Output
Init:Zero 0s=1000 1s=0
Init:One  0s=0    1s=1000
Press any key to continue...
```

#### [Visual Studio](#tab/tabid-vs2019)

1. Just hit `F5`, and your program should build and run!

The results should be:

```Output
Init:Zero 0s=1000 1s=0
Init:One  0s=0    1s=1000
Press any key to continue...
```

The program will exit after you press a key.

* * *

## Prepare superposition

Now we want to manipulate the qubit. First we'll just try to flip it. This is accomplished by performing an `X` gate before we measure it in `TestBellState`:

```qsharp
X(qubit);
let res = M(qubit);
```

Now the results (after pressing `F5`) are reversed:

```Output
Init:Zero 0s=0    1s=1000
Init:One  0s=1000 1s=0
```

However, everything we've seen so far is classical. Let's get a quantum result. All we need to do is replace the `X` gate in the previous run with an `H` or Hadamard gate. Instead of flipping the qubit all the way from 0 to 1, we will only flip it halfway. The replaced lines in `TestBellState` now look like:

```qsharp
H(qubit);
let res = M(qubit);
```

Now the results get more interesting:

```Output
Init:Zero 0s=484  1s=516
Init:One  0s=522  1s=478
```

Every time we measure, we ask for a classical value, but the qubit is halfway between 0 and 1, so we get (statistically) 0 half the time and 1 half the time. This is known as __superposition__ and gives us our first real view into a quantum state.

## Prepare entanglement

Now we'll prepare the promised [Bell state](https://en.wikipedia.org/wiki/Bell_state) and show off __entanglement__. The first thing we'll need to do is allocate 2 qubits instead of one in `TestBellState`:

```qsharp
using ((q0, q1) = (Qubit(), Qubit())) {
```

This will allow us to add a new gate (`CNOT`) before we measure  (`M`) in `TestBellState`:

```qsharp
Set(initial, q0);
Set(Zero, q1);

H(q0);
CNOT(q0, q1);
let res = M(q0);
```

We've added another `Set` operation to initialize the first qubit to make sure that it's always in the `Zero` state when we start.

We also need to reset the second qubit before releasing it.

```qsharp
Set(Zero, q0);
Set(Zero, q1);
```

The full routine now looks like this:

```qsharp
    operation TestBellState(count : Int, initial : Result) : (Int, Int) {

        mutable numOnes = 0;
        using ((q0, q1) = (Qubit(), Qubit())) {
            for (test in 1..count) {
                Set (initial, q0);
                Set (Zero, q1);

                H(q0);
                CNOT(q0,q1);
                let res = M(q0);

                // Count the number of ones we saw:
                if (res == One) {
                    set numOnes += 1;
                }
            }
            
            Set(Zero, q0);
            Set(Zero, q1);
        }

        // Return number of times we saw a |0> and number of times we saw a |1>
        return (count-numOnes, numOnes);
    }
```

If we run this, we'll get exactly the same 50-50 result we got before. However, what we're interested in is how the second qubit reacts to the first being measured. We'll add this statistic with a new version of the `TestBellState` operation:

```qsharp
    operation TestBellState(count : Int, initial : Result) : (Int, Int, Int) {
        mutable numOnes = 0;
        mutable agree = 0;
        using ((q0, q1) = (Qubit(), Qubit())) {
            for (test in 1..count) {
                Set(initial, q0);
                Set(Zero, q1);

                H(q0);
                CNOT(q0, q1);
                let res = M(q0);

                if (M(q1) == res) {
                    set agree += 1;
                }

                // Count the number of ones we saw:
                if (res == One) {
                    set numOnes += 1;
                }
            }
            
            Set(Zero, q0);
            Set(Zero, q1);
        }

        // Return number of times we saw a |0> and number of times we saw a |1>
        return (count-numOnes, numOnes, agree);
    }
```

The new return value (`agree`) keeps track of every time the measurement from the first qubit matches the measurement of the second qubit. We also have to update the host application accordingly:

#### [Python](#tab/tabid-python)

```python
import qsharp

from qsharp import Result
from Quantum.Bell import TestBellState

initials = {Result.Zero, Result.One} 

for i in initials:
    res = TestBellState.simulate(count=1000, initial=i)
    (num_zeros, num_ones, agree) = res
    print(f'Init:{i: <4} 0s={num_zeros: <4} 1s={num_ones: <4} agree={agree: <4}')
```

#### [C#](#tab/tabid-csharp)

```csharp
            using (var qsim = new QuantumSimulator())
            {
                // Try initial values
                Result[] initials = new Result[] { Result.Zero, Result.One };
                foreach (Result initial in initials)
                {
                    var res = TestBellState.Run(qsim, 1000, initial).Result;
                    var (numZeros, numOnes, agree) = res;
                    System.Console.WriteLine(
                        $"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4} agree={agree,-4}");
                }
            }
            
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
```

#### [](#tab/tabid-vs2019)

* * *

Now when we run, we get something pretty amazing:

```Output
Init:Zero 0s=499  1s=501  agree=1000
Init:One  0s=490  1s=510  agree=1000
```

Our statistics for the first qubit haven't changed (50-50 chance of a 0 or a 1), but now when we measure the second qubit, it is __always__ the same as what we measured for the first qubit. Our `CNOT` has entangled the two qubits, so that whatever happens to one of them, happens to the other. If you reversed the measurements (did the second qubit before the first), the same thing would happen. The first measurement would be random and the second would be in lock step with whatever was discovered for the first.

Congratulations, you've written your first quantum program!

## What's next?

For more information about the metrics reported and accessing the data programmatically,
take a look at the [`ResourcesEstimator` documentation](xref:microsoft.quantum.machines.resources-estimator).

To learn more about the other type of simulators and target machines provided in the Quantum Development Kit, how they work and how to use them, take a look at the [Managing quantum machines and drivers topic](xref:microsoft.quantum.machines) in the documentation.

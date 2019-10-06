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



# Tutorial: Simulate quantum circuits in Q#
Welcome to the Quantum Development Kit tutorial on setting up and simulating a basic quantum circuit. 
Having already [downloaded the QDK and set up your environment](xref:microsoft.quantum.install), you're probably eager to get started. 
In this tutorial we will explore some key features of quantum-ness while showing you the necessary components of running an application with Q#.
By the end, you will be ready to take quantum circuits from paper and run them in Q#.


## In this tutorial, you'll learn how to:

> [!div class="checklist"]
> * Define quantum operations in Q#
> * Setup the classical driver to call and simulate Q# operations
> * Simulate a full circuit from qubit allocation to measurement output
> * (maybe) Observe the simulated wavefunction of the full quantum system

Applications developed with Microsoft's Quantum Development Kit typically consists of two parts:
1. One or more quantum algorithms, implemented using the Q# quantum programming language.
2. A classical program, implemented in a classical programming language like Python or C#, 
  that serves as the main entry point and will invoke Q# operations 
  when it wants to execute a quantum algorithm.

In this tutorial we will first set up the classical driver file to call our Q# program on a target machine (in our case, the full state simulator) and display the output. 
We describe this process in both Python and C#.
Then, we will direct our attention to the Q# program itself, allocating qubits and seeing how basic gates and measurements affect our output. 
Lastly, we will show how the `DumpMachine` function can be used to print the wavefunction of our full simulated system.


## Allocate qubits and define quantum operations

The first part of this tutorial will consist of simulating single qubit "circuits" in which we instantiate a qubit, perform a single gate, and then measure it. 
We will then repeat this many times in order to get a more accurate depiction of the measurement statistics. 
The gates we will use are first none, and then the elementary 'X' and 'H' gates.


Here, we will write the Q# file that defines the circuits within operations in Q#, which can then be called and simulated by the classical driver, returning classical values to it when complete (e.g. measurement counts).
In the section below, we will write the classical driver file that calls the Q# operations, and then processes the returned classical measurement data.


In your development environment, create a Q# sharp file: `Operations.qs`. 
- To be filled with more description on the operations themselves, as well as the gates. (mention Microsoft.Quantum.Intrinsic and .Canon, perhaps link to them?)
- @anyone, is it possible or appropriate to make it annotated code in the docs itself? i.e. include annotations along the right side, as opposed to including them in the code itself as comments, because I found that jumbling everything up and making the code itself difficult to discern


```qsharp
namespace Quantum.Operations {
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Canon;

    operation Set (desired: Result, q1: Qubit) : Unit {
        if (desired != M(q1)) {
            X(q1);
        }
    }

    operation OneQubitNoGate (count : Int) : (Int, Int) {
        mutable numOnes = 0;
        using (qubit = Qubit()) {
            for (test in 1..count) {
                let res = M (qubit);
                if (res == One) {
                    set numOnes += 1;
                }
                Set(Zero, qubit);
            }
        }
        return (count-numOnes, numOnes);
    }

    operation OneQubitX (count : Int) : (Int, Int) {
        mutable numOnes = 0;
        using (qubit = Qubit()) {
            for (test in 1..count) {
                X(qubit);
                let res = M (qubit);
                if (res == One) {
                    set numOnes += 1;
                }
                Set(Zero, qubit);
            }
        }
        return (count-numOnes, numOnes);
    }

    operation OneQubitH (count : Int) : (Int, Int) {
        mutable numOnes = 0;
        using (qubit = Qubit()) {
            for (test in 1..count) {
                H(qubit);
                let res = M (qubit);
                if (res == One) {
                    set numOnes += 1;
                }
                Set(Zero, qubit);
            }
        }
        return (count-numOnes, numOnes);
    }
}
```





## Setup the classical driver


- In the section above, we defined our Q# operations, and now we will write the classical driver file that calls them and processes the returned classical measurement data. 
- While the Q# program is ubiquitous across classical host languages, the driver programs of course will vary slightly. As such, please follow the instructions in the tab corresponding to the development environment you set up.

#### [Python](#tab/tabid-python)

The driver.py file is constructed as follows: 
1. First, we import qsharp to make sure...? (@chris et al.) 
2. Then, we directly import the Q# operations which we will be directly interacting with. 
	Note that we can import directly from the `Quantum.Operations` namespace defined in our `.qs` file, and also that we do not need to import "helper" operations like `Set` which are used by other Q# operations but never called directly from our driver file. 
	Additionally, the operations must be imported individually (i.e. `from Quantum.Operations import *` or `import Quantum.Operations` will cause an error.) 
	- @chris et al., is there a more elegant way that doesn't throw errors?
3. In calling the functions, we simply use the form `<Q# function>.simulate(<args>)` to run them on the `QuantumSimulator()` target machine. 
	Here, the only argument we defined was `count`, the number of times to repeat the circuit.

> [!NOTE]
> If we wanted to call the operation on a different machine, for example the `ResourceEstimator()`, we would simply use `<Q# function>.estimate_resources(<args>)`.
> 
> - @anyone, it'd be very helpful to have and/or link-to a place where all these Python nuances are defined more clearly (I've been having to scrape through random docs and files just to figure this out)
> - for example, the fact that if we're in Python, we can use `0` and `1` to refer to the result state of a qubit, whereas in C# we use `Result.Zero` and `Result.One`. Not relevant in this tutorial specifically, but certainly useful info.

4. Upon performing the simulation, the operation calls will return values as defined in `Operations.qs`.
	In our case, these are simply tuples of our results of the form `(numberOfZeros, numberOfOnes)`, to which we assign names in standard Python fashion.
	With the resultant data in our hands and totally classical, we can do whatever we'd like with it. 
	Here, we simply print it to easily compare the effect the gates had on our measurement statistics.

Your full `driver.py` file should be this:

```python
import qsharp
from Quantum.Operations import OneQubitNoGate, OneQubitX, OneQubitH

resNoGate = OneQubitNoGate.simulate(count=100)
resX = OneQubitX.simulate(count=100)
resH = OneQubitH.simulate(count=100)

print("Measured results: (# |0>'s, # |1>'s):\n"
      "No gate: " + str(resNoGate) +"\n"
      "X gate: " + str(resX) +"\n"
      "H gate: " + str(resH))

```

Simply run the Python file, and your output should match that below.


#### [C#](#tab/tabid-csharp)

- @anyone, I'm hoping to define running the .cs file in a more general way than is described in the Quickstart. Only way I could get this to run was by using the `dotnet run` terminal command was by following those terminal based steps (creating a VS Code project), then deleting the HelloQ stuff that was automatically there, and replacing it with my .qs and .cs files. The C# code below indeed works perfectly, but I could use someone's help penning these create/run instructions.

The C# driver has four parts:
1. Construct a quantum simulator. 
	In the example, `qsim` is the simulator.
2. Compute any arguments required for the quantum algorithm. 
	In the example, `count` is fixed at a 100---the number of times the Q# operation will repeat the simulation.
3. Run the quantum algorithm. 
	Each Q# operation generates a C# class with the same name. 
	This class has a `Run` method that **asynchronously** executes the operation.
	The execution is asynchronous because execution on actual hardware will be asynchronous. 
	Because the `Run` method is asynchronous, we fetch the `Result` property; this blocks execution until the task completes and returns the result synchronously. 
4. Process the result of the operation. 
	In the example, `res` receives the result of the operation.
	Here the result is a tuple of the number of zeros (`numZeros`) and number of ones (`numOnes`) measured by the simulator. 
	This is returned as a ValueTuple in C#.
	We deconstruct the tuple to get the two fields, print the results, and wait for a keypress.


```csharp
using System;

using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.Operations
{
    class Driver
    {
        static void Main(string[] args)
        {
            using (var qsim = new QuantumSimulator())
            {
                var resNoGate = OneQubitNoGate.Run(qsim, 100).Result;
                var resX = OneQubitX.Run(qsim, 100).Result;
                var resH = OneQubitH.Run(qsim, 100).Result;
                System.Console.WriteLine(
                    $"Measured results: (# |0>'s, |1>'s):");
                System.Console.WriteLine(
                    $"No Gate: {resNoGate}");
                System.Console.WriteLine(
                    $"X Gate:  {resX}");
                System.Console.WriteLine(
                    $"H Gate:  {resH}");
            }

            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

```

- something about how to run the file goes here. 

... and your output should match that below.
The program will exit after you press a key.
***

```Output
Measured results: (# |0>'s, # |1>'s):
No gate: (100, 0)
X gate: (0, 100)
H gate: (51, 49)
```

- discuss...


## Using multiple qubits

- simply doing same as above on a register of n qubits (use n=3 in running example)
- get input as to best way to track the above counts
- CNOT to create Bell state
- maybe 3 qubit bit flip error correction code?

## (maybe)Observe wavefunction of full quantum system

- use DumpMachine




## Clean up resources

If you're not going to continue to use this application, delete
<resources> with the following steps:

1. From the left-hand menu...
2. ...click Delete, type...and then click Delete



## Next steps

- tutorial with 3 qubit bit flip error correction?
- tutorial on passing qubits between operations, more complicated development flows between driver and q#, etc.?


Advance to the next article to learn how to create...
> [!div class="nextstepaction"]
> [Next steps button](contribute-get-started-mvc.md)


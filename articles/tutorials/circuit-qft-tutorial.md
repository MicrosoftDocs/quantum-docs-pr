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
It is important to note that the Q# language is far more than a new syntax for simulating quantum circuits. 
If that were the only goal, a mere library of classical functions would have sufficed, because a quantum circuit is nothing more than the state's evolution through a specific sequence of gates---all of which can be fully expressed through matrix multiplication.
Just as higher level classical languages like C and Python allow one to go beyond simulating sequences of AND and OR gates, Q# has been specifically designed with a computational paradigm shift in mind. 
It is to be used for writing subroutines that, under the control of a classical host program and computer, execute on a separate quantum processing unit, thereby allowing developers to fully harness this classical-quantum symbiosis in full-scale quantum programs.

However, if you are new to the ideas of quantum computation, or a researcher interested in fiddling with some ideas, small scale circuit simulation can nevertheless be a valuable tool---and, of course, it is still made easy with Q#.
Having already [installed the QDK and set up your environment](xref:microsoft.quantum.install), you're probably eager to get started. 
In this tutorial, we will show you the necessary components of running an application with Q# as we set up and simulate the circuit for the quantum Fourier transform, a subroutine that is integral to many larger quantum algorithms.
By the end, you will be ready to take quantum circuits from paper and run them in Q#.


## In this tutorial, you'll learn how to:

> [!div class="checklist"]
> * Define quantum operations in Q#
> * Setup the classical host program to call and simulate Q# operations
> * Simulate a quantum circuit from qubit allocation to measurement output
> * Observe the full quantum system's simulated wavefunction at various points in our circuit

Applications developed with Microsoft's Quantum Development Kit typically consists of two parts:
1. One or more quantum algorithms, implemented using the Q# quantum programming language, and invoked by the classical host program. These consist of 
	- Q# operations: subroutines containing quantum operations, and 
	- Q# functions: classical subroutines used within the quantum algorithm.
2. A classical program, implemented in a classical programming language like Python or C#, 
  that serves as the main entry point and will invoke Q# operations 
  when it wants to execute a quantum algorithm.

In this tutorial we will first set up the Q# program, allocating qubits and applying those quantum gates which comprise the quantum Fourier transform. 
Additionally, we show how the `DumpMachine` function can be used to print the wavefunction of our full simulated system---a useful tool for debugging more complex quantum programs or simply exploring how quantum gates behave.
Then, we will direct our attention to the classical host file which calls our Q# program on a target machine (in our case, the full state simulator) and processes any returned output. 
We describe this process in both Python and C#.


## Allocate qubits and define quantum operations

The first part of this tutorial will consist of defining the Q# operation `perform_3qubit_qft`, which will perform the quantum Fourier transform on three qubits. 
Here, we will create the Q# file that defines the circuit in terms of basic gates (from the `Microsoft.Quantum.Intrinsic` namespace) within a single Q# operation. 
That operation can then be called and simulated by the classical host, returning classical values to it when complete (e.g. measurement counts). 

### Simulate the circuit without measurement

Initially, we proceed to simulate the circuit without measurement, and simply use the `DumpMachine` function to print the simulated wavefunction at various steps. 
Later, we will add measurement to the end of our circuit, and discuss some of the limitations of quantum computation that become glaringly clear.

In your development environment, create a Q# file: `Operations.qs`. 
Inside the file, we define the namespace `Quantum.Operations`, which will be accessed/imported by the classical host. 
After opening the relevant `Microsoft.Quantum.<>` namespaces to access existing Q# operations, we proceed to define the `perform_3qubit_qft` operation.
For now, the operation takes no arguments, and does not return anything. 
Later, we will modify it to return an array of measurement results, at which point `Unit` will be replaced by `Result[]`.


Within our Q# operation, we first allocate a register of three qubits with the `using` statement.
Note that the qubits are allocated in the $\ket{0}$ state, as we can verify by using `Message(<string>)` and `DumpMachine()` to print our system's current state ($\ket{000}$) to the host console.

> [!NOTE]
> The `Message(<string>)` and `DumpMachine()` functions (from `Microsoft.Quantum.Intrinsic` and `Microsoft.Quantum.Diagnostics`, respectively) both print directly to our classical host's console. 
> Just like a real quantum computation, Q# does not allow us access to the state of qubits.
> However, as `DumpMachine` prints the current state of the target machine (in this case, the full simulated state), it can provide valuable insight for debugging and learning.

Next, we apply the gates which comprise the QFT.
Q# already contains many basic quantum gates as operations in the `Microsoft.Quantum.Intrinsic` namespace, and these are no exception. 
To apply a gate to a specific qubit from a register (i.e. a single `Qubit()` from an array `Qubit[]`), we need only use standard index notation to reference the qubit.
That is, for register `qs`, we use `qs[0]` to refer to the first qubit.
Besides applying the `H` (Hadamard) gate to individual qubits, the QFT circuit consists primarily of controlled `R1` rotations. 



```qsharp
namespace Quantum.Operations {
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Diagnostics;
	open Microsoft.Quantum.Math;
    open Microsoft.Quantum.Arrays;

    operation perform_3qubit_qft () : Unit {

        using (qs = Qubit[3]) {

            Message("Initial state |000>:");
            DumpMachine();

            //QFT:
            //first qubit:
            H(qs[0]);
            Controlled R1([qs[1]], (PI()/2.0, qs[0]));
            Controlled R1([qs[2]], (PI()/4.0, qs[0]));

            //second qubit:
            H(qs[1]);
            Controlled R1([qs[2]], (PI()/2.0, qs[1]));

            //third qubit:
            H(qs[2]);

            SWAP(qs[2], qs[0]);

            //Message("After:");
            //DumpMachine();

            }

            ResetAll(qs);

        }
        return r;
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


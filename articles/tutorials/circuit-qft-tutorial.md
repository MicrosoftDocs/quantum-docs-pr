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
Here we present the full code, with the explanation and description below:

```qsharp
namespace Quantum.Operations {
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Diagnostics;
	open Microsoft.Quantum.Math;
    open Microsoft.Quantum.Arrays;

    operation perform_3qubit_qft() : Unit {

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

            Message("After:");
            DumpMachine();

            ResetAll(qs);
        }
    }
}
```

#### Namespaces to access other Q# operations
Inside the file, we define the namespace `Quantum.Operations`, which will be accessed/imported by the classical host. 
After opening the relevant `Microsoft.Quantum.<>` namespaces to access existing Q# operations, we proceed to define the `perform_3qubit_qft` operation.
For now, the operation takes no arguments, and does not return anything. 
Later, we will modify it to return an array of measurement results, at which point `Unit` will be replaced by `Result[]`.

#### Allocating qubits with `using`
Within our Q# operation, we first allocate a register of three qubits with the `using` statement.
Note that the qubits are allocated in the $\ket{0}$ state, as we can verify by using `Message(<string>)` and `DumpMachine()` to print our system's current state ($\ket{000}$) to the host console.

> [!NOTE]
> The `Message(<string>)` and `DumpMachine()` functions (from `Microsoft.Quantum.Intrinsic` and `Microsoft.Quantum.Diagnostics`, respectively) both print directly to our classical host's console. 
> Just like a real quantum computation, Q# does not allow us access to the state of qubits.
> However, as `DumpMachine` prints the current state of the target machine (in this case, the full simulated state), it can provide valuable insight for debugging and learning.

#### Applying normal and controlled gates
Next, we apply the gates which comprise the QFT.
Q# already contains many basic quantum gates as operations in the `Microsoft.Quantum.Intrinsic` namespace, and these are no exception. 
To apply a gate to a specific qubit from a register (i.e. a single `Qubit()` from an array `Qubit[]`), we need only use standard index notation to reference the qubit.
That is, for register `qs`, we use `qs[0]` to refer to the first qubit.

Besides applying the `H` (Hadamard) gate to individual qubits, the QFT circuit consists primarily of controlled `R1` rotations.
An `R1($\theta$, <qubit>)` operation in general leaves the $\ket{0}$ component of the qubit unchanged, while applying a rotation of $e^{i\theta}$ to the $\ket{1}$ component.
To define the QFT rotations in terms of pi radians, we use the `PI()` function from the `Microsoft.Quantum.Math` namespace, and divide by a `Double` (e.g. `2.0`).
Dividing by an integer `2` would throw a type error. 

> [!NOTE]
> `R1($\pi$/2)` and `R1($\pi$/4)` are equivalent to the `S` and `T` operations (also in `Microsoft.Quantum.Intrinsic`)


Q# makes it extremely easy to condition the execution of an operation upon one or multiple control qubits.
As seen below, we merely preface the call with `Controlled`, and the operation arguments change as:

* `Op(<normal args>)` --> `Controlled Op([<control qubits>], (<normal args>))`.

Note that the control qubits must be provided as an array, even if it is a single qubit.

After applying all the relevant Hadamards and controlled rotations, we need only apply a `SWAP` gate to complete the circuit.
This is necessary because the nature of the QFT outputs the qubits in reverse order, so the swaps allow for seamless integration of the QFT subroutine into larger algorithms.

#### De-allocate qubits
We then call `DumpMachine()` again to see the post-QFT state, and finally apply `ResetAll` to the qubit register to reset our qubits to $\ket{0}$ before completing the operation. 
Requiring that all de-allocated qubits be explicitly set to $\ket{0}$ is a basic feature of Q#.
If it is not performed at the end of a `using` allocation block, a runtime error will be thrown.

With the Q# file and operation complete, we move on to the classical host file.


## Setup the classical host

In the previous section, we defined our Q# operation in a `.qs` file.
Now, we must write the classical host file that calls the Q# operation, and processes any returned classical data. 
Initially, there is no returned data to process---recall that our operation defined above returns `Unit`.
Later, upon adding measurements, we will modify the Q# operation to return an array of measurement results (`Result[]`), and therefore we will also modify the host file to process these values.
While the Q# program is ubiquitous across classical host languages, the host programs of course will vary slightly. As such, please follow the instructions in the tab corresponding to the development environment you set up.

#### [Python](#tab/tabid-python)

Create a Python file titled `host.py`.
The host file is constructed as follows: 
1. First, we import the `qsharp` module, which registers the module loader for Q# interoperability. 
	This allows Q# namespaces (e.g. the `Quantum.Operations` defined above) to appear as Python modules, from which we can import Q# operations.
2. Then, import the Q# operations which we will be directly invoking---that is, we need only import the entry point into a Q# program.
	We do _not_ need to import operations like `H` and `R1`, which are called by other Q# operations but never by the classical host.
3. In simulating the Q# operations or functions, we simply use the form `<Q# callable>.simulate(<args>)` to run them on the `QuantumSimulator()` target machine. 
	For now, our operation is defined to take no arguments.

> [!NOTE]
> If we wanted to call the operation on a different machine, for example the `ResourceEstimator()`, we would simply use `<Q# function>.estimate_resources(<args>)`.
> In general, Q# operations are agnostic to the machines on which they're run.
> However, some features such as `DumpMachine` will behave differently.

4. Upon performing the simulation, the operation call will return values as defined in `Operations.qs`.
	For now there is nothing returned, but later on we will see an example of assigning and processing these values.
	With the resultant data in our hands and totally classical, we can do whatever we'd like with it. 
	Here, we simply print it to easily compare the effect the gates had on our measurement statistics.

Your full `host.py` file should be this:

```python
import qsharp
from Quantum.Operations import perform_3qubit_qft

perform_3qubit_qft.simulate()

```

Simply run the Python file, and printed in your console you should see the `Message` and `DumpMachine` outputs below. 



#### [C#](#tab/tabid-csharp)

- @anyone, I'm hoping to define running the .cs file in a more general way than is described in the Quickstart. Only way I could get this to run was by using the `dotnet run` terminal command was by following those terminal based steps (creating a VS Code project), then deleting the HelloQ stuff that was automatically there, and replacing it with my .qs and .cs files. The C# code below indeed works perfectly, but I could use someone's help penning these create/run instructions.

The C# host has four parts:
1. Construct a quantum simulator. 
	In the example, `qsim` is the simulator.
2. Compute any arguments required for the quantum algorithm. 
	For now, there are none.
3. Run the quantum algorithm. 
	Each Q# operation generates a C# class with the same name. 
	This class has a `Run` method that **asynchronously** executes the operation.
	The execution is asynchronous because execution on actual hardware will be asynchronous. 
	Because the `Run` method is asynchronous, we fetch the `Result` property; this blocks execution until the task completes and returns the result synchronously. 
4. Process the result of the operation. 
	For now, there is none.


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
                perform_3qubit_qft.Run(qsim);
            }

            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

```

- something about how to run the file...
- ... and your output should match that below.
The program will exit after you press a key.
***

```Output
Initial state |000>:
# wave function for qubits with ids (least to most significant): 0;1;2
∣0❭:	 1.000000 +  0.000000 i	 == 	******************** [ 1.000000 ]     --- [  0.00000 rad ]
∣1❭:	 0.000000 +  0.000000 i	 == 	                     [ 0.000000 ]                   
∣2❭:	 0.000000 +  0.000000 i	 == 	                     [ 0.000000 ]                   
∣3❭:	 0.000000 +  0.000000 i	 == 	                     [ 0.000000 ]                   
∣4❭:	 0.000000 +  0.000000 i	 == 	                     [ 0.000000 ]                   
∣5❭:	 0.000000 +  0.000000 i	 == 	                     [ 0.000000 ]                   
∣6❭:	 0.000000 +  0.000000 i	 == 	                     [ 0.000000 ]                   
∣7❭:	 0.000000 +  0.000000 i	 == 	                     [ 0.000000 ]                   
After:
# wave function for qubits with ids (least to most significant): 0;1;2
∣0❭:	 0.353553 +  0.000000 i	 == 	***                  [ 0.125000 ]     --- [  0.00000 rad ]
∣1❭:	 0.353553 +  0.000000 i	 == 	***                  [ 0.125000 ]     --- [  0.00000 rad ]
∣2❭:	 0.353553 +  0.000000 i	 == 	***                  [ 0.125000 ]     --- [  0.00000 rad ]
∣3❭:	 0.353553 +  0.000000 i	 == 	***                  [ 0.125000 ]     --- [  0.00000 rad ]
∣4❭:	 0.353553 +  0.000000 i	 == 	***                  [ 0.125000 ]     --- [  0.00000 rad ]
∣5❭:	 0.353553 +  0.000000 i	 == 	***                  [ 0.125000 ]     --- [  0.00000 rad ]
∣6❭:	 0.353553 +  0.000000 i	 == 	***                  [ 0.125000 ]     --- [  0.00000 rad ]
∣7❭:	 0.353553 +  0.000000 i	 == 	***                  [ 0.125000 ]     --- [  0.00000 rad ]

```

- add description of DumpMachine output from https://docs.microsoft.com/en-us/quantum/techniques/testing-and-debugging?view=qsharp-preview&tabs=tabid-vs2019#dump-functions

- add full state LaTeX description of what we're seeing


## Adding Measurements

- more interesting input to QFT than $\ket{000}$, done by adding Hadamards on first and third qubits before QFT
	- observe the DumpMachine output
- add measurements --> discussion of limitation: processing $2^3$ bits but can't access them directly. 
	with measuring, each shot only yields the 3 bits corresponding to each qubit's measurement
- add classical logic within Q# to aggregate measurement counts over 1000 shots
	- see that the amplitude statistics begin to appear, but it's hardly efficient anymore. 
	hence why the QFT likely won't replace classcial FFT, but rather has an important place as a subroutine
	--> link to Phase Estimation page



## Clean up resources

If you're not going to continue to use this application, delete
<resources> with the following steps:

1. ...


## Next steps

- tutorial on passing qubits between operations, more complicated development flows between driver and q#, etc.?


Advance to the next article to learn how to create...
> [!div class="nextstepaction"]
> [Next steps button](contribute-get-started-mvc.md)


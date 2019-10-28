---
title: Tutorial: Addressing individual qubits in a quantum program | Microsoft Docs
description: Step-by-step tutorial on writing and simulating a quantum program which operates at the individual qubit level
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.topic: tutorial 
ms.date: 10/06/2019
uid: microsoft.quantum.circuit-tutorial
---



# Tutorial: Write and simulate qubit-level programs in Q#
Welcome to the Quantum Development Kit tutorial on writing and simulating a basic quantum program operating on individual qubits. 

Although the power of quantum computation is revealed at the higher level of "what a quantum algorithm does", we should remember that even the most complex quantum programs are built upon operations occuring at the level of individual qubits.
The flexibility of Q# allows users to approach quantum systems from any such level of abstraction, and in this tutorial we dive into the qubits themselves.

This low-level view of quantum information processing is often desribed in terms of "[quantum circuits](xref:microsoft.quantum.concepts.circuits)," which represent the sequential application of gates to specific qubits of a system.

Specifically, we take a look under the hood of the [quantum Fourier transform](https://en.wikipedia.org/wiki/Quantum_Fourier_transform), a subroutine that is integral to many larger quantum algorithms.


## Pre-requisites

* [Install](xref:microsoft.quantum.install) the Quantum Development Kit using your preferred language and development environment
* If you already have the QDK installed, make sure you have [updated](xref:microsoft.quantum.update) to the latest version


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
2. A classical program, implemented in a classical programming language like Python or C#, that serves as the main entry point and will invoke Q# operations when it wants to execute a quantum algorithm.

## Allocate qubits and define quantum operations

The first part of this tutorial will consist of defining the Q# operation `perform_3qubit_qft`, which will perform the quantum Fourier transform on three qubits. 

The [`DumpMachine`](xref:microsoft.quantum.diagnostics.dumpmachine) function is a useful tool for debugging complex quantum programs, as it prints the simulated full wavefunction of the quantum system whenever called. 
Of course, within smaller programs we can also use it to simply observe how quantum states evolve across an operation---precisely what we will do with the quantum Fourier transform.

In your development environment, create a Q# file: `Operations.qs`.
We will walk you through the components of the file step-by-step, and you can also find the code as a full block below.

### Namespaces to access other Q# operations
Inside the file, we first define the namespace `Quantum.Operations` which will be accessed/imported by the classical host, and then open the relevant `Microsoft.Quantum.<>` namespaces so our operation can access existing Q# operations:

```qsharp
namespace Quantum.Operations {
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Diagnostics;
	open Microsoft.Quantum.Math;
    open Microsoft.Quantum.Arrays;

	// operations go here
}
```

### Define operations with arguments and returns
Next, we define the `perform_3qubit_qft` operation:

```qsharp
    operation perform_3qubit_qft() : Unit {
		// do stuff
	}
```
For now, the operation takes no arguments and does not return anything. 
Later, we will modify it to return an array of measurement results, at which point `Unit` will be replaced by `Result[]`. 

### Allocate qubits with `using`
Within our Q# operation, we first allocate a register of three qubits with the `using` statement:

```qsharp
        using (qs = Qubit[3]) {

            Message("Initial state |000>:");
            DumpMachine();

		}
```

With `using`, the qubits are allocated in the $\ket{0}$ state, which we verify with [`Message(<string>)`](xref:microsoft.quantum.intrinsic.message) and [`DumpMachine()`](xref:microsoft.quantum.diagnostics.dumpmachine) to print the system's current state ($\ket{000}$) to the host console.

> [!NOTE]
> The `Message(<string>)` and `DumpMachine()` functions (from [`Microsoft.Quantum.Intrinsic`](xref:microsoft.quantum.intrinsic) and [`Microsoft.Quantum.Diagnostics`](xref:microsoft.quantum.diagnostics), respectively) both print directly to our classical host's console. 
> Just like a real quantum computation, Q# does not allow us access to the state of qubits.
> However, as `DumpMachine` prints the target machine's current state, it can provide valuable insight for debugging and learning in conjunction with the full state simulator.


### Applying single-qubit and controlled gates

Next, we apply the gates which comprise the operation itself (see the circuit diagram and explanation for the three-qubit example [here](https://en.wikipedia.org/wiki/Quantum_Fourier_transform#Example).
Q# already contains many basic quantum gates as operations in the `Microsoft.Quantum.Intrinsic` namespace, and these are no exception. 
To apply an operation to a specific qubit from a register (i.e. a single `Qubit()` from an array `Qubit[]`), we need only use standard index notation.
So, applying the [`H`](microsoft.quantum.intrinsic.h) (Hadamard) to the first qubit of our register `qs` takes the form:

```qsharp
            H(qs[0]);
```

Besides applying the `H` (Hadamard) gate to individual qubits, the QFT circuit consists primarily of controlled [`R1`](microsoft.quantum.intrinsic.r1) rotations.
An `R1(θ, <qubit>)` operation in general leaves the $\ket{0}$ component of the qubit unchanged, while applying a rotation of $e^{iθ}$ to the $\ket{1}$ component.


#### Controlled operations

Q# makes it extremely easy to condition the execution of an operation upon one or multiple control qubits.
In general, we merely preface the call with `Controlled`, and the operation arguments change as:

> `Op(<normal args>)` --> `Controlled Op([<control qubits>], (<normal args>))`.

Note that the control qubits must be provided as an array, even if it is a single qubit.
So, we call the `R1` gates acting on the first qubit (and controlled by the second third) as:

```qsharp
            Controlled R1([qs[1]], (PI()/2.0, qs[0]));
            Controlled R1([qs[2]], (PI()/4.0, qs[0]));
```

Note that we use the `PI()` function from the `Microsoft.Quantum.Math` namespace to define the rotations in terms of pi radians.
Additionally, we divide by a `Double` (e.g. `2.0`) because dividing by an integer `2` would throw a type error. 

> [!NOTE]
> `R1(π/2)` and `R1(π/4)` are equivalent to the `S` and `T` operations (also in `Microsoft.Quantum.Intrinsic`)


After applying the relevant Hadamards and controlled rotations to the second and third qubits:

```qsharp
            //second qubit:
            H(qs[1]);
            Controlled R1([qs[2]], (PI()/2.0, qs[1]));

            //third qubit:
            H(qs[2]);
```

we need only apply a [`SWAP`](microsoft.quantum.intrinsic.swap) gate to complete the circuit:

```qsharp
            SWAP(qs[2], qs[0]);
```

This is necessary because the nature of the quantum Fourier transform outputs the qubits in reverse order, so the swaps allow for seamless integration of the subroutine into larger algorithms.


#### De-allocate qubits
We then call [`DumpMachine()`](xref:microsoft.quantum.diagnostics.dumpmachine) again to see the post-operation state, and finally apply [`ResetAll`](microsoft.quantum.intrinsic.resetall) to the qubit register to reset our qubits to $\ket{0}$ before completing the operation:

```qsharp
            Message("After:");
            DumpMachine();

            ResetAll(qs);
```

Requiring that all de-allocated qubits be explicitly set to $\ket{0}$ is a basic feature of Q#.
If it is not performed at the end of a `using` allocation block, a runtime error will be thrown.

Your full Q# file should now look like this:

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


With the Q# file and operation complete, it is ready to be called and simulated by the classical host.

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


To be filled:

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


## Next steps

- tutorial on passing qubits between operations, more complicated development flows between driver and q#, etc.?



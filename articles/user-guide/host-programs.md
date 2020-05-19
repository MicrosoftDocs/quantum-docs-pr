---
title: Run Q# with standalone applications or host programs
description: Overview of the different ways to run Q# programs. Command line, Q# Jupyter Notebooks, and classical host programs in Python a .NET language.
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.date: 05/15/2020
ms.topic: article
uid: microsoft.quantum.guide.host-programs
---

# Run Q# with standalone applications or host programs

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
For the sake of brevity we refer primarily to Q# *operations* on this page, however all of the concepts discussed work in the same manner for Q# *functions*, as well as any user-defined Q# types. 

### Operation defined in a Q# file

The operation is precisely what's called and run by Q#.
However, it requires a few more additions to comprise a full `*.qs` Q# file.

All Q# types and callables are defined within *namespaces*, which the compiler can then open individually 

Firstly, the [`H`](xref:microsoft.quantum.intrinsic.h) and [`MResetZ`](xref:microsoft.quantum.measurement.mresetz) actually belong to the [Q# Standard Libraries](xref:microsoft.quantum.qsharplibintro).
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
<img src="./images/general_execution_model.png" alt="Q# program execution diagram" width="400">

Firstly, the specific operation to be executed has access to any other callables and types defined in the same namespace.
Thanks to `open` statements, it can also access those from any of the [Q# libraries](xref:microsoft.quantum.libraries). 

The operation itself is then executed on a *[target machine](xref:microsoft.quantum.machines)*.
In the future, one such target machine will be a real quantum computer, but there are currently multiple simulators available, each with a particular use.
For our purposes here, the most useful target machine is instance of the full-state simulator, `QuantumSimulator`, which calculates the program's behavior as if it were being executed on a noise-free quantum computer.

So far, we've described what happens when a specific Q# operation is being executed.
Regardless of whether Q# is used in a standalone application or with a host program, this general process is more or less the same---hence the QDK's flexibility.
The differences between the methods therefore reveal themselves in *how* that Q# operation is called to be executed, and in what manner any results are returned.

First, we discuss how this done with the Q# standalone application from the command line, and then proceed to using Python and C# host programs.
We reserve the standalone application of Q# Jupyter Notebooks for last, because unlike the first three, it does not actually require a Q# file.


## Q# from the command line
One of the easiest ways to get started writing Q# programs is to avoid worrying about separate files and a second language altogether.
Using Visual Studio Code or Visual Studio with the QDK extension allows for a seamless work flow in which we run Q# operations from only a single Q# file.

For this, we will ultimately invoke the program's execution by entering
```bash
dotnet run
```
in the command line.
Note that the terminal's directory location needs to be the same as the Q# file, so we recommend simply using the integrated terminal in VS Code or Visual Studio.

### Add entry point to Q# file
Of course, most Q# files will contain more than one operation.
So, we need to let the compiler know *which* operation to execute when we provide the `dotnet run` command.

This is done with a simple change to the Q# file itself: add a line with `@EntryPoint()` directly preceding the operation.

Our file from above would therefore become
```qsharp
namespace NamespaceName {
    open Microsoft.Quantum.Intrinsic;     // for the H operation
    open Microsoft.Quantum.Measurement;   // for MResetZ

	@EntryPoint()
    operation MeasureSuperposition() : Result {
        using (q = Qubit()) { 
            H(q);
            return MResetZ(q);
        }
    }
}
```

Now, a call of `dotnet run` from the command line leads to `MeasureSuperposition` being run, and the returned value is then printed directly to the terminal.
So, you will see either `One` or `Zero` printed. 

Note that it doesn't matter if you have more operations defined below it, only `MeasureSuperposition` will be run.
Additionally, it's no problem if your operation includes [documentation comments](xref:microsoft.quantum.guide.filestructure#documentation-comments) before the operation declaration, the `@EntryPoint()` attribute can be simply placed above them.

### Operation arguments

So far, we've only considered an operation that takes no arguments.
Suppose we wanted to perform a similar operation, but on multiple qubits---the number of which is provided as an argument.
Such an operation could be written as
```qsharp
    operation MeasureSuperpositionArray(n : Int) : Result[] {
        mutable resultArray = new Result[n];     // instantiate a length n array for the measurement Results 
        using (qubits = Qubit[n]) {              // allocate a register of n qubits
            ApplyToEach( H , qubits);            // apply H to each qubit in the register (from Microsoft.Quantum.Canon)
            set resultArray = MultiM(qubits);    // measure the array of qubits
            ResetAll(qubits);                    // reset all the qubits
        }
        return resultArray;
    }
```
where the returned value is an array of the measurement results.
Note that the [`ApplyToEach`](xref:microsoft.quantum.canon.applytoeach) operation is in the `Microsoft.Quantum.Canon` namespace, requiring another `open` statement with the others.

If we move the `@EntryPoint()` to precede this new operation (note there can only be one such line in a file), attempting to run it with simply `dotnet run` results in a helpful error message.
This message indicates what additional command line options are required, and how to express them.

The general format for the command line is actually `dotnet run [options]`, and operation arguments are provided there.
In this case, the argument `n` is missing, and it shows that we need to provide the option `-n <n>`. 
To run `MeasureSuperpositionArray` for `n=4` qubits, we therefore use

```bash
dotnet run -n 4
```

yielding an output similar to

```bash
[Zero,One,One,One]
```

This of course extends to multiple arguments.

The error message also provides other options which can be used, including how to change the target machine.

### Different target machines

From the output of our operation thus far, it's clear that the default target machine from the command line is the full-state quauntum simulator, `QuantumSimulator`.
However, we can instruct the operation to be run on a specific target machine with the option `--simulator` (or the shorthand `-s`).

For example, we could run it on [`ResourcesEstimator`](xref:microsoft.quantum.machines.resources-estimator):

```bash
dotnet run -n 4 -s ResourcesEstimator
```

The printed output is then

```bash
Metric          Sum
CNOT            0
QubitClifford   4
R               0
Measure         8
T               0
Depth           0
Width           4
BorrowedWidth   0
```

Note that the [`Reset`](xref:microsoft.quantum.intrinsic.reset) and [`ResetAll`](xref:microsoft.quantum.intrinsic.resetall) operations utilize measurement to reset the qubits to $\ket{0}$, hence the reported 8 measurements as opposed to the 4 which yield the actual results.
Details on what these metrics indicate can be found [here](xref:microsoft.quantum.machines.resources-estimator#metrics-reported).

### Command line execution summary
<br/>
<img src="./images/command_line_diagram.png" alt="Q# program from command line" width="700">


## Q# with host programs

With our Q# file in hand, an alternative to calling an operation directly from the command line is to use a *host program* in another classical language. 
Specifically, this can be done with either Python or a .NET language such as C# or F# (for the sake of brevity we will only detail C# here).
A little more setup is required to enable the interoperability, but those details can be found in the [install guides](xref:microsoft.quantum.install).

In a nutshell, the situation now includes a host program file (e.g. `*.py` or `*.cs`) in the same location as our Q# file.
It's now the *host* program that gets run, and in the course of its execution it calls specific Q# operations from the Q# file.
The core of the interoperability is based on the Q# compiler making the contents of the Q# file accessible to the host program so that they can be called.

One of the main benefits of using a host program is that the classical data returned by the Q# program can then be further processed in the host language.
This could consist of some advanced data processing (e.g. something that can't be performed internally in Q#), and then calling further Q# actions based on those results, or something as simple as plotting the Q# results.

The general scheme is shown here, and we discuss the specific implementations for Python and C# below. 
A sample using an F# host program can be found at the [.NET interoperability samples](https://github.com/microsoft/Quantum/tree/master/samples/interoperability/dotnet).

<br/>
<img src="./images/host_program_diagram.png" alt="Q# program from a host program" width="700">

> [!NOTE]
> The `@EntryPoint()` attribute used for Q# command line applications cannot be used with host programs.
> An error will be raised if it is present in the Q# file being called by a host. 

To work with different host programs, there are no changes required to a `*.qs` Q# file.
The following host program implementations all work with the same Q# file:

```qsharp
namespace NamespaceName {
    open Microsoft.Quantum.Intrinsic;     // for the H operation
    open Microsoft.Quantum.Measurement;   // for MResetZ and MultiM
	open Microsoft.Quantum.Canon;         // for ApplyToEach

    operation MeasureSuperposition() : Result {
        using (q = Qubit()) { 
            H(q);
            return MResetZ(q);
        }
    }

    operation MeasureSuperpositionArray(n : Int) : Result[] {
        mutable resultArray = new Result[n];
        using (qubits = Qubit[n]) {
            ApplyToEach( H , qubits);
            set resultArray = MultiM(qubits);
            ResetAll(qubits);
        }
        return resultArray;
    }
}
```

Select the tab corresponding to your host language of interest.

### [Python](#tab/tabid-python)
A python host file is constructed as follows:
1. Import the `qsharp` module, which registers the module loader for Q# interoperability. 
    This allows Q# namespaces to appear as Python modules, from which we can import Q# operations.

2. Import those Q# operations which we will directly invoke---in this case, `MeasureSuperposition` and `MeasureSuperpositionArray`.
    ```python
    import qsharp
    from NamespaceName import MeasureSuperposition, MeasureSuperpositionArray
    ```
    Note that with the `qsharp` module imported, you can also import operations directly from the Q# library namespaces.

3. Among any other Python code, you can now call those operations on specific target machines, and assign their returns to variables (if they return a value) for further use.

#### Specifying target machines
Calling an operation to be run on a specific target machine is done via different Python methods on the imported operation.
For example, `.simulate(<args>)`, uses the `QuantumSimulator` to run the operation, whereas `.estimate_resources(<args>)` does so on the `ResourcesEstimator`.

#### Arguments
Arguments for the Q# callable should be provided in the form of a keyword argument, where the keyword is the argument name in the callable definition.
That is, `MeasureSuperpositionArray.simulate(n=4)` is valid, whereas `MeasureSuperpositionArray.simulate(4)` would throw an error.

Therefore, the Python host program 

```python
import qsharp
from NamespaceName import MeasureSuperposition, MeasureSuperpositionArray

single_qubit_result = MeasureSuperposition.simulate()
single_qubit_resources = MeasureSuperposition.estimate_resources()

multi_qubit_result = MeasureSuperpositionArray.simulate(n=4)
multi_qubit_resources = MeasureSuperpositionArray.estimate_resources(n=4)

print('Single qubit:')
print(single_qubit_result)
print(single_qubit_resources)

print('\nMultiple qubits:')
print(multi_qubit_result)
print(multi_qubit_resources)
```

results in an output like the following:

```python
Single qubit:
1
{'CNOT': 0, 'QubitClifford': 1, 'R': 0, 'Measure': 1, 'T': 0, 'Depth': 0, 'Width': 1, 'BorrowedWidth': 0}

Multiple qubits:
[1, 1, 0, 0]
{'CNOT': 0, 'QubitClifford': 4, 'R': 0, 'Measure': 8, 'T': 0, 'Depth': 0, 'Width': 4, 'BorrowedWidth': 0}
```

### [C#](#tab/tabid-csharp)

A C# host program has multiple components, and works very closely with some components of the QDK, such as the simulators, which are also built on the .NET language.

The Q# compiler works here by generating an equivalently named C# namespace from the Q# namespace in our Q# file.
It further generates an equivalently named C# class for each of the Q# callables or types defined therein.

First, we make any classes used in our host program available with `using` statements:

```csharp
using System;
using Microsoft.Quantum.Simulation.Simulators;    // contains the target machines, e.g. QuantumSimulator
using NamespaceName;                              // make the Q# namespace available
```

Next, we declare our C# namespace, a few other bits and pieces (see the full code block below), and then any classical programming we would like (e.g. computing arguments for the Q# operations).
The latter isn't necessary in our case, but an example of such usage can be found at the  [.NET interoperability sample](https://github.com/microsoft/Quantum/tree/master/samples/interoperability/dotnet).

#### Target machines

Getting back to Q#, we must create an instance of whatever target machine we will execute our operations on.

```csharp
            using var sim = new QuantumSimulator();
```

Using other target machines is as simple as instantiating a different one, although processing the returns could require different action.
For an example, you can check out how to use the [`ResourceEstimator` with C#](xref:microsoft.quantum.machines.resources-estimator).

Each C# class generated from the Q# operations have a `Run` method, the first argument of which must be the target machine instance.
So, to run `MeasureSuperposition` on the `QuantumSimulator`, we use `MeasureSuperposition.Run(sim)`.
The returned results can then be assigned to variables in C# by fetching the `Result` property:

```csharp
            var single_qubit_result = MeasureSuperposition.Run(sim).Result;
```

> [!NOTE]
> If the Q# operation does not have any returns (i.e. has return type `Unit`), use the `.Wait()` method call instead of `.Result`.
> The `Run` method is actually executed asynchronously, because this will be the case for real quantum hardware.
> Therefore the `Wait()` method blocks further execution until the task completes.

#### Arguments

Any arguments to the Q# operation are simply passed as additional arguments afer the target machine.
Hence the results of `MeasureSuperpositionArray` on `n=4` qubits would fetched via 

```csharp
            var multi_qubit_result = MeasureSuperpositionArray.Run(sim, 4).Result;
```

A full C# host program could thus look like

```csharp
using System;
using Microsoft.Quantum.Simulation.Simulators;
using NamespaceName;

namespace host
{
    class Program
    {
        static void Main(string[] args)
        {
            using var sim = new QuantumSimulator();

            var single_qubit_result = MeasureSuperposition.Run(sim).Result;
            var multi_qubit_result = MeasureSuperpositionArray.Run(sim, 4).Result;

            Console.WriteLine($"Single qubit result: {single_qubit_result}");
            Console.WriteLine($"Multiple qubits result: {multi_qubit_result}");
        }
    }
}
```

At the location of the C# file, the host program can be run from the command line by entering

```bash
dotnet run
```

and in this case you will see output written to the console similar to 

```bash
Single qubit result: Zero
Multiple qubits result: [One,One,Zero,Zero]
```

> [!NOTE]
> Due to the compiler's interoperability with namespaces, we could alternatively make our Q# operations available without the `using NamespaceName;` statement, and simply matching the C# namespace title to it.
> That is, replacing `namespace host` with `namespace NamespaceName`.

***

## Q# Jupyter Notebooks
Q# Jupyter Notebooks make use of the IQ# kernel, which allows you to define, compile, and run Q# operations in a single notebook---all alongside instructions, notes, and other content.
This means that while it is possible to import and use the contents of `*.qs` Q# files, they are not necessary in the execution model.

Here, we will detail how to run the Q# operations defined above, but another good introduction to using Q# Jupyter Notebooks is provided at [Intro to Q# and Jupyter Notebook](https://github.com/microsoft/Quantum/blob/master/samples/getting-started/intro-to-iqsharp/Notebook.ipynb).

### Defining operations

In a Q# Jupyter Notebook, you enter Q# code just as we would from inside the namespace of a Q# file.

So, we can enable access to operations from the [Q# standard libraries](xref:microsoft.quantum.qsharplibintro) with `open` statements for their respective namespaces.
Upon running a cell with such a statement, the definitions from those namespaces are available throughout the workspace.

> [!NOTE]
> Operations from [Microsoft.Quantum.Intrinsic](xref:microsoft.quantum.intrinsic) and [Microsoft.Quantum.Canon](xref:microsoft.quantum.canon) (e.g. [`H`](xref:microsoft.quantum.intrinsic.h) and [`ApplyToEach`](xref:microsoft.quantum.canon.applytoeach)) are automatically available in Q# Jupyter Notebooks.

Similarly, defining operations requires only writing the Q# code and running the cell.

<img src="./images/jupyter_op_def_crop.png" alt="Jupyter cell defining Q# operations" width="600">

The output then lists those operations, which can then be called from future cells.

### Target machines

The functionality to run operations on specific target machines is provided via [IQ# Magic Commands](xref:microsoft.quantum.guide.quickref.iqsharp).
For example, `%simulate` makes use of the `QuantumSimulator`, and `%estimate` uses the `ResourcesEstimator`:

<img src="./images/jupyter_no_args_sim_est_crop.png" alt="Simulate and estimate resources Jupyter cell" width="500">

### Arguments

Currently the execution magic commands can only be used with operations that take no arguments. 
So, to run `MeasureSuperpositionArray`, we need to define a "wrapper" operation which then calls the operation with the arguments:

<img src="./images/jupyter_wrapper_def_sim_crop.png" alt="Wrapper function and simulate Jupyter cell" width="550">

This operation can of course be used similarly with `%estimate` and other execution commands.


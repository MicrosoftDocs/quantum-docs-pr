---
title: Ways to run a Q# program
description: Overview of the different ways to run Q# programs. From the command prompt, Q# Jupyter Notebooks, and classical host programs in Python or a .NET language.
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.date: 05/15/2020
ms.topic: article
uid: microsoft.quantum.guide.host-programs
no-loc: ['Q#', '$$v']
---

# Ways to run a Q# program

One of the Quantum Development Kit's greatest strengths is its flexibility across platforms and development environments.
However, this also means that new Q# users may find themselves confused or overwhelmed by the numerous options found in the [install guide](xref:microsoft.quantum.install).
On this page, we explain what happens when a Q# program is run, and compare the different ways in which users can do so.

A primary distinction is that Q# can be run:
- as a standalone application, where Q# is the only language involved and the program is invoked directly. Two methods actually fall in this category:
  - the command-line interface
  - Q# Jupyter Notebooks
- with an additional *host program*, written in Python or a .NET language (e.g. C# or F#), which then invokes the program and can further process returned results.

To best understand these processes and their differences, we consider a simple Q# program and compare the ways it can be executed.

## Basic Q# program

A basic quantum program might consist of preparing a qubit in an equal superposition of states $\ket{0}$ and $\ket{1}$, measuring it, and returning the result, which will be randomly either one of these two states with equal probability.
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
Hence, you can write an operation of the following form:
```qsharp
    operation MeasureSuperposition() : Result {
        using (q = Qubit()) {
            H(q);
            return MResetZ(q);
        }
    }
```
You have defined an operation, `MeasureSuperposition`, which takes no inputs and returns a value of type [Result](xref:microsoft.quantum.guide.types).

While the examples on this page only consist of Q# *operations*, all of the concepts we will discuss pertain equally to Q# *functions*, and therefore we refer to them collectively as *callables*. 
Their differences are discussed at [Q# basics: operations and functions](xref:microsoft.quantum.guide.basics#q-operations-and-functions), and more details on defining them can be found at [Operations and functions](xref:microsoft.quantum.guide.operationsfunctions).

### Callable defined in a Q# file

The callable is precisely what's called and run by Q#.
However, it requires a few more additions to comprise a full `*.qs` Q# file.

All Q# types and callables (both those you define and those intrinsic to the language) are defined within *namespaces*, which provide each a full name that can then be referenced.

For example, the [`H`](xref:microsoft.quantum.intrinsic.h) and [`MResetZ`](xref:microsoft.quantum.measurement.mresetz) operations are found in the [`Microsoft.Quantum.Instrinsic`](xref:microsoft.quantum.intrinsic) and [`Microsoft.Quantum.Measurement`](xref:microsoft.quantum.measurement) namespaces (part of the [Q# Standard Libraries](xref:microsoft.quantum.qsharplibintro)).
As such, they can always be called via their *full* names, `Microsoft.Quantum.Intrinsic.H(<qubit>)` and `Microsoft.Quantum.Measurement.MResetZ(<qubit>)`, but always doing this would lead to very cluttered code.

Instead, `open` statements allow callables to be referenced with more concise shorthand, as we've done in the operation body above.
The full Q# file containing our operation would therefore consist of defining our own namespace, opening the namespaces for those callables our operation uses, and then our operation:

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

> [!NOTE]
> Namespaces can also be *aliased* when opened, which can be helpful if callable/type names in two namespaces conflict.
> For example, we could instead use `open Microsoft.Quantum.Instrinsic as NamespaceWithH;` above, and then call `H` via `NamespaceWithH.H(<qubit>)`.

> [!NOTE]
> One exception to all of this is the [`Microsoft.Quantum.Core`](xref:microsoft.quantum.core) namespace, which is always automatically opened.
> Therefore, callables like [`Length`](xref:microsoft.quantum.core.length) can always be used directly.

### Execution on target machines

Now the general execution model of a Q# program becomes clear.

<br/>
<img src="../media/hostprograms_general_execution_model.png" alt="Q# program execution diagram" width="400">

Firstly, the specific callable to be executed has access to any other callables and types defined in the same namespace.
It also access those from any of the [Q# libraries](xref:microsoft.quantum.libraries), but those must be referenced either via their full name, or through the use of `open` statements described above.

The callable itself is then executed on a *[target machine](xref:microsoft.quantum.machines)*.
Such target machines can be actual quantum hardware or the multiple simulators available as part of the QDK.
For our purposes here, the most useful target machine is an instance of the [full-state simulator](xref:microsoft.quantum.machines.full-state-simulator), `QuantumSimulator`, which calculates the program's behavior as if it were being executed on a noise-free quantum computer.

So far, we've described what happens when a specific Q# callable is being executed.
Regardless of whether Q# is used in a standalone application or with a host program, this general process is more or less the same---hence the QDK's flexibility.
The differences between the different ways of calling into the Quantum Development Kit therefore reveal themselves in *how* that Q# callable is called to be executed, and in what manner any results are returned.
More specifically, the differences revolve around 
1. indicating which Q# callable is to be executed,
2. how potential callable arguments are provided,
3. specifying the target machine on which to execute it, and
4. how any results are returned.

First, we discuss how this is done with the Q# standalone application from the command prompt, and then proceed to using Python and C# host programs.
We reserve the standalone application of Q# Jupyter Notebooks for last, because unlike the first three, it's primary functionality does not center around a local Q# file.

> [!NOTE]
> Although we don't illustrate it in these examples, one commonality between the execution methods is that any messages printed from inside the Q# program (by way of [`Message`](xref:microsoft.quantum.intrinsic.message) or [`DumpMachine`](xref:microsoft.quantum.diagnostics.dumpmachine), for example) will typically always be printed to the respective console.

## Q# from the command prompt
One of the easiest ways to get started writing Q# programs is to avoid worrying about separate files and a second language altogether.
Using Visual Studio Code or Visual Studio with the QDK extension allows for a seamless work flow in which we run Q# callables from only a single Q# file.

For this, we will ultimately invoke the program's execution by entering
```dotnetcli
dotnet run
```
at the command prompt.
The simplest workflow is when the terminal's directory location is the same as the Q# file, which can be easily handled alongside Q# file editing by using the integrated terminal in VS Code, for example.
However, the [`dotnet run` command](https://docs.microsoft.com/dotnet/core/tools/dotnet-run) accepts numerous options, and the program can also be run from a different location by simply providing `--project <PATH>` with the location of the Q# file.


### Add entry point to Q# file

Most Q# files will contain more than one callable, so naturally we need to let the compiler know *which* callable to execute when we provide the `dotnet run` command.
This is done with a simple change to the Q# file itself: 
    - add a line with `@EntryPoint()` directly preceding the callable.

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

Now, a call of `dotnet run` from the command prompt leads to `MeasureSuperposition` being run, and the returned value is then printed directly to the terminal.
So, you will see either `One` or `Zero` printed. 

Note that it doesn't matter if you have more callables defined below it, only `MeasureSuperposition` will be run.
Additionally, it's no problem if your callable includes [documentation comments](xref:microsoft.quantum.guide.filestructure#documentation-comments) before its declaration, the `@EntryPoint()` attribute can be simply placed above them.

### Callable arguments

So far, we've only considered an operation that takes no inputs.
Suppose we wanted to perform a similar operation, but on multiple qubits---the number of which is provided as an argument.
Such an operation could be written as
```qsharp
    operation MeasureSuperpositionArray(n : Int) : Result[] {
        using (qubits = Qubit[n]) {              // allocate a register of n qubits
            ApplyToEach(H, qubits);              // apply H to each qubit in the register
            return ForEach(MResetZ, qubits);     // perform MResetZ on each qubit, returns the resulting array
        }
    }
```
where the returned value is an array of the measurement results.
Note that [`ApplyToEach`](xref:microsoft.quantum.canon.applytoeach) and [`ForEach`](xref:microsoft.quantum.arrays.foreach) are in the [`Microsoft.Quantum.Canon`](xref:microsoft.quantum.canon) and [`Microsoft.Quantum.Arrays`](xref:microsoft.quantum.arrays) namespaces, requiring additional `open` statements for each.

If we move the `@EntryPoint()` attribute to precede this new operation (note there can only be one such line in a file), attempting to run it with simply `dotnet run` results in an error message which indicates what additional command-line options are required, and how to express them.

The general format for the command line is actually `dotnet run [options]`, and callable arguments are provided there.
In this case, the argument `n` is missing, and it shows that we need to provide the option `-n <n>`. 
To run `MeasureSuperpositionArray` for `n=4` qubits, we therefore use

```dotnetcli
dotnet run -n 4
```

yielding an output similar to

```output
[Zero,One,One,One]
```

This of course extends to multiple arguments.

> [!NOTE]
> Argument names defined in `camelCase` are slightly altered by the compiler to be accepted as Q# inputs. 
> For example, if instead of `n`, we used the name `numQubits` above, then this input would be provided in the command line via `--num-qubits 4` instead of `-n 4`.

The error message also provides other options which can be used, including how to change the target machine.

### Different target machines

As the outputs from our operations thus far have been the expected results of their action on real qubits, it's clear that the default target machine from the command line is the full-state quantum simulator, `QuantumSimulator`.
However, we can instruct callables to be run on a specific target machine with the option `--simulator` (or the shorthand `-s`).

For example, we could run it on [`ResourcesEstimator`](xref:microsoft.quantum.machines.resources-estimator):

```dotnetcli
dotnet run -n 4 -s ResourcesEstimator
```

The printed output is then

```output
Metric          Sum
CNOT            0
QubitClifford   4
R               0
Measure         4
T               0
Depth           0
Width           4
BorrowedWidth   0
```

For details on what these metrics indicate, see [Resource estimator: metrics reported](xref:microsoft.quantum.machines.resources-estimator#metrics-reported).

### Command line execution summary
<br/>
<img src="../media/hostprograms_command_line_diagram.png" alt="Q# program from command line" width="700">

### Non-Q# `dotnet run` options

As we briefly mentioned above with the `--project` option, the [`dotnet run` command](https://docs.microsoft.com/dotnet/core/tools/dotnet-run) also accepts options unrelated to the Q# callable arguments.
If providing both kinds of options, the `dotnet`-specific options must be provided first, followed by a delimeter `--`, and then the Q#-specific options.
For example, specifiying a path along with a number qubits for the operation above would be executed via `dotnet run --project <PATH> -- -n <n>`.

## Q# with host programs

With our Q# file in hand, an alternative to calling an operation or function directly from the command prompt is to use a *host program* in another classical language. 
Specifically, this can be done with either Python or a .NET language such as C# or F# (for the sake of brevity we will only detail C# here).
A little more setup is required to enable the interoperability, but those details can be found in the [install guides](xref:microsoft.quantum.install).

In a nutshell, the situation now includes a host program file (e.g. `*.py` or `*.cs`) in the same location as our Q# file.
It's now the *host* program that gets run, and in the course of its execution it can call specific Q# operations and functions from the Q# file.
The core of the interoperability is based on the Q# compiler making the contents of the Q# file accessible to the host program so that they can be called.

One of the main benefits of using a host program is that the classical data returned by the Q# program can then be further processed in the host language.
This could consist of some advanced data processing (e.g. something that can't be performed internally in Q#), and then calling further Q# actions based on those results, or something as simple as plotting the Q# results.

The general scheme is shown here, and we discuss the specific implementations for Python and C# below. 
A sample using an F# host program can be found at the [.NET interoperability samples](https://github.com/microsoft/Quantum/tree/master/samples/interoperability/dotnet).

<br/>
<img src="../media/hostprograms_host_program_diagram.png" alt="Q# program from a host program" width="700">

> [!NOTE]
> The `@EntryPoint()` attribute used for Q# applications cannot be used with host programs.
> An error will be raised if it is present in the Q# file being called by a host. 

To work with different host programs, there are no changes required to a `*.qs` Q# file.
The following host program implementations all work with the same Q# file:

```qsharp
namespace NamespaceName {
    open Microsoft.Quantum.Intrinsic;     // contains H
    open Microsoft.Quantum.Measurement;   // MResetZ
    open Microsoft.Quantum.Canon;         // ApplyToEach
    open Microsoft.Quantum.Arrays;        // ForEach

    operation MeasureSuperposition() : Result {
        using (q = Qubit()) { 
            H(q);
            return MResetZ(q);
        }
    }

    operation MeasureSuperpositionArray(n : Int) : Result[] {
        using (qubits = Qubit[n]) {  
            ApplyToEach(H, qubits); 
            return ForEach(MResetZ, qubits);    
        }
    }
}
```

Select the tab corresponding to your host language of interest.

### [Python](#tab/tabid-python)
A Python host program is constructed as follows:
1. Import the `qsharp` module, which registers the module loader for Q# interoperability. 
    This allows Q# namespaces to appear as Python modules, from which we can "import" Q# callables.
    Note that it is technically not the Q# callables themselves which are imported, but rather Python stubs which allow calling into them.
    These then behave as objects of Python classes, on which we use methods to specify the target machines to send the operation to for execution.

2. Import those Q# callables which we will directly invoke---in this case, `MeasureSuperposition` and `MeasureSuperpositionArray`.
    ```python
    import qsharp
    from NamespaceName import MeasureSuperposition, MeasureSuperpositionArray
    ```
    With the `qsharp` module imported, you can also import callables directly from the Q# library namespaces.

3. Among any other Python code, you can now call those callables on specific target machines, and assign their returns to variables (if they return a value) for further use.

#### Specifying target machines
Calling an operation to be run on a specific target machine is done via different Python methods on the imported object.
For example, `.simulate(<args>)`, uses the `QuantumSimulator` to run the operation, whereas `.estimate_resources(<args>)` does so on the `ResourcesEstimator`.

#### Passing inputs to Q\#
Arguments for the Q# callable should be provided in the form of a keyword argument, where the keyword is the argument name in the Q# callable definition.
That is, `MeasureSuperpositionArray.simulate(n=4)` is valid, whereas `MeasureSuperpositionArray.simulate(4)` would throw an error.

Therefore, the Python host program 

```python
import qsharp
from NamespaceName import MeasureSuperposition, MeasureSuperpositionArray

single_qubit_result = MeasureSuperposition.simulate()
single_qubit_resources = MeasureSuperposition.estimate_resources()

multi_qubit_result = MeasureSuperpositionArray.simulate(n=4)
multi_qubit_resources = MeasureSuperpositionArray.estimate_resources(n=4)

print('Single qubit:\n' + str(single_qubit_result))
print(single_qubit_resources)

print('\nMultiple qubits:\n' + str(multi_qubit_result))
print(multi_qubit_resources)
```

results in an output like the following:

```output
Single qubit:
1
{'CNOT': 0, 'QubitClifford': 1, 'R': 0, 'Measure': 1, 'T': 0, 'Depth': 0, 'Width': 1, 'BorrowedWidth': 0}

Multiple qubits:
[0, 1, 1, 1]
{'CNOT': 0, 'QubitClifford': 4, 'R': 0, 'Measure': 4, 'T': 0, 'Depth': 0, 'Width': 4, 'BorrowedWidth': 0}
```

#### Using Q# code from other projects or packages

By default, the `import qsharp` command loads all of the `.qs` files in the current folder and makes their Q# operations and functions
available for use from inside the Python script.

To load Q# code from another folder, the [`qsharp.projects` API](https://docs.microsoft.com/python/qsharp/qsharp.projects.projects)
can be used to add a reference to a `.csproj` file for a Q# project (that is, a project that references `Microsoft.Quantum.Sdk`).
This command will compile any `.qs` files in the folder containing the `.csproj` (and subfolders). It will also recursively load
any packages referenced via `PackageReference` or Q# projects referenced via `ProjectReference` in that `.csproj` file.

As an example, the following Python code imports an external project, referencing its path relative to the current folder,
and invokes one of its Q# operations:

```python
import qsharp
qsharp.projects.add("../qrng/Qrng.csproj")
from Qrng import SampleQuantumRandomNumberGenerator
print(f"Qrng result: {SampleQuantumRandomNumberGenerator.simulate()}")
```

This results in output like the following:

```output
Adding reference to project: ../qrng/Qrng.csproj
Qrng result: 0
```

To load external packages containing Q# code, use the [`qsharp.packages` API](https://docs.microsoft.com/python/qsharp/qsharp.packages.packages).

If the Q# code in the current folder depends on external projects or packages, you may see errors when running `import qsharp`,
since the dependencies have not yet been loaded.
To load required external packages or Q# projects during the `import qsharp` command, ensure that the folder with the Python script
contains a `.csproj` file which references `Microsoft.Quantum.Sdk`. In that `.csproj`, add the property
`<IQSharpLoadAutomatically>true</IQSharpLoadAutomatically>` to the `<PropertyGroup>`. This will instruct IQ# to recursively
load any `ProjectReference` or `PackageReference` items found in that `.csproj` during the `import qsharp` command.

For example, here is a simple `.csproj` file that causes IQ# to automatically load the `Microsoft.Quantum.Chemistry` package:

    <Project Sdk="Microsoft.Quantum.Sdk/0.12.20072031">
        <PropertyGroup>
            <OutputType>Library</OutputType>
            <TargetFramework>netstandard2.1</TargetFramework>
            <IQSharpLoadAutomatically>true</IQSharpLoadAutomatically>
        </PropertyGroup>
        <ItemGroup>
            <PackageReference Include="Microsoft.Quantum.Chemistry" Version="0.12.20072031" />
        </ItemGroup>
    </Project>

> [!NOTE]
> Currently this custom `<IQSharpLoadAutomatically>` property is required, but in the future, this may become the default
behavior for a `.csproj` file located in the same folder as the Python script.

> [!NOTE]
> Currently the `<QsharpCompile>` setting in the `.csproj` is ignored, and all `.qs` files in the folder of the `.csproj`
> (including subfolders) are loaded and compiled. Support for `.csproj` settings will be improved in the future
> (see [iqsharp#277](https://github.com/microsoft/iqsharp/issues/277) for more details).


### [C#](#tab/tabid-csharp)

A C# host program has multiple components, and works very closely with some components of the QDK, such as the simulators, which are themselves built on C#.

The Q# compiler works here by generating an equivalently named C# namespace from the Q# namespace in our Q# file.
It further generates an equivalently named C# class for each of the Q# callables or types defined therein.

First, we make any classes used in our host program available with `using` statements, which are roughly analagous to the `open` statements in our Q# file:

```csharp
using System;
using System.Threading.Tasks;
using Microsoft.Quantum.Simulation.Simulators;    // contains the target machines (e.g. QuantumSimulator, ResourcesEstimator)
using NamespaceName;                              // make the Q# namespace available
```

Next, we declare our C# namespace, a few other bits and pieces (see the full code block below), and then any classical programming we would like (e.g. computing arguments for the Q# callables).
The latter isn't necessary in our case, but an example of such usage can be found at the  [.NET interoperability sample](https://github.com/microsoft/Quantum/tree/master/samples/interoperability/dotnet).

#### Target machines

Getting back to Q#, we must create an instance of whatever target machine we will execute our operations on.

```csharp
            using var sim = new QuantumSimulator();
```

Using other target machines is as simple as instantiating a different one, although the manner of doing so and processing the returns can be slightly different.
For brevity, we stick to the [`QuantumSimulator`](xref:microsoft.quantum.machines.full-state-simulator) for now, and include the [`ResourcesEstimator`](xref:microsoft.quantum.machines.resources-estimator) [below](#including-the-resources-estimator).

Each C# class generated from the Q# operations have a `Run` method, the first argument of which must be the target machine instance.
So, to run `MeasureSuperposition` on the `QuantumSimulator`, we use `MeasureSuperposition.Run(sim)`.
The returned results can then be assigned to variables in C#:

```csharp
            var singleQubitResult = await MeasureSuperposition.Run(sim);
```

> [!NOTE]
> The `Run` method is executed asynchronously because this will be the case for real quantum hardware, and therefore the `await` keyword blocks further execution until the task completes.

If the Q# callable does not have any returns (i.e. has return type `Unit`), then the execution can still be done in the same manner without assigning it to a variable.
In that case, the entire line would simply consist of 
```csharp
await <callable>.Run(<simulator>);
```

#### Arguments

Any arguments to the Q# callable are simply passed as additional arguments afer the target machine.
Hence the results of `MeasureSuperpositionArray` on `n=4` qubits would fetched via 

```csharp
            var multiQubitResult = await MeasureSuperpositionArray.Run(sim, 4);
```

A full C# host program could thus look like

```csharp
using System;
using System.Threading.Tasks;
using Microsoft.Quantum.Simulation.Simulators;
using NamespaceName;

namespace host
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            using var sim = new QuantumSimulator();

            var singleQubitResult = await MeasureSuperposition.Run(sim);
            var multiQubitResult = await MeasureSuperpositionArray.Run(sim, 4);

            Console.WriteLine($"Single qubit result: {singleQubitResult}");
            Console.WriteLine($"Multiple qubit result: {multiQubitResult}");
        }
    }
}
```

At the location of the C# file, the host program can be run from the command prompt by entering
```dotnetcli
dotnet run
```
and in this case you will see output written to the console similar to 
```output
Single qubit result: One
Multiple qubit result: [One,One,Zero,Zero]
```

> [!NOTE]
> Due to the compiler's interoperability with namespaces, we could alternatively make our Q# callables available without the `using NamespaceName;` statement, and simply matching the C# namespace title to it.
> That is, by replacing `namespace host` with `namespace NamespaceName`.

#### Including the resources estimator

The [`ResourcesEstimator`](xref:microsoft.quantum.machines.resources-estimator) requires a slightly different implementation to retrieve the output.

Firstly, instead of instantiating them as a variable with a `using` statement (as we do with the `QuantumSimulator`), we more directly instantiate objects of the class via

```csharp
            var estimatorSingleQ = new ResourcesEstimator();
            var estimatorMultiQ = new ResourcesEstimator();
```

Notice that instead of a single target simulator to be used by multiple Q# operations, we have instantiated one for each. 
This is because the objects themselves are modified when used as target machines, and their results can then be retrieved afterwards with the class method `.ToTSV()`.

To run the operations on the resource estimators, we use

```csharp
            await MeasureSuperposition.Run(estimatorSingleQ);
            await MeasureSuperpositionArray.Run(estimatorMultiQ, 4);
```
and then fetch the results as tab-separated-values (TSV) with `estimatorSingleQ.ToTSV()` and `estimatorMultiQ.ToTSV()`.

So, a full C# host program making use of both the `QuantumSimulator` and `ResourcesEstimator` could take the form:

```csharp
using System;
using System.Threading.Tasks;
using Microsoft.Quantum.Simulation.Simulators;
using NamespaceName;

namespace host
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            using var sim = new QuantumSimulator();
            var estimatorSingleQ = new ResourcesEstimator();
            var estimatorMultiQ = new ResourcesEstimator();

            var singleQubitResult = await MeasureSuperposition.Run(sim);
            var multiQubitResult = await MeasureSuperpositionArray.Run(sim, 4);

            await MeasureSuperposition.Run(estimatorSingleQ);
            await MeasureSuperpositionArray.Run(estimatorMultiQ, 4);

            Console.WriteLine($"Single qubit result: {singleQubitResult}");
            Console.WriteLine("Single qubit resources:");
            Console.WriteLine(estimatorSingleQ.ToTSV());

            Console.WriteLine($"\nMultiple qubit result: {multiQubitResult}");
            Console.WriteLine("Multiple qubit resources:");
            Console.WriteLine(estimatorMultiQ.ToTSV());
        }
    }
}
```


which would yield output similar to

```output
Single qubit result: One
Single qubit resources:
Metric          Sum
CNOT            0
QubitClifford   1
R               0
Measure         1
T               0
Depth           0
Width           1
BorrowedWidth   0

Multiple qubit result: [One,One,One,Zero]
Multiple qubit resources:
Metric          Sum
CNOT            0
QubitClifford   4
R               0
Measure         4
T               0
Depth           0
Width           4
BorrowedWidth   0
```

***

## Q# Jupyter Notebooks
Q# Jupyter Notebooks make use of the IQ# kernel, which allows you to define, compile, and run Q# callables in a single notebook---all alongside instructions, notes, and other content.
This means that while it is possible to import and use the contents of `*.qs` Q# files, they are not necessary in the execution model.

Here, we will detail how to run the Q# operations defined above, but a more broad introduction to using Q# Jupyter Notebooks is provided at [Intro to Q# and Jupyter Notebooks](https://github.com/microsoft/Quantum/blob/master/samples/getting-started/intro-to-iqsharp/Notebook.ipynb).

### Defining operations

In a Q# Jupyter Notebook, you enter Q# code just as we would from inside the namespace of a Q# file.

So, we can enable access to callables from the [Q# standard libraries](xref:microsoft.quantum.qsharplibintro) with `open` statements for their respective namespaces.
Upon running a cell with such a statement, the definitions from those namespaces are available throughout the workspace.

> [!NOTE]
> Callables from [Microsoft.Quantum.Intrinsic](xref:microsoft.quantum.intrinsic) and [Microsoft.Quantum.Canon](xref:microsoft.quantum.canon) (e.g. [`H`](xref:microsoft.quantum.intrinsic.h) and [`ApplyToEach`](xref:microsoft.quantum.canon.applytoeach)) are automatically available to operations defined within cells in Q# Jupyter Notebooks.
> However, this is not true for code brought in from external Q# source files (a process shown at [Intro to Q# and Jupyter Notebooks](https://github.com/microsoft/Quantum/blob/master/samples/getting-started/intro-to-iqsharp/Notebook.ipynb)). 
> 

Similarly, defining operations requires only writing the Q# code and running the cell.

<img src="../media/hostprograms_jupyter_op_def_crop.png" alt="Jupyter cell defining Q# operations" width="600">

The output then lists those operations, which can then be called from future cells.

### Target machines

The functionality to run operations on specific target machines is provided via [IQ# Magic Commands](xref:microsoft.quantum.guide.quickref.iqsharp).
For example, `%simulate` makes use of the `QuantumSimulator`, and `%estimate` uses the `ResourcesEstimator`:

<img src="../media/hostprograms_jupyter_no_args_sim_est_crop.png" alt="Jupyter cell simulating a Q# operation and running resource estimation" width="600">

### Passing inputs to functions and operations

To pass inputs to the Q# operations, the arguments can be passed as `key=value` pairs to the execution magic command.
So, to run `MeasureSuperpositionArray`, we can run `%simulate MeasureSuperpositionArray n=4`:

<img src="../media/hostprograms_jupyter_args_sim_crop.png" alt="Jupyter cell simulating a Q# operation with arguments" width="600">

This pattern can be used similarly with `%estimate` and other execution commands.

### Using Q# code from other projects or packages

By default, a Q# Jupyter Notebook loads all of the `.qs` files in the current folder and makes their Q# operations and functions
available for use from inside the notebook. The [`%who` magic command](xref:microsoft.quantum.iqsharp.magic-ref.who) lists all
currently-available Q# operations and functions.

To load Q# code from another folder, the [`%project` magic command](xref:microsoft.quantum.iqsharp.magic-ref.project) can be used
to add a reference to a `.csproj` file for a Q# project (that is, a project that references `Microsoft.Quantum.Sdk`). This command
will compile any `.qs` files in the folder containing the `.csproj` (and subfolders). It will also recursively load any packages
referenced via `PackageReference` or Q# projects referenced via `ProjectReference` in that `.csproj` file.

As an example, the following cells simulate a Q# operation from an external project, where the project path is referenced relative to the current folder:

<img src="../media/hostprograms_jupyter_project_crop.png" alt="Jupyter cell simulating a Q# operation with arguments" width="600">

To load external packages containing Q# code, use the [`%package` magic command](xref:microsoft.quantum.iqsharp.magic-ref.package).
Loading a package will also make available any custom magic commands or display encoders that are contained in any assemblies
that are part of the package.

To load external packages or Q# projects at notebook intialization time, ensure that the notebook folder contains
a `.csproj` file which references `Microsoft.Quantum.Sdk`. In that `.csproj`, add the property
`<IQSharpLoadAutomatically>true</IQSharpLoadAutomatically>` to the `<PropertyGroup>`. This will instruct IQ# to recursively
load any `ProjectReference` or `PackageReference` items found in that `.csproj` at notebook load time.

For example, here is a simple `.csproj` file that causes IQ# to automatically load the `Microsoft.Quantum.Chemistry` package:

    <Project Sdk="Microsoft.Quantum.Sdk/0.12.20072031">
        <PropertyGroup>
            <OutputType>Library</OutputType>
            <TargetFramework>netstandard2.1</TargetFramework>
            <IQSharpLoadAutomatically>true</IQSharpLoadAutomatically>
        </PropertyGroup>
        <ItemGroup>
            <PackageReference Include="Microsoft.Quantum.Chemistry" Version="0.12.20072031" />
        </ItemGroup>
    </Project>

> [!NOTE]
> Currently this custom `<IQSharpLoadAutomatically>` property is required, but in the future, this may become the default
behavior for a `.csproj` file located in the same folder as the notebook file.

> [!NOTE]
> Currently the `<QsharpCompile>` setting in the `.csproj` is ignored, and all `.qs` files in the folder of the `.csproj`
> (including subfolders) are loaded and compiled. Support for `.csproj` settings will be improved in the future
> (see [iqsharp#277](https://github.com/microsoft/iqsharp/issues/277) for more details).

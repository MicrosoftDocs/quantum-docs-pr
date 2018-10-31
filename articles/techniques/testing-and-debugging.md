---
title: Q# techniques - testing and debugging | Microsoft Docs
description: Q# techniques - testing and debugging
author: tcNickolas
ms.author: mamykhai@microsoft.com
uid: microsoft.quantum.techniques.testing-and-debugging
ms.date: 12/11/2017
ms.topic: article
---

# Testing and Debugging

As with classical programming, it is essential to be able to check that quantum programs act as intended, and to be able to diagnose a quantum program that is incorrect.
In this section, we cover the tools offered by Q# for testing and debugging quantum programs.

## Unit Tests

One common approach to testing classical programs is to write small programs called *unit tests* which run code in a library and compare its output to some expected output.
For instance, we may want to ensure that `Square(2)` returns `4`, since we know *a priori* that $2^2 = 4$.

Q# supports creating unit tests for quantum programs, and which can be executed as tests within the [xUnit](https://xunit.github.io/) unit testing framework.

### Creating a Test Project

#### [Visual Studio 2017](#tab/tabid-vs2017)

Open Visual Studio 2017. Go to the `File` menu and select `New` > `Project...`.
In the project template explorer, under `Installed` > `Visual C#`,
select the `Q# Test Project` template.

#### [Command Line / Visual Studio Code](#tab/tabid-vscode)

From your favorite command line, run the following command:
```bash
$ dotnet new xunit -lang Q# -o Tests
$ cd Tests
$ code . # To open in Visual Studio Code
```

****

In either case, your new project will have two files open.
The first file, `Tests.qs`, provides a convenient place to define new Q# unit tests.
Initially this file contains one sample unit test `AllocateQubitTest` which checks that a newly allocated qubit is in the $\ket{0}$ state and prints a message:

```qsharp
operation AllocateQubitTest () : Unit
{
    body (...)
    {
        using (qs = Qubit()) 
        {
            Assert([PauliZ], [qs], Zero, "Newly allocated qubit must be in |0> state");
        }
        Message("Test passed");
    }
}
```

Any Q# operation with the signature `Unit => Unit` or function with the signature `Unit -> Unit` can be executed as a unit test. 

The second file, `TestSuiteRunner.cs` contains a method that discovers and runs Q# unit tests. 
This is the method `TestTarget` annotated with `OperationDriver` attribute.
The `OperationDriver` attribute is a part of the Xunit extension library Microsoft.Quantum.Simulation.Xunit.
The unit testing framework calls `TestTarget` method for every Q# unit test it has discovered.
The framework passes the unit test description to the method through `op` argument. The following line of code:
```csharp
op.TestOperationRunner(sim);
```
executes the unit test on `QuantumSimulator`.

By default, the unit test discovery mechanism looks for all Q# functions or operations with signatures `Unit => Unit` or `Unit -> Unit`
that satisfy the following properties:
* Located in the same assembly as the method annotated with the `OperationDriver` attribute.
* Located in the same namespace as the method annotated with the `OperationDriver` attribute.
* Has a name ending with `Test`.

An assembly, a namespace, and a suffix for unit test functions and operations can be set using optional parameters of the `OperationDriver` attribute:
* `AssemblyName` parameter sets the name of the assembly which is being searched for tests.
* `TestNamespace` parameter sets the name of the namespace which is being searched for tests.
* `Suffix` sets the suffix of operation or function names that are considered to be unit tests.

In addition, the `TestCasePrefix` optional parameter lets you set a prefix for the name of the test case. 
The prefix in front of the operation name will appear in the list of test cases. For example, 
`TestCasePrefix = "QSim:"` will cause `AllocateQubitTest` to appear as `QSim:AllocateQubitTest` in the list 
of found tests. This can be useful to indicate, for instance, which simulator is used to run a test.

### Running Q# Unit Tests

#### [Visual Studio 2017](#tab/tabid-vs2017)

As a one-time per-solution setup, go to `Test` menu and select `Test Settings` > `Default Processor Architecture` > `X64`.

> [!TIP]
> The default processor architecture setting for Visual Studio is stored in the solution options (`.suo`) file for each solution.
> If you delete this file, then you will need to select `X64` as your processor architecture again.

Build the project, go to the `Test` menu and select `Windows` > `Test Explorer`. `AllocateQubitTest` will show up in the list of tests in the `Not Run Tests` group. Select `Run All` or run this individual test, and it should pass!

#### [Command Line / Visual Studio Code](#tab/tabid-vscode)

To run tests, navigate to the project folder (the folder which contains `Tests.csproj`), and execute the command:

```bash
$ dotnet restore
$ dotnet test
```

You should get output similar to the following:

```
Build started, please wait...
Build completed.

Test run for C:\Users\chgranad.REDMOND\tmp\Tests\bin\Debug\netcoreapp2.0\Tests.dll(.NETCoreApp,Version=v2.0)
Microsoft (R) Test Execution Command Line Tool Version 15.3.0-preview-20170628-02
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
[xUnit.net 00:00:00.5864002]   Discovering: Tests
[xUnit.net 00:00:00.7073844]   Discovered:  Tests
[xUnit.net 00:00:00.7453826]   Starting:    Tests
[xUnit.net 00:00:00.9590439]   Finished:    Tests

Total tests: 1. Passed: 1. Failed: 0. Skipped: 0.
Test Run Successful.
Test execution time: 1.9607 Seconds
```

***

## Logging and Assertions

One important consequence of the fact that functions in Q# have no side effects is that any effects of executing a function whose output type is the empty tuple `()` can never be observed from within a Q# program.
That is, a target machine can choose not to execute any function which returns `()` with the guarantee that this omission will not modify the behavior of any following Q# code.
This makes functions returning `()` a useful tool for embedding assertions and debugging logic into Q# programs. 

### Logging

The primitive function @"microsoft.quantum.primitive.message" has type `String -> ()` and enables the creation of diagnostic messages.

The `onLog` action of `QuantumSimulator` can be used to define actions performed when Q# code calls `Message`. By default logged messages are printed to standard output.

When defining a unit test suite, the logged messages can be directed to the test output. When a project is created from Q# Test Project template, this redirection is pre-configured for the suite and created by default as follows:

```qsharp
using (var sim = new QuantumSimulator())
{
    // OnLog defines action(s) performed when Q# test calls operation Message
    sim.OnLog += (msg) => { output.WriteLine(msg); };
    op.TestOperationRunner(sim);
}
```

#### [Visual Studio 2017](#tab/tabid-vs2017)

After you execute a test in Test Explorer and click on the test, a panel will appear with information about test execution: Passed/Failed status, elapsed time and an "Output" link. If you click the "Output" link, test output will open in a new window.

![test output](~/media/unit-test-output.png)

#### [Command Line / Visual Studio Code](#tab/tabid-vscode)

The pass/fail status for each test is printed to the console by `dotnet test`.
For failing tests, the outputs logged as a result of the `output.WriteLine(msg)` call above are also printed to the console to help diagnose the failure.

***

### Assertions

The same logic can be applied to implementing assertions. Let's consider a simple example:

```qsharp
function AssertPositive(value : Double) : Unit 
{
    if (value <= 0) 
    {
        fail "Expected a positive number.";
    }
}
```

Here, the keyword `fail` indicates that the computation should not proceed, raising an exception in the target machine running the Q# program.
By definition, a failure of this kind cannot be observed from within Q#, as no further Q# code is run after a `fail` statement is reached.
Thus, if we proceed past a call to `AssertPositive`, we can be assured by that its input was positive.

Building on these ideas, [the prelude](xref:microsoft.quantum.libraries.standard.prelude) offers two especially useful assertions, @"microsoft.quantum.primitive.assert" and @"microsoft.quantum.primitive.assertprob" both modeled as operations onto `()`. These assertions each take a Pauli operator describing a particular measurement of interest, a quantum register on which a measurement is to be performed, and a hypothetical outcome.
On target machines which work by simulation, we are not bound by [the no-cloning theorem](https://en.wikipedia.org/wiki/No-cloning_theorem), and can perform such measurements without disturbing the register passed to such assertions.
A simulator can then, similar to the `AssertPositive` function above, abort computation if the hypothetical outcome would not be observed in practice:

```qsharp
using (register = Qubit()) 
{
    H(register);
    Assert([PauliX], [register], Zero);
    // Even though we do not have access to states in Q#,
    // we know by the anthropic principle that the state
    // of register at this point is |+〉.
}
```

On physical quantum hardware, where the no-cloning theorem prevents examination of quantum state, the `Assert` and `AssertProb` operations simply return `()` with no other effect.

The <xref:microsoft.quantum.canon> namespace provides several more functions of the `Assert` family which allow us to check more advanced conditions. They are detailed in [Q# standard libraries: Testing and Debugging](xref:microsoft.quantum.libraries.standard.testing) section.

## Dump Functions

To help troubleshooting quantum programs, [the prelude](xref:microsoft.quantum.libraries.standard.prelude) offers two functions that can dump into a file the current status of the target machine: @"microsoft.quantum.extensions.diagnostics.dumpmachine" and @"microsoft.quantum.extensions.diagnostics.dumpregister". The generated output of each depends on the target machine.

### DumpMachine

The full-state quantum simulator distributed as part of the Quantum Development Kit writes into the file the [wave function](https://en.wikipedia.org/wiki/Wave_function) of the entire quantum system, as a one-dimensional array of complex numbers, in which each element represents the amplitude of the probability of measuring the computational basis state $\ket{n}$, where $\ket{n} = \ket{b_{n-1}...b_1b_0}$ for bits $\{b_i\}$. For example, on a machine with only two qubits allocated and in the quantum state
$$
\begin{align}
    \ket{\psi} = \frac{1}{\sqrt{2}} \ket{00} - \frac{(1 + i)}{2} \ket{10},
\end{align}
$$
calling @"microsoft.quantum.extensions.diagnostics.dumpmachine" generates this output:

```
Ids:    [1;0;]
Wavefunction:
0:      0.707107        0
1:      0               0
2:      -0.5            -0.5
3:      0               0
```

Notice how the ids of the qubits are shown at the top in their significant order. For each computational basis state $\ket{n}$, the first column represents the Real part of the amplituted, and the second column represents its Imaginary part.

  > [!NOTE]
  > The id of a qubit is assigned at runtime and it's not necessarily aligned with the order in which the qubit was allocated or its position within a qubit register.


#### [Visual Studio 2017](#tab/tabid-vs2017)

  > [!TIP]
  > You can figure out a qubit id in Visual Studio by putting a breakpoint in your code and inspecting the value of a qubit variable, for example:
  > 
  > ![show qubit id in Visual Studio](~/media/qubit_id.png)
  >
  > the qubit with index `0` on `register2` has id=`3`, the qubit with index `1` has id=`2`.

#### [Command Line / Visual Studio Code](#tab/tabid-vscode)

  > [!TIP]
  > You can figure out a qubit id by using the @"microsoft.quantum.primitive.message" function and passing the qubit variable in the message, for example:
  >
  > ```qsharp
  > Message($"0={register2[0]}; 1={register2[1]}");
  > ```
  > 
  > which could generate this output:
  >```
  > 0=q:3; 1=q:2
  >```
  > which means that the qubit with index `0` on `register2` has id=`3`, the qubit with index `1` has id=`2`.


***


@"microsoft.quantum.extensions.diagnostics.dumpmachine" is part of the  <xref:microsoft.quantum.extensions.diagnostics> namespace, so in order to use it you must add an `open` statement:

```qsharp
namespace Samples
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Extensions.Diagnostics;

    operation Operation () : Unit
    {
        body (...)
        {
            using (qubits = Qubit[2])
            {
                H(qubits[1]);
                DumpMachine("dump.txt");
            }
        }
    }
}
```


### DumpRegister

@"microsoft.quantum.extensions.diagnostics.dumpregister" works like @"microsoft.quantum.extensions.diagnostics.dumpmachine", except it also takes an array of qubits to limit the amount of information to only that relevant to the corresponding qubits.

As with @"microsoft.quantum.extensions.diagnostics.dumpmachine", the information generated by @"microsoft.quantum.extensions.diagnostics.dumpregister" depends on the target machine. For the full-state quantum simulator it writes into the file the wave function up to a global phase of the quantum sub-system generated by the provided qubits in the same format as @"microsoft.quantum.extensions.diagnostics.dumpmachine".  For example, take again a machine with only two qubits allocated and in the quantum state
$$
\begin{align}
    \ket{\psi} = \frac{1}{\sqrt{2}} \ket{00} - \frac{(1 + i)}{2} \ket{10} = - e^{-i\pi/4} ( (\frac{1}{\sqrt{2}} \ket{0} - \frac{(1 + i)}{2} \ket{1} ) \otimes \frac{-(1 + i)}{\sqrt{2}} \ket{0} ) ,
\end{align}
$$
calling @"microsoft.quantum.extensions.diagnostics.dumpregister" for `qubit[0]` generates this output:

```
Ids:    [0;]
Wavefunction:
0:      -0.707107       -0.707107
1:      0               0
```

and calling @"microsoft.quantum.extensions.diagnostics.dumpregister" for `qubit[1]` generates this output:

```
Ids:    [1;]
Wavefunction:
0:      0.707107        0
1:      -0.5            -0.5
```

In general, the state of a register that is entangled with another register is a mixed state rather than a pure state. In this case, @"microsoft.quantum.extensions.diagnostics.dumpregister" outputs the following message:

```
Qubits provided (0;) are entangled with some other qubit.
```

The following example shows you how you can use both @"microsoft.quantum.extensions.diagnostics.dumpregister" and @"microsoft.quantum.extensions.diagnostics.dumpmachine" in your Q# code:

```qsharp
namespace app
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Extensions.Diagnostics;

    operation Operation () : Unit
    {
        body (...)
        {
            using (qubits = Qubit[2])
            {
                X(qubits[1]);
                H(qubits[1]);
                R1Frac(1, 2, qubits[1]);
                
                DumpMachine("dump.txt");
                DumpRegister("q0.txt", qubits[0..0]);
                DumpRegister("q1.txt", qubits[1..1]);

                ResetAll(qubits);
            }
        }
    }
}
```

## Debugging

On top of `Assert` and `Dump` functions and operations, Q# supports a subset of standard Visual Studio debugging capabilities: [setting line breakpoints](https://docs.microsoft.com/visualstudio/debugger/using-breakpoints), [stepping through code using F10](https://docs.microsoft.com/visualstudio/debugger/navigating-through-code-with-the-debugger) and [inspecting values of classic variables](https://docs.microsoft.com/visualstudio/debugger/autos-and-locals-windows) are all possible during code execution on the simulator.

Debugging in Visual Studio Code is not yet supported.


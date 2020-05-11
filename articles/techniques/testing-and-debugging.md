---
title: Testing and debugging Q# programs
description: Learn how to use unit tests, facts and assertions, and dump functions to test and debug quantum programs. 
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

#### [Visual Studio 2019](#tab/tabid-vs2019)

Open Visual Studio 2019. Go to the `File` menu and select `New` > `Project...`.
In the upper right corner, search for `Q#`, and select the `Q# Test Project` template.

#### [Command Line / Visual Studio Code](#tab/tabid-vscode)

From your favorite command line, run the following command:
```bash
$ dotnet new xunit -lang Q# -o Tests
$ cd Tests
$ code . # To open in Visual Studio Code
```

****

Your new project will have a single file `Tests.qs`, which provides a convenient place to define new Q# unit tests.
Initially this file contains one sample unit test `AllocateQubit` which checks that a newly allocated qubit is in the $\ket{0}$ state and prints a message:

```qsharp
    @Test("QuantumSimulator")
    operation AllocateQubit () : Unit {

        using (qubit = Qubit()) {
            Assert([PauliZ], [qubit], Zero, "Newly allocated qubit must be in the |0⟩ state.");
        }
        
        Message("Test passed");
    }
```

:new: Any Q# operation or function that takes an argument of type `Unit` and returns `Unit` can be marked as a unit test via the `@Test("...")` attribute. 
The argument to that attribute, `"QuantumSimulator"` above, specifies the target on which the test is executed. A single test can be executed on multiple targets. For example, add an attribute `@Test("ResourcesEstimator")` above `AllocateQubit`. 
```qsharp
    @Test("QuantumSimulator")
    @Test("ResourcesEstimator")
    operation AllocateQubit () : Unit {
        ...
```
Save the file and execute all tests. There should now be two unit tests, one where AllocateQubit is executed on the QuantumSimulator, and one where it is executed in the ResourceEstimator. 

The Q# compiler recognizes the built-in targets "QuantumSimulator", "ToffoliSimulator", and "ResourcesEstimator" as valid execution targets for unit tests. It is also possible to specify any fully qualified name to define a custom execution target. 

### Running Q# Unit Tests

#### [Visual Studio 2019](#tab/tabid-vs2019)

As a one-time per-solution setup, go to `Test` menu and select `Test Settings` > `Default Processor Architecture` > `X64`.

> [!TIP]
> The default processor architecture setting for Visual Studio is stored in the solution options (`.suo`) file for each solution.
> If you delete this file, then you will need to select `X64` as your processor architecture again.

Build the project, go to the `Test` menu and select `Windows` > `Test Explorer`. `AllocateQubit` will show up in the list of tests in the `Not Run Tests` group. Select `Run All` or run this individual test, and it should pass!

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

Unit tests can be filtered according to their name and/or the execution target:

```bash 
$ dotnet test --filter "Target=QuantumSimulator"
$ dotnet test --filter "Name=AllocateQubit"
```


***

The intrinsic function <xref:microsoft.quantum.intrinsic.message> has type `(String -> Unit)` and enables the creation of diagnostic messages.

#### [Visual Studio 2019](#tab/tabid-vs2019)

After you execute a test in Test Explorer and click on the test, a panel will appear with information about test execution: Passed/Failed status, elapsed time and an "Output" link. If you click the "Output" link, test output will open in a new window.

![test output](~/media/unit-test-output.png)

#### [Command Line / Visual Studio Code](#tab/tabid-vscode)

The pass/fail status for each test is printed to the console by `dotnet test`.
For failing tests, the outputs are also printed to the console to help diagnose the failure.

***

## Facts and Assertions

Because functions in Q# have no _logical_ side effects, any _other kinds_ of effects of executing a function whose output type is the empty tuple `()` can never be observed from within a Q# program.
That is, a target machine can choose not to execute any function which returns `()` with the guarantee that this omission will not modify the behavior of any following Q# code.
This makes functions returning `()` (i.e. `Unit`) a useful tool for embedding assertions and debugging logic into Q# programs. 

Let's consider a simple example:

```qsharp
function PositivityFact(value : Double) : Unit 
{
    if (value <= 0) 
    {
        fail "Expected a positive number.";
    }
}
```

Here, the keyword `fail` indicates that the computation should not proceed, raising an exception in the target machine running the Q# program.
By definition, a failure of this kind cannot be observed from within Q#, as no further Q# code is run after a `fail` statement is reached.
Thus, if we proceed past a call to `PositivityFact`, we can be assured by that its input was positive.

Note that we can implement the same behavior as `PositivityFact` using the [`Fact`](xref:microsoft.quantum.diagnostics.fact) function from the <xref:microsoft.quantum.diagnostics> namespace:

```qsharp
    Fact(value > 0, "Expected a positive number.");
```

*Assertions*, on the other hand, are used similarly to facts, but may be dependent on the state of the target machine. 
Correspondingly, they are defined as operations, whereas facts are defined as functions (as above).
To understand the distinction, consider the following use of a fact within an assertion:

```qsharp
operation AssertQubitsAreAvailable() : Unit
{
     Fact(GetQubitsAvailableToUse() > 0, "No qubits were actually available");
}
```

Here, we are using the operation <xref:microsoft.quantum.environment.getqubitsavailabletouse> to return the number of qubits available to use.
As this clearly depends on the global state of the program and its execution environment, our definition of  `AssertQubitsAreAvailable` must be an operation as well.
However, we can use that global state to yield a simple `Bool` value as input to the `Fact` function.

Building on these ideas, [the prelude](xref:microsoft.quantum.libraries.standard.prelude) offers two especially useful assertions, <xref:microsoft.quantum.intrinsic.assert> and <xref:microsoft.quantum.intrinsic.assertprob> both modeled as operations onto `()`. These assertions each take a Pauli operator describing a particular measurement of interest, a quantum register on which a measurement is to be performed, and a hypothetical outcome.
On target machines which work by simulation, we are not bound by [the no-cloning theorem](https://en.wikipedia.org/wiki/No-cloning_theorem), and can perform such measurements without disturbing the register passed to such assertions.
A simulator can then, similar to the `PositivityFact` function above, abort computation if the hypothetical outcome would not be observed in practice:

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

The <xref:microsoft.quantum.diagnostics> namespace provides several more functions of the `Assert` family which allow us to check more advanced conditions. 

## Dump Functions

To help troubleshooting quantum programs, the <xref:microsoft.quantum.diagnostics> namespace offers two functions that can dump into a file the current status of the target machine: <xref:microsoft.quantum.diagnostics.dumpmachine> and <xref:microsoft.quantum.diagnostics.dumpregister>. The generated output of each depends on the target machine.

### DumpMachine

The full-state quantum simulator distributed as part of the Quantum Development Kit writes into the file the [wave function](https://en.wikipedia.org/wiki/Wave_function) of the entire quantum system, as a one-dimensional array of complex numbers, in which each element represents the amplitude of the probability of measuring the computational basis state $\ket{n}$, where $\ket{n} = \ket{b_{n-1}...b_1b_0}$ for bits $\{b_i\}$. For example, on a machine with only two qubits allocated and in the quantum state
$$
\begin{align}
    \ket{\psi} = \frac{1}{\sqrt{2}} \ket{00} - \frac{(1 + i)}{2} \ket{10},
\end{align}
$$
calling <xref:microsoft.quantum.diagnostics.dumpmachine> generates this output:

```
# wave function for qubits with ids (least to most significant): 0;1
∣0❭:	 0.707107 +  0.000000 i	 == 	**********           [ 0.500000 ]     --- [  0.00000 rad ]
∣1❭:	 0.000000 +  0.000000 i	 == 	                     [ 0.000000 ]                   
∣2❭:	-0.500000 + -0.500000 i	 == 	**********           [ 0.500000 ]   /     [ -2.35619 rad ]
∣3❭:	 0.000000 +  0.000000 i	 == 	                     [ 0.000000 ]                   
```

The first row provides a comment with the IDs of the corresponding qubits in their significant order.
The rest of the rows describe the probability amplitude of measuring the basis state vector $\ket{n}$ in both Cartesian and polar formats. In detail for the first row:

* **`∣0❭:`** this row corresponds to the `0` computational basis state
* **`0.707107 +  0.000000 i`**: the probability amplitude in Cartesian format.
* **` == `**: the `equal` sign seperates both equivalent representations.
* **`**********  `**: A graphical representation of the magnitude, the number of `*` is proportionate to the probability of measuring this state vector.
* **`[ 0.500000 ]`**: the numeric value of the magnitude
* **`    ---`**: A graphical representation of the amplitude's phase (see below).
* **`[ 0.0000 rad ]`**: the numeric value of the phase (in radians).

Both the magnitude and the phase are displayed with a graphical representation. The magnitude representation is straight-forward: it shows a bar of `*`, the bigger the probability the bigger the bar will be. For the phase, we show the following symbols to represent the angle based on ranges:

```
[ -π/16,   π/16)       ---
[  π/16,  3π/16)        /-
[ 3π/16,  5π/16)        / 
[ 5π/16,  7π/16)       +/ 
[ 7π/16,  9π/16)      ↑   
[ 8π/16, 11π/16)    \-    
[ 7π/16, 13π/16)    \     
[ 7π/16, 15π/16)   +\     
[15π/16, 19π/16)   ---    
[17π/16, 19π/16)   -/     
[19π/16, 21π/16)    /     
[21π/16, 23π/16)    /+    
[23π/16, 25π/16)      ↓   
[25π/16, 27π/16)       -\ 
[27π/16, 29π/16)        \ 
[29π/16, 31π/16)        \+
[31π/16,   π/16)       ---
```

The following examples show `DumpMachine` for some common states:

### `∣0❭`

```
# wave function for qubits with ids (least to most significant): 0
∣0❭:	 1.000000 +  0.000000 i	 == 	******************** [ 1.000000 ]     --- [  0.00000 rad ]
∣1❭:	 0.000000 +  0.000000 i	 == 	                     [ 0.000000 ]                   
```

### `∣1❭`

```
# wave function for qubits with ids (least to most significant): 0
∣0❭:	 0.000000 +  0.000000 i	 == 	                     [ 0.000000 ]                   
∣1❭:	 1.000000 +  0.000000 i	 == 	******************** [ 1.000000 ]     --- [  0.00000 rad ]
```

### `∣+❭`

```
# wave function for qubits with ids (least to most significant): 0
∣0❭:	 0.707107 +  0.000000 i	 == 	**********           [ 0.500000 ]      --- [  0.00000 rad ]
∣1❭:	 0.707107 +  0.000000 i	 == 	**********           [ 0.500000 ]      --- [  0.00000 rad ]
```

### `∣-❭`

```
# wave function for qubits with ids (least to most significant): 0
∣0❭:	 0.707107 +  0.000000 i	 == 	**********           [ 0.500000 ]      --- [  0.00000 rad ]
∣1❭:	-0.707107 +  0.000000 i	 == 	**********           [ 0.500000 ]  ---     [  3.14159 rad ]
```


  > [!NOTE]
  > The id of a qubit is assigned at runtime and it's not necessarily aligned with the order in which the qubit was allocated or its position within a qubit register.


#### [Visual Studio 2019](#tab/tabid-vs2019)

  > [!TIP]
  > You can figure out a qubit id in Visual Studio by putting a breakpoint in your code and inspecting the value of a qubit variable, for example:
  > 
  > ![show qubit id in Visual Studio](~/media/qubit_id.png)
  >
  > the qubit with index `0` on `register2` has id=`3`, the qubit with index `1` has id=`2`.

#### [Command Line / Visual Studio Code](#tab/tabid-vscode)

  > [!TIP]
  > You can figure out a qubit id by using the <xref:microsoft.quantum.intrinsic.message> function and passing the qubit variable in the message, for example:
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

<xref:microsoft.quantum.diagnostics.dumpmachine> is part of the  <xref:microsoft.quantum.diagnostics> namespace, so in order to use it you must add an `open` statement:

```qsharp
namespace Samples {
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Diagnostics;

    operation Operation () : Unit {
        using (qubits = Qubit[2]) {
            H(qubits[1]);
            DumpMachine("dump.txt");
        }
    }
}
```


### DumpRegister

<xref:microsoft.quantum.diagnostics.dumpregister> works like <xref:microsoft.quantum.diagnostics.dumpmachine>, except it also takes an array of qubits to limit the amount of information to only that relevant to the corresponding qubits.

As with <xref:microsoft.quantum.diagnostics.dumpmachine>, the information generated by <xref:microsoft.quantum.diagnostics.dumpregister> depends on the target machine. For the full-state quantum simulator it writes into the file the wave function up to a global phase of the quantum sub-system generated by the provided qubits in the same format as <xref:microsoft.quantum.diagnostics.dumpmachine>.  For example, take again a machine with only two qubits allocated and in the quantum state
$$
\begin{align}
    \ket{\psi} = \frac{1}{\sqrt{2}} \ket{00} - \frac{(1 + i)}{2} \ket{10} = - e^{-i\pi/4} ( (\frac{1}{\sqrt{2}} \ket{0} - \frac{(1 + i)}{2} \ket{1} ) \otimes \frac{-(1 + i)}{\sqrt{2}} \ket{0} ) ,
\end{align}
$$
calling <xref:microsoft.quantum.diagnostics.dumpregister> for `qubit[0]` generates this output:

```
# wave function for qubits with ids (least to most significant): 0
∣0❭:	-0.707107 + -0.707107 i	 == 	******************** [ 1.000000 ]  /      [ -2.35619 rad ]
∣1❭:	 0.000000 +  0.000000 i	 == 	                     [ 0.000000 ]                   
```

and calling <xref:microsoft.quantum.diagnostics.dumpregister> for `qubit[1]` generates this output:

```
# wave function for qubits with ids (least to most significant): 1
∣0❭:	 0.707107 +  0.000000 i	 == 	***********          [ 0.500000 ]     --- [  0.00000 rad ]
∣1❭:	-0.500000 + -0.500000 i	 == 	***********          [ 0.500000 ]  /      [ -2.35619 rad ]
```

In general, the state of a register that is entangled with another register is a mixed state rather than a pure state. In this case, <xref:microsoft.quantum.diagnostics.dumpregister> outputs the following message:

```
Qubits provided (0;) are entangled with some other qubit.
```

The following example shows you how you can use both <xref:microsoft.quantum.diagnostics.dumpregister> and <xref:microsoft.quantum.diagnostics.dumpmachine> in your Q# code:

```qsharp
namespace app
{
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Diagnostics;

    operation Operation () : Unit {

        using (qubits = Qubit[2]) {
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
```

## Debugging

On top of `Assert` and `Dump` functions and operations, Q# supports a subset of standard Visual Studio debugging capabilities: [setting line breakpoints](https://docs.microsoft.com/visualstudio/debugger/using-breakpoints), [stepping through code using F10](https://docs.microsoft.com/visualstudio/debugger/navigating-through-code-with-the-debugger) and [inspecting values of classic variables](https://docs.microsoft.com/visualstudio/debugger/autos-and-locals-windows) are all possible during code execution on the simulator.

Debugging in Visual Studio Code leverages the debugging capabilities provided by the C# for Visual Studio Code extension powered by OmniSharp and requires installing the [latest version](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp). 

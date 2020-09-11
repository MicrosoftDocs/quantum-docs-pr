---
title: Testing and debugging
description: Learn how to use unit tests, facts and assertions, and dump functions to test and debug quantum programs. 
author: tcNickolas
ms.author: mamykhai
ms.date: 06/01/2020
ms.topic: article
uid: microsoft.quantum.guide.testingdebugging
no-loc: ['Q#', '$$v']
---

# Testing and debugging

As with classical programming, it is essential to be able to check that quantum programs act as intended, and to be able to diagnose incorrect behavior.
In this section, we cover the tools offered by Q# for testing and debugging quantum programs.

## Unit Tests

One common approach to testing classical programs is to write small programs called *unit tests*, which run code in a library and compare its output to some expected output.
For example, you can ensure that `Square(2)` returns `4` since you know *a priori* that $2^2 = 4$.

Q# supports creating unit tests for quantum programs, and which can run as tests within the [xUnit](https://xunit.github.io/) unit testing framework.

### Creating a Test Project

#### [Visual Studio 2019](#tab/tabid-vs2019)

Open Visual Studio 2019. Go to the **File** menu and select **New > Project...**.
In the upper right corner, search for `Q#`, and select the **Q# Test Project** template.

#### [Command Line / Visual Studio Code](#tab/tabid-vscode)

From your favorite command line, run the following command:
```dotnetcli
$ dotnet new xunit -lang Q# -o Tests
$ cd Tests
$ code . # To open in Visual Studio Code
```

****

Your new project has a single file `Tests.qs`, which provides a convenient place to define new Q# unit tests.
Initially, this file contains one sample unit test `AllocateQubit` which checks that a newly allocated qubit is in the $\ket{0}$ state and prints a message:

```qsharp
    @Test("QuantumSimulator")
    operation AllocateQubit () : Unit {

        using (qubit = Qubit()) {
            AssertMeasurement([PauliZ], [qubit], Zero, "Newly allocated qubit must be in the |0⟩ state.");
        }
        
        Message("Test passed");
    }
```

Any Q# operation or function that takes an argument of type `Unit` and returns `Unit` can be marked as a unit test via the `@Test("...")` attribute. 
In the previous example, the argument to that attribute, `"QuantumSimulator"`, specifies the target on which the test runs. A single test can run on multiple targets. For example, add an attribute `@Test("ResourcesEstimator")` before `AllocateQubit`. 
```qsharp
    @Test("QuantumSimulator")
    @Test("ResourcesEstimator")
    operation AllocateQubit () : Unit {
        ...
```
Save the file and run all tests. There should now be two unit tests, one where `AllocateQubit` runs on the `QuantumSimulator`, and one where it runs in the `ResourcesEstimator`. 

The Q# compiler recognizes the built-in targets `"QuantumSimulator"`, `"ToffoliSimulator"`, and `"ResourcesEstimator"` as valid execution targets for unit tests. It is also possible to specify any fully qualified name to define a custom execution target. 

### Running Q# Unit Tests

#### [Visual Studio 2019](#tab/tabid-vs2019)

As a one-time per-solution setup, go to the **Test** menu and select **Test Settings > Default Processor Architecture > X64**.

> [!TIP]
> The default processor architecture setting for Visual Studio is stored in the solution options (`.suo`) file for each solution.
> If you delete this file, then you need to select **X64** as your processor architecture again.

Build the project, open the **Test** menu, and select **Windows > Test Explorer**. **AllocateQubit** displays in the list of tests in the **Not Run Tests** group. Select **Run All** or run this individual test.

#### [Command Line / Visual Studio Code](#tab/tabid-vscode)

To run tests, navigate to the project folder (the folder which contains `Tests.csproj`), and run the command:

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

Unit tests can be filtered according to their name or the execution target:

```bash 
$ dotnet test --filter "Target=QuantumSimulator"
$ dotnet test --filter "Name=AllocateQubit"
```


***

The intrinsic function <xref:microsoft.quantum.intrinsic.message> has type `(String -> Unit)` and enables the creation of diagnostic messages.

#### [Visual Studio 2019](#tab/tabid-vs2019)

After you run a test in Test Explorer and click on the test, a panel displays with information about test execution: Pass/fail status, elapsed time, and a link to the output. Click **Output** to open the test output in a new window.

![test output](~/media/unit-test-output.png)

#### [Command Line / Visual Studio Code](#tab/tabid-vscode)

The pass/fail status for each test is printed to the console by `dotnet test`.
For failing tests, the outputs are also printed to the console to help diagnose the failure.

***

## Facts and Assertions

Because functions in Q# have no _logical_ side effects, you can never observe, from within a Q# program, any other kinds of effects from running a function whose output type is the empty tuple `()`.
That is, a target machine can choose not to run any function which returns `()` with the guarantee that this omission will not modify the behavior of any following Q# code.
This behavior makes functions returning `()` (such as `Unit`) a useful tool for embedding assertions and debugging logic into Q# programs. 

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

Here, the keyword `fail` indicates that the computation should not proceed, and raises an exception in the target machine running the Q# program.
By definition, a failure of this kind cannot be observed from within Q#, as the target machine no longer runs the Q# code after reaching a `fail` statement.
Thus, if we proceed past a call to `PositivityFact`, we can be assured that its input was positive.

Note that we can implement the same behavior as `PositivityFact` using the [`Fact`](xref:microsoft.quantum.diagnostics.fact) function from the <xref:microsoft.quantum.diagnostics> namespace:

```qsharp
	Fact(value > 0, "Expected a positive number.");
```

*Assertions*, on the other hand, are used similarly to facts but may depend on the state of the target machine. 
Correspondingly, they are defined as operations, whereas facts are defined as functions (as in the previous example).
To understand the distinction, consider the following use of a fact within an assertion:

```qsharp
operation AssertQubitsAreAvailable() : Unit
{
     Fact(GetQubitsAvailableToUse() > 0, "No qubits were actually available");
}
```

Here, we are using the operation <xref:microsoft.quantum.environment.getqubitsavailabletouse> to return the number of qubits available to use.
As this depends on the global state of the program and its execution environment, our definition of `AssertQubitsAreAvailable` must be an operation as well.
However, we can use that global state to yield a simple `Bool` value as input to the `Fact` function.

[The prelude](xref:microsoft.quantum.libraries.standard.prelude), building on these ideas, offers two especially useful assertions, <xref:microsoft.quantum.diagnostics.assertmeasurement> and <xref:microsoft.quantum.diagnostics.assertmeasurementprobability> both modeled as operations onto `()`. These assertions each take a Pauli operator describing a particular measurement of interest, a quantum register on which a measurement is performed, and a hypothetical outcome.
Target machines which work by simulation are not bound by [the no-cloning theorem](https://en.wikipedia.org/wiki/No-cloning_theorem), and can perform such measurements without disturbing the register that passes to such assertions.
A simulator can then, similar to the `PositivityFact` function previous, stop computation if the hypothetical outcome is not observed in practice:

```qsharp
using (register = Qubit()) 
{
    H(register);
    AssertMeasurement([PauliX], [register], Zero);
    // Even though we do not have access to states in Q#,
    // we know by the anthropic principle that the state
    // of register at this point is |+〉.
}
```

On physical quantum hardware, where the no-cloning theorem prevents examination of a quantum state, the `AssertMeasurement` and `AssertMeasurementProbability` operations simply return `()` with no other effect.

The <xref:microsoft.quantum.diagnostics> namespace provides several more functions of the `Assert` family, with which you can check more advanced conditions. 

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

The first row provides a comment with the ids of the corresponding qubits in their significant order.
The rest of the rows describe the probability amplitude of measuring the basis state vector $\ket{n}$ in both Cartesian and polar formats. In detail for the first row:

* **`∣0❭:`** this row corresponds to the `0` computational basis state
* **`0.707107 +  0.000000 i`**: the probability amplitude in Cartesian format.
* **` == `**: the `equal` sign separates both equivalent representations.
* **`**********  `**: A graphical representation of the magnitude, the number of `*` is proportionate to the probability of measuring this state vector.
* **`[ 0.500000 ]`**: the numeric value of the magnitude
* **`    ---`**: A graphical representation of the amplitude's phase (see the following output).
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
  > The id of a qubit is assigned at runtime and is not necessarily aligned with the order in which the qubit was allocated or its position within a qubit register.


#### [Visual Studio 2019](#tab/tabid-vs2019)

  > [!TIP]
  > You can locate a qubit id in Visual Studio by putting a breakpoint in your code and inspecting the value of a qubit variable, for example:
  > 
  > ![show qubit id in Visual Studio](~/media/qubit_id.png)
  >
  > the qubit with index `0` on `register2` has id=`3`, the qubit with index `1` has id=`2`.

#### [Command Line / Visual Studio Code](#tab/tabid-vscode)

  > [!TIP]
  > You can locate a qubit id by using the <xref:microsoft.quantum.intrinsic.message> function and passing the qubit variable in the message, for example:
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

Since <xref:microsoft.quantum.diagnostics.dumpmachine> is part of the  <xref:microsoft.quantum.diagnostics> namespace, you must add an `open` statement to access it:

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

<xref:microsoft.quantum.diagnostics.dumpregister> works like <xref:microsoft.quantum.diagnostics.dumpmachine>, except that it also takes an array of qubits to limit the amount of information to only that relevant to the corresponding qubits.

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

On top of `Assert` and `Dump` functions and operations, Q# supports a subset of standard Visual Studio debugging capabilities: [setting line breakpoints](https://docs.microsoft.com/visualstudio/debugger/using-breakpoints), [stepping through code using F10](https://docs.microsoft.com/visualstudio/debugger/navigating-through-code-with-the-debugger), and [inspecting values of classic variables](https://docs.microsoft.com/visualstudio/debugger/autos-and-locals-windows) are all possible during code execution on the simulator.

Debugging in Visual Studio Code leverages the debugging capabilities provided by the C# for Visual Studio Code extension powered by OmniSharp and requires installing the [latest version](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp). 

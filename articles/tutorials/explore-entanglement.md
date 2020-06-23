---
title: Explore entanglement with Q#
description: Learn how to write a quantum program in Q#. Develop a Bell State application using the Quantum Development Kit (QDK)
author: natke
ms.author: nakersha 
ms.date: 05/29/2020
ms.topic: tutorial
uid: microsoft.quantum.write-program
---

# Tutorial: Explore entanglement with Q\#

In this tutorial, we show you how to write a Q# program that manipulates and
measures qubits and demonstrates the effects of superposition and entanglement.

You will write an application called Bell to demonstrate quantum entanglement.
The name Bell is in reference to Bell states, which are specific quantum states
of two qubits that are used to represent the simplest examples of superposition
and quantum entanglement.

## Pre-requisites

If you are ready to start coding, follow these steps before proceeding: 

* [Install](xref:microsoft.quantum.install) the Quantum Development Kit using
  your  preferred language and development environment.
* If you already have the QDK installed, make sure you have
  [updated](xref:microsoft.quantum.update) to the latest version

You can also follow along with the narrative without installing the QDK,
reviewing  the overviews of the Q# programming language and the first concepts
of quantum computing.

## In this tutorial, you'll learn how to:

> [!div class="checklist"]
> * Create and combine operations in Q\#
> * Create operations to put qubits in superposition, entangle and measure them.
> * Demonstrate quantum entanglement with a Q# program run in a simulator. 

## Demonstrating qubit behavior with the QDK

Where classical bits hold a single binary value such as a 0 or 1, the state of a
[qubit](xref:microsoft.quantum.glossary#qubit) can be in a **superposition** of
0 and 1.  Conceptually, the state of a qubit can be thought of as a direction in an abstract
space (also known as a vector).  A qubit state can be in any of the possible
directions. The two **classical states** are the two directions; representing
100% chance of measuring 0 and 100% chance of measuring 1.

The act of measurement produces a binary result and changes a qubit state.
Measurement  produces a binary value, either 0 or 1.  The qubit goes from being
in superposition (any direction) to one of the classical states.  Thereafter,
repeating the same measurement without any intervening operations produces the
same binary result.  

Multiple qubits can be
[**entangled**](xref:microsoft.quantum.glossary#entanglement).  When we make a
measurement of one entangled qubit, our knowledge of the state of the other(s)
is updated as well.

Now, we're ready to demonstrate how Q# expresses this behavior.  You start with
the simplest program possible and build it up to demonstrate quantum
superposition and quantum entanglement.

## Creating a Q# project

The first thing we have to do is to create a new Q# project. In this tutorial
we are going to use the environment based on [command line applications with
VS Code](xref:microsoft.quantum.install.standalone).

To create a new project, in VS Code: 

1. Click **View** -> **Command Palette** and select **Q#: Create New Project**.
2. Click **Standalone console application**.
3. Navigate to the location to save the project and click **Create Project**.
4. When the project is successfully created, click **Open new project...** in the
   lower right.

In this case we called the project `Bell`. This generates two files:
`Bell.csproj`, the project file and `Program.qs`, a template of a Q# application
that we will use to write our application. The content of `Program.qs` should
be:

```qsharp
namespace Bell {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;
    

    @EntryPoint()
    operation HelloQ() : Unit {
        Message("Hello quantum world!");
    }
}
```

## Write the Q\# application
 
Our goal is to prepare two qubits in a specific quantum state, demonstrating how
to operate on qubits with Q# to change their state and demonstrate the effects
of superposition and entanglement. We will build this up piece by piece to
introduce qubit states, operations, and measurement.

### Initialize qubit using measurement

In the first code below, we show you how to work with qubits in
Q#.  We’ll introduce two operations, [`M`](xref:microsoft.quantum.intrinsic.m) and [`X`](xref:microsoft.quantum.intrinsic.x) that transform the state of a
qubit. In this code snippet, an operation `Set` is defined that takes as a parameter a
qubit and another parameter, `desired`, representing the state that we would
like the qubit to be in.  The operation `Set` performs a measurement on the
qubit using the operation `M`.  In Q#, a qubit measurement always returns either
`Zero` or `One`.  If the measurement returns a value not equal to the desired
value, `Set` “flips” the qubit; that is, it executes an `X` operation, which
changes the qubit state to a new state in which the probabilities of a
measurement returning `Zero` and `One` are reversed. This way, `Set` always puts
the target qubit in the desired state.

Replace the contents of `Program.qs` with the following code:

    ```qsharp
    namespace Bell {
        open Microsoft.Quantum.Intrinsic;
        open Microsoft.Quantum.Canon;

        operation Set(desired : Result, q1 : Qubit) : Unit {
            if (desired != M(q1)) {
                X(q1);
            }
        }
    }
    ```

This operation may now be called to set a qubit to a classical state, either
returning `Zero` 100% of the time or returning `One` 100% of the time.
`Zero` and `One` are constants that represent the only two possible results
of a measurement of a qubit.

The operation `Set` measures the qubit. If the qubit is in the state we
want, `Set` leaves it alone; otherwise, by executing the `X` operation, we
change the qubit state to the desired state.

#### About Q# operations

A Q# operation is a quantum subroutine. That is, it is a callable routine that
contains calls to other quantum operations.

The arguments to an operation are specified as a tuple, within parentheses.

The return type of the operation is specified after a colon. In this case, the
`Set` operation has no return, so it is marked as returning `Unit`. This is the
Q# equivalent of `unit` in F#, which is roughly analogous to `void` in C#, and
an empty tuple (`Tuple[()]`) in Python.

You have used two quantum operations in your first Q# operation:

* The [M](xref:microsoft.quantum.intrinsic.m) operation, which measures the
  state of the qubit
* The [X](xref:microsoft.quantum.intrinsic.x) operation, which flips the state
  of a qubit

A quantum operation transforms the state of a qubit. Sometime people talk about
quantum gates instead of operations, in analogy to classical logic gates. This
is rooted in the early days of quantum computing when algorithms were merely a
theoretical construct and visualized as diagrams similarly to circuit diagrams
in classical computing.

### Counting measurement outcomes

To demonstrate the effect of the `Set` operation, a
`TestBellState` operation is then added. This operation takes as input a `Zero`
or `One`, and calls the `Set` operation some number of times with that input,
and counts the number of times that `Zero` was returned from the measurement of
the qubit and the number of times that `One` was returned. Of course, in this
first simulation of the `TestBellState` operation, we expect that the output
will show that all measurements of the qubit set with `Zero` as the parameter
input will return `Zero`, and all measurements of a qubit set with `One` as the
parameter input will return `One`. Further on, we’ll add code to `TestBellState`
to demonstrate superposition and entanglement.

Add the following operation to the `Bell.qs` file, inside the namespace,
   after the end of the `Set` operation:

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
        Message("Test results (# of 0s, # of 1s): ");
        return (count - numOnes, numOnes);
    }
    ```
Note that we added a line before the `return` to print an explanatory message in
the console with the function (`Message`)[microsoft.quantum.intrinsic.message]

This operation (`TestBellState`) will loop for `count` iterations, set a
specified `initial` value on a qubit and then measure (`M`) the result. It
will gather statistics on how many zeros and ones we've measured and return
them to the caller. It performs one other necessary operation. It resets the
qubit to a known state (`Zero`) before returning it allowing others to
allocate this qubit in a known state. This is required by the `using`
statement.

#### About variables in Q\#

By default, variables in Q# are immutable; their value may not be changed after
they are bound. The `let` keyword is used to indicate the binding of an
immutable variable. Operation arguments are always immutable.

If you need a variable whose value can change, such as `numOnes` in the example,
you can declare the variable with the `mutable` keyword. A mutable variable's
value may be changed using a `set` statement.

In both cases, the type of a variable is inferred by the compiler. Q# doesn't
require any type annotations for variables.

#### About `using` statements in Q\#

The `using` statement is also special to Q#. It is used to allocate qubits for
use in a block of code. In Q#, all qubits are dynamically allocated and
released, rather than being fixed resources that are there for the entire
lifetime of a complex algorithm. A `using` statement allocates a set of qubits
at the start, and releases those qubits at the end of the block.

## Execute the code from the command line

In order to run the code we need to specify the compiler *which* callable to run
when we provide the `dotnet run` command. This is done with a simple change in
the Q# file by adding a line with `@EntryPoint()` directly preceding the
callable: the `TestBellState` operation in this case. The full code should be:

```qsharp
namespace Bell {
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Set(desired : Result, target : Qubit) : Unit {
        if (desired != M(target)) {
            X(target);
        }
    }

    @EntryPoint()
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
    Message("Test results (# of 0s, # of 1s): ");
    return (count - numOnes, numOnes);
    }
}
```

To run the program we need to specify `count` and `initial` arguments from the
command line. Let's choose for example `count = 1000` and `initial = One`. Enter
the following command:

```dotnetcli
dotnet run --count 1000 --initial One
```

And you should observe the following output:

```output
Test results (# of 0s, # of 1s):
(0, 1000)
```

If you try with `initial = Zero` you should observe:

```dotnetcli
dotnet run --count 1000 --initial Zero
```
```output
Test results (# of 0s, # of 1s):
(1000, 0)
```

## Prepare superposition

Now let’s look at how Q# expresses ways to put qubits in
superposition.  Recall that the state of a qubit can be in a superposition of 0
and 1.  We’ll use the `Hadamard` operation to accomplish this. If the qubit is
in either of the classical states (where a measurement returns `Zero` always or
`One` always), then the `Hadamard` or `H` operation will put the qubit in a
state where a measurement of the qubit will return `Zero` 50% of the time and
return `One` 50% of the time.  Conceputually, the qubit can be thought of as
halfway between the `Zero` and `One`.  Now, when we simulate the `TestBellState`
operation, we will see the results will return roughly an equal number of `Zero`
and `One` after measurement.  

### `X` flips qubit state

First we'll just try to flip the qubit (if the qubit is in `Zero` state will
flip to `One` and vice versa). This is accomplished by performing an `X`
operation before we measure it in `TestBellState`:

```qsharp
X(qubit);
let res = M(qubit);
```

Now the results are reversed:

```dotnetcli
dotnet run --count 1000 --initial One
```

```output
Test results (# of 0s, # of 1s):
(1000, 0)
```

```dotnetcli
dotnet run --count 1000 --initial Zero
```
```output
Test results (# of 0s, # of 1s):
(0, 1000)
```

Now let's explore the quantum properties of the qubits.

### `H` prepares superposition

All we need to do is replace the `X` operation in the previous run with an `H`
or Hadamard operation. Instead of flipping the qubit all the way from 0 to 1, we
will only flip it halfway. The replaced lines in `TestBellState` now look like:

```qsharp
H(qubit);
let res = M(qubit);
```

Now the results get more interesting:

```dotnetcli
dotnet run --count 1000 --initial One
```

```output
Test results (# of 0s, # of 1s):
(496, 504)
```

```dotnetcli
dotnet run --count 1000 --initial Zero
```

```output
Test results (# of 0s, # of 1s):
(506, 494)
```

Every time we measure, we ask for a classical value, but the qubit is halfway
between 0 and 1, so we get (statistically) 0 half the time and 1 half the time.
This is known as **superposition** and gives us our first real view into a
quantum state.

## Prepare entanglement

Now let’s look at how Q# expresses ways to entangle qubits.
First, we set the first qubit to the initial state and then use the `H`
operation to put it into superposition.  Then, before we measure the first
qubit, we use a new operation (`CNOT`), which stands for Controlled-NOT.  The
result of executing this operation on two qubits is to flip the second qubit if
the first qubit is `One`.  Now, the two qubits are entangled.  Our statistics
for the first qubit haven't changed (50-50 chance of a `Zero` or a `One` after
measurement), but now when we measure the second qubit, it is __always__ the
same as what we measured for the first qubit. Our `CNOT` has entangled the two
qubits, so that whatever happens to one of them, happens to the other. If you
reversed the measurements (did the second qubit before the first), the same
thing would happen. The first measurement would be random and the second would
be in lock step with whatever was discovered for the first.

The first thing we'll need to do is allocate two qubits instead of one in
`TestBellState`:

```qsharp
using ((q0, q1) = (Qubit(), Qubit())) {
```

This will allow us to add a new operation (`CNOT`) before we measure  (`M`) in
`TestBellState`:

```qsharp
Set(initial, q0);
Set(Zero, q1);

H(q0);
CNOT(q0, q1);
let res = M(q0);
```

We've added another `Set` operation to initialize the first qubit to make sure
that it's always in the `Zero` state when we start.

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

If we run this, we'll get exactly the same 50-50 result we got before. However,
what we're interested in is how the second qubit reacts to the first being
measured. We'll add this statistic with a new version of the `TestBellState`
operation:

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

        // Return times we saw |0>, times we saw |1>, and times measurements agreed
        Message("Test results (# of 0s, # of 1s, # of agreements)");
        return (count-numOnes, numOnes, agree);
    }
```

The new return value (`agree`) keeps track of every time the measurement from
the first qubit matches the measurement of the second qubit.

Running the code we obtain:

```dotnetcli
dotnet run --count 1000 --initial One
```
```output
(505, 495, 1000)
```
```dotnetcli
dotnet run --count 1000 --initial Zero
```
```output
Test results (# of 0s, # of 1s, # of agreements)
(507, 493, 1000)
```

As stated in the overview, our statistics for the first qubit haven't changed
(50-50 chance of a 0 or a 1), but now when we measure the second qubit, it is
__always__ the same as what we measured for the first qubit, because they are
entangled!

## Next steps

The tutorial [Grover’s search](xref:microsoft.quantum.quickstarts.search) shows
you how to build and run Grover search, one of the most popular quantum
computing algorithms and offers a nice example of a Q# program that can be used
to solve real problems with quantum computing.  

[Get Started with the Quantum Development Kit](xref:microsoft.quantum.welcome)
recommends more ways to learn Q# and quantum programming.

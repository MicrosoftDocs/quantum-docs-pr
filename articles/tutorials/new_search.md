---
title: Implement Grover's search algorithm in Q# - Quantum Development Kit
description: Build a Q# project that demonstrates Grover's algorithm, one of the canonical quantum algorithms.
author: geduardo
ms.author: v-edsanc
ms.date: 11/30/2020
ms.topic: article
uid: microsoft.quantum.quickstarts.new-search
no-loc: ['Q#', '$$v']
---

# Tutorial: Implement Grover's search algorithm in Q\#

In this tutorial you'll learn to implement Grover's algorithm in Q# to solve search based problems.

Grover's algorithm is one of the most famous algorithms in quantum computing. The problem it solves is often referred to as "searching a database", but it's more accurate to think of it as a "search problem".

> [!NOTE] 
> This tutorial is intended for people who are already familiar with
> Grover's algorithm that want to learn how to implement it in Q#. For a more
> slow paced tutorial we recommend the Microsoft Learn module [Solve graph
> coloring problems by using Grover's
> search](https://docs.microsoft.com/learn/modules/solve-graph-coloring-problems-grovers-search/).

Any searching task can be mathematically formulated with an abstract function $f(x)$ that accepts search items $x$. If the item $x$ is a solution for the search task, then $f(x)=1$. If the item $x$ isn't a solution, then $f(x)=0$. The search problem consists on finding any item $x_0$ such that $f(x_0)=1$. This is, an item $x_0$ that is a solution of the search problem.

## Grover's algorithm task

You are given a classical function $f(x):\\{0,1\\}^n \rightarrow\\{0,1\\}$. The task solved by Grover's algorithm is to find an input $x_0$ for which $f(x_0)=1$.

## Overview of the process

To implement Grover's algorithm to solve a problem you need to:

1. **Transform the problem to the form of a Grover's task:** for example, suppose we want to find the factors of an integer $M$ using Grover's algorithm. You can transform the integer factorization problem to a Grover's task by creating a function $$f_M(x)=1[r],$$ where $1[r]=1$ if $r=0$ and $1[r]=0$ if $r\neq0$ and $r$ is the remainder of $M/x$. This way, the integers $x_i$ that make $f_M(x_i)=1$ are the factors of $M$ and we transformed the problem to a Grover's task.
1. **Implement the function of the Grover's task as a quantum oracle:** to implement Grover's algorithm, you need to implement the function $f(x)$ of your Grover's task as a [quantum oracle](xref:microsoft.quantum.concepts.oracles).
1. **Use Grover's algorithm with your oracle to solve the task:** once you have quantum oracle, you can plug it into your Grover's algorithm implementation to solve the problem and interpret the output.

## Quick overview of Grover's algorithm

Suppose we have $N=2^n$ eligible items for the search task and we index them by assigning each item a integer from $0$ to
$N-1$. The steps of the algorithm are:

1. Start with a register of $n$ qubits initialized in the state $\ket{0}$ by applying $H$ to each qubit of the register.
1. Prepare the register into a uniform superposition: $$|\psi\rangle=\frac{1}{N^{1 / 2}} \sum_{x=0}^{N-1}|x\rangle$$
1. Apply $N_{\text{optimal}}$ times the following operations to the register:
   1. The phase oracle $O_f$ that applies a conditional phase shift of $-1$ for the solution items.
   1. Apply $H$ to each qubit of the register.
   1. A conditional phase shift of $-1$ to every computational basis state except $\ket{0}$.
   1. Apply $H$ to each qubit of the register.
1. Measure the register to obtain the index of a item that's a solution with very high probability.
1. Check if it's a valid solution. If not, start again.

## Write the code for Grover's algorithm

Now let's see how to implement the code in Q#.

### Grover's diffusion operator

First, we are going to write an operation that applies the steps **b**, **c** and **d** of the loop. These steps
are sometimes known as the Grover's diffusion operation.

```qsharp
operation ReflectAboutUniform(inputQubits : Qubit[]) : Unit {

    within {
        ApplyToEachA(H, inputQubits);
        ApplyToEachA(X, inputQubits);
    } apply {
        Controlled Z(Most(inputQubits), Tail(inputQubits));
    }

}
```

In this operation we use the [within-apply](xref:microsoft.quantum.qsharp.conjugations) statement that implements the
conjugation operations that occurs in the steps of the Grover's diffusion
operation.

> [!NOTE]
> To learn more about conjugations in Q#, check the [conjugations
> article in the Q# language guide](xref:microsoft.quantum.qsharp.conjugations).

You can check what each of the operations and functions used is by looking into
the API documentation:

- [`ApplyToEachA`](xref:Microsoft.Quantum.Canon.ApplyToEachA)
- [`Most`](xref:microsoft.quantum.arrays.most)
- [`Tail`](xref:microsoft.quantum.arrays.tail)

A good exercise to understand the code and the operations is to check with pen
and paper that the operation `ReflectAboutUniform` applies the Grover's
diffusion operation. To see it note that in `Controlled Z(Most(inputQubits),Tail(inputQubits))` only has an effect different than
the identity if and only if all qubits are in the state $\ket{1}$.

The operation is called `ReflectAboutUniform` because it can be geometrically
interpreted as a reflection in the ket space about the uniform superposition
state.

### Number of iterations

Grover's search has an optimal number of iterations that yields the highest probability of measuring a valid output. If the problem has $N$ possible eligible items, and $M$ of them are solutions to the problem, the optimal number of iterations is:

$$N_{\text{optimal}}\approx\frac{\pi}{4}\sqrt{\frac{N}{M}}$$

Continuing to iterate past that number starts reducing that probability until we reach nearly-zero success probability on iteration $2 N_{\text{optimal}}$. After that, the probability grows again and util $3 N_{\text{optimal}}$ and so on.

In practical applications, you don't usually know how many solutions your problem has before you solve it. An efficient strategy to handle this issue is to gradually increase the iteration number (for example: $2, 4, 8, 16, ..., 2^n$) and it will still find the solution with an average number of iterations around $\sqrt{\frac{N}{M}}$.

### Complete Grover's operation

Now we are ready to write the full operation a Grover's search. It will have three inputs:

- A qubit array `register : Qubit[]` that should be initialized in the all `Zero` state. This register will encode the tentative solution to the search problem. After the operation it will be measured.
- An operation `phaseOracle : ((Qubit[]) => Unit is Adj` that represents the phase oracle for the Grover's task. This operation applies an unitary transformation over a generic qubit register.
- An integer `iterations : Int` to represent the iterations of the algorithm.

```qsharp
operation RunGroversSearch(register : Qubit[], phaseOracle : ((Qubit[]) => Unit is Adj), iterations : Int) : Unit {
    // Prepare register into uniform superposition.
    ApplyToEach(H, register);
    // Start Grover's loop.
    for (_ in 1 .. iterations) {
        // Apply phase oracle for the task.
        phaseOracle(register);
        // Apply Grover's diffusion operation.
        ReflectAboutUniform(register);
    }
}
```

This code is generic - it can be used to solve any search problem. We pass the quantum oracle - the only operation that relies on the knowledge of the problem instance we want to solve - as a parameter to the search code.

## Implement the oracle

One of the key properties that makes Grover's algorithm faster is the ability of
quantum computers of performing calculations not only on individual inputs but
also on superpositions of inputs. We need to compute the function $f(x)$ that
describes the instance of a search problem using only quantum operations. This
way we can compute it over a superposition of inputs.

Unfortunately there isn't an automatic way to translate classical functions to
quantum operations. It's an open field of research in computer science called
*reversible computing*.

However, there are some guidelines that might help you to translate your
function $f(x)$ into a quantum oracle:

1. **Break down the classical function into small building blocks that are easy to implement.** For example, you can try
   to decompose your function $f(x)$ into a series of arithmetic operations or boolean logic gates.
1. **Use the higher-level building blocks of the Q# library operations to implement the intermediate operations.** For instance,
   if you decomposed your function into a combination of simple arithmetic operations, you can use the [Numerics library](xref:microsoft.quantum.arithmetic) to implement the intermediate operations. 

The following equivalence table might result you useful to implement boolean functions in Q#.

| Classical logic gate | Q# operation        |
|----------------|--------------------------|
| $NOT$          | `X`                      |
| $XOR$          | `CNOT`                   |
| $AND$          | `CCNOT` with an auxiliary qubit|

### Example: Quantum operation to check if a number is a divisor

> [!IMPORTANT]
> In this tutorial we are going to factorize a number using Grover's search algorithm as a didatic example to show how to translate a simple mathematical problem into a Grover's task. However, **Grover's algorithm is NOT an efficient algorithm to solve the integer factorization problem**. To explore a quantum algorithm that does solve the integer factorization problem faster than any classical algorithm check the [**Shor's algorithm** sample](https://github.com/microsoft/Quantum/tree/main/samples/algorithms/integer-factorization).

As an example, let's see how we would express the function $f_M(x)=1[r]$ of the factoring problem as quantum operation in Q#.

Classically, we would compute the rest of the division $M/x$ and check if it's equal to zero. If it is, the program outputs `1` and if it's not, the program outputs `0`. We need to:

- Compute the remainder of the division.
- Apply a controlled operation over the output bit so that it's `1` if the remainder is `0`.

So we need to calculate a division of two numbers with a quantum operation. Fortunately, you don't need to write the circuit implementing the division from scratch, you can use [`DivideI`](xref:microsoft.quantum.arithmetic.dividei) operation of the Numerics library instead.

If we look into the description of `DivideI` we see that it needs three qubit registers, the $n$-bit dividend `xs`, the $n$-bit divisor `ys` and the
$n$-bit `result` that must be initialized in the state `Zero`. The operation is `Adj + Ctl`, so we can conjugate it and use it in *within-apply* statements. Also, in the description it says that the dividend in the input register `xs` is replaced by the remainder. This is perfect since we are interested exclusively in the remainder, and not in the result of the operation.

We can build then a quantum operation that does the following:

1. Takes three inputs:
   - The dividend `number`: `Int`, this is the $M$ of $f_M(x)$.
   - A qubit array encoding the divisor `divisorRegister : Qubit[]`, this is, $x$, that might be in a superposition state.
   - A target qubit `target : Qubit` that flips if the output of $f_M(x)$ is $1$.
1. Calculates the division $M/x$ using only reversible quantum operations, and flips the state of `target` if and only if the remainder is zero.
1. Reverts all the operations except the flipping of `target` to leave the used auxiliary qubits in the zero state without introducing any irreversible operation like measurement. This step is important to preserve entanglement and superposition during the process.

The code to implement this quantum operation is:

```qsharp
operation markingDivisor (
    dividend : Int,
    divisorRegister : Qubit [],
    target : Qubit
) : Unit is Adj+Ctl {
    // Calculate the bit-size of the dividend.
    let size = BitSizeI(dividend);
    // Allocate two new qubit registers for the dividend and the result.
    using ( (dividendQubits, resultQubits) = (Qubit[size], Qubit[size]) ){
        // Create new LittleEndian instances from the registers to use DivideI
        let xs = LittleEndian(dividendQubits);
        let ys = LittleEndian(divisorRegister);
        let result = LittleEndian(resultQubits);

        // Start a within-apply statement to perform the operation.
        within{
            // Encode the dividend in the register.
            ApplyXorInPlace(dividend, xs);
            // Apply the division operation.
            DivideI(xs, ys, result);
            // Flip all the qubits from the remainder.
            ApplyToEachA(X, xs!);
        }
        apply{
            // Apply a controlled NOT over the flipped remainder.
            Controlled X(xs!, target);
            // The target flips if and only if the remainder is 0.
        }
    }
}
```

> [!NOTE]
> We take advantage of the statement *within-apply* to achieve the step 3. Alternatively we could write explicitly the adjoints of each of the operations inside the `within` block after the controlled flipping of `target`. The *within-apply* statement does it for us, making the code more readable and short. One of the main goals of Q# is to make quantum programs easy to write and read.

### Transform the operation into a phase oracle

The operation `markingDivisor` is what's known as a *marking oracle*, since it marks the valid items with an entangled auxiliary qubit (`target`). However, Grover's algorithm needs a *phase oracle*, this is, an oracle that applies a conditional phase shift of $-1$ for the solution items. But don't panic, the operation above isn't work in vain. It's very easy to switch from one to another with Q#.

We can apply any marking oracle as a phase oracle with the following operation:

```qsharp
operation ApplyMarkingOracleAsPhaseOracle(
    markingOracle : ((Qubit[], Qubit) => Unit is Adj), 
    register : Qubit[]
) : Unit is Adj {
    using (target = Qubit()) {
        within {
            X(target);
            H(target);
        } apply {
            markingOracle(register, target);
        }
    }
}
```

This famous transformation is often known as the *phase kickback* and it's widely used in many quantum computing algorithms. You can find a detailed explanation of this technique in the [Microsoft Learn module](https://docs.microsoft.com/learn/modules/solve-graph-coloring-problems-grovers-search/4-implement-quantum-oracle).

## Factoring numbers with a Grover's search

Now we have all the ingredients to implement the Grover's search algorithm to solve a mathematical problem. We just need to wrap-up everything.

Let's use the program to find a factor of 21. To simplify the code let's assume that we know the number $M$ of valid items. In this case $M=4$, since there are two factors, 3 and 7, plus 1 and 21 itself.

The code would be:

```qsharp
namespace GroversTutorial {
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Measurement;
    open Microsoft.Quantum.Math;
    open Microsoft.Quantum.Convert;
    open Microsoft.Quantum.Arithmetic;
    open Microsoft.Quantum.Arrays;

    @EntryPoint()
    operation FactorizeWithGrovers(number : Int) : Unit {
        
            // Define the oracle that for the factoring problem.
            let markingOracle = markingDivisor(number, _, _);
            let phaseOracle = ApplyMarkingOracleAsPhaseOracle(markingOracle, _);
            // Bit-size of the number to factorize.
            let size = BitSizeI(number);
            // Estimate of the number of solutions.
            let nSolutions = 4;
            // The number of iterations can be computed using the formula.
            let nIterations = Round(PI() / 4.0 * Sqrt(IntAsDouble(size) / IntAsDouble(nSolutions)));

            // Initialize the register to run the algorithm
            using ((register, output) = (Qubit[size], Qubit())){
                mutable isCorrect = false;
                mutable answer = 0;
                // Use a Repeat-Until-Succeed loop to iterate until the solution is valid.
                repeat {
                    RunGroversSearch(register, phaseOracle, nIterations);
                    let res = MultiM(register);
                    set answer = BoolArrayAsInt(ResultArrayAsBoolArray(res));
                    // Check that if the result is a solution with the oracle.
                    markingOracle(register, output);
                    if (MResetZ(output) == One and answer != 1 and answer != number) {
                        set isCorrect = true;
                    }
                    ResetAll(register);
                } until (isCorrect);

                // Print out the answer.
                Message($"The number {answer} is a factor of {number}.");
            }

    }

    operation markingDivisor (
        dividend : Int,
        divisorRegister : Qubit [],
        target : Qubit
    ) : Unit is Adj+Ctl {
        let size = BitSizeI(dividend);
        using ( (dividendQubits, resultQubits) = (Qubit[size], Qubit[size]) ){
            let xs = LittleEndian(dividendQubits);
            let ys = LittleEndian(divisorRegister);
            let result = LittleEndian(resultQubits);
            within{
                ApplyXorInPlace(dividend, xs);
                DivideI(xs, ys, result);
                ApplyToEachA(X, xs!);
            }
            apply{
                Controlled X(xs!, target);
            }
        }
    }

    operation ApplyMarkingOracleAsPhaseOracle(
        markingOracle : ((Qubit[], Qubit) => Unit is Adj), 
        register : Qubit[]
    ) : Unit is Adj {
        using (target = Qubit()) {
            within {
                X(target);
                H(target);
            } apply {
                markingOracle(register, target);
            }
        }
    }

    operation RunGroversSearch(register : Qubit[], phaseOracle : ((Qubit[]) => Unit is Adj), iterations : Int) : Unit {
        ApplyToEach(H, register);
        for (_ in 1 .. iterations) {
            phaseOracle(register);
            ReflectAboutUniform(register);
        }
    }

    operation ReflectAboutUniform(inputQubits : Qubit[]) : Unit {
        within {
            ApplyToEachA(H, inputQubits);
            ApplyToEachA(X, inputQubits);
        } apply {
            Controlled Z(Most(inputQubits), Tail(inputQubits));
        }
    }
    
}
```

### Run it with Visual Studio or Visual Studio Code

The program above will run the operation or function marked with the `@EntryPoint()` attribute on a simulator or resource estimator, depending on the project configuration and command-line options.

In Visual Studio, simply press Ctrl + F5 to run the script.

In VS Code, build the `Program.qs` the first time by typing the below in the terminal:

```Command line
dotnet build
```

For subsequent runs, there is no need to build it again. To run it, type the following command and press enter:

```Command line
dotnet run --no-build --number 21
```

Pressing enter should observe something like:

```Command line
The number 7 is a factor of 21.
```

## Extra: check the statistics with Python

How can you check that the algorithm is behaving correctly? For example, if we substitute the Grover's search by a random number generator in the code above after ~ $N$ attempts it will also find a factor.

Let's write a small Python script to check that program is working as it should.

> [!TIP]
> If you need help for running Q# operations within Python you can take a look to our [guide to use Python as a host program for Q#](xref:microsoft.quantum.guide.host-programs#python) and the [installation guide for Python](xref:microsoft.quantum.install.python).

First, we are going to modify slightly the code to get rid of the RUS loop so it outputs the first measurement after the Grover's search:

```qsharp
...

@EntryPoint()
operation FactorizeWithGrovers2(number : Int) : Int {

        let markingOracle = markingDivisor(number, _, _);
        let phaseOracle = ApplyMarkingOracleAsPhaseOracle(markingOracle, _);
        let size = BitSizeI(number);
        let nSolutions = 4;
        let nIterations = Round(PI() / 4.0 * Sqrt(IntAsDouble(size) / IntAsDouble(nSolutions)));

        using ((register) = Qubit[size] ){
            RunGroversSearch(register, phaseOracle, nIterations);
            let res = MultiM(register);
            return ResultArrayAsInt(res);
            // Check whether the result is correct.
        }
...
```

Note that we changed the output type from `Unit` to `Int`. This will be useful for the Python program.

The Python program is very simple. It just calls the operation `FactorizeWithGrovers2` several times and plots the results in a histogram.

The code is the following:

```python
import qsharp
qsharp.packages.add("Microsoft.Quantum.Numerics")
qsharp.reload()
from GroversTutorial import FactorizeWithGrovers2
import matplotlib.pyplot as plt
import numpy as np

def main():

    # Instantiate variables
    frequency =  {}
    N_Experiments = 1000
    results = []
    number = 21

    # Run N_Experiments times the Q# operation.
    for i in range(N_Experiments):
        print(f'Experiment: {i} of {N_Experiments}')
        results.append(FactorizeWithGrovers.simulate(number = number))

    # Store the results in a dictionary
    for i in results:
        if i in frequency:c
            frequency[i]=frequency[i]+1
        else:
            frequency[i]=1

    # Sort and print the results
    frequency = dict(reversed(sorted(frequency.items(), key=lambda item: item[1])))
    print('Output,  Frequency' )
    for k, v in frequency.items():
        print(f'{k:<8} {v}')
    
    # Plot an histogram with the results
    plt.bar(frequency.keys(), frequency.values())
    plt.xlabel("Output")
    plt.ylabel("Frequency of the outputs")
    plt.title("Outputs for Grover's factoring. N=21, 1000 iterations")
    plt.xticks(np.arange(1, 33, 2.0))
    plt.show()

if __name__ == "__main__":
    main()

```

The program generates the following histogram:

![alt_text=Histogram with the results of running several time the Grover's algorithm](~/media/grovers-histogram.png)

As you can see in the histogram, the algorithm outputs the solutions to the search problem (1, 3, 7 and 21) with much higher probability than the non-solutions. You can think of Grover's algorithm as a quantum random generator that is purposefully biased towards those indexes that are a solutions of the search problem.

## Next steps

Now that you now how to implement Grover's algorithm, try to transform a mathematical problem into a search task and solve it with Q# and the Grover's algorithm.
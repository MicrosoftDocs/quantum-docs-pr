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

You are given a classical function $f(x):\\{0,1\\}^N \rightarrow\\{0,1\\}$. The task solved by Grover's algorithm is to find an input $x_0$ for which $f(x_0)=1$.

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

### Grover's difussion operator

First, we are going to write an operation that applies the steps b., c. and d. of the loop. These steps
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

In this operation we use the *within-apply* statement that implements a the
conjugation operations that occurs in the steps of the Grover's diffusion
operation.

> [!NOTE]
> To learn more about conjugations in Q#, check the [conjugations
> article in the Q# language guide](xref:microsoft.quantum.qsharp.conjugations).

You can check what each of the operations and functions used is by looking into
the API documentation:

- [`ApplyToEachA`](xref:microsoft.quantum.canon.ApplyToEachA)
- [`Most`](xref:microsoft.quantum.arrays.Most)
- [`Tail`](xref:microsoft.quantum.arrays.Tail)

A good exercise to understand the code and the operations is to check with pen
and paper that the operation `ReflectAboutUniform` applies the Grover's
diffusion operation. To see it note that in `Controlled Z(Most(inputQubits),Tail(inputQubits))`, `Z` only has an effect different than
the identity and only if all qubits are in the state `\ket{1}`.

The operation is called `ReflectAboutUniform` because it can be geometrically
interpreted as a reflection in the ket space about the uniform superposition
state.

-------------------------------------------------------------TODO-------------------------------------------------------------

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
   to decompose your function $f(x)$ into a series of arithmetic operations or boolean logical gates.
1. **Use the higher-level building blocks implemented by Q# library operations to implement the intermediate operations.** For instance,
   if you decomposed your function into a combination of simple arithmetic operations, you can use the [Numerics library](xref:microsoft.quantum.arithmetic) to implement the intermediate operations. The following equivalence table might result you useful to implement boolean functions in Q#.

| Classical logic gate | Q# operation        |
|----------------|--------------------------|
| $NOT$          | `X`                      |
| $XOR$          | `CNOT`                   |
| $AND$          | `CCNOT` with an auxiliary qubit|

### Example: Quantum operation to check if a number is a divisor

As an example, let's see how we would express the function $f_M(x)=1[r]$ of the factoring problem as quantum operation in Q#.

Classically, we would compute the rest of the division $M/x$ and check if it's equal to zero. If it is, the program outputs `1` and if it's not, the program outpus `0`. We need to:

- Compute the remainder of the division.
- Apply a controlled operation over the output bit so that it's `1` if the remainder is `0`.

So we need to calculate a division of two numbers with a quantum operation. Fortunately, you don't need to write the circuit implementing the division from scratch, you can use [`DivideI`](xref:microsoft.quantum.arithmetic.DivideI) operation of the Numerics library instead.

If we look into the description of `DivideI` we see that it needs three qubit registers, the $n$-bit dividend `xs`, the $n$-bit divisor `ys` and the
$n$-bit `result` that must be initialized in the state `Zero`. The operation is `Adj + Ctl`, so we can conjugate it and use it in *within-apply* statements. Also, in the description it says that the dividend in the input register `xs` is replaced by the remainder. This is perfect since we are interested exclusively in the remainder, and not in the result of the operation.

We can build then a quantum operation that does the following:

- Takes three inputs:
  - The dividend `number`: `Int`.
  - A qubit array encoding the divisor `divisorRegister : Qubit[]` that might be in a superposition state.
  - A target qubit `target : Qubit` that represents the output of $f_M(x)$.

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

        // Start a within-apply statement to perform the opearion.
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

If the algorithm calls for a phase oracle, transform the marking oracle into a phase oracle.
This step uses a standard trick called phase kickback: that is, applying a marking oracle to an input array of qubits and a target qubit in a particular state will have the same effect on the input array as applying a phase oracle to it.


<!-- Any searching task can be mathematically formulated with an abstract function $f(x)$ that accepts search items $x$. If the item $x$ is a solution for the search task, then $f(x)=1$. If the item $x$ isn't a solution, then $f(x)=0$.

The search problem consists on finding any item $x_0$ such that $f(x_0)=1$. This is, an item $x_0$ that is a solution of the search problem.

Generally, we don't have access to the internal workings of $f$, but we can ask search queries by trying input items $x$ and observing the output.
 -->

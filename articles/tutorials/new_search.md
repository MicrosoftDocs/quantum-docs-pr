---
title: Run Grover's search algorithm in Q# - Quantum Development Kit
description: Build a Q# project that demonstrates Grover's algorithm, one of the canonical quantum algorithms.
author: cgranade
ms.author: chgranad
ms.date: 10/19/2019
ms.topic: article
uid: microsoft.quantum.quickstarts.new-search
no-loc: ['Q#', '$$v']
---

# Tutorial: Implement Grover's search algorithm in Q\#

In this tutorial you'll learn to implement Grover's algorithm in Q# to solve search based problems.

Grover's algorithm is one of the most famous algorithms in quantum computing. The problem it solves is often referred to as "searching a database", but it's more accurate to think of it as a "search problem".

> [!NOTE] This tutorial is intended for people who are already familiar with
> Grover's algorithm that want to learn how to implement it in Q#. For a more
> slow paced tutorial we recommend the Microsoft Learn module [Solve graph
> coloring problems by using Grover's
> search](https://docs.microsoft.com/learn/modules/solve-graph-coloring-problems-grovers-search/).

Any searching task can be mathematically formulated with an abstract function $f(x)$ that accepts search items $x$. If the item $x$ is a solution for the search task, then $f(x)=1$. If the item $x$ isn't a solution, then $f(x)=0$. The search problem consists on finding any item $x_0$ such that $f(x_0)=1$. This is, an item $x_0$ that is a solution of the search problem.

## Grover's algorithm task

You are given a classical function $f(x):\{0,1\}^N \right_arrow\{0,1\}$. The task solved by Grover's algorithm is to find an input $x_0$ for which $f(x_0)=1$.

## Overview of the process

To implement Grover's algorithm to solve a problem you need to:

1. **Transform the problem to the form of a Grover's task:** for example, suppose we want to find the factors of an integer $M$ using Grover's algorithm. You can transform the integer factorization problem to a Grover's task by creating a function $$f_M(x)=1[r],$$ where $1[r]=1$ if $r=0$ and $1[r]=0$ if $r\neq0$ and $r$ is the remainder of $M/x$. This way, the integers $x_i$ that make $f_M(x_i)=1$ are the factors of $M$ and we transformed the problem to a Grover's task.
1. **Implement the function of the Grover's task as a quantum oracle:** to implement Grover's algorithm, you need to implement the function $f(x)$ of your Grover's task as a [quantum oracle](xref:microsoft.quantum.concepts.oracles).
1. **Use Grover's algorithm with your oracle to solve the task:** once you have quantum oracle, you can plug it into your Grover's algorithm implementation to solve the problem and interpret the output.

<!-- Any searching task can be mathematically formulated with an abstract function $f(x)$ that accepts search items $x$. If the item $x$ is a solution for the search task, then $f(x)=1$. If the item $x$ isn't a solution, then $f(x)=0$.

The search problem consists on finding any item $x_0$ such that $f(x_0)=1$. This is, an item $x_0$ that is a solution of the search problem.

Generally, we don't have access to the internal workings of $f$, but we can ask search queries by trying input items $x$ and observing the output.
 -->

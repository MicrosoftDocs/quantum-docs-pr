---
title: The Q# Programming Language | Microsoft Docs 
description: The Q# Programming Language
author: QuantumWriter
ms.author: Alan.Geller@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
uid: microsoft.quantum.language.intro
---

# The Q# Programming Language

# Introduction

A natural model for quantum computation is to treat the quantum computer
as a coprocessor, similar to that used for GPUs, FPGAs, and other adjunct
processors.
The primary control logic runs classical code on a classical "host" computer.
When appropriate and necessary, the host program can invoke a subroutine
that runs on the adjunct processor.
When the subroutine completes, the host program gets access to the
subroutine's results.

Q# (Q-sharp) is a domain-specific programming language used for
expressing quantum algorithms.
It is to be used for writing subroutines that execute on an adjunct
quantum processor, under the control of a classical host program and computer.
Until quantum processors are widely available, Q# subroutines execute on a simulator.

Q# provides a small set of primitive types, along with two ways
(arrays and tuples) for creating new, structured types.
It supports a basic procedural model for writing programs,
with loops and if/then statements.
The top-level constructs in Q# are user defined types, operations,
and functions.

The following sections detail:
- [The Type Model](xref:microsoft.quantum.language.type-model)
- [Expressions](xref:microsoft.quantum.language.expressions)
- [Statements](xref:microsoft.quantum.qsharp-ref.statements)
- [File Structure](xref:microsoft.quantum.qsharp-ref.file-structure)

# Conventions

We are working to ensure that common punctuation marks are used consistently in all situations.
We expect that this will make Q# easier to learn and to read because these marks
always mean the same thing, and the same concept is always represented the same way.

Specifically:

- The semi-colon, `;`, is used to end a statement or single-line directive.
  It is not used for any other purpose.
- The comma, `,`, is used to separate elements of a sequence. It is used for tuple literals,
  array literals, argument lists, tuple definitions, and type lists. **In a change from earlier
  versions, `;` is no longer supported as an array literal separator.**
- The colon, `:`, is used to introduce a type annotation. It is primarily used in callable signatures.
  Because colon always introduces a type signature, the ternary conditional operator introduced in 0.3
  uses a vertical bar, `|`, to separate the true and false values; thus, Q# uses `cond ? tval | fval`
  instead of the colon as separator as in C.
  

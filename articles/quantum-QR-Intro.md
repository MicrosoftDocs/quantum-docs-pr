---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Intent and product brand in a unique string of 43-59 chars including spaces | Microsoft Docs 
description: 115-145 characters including spaces. Edit the intro para describing article intent to fit here. This abstract displays in the search result.
services: service-name-with-dashes-AZURE-ONLY 
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: QuantumWriter
ms.author: MSFT-alias-person-or-DL
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# ms.service: service-name-from-white-list
# product-name-from-white-list

# Optional fields. Don't forget to remove # if you need a field.
# ms.custom: can-be-multiple-comma-separated
# ms.devlang:devlang-from-white-list
# ms.suite: 
# ms.tgt_pltfrm:
# ms.reviewer:
# manager: MSFT-alias-manager-or-PM-counterpart
---

# The Q# Programming Language

# Introduction

A natural model for quantum computation is to treat the quantum computer 
as a coprocessor, similar to that used for GPUs, FPGAs, and other adjunct 
processors.
The primary control logic runs classical code on a classical "host" computer.
When appropriate and necessary, the host program can invoke a sub-program 
that runs on the adjunct processor.
When the sub-program completes, the host program gets access to the 
sub-program's results.

In this model, there are three levels of computation:

 - Classical computation that reads input data, sets up the quantum 
    computation, triggers the quantum computation, processes the results 
    of the computation, and presents the results to the user.
 - Quantum computation that happens directly in the quantum device and 
    implements a quantum algorithm.
 - Classical computation that is required by the quantum algorithm during 
    its execution.

There is no intrinsic requirement that these three levels all be written 
in the same language.
Indeed, quantum computation has somewhat different control structures and 
resource management needs than classical computation, so using a custom 
programming language allows common patterns in quantum algorithms to be 
expressed more naturally.

Keeping classical computations separate means that the quantum programming 
language may be very constrained.
These constraints may allow better optimization or faster execution 
of the quantum algorithm.

Q# (Q-sharp) is a domain-specific programming language used for 
expressing quantum algorithms.
It is to be used for writing sub-programs that execute on an adjunct 
quantum processor, under the control of a classical host program and computer.

Q# provides a small set of primitive types, along with two ways 
(arrays and tuples) for creating new, structured types. 
It supports a basic procedural model for writing programs, 
with loops and if/then statements. 
The top-level constructs in Q# are user defined types, operations, 
and functions.

The following sections detail:
- [The Type Model](quantum-QR-TypeModel.md)
- [Expressions](quantum-QR-Expressions.md)
- [Statements](quantum-QR-Statements.md)
- [File Structure](quantum-QR-FileStructure.md)
- [The Standard Library](quantum-QR-StandardLibrary.md)



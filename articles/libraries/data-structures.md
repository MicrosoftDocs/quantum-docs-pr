---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: "Q# standard libraries | Microsoft Docs"
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


## Data Structures and Modeling ##

### Oracles ###

One very common concept throughout quantum algorithms is that of a problem that can be specified in terms of a black-box quantum circuit.
That is, we allow an algorithm to apply a circuit to qubits of its choice, but not to look at how that circuit is defined.
This concept is often called an *oracle*, and is modeled in Q# by operations that accept qubit arrays as a part of their input.
There are a variety of different forms oracles can take, however.
To represent that, the canon provides a range of different user-defined types to label the ways that it might be convienent to represent a problem as an oracle.

<!-- TODO: summarize the following.

    - ReflectionOracle
    - ContinousOracle (FIXME: rename to ContinuousPhaseOracle)
    - DiscreteOracle (same FIXME)
    - StateOracle
    - DeterministicStateOracle
    - ObliviousOracle (FIXME: need to expand on the API docs here)
    - ProbabilityOracle (TODO: add this type.)

-->

### Dynamical Generator Modeling ###

### Classical Data Structures ###

Along with user-defined types for representing quantum concepts, the canon also provides operations, functions, and types for working with classical data used in the control of quantum systems.
For instance, the @"microsoft.quantum.canon.reverse" function takes an array as input and returns the same array in reverse order.
This can then be used on an array of type `Qubit[]` to avoid having to apply unnecessary $\operatorname{SWAP}$ gates when converting between quantum representations of integers.
Similarly, we saw in the previous section that types of the form `(Int, Int -> T)` can be useful for representing random access collections, so the @"microsoft.quantum.canon.lookupfunction" function provides a convienent way of constructing such types from array types.

<!-- TOOD: point out that MapIndex can be used to reconstruct an array from a lookup function. Also, write MapIndex. -->

#### Stacks ####

<!-- TODO -->

---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: "Testing | Q# standard libraries | Microsoft Docs"
description: 115-145 characters including spaces. Edit the intro para describing article intent to fit here. This abstract displays in the search result.
services: service-name-with-dashes-AZURE-ONLY 
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: vadym-kl
ms.author: vadym@microsoft.com
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

# Testing and debugging

We provide several function that built on top of `Microsoft.Quantum.Primitive.AssertProb`
 to help user test the correctness of the operations they implemented. These include: 

* [Checking if two operations are equal](#checking-equality-of-the-operations)
* [Checking that the qubit in the given state](#checking-that-the-qubit-is-in-the-given-state)
* [Helpers to iterate over a Cartesian products and powers](#iterating-over-cartesian-products-and-powers)
* [Asserts on classical values](#asserts-on-classical-values)

## Checking equality of the operations
There are three functions that assist witch checking the equality of quantum operations:

* [Microsoft.Quantum.Canon.AssertOperationsEqualReferenced](fixme.md)
* [Microsoft.Quantum.Canon.AssertOperationsEqualInPlace](fixme.md)
* [Microsoft.Quantum.Canon.AssertOperationsEqualInPlaceCompBasis](fixme.md)

First two functions ensure that two operations are equal. They differ in the number 
of calls to operations being tested and number of total qubits needed. The third operation 
checks equality only on computational basis states and can be particularly useful when 
used with the reversible simulators. First two operations use only Clifford gates 
in addition to calls to operations being tested. 

## Checking that the qubit is in the given state

We provide [Microsoft.Quantum.Canon.AssertQubit](fixme.md) to check if the qubit is 
in computational zero or one state. Operation [Microsoft.Quantum.Canon.AssertQubitState](fixme.md)
helps to check if the qubit is in the given state given by two dimensional complex vector.

## Iterating over Cartesian products and powers

There are two helper operations that help user to exhaustively go through possible options 
in their tests: 

* [Microsoft.Quantum.Canon.IterateThroughCartesianProduct](fixme.md)
* [Microsoft.Quantum.Canon.IterateThroughCartesianPower](fixme.md)

The example of use of these operations can be found in the implementation of 
[Microsoft.Quantum.Canon.AssertOperationsEqualInPlace](fixme.md).

## Asserts on classical values

We also provide a range of functions for asserting different properties of and relations between
classical values. These functions all start with prefix Assert and located in Microsoft.Quantum.Canon 
namespace.
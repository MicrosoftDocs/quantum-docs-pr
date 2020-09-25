---
title: Math in the Q# standard libraries
description: Learn about the classical math functions in the Q# standard libraries that are used with the built-in data types. 
author: cgranade
uid: microsoft.quantum.libraries.math
ms.author: chgranad
ms.date: 9/24/2020
ms.topic: article
no-loc: ['Q#', '$$v']
---

# Classical mathematical functions in Q#

The <xref:microsoft.quantum.math> namespace contains classical mathematical functions and data types. You use these functions primarily to work with the Q# built-in data types `Int`, `Double`, and `Range`. 

You can also find classical mathematical functions in other namespaces. For example, the <xref:microsoft.quantum.random.drawcategorical> operation, which has the signature `(Double[] => Int)`, takes an array of doubles as input, and returns a randomly-selected index into the array as an `Int`.
The probability of selecting a specific index is proportional to the value of the array element at that index.
The operation ignores all array elements that are equal to zero  and does not return their indices.
If any element in the array is less than zero, or if no array element is greater than zero, then the operation fails.

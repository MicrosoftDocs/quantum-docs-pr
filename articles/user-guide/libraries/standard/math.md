---
title: Math in the Q# standard libraries
description: Learn about the classical math functions in the Q# standard libraries that are used with the built-in data types. 
author: cgranade
uid: microsoft.quantum.libraries.math
ms.author: chgranad
ms.topic: article
no-loc: ['Q#', '$$v']
---

# Classical Mathematical Functions #

These functions are primarily used to work with the Q# built-in data types `Int`, `Double`, and `Range`.

The <xref:microsoft.quantum.intrinsic.random> operation has signature `(Double[] => Int)`.
It takes an array of doubles as input, and returns a randomly-selected index into the array as an `Int`.
The probability of selecting a specific index is proportional to the value of the array element at that index. n
Array elements that are equal to zero are ignored and their indices are never returned.
If any array element is less than zero, or if no array element is greater than zero, then the operation fails.

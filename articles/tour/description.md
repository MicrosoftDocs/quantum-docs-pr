---
title: Description of Q#
description: Q# description
author: MikeDodaro
ms.author: Cathy.Palmer@microsoft.com
uid: microsoft.quantum.tour.description
ms.date: 05/02/2019
ms.topic: article
---

# Q# syntax and logic gates

The following code shows a Q# operation.  The term `operation` is applied to Q# code blocks that resemble functions in C#. Parameters of the operation are listed by name and type. In this example the name `qs` refers to an array of quibits. The parameter `oracle` is like a pointer to function. Following the colon, the `Adjoint` keyword specifies autogeneration of code that reverses the effect of the operation.  The return value in this case is void according to the `Unit` keyword.

The body of the operation includes a `for` loop similar to C# syntax.  The logic gate `H` sets a quibit to one of the nonbinary probability states, where the result depends on the starting value of the quibit.

````
operation ApproximateQFT (a: Int, qs: BigEndian, oracle: (BigEndian => Unit) : Adjoint) : Unit {
  body(...) {
    let nQubits = Length(qs!);

    for (i in 0 .. (nQubits - 1)) {
      for (j in 0..(i-1)) {
        if ((i-j) < a) {
          (Controlled R1Frac)([qs![i]], (1, i-j, qs![j]));
        }
      }

      H(qs![i]);
    }

    oracle(qs);
  }

  adjoint invert;
}

````
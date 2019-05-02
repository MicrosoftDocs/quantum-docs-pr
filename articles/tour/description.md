---
title: Description of Q#
description: Q# description
author: MikeDodaro
ms.author: Cathy.Palmer@microsoft.com
uid: microsoft.quantum.tour.description
ms.date: 05/02/2019
ms.topic: article
---

# Description of Q#

The following block of code shows a Q# operation.
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
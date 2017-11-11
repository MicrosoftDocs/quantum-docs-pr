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

# Putting it All Together: Teleportation #

Let's return to the example of the teleportation circuit defined in @qc_concepts <!-- TODO: more specific link. -->.

![](figures/teleportation.png){ width=50% }

We can now translate each of the steps in this quantum circuit into Q#.
First, we begin the definition of a new operation while will perform the teleportation given two qubits `msg` and `there`:

```qsharp
operation Teleport(msg : Qubit, there : Qubit) : () {
    body {
```

Next, we allocate a qubit `here` with a `using` block:

```qsharp
        using (register = Qubit[1]) {
            let here = register[0];
```

We can then create the entangled pair between `here` and `there` by using the @"microsoft.quantum.primitive.h" and @"microsoft.quantum.primitive.cnot" operations:

```qsharp
            H(here);
            CNOT(here, there);
```

We then use the next $\operatorname{CNOT}$ and $H$ gates to move our message qubit:

```qsharp
            CNOT(msg, here);
            H(msg);
```

Finally, we use @"microsoft.quantum.primitive.m" to perform the measurements and feed them into classical control, as denoted by `if` statements:

```qsharp
            // Measure out the entanglement.
            if (M(msg) == One)  { Z(there); }
            if (M(here) == One) { X(there); }
```

This finishes the definition of our teleportation operator, so we can deallocate `here`, end the body, and end the operation.

```qsharp
        }
    }
}
```

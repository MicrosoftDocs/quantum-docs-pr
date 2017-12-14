---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Q# techniques - putting it all together | Microsoft Docs 
description: Q# techniques - putting it all together
author: QuantumWriter
ms.author: Christopher.Granade@microsoft.com
ms.date: 12/11/2017
ms.topic: article
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# For Quantum products none of these categories have been defined  yet.
# ms.service: service-name-from-white-list
# ms.prod: product-name-from-white-list
# ms.technology: tech-name-from-white-list
---

# Putting it All Together: Teleportation #

Let's return to the example of the teleportation circuit defined in [Quantum Circuits](quantum-concepts-8-QuantumCircuits.md). Shown below is a text-book quantum circuit that implements the teleportation, including the quantum part, the measurements, and the classically-controlled correction operations.

![`Teleport(msg : Qubit, there : Qubit) : ()`](./media/teleportation.svg)

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

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
Let's return to the example of the teleportation circuit defined in [Quantum Circuits](quantum-concepts-8-QuantumCircuits.md). We're going to use this to illustrate the concepts we've learned so far. An explanation of quantum teleportation is provided below for those who are unfamiliar with the theory, followed by a walkthrough of the code implementation in Q#. 

## Quantum Teleportation: Theory
Quantum teleportation is a technique for sending an unknown quantum state (which we'll refer to as the '__message__') from a qubit in one location to a qubit in another location (we'll refer to these qubits as '__here__' and '__there__', respectively). We can represent our __message__ as a vector using Dirac notation: 

$$
|\psi\rangle = \alpha|0\rangle + \beta|1\rangle
$$

The __message__ qubit's state is unknown to us as we do not know the values of $\alpha$ and $\beta$.

### Step 1: Create an entangled state
In order to send the __message__ we need for the qubit __here__ to be entangled with the qubit __there__. This is achieved by applying a Hadamard gate, followed by a CNOT gate. Let's look at the math behind these gate operations.

We will begin with the qubits __here__ and __there__ both in the $|0\rangle$ state. After entangling these qubits, they are in the state:

$$
|\phi^+\rangle = \frac{1}{\sqrt{2}}(|00\rangle + |11\rangle)
$$

### Step 2: Send the message
To send the __message__ we first apply a CNOT gate with the __message__ qubit and __here__ qubit as input. This input state can be written:

$$
|\psi\rangle|\phi^+\rangle = (\alpha|0\rangle + \beta|1\rangle)(\frac{1}{\sqrt{2}}(|00\rangle + |11\rangle))
$$

This expands to:

$$
|\psi\rangle|\phi^+\rangle = \frac{\alpha}{\sqrt{2}}|000\rangle + \frac{\alpha}{\sqrt{2}}|011\rangle + \frac{\beta}{\sqrt{2}}|100\rangle + \frac{\beta}{\sqrt{2}}|111\rangle
$$

As a reminder, the CNOT gate flips the target qubit when the control qubit is 1. So for example, an input of $|000\rangle$ will result in no change as the first qubit (the control) is 0. However take a case where the first qubit is 1, for example an input of $|100\rangle$, then the output is $|110\rangle$ as the second qubit (the target) is flipped by the CNOT gate.

Let's now consider our output once the CNOT gate has acted on our input above. The result is:

$$
\frac{\alpha}{\sqrt{2}}|000\rangle + \frac{\alpha}{\sqrt{2}}|011\rangle + \frac{\beta}{\sqrt{2}}|110\rangle + \frac{\beta}{\sqrt{2}}|101\rangle
$$

The next step to send the __message__ is to apply a Hadamard gate to the __message__ qubit (that's the first qubit of each term). 

As a reminder, the Hadamard gate does the following:

Input | Output
------------ | ---------------------------------------------------------------
|0\rangle  | \frac{1}{\sqrt{2}}(|0\rangle + |1\rangle)
|1\rangle  | \frac{1}{\sqrt{2}}(|0\rangle - |1\rangle)

If we apply the Hadamard gate to the first qubit of each term of our output above, we get the following result:

$$
\frac{\alpha}{\sqrt{2}}(\frac{1}{\sqrt{2}}(|0\rangle + |1\rangle))|00\rangle + \frac{\alpha}{\sqrt{2}}(\frac{1}{\sqrt{2}}(|0\rangle + |1\rangle))|11\rangle + \frac{\beta}{\sqrt{2}}(\frac{1}{\sqrt{2}}(|0\rangle - |1\rangle))|10\rangle + \frac{\beta}{\sqrt{2}}(\frac{1}{\sqrt{2}}|0\rangle - |1\rangle))|01\rangle
$$

Note that each term has two $\frac{1}{\sqrt{2}}$ factors. We can multiply these out giving the following result:

$$
\frac{\alpha}{2}(|0\rangle + |1\rangle)|00\rangle + \frac{\alpha}{2}(|0\rangle + |1\rangle)|11\rangle + \frac{\beta}{2}(|0\rangle - |1\rangle)|10\rangle + \frac{\beta}{2}(|0\rangle - |1\rangle)|01\rangle
$$

The  $\frac{1}{2}$ factor is common to each term so we can now take it outside the brackets:

$$
\frac{1}{2}\big[\alpha(|0\rangle + |1\rangle)|00\rangle + \alpha(|0\rangle + |1\rangle)|11\rangle + \beta(|0\rangle - |1\rangle)|10\rangle + \beta(|0\rangle - |1\rangle)|01\rangle\big]
$$

We can then multiply out the brackets for each term giving:

$$
\frac{1}{2}\big[\alpha|000\rangle + \alpha|100\rangle + \alpha|011\rangle + \alpha|111\rangle + \beta|010\rangle - \beta|110\rangle + \beta|001\rangle - \beta|101\rangle\big]
$$

### Step 3: Measure the result

Due to __here__ and __there__ being entangled, the operations on __here__ in the previous step have altered __there__'s state. If we measure the first and second qubit (__message__ and __here__) we can learn what state __there__ is in, due to this property of entanglement. 

* If we measure and get a result 00, the superposition collapses, leaving only terms consistent with this result. That's $\alpha|000\rangle +\beta|001\rangle$. This can be refactored to $|00\rangle(\alpha|0\rangle +\beta|1\rangle)$. Therefore if we measure the first and second qubit to be 00, we know that the third qubit, __there__, is in the state $(\alpha|0\rangle +\beta|1\rangle)$.
* If we measure and get a result 01, the superposition collapses, leaving only terms consistent with this result. That's $\alpha|011\rangle +\beta|010\rangle$. This can be refactored to $|01\rangle(\alpha|1\rangle +\beta|0\rangle)$. Therefore if we measure the first and second qubit to be 01, we know that the third qubit, __there__, is in the state $(\alpha|1\rangle +\beta|0\rangle)$.
* If we measure and get a result 10, the superposition collapses, leaving only terms consistent with this result. That's $\alpha|100\rangle -\beta|101\rangle$. This can be refactored to $|10\rangle(\alpha|0\rangle -\beta|1\rangle)$. Therefore if we measure the first and second qubit to be 10, we know that the third qubit, __there__, is in the state $(\alpha|0\rangle -\beta|1\rangle)$.
* If we measure and get a result 11, the superposition collapses, leaving only terms consistent with this result. That's $\alpha|111\rangle -\beta|110\rangle$. This can be refactored to $|11\rangle(\alpha|1\rangle -\beta|0\rangle)$. Therefore if we measure the first and second qubit to be 11, we know that the third qubit, __there__, is in the state $(\alpha|1\rangle -\beta|0\rangle)$.

### Step 4: Interpret the result

As a reminder, the original __message__ we wished to send was:

$$
|\psi\rangle = \alpha|0\rangle + \beta|1\rangle
$$

We need to get the __there__ qubit into this state, so that the received state is the one that was intended. 

* If we measured and got a result of 00, then the third qubit, __there__, is in the state $(\alpha|0\rangle +\beta|1\rangle)$. You can see that this is the intended __message__ therefore we do not need to alter this state.
* If we measured and got a result of 01, then the third qubit, __there__, is in the state $(\alpha|1\rangle +\beta|0\rangle)$. This differs from the intended __message__, however applying a NOT gate gives us the desired state $(\alpha|0\rangle +\beta|1\rangle)$.
* If we measured and got a result of 10, then the third qubit, __there__, is in the state $(\alpha|0\rangle -\beta|1\rangle)$. This differs from the intended __message__, however applying a Z gate gives us the desired state $(\alpha|0\rangle +\beta|1\rangle)$.
* If we measured and got a result of 11, then the third qubit, __there__, is in the state $(\alpha|1\rangle -\beta|0\rangle)$. This differs from the intended __message__, however applying a NOT gate, followed by a Z gate, gives us the desired state $(\alpha|0\rangle +\beta|1\rangle)$.

To summarize, if we measure and the first qubit is 1, a Z gate is applied. If we measure and the second qubit is 1, a NOT gate is applied.

### Summary
Shown below is a text-book quantum circuit that implements the teleportation. Moving from left to right you can see:
1. Step 1: creating an entangled state by applying a Hadamard gate and CNOT gate. 
1. Step 2: sending the __message__ using a CNOT gate and a Hadamard gate.
1. Step 3: making a measurement of the first and second qubits, __message__ and __here__.
1. Step 4: applying a NOT gate or a Z gate, depending on the result of the measurement. 
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

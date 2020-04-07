---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Q# techniques - Putting it all together
description: Walk through a basic Q# program that demonstrates quantum teleportation. 
uid: microsoft.quantum.techniques.puttingittogether
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

# Putting It All Together: Teleportation #
Let's return to the example of the teleportation circuit defined in [Quantum Circuits](xref:microsoft.quantum.concepts.circuits). We're going to use this to illustrate the concepts we've learned so far. An explanation of quantum teleportation is provided below for those who are unfamiliar with the theory, followed by a walkthrough of the code implementation in Q#. 

## Quantum Teleportation: Theory
Quantum teleportation is a technique for sending an unknown quantum state (which we'll refer to as the '__message__') from a qubit in one location to a qubit in another location (we'll refer to these qubits as '__here__' and '__there__', respectively). We can represent our __message__ as a vector using Dirac notation: 

$$
\ket{\psi} = \alpha\ket{0} + \beta\ket{1}
$$

The __message__ qubit's state is unknown to us as we do not know the values of $\alpha$ and $\beta$.

### Step 1: Create an entangled state
In order to send the __message__ we need for the qubit __here__ to be entangled with the qubit __there__. This is achieved by applying a Hadamard gate, followed by a CNOT gate. Let's look at the math behind these gate operations.

We will begin with the qubits __here__ and __there__ both in the $\ket{0}$ state. After entangling these qubits, they are in the state:

$$
\ket{\phi^+} = \frac{1}{\sqrt{2}}(\ket{00} + \ket{11})
$$

### Step 2: Send the message
To send the __message__ we first apply a CNOT gate with the __message__ qubit and __here__ qubit as inputs (the __message__ qubit being the control and the __here__ qubit being the target qubit, in this instance). This input state can be written:

$$
\ket{\psi}\ket{\phi^+} = (\alpha\ket{0} + \beta\ket{1})(\frac{1}{\sqrt{2}}(\ket{00} + \ket{11}))
$$

This expands to:

$$
\ket{\psi}\ket{\phi^+} = \frac{\alpha}{\sqrt{2}}\ket{000} + \frac{\alpha}{\sqrt{2}}\ket{011} + \frac{\beta}{\sqrt{2}}\ket{100} + \frac{\beta}{\sqrt{2}}\ket{111}
$$

As a reminder, the CNOT gate flips the target qubit when the control qubit is 1. So for example, an input of $\ket{000}$ will result in no change as the first qubit (the control) is 0. However, take a case where the first qubit is 1 - for example an input of $\ket{100}$. In this instance, the output is $\ket{110}$ as the second qubit (the target) is flipped by the CNOT gate.

Let's now consider our output once the CNOT gate has acted on our input above. The result is:

$$
\frac{\alpha}{\sqrt{2}}\ket{000} + \frac{\alpha}{\sqrt{2}}\ket{011} + \frac{\beta}{\sqrt{2}}\ket{110} + \frac{\beta}{\sqrt{2}}\ket{101}
$$

The next step to send the __message__ is to apply a Hadamard gate to the __message__ qubit (that's the first qubit of each term). 

As a reminder, the Hadamard gate does the following:

Input | Output
---------------------------| ---------------------------------------------------------------
$\ket{0}$  | $\frac{1}{\sqrt{2}}(\ket{0} + \ket{1})$
$\ket{1}$  | $\frac{1}{\sqrt{2}}(\ket{0} - \ket{1})$

If we apply the Hadamard gate to the first qubit of each term of our output above, we get the following result:

$$
\frac{\alpha}{\sqrt{2}}(\frac{1}{\sqrt{2}}(\ket{0} + \ket{1}))\ket{00} + \frac{\alpha}{\sqrt{2}}(\frac{1}{\sqrt{2}}(\ket{0} + \ket{1}))\ket{11} + \frac{\beta}{\sqrt{2}}(\frac{1}{\sqrt{2}}(\ket{0} - \ket{1}))\ket{10} + \frac{\beta}{\sqrt{2}}(\frac{1}{\sqrt{2}}(\ket{0} - \ket{1}))\ket{01}
$$

Note that each term has two $\frac{1}{\sqrt{2}}$ factors. We can multiply these out giving the following result:

$$
\frac{\alpha}{2}(\ket{0} + \ket{1})\ket{00} + \frac{\alpha}{2}(\ket{0} + \ket{1})\ket{11} + \frac{\beta}{2}(\ket{0} - \ket{1})\ket{10} + \frac{\beta}{2}(\ket{0} - \ket{1})\ket{01}
$$

The  $\frac{1}{2}$ factor is common to each term so we can now take it outside the brackets:

$$
\frac{1}{2}\big[\alpha(\ket{0} + \ket{1})\ket{00} + \alpha(\ket{0} + \ket{1})\ket{11} + \beta(\ket{0} - \ket{1})\ket{10} + \beta(\ket{0} - \ket{1})\ket{01}\big]
$$

We can then multiply out the brackets for each term giving:

$$
\frac{1}{2}\big[\alpha\ket{000} + \alpha\ket{100} + \alpha\ket{011} + \alpha\ket{111} + \beta\ket{010} - \beta\ket{110} + \beta\ket{001} - \beta\ket{101}\big]
$$

### Step 3: Measure the result

Due to __here__ and __there__ being entangled, any measurement on __here__ will affect the state of __there__. If we measure the first and second qubit (__message__ and __here__) we can learn what state __there__ is in, due to this property of entanglement. 

* If we measure and get a result 00, the superposition collapses, leaving only terms consistent with this result. That's $\alpha\ket{000} +\beta\ket{001}$. This can be refactored to $\ket{00}(\alpha\ket{0} +\beta\ket{1})$. Therefore if we measure the first and second qubit to be 00, we know that the third qubit, __there__, is in the state $(\alpha\ket{0} +\beta\ket{1})$.
* If we measure and get a result 01, the superposition collapses, leaving only terms consistent with this result. That's $\alpha\ket{011} +\beta\ket{010}$. This can be refactored to $\ket{01}(\alpha\ket{1} +\beta\ket{0})$. Therefore if we measure the first and second qubit to be 01, we know that the third qubit, __there__, is in the state $(\alpha\ket{1} +\beta\ket{0})$.
* If we measure and get a result 10, the superposition collapses, leaving only terms consistent with this result. That's $\alpha\ket{100} -\beta\ket{101}$. This can be refactored to $\ket{10}(\alpha\ket{0} -\beta\ket{1})$. Therefore if we measure the first and second qubit to be 10, we know that the third qubit, __there__, is in the state $(\alpha\ket{0} -\beta\ket{1})$.
* If we measure and get a result 11, the superposition collapses, leaving only terms consistent with this result. That's $\alpha\ket{111} -\beta\ket{110}$. This can be refactored to $\ket{11}(\alpha\ket{1} -\beta\ket{0})$. Therefore if we measure the first and second qubit to be 11, we know that the third qubit, __there__, is in the state $(\alpha\ket{1} -\beta\ket{0})$.

### Step 4: Interpret the result

As a reminder, the original __message__ we wished to send was:

$$
\ket{\psi} = \alpha\ket{0} + \beta\ket{1}
$$

We need to get the __there__ qubit into this state, so that the received state is the one that was intended. 

* If we measured and got a result of 00, then the third qubit, __there__, is in the state $(\alpha\ket{0} +\beta\ket{1})$. As this is the intended __message__, no alteration is required.
* If we measured and got a result of 01, then the third qubit, __there__, is in the state $(\alpha\ket{1} +\beta\ket{0})$. This differs from the intended __message__, however applying a NOT gate gives us the desired state $(\alpha\ket{0} +\beta\ket{1})$.
* If we measured and got a result of 10, then the third qubit, __there__, is in the state $(\alpha\ket{0} -\beta\ket{1})$. This differs from the intended __message__, however applying a Z gate gives us the desired state $(\alpha\ket{0} +\beta\ket{1})$.
* If we measured and got a result of 11, then the third qubit, __there__, is in the state $(\alpha\ket{1} -\beta\ket{0})$. This differs from the intended __message__, however applying a NOT gate followed by a Z gate gives us the desired state $(\alpha\ket{0} +\beta\ket{1})$.

To summarize, if we measure and the first qubit is 1, a Z gate is applied. If we measure and the second qubit is 1, a NOT gate is applied.

### Summary
Shown below is a text-book quantum circuit that implements the teleportation. Moving from left to right you can see:
- Step 1: Entangling __here__ and __there__ by applying a Hadamard gate and CNOT gate.
- Step 2: Sending the __message__ using a CNOT gate and a Hadamard gate.
- Step 3: Taking a measurement of the first and second qubits, __message__ and __here__.
- Step 4: Applying a NOT gate or a Z gate, depending on the result of the measurement in step 3.

![`Teleport(msg : Qubit, there : Qubit) : Unit`](~/media/teleportation.svg)

## Quantum Teleportation: Code

We have our circuit for quantum teleportation:

![`Teleport(msg : Qubit, there : Qubit) : Unit`](~/media/teleportation.svg)

We can now translate each of the steps in this quantum circuit into Q#.

### Step 0: Definition
When we perform teleportation, we must know the __message__ we wish to send, and where we wish to send it (__there__). For this reason, we begin by defining a new Teleport operation that is given two qubits as arguments, `msg` and `there`:

```qsharp
operation Teleport(msg : Qubit, there : Qubit) : Unit {
```

We also need to allocate a qubit `here` which we achieve with a `using` block:

```qsharp
    using (here = Qubit()) {
```

### Step 1: Create an entangled state
We can then create the entangled pair between `here` and `there` by using the @"microsoft.quantum.intrinsic.h" and @"microsoft.quantum.intrinsic.cnot" operations:

```qsharp
        H(here);
        CNOT(here, there);
```

### Step 2: Send the message
We then use the next $\operatorname{CNOT}$ and $H$ gates to move our message qubit:

```qsharp
        CNOT(msg, here);
        H(msg);
```

### Step 3 & 4: Measuring and interpreting the result
Finally, we use @"microsoft.quantum.intrinsic.m" to perform the measurements and perform the necessary gate operations to get the desired state, as denoted by `if` statements:

```qsharp
        // Measure out the entanglement
        if (M(msg) == One)  { Z(there); }
        if (M(here) == One) { X(there); }
```

### Step 5: Restarting the qubit register

At the end of every Q# operation we need to let the qubits in the state $\ket{0}$. We can use @"microsoft.quantum.intrinsic.reset"
to restart all the qubits to the zero state and this will finish our operation.

```qsharp
        Reset(msg);
        Reset(here);
        Reset(there);
    }
}
```



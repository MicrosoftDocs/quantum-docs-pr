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

#Quantum Circuits
Consider for a moment the unitary transformation $\text{ CNOT}_{01}(H\otimes 1)$.  This gate sequence is of fundamental significance to quantum computing because it creates a maximally entangled two-qubit state:
$$\text{CNOT}_{01}(H\otimes 1)|00\rangle = \frac{1}{\sqrt{2}} \left(\ket{00} + \ket{11} \right),$$
Operations with this, or greater complexity, are ubiquitous in quantum algorithms and quantum error correction and so it should come as a great relief that there is a simple method for visualizing them called a quantum circuit diagram.  The circuit diagram for preparing this maximally entangled quantum state is

![](1.svg)

This visual language for quantum operations is obviously much more digestable than writing down its equivalent matrix once you understand the conventions for drawing a quantum circuit.  We review these conventions below.

In a circuit diagram, each solid line depicts a qubit or more generally a qubit register.  By convention, the top line is qubit register $0$ and the remainder are labeled sequentially. In the example of the above circuit, it is depicted as acting on two qubits (or equivalently two registers consisting of one qubit).  Gates acting on one or more qubit register are denoted as a box.  For example, the symbol

![](2.svg)

 is the Hadamard gate acting on the qubit register.

Quantum gates are ordered in chronological order with the left most gate being the gate that is applied to the qubits first.  In other words, if you picture the wire as holding the quantum state the wires draw the quantum state through each of the gates in a diagram from left to right.  That is to say 

![](3.svg)

 is the unitary matrix $CBA$.  This is because matrix multiplication obeys the opposite convention used in quantum circuit diagrams: the right most matrix is applied first but the left most gate in a quantum circuit is applied first.  Unfortunately, this difference leads to no end of confusion and so it is important to note this significant differences between the linear algebraic notation provided earlier and quantum circuit diagrams.

All the previous examples given have precisely the same number of wires (qubits) input to a quantum gate as the number of wires that store the output of the quantum gate.  It may seem reasonable that quantum circuits could have more, or fewer, outputs than inputs in general.  This is impossible, however, because all quantum operations, save measurement, are unitary and hence reversible.  If they did not have the same number of outputs as inputs they would not be reversible and hence not unitary, which is a contradiction.  For this reason any box drawn in a circuit diagram must have precisely as many wires entering it as it has wires leaving it.

Multiqubit circuits diagrams follow similar conventions to single qubit circuits.  As a clarifying example, we can define a two-qubit unitary operation $B$ to be $(H S\otimes X)$ then we can express the circuit equivalently as

![](4.svg)

We can also view $B$ as having on action on a single two-qubit register rather than two one-qubit registers depending on the context in which the circuit is used. 
Perhaps the most useful property of such abstract circuit diagrams is that they allow complicated quantum algorithms to be described at a high level without having to compile them down to fundamental gates.  This means that you can get an intuition about the data flow for a large quantum algorithm without needing to understand all the details of how each of the subroutines within the algorithm work.

The other construct that is built into multi-qubit quantum circuit diagrams is control.  The action of a controlled quantum gate, $\Lambda(G)$, can be understood by looking at the following example of a product state input $\Lambda(G) (\alpha |0\rangle + \beta |1\rangle) |\psi\rangle = \alpha |0\rangle |\psi\rangle + \beta |1\rangle G|\psi \rangle $.  That is to say, the controlled gate applies $G$ to the register containing $\psi$ if and only if the control qubit takes the value $1$.  In general, we describe such controlled operations in circuit diagrams as

![](5.svg)

Here the black circle denotes the quantum bit that the gate is controlled on and verticle wire denotes the unitary that is applied when the control qubit takes the value $1$.
For the special cases where $G=X$ and $G=Z$ we introduce the following notation to describe the controlled gates:
![](6.svg)

The remaining operation in circuit diagrams is measurement.  Measurement takes a qubit register and measures it and outputs the result as classical information.  A measurement operation is denoted by a meter and it always takes as input a qubit register (a solid line) and outputs classical information (a double line).  Specifically, such a subcircuit looks like 

![](7.svg)

Similarly, the subcircuit

![](8.svg)

gives a classically controlled gate that is applied conditioned on the classical control bit being $1$.

Quantum Teleportation is perhaps the best quantum algorithm for illustrating all of these components.  Quantum teleportation is a method for moving data within a quantum computer (or perhaps between distant quantum computers in a quantum network) through the use of entanglement and measurement.  Interestingly, it is actually capable of moving a quantum state from one qubit to another without even knowing what that qubit is which is necessary for the protocol to work according to the laws of quantum mechanics.  This circuit is given below and we provide an annotated version of the circuit that illustrates how to read the quantum circuit.

![](tp2.svg){ width=50% }

---
title: Understanding quantum computing
description: What are quantum computers and how do they use the principles of quantum mechanics?
author: bradben
ms.author:  bradben
ms.date: 5/5/2020
ms.topic: overview
uid: microsoft.quantum.overview.understanding
---

# Understanding quantum computing

Quantum computing uses the principles of quantum mechanics to process information. Because of this, quantum computing requires a different approach than classical computing.  One example of this difference is the processor used in quantum computers.  Where classical computers use familiar silicon-based chips, quantum computers use quantum materials such as atoms, ions, photons, or electrons.  

The quantum material behaves according to the laws of quantum mechanics, leveraging concepts such as probabilistic computation, superposition, and entanglement. These concepts provide the basis for quantum algorithms that harness the power of quantum computing to solve complex problems. This article describes some of the essential concepts of quantum mechanics on which quantum computing is based.

## A bird’s-eye view of quantum mechanics

Quantum mechanics, also called quantum theory, is a branch of physics that deals with particles at the atomic and subatomic levels. At the quantum level, however, many of the laws of mechanics you take for granted don’t apply. Superposition, quantum measurement, and entanglement are three phenomena that are central to quantum computing.  

### Superposition vs. binary computing

Imagine that you are exercising in your living room. You turn all the way to your left and then all the way to your right. Now turn to your left and your right at the same time. You can’t do it (not without splitting yourself in two, at least).  Obviously, you can’t be in both of those states at once – you can’t be facing left and facing right at the same time.

However, if you are a quantum particle, then you can be *facing left* AND *facing right* AND *anywhere in-between* at the same time due to a phenomenon known as **superposition** (also known as **coherence**).

A quantum particle such as an electron has its own “facing left or facing right” properties, for example **spin**, referred to as either up or down, or to make it more relatable to classical binary computing, let’s just say 1 or 0. When a quantum particle is in a superposition state, it’s a linear combination of an infinite number of states between 1 and 0, but you don’t know which one it will be until you actually look at it, which brings up our next phenomenon, **quantum measurement**.

### Quantum measurement

Now, let’s say your friend comes over and wants to take a picture of you exercising. Most likely, they’ll get a blurry image of you turning somewhere between all the way left and all the way right.

But if you’re a quantum particle, an interesting thing happens. No matter where you are when they take the picture, it will always show you either all the way left or all the way right – nothing in-between.

This is because the act of observing or measuring a quantum particle **collapses** the superposition state (also known as **decoherence**) and the particle takes on a classical binary state of either 1 or 0.

This binary state is helpful to us, because in computing you can do lots of things with 1’s and 0’s. However, once a quantum particle has been measured and collapsed, it stays in that state forever (just like your picture) and will always be a 1 or 0. As you’ll see later, though, in quantum computing there are operations that can “reset” a particle back to a superposition state so it can be used for quantum calculations again.

### Entanglement

Possibly the most interesting phenomenon of quantum mechanics is the ability of two or more quantum particles to become **entangled** with each other. When particles become entangled, they form a single system such that the quantum state of any one particle cannot be described independently of the quantum state of the other particles. This means that whatever operation or process you apply to one particle correlates to the other particles as well.

In addition to this interdependency, particles can maintain this connection even when separated over incredibly large distances, even light-years. The effects of quantum measurement also apply to entangled particles, such that when one particle is measured and collapses, the other particle collapses as well. Because there is a correlation between the entangled qubits, measuring the state of one qubit provides information about the state of the other qubit – this particular property is very helpful in quantum computing.

### Qubits and probability

Classical computers store and process information in bits, which can have a state of either 1 or 0, but never both. The equivalent in quantum computing is the **qubit**, which represents the state of a quantum particle. Because of superposition, qubits can either be 1 or 0 or anything in between. Depending on its configuration, a qubit has a certain *probability* of collapsing to 1 or 0. The ability to configure a qubit's probability of collapsing one way or the other is called **quantum interference**. 

Remember your friend that was taking your picture? Suppose they have special filters on their camera called *Interference* filters. If they select the *70/30* filter and start taking pictures, in 70% of them you will be facing left, and in 30% you will be facing right. The filter has interfered with the regular state of the camera to influence the probability of its behavior.

Similarly, quantum interference affects the state of a qubit in order to influence the probability of a certain outcome during measurement, and this probabilistic state is where the power of quantum computing excels.

For example, with two bits in a classical computer, each bit can store 1 or 0, so together you can store four possible values – **00**, **01**, **10**, and **11** – but only one of those at a time. With two qubits in superposition, however, each qubit can be 1 or 0 or *both*, so you can represent the same four values simultaneously. With three qubits, you can represent eight values, with four qubits, you can represent 16 values, and so on.

## Summary

These concepts just scratch the surface of quantum mechanics, but are fundamentally important concepts to know for quantum computing.

- **Superposition** - The ability of quantum particles to be a combination of all possible states.
- **Quantum measurement** - The act of observing a quantum particle in superposition and resulting in one of the possible states.
- **Entanglement** - The ability of quantum particles to correlate their measurement results with each other.
- **Qubit** - The basic unit of information in quantum computing. A qubit represents a quantum particle in superposition of all possible states.
- **Interference** - Actions applied to a qubit to influence the probability of it collapsing one way or another.

## Next Steps

> [!div class="nextstepaction"]
> [Quantum computers and quantum simulators](xref:microsoft.quantum.overview.simulators)
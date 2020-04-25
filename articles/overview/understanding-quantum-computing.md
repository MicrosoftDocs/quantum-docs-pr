---
title: Understanding quantum computing
description: What are quantum computers and how do they use the principles of quantum physics?
author: bradben
ms.author:  bradben
ms.date: 04/22/2020
ms.topic: overview
uid: microsoft.quantum.overview.understanding
---

# Understanding quantum computing

Quantum computing uses the principles of quantum physics to process information. Because of this, quantum computing requires a different approach than classical computing.  One example of this is the processor used in quantum computers.  Where classical computers use familiar silicon-based chips, quantum computers use quantum particles such atoms, ions, photons or electrons.  

These quantum particles behave according to the laws of quantum physics, leveraging concepts such as probabilistic computation, superposition, and entanglement, which provide the basis for quantum algorithms that harness the power of quantum computing to solve complex problems. This article describes some of the essential concepts of quantum physics on which quantum computing is based.

## A bird’s-eye view of quantum physics
Quantum physics, also called quantum mechanics or quantum theory, is a branch of physics that deals with particles at the atomic and subatomic level. At the quantum level, however, many of the laws of physics you take for granted don’t apply. Superposition, quantum measurement, and entanglement are three phenomena that are central to quantum computing.  

### Superposition vs. binary computing
Anyone with a hectic work or school schedule knows that you can’t be two places at once – you have to be either *here* or *there*. However, if you’re a quantum particle then you can be *here* AND *there* AND *somewhere else* due to a phenomenon known as **superposition** (also known as **coherence**).

Think of flipping a coin in the air and catching it. While it’s in the air turning over and over, it’s neither heads nor tails, but can be seen as a linear combination of all of its possible states at once – heads, tails, 75% heads, 12.5% tails, and so on.

A quantum particle such as an electron has its own “heads or tails” property called **spin**, which can be either up or down (or positive or negative for a photon), or to make it more relatable to classical binary computing, let’s just say 1 or 0. When a quantum particle is in a superposition state, it’s a linear combination of all of its possible states between 1 and 0, but you don’t know which one it will be until you actually look at it, which brings up our next phenomenon, **quantum measurement**.

### Quantum measurement

Let’s say you want to track the height of a five-year old child every year by measuring them and placing a mark on the wall. You would expect their height to increase every year, and the mark on the wall to gradually get higher.

But what if you measured that five-year old and they just stopped growing? That’s sort of what happens when you measure a quantum particle. Just the act of observing or measuring a quantum particle **collapses** the superposition state (also known as **decoherence**) and the particle takes on a classical binary state of either 1 or 0.

This is helpful to us, because in computing you can do lots of things with 1’s and 0’s. However, once a quantum particle has been measured and collapsed, it stays in that state forever and will always be a 1 or 0, and cannot be used for more calculations. As you’ll see later, though, in quantum computing there are operations that can “reset” a particle back to a superposition state so it can be useful again.

### Entanglement

Possibly the most interesting phenomenon of quantum physics is the ability of two or more quantum particles to become **entangled** with each other. When particles become entangled, they form a single system such that the quantum state of any one particle cannot be described independently of the quantum state of the other particles. This means that whatever operation or process you apply to one particle immediately takes effect on the other particles as well.

In addition, particles can maintain this connection even when separated over incredibly large distances, even light-years. The effects of quantum measurement still apply to entangled particles, such that when one particle is measured and collapses, the other particle collapses as well. However, the second one always collapses in the *opposite* state as the first one – this particular property is very helpful in quantum computing. These unique properties of entangled particles can be used to transmit quantum information from one place to another by a process called **teleportation**, and may play a critical role in future cryptography applications.

### Qubits and probability

Classical computers store and process information in bits, which can have a state of either 1 or 0, but never both. The equivalent in quantum computing is the **qubit**, which represents the state of a quantum particle. Because of superposition, qubits can either be 1 or 0, or both, or anything in between. Depending on its configuration, a qubit has a certain *probability* of collapsing to 1 or 0, and this probabilistic state is where the power of quantum computing excels.

In classical computing, uncertainty is not a good thing. In quantum computing, it’s built in.

For example, with two bits in a classical computer, each bit can store 1 or 0, so together you can store four possible values – **00**, **01**, **10**, and **11** – but only one of those at a time. With two qubits in superposition, however, each qubit can store 1 or 0 or *both*, so you can represent the same four values simultaneously. Furthermore, when multiple entangled qubits are in superposition, they can process multiple options simultaneously. And with each qubit you add to the system, that power increases exponentially.

## Summary

These concepts just scratch the surface of quantum physics, but are very important abstract concepts to know for quantum computing.
- **Superposition** - The ability of quantum particles to hold multiple states at once.
- **Quantum measurement** - The act of observing a quantum particle in superposition and collapsing it to a binary state.
- **Entanglement** - The ability of quantum particles to bond and behave as a single system.
- **Qubit** - The basic unit of information in quantum computing. A qubit represents a quantum particle and can store multiple states simultaneously.

## Next Steps

> [!div class="nextstepaction"]
> [Quantum computers and quantum simulators](index.md)
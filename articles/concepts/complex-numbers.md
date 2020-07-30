---
title: Complex numbers in quantum computing
description: This article introduces the use of complex numbers for quantum computing.
author: geduardo
uid: microsoft.quantum.concepts.algebra.complex-numbers
ms.author: v-edsanc@microsoft.com
ms.date: 07/30/2020
ms.topic: article
---

# Complex numbers for quantum computing

This article explains the basic concepts of complex numbers for quantum
computing.

## Why do we need complex numbers for quantum computing?

In quantum mechanics, and therefore in quantum computing, the state of a
particular system (e.g. a qubit) is often represented as sum of different
classical states: this is what is known as a quantum superposition. For example,
at this point you might know that a qubit can exist in a quantum superposition
of the two binary states **0** and **1**. A superposition is mathematically
represented as a sum of states. For example, the state of qubit can be the
following superposition:

$$ \ket{\text{qubit}} = a \ket{0} + b \ket{1} $$

The symbol $\ket{}$ is part of the Dirac notation for quantum mechanics and will
be explained later in detail in this guide. However, for the moment you just need to know
that the symbol $\ket{}$ is used to represent states. For example, $$\ket{1}$$
represents the qubit in the state **1**. Then the state of the qubit
$\ket{\text{qubit}}$ is just a sum of the possible states $\ket{0}$ and
$\ket{1}$. Another way to phrase this is by saying that the state
$\ket{\text{qubit}}$ is a **linear combination** of the states $\ket{0}$ and
$\ket{1}$.

What are the coefficients $a$ and $b$? Well, $a$ and $b$ are complex numbers. A
superposition is a *complex sum* of different states. Why complex numbers?
Complex numbers are mathematical tool that is very useful to represent the
different properties of quantum systems. In particular, using complex numbers we
can encode intuitively the *phase* and the *probability* associated with each of
the superposed states. As we will see in this guide, quantum systems follow
wave-like equations. To describe wave-like phenomena like interference we need
to take in account the phase of each state. This is why use complex numbers.

## Introduction to complex numbers

Now let's introduce the concept of complex numbers and discuss some of their
basic properties.

### A quick overview of the different sets of numbers

The natural numbers: $0, 1, 2, 3, ...$ are often represented by the symbol
$\mathbb{N}$. We can perform operations with them, like addition or subtraction.
All additions are allowed within the set of the natural numbers: the sum of two
natural numbers is always a natural number. However, this is not true for
subtraction. For example, operation 2-5 is not allowed within the natural numbers.
This is why we introduce the integer numbers: $... -2, -1, 0, 1, 2 ...$ that are
often represented by the symbol $\mathbb{Z}$. The operation $2-5$ is allowed
within the integer numbers, and its equal to $-3$.

Something similar happens when we try perform division with some integers, for
example there isn't an integer number equal to $\frac52$. But we can
create a new set of numbers, the rational numbers, $\mathbb{Q}$, such that all
divisions are allowed. Similarly, it can be proved that some numbers, like $\pi$
or $\sqrt2$ cannot be expressed as a division between two integers, but we can
introduce a bigger set of numbers called the real numbers, $\mathbb{R}$, so that
$\sqrt2$, $\pi$ and numbers alike are included.

Complex numbers follow the same logic that we have follow with the previous sets. The
square root of negative numbers is not allowed within the set of complex
numbers. For example, there isn't a real number equal to $\sqrt{-5}$. But
we can create a new set of numbers, the set of complex numbers $\mathbb{C}$, so
that $\sqrt{-5}$ is a valid number.

![Numbersdiagram](~/media/numbers.png)

### i, the imaginary unit

How do we express complex numbers? We can express complex numbers in a handy way
using the imaginary unit $i$. We define the imaginary unit $i$ as the result of
the operation $\sqrt{-1}$. This is:

$$i=\sqrt{-1}$$

Using the imaginary unit we can express other complex numbers. For example,
$\sqrt{-5}$ is $i\sqrt{5}$, since
$\sqrt{-5}=\sqrt{(-1)(5)}=\sqrt{-1}\sqrt5=i\sqrt5$.

### Imaginary and real parts

Sums and every other operation are allowed between any two complex numbers. For
example $2+i\sqrt{5}$ is also a complex number. In general, any complex number
$z$ can be expressed in the form $z=a+ib$, where $a$ and $b$ are real numbers.
We say then that $a$ is the real part of $z$ and that $b$ is the imaginary part
of $z$. This representation is called the *cartesian representation* of a
complex number, since we can visualize $a$ and $b$ as the cartesian coordinates
of a point in the *complex plane*.

![Complex plane](~/media/complex-plane.PNG)

### Basic operations

Let's outline how to perform the basic operations with complex numbers in their
cartesian representation. If we have two complex numbers $z=a+ib$ and $w=c+id$:

#### Sum

We sum the real and imaginary parts of both numbers as we do usually.

$$z+w=(a+c)+i(b+d)$$

#### Subtraction

Similarly to sum, we subtract the real and imaginary parts of both numbers as we
do usually.

$$z-w=(a-c)+i(b-d)$$

#### Multiplication

Multiplication requires a bit more of work. We just need to use distributive
and associative properties:

$$zw=zw=(a+ib)(c+id)=a(c+id)+ib(c+id)=ac+iad+ibc+i^2bd$$

Since $i=\sqrt{-1}$, we have that $i^2=-1$, and therefore:

$$zw=(ac-bd)+i(ad+bc)$$

## Polar representation of complex numbers

As we just saw, we can represent complex numbers as points in a cartesian
plane.
It means that we can also represent any complex number $z$ with polar
coordinates, this is, a *modulus*, $|z|$, and an angle or *phase*, $\phi$.

- The **modulus** or **absolute value** of a complex number $z=a+ib$ is the length
of the associated vector in the complex plane. It can be calculated from the
cartesian representation using the Pythagorean theorem: $$|z|=\sqrt{a^2+b^2}$$

- The **phase** or **argument** of a complex number $z=a+ib$ is the angle between the
  associated vector in the complex plane and the real axis.

![Complex plane in polar coordinates](~/media/complex-plane-polar.PNG)

Using basic trigonometry is easy to check that the real part is $Re(z)=|z|\cos
\varphi$ and the imaginary part is $Im(z)=|z|sin \varphi$.

### Euler's formula

Euler's formula establishes a relationship between the complex exponential
function and the trigonometric representation of complex numbers. The formula
states that for any real number $x$ the following relation is true:

$$e^{ix}=\cos x + i \sin x$$

We can then represent any complex number using complex exponentials:

$$z=|z|e^{i\varphi}$$

This representation is very useful and common, specially in the context of
quantum computing. For example, it makes the multiplication of complex numbers
very straightforward.

$zw=(|z|e^{i\varphi_z})(|w|e^{i\varphi_w})=|z||w|e^{i(\varphi_z+\varphi_w)}$

Also the division:

$$\frac{z}{w}=\frac{|z|e^{i\varphi_z}}{|w|e^{i\varphi_w}}=\frac{|z|}{|w|}e^{i(\varphi_z-\varphi_w)}$$
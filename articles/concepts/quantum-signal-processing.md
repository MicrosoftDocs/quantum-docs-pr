---
title: Quantum Signal Processing | Microsoft Docs 
description: Concept of quantum signal processing
author: QuantumWriter
uid: microsoft.quantum.concepts.quantumsignalprocessing
ms.author: jwhaah@microsoft.com 
ms.date: 9/20/2019
ms.topic: article
---

# Quantum Signal Processing

Given a linear operator $W$ on a complex vector space and a polynomial function $f(z) = \sum_k f_k z^k$ where $f_k \in \mathbb{C}$,
we can think of a linear operator $f(W) = \sum_k f_k W^k$.
A number of quantum algorithms can be thought of as implementing $f(W)$ given that we already have implemented $W$.
Since unitary operations are meant to be composed rather than superposed,
the expression $f(W) = \sum_k f_k W^k$ does not make much sense as it reads.
Quantum signal processing is a general technique to realize $f(W)$ using $W$ many times.

## Unitary-to-unitary transformation

## Unitary-to-nonunitary transformation

## Polynomial approximation to transformation function

## Application scope
---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: "Q# standard libraries | Microsoft Docs"
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

## Applications ##

### Hamiltonian Simulation ###

The modeling of Hamiltonians is one of the major application areas desired for Quantum Computing. We provide a simple example of this based on the experimental results reported in [O'Malley et. al.](https://arxiv.org/abs/1512.06860) using superconducting qubits. The model used for molecular hydrogen ($H_2$) only requires Pauli matrices and takes the form:

        $H = g_{0}\bold{1}+g_1{Z_0}+g_2{Z_1}+g_3{Z_0}{Z_1}+g_4{Y_0}{Y_1}+g_5{X_0}{X_1}$

We represent the target Hamiltonian as an expansion in a set of unitaries which allows the system to find a solution using either Trotter-Suzuki with Phase Estimation or a Linear Combination of Unitaries (LCU) with Amplitude Amplification. For an in-depth treatment of LCU, please refer to Chapter 2 of  [Robin Kohari's thesis](https://uwspace.uwaterloo.ca/bitstream/handle/10012/8625/Kothari_Robin.pdf). A nice overview of the area was presented by [Dominic Berry](http://www.dominicberry.org/presentations/Durban.pdf).

The $H_2$ example is an Effective Hamiltonian only representing the off-diagonal elements, requiring only 2 qubits. The constants $g$ are computed from the distance $R$ between the two Hydrogen atoms. 

Using canon functions, the Paulis are converted to Unitaries and then evolved over short periods of time, implementing Trotterization. This allows us to use a product of Unitaries (quantum circuit) to represent the sum of terms in the Hamiltonian. See `ExampleH2.qs` for how this is done.

The solution for the Hamiltonian ground state is found by utilizing Phase Estimation (described earlier) from the canon.

To demonstrate the solution, a top level driver program (`H2SimulationExample`) is provided which performs a plot of the resulting ground state energy for several bond lengths $R$ using the `FSharp.Charting` package and is shown along with the theoretical values.

### Factorization ###


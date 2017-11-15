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


# Quantum Characterization and Statistics #

In developing quantum algorithms, it is critical to be able to characterize the effects of operations.
This is made challenging by the fact that quantum states cannot be learned directly, reflected in that Q# does not expose or even define what a state *is* to quantum programs.
We thus approach quantum characterization by treating operations and states as black-box; this approach shares much in common with the experimental practice of quantum characterization, verification and validation (QCVV).

## Learning Quantum Processes ##

## Iterative Phase Estimation ##

Viewing quantum programming in terms of quantum characterization suggests a useful alternative to [quantum phase estimation](algorithms#quantum-phase-estimation).
That is, instead of preparing an $n$-qubit register to contain a binary representation of the phase as in quantum phase estimation, we can view phase estimation as the process by which a *classical* agent learns properties of a quantum system through measurements.
This has the advantage that we only require a single additional qubit to perform the phase kickback described in the quantum case, as we then measure the control bit and use it to learn the phase in an iterative fashion.


### Bayesian Phase Estimation ###

<!-- FIXME: though RPE is the correct name of this algorithm, in context it reads as though Bayesian PE is the opposite of robust, which is not the case. -->
### Robust Phase Estimation ###

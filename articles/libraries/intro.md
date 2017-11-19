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

# Introduction to the Q# standard libraries #

Q# is supported by a range of different useful operations, functions, and user-defined types that comprise the Q# *standard library*.
The Q# standard library is split into two main parts:

- **The prelude**: operations and functions defined as a part of the target machine and compiler, typically in classical native .NET code.
  In general, different target machines may have different implementations of the prelude apporpiate to each system.
- **The canon**: operations and functions defined in Q# building on the logic defined in the prelude.
  The canon implementation is agnostic with respect to target machines.

The `Microsoft.Quantum.Simulation.Simulators` NuGet package installed during [installation and configuration](quantum-InstallConfig.md) provides a target machine which implements the prelude by calling into a local simulator, while the `Microsoft.Quantum.Canon` package <!-- TODO: check that this is actually how the canon is distributed --> provides an implementation of the canon that references definitions in the prelude.

The symbols defined by each of the prelude and the canon are defined in much greater and more exhaustive detail in the API documentation <!-- TODO: link! -->.
In this section, we will outline the most salient features of each part of the standard library and provide some context about how each feature might be used in practice.


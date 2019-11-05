---
title: Broombridge - Quantum Chemistry Schema
author: martinro
ms.author: martinro@microsoft.com
ms.date: 10/17/2018
ms.topic: article
uid: microsoft.quantum.libraries.chemistry.schema.broombridge
---

# Broombridge Quantum Chemistry Schema # 

Powerful computational chemistry software such as [NWChem](http://www.nwchem-sw.org/) allows to model a wide range of real-world chemistry problems. In order to access NWChem molecular models with the Microsoft Quantum Chemistry library, we use a [YAML](https://en.wikipedia.org/wiki/YAML)-based schema which we call **Broombridge**. The name was chosen in reference to a [landmark](https://en.wikipedia.org/wiki/Broom_Bridge) which in some circles is celebrated as a birthplace of Hamiltonians. 

[NWChem](https://github.com/nwchemgit/nwchem) is an Open Source project licensed under the permissive Educational Community License (ECL) 2.0 license. Broombridge is an Open Source schema that is specified [here](xref:microsoft.quantum.libraries.chemistry.schema.broombridge) and that comes with a [definition](https://raw.githubusercontent.com/Microsoft/Quantum/master/Chemistry/Schema/broombridge-0.1.schema.json) following [RFC 2119](https://tools.ietf.org/html/rfc2119) and [validator script](https://raw.githubusercontent.com/Microsoft/Quantum/master/Chemistry/Schema/validator.py) licensed under the MIT license. 

Being YAML-based, Broombridge is a structured, human-readable and human-editable way of representing electronic structure problems. In particular, the following data can be represented: 
- Fermionic Hamiltonians can be represented using one- and two-electron integrals. 
- Ground and excited states can be presented using creation sequences.
- Upper and lower bounds of energy levels can be specified.

The data format can be generated from NWChem with effortless ease: a variety of methods is available that range from a full installation of NWChem to run chemistry decks such as the ones provided [here](https://github.com/nwchemgit/nwchem/tree/master/QA/chem_library_tests) and output Broombridge as part of the run, over a docker image of NWchem which can also be used to generate Broombridge from chemistry decks. Finally, a visual method to get started with computational chemistry quickly without having to install any chemistry software is provided by the [EMSL Arrows](https://arrows.emsl.pnnl.gov/api/qsharp_chem) interface to NWChem. 

At a high level, the interplay between NWChem and the Microsoft Quantum Development Kit can be visualized as follows: 
![Chemistry stack](~/media/broombridge.png)
The blue shaded box represents the Broombridge schema, the various grey shaded boxes represent other internal data representations that were chosen to represent and process quantum algorithms for computational chemistry based on real-world chemistry problems. 

Multiple chemical representations defined using the Broombridge schema are provided [here](https://github.com/microsoft/Quantum/tree/master/Chemistry/IntegralData/YAML).


---
title: Broombridge Quantum Chemistry Schema
description: Overview of the Broombridge quantum chemistry schema, used to model real-world chemistry problems with the Microsoft Quantum Development Kit. 
author: martinro
ms.author: martinro@microsoft.com
ms.date: 10/17/2018
ms.topic: article
uid: microsoft.quantum.libraries.chemistry.schema.broombridge
no-loc: ['Q#', '$$v']
---

# Broombridge Quantum Chemistry Schema # 

Powerful computational chemistry software such as [NWChem](http://www.nwchem-sw.org/) allows you to model a wide range of real-world chemistry problems. In order to access NWChem molecular models with the Microsoft Quantum Chemistry library, you use a [YAML](https://en.wikipedia.org/wiki/YAML)-based schema named **Broombridge**. The name was chosen in reference to a [landmark](https://en.wikipedia.org/wiki/Broom_Bridge) which in some circles is celebrated as a birthplace of Hamiltonians. 

[NWChem](https://github.com/nwchemgit/nwchem) is an Open Source project licensed under the permissive Educational Community License (ECL) 2.0 license. The [Broombridge Quantum Chemistry Schema](https://docs.microsoft.com/quantum/libraries/chemistry/schema/spec_v_0_2)) is an Open Source schema that includes a [definition](https://raw.githubusercontent.com/Microsoft/Quantum/master/Chemistry/Schema/broombridge-0.1.schema.json) following [RFC 2119](https://tools.ietf.org/html/rfc2119) and a [validator script](https://raw.githubusercontent.com/Microsoft/Quantum/master/Chemistry/Schema/validator.py) licensed under the MIT license. 

Being YAML-based, Broombridge is a structured, human-readable and human-editable way of representing electronic structure problems. In particular, the following data can be represented:
- Fermionic Hamiltonians can be represented using one- and two-electron integrals.
- Ground and excited states can be presented using creation sequences.
- Upper and lower bounds of energy levels can be specified.

Data can be generated from NWChem using various methods, such as using a full installation of NWChem to run chemistry decks (for example the ones provided in the [NWChem library](https://github.com/nwchemgit/nwchem/tree/master/QA/chem_library_tests) that output Broombridge as part of the run), or a docker image of NWChem which can also be used to generate Broombridge from chemistry decks. To get started with computational chemistry quickly without having to install any chemistry software, you can use the visual interface to NWChem provided by [EMSL Arrows](https://arrows.emsl.pnnl.gov/api/qsharp_chem).

At a high level, the interplay between NWChem and the Microsoft Quantum Development Kit can be visualized as follows:
![Chemistry stack](~/media/broombridge.png)
The blue shaded box represents the Broombridge schema, the various grey shaded boxes represent other internal data representations that were chosen to represent and process quantum algorithms for computational chemistry based on real-world chemistry problems.

The [Integral/YAML](https://github.com/microsoft/Quantum/tree/master/samples/chemistry/IntegralData/YAML) folder in the Quantum Development Kit Samples repository contains multiple chemical representations defined using the Broombridge schema.

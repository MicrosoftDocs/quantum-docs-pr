---
title: The Q# language
description: Learn about the Q# programming language.
author: bettinaheim
ms.author: beheim
ms.date: 10/07/2020
ms.topic: article
uid: microsoft.quantum.qsharp.index
no-loc: ['Q#', '$$v']
---

# The Q# language

Q# is part of Microsoft's [Quantum Development Kit](https://www.microsoft.com/quantum), and comes with rich IDE support and tools for program visualization and analysis.
The goal in designing Q# is to support the development of future large-scale applications, while allowing users to run their first efforts on current quantum hardware. 

The type system lets users safely interleave and naturally represent the composition of classical and quantum computations. A Q# program may express arbitrary classical computations based on quantum measurements that run while qubits remain live, that is, they are not released and maintain their state. Even though the full complexity of such computations requires further hardware development, Q# programs can be targeted to run on various quantum hardware backends in [Azure Quantum](https://azure.microsoft.com/services/quantum/).

Q# is a stand-alone language offering a high level of abstraction.
There is no notion of a quantum state or a circuit. Instead, 
programs are implemented in terms of statements and expressions, much like in classical programming languages. Distinct quantum capabilities, (for example, support for functors and quantum control-flow constructs such as repeat-until-success loops), facilitate the expression of algorithms for areas such as phase estimation and quantum chemistry.

<!--->
[!INCLUDE [source link](~/includes/qsharp-language/Specifications/Language/README.md)]
-->

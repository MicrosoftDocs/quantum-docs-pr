---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Intent and product brand in a unique string of 43-59 chars including spaces | Microsoft Docs 
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

# Appendices

## Type Specifier Syntax

The rough EBNF syntax for type specifiers follows. 
In the syntax, the “symbol” production specifies the set of valid Q# symbols. 

```ebnf
type              = simple-type | 
                    array-type | 
                    tuple-type | 
                    operation-type | 
                    function-type | 
                    user-defined-type
simple-type       = “Int” | “Double” | "Bool" | "String" | 
                    “Qubit” | "Pauli" | “Result” | "Range"
variant           = "Adjoint" | "Controlled"
array-type        = type “[]”
tuple-type        = “(“ [ type { “,” type } ] “)”
operation-type    = “(“ tuple-type “=>” tuple-type [ : variant { "," variant } ] “)”
function-type     = “(“ tuple-type “->” tuple-type “)”
user-defined-type = symbol
```
<!---
## Anticipated Future Features

Some or all of the following features may be added to Q# in the future:

 - Ability to link Q# functions to .NET static methods.
    The expected use for external functions is for core mathematical 
    functions such as `sine` and `exp`.
    External functions used during actual quantum execution must be 
    small enough and simple enough to fit on the classical control hardware.
    In addition, because the quantum state decays randomly over time,
    external functions called during quantum execution must run 
    extremely quickly.
 - Constraints for type parameters on operations. 
    This allows, for instance, the ability to restrict a type parameter
    to only being instantiated with types that are numeric.
 - Type constructors for user-defined types that may be used from within a 
    "using" or "borrowing" acquisition.
    This would make it simpler to allocate user-defined types that contain 
    qubits, rather than getting the qubits first and then building a value of
    the type from the qubit array.
 - Annotation of operation calls with precision requirements.
    This provides a way to control the distribution of the allowed error 
    tolerance for an algorithm.
 - Standard library operations for qubit allocation and release.
    While this gives up the safety of the `using` statement, there may be
    specific algorithms that are very awkward to express without these.
 - Standard library functions for finding the number of qubits available
    for using or borrowing.
 - Keyword and optional arguments.
 - .NET-style attributes for declarations, parameters, and statements.
 - Compiler directives (#if/#endif, #pragma). 
 - A language construct to allow the programmer to designate that a set
    of statement blocks may be safely executed in parallel or in an 
    arbitrary order.
    In some cases this may allow optimizations that are difficult to 
    detect programmatically.
--->
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

# Using The Compiler

Q# code is stored as text in files. 
The top-level constructs allowed in a file are user defined types, 
function and operation declarations, and comments.

The Q# compiler will process one or more text files containing any number of 
these constructs and create a single .NET library exposing the functionality 
defined in these text files. 
This library can be referenced within a .NET project and native .NET code in C# or F# 
can then access the functionality represented by the Q# code within the native .NET 
code. 

The compiler functionality is packaged in two different forms:

- As a command line tool which will take some arguments and 
    generate an assembly which can be linked against.
- As a single file generator packaged within a Visual Studio Extension (VSIX) 
    which can act as a custom tool for Q# files in a project, 
    and generate code-behind C# for each file.
    This provides debugging capability within Visual Studio at the Q# language level.

## Compiler Command Line Interface

The command line interface should take a list of Q# input files and the desired name of the output DLL.

    Q#c.exe f1.Q# f2.Q# f3.Q# --output phase.dll
    

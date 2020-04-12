---
title: IQ# Magic Commands
description: Quick reference page for IQ# magic commands with Q# Jupyter Notebooks
author: gillenhaalb
ms.author:  a-gibec@microsoft.com
ms.date: 03/05/2020
uid: microsoft.quantum.guide.quickref.iqsharp
---

# IQ# Magic Commands

### General

- `%config`: Sets or gets configuration preferences.
- `%estimate`: Runs a given function or operation on the QuantumSimulator target machine.
- `%package`: Provides the ability to load a Nuget package.
- `%simulate`: Runs a given function or operation on the QuantumSimulator target machine.
- `%toffoli`: Runs a given function or operation on the ToffoliSimulator simulator target machine.
- `%who`: Returns a list of currently defined operations and functions.
- `%workspace`: Provides actions related to the current workspace.

### From Microsoft.Quantum.Katas package
- `%kata`: Executes a single test, and reports whether the test passed successfully.
- `%check_kata`: Checks the reference implementation for a single kata's test.
    Specifically, it substitutes the reference implementation for a single task into the cell, and reports whether the test passed successfully.

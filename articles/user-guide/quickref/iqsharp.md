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
- `%lsmagic`: Returns a list of all currently available magic commands.
- `%package`: Provides the ability to load a Nuget package.
- `%performance`: Reports current performance metrics for this kernel.
- `%simulate`: Runs a given function or operation on the QuantumSimulator target machine.
- `%toffoli`: Runs a given function or operation on the ToffoliSimulator simulator target machine.
- `%who`: Provides actions related to the current workspace.
- `%workspace`: Returns a list of all operations and functions defined in the current session, either interactively or loaded from the current workspace.

### Chemistry

- `%chemistry.broombridge`: Loads and returns Broombridge electronic structure problem representation from a given .yaml file.
- `%chemistry.encode`: Encodes a fermion Hamiltonian to a format consumable by Q#.
- `%chemistry.fh.add_terms`: Adds terms to a fermion Hamiltonian.
- `%chemistry.fh.load`: Loads the fermion Hamiltonian for an electronic structure problem. The problem is loaded from a file or passed as an argument.
- `%chemistry.inputstate.load`: Loads Broombridge electronic structure problem and returns selected input state.

### From Microsoft.Quantum.Katas package

- `%kata`: Executes a single test, and reports whether the test passed successfully.
- `%check_kata`: Checks the reference implementation for a single kata's test.
    Specifically, it substitutes the reference implementation for a single task into the cell, and reports whether the test passed successfully.

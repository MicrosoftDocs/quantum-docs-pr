---
uid: Microsoft.Quantum.Chemistry.JordanWigner.VQE.EstimateTermExpectation
title: EstimateTermExpectation operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner.VQE
qsharp.name: EstimateTermExpectation
qsharp.summary: Computes the energy associated to a given Jordan-Wigner Hamiltonian term
---

# EstimateTermExpectation operation

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner.VQE](xref:Microsoft.Quantum.Chemistry.JordanWigner.VQE)

Package: [](https://nuget.org/packages/)


Computes the energy associated to a given Jordan-Wigner Hamiltonian term

```Q#
EstimateTermExpectation (inputStateUnitary : (Qubit[] => Unit is Adj), ops : Pauli[][], coeffs : Double[], nQubits : Int, nSamples : Int) : Double
```


## Description

This operation estimates the expectation value associated to each measurement operator andmultiplies it by the corresponding coefficient, using sampling.The results are aggregated into a variable containing the energy of the Jordan-Wigner term.

## Input

### inputStateUnitary : Qubit[] => Unit Adj

The unitary used for state preparation.


### ops : Pauli[][]

The measurement operators of the Jordan-Wigner term.


### coeffs : Double[]

The coefficients of the Jordan-Wigner term.


### nQubits : Int

The number of qubits required to simulate the molecular system.


### nSamples : Int

The number of samples to use for the estimation of the term expectation.



## Output

The energy associated to the Jordan-Wigner term.
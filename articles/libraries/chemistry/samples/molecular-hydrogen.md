---
title: Obtaining energy level estimates | Microsoft Docs
description: Obtaining energy level estimates Docs
author: guanghaolow
ms.author: gulow
ms.date: 10/23/2018
ms.topic: article-type-from-white-list
uid: microsoft.quantum.chemistry.examples.energyestimate
---

## Obtaining energy level estimates
Estimating the values of energy levels is one of the principal applications of quantum chemistry. Here, we outline how this may be performed for the canonical example of molecular Hydrogen. The sample referenced in this section is `MolecularHydrogen` in the chemistry samples repository. A more visual example that plots the output is the `MolecularHydrogenGUI` demo.

Our first step is to construct the Hamiltonian representing molecular Hydrogen. Though this can be constructed through the NWChem tool, we manually add Hamiltonian terms for brevity in this sample.

```csharp
// These orbital integrals represent terms in molecular Hydrogen
var orbitalIntegrals = new OrbitalIntegral[]
{
    new OrbitalIntegral(new[] { 0,0 }, -1.252477495),
    new OrbitalIntegral(new[] { 1,1 }, -0.475934275),
    new OrbitalIntegral(new[] { 0,0,0,0 }, 0.674493166),
    new OrbitalIntegral(new[] { 0,1,0,1 }, 0.181287518),
    new OrbitalIntegral(new[] { 0,1,1,0 }, 0.663472101),
    new OrbitalIntegral(new[] { 1,1,1,1 }, 0.697398010)
};

// We initialize a Fermion Hamiltonian data structure and add terms to it.
// Note that all these steps are performed automatically when loading from
// the `Broombridge` schema.
var hamiltonian = new FermionHamiltonian();
hamiltonian.NOrbitals = 2;                    // There are two orbitals
hamiltonian.NElectrons = 2;                   // Molecular hydrogen has two electrons
hamiltonian.EnergyOffset = 0.71377618;        // This is the coulomb repulsion
hamiltonian.AddFermionTerm(orbitalIntegrals); // Add all orbital integrals in the array
```

Simulating the Hamiltonian requires us to convert the Fermion operators to qubit operators. This conversion is performed through the Jordan-Wigner encoding as follows.

```csharp
// The Jordan-Wigner encoding converts the Fermion Hamiltonian, 
// expressed in terms of Fermionic operators, to a qubit Hamiltonian,
// expressed in terms of Pauli matrices.
var jordanWignerEncoding = JordanWignerEncoding.Create(hamiltonian);

// This is a data structure representing the Jordan-Wigner encoding 
// of the Hamiltonian that we may pass to a Q# algorithm.
var qSharpData = jordanWignerEncoding.QSharpData();
```

We now pass the `qSharpData` representing the Hamiltonian to the `TrotterStepOracle` function in [Simulating Hamiltonian dynamics](xref:microsoft.quantum.libraries.standard.algorithms). `TrotterStepOracle` returns a quantum operation that approximates the real time-evolution of the Hamiltonian.

```qsharp
// qSharpData passed from driver
let qSharpData = ... 

// Choose the integrator step size
let stepSize = 1.0;

// Choose the order of the Trotter—Suzuki integrator.
let integratorOrder = 4;

// `oracle` is an operation that applies a single time-step of evolution for duration `stepSize`.
// `rescale` is just `1.0/stepSize` -- the number of steps required to simulate unit-time evolution.
// `nQubits` is the number of qubits that must be allocated to run the `oracle` operatrion.
let (nQubits, (rescale, oracle)) =  TrotterStepOracle (qSharpData, stepSize, integratorOrder);
```

We can now use Canon's phase estimation algorithms to learn the ground state energy using the above simulation. This requires preparing a good approximation to the quantum ground state. Suggestions for such approximations are provided in the `Broombridge` schema, but absent these suggestions, the default approach adds a number of `hamiltonian.NElectrons` electrons to  greedily minimizes the diagonal one-electron term energies. The following snippet shows how the real time-evolution output by the chemistry simulation library may be integrated with quantum phase estimation.

```qsharp
operation GetEnergyByTrotterization (
    qSharpData : JordanWignerEncodingData, 
    nBitsPrecision : Int, 
    trotterStepSize : Double, 
    trotterOrder : Int) : (Double, Double) {
    
    // The data describing the Hamiltonian for all these steps is contained in
    // `qSharpData`
    let (nSpinOrbitals, fermionTermData, statePrepData, energyOffset) = qSharpData!;
    
    // We use a Product formula, also known as `Trotterization` to
    // simulate the Hamiltonian.
    let (nQubits, (rescaleFactor, oracle)) = 
        TrotterStepOracle(qSharpData, trotterStepSize, trotterOrder);
    
    // The operation that creates the trial state is defined below.
    // By default, greedy filling of spin-orbitals is used.
    let statePrep = PrepareTrialState(statePrepData, _);
    
    // We use the Robust Phase Estimation algorithm
    // of Kimmel, Low and Yoder.
    let phaseEstAlgorithm = RobustPhaseEstimation(nBitsPrecision, _, _);
    
    // This runs the quantum algorithm and returns a phase estimate.
    let estPhase = EstimateEnergy(nQubits, statePrep, oracle, phaseEstAlgorithm);
    
    // We obtain the energy estimate by rescaling the phase estimate
    // with the trotterStepSize. We also add the constant energy offset
    // to the estimated energy.
    let estEnergy = estPhase * rescaleFactor + energyOffset;
    
    // We return both the estimated phase, and the estimated energy.
    return (estPhase, estEnergy);
}
```

This Q# code may now be invoke from the driver program. In the following, we create a full-state simulator and run `GetEnergyByTrotterization` to obtain the ground state energy.

```csharp
using (var qsim = new QuantumSimulator())
{
    // We specify the bits of precision desired in the phase estimation 
    // algorithm
    var bits = 7;

    // We specify the step-size of the simulated time-evolution. This needs to
    // be small enough to avoid aliasing of phases, and also to control the
    // error of simulation.
    var trotterStep = 0.4;

    // Choose the Trotter integrator order
    Int64 trotterOrder = 1;

    // As the quantum algorithm is probabilistic, let us run a few trials.

    // This may be compared to true value of
    Console.WriteLine("Exact molecular Hydrogen ground state energy: -1.137260278.\n");
    Console.WriteLine("----- Performing quantum energy estimation by Trotter simulation algorithm");
    for (int i = 0; i < 5; i++)
    {
        // EstimateEnergyByTrotterization
        var (phaseEst, energyEst) = GetEnergyByTrotterization.Run(qsim, qSharpData, bits, trotterStep, trotterOrder).Result;
    }
}
```

Note that two parameters are returned. `energyEst` is the estimate of the ground state energy, and should be around `-1.137` on average. `phaseEst` is the raw phase returned by the phase estimation algorithm, and is useful to diagnose when aliasing occurs due to a `trotterStep` that is too large.

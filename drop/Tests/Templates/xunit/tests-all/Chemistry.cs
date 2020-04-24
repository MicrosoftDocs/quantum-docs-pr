// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;

using Microsoft.Quantum.Chemistry;
using Microsoft.Quantum.Chemistry.Broombridge;
using Microsoft.Quantum.Chemistry.Fermion;
using Microsoft.Quantum.Chemistry.JordanWigner;
using Microsoft.Quantum.Chemistry.OrbitalIntegrals;
using Microsoft.Quantum.Chemistry.Paulis;
using Microsoft.Quantum.Chemistry.QSharpFormat;
using Microsoft.Quantum.Chemistry.Samples;
using Microsoft.Quantum.Simulation.Simulators;

using Xunit;

// This loads a Hamiltonian from file and performs quantum phase estimation on
// - Jordan-Wigner Trotter step
// - Jordan-Wigner optimized Trotter step
// - Jordan-Wigner Qubitization iterate
// Taken from the Chemistry/Samples/RunSimulation project. It does not try to validate the results
// just makes sure the Chemistry library uploads and runs.
namespace Microsoft.Quantum.Tests
{
    public class ChemistryTests
    {
        private static JordanWignerEncodingData Encode(FermionHamiltonian hamiltonian, int electrons)
        {
            var wavefunction = hamiltonian.CreateHartreeFockState(electrons);

            // We target a qubit quantum computer, which requires a Pauli representation of the fermion Hamiltonian.
            // A number of mappings from fermions to qubits are possible. Let us choose the Jordan-Wigner encoding.
            PauliHamiltonian pauliHamiltonian = hamiltonian.ToPauliHamiltonian(QubitEncoding.JordanWigner);

            // We now convert this Hamiltonian and a selected state to a format that than be passed onto the QSharp component
            // of the library that implements quantum simulation algorithms.
            var qSharpHamiltonian = pauliHamiltonian.ToQSharpFormat();
            var qSharpWavefunction = wavefunction.ToQSharpFormat();
            var qSharpData = Microsoft.Quantum.Chemistry.QSharpFormat.Convert.ToQSharpFormat(qSharpHamiltonian, qSharpWavefunction);

            return qSharpData;
        }

        private static JordanWignerEncodingData LoadLiquidData()
        {
            var path = Path.Combine("..", "..", "..", "Data", "h2_sto3g_4.dat");
            var problemData = LiQuiD.Deserialize(path).Single();
            Assert.Equal(2L, problemData.NOrbitals);

            var hamiltonian = problemData.OrbitalIntegralHamiltonian.ToFermionHamiltonian(IndexConvention.UpDown);
            Assert.Equal(13, hamiltonian.CountTerms());

            return Encode(hamiltonian, 2);
        }


        private static JordanWignerEncodingData LoadYAMLData()
        {
            var path = Path.Combine("..", "..", "..", "Data", "h2_2_sto6g_1.0au.nw.out.yaml");
            var broombridge = Deserializers.DeserializeBroombridge(path);

            var problemData = broombridge.ProblemDescriptions.First();
            Assert.Equal(4L, problemData.NElectrons);
            Assert.Equal(4L, problemData.NOrbitals);

            var hamiltonian = problemData.OrbitalIntegralHamiltonian.ToFermionHamiltonian(IndexConvention.UpDown);
            Assert.Equal(111, hamiltonian.CountTerms());

            return Encode(hamiltonian, problemData.NElectrons);
        }

        [Fact]
        public void TrotterEstimateEnergyTest()
        {
            void TestOne(JordanWignerEncodingData data)
            {
                using (var qsim = new QuantumSimulator(randomNumberGeneratorSeed: 19))
                {
                    var bits = 4;
                    var trotterStep = .4;
                    var (phaseEst, energyEst) = TrotterEstimateEnergy.Run(qsim, data, bits, trotterStep).Result;
                    Assert.True(phaseEst != 0.0);
                    Assert.True(energyEst != 0.0);
                }
            }

            TestOne(LoadLiquidData());
            TestOne(LoadYAMLData());
        }

        [Fact]
        public void OptimizedTrotterEstimateEnergyTest()
        {
            void TestOne(JordanWignerEncodingData data)
            {
                using (var qsim = new QuantumSimulator(randomNumberGeneratorSeed: 74))
                {
                    var bits = 4;
                    var trotterStep = .4;
                    var (phaseEst, energyEst) = OptimizedTrotterEstimateEnergy.Run(qsim, data, bits, trotterStep).Result;
                    Assert.True(phaseEst != 0.0);
                    Assert.True(energyEst != 0.0);
                }
            }

            TestOne(LoadYAMLData());
        }

        [Fact]
        public void QubitizationEstimateEnergyTest()
        {
            void TestOne(JordanWignerEncodingData data)
            {
                using (var qsim = new QuantumSimulator(randomNumberGeneratorSeed: 42))
                {
                    var bits = 4;
                    var (phaseEst, energyEst) = QubitizationEstimateEnergy.Run(qsim, data, bits).Result;
                    Assert.True(phaseEst != 0.0);
                    Assert.True(energyEst != 0.0);
                }
            };

            TestOne(LoadLiquidData());
        }
    }
}


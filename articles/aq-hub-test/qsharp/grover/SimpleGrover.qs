// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Tets.Samples.Grover {
    open Microsoft.Quantum.Arithmetic;
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Convert;
    open Microsoft.Quantum.Math;
    open Microsoft.Quantum.Arrays;
    open Microsoft.Quantum.Measurement;

    /// # Summary
    /// This operation applies Grover's algorithm to search all possible inputs
    /// to an operation to find a particular marked state.
    ///
    /// # Input
    /// ## nQubits
    /// The number of qubits to allocate.
    ///
    /// # Output
    /// The computational basis state found in the final measurement.
    @EntryPoint()
    operation SearchForMarkedInput(nQubits : Int, idxMarked : Int) : Result[] {
        using (qubits = Qubit[nQubits]) {
            // Initialize a uniform superposition over all possible inputs.
            PrepareUniform(qubits);
            // The search itself consists of repeatedly reflecting about the
            // marked state and our start state, which we can write out in Q#
            // as a for loop.
            for (idxIteration in 0..NIterations(nQubits) - 1) {
                ReflectAboutMarked(idxMarked, qubits);
                ReflectAboutUniform(qubits);
            }
            // Measure and return the answer.
            return ForEach(MResetZ, qubits);
        }
    }

    /// # Summary
    /// Returns the number of Grover iterations needed to find a single marked
    /// item, given the number of qubits in a register.
    function NIterations(nQubits : Int) : Int {
        let nItems = 1 <<< nQubits; // 2^numQubits
        // compute number of iterations:
        let angle = ArcSin(1. / Sqrt(IntAsDouble(nItems)));
        let nIterations = Round(0.25 * PI() / angle - 0.5);
        return nIterations;
    }

    /// # Summary
    /// Reflects about the basis state marked by alternating zeros and ones.
    /// This operation defines what input we are trying to find in the main
    /// search.
    operation ReflectAboutMarked(idxMarked : Int, inputQubits : Qubit[]) : Unit {
        using (outputQubit = Qubit()) {
            within {
                // We initialize the outputQubit to (|0⟩ - |1⟩) / √2,
                // so that toggling it results in a (-1) phase.
                X(outputQubit);
                H(outputQubit);
            } apply {
                // Flip the outputQubit for marked states.
                // Here, we get the state given by the index idxMarked.
                (ControlledOnInt(idxMarked, X))(inputQubits, outputQubit);
            }
        }
    }

}

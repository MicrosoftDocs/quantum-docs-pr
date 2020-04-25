namespace Simulator {
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Diagnostics;
    
    
    function AssertEqualResult (expected : Result, actual : Result) : Unit {
        
    }
    
    
    operation JointMeasureTest () : Unit {
        
        using (qubits = Qubit[3]) {
            let q1 = qubits[0];
            let q2 = qubits[1];
            let q3 = qubits[2];
            let basis = [PauliZ, PauliZ, PauliZ];
            let r1 = Measure(basis, qubits);
            AssertEqualResult(Zero, r1);
            X(q1);
            let r2 = Measure(basis, qubits);
            AssertEqualResult(One, r2);
            AssertEqualResult(One, Measure([PauliZ], [q1]));
            AssertEqualResult(Zero, Measure([PauliZ], [q2]));
            AssertEqualResult(Zero, Measure([PauliZ], [q3]));
            DumpMachine($"JMT-1.txt");
            X(q3);
            let r3 = Measure(basis, qubits);
            AssertEqualResult(Zero, r3);
            AssertEqualResult(One, Measure([PauliZ], [q1]));
            AssertEqualResult(Zero, Measure([PauliZ], [q2]));
            AssertEqualResult(One, Measure([PauliZ], [q3]));
            DumpMachine($"JMT-2.txt");
            X(q2);
            let r4 = Measure(basis, qubits);
            AssertEqualResult(One, r4);
            AssertEqualResult(One, Measure([PauliZ], [q1]));
            AssertEqualResult(One, Measure([PauliZ], [q2]));
            AssertEqualResult(One, Measure([PauliZ], [q3]));
            DumpMachine($"JMT-3.txt");
            DumpRegister($"JMT-q1_q3.txt", [q1, q3]);
            ResetAll(qubits);
        }
    }
    
}



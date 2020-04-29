namespace Microsoft.Quantum.Tests
{
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Convert;
    open Microsoft.Quantum.Diagnostics;
    open Microsoft.Quantum.Math;
    
    function AssertEqual<'T> (expected : 'T, actual : 'T) : Unit { body intrinsic; }

    operation SimpleDumpTest () : Unit {
        
        using (qubits = Qubit[3]) {
            Message($"Starting test");
            DumpMachine($"dumptest-start.txt");
            ApplyToEachCA(H, qubits);
            DumpMachine($"dumptest-h.txt");
            DumpMachine($"");
                
            using (q2 = Qubit[2]) {
                Assert([PauliZ, PauliZ], q2, Zero, $"Qubit should be in Zero state");
                DumpRegister($"dumptest-former.txt", qubits);
                DumpRegister($"dumptest-later.txt", q2);
                DumpRegister($"dumptest-one.txt", [qubits[1]]);
                DumpRegister($"dumptest-two.txt", [qubits[1], q2[1]]);
                DumpRegister((), [qubits[1], q2[1]]);
                DumpRegister("", [q2[1], qubits[1]]);
                DumpMachine($"dumptest-all.txt");
                ApplyToEachCA(Controlled X(qubits, _), q2);
                DumpMachine($"dumptest-entangled.txt");
                DumpRegister((), [qubits[1], q2[1]]);
                DumpRegister($"dumptest-twoQubitsEntangled.txt", [qubits[0], q2[0]]);
                DumpMachine();
                ApplyToEachCA(Adjoint Controlled X(qubits, _), q2);
            }
                
            Adjoint ApplyToEachCA(H, qubits);
        }
            
        DumpMachine($"dumptest-end.txt");
        DumpMachine();
    }
    

    function BigIntTest() : Unit
    {
        let a = 2L;
        let b = 32L;
        AssertEqual(b, a ^ 5);
        AssertEqual(0L, a &&& b);
        AssertEqual(34L, a + b);
        let arr = [true, true, true, false, true];	// Not an even number of bytes
        AssertEqual(23L, BoolArrayAsBigInt(arr));
        let arr2 = [true, true,  true,  false, true,  false, false, false,
                    true, false, false, false, false, false, false, false];	// Exactly 2 bytes
        AssertEqual(279L, BoolArrayAsBigInt(arr2));
        AssertEqual(37L, BoolArrayAsBigInt(BigIntAsBoolArray(37L)));
        let (div, rem) = DivRemL(16L, 5L);
        AssertEqual(3L, div);
        AssertEqual(1L, rem);
        AssertEqual(7L, MaxL(7L, 5L));
        AssertEqual(5L, MinL(7L, 5L));
        AssertEqual(1L, ModPowL(3L, 100L, 2L));
    }
    
}

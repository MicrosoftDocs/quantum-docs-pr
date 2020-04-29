namespace Perf {
    
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;
	open Microsoft.Quantum.Arithmetic;
	open Microsoft.Quantum.Math;
    
    
    operation ModularAddProductLETestHelper (summand : Int, multiplier1 : Int, multiplier2 : Int, modulus : Int, numberOfQubits : Int) : Unit {
        
        using (register = Qubit[numberOfQubits * 2]) {
            let summandLE = LittleEndian(register[0 .. numberOfQubits - 1]);
            let multiplierLE = LittleEndian(register[numberOfQubits .. 2 * numberOfQubits - 1]);
            ApplyXorInPlace(summand, summandLE);
            ApplyXorInPlace(multiplier1, multiplierLE);
            MultiplyAndAddByModularInteger(multiplier2, modulus, multiplierLE, summandLE);
            let expected = ModulusI(summand + multiplier1 * multiplier2, modulus);
            let actual = MeasureInteger(summandLE);
            let actualMult = MeasureInteger(multiplierLE);
            ResetAll(register);
        }
    }
    
    
    /// # Summary
    /// Exhaustively tests Microsoft.Quantum.Canon.ModularAddProductLE
    /// on 4 qubits with modulus 13
    /// NOTE: this one does only half of the tests (as opposed to Canon tests.)
    operation ModularAddProductLETest () : Unit {
        
        let numberOfQubits = 4;
        let modulus = 13;
        
        for (summand in 0 .. 2 .. modulus - 1) {
            Message($"summand: {summand}");
            
            for (multiplier1 in 0 .. modulus - 1) {
                
                for (multiplier2 in 0 .. modulus - 1) {
                    ModularAddProductLETestHelper(summand, multiplier1, multiplier2, modulus, numberOfQubits);
                }
            }
        }
    }
    
}



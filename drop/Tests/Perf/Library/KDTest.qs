namespace Perf {
    open Microsoft.Quantum.Math;
    open Microsoft.Quantum.Intrinsic;
	open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.ErrorCorrection;

    
    // NOTE: In Canon, this tests all cases when two magic states are wrong. Here we only
    //       run it with one quarter of them
    
    /// # Summary
    /// Tests if the distillation routine works as intended.
    /// This protocol is supposed to catch any weight 2 errors
    /// on the input magic states, assuming perfect Cliffords.
    /// Here we do not attempt to correct detected errors,
    /// since corrections would make the output magic state
    /// less accurate, compared to post-selection on zero syndrome.
    ///
    //// NOTE: In Canon, this tests all cases when two magic states are wrong. Here we only
    ////       run it with one quarter of them
    operation KDTest () : Unit {
        
        using (rm = Qubit[15]) {
            ApplyToEach(Ry(PI() / 4.0, _), rm);
            let acc = KnillDistill(rm);
            Ry(-PI() / 4.0, rm[0]);
            
            // Cases where a single magic state is wrong
            for (idx in 0 .. 14) {
                ResetAll(rm);
                ApplyToEach(Ry(PI() / 4.0, _), rm);
                Y(rm[idx]);
                let acc1 = KnillDistill(rm);
                NoOp();
            }
            
            //// Cases where two magic states are wrong..
            for (idxFirst in 0 .. 4 .. 13) {
                
                for (idxSecond in idxFirst + 1 .. 14) {
                    ResetAll(rm);
                    ApplyToEach(Ry(PI() / 4.0, _), rm);
                    Y(rm[idxFirst]);
                    Y(rm[idxSecond]);
                    let acc1 = KnillDistill(rm);
                    NoOp();
                }
            }
            
            ResetAll(rm);
        }
    }
    
}



namespace Microsoft.Quantum.Samples {

    open Microsoft.Quantum.Primitive;
    
    operation Set(desired: Result, q1: Qubit) : Unit
    {
        let current = M(q1);

        if (desired != current)
        {
            X(q1);
        }
    }

    operation EPR (q1 : Qubit, q2 : Qubit) : Unit  
    {   
        H (q1);
        CNOT (q1,q2);
    }

    operation Teleport (msg : Qubit, here : Qubit, there : Qubit) : Unit {   
        EPR (here, there);
        CNOT (msg, here);
        H (msg);
            
        let m_here = M (here);
        if (m_here == One) { 
            X (there);
        }
            
        let m_msg = M (msg);
        if (m_msg == One) { 
            Z (there);
        }
    }

    operation TeleportTest (msg: Result) : (Result) {
        using (qubits = Qubit[3]) {
            let msgQ = qubits[0];

            // Set msgQ to message state
            if (M(msgQ) != msg) {
                X (msgQ);
            }

            Teleport (msgQ, qubits[1], qubits[2]);

            let res = M (qubits[2]);

            ResetAll(qubits);
			return res;
        }
    }
}
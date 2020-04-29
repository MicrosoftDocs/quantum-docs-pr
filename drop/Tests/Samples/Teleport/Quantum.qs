namespace Quantum.Teleport
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;


    /// # Summary
    /// Direct implementation of Teleport's circuit
    operation TeleportCircuit() : Unit {
        Message("Running teleport circuit");
        
        using (qubits = Qubit[3]) {
            // Entangle
            H(qubits[1]);
            CNOT(qubits[1], qubits[2]);

            // Encode
            PrepareRandomMessage(qubits[0]);
            CNOT(qubits[0], qubits[1]);
            H(qubits[0]);
            let classicInfo = M(qubits[0]);

            // Decode
            if (M(qubits[1]) == One) { X(qubits[2]); }
            if (classicInfo == One)  { Z(qubits[2]); }

            // Report message received:
            if (IsPlus(qubits[2]))  { Message("Received |+>"); }
            if (IsMinus(qubits[2])) { Message("Received |->"); }

            ResetAll(qubits);
        }
    }
    
    /// # Summary
    /// A version of Teleport that is not circuit-based.
    operation Teleport() : Unit {
        using (qubits = Qubit[2]) {
            let msg = qubits[0];
            let channel = qubits[1];

            // Entangle
            Entangle(channel, msg);

            // Ask Alice to encode message on entangled qubit
            let classicInfo = Encode(channel);

            // Decode Alice's message into the msg qubit:
            Decode(channel, classicInfo, msg);
            
            // Report message received:
			Message(IsPlus(msg) ? "Received |+>" | "Received |->");
            ResetAll(qubits);
        }
    }

    /// # Summary
    /// Operation that takes |00> to (|00> + |11>)
    operation Entangle(q1: Qubit, q2: Qubit) : Unit {
        H(q1);
        CNOT(q1, q2);
    }

    /// # Summary
    /// This is what Alice does: encodes a random message
    /// using an entangled qubit (channel) that shares with Bob.
    /// It returns the classical piece of data that Bob needs to 
    /// decode the message.
    operation Encode(channel: Qubit) : Result {
        using (msg = Qubit()) {
            PrepareRandomMessage(msg);
            CNOT(msg, channel);
            H(msg);
            let r = M(msg);

            Reset(msg);
			return r;
        }
    }

    /// # Summary
    /// This is what Bob's does: decodes the message sent by Alice from the entangled qubit (channel)
    /// with the piece of classical info sent by her.
    /// After this operation `msg` contains the original state sent by Alice.
    operation Decode(channel : Qubit, classicalInfo : Result, msg : Qubit) : Unit {
        if (M(channel) == One) { X(msg); }
        if (classicalInfo == One) { Z(msg); }
    }

    /// -------------------------------
    /// Helper operations
    /// -------------------------------
    

    /// # Summary
    /// Sets the qubit's state to |+>
    operation SetPlus(q: Qubit) : Unit {
        Reset(q);
        H(q);
    }
    
    /// # Summary
    /// Sets the qubit's state to |->
    operation SetMinus(q: Qubit) : Unit {
        Reset(q);
        X(q);
        H(q);
    }

    /// # Summary
    /// Returns true if qubit is |+> (assumes qubit is either |+> or |->)
    operation IsPlus(q: Qubit) : Bool {
        return (Measure([PauliX], [q]) == Zero);
    }

    /// # Summary
    /// Returns true if qubit is |-> (assumes qubit is either |+> or |->)
    operation IsMinus(q: Qubit) : Bool {
        return (Measure([PauliX], [q]) == One);
    }
    
    /// # Summary
    /// Randomly prepares the qubit into |+> or |->
    operation PrepareRandomMessage(q: Qubit) : Unit {
        
        let choice = RandomInt(2);

        if (choice == 0) {
            Message("Sending |->");
            SetMinus(q);
        } else {
            Message("Sending |+>");
            SetPlus(q);
        }
    }
}
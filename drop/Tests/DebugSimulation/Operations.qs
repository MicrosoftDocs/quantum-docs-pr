namespace DebugSimulation
{
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Diagnostics;

    operation DumpTest() : Unit
    {
        using(q = Qubit[4])
        {
            X(q[1]);
            X(q[2]);
            AssertQubit(Zero, q[0]);
            AssertQubit(One,  q[1]);
            AssertQubit(One,  q[2]);
            AssertQubit(Zero, q[3]);

            SWAP(q[2], q[1]);
            AssertQubit(Zero, q[0]);
            AssertQubit(One,  q[1]);
            AssertQubit(One,  q[2]);
            AssertQubit(Zero, q[3]);

            DumpMachine(());

            // These should all be equivalent
            DumpRegister((), [q[0],q[1],q[2],q[3]]);
            DumpRegister((), [q[3],q[1],q[2],q[0]]);
            DumpRegister((), [q[3],q[2],q[1],q[0]]);
            DumpRegister((), [q[0],q[2],q[1],q[3]]);
                
            ResetAll(q);
        }
    }
}

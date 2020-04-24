namespace Perf
{
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Diagnostics;

    operation ToffoliChainTest (count : Int) : Unit
    {
        using (qs = Qubit[count])
        {
            X(qs[0]);
            X(qs[1]);
            for (idx1 in 0..count-3)
            {
                CCNOT(qs[idx1], qs[idx1+1], qs[idx1+2]);
            }
            // Now all qubits should be in the One state
            for (idx2 in 0..count-1)
            {
                AssertQubit(One, qs[idx2]);
            }
            // Now step back up
            for (idx3 in count-1..-1..2)
            {
                CCNOT(qs[idx3], qs[idx3-1], qs[idx3-2]);
            }
            // Now qubits with (count-idx) divisible by 3 are Zero, the rest are One
            for (idx4 in 0..count-1)
            {
                if ((count - idx4) % 3 == 0)
                {
                    AssertQubit(Zero, qs[idx4]);
                
                }
                else
                {
                    AssertQubit(One, qs[idx4]);
                    X(qs[idx4]);
                }
            }
        }
    }

    operation ToffoliChainTest1000 () : Unit
    {
        ToffoliChainTest(1000);
    }

    operation ToffoliChainTest10000 () : Unit
    {
        ToffoliChainTest(10000);
    }

    operation ToffoliChainTest50000 () : Unit
    {
        ToffoliChainTest(50000);
    }
}

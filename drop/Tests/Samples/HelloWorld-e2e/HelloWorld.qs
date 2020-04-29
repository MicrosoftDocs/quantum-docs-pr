namespace Microsoft.Quantum.Samples{

    operation HelloWorld (n: Int) : Int 
    {
        mutable r = n + 1;
        set r += 2;
        set r += 3;
        return r;
    }
}

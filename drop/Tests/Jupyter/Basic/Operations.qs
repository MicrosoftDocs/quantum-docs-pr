///
/// Q# code should be in one or more .qs files that live 
/// in the same directory as the python clasical driver.
///

namespace Microsoft.Quantum.SanityTests
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

    /// # Summary
    /// Returns true if qubit is $|+\rangle$ (assumes qubit is either $|+\rangle$ or $|-\rangle$)
    operation IsPlus(q: Qubit) : Bool {
        return (Measure([PauliX], [q]) == Zero);
    }

    /// # Summary
    /// Returns true if qubit is |-\rangle$ (assumes qubit is either |+\rangle$ or |-\rangle$)
    operation IsMinus(q: Qubit) : Bool {
        return (Measure([PauliX], [q]) == One);
    }
}

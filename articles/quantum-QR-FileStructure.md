---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Intent and product brand in a unique string of 43-59 chars including spaces | Microsoft Docs 
description: 115-145 characters including spaces. Edit the intro para describing article intent to fit here. This abstract displays in the search result.
services: service-name-with-dashes-AZURE-ONLY 
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: QuantumWriter
ms.author: MSFT-alias-person-or-DL
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# ms.service: service-name-from-white-list
# product-name-from-white-list

# Optional fields. Don't forget to remove # if you need a field.
# ms.custom: can-be-multiple-comma-separated
# ms.devlang:devlang-from-white-list
# ms.suite: 
# ms.tgt_pltfrm:
# ms.reviewer:
# manager: MSFT-alias-manager-or-PM-counterpart
---

# File Structure

A Q# file consists of one or more namespace declarations.

Each namespace declaration contains definitions for user-defined types,
operations, and functions.
A namespace declaration may contain any number of each type of definition,
but it must contain at least one definition.

## User Defined Type Declarations

Q# provides a way for users to declare new user-defined types, 
as described in the [Q# type model](quantum-QR-TypeModel) section. 
User-defined types are distinct even if the underlying  types are identical, 
and there is no automatic conversion between two user-defined types 
even if the underlying types are identical.

A user-defined type declaration consists of the keyword `newtype`, followed by 
the name of the user-defined type, an `=`, a valid type specification, and
a terminating semicolon. 

For example:

    newtype PairOfInts = (Int, Int);

A file may contain zero or more user-defined type declarations. 
Type names must be unique within a namespace and may not conflict with 
operation and function names.

## Operation Definitions

Operations are the core of Q#, 
roughly analogous to functions in other languages. 
Each Q# source file may define any number of operations, including none 
if the file only defines one or more user-defined types.

An operation definition consists of the keyword `operation`, 
followed by the symbol that is the operation’s name, 
a typed identifier tuple that defines the arguments to the operation,
a colon `:`, a type annotation that describes the operation’s result type, 
an open brace `{`,
an optional body definition, 
an optional adjoint definition, 
an optional controlled definition, 
an optional controlled adjoint definition,
and a final closing brace `}`.

An operation should define a controlled adjoint variant if and only if 
it defines both a controlled variant and an adjoint variant.

Operation names must be unique within a namespace and may not conflict with 
type and function names.

### Body

The body of an operation is the Q# code that implements the operation. 
It is legal to define an operation with no body; for instance, 
primitive operations such as Paulis and the Hadamard gate are defined this way. 
A body definition consists of the keyword `body`, followed by a statement block.

### Adjoint

The adjoint of an operation specifies how the complex conjugate transpose
of the operation is implemented. 
It is legal to specify an operation with no adjoint; 
for instance, measurement operations have no adjoint because 
they are not invertible. 
An operation supports the `Adjoint` functor if and only if its declaration
contains an adjoint declaration.

An adjoint definition consists of the keyword `adjoint`, followed by one of:

 - The keyword `self` indicating that the operation is its own adjoint.
 - The keyword `auto` indicating that the Q# compiler should generate an adjoint 
    for the operation, based on the operation’s body.
    The generated version will apply the adjoint of each quantum operation
    in the body, in reverse order to the order in the body.
    Non-quantum code may be reorganized to ensure values are computed
    before they are used.
 - A statement block that implements the operation’s adjoint. 

Thus, an operation definition contain

```qsharp
adjoint self
```

or

```qsharp
adjoint auto
```

or 

```qsharp
adjoint none
```

or 

```qsharp
adjoint {
    // Code for the adjoint goes here
}
```

If none of these appear, then no adjoint is defined;.

An operation whose body contains repeat-until-success loops or measurements 
or that calls another operation that does not support the `Adjoint` functor
may not specify the `auto` keyword.

If an operation has no body but should have an adjoint defined, 
it should specify `adjoint auto` or `adjoint self`.

### Controlled

The controlled version of an operation specifies how a quantum-controlled 
version of the operation is implemented. 
A more complete description is provided above in the [Controlled](quantum-QR-TypeModel#controlled)
section, above.

It is legal to specify an operation with no controlled version; 
for instance, measurement operations have no controlled version because 
they are not controllable. 
An operation supports the `Controlled` functor if and only if its definition
contains a controlled definition.

A controlled definition consists of the keyword `controlled`, followed by
one of:

 - The keyword `auto` indicating that the Q# compiler should generate a 
    controlled version of the operation based on the operation’s body. 
    The generated version will apply quantum control to every *quantum* 
    operation.
    Non-quantum code will be unmodified.
 - A `(`, a symbol that will be the name of the variable holding the 
    array of control qubits, `)`, and a statement block that implements the 
    controlled version of the operation. 

Thus, an operation definition contain

```qsharp
controlled self
```

or 

```qsharp
controlled(controls) {
    // Code for the controlled version goes here.
    // "controls" is bound to the array of control qubits.
}
```

An operation whose body contains repeat-until-success loops or measurements 
or that calls another operation that does not support the `Controlled` functor
may not specify the `auto` keyword.

If an operation has no body but should have a controlled version defined, 
it should specify `controlled auto`.

### Controlled Adjoint

The controlled adjoint version of an operation specifies how a 
quantum-controlled version of the adjoint of the operation is implemented. 
It is legal to specify an operation with no controlled adjoint version; 
for instance, measurement operations have no controlled adjoint version 
because they are neither controllable nor invertible. 

An operation should define a controlled adjoint variant if and only if 
it defines both a controlled variant and an adjoint variant.

A controlled adjoint definition consists of the keyword `adjoint`, 
then the keyword `controlled`, followed either by the keyword `auto` 
indicating that the Q# compiler should generate a controlled adjoint version 
of the operation based on the operation’s body, or by `(`, a symbol that will 
be the name of the variable holding the array of control qubits, `)`, 
and a statement block that implements the controlled adjoint version of the 
operation. 

An operation whose body contains repeat-until-success loops or measurements 
or that calls another operation that has no controlled adjoint version 
may not specify the `auto` keyword.

If a statement block is provided for either the adjoint or controlled version 
of an operation, and `auto` is specified for the controlled adjoint version, 
then the provided statement block is used to generate the 
controlled adjoint version. 
If a statement block is provided for both and the controlled adjoint version 
is specified as `auto`, then the controlled adjoint version will be generated 
from the controlled version’s statement block.

If an operation has no body but should have a controlled adjoint version 
defined, it should specify `adjoint controlled auto`.

### Example Operation Definitions

An operation definition might be as simple as the following, 
which defines the primitive Pauli X operation:

```qsharp
operation X (q : Qubit) : () {
    adjoint self
    controlled auto
    adjoint controlled auto
}
```

The following defines the teleport operation. 

```qsharp
namespace Microsoft.Quantum.Samples {
    // Entangle two qubits.
    // Assumes that both qubits are in the |0> state.
    operation EPR (q1 : Qubit, q2 : Qubit) : () {
        body
        {
            H(q2);
            CNOT(q2, q1);
        }
    }

    // Teleport the quantum state of the source to the target.
    // Assumes that the target is in the |0> state.
    operation Teleport (source : Qubit, target : Qubit) : () {
        body {
            // Get a temporary for the Bell pair
            using (ancilla = Qubit[1]) {
                let temp = ancilla[0];

                // Create a Bell pair between the temporary and the target
                EPR(target, temp);

                // Do the teleportation
                CNOT(source, temp);
                H(source);
                if (M(source) == One) {
                    X(target);
                }
                if (M(temp) == One) {
                    Z(target);
                }
            }
        }
    }
}
```

## Function Definitions

Functions are purely classical routines in Q#. 
Each Q# source file may define any number of functions, including none.

A function definition consists of the keyword `function`, followed by 
the symbol that is the function’s name, a typed identifier tuple as for 
an operation, a type annotation that describes the function's result type, 
and a statement block that defines the function.

Note that a statement block defining a function must be enclosed in
`{` and `}` like any other statement block.
An external definition requires a terminating semicolon.

Function names must be unique within a namespace and may not conflict with 
operation and type names.
Functions may not allocate qubits or call operations.

For example,

```qsharp
function DotProduct(a : Double[], b : Double[]) : Double {
    if (Length(a) != Length(b) {
        fail "Arrays are not compatible";
    }
    mutable accum = 0.0;
    for (i in 0..Length(a)-1) {
        set accum = accum + a[i] * b[i];
    }
    return accum;
}
```

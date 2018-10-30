---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: File Structure | Microsoft Docs 
description: Q# File Structure
author: QuantumWriter
uid: microsoft.quantum.qsharp-ref.file-structure
ms.author: Alan.Geller@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# For Quantum products none of these categories have been defined  yet.
# ms.service: service-name-from-white-list
# ms.prod: product-name-from-white-list
# ms.technology: tech-name-from-white-list
---

# File Structure

A Q# file consists of a sequence of namespace declarations.
Each namespace declaration contains definitions for user-defined types,
operations, and functions.
A namespace declaration may contain any number of each type of definition.

The only text that can appear outside of a namespace declaration is comments.
In particular, documentation comments for a namespace precede the declaration.

## Namespace Declarations

A Q# file will typically have exactly one namespace declaration,
but may have none (and be empty or just contain comments) or may contain
multiple namespaces.
Namespace declarations may not be nested.

The same namespace may be declared in multiple Q# files that are compiled
together, as long as there are no type, operation, or function definitions
with the same name.
In particular, it is invalid to define the same type in the same namespace
in multiple files, even if the definitions are identical.

A namespace declaration consists of the keyword `namespace`, followed by the
name of the namespace, an open brace `{`, the definitions contained in the
namespace, and a close brace `}`.
Namespace names follow the .NET pattern of a sequence of one or more legal
symbols separated by periods `.`.
For instance, `MyQuantumStuff` and `Microsoft.Quantum.Canon` are valid
namespace names.
By convention, the symbols in a namespace name are capitalized,
but this is not required.

Definitions may appear in any order in a namespace declaration.
References to definitions that appear "below" are resolved properly;
there is no need for the definition of a type, operation, or function
to precede a reference to it.

## Open Directives

Within a namespace block, the `open` directive may be used to allow
abbreviated reference to constructs from another namespace.
This consists of the `open` keyword, followed by the namespace to be
opened and a terminating semicolon.

`open` directives must appear before any `function`, `operation`, or
`newtype` definitions in the namespace block.
The `open` directive applies to the entire namespace block.

For instance,

```qsharp
open Microsoft.Quantum.Canon;
```

## User-Defined Type Declarations

Q# provides a way for users to declare new user-defined types, as described in
the [Q# type model](xref:microsoft.quantum.qsharp-ref.type-model) section.
User-defined types are distinct even if the base types are identical.
In particular, there is no automatic conversion between values of two
user-defined types even if the base types are identical.

A user-defined type declaration consists of the keyword `newtype`, followed by
the name of the user-defined type, an `=`, a valid type specification, and
a terminating semicolon.

For example:

```qsharp
newtype PairOfInts = (Int, Int);
```

Each Q# source file may define any number of user-defined type declarations,
including none.
Type names must be unique within a namespace and may not conflict with
operation and function names.

## Operation Definitions

Operations are the core of Q#, roughly analogous to functions
in other languages.
Each Q# source file may define any number of operations, including none.

Operation names must be unique within a namespace and may not conflict with
type and function names.

An operation definition consists of the keyword `operation`,
followed by the symbol that is the operation’s name,
a typed identifier tuple that defines the arguments to the operation,
a colon `:`, a type annotation that describes the operation’s result type,
an open brace `{`, a list of specializations, and a final closing brace `}`.

Q# operations may have up to four specializations:

- The `body` specialization specifies the implementation of the operation with
  no functors applied.
- The `adjoint` specialization specifies the implementation of the operation with
  the `Adjoint` functor modifier applied.
- The `controlled` specialization specifies the implementation of the operation with
  the `Controlled` functor modifier applied.
- The `adjoint controlled` specialization specifies the implementation of the
  operation with both the `Adjoint` and `Controlled` functor modifiers applied.
  This specialization can also be named `controlled adjoint`.

All operations must provide at least a `body` specialization.

An operation should have an adjoint controlled specialization if and only if
it has both a controlled specialization and an adjoint specialization.

### Specialization Definitions

An operation specialization consists of the specialization tag (`body`, etc.)
followed by one of:

- An explicit definition as described below.
- A directive that tells the compiler how to generate the specialization,
  one of:
  - :new: `intrinsic`, which indicates that the specialization is provided by
    the simulator or other machine definition.
  - :new: `distribute`, which may be used with the `controlled` and
    `adjoint controlled` specializations.
    When used with `controlled`, it indicates that the compiler should compute
    the specialization by applying `Controlled` to all of the operations in
    the `body`.
    When used with `adjoint controlled`, this indicates that the compiler
    should compute the specialization by applying `Controlled` to all of the
    operations in the `adjoint` specialization.
  - :new: `invert`, which indicates that the compiler should compute the
    `adjoint` specialization by inverting the `body`, applying operations
    in the reverse order and applying the adjoint of each operation.
    When used with `adjoint controlled`, this indicates that the compiler
    should compute the specialization by inverting the `controlled`
    specialization.
  - `self`, to indicate that the adjoint specialization is the
    the same as the definition of the `body` specialization.
    This is legal for the `adjoint` and `adjoint controlled` specializations.
    For `adjoint controlled`, `self` implies that the `adjoint controlled`
    specialization is the same as the `controlled` specialization.
  - `auto`, to indicate that the compiler should select an
    appropriate directive to apply.
    `auto` may not be used for the `body` specialization.

The directives and `auto` all require a closing semi-colon `;`.

:new: An explicit definition consists of an argument tuple followed by
a statement block containing the Q# code that implements the specialization.
In the argument list, `...` is used to represent the arguments
declared for the operation as a whole.
For `body` and `adjoint`, the argument list should always be `(...)`;
for `controlled` and `adjoint controlled`, the argument list should be
a symbol that represents the array of control qubits, followed by `...`,
enclosed in parentheses; for example, `(controls,...)`.

:new: In version 0.3, the argument tuple may be omitted for the `body` and
`adjoint` specializations, and may contain only the qubit array name for the
`controlled` and `adjoint controlled` specializations.
This maintains backward compatibility with earlier releases, but is
deprecated, and will be flagged as a warning.

For the `auto` keyword, if the `body` is `intrinsic`, so are all other
specializations.
If an explicit definition of the `body` is provided, then:

- The `adjoint` specialization is `invert`.
- The `controlled` specialization is `distribute`.
- The `adjoint controlled` specialization is `invert` if an explicit
  definition for `controlled` is given but not one for `adjoint`, and
  `distribute` otherwise.

:new: If an operation has only a `body` specialization, and provides an explicit
definition for that specialization, then the `body` keyword and corresponding pair
of open and close braces `{` and `}` may be omitted.
For instance, this operation:

```qsharp
operation CountOnes(qs: Qubit[]) : Int
{
    body (...)
    {
        mutable n = 0;
        for (q in qs)
        {
            n = n + (M(q) == One ? 1 | 0);
        }
        return n;
    }
}
```

may be written more compactly as:

```qsharp
operation CountOnes(qs: Qubit[]) : Int
{
    mutable n = 0;
    for (q in qs)
    {
        n = n + (M(q) == One ? 1 | 0);
    }
    return n;
}
```

### Adjoint

The adjoint of an operation specifies how the complex conjugate transpose
of the operation is implemented.
It is legal to specify an operation with no adjoint;
for instance, measurement operations have no adjoint because
they are not invertible.
An operation supports the `Adjoint` functor if and only if its declaration
contains an adjoint declaration.

An operation whose body contains repeat-until-success loops, set statements,
measurements, return statements, or calls to other operations that do not
support the `Adjoint` functor, may not specify the `invert` directive.

### Controlled

The controlled version of an operation specifies how a quantum-controlled
version of the operation is implemented.
A more complete description is provided in the
[Controlled](xref:microsoft.quantum.qsharp-ref.type-model#controlled)
section.

It is legal to specify an operation with no controlled version;
for instance, measurement operations have no controlled version because
they are not controllable.
An operation supports the `Controlled` functor if and only if its definition
contains a controlled definition.

An operation whose body contains repeat-until-success loops, set statements,
measurements, or calls to other operations that does not support the
`Controlled` functor, may not specify the `distribute` directive.

### Controlled Adjoint

The controlled adjoint version of an operation specifies how a
quantum-controlled version of the adjoint of the operation is implemented.
It is legal to specify an operation with no controlled adjoint version;
for instance, measurement operations have no controlled adjoint version
because they are neither controllable nor invertible.

An operation should define a controlled adjoint specialization if and only if
it defines both a controlled specialization and an adjoint specialization.

An operation whose body contains repeat-until-success loops, set statements,
return statements, and/or measurements or calls to other operations that do
not have a controlled adjoint version may not specify the `invert` or
`distributed` directive.

If a statement block is provided for either the adjoint or controlled version
of an operation, and `auto` is specified for the controlled adjoint version,
then the provided statement block is used to generate the
controlled adjoint version.
If a statement block is provided for both and the controlled adjoint version
is specified as `auto`, then the controlled adjoint version will be generated
from the controlled version’s statement block.

### Examples

An operation definition might be as simple as the following,
which defines the primitive Pauli X operation:

```qsharp
operation X (q : Qubit) : Unit
{
    body intrinsic;
    adjoint intrinsic;
    controlled intrinsic;
    adjoint controlled intrinsic;
}
```

The following defines the teleport operation.

```qsharp
namespace Microsoft.Quantum.Samples
{
    // Entangle two qubits.
    // Assumes that both qubits are in the |0> state.
    operation EPR (q1 : Qubit, q2 : Qubit) : Unit
    {
        H(q2);
        CNOT(q2, q1);
    }

    // Teleport the quantum state of the source to the target.
    // Assumes that the target is in the |0> state.
    operation Teleport (source : Qubit, target : Qubit) : Unit
    {
        // Get a temporary for the Bell pair
        using (ancilla = Qubit())
        {
            // Create a Bell pair between the temporary and the target
            EPR(target, ancilla);

            // Do the teleportation
            CNOT(source, ancilla);
            H(source);
            if (M(source) == One)
            {
                X(target);
            }
            if (M(ancilla) == One)
            {
                Z(target);
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

Function names must be unique within a namespace and may not conflict with
operation and type names.
Functions may not allocate qubits or call operations.

For example,

```qsharp
function DotProduct(a : Double[], b : Double[]) : Double
{
    if (Length(a) != Length(b))
    {
        fail "Arrays are not compatible";
    }

    mutable accum = 0.0;
    for (i in 0..Length(a)-1)
    {
        set accum = accum + a[i] * b[i];
    }

    return accum;
}
```

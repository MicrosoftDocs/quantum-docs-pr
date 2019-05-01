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
A namespace declaration may contain any number of each type of definition, and in any order.
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

Within a namespace block, the `open` directive may be used to 
import all types and callables defined in a certain namespace and refer to them by their unqualified name. 

Such an `open` directive consists of the `open` keyword, followed by the namespace to be
opened and a terminating semicolon.

For instance,

```qsharp
open Microsoft.Quantum.Canon;
```

Optionally, a short name for the opened namespace may be defined 
such that all elements from that namespace can (and need) to be qualified by the defined short name. 
Such a short name is defined by adding the keyword `as` followed by the desired short name before the semicolon in an `open` directive:

```qsharp
open Microsoft.Quantum.Math as Math;
```

All `open` directives must appear before any `function`, `operation`, or `newtype` definitions in the namespace block.
The `open` directive applies to the entire namespace block within a file.

## User-Defined Type Declarations

Q# provides a way for users to declare new user-defined types, as described in
the [Q# type model](xref:microsoft.quantum.language.type-model) section.
User-defined types are distinct even if the base types are identical.
In particular, there is no automatic conversion between values of two
user-defined types even if the underlying types are identical.

A user-defined type declaration consists of the keyword `newtype`, followed by
the name of the user-defined type, an `=`, a valid type specification, and
a terminating semicolon.

For example:

```qsharp
newtype PairOfInts = (Int, Int);
```

Each Q# source file may define any number of user-defined type declarations.
Type names must be unique within a namespace and may not conflict with
operation and function names.

It is not possible to define circular dependencies between user defined types. 
Recursive types are thus not possible within Q#.

## Operation Definitions

Operations are the core of Q#, roughly analogous to functions in other languages.
Each Q# source file may define any number of operations.

Operation names must be unique within a namespace and may not conflict with type and function names.

An operation definition consists of the keyword `operation`,
followed by the symbol that is the operation’s name,
a typed identifier tuple that defines the arguments to the operation,
a colon `:`, a type annotation that describes the operation’s result type,
optionally an annotation with the operation characteristics, 
an open brace `{`, the body of the operation declaration, and a final closing brace `}`.

The body of the operation declaration either consists of the default implementation or of a list of specializations.
The default implementation can be specified directly within the declaration 
if only the implementation of the default body specialization needs to specified explicitly.
In this case, an annotation with the operation characteristics in the declaration is useful 
to ensure that the compiler auto-generates other specializations based on the default implementation. 

For example 

```qsharp
operation PrepareEntangledPair(here : Qubit, there : Qubit) : Unit {
is Adj + Ctl { // implies the existence of an adjoint, a controlled, and a controlled adjoint specialization
    H(here);
    CNOT(here, there);
}
```

Operation characteristics define what kinds of functors can be applied to the declared operation, and what effect they have. 
If an operation implements a unitary transformation, then it is possible to define how the operation acts when *adjointed* or *controlled*.
An adjoint specialization of an operation specifies how it acts when run in reverse, while a controlled variant specifies how an operation acts when applied conditioned on the state of a quantum register.
The existence of these specializations can be declared as part of the operation signature. The corresponding implementation for each such implicitly declared specialization is then generated by the compiler. 
In the example above, and adjoint, a controlled, and a controlled adjoint specialization are generated by the compiler. 

In the case where the implementation cannot be generated by the compiler, it can be explicitly specified. 
Such explicit specialization declarations can either consist of a suitable generation directive, or a user defined implementation. 
The code in `PrepareEntangledPair` above for example is equivalent to the code below containing explicit specialization declarations: 

```qsharp
operation PrepareEntangledPair(here : Qubit, there : Qubit) : Unit {
    body (...) { // default body specialization
        H(here);
        CNOT(here, there);
    }

    adjoint auto; // auto-generate adjoint specialization
    controlled auto; // auto-generate controlled specialization
    controlled adjoint auto; // auto-generate controlled adjoint specialization
}
```
The keyword `auto` indicates that the compiler should determine how to generate the specialization implementation.
If the compiler cannot generate the implementation for a certain specialization automatically, or if a more efficient implementation can be given, then the implementation may also be manually defined.

```qsharp
operation PrepareEntangledPair(here : Qubit, there : Qubit) : Unit
is Ctl + Adj {
    body (...) { // default body specialization
        H(here);
        CNOT(here, there);
    }

    controlled (cs, ...) { // user defined implementation for the controlled specialization
        Controlled H(cs, here);
        Controlled X(cs + [here], there);
    }

    adjoint invert; 
    controlled adjoint invert; 
}
```

In the example above, `adjoint invert;` indicates that the adjoint specialization is to be generated by inverting the body implementation, 
and `controlled adjoint invert;` indicates that the controlled adjoint specialization is to be generated by inverting the given implementation of the controlled specialization.

For an operation to support application of the `Adjoint` and/or `Controlled` functor, its return type necessarily needs to be `Unit`. 


### Explicit Specialization Definitions

Q# operations declaration may contain the following explicit declarations:

- The `body` specialization specifies the implementation of the operation with no functors applied.
- The `adjoint` specialization specifies the implementation of the operation with the `Adjoint` functor modifier applied.
- The `controlled` specialization specifies the implementation of the operation with the `Controlled` functor modifier applied.
- The `adjoint controlled` specialization specifies the implementation of the
  operation with both the `Adjoint` and `Controlled` functor modifiers applied.
  This specialization can also be named `controlled adjoint`, since the two functors commute.


An operation specialization consists of the specialization tag (`body`, etc.)
followed by one of:

- An explicit definition as described below.
- A directive that tells the compiler how to generate the specialization,
  one of:
  - `intrinsic`, which indicates that the specialization is provided by
    the simulator or other machine definition.
  - `distribute`, which may be used with the `controlled` and
    `adjoint controlled` specializations.
    When used with `controlled`, it indicates that the compiler should compute
    the specialization by applying `Controlled` to all of the operations in
    the `body`.
    When used with `adjoint controlled`, this indicates that the compiler
    should compute the specialization by applying `Controlled` to all of the
    operations in the `adjoint` specialization.
  - `invert`, which indicates that the compiler should compute the
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

An explicit definition consists of an argument tuple followed by
a statement block containing the Q# code that implements the specialization.
In the argument list, `...` is used to represent the arguments
declared for the operation as a whole.
For `body` and `adjoint`, the argument list should always be `(...)`;
for `controlled` and `adjoint controlled`, the argument list should be
a symbol that represents the array of control qubits, followed by `...`,
enclosed in parentheses; for example, `(controls,...)`.

For the `auto` keyword, if the `body` is `intrinsic`, so are all other
specializations.
If an explicit definition of the `body` is provided, then:

- The `adjoint` specialization is `invert`.
- The `controlled` specialization is `distribute`.
- The `adjoint controlled` specialization is `invert` if an explicit
  definition for `controlled` is given but not one for `adjoint`, and
  `distribute` otherwise.

If one or more specializations besides the default body need to be explicitly defined, 
then the implementation for the default body needs to be wrapped into a suitable specialization declaration as well:

```qsharp
operation CountOnes(qs: Qubit[]) : Int
{
    body (...) // default body specialization
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
[Controlled](xref:microsoft.quantum.language.type-model#controlled)
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

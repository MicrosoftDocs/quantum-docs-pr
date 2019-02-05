---
title: Q# Style Guide | Microsoft Docs
description: Q# Style Guide
author: cgranade
ms.author: chgranad
ms.date: 10/12/2018
ms.topic: article
uid: microsoft.quantum.contributing.style
---

# Q# Style Guide #
## General Conventions ##

- The conventions listed here are suggestions only, and should likely be disregarded when they would result in less readable or useful code.
  Put differently, disregarding conventions should always be an intentional decision to produce more useful code, and not an accident.

## Naming Conventions ##

In offering the Quantum Development Kit, we strive for function and operation names that help quantum developers write programs that are easy to read and that minimize surprise.
An important part of that is that when we choose names for functions, operations, and types, we are establishing the *vocabulary* that programmers use to express quantum concepts; with our choices, we either help or hinder them in their effort to clearly communicate.
This places a responsibility on us to make sure that the names we introduce lend themselves to clarity rather than obscurity.
In this section, we detail how we realize this obligation in terms of explicit guidance that helps us do the best by the Q# development community.

### Operations and Functions ###

The first thing that a name should establish is whether a given symbol represents a function or an operation.
The difference between functions and operations is critical to understanding how a block of code behaves.
To communicate this distinction to programmers, we refer back to that in Q#, quantum computation proceeds through the effects of operations.
That is, an operation *does* something.

By contrast, functions describe the mathematical relationships between data.
The expression `Sin(PI() / 2.0)` *is* `1.0`, and implies nothing about the state of a program or its qubits.

Summarizing, operations do things while functions are things.
This distinction suggests that we name operations as verbs and functions as nouns.

> [!NOTE]
> In many ways, user-defined types can be thought of as functions which construct instances of a UDT.
> From that perspective, UDTs should be named as functions rather than as operations.

Where reasonable, ensure that operation names begin with verbs that clearly indicate the effect taken by the operation.
For example:

- `MeasureInteger`
- `EstimateEnergy`
- `SampleInt`

One case that deserves special mention is when an operation takes another operation as input and calls it.
In such cases, the action taken by the input operation is not clear when the outer operation is defined, such that the right verb is not immediately clear.
We recommend the verb `Apply`, as in `ApplyIf`, `ApplyToEach`, and `ApplyToFirst`.
Other verbs may be useful in this case as well, as in `IterateThroughCartesianPower`.

| Verb | Expected Effect |
| ---- | ------ |
| Apply | An operation provided as input is called |
| Estimate | A classical value is returned, representing an estimate drawn from one or more measurements |
| Measure | A quantum measurement is performed, and its result is returned to the user |
| Prepare | A given register of qubits is initialized into a particular state |
| Sample | A classical value is returned at random from some distribution |

For functions, we suggest avoiding the use of verbs in favor of common nouns (see guidance on proper nouns below) or adjectives:

- `ConstantArray`
- `Head`
- `LookupFunction`

In particular, we suggest using past participles where appropriate to indicate that a function name is strongly connected to an action or side effect elsewhere in a quantum program.
For example,  `ControlledOnInt` uses the part participle form of the verb "control" to indicate that the function acts as an adjective to modify its argument.
This name has the additional benefit of matching the semantics of the built-in `Controlled` functor, as discussed further below.

Similarly, _agent nouns_ can be used to construct function and UDT names from operation names, as in the case of the name `Encoder` for a UDT that is strongly associated with `Encode`. 

### Shorthand ###

The above advice notwithstanding, there are many forms of shorthand that see common and pervasive use in quantum computing.
We suggest using existing and common shorthand where it exists, especially for operations that are intrinsic to the operation of a target machine.
For example, we choose the name `X` instead of `ApplyX`, and `Rz` instead of `RotateAboutZ`.

### Proper Nouns in Names ###



- Avoid using people's names in operation and function names where reasonable.
  Consider using names that describe the implemented functionality;
  e.g. `CCNOT` versus `Toffoli` or `CSWAP` versus `Fredkin `.
  In sample code, consider using names that are familiar to the community reading each particular example, even if that would otherwise run counter to these suggestions.
  **NB:** names should still appear in documentation comments.



- If an operation or function is not intended for direct use, but rather should be used by a matching callable which acts by partial application, consider using a name ending with `Impl` for the callable that is partially applied.
  By contrast, if an operation or function should never be directly called by a user, consider indicating this with a leading `_`.
- Value argument names should be descriptive; avoid one or two letter names where possible.
- Generic argument names should be single capital letters where the role of a type is obvious.
  Otherwise, consider using a short capitalized word prefaced by `T` (e.g.: `TOutput`).
- Denote types in argument and variable names where it is ambiguous, but omit where it is clear from context.
  Type names should be suffixes (`targetQubit`) where reasonable.
- Denote scalar types by their literal names (`flagQubit`), and array types by a plural (`measResults`).
  For arrays of qubits in particular, consider denoting such types by `Register` where the name refers to a sequence of qubits that are closely related in some way.
- If several operations or functions are related by the functor variants supported by their arguments, denote this by suffixes `A`, `C` or `CA` to their names.
- Where reasonable, arrays should have names that are pluralized (e.g.: `things`).
- Variables used as indices into arrays should begin with `idx` and should be singular (e.g.: `things[idxThing]`).
  In particular, strongly avoid using single-letter variable names as indices; consider using `idx` at a minimum.
- Variables used to hold lengths of arrays should begin with `n` and should be pluralized (e.g.: `nThings`).

## Argument Conventions ##

The argument ordering conventions here largely derive from thinking of partial application as a generalization of currying 𝑓(𝑥, 𝑦) ≡ 𝑓(𝑥)(𝑦).
Thus, partially applying the first arguments should result in a callable that is useful in its own right whenever that is reasonable.
Following this principle, consider using the following order of arguments:

- Classical non-callable arguments such as angles, vectors of powers, etc.
- Callable arguments (functions and arguments).
  If both functions and operations are taken as arguments, consider placing operations after functions.
- Collections acted upon by callable arguments in a similar way to `Map`, `Iter`, `Enumerate`, and `Fold`.
- Qubit arguments used as controls.
- Qubit arguments used as targets.

Thus, an operation `Op` which takes an angle, passes it to `Rz` modified by an array of different scaling factors, and then controls the resulting operation would be called in the following fashion:

```qsharp
operation Op(
          angle : Double,
          callable : (Qubit => () : Controlled),
          scaleFactors : Double[],
          controlQubit : Qubit,
          targetQubits : Qubit[]) : ()
```

If an operation or function acts similarly to a keyword functor or a prelude callable, strongly consider following the convention set by the prelude, even if it would otherwise contravene a rule here.
For instance, a function which applies the `Controlled` functor should take an operation and return an operation that has an array of control qubits as its first argument and all remaining arguments as a tuple:

```qsharp
operation ControlledLike<'T>(op : ('T => () : Controlled)) : ((Qubit[], ('T)) => () : Controlled)
```

## Whitespace and Delimiter Conventions ##

- Use four spaces instead of tabs for portability.
  For instance, in VS Code:
  ```json
    "editor.insertSpaces": true,
    "editor.tabSize": 4
  ```

## Documentation Conventions ##

- Each function, operation, and user-defined type should be immediately preceded by a documentation comment containing a summary, remarks, links to papers and external documentation, descriptions of parameters and return types as appropriate.

- When documenting a pair of callables including an `Impl` or a private method, document the public-facing callable more completely, and use a `See Also` tag from the private-facing callable.

- Document operations and functions related by the functor variants by duplicating content as appropriate and by using the `See Also` tag to denote related callables.

## Other Conventions ##

- Line wrap at 79 characters where reasonable.
  **NB:** for files such as Markdown-formatted prose that can safely wrap, consider using the one line per sentence rule instead, as this can help reduce insignificant changes during diffing.

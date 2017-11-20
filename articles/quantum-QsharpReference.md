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

<H1>The Q# Programming Language</H1>

<!-- TOC -->

- [Introduction](#introduction)
    - [Execution Model](#execution-model)
- [The Type Model](#the-type-model)
    - [Primitive Types](#primitive-types)
    - [Array Types](#array-types)
    - [Tuple Types](#tuple-types)
    - [Singleton Tuple Equivalence](#singleton-tuple-equivalence)
    - [User-Defined Types](#user-defined-types)
        - [Type Compatibility](#type-compatibility)
    - [Operation and Function Types](#operation-and-function-types)
        - [Type-Parameterized Functions and Operations](#type-parameterized-functions-and-operations)
        - [Type Compatibility](#type-compatibility-1)
        - [Functors](#functors)
            - [Adjoint](#adjoint)
            - [Controlled](#controlled)
- [Expressions](#expressions)
    - [Grouping](#grouping)
    - [Symbols](#symbols)
    - [Numeric Expressions](#numeric-expressions)
    - [Qubit Expressions](#qubit-expressions)
    - [Pauli Expressions](#pauli-expressions)
    - [Result Expressions](#result-expressions)
    - [Range Expressions](#range-expressions)
    - [Callable Expressions](#callable-expressions)
    - [Callable Invocation Expressions](#callable-invocation-expressions)
        - [Partial Application](#partial-application)
        - [Recursion](#recursion)
    - [Tuple Expressions](#tuple-expressions)
    - [User-Defined Type Expressions](#user-defined-type-expressions)
    - [Array Expressions](#array-expressions)
        - [Array Creation](#array-creation)
        - [Array Slices](#array-slices)
    - [Array Element Expressions](#array-element-expressions)
    - [Boolean Expressions](#boolean-expressions)
    - [Operator Precedence](#operator-precedence)
    - [String Interpolations](#string-interpolations)
- [Statements and Other Constructs](#statements-and-other-constructs)
    - [Comments](#comments)
        - [Documentation Comments](#documentation-comments)
    - [Namespaces](#namespaces)
    - [Formatting](#formatting)
    - [Statement Blocks](#statement-blocks)
    - [Symbol Binding and Assignment](#symbol-binding-and-assignment)
        - [Immutable Symbols](#immutable-symbols)
        - [Mutable Symbols](#mutable-symbols)
        - [Updating Mutable Symbols](#updating-mutable-symbols)
        - [Binding Scopes](#binding-scopes)
    - [Control Flow](#control-flow)
        - [For Loop](#for-loop)
        - [Repeat Until Success Loop](#repeat-until-success-loop)
        - [Conditional Statement](#conditional-statement)
        - [Return](#return)
        - [Fail](#fail)
    - [Qubit Management](#qubit-management)
        - [Clean Qubits](#clean-qubits)
        - [Dirty Qubits](#dirty-qubits)
    - [Expression Evaluation Statements](#expression-evaluation-statements)
- [File Structure](#file-structure)
    - [User Defined Type Declarations](#user-defined-type-declarations)
    - [Operation Definitions](#operation-definitions)
        - [Body](#body)
        - [Adjoint](#adjoint-1)
        - [Controlled](#controlled-1)
        - [Controlled Adjoint](#controlled-adjoint)
        - [Example Operation Definitions](#example-operation-definitions)
    - [Function Definitions](#function-definitions)
- [Using The Compiler](#using-the-compiler)
    - [Compiler Command Line Interface](#compiler-command-line-interface)
- [The Standard Library](#the-standard-library)
    - [Functions](#functions)
    - [Clifford and Related Operations](#clifford-and-related-operations)
    - [Rotations](#rotations)
    - [Measurements](#measurements)
    - [Debugging](#debugging)
- [Appendices](#appendices)
    - [Type Specifier Syntax](#type-specifier-syntax)
    - [Anticipated Future Features](#anticipated-future-features)

<!-- /TOC -->

# Introduction

A natural model for quantum computation is to treat the quantum computer 
as a coprocessor, similar to that used for GPUs, FPGAs, and other adjunct 
processors.
The primary control logic runs classical code on a classical "host" computer.
When appropriate and necessary, the host program can invoke a sub-program 
that runs on the adjunct processor.
When the sub-program completes, the host program gets access to the 
sub-program's results.

In this model, there are three levels of computation:

 - Classical computation that reads input data, sets up the quantum 
    computation, triggers the quantum computation, processes the results 
    of the computation, and presents the results to the user.
 - Quantum computation that happens directly in the quantum device and 
    implements a quantum algorithm.
 - Classical computation that is required by the quantum algorithm during 
    its execution.

There is no intrinsic requirement that these three levels all be written 
in the same language.
Indeed, quantum computation has somewhat different control structures and 
resource management needs than classical computation, so using a custom 
programming language allows common patterns in quantum algorithms to be 
expressed more naturally.

Keeping classical computations separate means that the quantum programming 
language may be very constrained.
These constraints may allow better optimization or faster execution 
of the quantum algorithm.

Q# (Q-sharp) is a domain-specific programming language used for 
expressing quantum algorithms.
It is to be used for writing sub-programs that execute on an adjunct 
quantum processor, under the control of a classical host program and computer.

Q# provides a small set of primitive types, along with two ways 
(arrays and tuples) for creating new, structured types. 
It supports a basic procedural model for writing programs, 
with loops and if/then statements. 
The top-level constructs in Q# are user defined types, operations, 
and functions.

## Execution Model

The basic model for Q# execution includes a classical driver application,
the Q# code itself, and either a quantum simulator or
classical logic that controls the quantum processor
and the quantum processor itself.
In this release we are only supporting a (classical) quantum simulator.

The classical driver sets up the connection to the simulator by
instantiating an object of the appropriate "quantum machine" type.
It then invokes a method on the quantum machine object that executes the 
top-level Q# operation, with the requested parameters.

The Q# compiler translates the Q# code into C#; this C# code is used
by the quantum machine object to execute the algorithm expressed in the
Q# code.
The standard library operations are implemented by the
quantum machine object by classically updating a representation of the
simulated quantum state.
When the simulated computation is done, the invocation method asynchronously
returns the results to the classical driver.

Note that the same classical driver should work for both execution and 
simulation modes, except that the type of quantum machine that is
instantiated changes.
Similarly, the same Q# code should work for both execution and simulation, 
although there are additional compilation and optimization steps required
for execution.

# The Type Model

This section lays out the Q# type model and describes the syntax for 
specifying and working with types.

## Primitive Types

Q# provides several primitive types, out of which all other types 
are constructed:
- The `Int` type represents a 64- bit signed (two's complement) integer. 
- The `Double` type represents a double-precision floating-point number. 
- The `Bool` type represents a Boolean value, either `true` or `false`.
- The `Qubit` type represents a quantum bit or qubit. 
  `Qubit`s are opaque to the user; the only operation possible with them,
   other than passing them to another operation, is to test for identity 
   (equality).
   Ultimately, actions on `Qubit's are implemented by calling operations
   in the Q# standard library.
- The `Pauli` type represents an element of the single-qubit Pauli group. 
   This type is used to denote the base operation for rotations and 
   to specify the basis of a measurement. 
   This type is a discriminated union with four possible values: 
   `PauliI`, `PauliX`, `PauliY`, and `PauliZ`.
- The `Result` type represents the result of a measurement.
   This type is a discriminated union with two possible values: 
   `One` and `Zero`. 
   `Zero` indicates that the +1 eigenvalue was measured; 
   `One` indicates the -1 eigenvalue.
- The `Range` type represents a sequence of integers. 

Note that this implies that `true`, `false`, `PauliI`, `PauliX`, 
`PauliY`, `PauliZ`, `One`, and `Zero` are all reserved symbols in Q#.

## Array Types

Given any valid Q# type `'T`, there is a type that represents an 
array of values of type `'T`. 
This array type is represented as `'T[]`; 
for example, `Qubit[]` or `Int[][]`.

In the second example, note that this represents a potentially 
jagged array of arrays, and not a rectangular two-dimensional array. 
Q# does not include support for rectangular multi-dimensional arrays.

Array types in Q# are considered to be different types if the element types
are different.
An array of a user-defined type is not a sub-type of an array of the
base type of the user-defined type.

## Tuple Types

Given any valid Q# types `'T1`, `'T2`, `'T3`, etc., there is a type that 
represents a tuple of values of types `'T1`, `'T2`, `'T3`, etc., 
respectively. 
This tuple type is represented as `('T1, 'T2, 'T3, …)`. 
Any number of types may be tupled together.
The empty tuple, `()`, is equivalent to `unit` in F#. 

It is possible to create arrays of tuples, tuples of arrays, 
tuples of sub-tuples, etc.

Tuple instances are immutable.
Q# does not provide a mechanism to change the contents of a tuple 
once created.

## Singleton Tuple Equivalence

It is possible to create a singleton (single-element) tuple, `('T1)`, 
such as `(5)` or `([1;2;3])`.
However, Q# treats a singleton tuple as completely equivalent 
to a value of the enclosed type.
That is, there is no difference between `5` and `(5)`, or between 
`5` and `(((5)))`, or between `(5, (6))` and `(5, 6)`.

This equivalence applies for all purposes, including assignment and expressions.
It is just as valid to write `(5)+3` as to write `5+3`, 
and both expressions will evaluate to `8`.

We refer to this property as _singleton tuple equivalence_.

## User-Defined Types

A Q# file may define a new named type based on a standard type. 
Any legal type may be used as the base for a user-defined type.

User-defined types may be used anywhere any other type may be used. 
In particular, it is possible to define an array of a user-defined type 
and to include a user-defined type as an element of a tuple type.

It is not possible to create recursive type structures.
That is, the type that defines a user-defined type may not be a tuple type
that includes an element of the user-defined type.
More generally, user-defined types may not have cyclic dependencies
on each other, so the following set of type definitions would be illegal:
```
newtype TypeA = (Int, TypeB);
newtype TypeB = (Double, TypeC);
newtype TypeC = (TypeA, Range);
```

The mutability of instances of user-defined types is the same as the
mutability of instances of the base type of the user-defined type.
Specifically, instances of user-defined types based on tuples are
immutable; instances of user-defined types based on arrays are
potentially mutable.

### Type Compatibility

Effectively, a user-defined type is a subtype of the base type. 
Thus, a value of a user-defined type may be used anywhere a value 
of the base type is expected. 
This is applied recursively.

For example, suppose type `IntPair` is a user-defined type with base type 
`(Int, Int)`, and type `IntPair2` is a user-defined type with base type 
`IntPair`.
A value of type `IntPair2` may be used anywhere a value of type `IntPair2`, 
`IntPair`, or `(Int, Int)` is expected.
A value of type `IntPair` may be used anywhere a value of type `IntPair` or
`(Int, Int)` is expected.

Different user-defined types based on the same base type are treated as
distinct and unrelated types. 
In the previous example, if `IntPair3` is also a user-defined type with
base type `(Int, Int)`, then `IntPair` and `IntPair3` are unrelated and
a value of one may not be used where a value of the other is expected.

## Operation and Function Types

A Q# _operation_ is a quantum subroutine.
That is, it is a callable routine that contains quantum operations.

A Q# _function_ is a classical subroutine used within 
a quantum algorithm.
It may contain classical code but no quantum operations.
Functions may not be passed qubits or operations as arguments, 
nor may they allocate or borrow qubits.

Together, operations and functions are known as _callables_.

All Q# callables are considered to take a single value as input 
and return a single value as output. 
Both the input and output values may be tuples.
Callables that have no result return the empty tuple, `()`;
callables that have no input take the empty tuple as input.

The basic signature for any callable is written as 
`('Tinput => 'Tresult)` or `('Tinput -> 'Tresult)`, 
where both `'Tinput` and `'Tresult` are type specifiers. 
The first form, with `=>`, is used for operations; 
the second form, with `->`, for functions.
For example, `((Qubit, Pauli) => Result)` represents the 
signature for a possible single-qubit measurement operation.

Function types are completely specified by their signature.
For example, a function that computes the sine of an angle 
would have type `(Double -> Double)`.

Operations -- but not functions -- may allow the application of 
one or more functors.
Functors are meta-operations that generate a variant of a base operation; 
see [Functors](#functors), below.

Operation types are specified by the their signature 
and the list of functors they support.
For example, the Pauli `X` operation has type 
`(Qubit => () : Adjoint, Controlled)`.
An operation type that does not support any functors is specified
by its signature alone, with no trailing `:`.

### Type-Parameterized Functions and Operations

Callable signatures may contain type parameters.
Type parameters are indicated by a symbol prefixed by a single quote;
for example, `'A` is a legal type parameter.
Type-parameterized functions and operations are similar to generic
functions in many programming languages, but Q# does not provide
a full generic type/function capability.

A type parameter may appear more than once in a single signature.
For example, a function that applies another function to each element
of an array and returns the collected results would have signature 
`(('A[], 'A->'A) -> 'A[])`.
Similarly, an operation that returns the composition of two operations
might have signature `((('A=>'B), ('B=>'C))=>('A=>'C))`.

When invoking a type-parameterized callable, the first value for an argument 
specified by the type parameter sets the value of the type parameter.
All later arguments that have the same type parameter must be of a
compatible type; that is, they must either be of the same type,
or of a user-defined type whose base type is compatible.

A type parameter may resolve to the `()` unit type.
This is useful particularly for parameterized operation signatures.
For instance, given an operation with the signature
`((('A=>'B), ('B=>'C))=>('A=>'C))`,
it might be useful to pass a first parameter with signature
`(()=>Foo)`, or a second parameter with signature `(Foo=>())`.

Q# does not provide a mechanism for constraining the possible types
that might be substituted for a type parameter.
Thus, type parameters are primarily useful for functions on arrays and 
for composing callables.

### Type Compatibility

An operation with additional functors supported may be used anywhere
an operation with fewer functors but the same signature is expected.
For instance, an operation of type `(Qubit=>():Adjoint)` may be used 
anywhere an operation of type `(Qubit=>())` is expected.

Q# is contravariant with respect to callable return types:
a callable that returns a type `'A` is compatible with a callable with 
the same input type and a result type that `'A` is compatible with.

Q# is covariant with respect to input types:
a callable that takes a type `'A` as input is compatible with a callable 
with the same result type and an input type that is compatible with `'A`.

That is, given the following type definitions:

    newtype IntPair : (Int, Int) 
    newtype IntPairTransform : ((Int, Int) -> (Int, Int))
    newType IntPairTransform2 : ((Int, Int) -> IntPair)   
    newType IntPairTransform3 : (IntPair -> (Int, Int))   

the following are true:
 - A value of type `IntPairTransform` may be invoked with a single argument 
    of type `IntPair`.
 - The result of invoking a function of type `IntPairTransform` may not be 
    used where a value of type `IntPair` is expected.
 - A value of type `IntPairTransform2` may be used when an `IntPairTransform` 
    is expected, but not _vice versa_.
 - A value of type `IntPairTransform` may be used when an `IntPairTransform3`
    is expected, but not _vice versa_.

### Functors

A functor in Q# is a factory that defines a new operation 
from another operation.
Functors have access to the implementation of the base operation when 
defining the implementation of the new operation. 
Thus, functors can perform more complex functions than 
traditional higher-level functions.

A functor is used by applying it to an operation, returning a new operation.
For example, the operation that results from applying the `Adjoint` functor 
to the `Y` operation is written as `(Adjoint Y)`.
The new operation may then be invoked like any other operation.
Thus, `(Adjoint Y)(q1)` applies the adjoint functor to the `Y` operation to
generate a new operation, and applies that new operation to `q1`.

Similarly, `(Controlled X)(controls, target)` 

The two standard functors in Q# are `Adjoint` and `Controlled`.

#### Adjoint

In quantum computing, the adjoint of an operation is the 
complex conjugate transpose of the operation.
For operations that implement a unitary operator, the adjoint is the 
inverse of the operation.
For a simple operation that just invokes a sequence of other
unitary operations on a set of qubits, the adjoint may be computed
by applying the adjoints of the sub-operations on the same qubits,
in the reverse sequence.

Given an operation expression, a new operation expression may be formed 
using the `Adjoint` functor, with the base operation expression 
enclosed in parentheses, `(` and `)`. 
The new operation has the same signature and type as the base operation.
In particular, the new operation also allows `Adjoint`, and will allow
`Controlled` if and only if the base operation did.

For instance, `(Adjoint QFT)` designates the adjoint of the `QFT` operation.

#### Controlled

The controlled version of an operation is a new operation that effectively 
applies the base operation only if all of the control qubits are in a
specified state.
If the control qubits are in superposition, then the base operation is
applied coherently to the appropriate part of the superposition.
Thus, controlled operations are often used to generate entanglement.

In Q#, controlled versions always take an array of control qubits, 
and the specified state is always for all of the control qubits to be
in the computational (`PauliZ`) `One` state.
Controlling based on other states may be achieved by applying the 
appropriate CLifford operations to the control qubits before the 
controlled operation, and then applying the inverses of the Cliffords
after the controlled operation.
For example, applying an `X` operation to a control qubit will control 
on the `Zero` state for that qubit; applying an `H` operation will control
on the `PauliX` `Zero` state rather than the `PauliZ` `Zero` state.

Given an operation expression, a new operation expression 
may be formed using the `Controlled` functor, with the base operation 
expression enclosed in parentheses, `(` and `)`. 
The signature of the new operation is based on the signature of the 
base operation.
The result type is the same, but the input type is a two-tuple with a 
qubit array that holds the control qubit(s) as the first element and
the arguments of the base operation as the second element.
If the base operation took no arguments, `()`, then the input type of
the controlled version is just the array of control qubits.
The new operation allows `Controlled`, and will allow
`Adjoint` if and only if the base operation did.

If the base function took only a single argument, then singleton
tuple equivalence will come into play here.
For instance, `Controlled(X)` is the controlled verson of the
`X` operation.
`X` has type `(Qubit => () : Adjoint, Controlled)`, so `Controlled(X)` 
has type `((Qubit[], (Qubit)) => () : Adjoint, Controlled)`;
because of singleton tuple equivalence, this is the same as
`((Qubit[], Qubit) => () : Adjoint, Controlled)`.

Similarly, `Controlled(Rz)` is the controlled verson of the
`Rz` operation.
`Rz` has type `((Double, Qubit) => () : Adjoint, Controlled)`, 
so `Controlled(Rz)` has type 
`((Qubit[], (Double, Qubit)) => () : Adjoint, Controlled)`.
For example, `((Controlled(Rz))(controls, (0.1, target))` would be 
a valid invocation of `Controlled(Rz)`.

# Expressions

## Grouping

Given any expression, that same expression enclosed in parantheses 
is an expression of the same type.
For instance, `(7)` is an `Int`` expression, 
`([1;2;3])` is an expression of type array of `Int`s,
and `((1,2))` is an expression with type `(Int, Int)`.

The equivalence between simple values and single-element tuples described in 
[Single-Element Tuples](#single-element-tuples) above removes the ambiguity 
between `(6)` as a group and `(6)` as a single-element tuple.

## Symbols

The name of a symbol bound or assigned to a value of type `'T` 
is an expression of type `'T`.
For instance, if the symbol `count` is bound to the integer value `5`, 
then `count` is an integer expression.

## Numeric Expressions

Numeric expressions are expressions of type `Int` or `Double`.
That is, they are either integer or floating-point numbers.

`Int` literals in Q# are identical to integer literals in C#, 
except that no trailing "l" or "L" is required (or allowed).
Hexadecimal integers are supported with a "0x" prefix.

Double literals in Q# are identical to double literals in C#, 
except that no trailing "d" or "D" is required (or allowed).

Given an array expression of any element type, an `Int` expression 
may be formed using the `Length` built-in function, with the array 
expression enclosed in parentheses, `(` and `)`. 
For instance, if `a` is bound to an array, then `Length(a)` is 
an integer expression.
If `b` is an array of arrays of integers, `Int[][]`, then 
`Length(b)` is the number of sub-arrays in `b`, and `Length(b[1])` 
is the number of integers in the second sub-array in `b`.

Given two numeric expressions, the binary operators `+`, `-`, `*`, 
and `/` may be used to form a new numeric expression. 
The type of the new expression will be `Double` if both of the 
constituent expressions are `Double`, or will be an `Int` expression 
if both are integers.

Given two integer expressions, a new integer expression may be formed 
using the `%` (modulus), `^` (power), `&` (bitwise AND), `|` (bitwise OR),
`<<` (arithmetic left shift), or `>>` (arithmetic right shift) operations. 
The second parameter to either shift operation must be greater than or 
equal to zero.
Right-shifting a negative number fills in the top bits with 1s.

Integer division and integer moduls follow the same behavior for
negative numbers as C#.
That is, `a % b` will always have the same sign as `a`, 
and `b * (a / b) + a % b` will always equal `a`.
For example:

 `A` | `B` | `A / B` | `A % B`
---------|----------|---------|---------
 5 | 2 | 2 | 1
 5 | -2 | -2 | 1
 -5 | 2 | -2 | -1
 -5 | -2 | 2 | -1

Given any numeric expression, a new expression may be formed using the 
`-` unary operator. 
The new expression will be the same type as the constituent expression.

Given any integer expression, a new integer expression may be formed 
using the `~` (bitwise complement) unary operator.

## Qubit Expressions

The only qubit expressions are symbols that are bound to qubit values 
or array elements of qubit arrays.
There are no qubit literals.

## Pauli Expressions

The four `Pauli` values, `PauliI`, `PauliX`, `PauliY`, and `PauliZ`, 
are all valid `Pauli` expressions.

Other than that, the only `Pauli` expressions are symbols that are 
bound to `Pauli` values or array elements of `Pauli` arrays.

## Result Expressions

The two `Result` values, `One` and `Zero`, are valid `Result` expressions.

Other than that, the only `Result` expressions are symbols that are 
bound to `Result` values or array elements of `Result` arrays.
In particular, note that `One` is not the same as the integer `1`, 
and there is no direct conversion between them.
The same is true for `Zero` and `0`.

## Range Expressions

Given any three `Int` expressions `start`, `step`, and `stop`, 
`start .. step .. stop` is a range expression whose first element is `start`, 
second element is `start+step`, third element is `start+step+step`, etc., 
until `stop` is passed.
A range may be empty if, for instance, `step` is positive and `stop < start`. 
The last element of the range will be `stop` if the difference between `start` 
and `stop` is an integral multiple of `step`; that is, 
the range is inclusive at both ends.

Given any two `Int` expressions `start` and `stop`, `start .. stop` is a 
range expression that is equal to `start .. 1 .. stop`. 
Note that the implied `step` is +1 even if `stop` is less than `start`; 
in such a case, the range is empty.

Some example ranges are:
- `1..3` is the range 1, 2, 3.
- `2..2..5` is the range 2, 4.
- `2..2..6` is the range 2, 4, 6.
- `6..-2..2` is the range 6, 4, 2.
- `2..1` is the empty range.
- `2..6..7` is the range 2.
- `2..2..1` is the empty range.
- `1..-1..2` is the empty range.

## Callable Expressions

A callable literal is the name of an operation or function defined in the 
compilation scope.
For instance, `X` is an operation literal that refers to the 
standard library `X` operation, and `Random` is a function literal that 
refers to the standard library `Random` function.

If an operation supports the `Adjoint` functor, then `Adjoint(op)` 
is an operation expression.
Similarly, if the operation supports the `Controlled` functor, then 
`Controlled(op)` is an operation expression.
The types of these expressions are specified above in [Functors](#functors).

## Callable Invocation Expressions

Given a callable (operation or function) expression and a tuple expression 
of the input type of the callable's signature, an invocation expression 
may be formed by appending the tuple expression to the callable expression.
The type of the invocation expression is the output type of the 
callable's signature.

For example, if `Op` is an operation with signature 
`((Int, Qubit) => Double)`, `Op(3, qubit1)` is an expression of type `Double`.
Similarly, if `Sin` is a function with signature `(Double -> Double`),
`Sin(0.1)` is an expression of type `Double`.

Invoking the result of a callable-valued expression requires an extra pair
of parentheses around the callable expression.
Thus, to invoke the adjoint of `Op` from the previous paragraph, the
correct syntax is:
```
(Adjoint(Op))(3, qubit1)
```

### Partial Application

Given a callable expression, a new callable may be created by providing a
subset of the arguments to the callable.
This is called _partial application_.

In Q#, a partially applied callable is expressed by writing a normal
invocation expression, but using an underscore, `_`, for the unspecified 
arguments. 
The resulting callable has the same result type as the base callable,
and the same variants for operations.
The input type of the partial application is simply the original type
with the specified arguments removed.

For example, if `Op` has type `((Int, Qubit, Double)=>():Adjoint)`:
 - `Op(5,_,_)` has type `((Qubit, Double)=>():Adjoint)`.
 - `Op(_,_,1.0)` has type `((Int, Qubit)=>():Adjoint)`.
 - `Op(_,q1,1.0)` has type `(Int=>():Adjoint)`. 
    Note that we have applied singleton tuple equivalence here.

### Recursion

Q# callables are allowed to be directly or indirectly recursive.
That is, an operation or function may call itself, or it may call 
another callable that directly or indirectly calls the callable operation.

There are two important comments about the use of recursion, however:
 - The use of recursion in operations is likely to interfere with certain
   optimizations. 
   This may have a substantial impact on the execution time of the algorithm. 
   The compiler should generate a warning if optimizations are prevented.
 - When executing on an actual quantum device, stack space may be limited, 
   and so deep recursion may lead to a runtime error.
   In particular, the Q# compiler and runtime do not identify and optimize 
   tail recursion. 

## Tuple Expressions

A tuple literal is a sequence of element expressions of the appropriate type, 
separated by commas, enclosed by `(` and `)`. 
For instance, `(1, One)` is an `(Int, Result)` expression.

Other than literals, the only tuple expressions are symbols that are bound to 
tuple values, array elements of tuple arrays, and callable invocations that
return tuples.

## User-Defined Type Expressions

A literal of a user-defined type consists of the type name followed by a 
tuple literal of the type’s base tuple type.
For instance, if `IntPair` is a user-defined type based on `(Int, Int)`, 
then `IntPair(2,3)` would be a valid literal of that type.

Other than literals, the only expressions of a user-defined type are symbols 
that are bound to values of that type, array elements of arrays of that type, 
and callable invocations that return that type.

## Array Expressions

An array literal is a sequence of one or more element expressions, 
separated by semi-colons, enclosed by `[` and `]`. 
All of the elements must have the same type.
If the element type is an operation type, all of the operation elements 
must have the same signature and allowed functors;
if the element type is a function type, then all of the function elements 
must have the same signature.

Empty array literals, `[]`, are not allowed.

Given two arrays of the same type, the binary `+` operator may be used to form a 
new array that is the concatenation of the two arrays.
For instance, `[1;2;3] + [4;5;6]` is `[1;2;3;4;5;6]`.

### Array Creation

Given a type and an `Int` expression, the `new` operator may be used 
to allocate a new array of the given size.
For instance, `new Int[i+1]` would allocate a new `Int` array with 
`i+1` elements.

The elements of a new array are initialized to a type-dependent default value.
In most cases this is some variation of zero.

For qubits and callables, which are references to entities, there is no
reasonable default value. 
Thus, for these types, the default is an invalid
reference that cannot be used without causing a runtime error.
This is similar to a null reference in languages such as C# or Java.
Arrays containing qubits or callables must be filled in using 
[`set`](#updating-mutable-symbols) statements 
before their elements may be safely used. Array elements can only be set if the 
array is declared as being mutable, e.g. `mutable array = new Int[5]`. 
Arrays passed as arguments are immutable. 

The default values for each type are:

Type | Default 
---------|----------
 `Int` | `0` 
 `Double` | `0.0`
 `Bool` | `false`
 `String` | `""`
 `Qubit` | _invalid qubit_
 `Pauli` | `PauliI`
 `Result` | `Zero`
 `Range` | The empty range, `1..1..0`
 `Callable` | _invalid callable_
 `Array['T]` | `'T[0]`

Tuple types are initialized element-by-element.

Array creation is primarily of use initializing mutable arrays, 
on the right-hand side of a [`mutable`](#mutable-symbols) statement.

### Array Slices

Given an array expression and a `Range` expression, a new expression 
may be formed using the `[` and `]` array slice operator. 
The new expression will be the same type as the array and will contain 
the array items indexed by the elements of the `Range`, 
in the order defined by the `Range`. 
For instance, if `a` is bound to an array of `Double`s, 
then `a[3..-1..0]` is a `Double[]` expression that contains the first four 
elements of `a` but in the reverse order as they appear in `a`.

If the `Range` is empty, then the resulting array slice will be zero length.

If the array expression is not a simple identifier, it must be enclosed
it parentheses in order to slice.
For instance, if `a` and `b` are both arrays of `Int`s, a slice from the
concatenation would be expressed as:
```
(a+b)[1..2..7]
```

All arrays in Q# are zero-based.
That is, the first element of an array `a` is always `a[0]`.

## Array Element Expressions

Given an array expression and an `Int` expression, a new expression 
may be formed using the `[` and `]` array element operator. 
The new expression will be the same type as the element type of the array. 
For instance, if `a` is bound to an array of `Double`s, 
then `a[4]` is a `Double` expression.

If the array expression is not a simple identifier, it must be enclosed
it parentheses in order to select an element.
For instance, if `a` and `b` are both arrays of `Int`s, an element from the
concatenation would be expressed as:
```
(a+b)[13]
```

All arrays in Q# are zero-based.
That is, the first element of an array `a` is always `a[0]`.

## Boolean Expressions

The two `Bool` literal values are `true` and `false`.

Given any two expressions of the same non-array type, the `==` and `!=` 
binary operators may be used to construct a new `Bool` expression. 
The expression will be true if the two expressions are (resp. are not) equal. 

Equality comparison for `Qubit` values is identity equality; 
that is, whether the two expressions identify the same qubit.
The state of the two qubits are not compared, accessed, measured, or modified
by this comparison.

Equality comparison for tuples and user-defined types is element-by-element.
It is not legal to compare a value of a user-defined type to a value of
its base type.
It is not legal to compare arrays for equality or inequality.

Equality comparison for `Double` values may be misleading 
due to rounding effects.
For instance, 49.0 * (1.0/49.0) != 1.0.

Given any two numeric expressions, the binary operators 
`>`, `<`, `>=`, and `<=` may be used to construct a new Boolean expression 
that is true if the first expression is respectively greater than, less than, 
greater than or equal to, or less than or equal to the second expression.

Given any two Boolean expressions, the `&&` and `||` binary operators 
may be used to construct a new Boolean expression that is true if both of 
(resp. either or both of) the two expressions are true.

Given any Boolean expression, the `!` unary operator may be used to construct 
a new Boolean expression that is true if the constituent expression is false.

## Operator Precedence

All binary operators are right-associative, except for `^`.

Brackets, `[` and `]`, for array slicing and indexing,
bind before any operator.
Parentheses for operation and function invocation also bind before any
operator but after array indexing.

Operators in order of precedence, from highest to lowest:

Operator | Arity | Description | Operand Types
---------|----------|---------|---------------
 `-`, `~` | Unary | Numeric negative, bitwise complement | `Int` or `Double`, only `Int` for `~`
 `^` | Binary | Integer power | `Int`
 `/`, `*`, `%` | Binary | Division, multiplication, integer modulus | `Int` or `Double`, only `Int` for `%`
 `+`, `-` | Binary | Addition, subtraction | `Int` or `Double`
 `<<`, `>>` | Binary | Left shift, right shift | `Int`
 `!` | Unary | Logical negation (NOT) | Boolean
 `<`, `<=`, `>`, `>=` | Binary | Less-than, less-than-or-equal, greater-than, greater-than-or-equal comparisons | `Int` or `Double`
 `==`, `!=` | Binary | equal, not-equal comparisons | any
 `&` | Binary | Bitwise AND | `Int`
 `|` | Binary | Bitwise OR | `Int`
 `&&` | Binary | Logical AND | `Boolean`
 `||` | Binary | Logical OR | `Boolean`

## String Interpolations

Q# allows strings to be used in the `fail` statement and the `Log` 
standard function.
There are no operators on strings, so they are not otherwise very useful.

The Q# syntax for string interpolations is a subset of the C# 7.0 syntax;
Q# does not support verbatim (multi-line) interpolated strings.
See [*Interpolated Strings*](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interpolated-strings)
for the C# syntax.

# Statements and Other Constructs

## Comments

Comments begin with two forward slashes, `//`, 
and continue until the end of line. 
Comments are treated as whitespace for parsing purposes.


A comment may appear anywhere in a Q# source file, 
including where statements are not valid.

### Documentation Comments


Comments that begin with three forward slashes, `///`, 
are treated specially by the compiler when they appear immediately before 
an operation, function, or type definition.
In that case, their contents are taken as documentation for the defined
callable or user-defined type, as for other .NET languages.

Within `///` comments, text to appear as a part of API documentation is formatted as
[Markdown](https://daringfireball.net/projects/markdown/syntax), 
with different parts of the documentation being indicated by specially named headers.
As an extension to Markdown, cross references to operations, functions and user-defined types
in Q♭ can be included using the `@"<ref target>"`, where `<ref target>` is replaced by the
fully qualified name of the code object being referenced.
Optionally, a documentation engine may also support additional Markdown extensions.

For example:

```Q#
/// # Summary
/// Given an operation and a target for that operation,
/// applies the given operation twice.
///
/// # Input
/// ## op
/// The operation to be applied.
/// ## target
/// The target to which the operation is to be applied.
///
/// # Type Parameters
/// ## 'T
/// The type expected by the given operation as its input.
///
/// # Example
/// ```Q#
///     // Should be equivalent to the identity.
///     ApplyTwice(H, qubit);
/// ```
///
/// # See Also
/// - @"Microsoft.Quantum.Primitive.H": An example of a related operation.
operation ApplyTwice<'T>(op : ('T => ()), target : 'T) {
    Body {
        op(target);
        op(target);
    }
}
```

The following names are recognized as documentation comment headers.
- **Summary**: A short summary of the behavior of a function or operation, or of the purpose of a type.
- **Input**: A description of the input tuple for an operation or function.
  May contain additional Markdown subsections indicating each individual element of the input tuple.
- **Output**: A description of the tuple returned by an operation or function.
- **Type Parameters**: An empty section which contains one additional subsection for each generic type parameter.
- **Example**: A short example of the operation, function or type in use.
- **Remarks**: Miscellaneous prose describing some aspect of the operation, function, or type.
- **See Also**: A list of links and
  [cross-references](https://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html?tabs=tabid-1%2Ctabid-a#cross-reference)
  related to the item being documented.
- **References**: A list of references and citations for the item being documented.

## Namespaces

Every Q# operation, function, and user-defined type is
defined within a namespace.
Q# namespaces are treated the same as namespaces in any other
.NET language, and follow the same rules for naming and for
forming qualified names.

Every Q# file must include at least one `namespace` directive.
This consists of the `namespace` keyword, followed by the namespace
name, an opening `{`, the construct definitions, and a closing `}`.
All user-defined type, function, and operations must appear inside of a
namespace block; only comments may appear outside of a namespace block.

Within a namespace block, the `open` directive may be used to allow
abbreviated reference to constructs from another namespace.
This consists of the `open` keyword, followed by the namespace to be
opened and a terminating semicolon.
`open` directives must appear before any `function`, `operation`, or
`newtype` directives in the namespace block.
The `open` directive applies to the entire namespace block.

A reference to a construct defined in another namespace that is not
opened in the current namespace must be by its fully-qualified name.
For example, an operation named `Op` in the `X.Y` namespace must be
referenced by its fully-qualified name `X.Y.Op`, unless the `X.Y`
namespace has been opened earlier in the current block.

Generally it is preferable to include a namespace with an `open` directive.
Using a fully-qualified name is required if two namespace define constructs
with the same name, and the current source uses constructs from both.

## Formatting

Most Q# statements and directives end with a terminating semicolon, `;`.
Statements and directives such as `for` and `operation` that end with 
a statement block do not require a terminating semicolon.
Each statement description notes whether the terminating semicolon
is required.

Statements may be broken out across multiple lines. 
There must be a line-end between statements, 
so it is not possible to have multiple statements on a single line.
Directives and declarations, such as operation declarations, 
may also span multiple lines.

## Statement Blocks

Q# statements are grouped into statement blocks. 
A statement block starts with an opening `{` and ends with a 
closing `}`.

A statement block that is lexically enclosed within another block 
is considered to be a sub-block of the containing block; 
containing and sub-blocks are also called outer and inner blocks. 

## Symbol Binding and Assignment

Q# distinguishes between mutable and immutable symbols.
In general, the use of immutable symbols is encouraged because it 
allows the compiler to perform more optimizations.

For arrays, mutability or immutability applies both to the array as a whole 
and to array elements.
That is, the elements of an immutable array may not be changed.

The contents of a tuple instance or of a user-defined type based on a tuple 
may not be changed regardless of the mutability of the symbol bound to the 
instance.
If a mutable symbol is bound to a tuple, the symbol may be bound 
to a new tuple, but the existing tuple may not be modified in place.

The arguments to an operation or a function are treated as immutable.
This means that Q# does not support "out" variables.
Also, the elements of an array passed to an operation or function may not be changed.

### Immutable Symbols

Immutable symbols are bound using the `let` statement. 
This is roughly equivalent to variable declaration and initialization in languages 
such as C#, except that Q# symbols, once bound, may not be changed; 
`let` bindings are immutable.

A simple binding statement consists of the keyword `let`, followed by 
an identifier, an equals sign `=`, an expression to bind the identifer to,
and a terminating semicolon. 
The type of the identifier is defined to be the same as the type of the expression
it is bound to.

For example, the statement
```
let i = 5;
```
binds the symbol `i` as an `Int` with the value `5`.

If the right-hand side of the binding is a tuple or a user-defined type, 
then an extended syntax may be used to deconstruct the tuple:
```
let (i, f) = (5, 0.1);
```
This statement will bind `5` to `i` and `0.1` to `f`.

Deconstructing binds may also be used for more complex tuples, such as:
```
let (a, (b, c)) = (1, (2, 3))
let (x, y) = (1, (2, 3))
```
In these examples, `a` and `x` both get bound to `1`,
`b` gets bound to `2`, `c` to `3`, and `y` to `(2, 3)`.

Tuple deconstruction can also be used when the right-hand side of the `=` 
is a tuple-valued expression:
```
let (r1, r2) = MeasureTwice(q1, PauliX, q2, PauliY);
```

### Mutable Symbols

Mutable symbols are defined and initialized using the `mutable` statement.
This statement defines a new symbol binding and specifies that the bound value
may be changed later in the code.

A mutable binding statement consists of the keyword `mutable`, followed by 
an identifier, an equals sign `=`, an expression to bind the identifer to,
and a terminating semicolon. 
The type of the identifier is defined to be the same as the type of the expression
it is bound to.

For example, the statement

    mutable counter = 0;

defines the symbol `counter` as a mutable `Int` with initial value `0`.

The `mutable` statement does not support tuple deconstruction.

If a mutable symbol is bound to an immutable array, a copy of the array
is created and bound to the symbol.
Modifying the elements of the mutable array will not change the contents
of the original immutable array.

### Updating Mutable Symbols

The value bound to a mutable symbol may be changed by 
binding the symbol to a new value using the `set` statement.

A mutable rebinding statement consists of the keyword `set`, followed by 
an identifier, an equals sign `=`, an expression to rebind the identifer to,
and a terminating semicolon. 
The new value must be compatible with the original type, 
and will be promoted to the original type.

For example, the statement

    set counter = counter + 1;

increments the `counter` symbol from the `mutable` example.

The `set` statement is also used to set the value of an item in a mutable array:

    set result[1] = One;

sets the second element of the `result` array to `One`.
Note that the `result` array must have been defined in a `mutable` statement
for this to be valid.

### Binding Scopes

In general, symbol bindings go out of scope and become inoperative 
at the end of the statement block they occur in. 
There are two exceptions to this rule: 
 - The binding of the loop variable of a `for` loop is in scope for 
    the body of the for loop, but not after the end of the loop. 
 - All three portions of a `repeat`/`until` loop (the body, the test, 
    and the fixup) are treated as a single scope, so symbols that are 
    bound in the body are available in the test and in the fixup. 
For both types of loops, each pass through the loop executes in its own scope, 
so bindings from an earlier pass are not available in a later pass.

Symbol bindings from outer blocks are inherited by inner blocks. 
A symbol may only be bound once per block; it is illegal to bind a symbol 
that is already bound.
Thus, the following sequences would be legal:

```
if a == b {
    ...
    let n = 5;
    ...             // n is 5
}
let n = 8;
...                 // n is 8
```

and

```
if a == b {
    ...
    let n = 5;
    ...             // n is 5
} else {
    ...
    let n = 8;
    ...             // n is 8
}
```

and

```
let n = 8;
if a == b {}
    ...             // n is 8
    let n = 5;
    ...             // n is 5
}
...                 // n is 8
```

But this would be illegal:

```
let n = 5;
...                 // n is 5
let n = 8;          // Error!!
...
```

## Control Flow

### For Loop

The `for` statement supports iteration through a simple integer range. 
The statement consists of the keyword `for`, followed by an identifier, 
the keyword `in`, a `Range` expression, and a statement block. 
The statement block (the body of the loop) is executed repeatedly, 
with the identifier (the loop variable) bound to each value in the 
range expression. 
Note that if the range expression evaluates to an empty range, 
the body will not be executed at all.

The range is fully evaluated before entering the loop, 
and will not change while the loop is executing.

For example,

```
for index in 0 .. n-2 {
    set results[index] = Measure([PauliX], [qubits[index]]);
}
```

The loop variable is bound at each entrance to the loop body, and unbound 
at the end of the body. 
In particular, the loop variable is not bound after the for loop is completed.

### Repeat Until Success Loop

The `repeat` statement supports the quantum “repeat until success” pattern. 
It consists of the keyword `repeat`, followed by a statement block 
(the _loop_ body), the keyword `until`, a Boolean expression, 
the keyword `fixup`, and another statement block (the _fixup_). 
The loop body, condition, and fixup are all considered to be a single scope, 
so symbols bound in the body are available in the condition and fixup.

Note that the fixup block is required, even if there is no fixup to be done. 
In this case, the fixup should be a single expression statement, `()`.

The loop body is executed, and then the condition is evaluated. 
If the condition is true, then the statement is completed; 
otherwise, the fixup is executed, and the statement is re-executed starting 
with the loop body. 
Note that completing the execution of the fixup ends the scope for the 
statement, so that symbol bindings made during the body or fixup are not 
available in subsequent repetitions.

For example, the following code is a probabilistic circuit that implements 
an important rotation gate **V3** = (**I**+2*i***Z**)/√5 using the 
Hadamard and T gates. 
The loop terminates in 8/5 repetitions on average.
See [*Repeat-Until-Success: Non-deterministic decomposition of single-qubit unitaries*](https://arxiv.org/abs/1311.1074) 
(Paetznick and Svore, 2014) for details.

```
using ancilla = Qubit[1] {
    repeat {
        let anc = ancilla[0]
        H(anc)
        T(anc)
        CNOT(target,anc)
        H(anc)
        (Adjoint T)(anc)
        H(anc)
        T(anc)
        H(anc)
        CNOT(target,anc)
        T(anc)
        Z(target)
        H(anc)
        let result = M([anc],[PauliZ])
    } until result == Zero
    fixup {
        ()
    }
}
```

### Conditional Statement

The if statement supports conditional execution. 
It consists of the keyword `if`, followed by a Boolean expression 
and a statement block (the _then_ block).
This may be followed by any number of else-if clauses, each of which consists
of the keyword `elif`, followed by a Boolean expression 
and a statement block (the _else-if_ block).
Finally, the statement may optionally finish with an else clause, which 
consists of the keyword `else` followed by another statement block 
(the _else_ block). 
The condition is evaluated, and if it is true, the then block is executed.
If the condition is false, then the first else-if condition is evaluated;
if it is true, that else-if block is executed.
Otherwise, the second else-if block is tested, and then the third, and so on 
until either a clause with a true condition is encountered or there are no 
more else-if clauses.
If the original if condition and all else-if clauses evaluate to false,
the else block is executed if one was provided.

Note that whichever block is executed is executed in its own scope.
Bindings made inside of a then, else-if, or else block are not visible 
after the end of the if statement.

For example,

```
if result == One {
    X(target)
} else {
    Z(target)
}
```
or
```
if i == 1 {
    X(target)
} elif i == 2 {
    Y(target)
} else {
    Z(target)
}
```

### Return

The return statement ends execution of an operation or function 
and returns a value to the caller. 
It consists of the keyword `return`, followed by an expression of the 
appropriate type, and a terminating semicolon. 

A callable that returns an empty tuple, `()`, does not require a 
return statement.
If an early exit is desired, `return ()` may be used in this case.
Callables that return any other type require a final return statement.

There is no maximum number of return statements within an operation. 
The compiler may emit a warning if statements follow a return statement 
within a block.

For example,
```
return 1;
```
or

```
return ();
```

or

```
return (results, qubits);
```

### Fail

The fail statement ends execution of an operation and returns an error value 
to the caller. 
It consists of the keyword `fail`, followed by a string interpolation
and a terminating semicolon.
The interpolated string is returned to the classical driver as the error message.

There is no restriction on the number of fail statements within an operation. 
The compiler may emit a warning if statements follow a fail statement within 
a block.

For example,

    fail $"Impossible state reached";

or

    fail $"Syndrome {syn} is incorrect";

## Qubit Management

Note that none of these statements are allowed within the body of a function.

### Clean Qubits

The using statement is used to acquire new qubits for use 
during a statement block. 
The qubits are guaranteed to be initialized to the 
computational `Zero` state.
The qubits should be in the computational `Zero` state at the 
end of the statement block; simulators are encouraged to enforce this.

The statement consists of the keyword `using`, followed by 
the symbol that should be bound to the resulting array of qubits, '=',
the type to acquire (`Qubit`), `[`, an `Int` expression, `]`, and
the statement block within which the qubits will be available. 

For example,

    using qubits = Qubit[bits * 2 + 3] {
        ...
    }

### Dirty Qubits

The borrowing statement is used to allocate qubits for temporary use
during a statement block. 
The borrower commits to leaving the qubits in the same state they were in 
when they were borrowed. 
Such qubits are often known as “dirty ancilla”. 
See [Factoring using 2n+2 qubits with Toffoli based modular multiplication](https://arxiv.org/abs/1611.07995)
(Haner, Roetteler, and Svore 2017) for an example of dirty ancilla use.

When borrowing qubits, the system will first try to fill the request
from qubits that are in use but that are not accessed during the body
of the `borrowing` statement.
If there aren't enough such qubits, then it will allocate new qubits
to complete the request.

The statement consists of the keyword `borrowing`, followed by 
the symbol that should be bound to the resulting array of qubits, '=',
the type to acquire (`Qubit`), `[`, an `Int` expression, `]`, and
the statement block within which the qubits will be available. 

For example,

    borrowing qubits = Qubit[bits * 2 + 3] {
        ...
    }

## Expression Evaluation Statements

Any valid Q# expression of type `()` may be evaluated as a statement.
This is primarily of use when calling operations on qubits that return `()`
because the purpose of the statement is to modify the implicit quantum state.
Expression evaluation statements require a terminating semicolon.

For example,

    X(q);

or

    CNOT(control, target);

or

    (Adjoint T)(q1);

# File Structure

A Q# file consists of some number of type declarations 
followed by some number of callable (operation or function) definitions. 
A file may contain only type definitions or callable definitions, 
but must contain at least one definition of some variety.

## User Defined Type Declarations

Q# provides a way for users to declare new user-defined types, 
as described in [The Type Model](#the-type-model) above. 
User-defined types are distinct even if the underlying  types are identical, 
and there is no automatic conversion between two user-defined types 
even if the underlying types are identical.

A user-defined type declaration consists of the keyword `newtype`, followed by 
the name of the user-defined type, an `=`, a valid type specification, and
a terminating semicolon. 

For example:

    newtype PairOfInts = (int, int);

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
A body definition consists of the keyword `Body`, followed by a statement block.

### Adjoint

The adjoint of an operation specifies how the complex conjugate transpose
of the operation is implemented. 
It is legal to specify an operation with no adjoint; 
for instance, measurement operations have no adjoint because 
they are not invertible. 
An operation supports the `Adjoint` functor if and only if its declaration
contains an adjoint declaration.

An adjoint definition consists of the keyword `Adjoint`, followed by one of:

 - The keyword `self` indicating that the operation is its own adjoint.
 - The keyword `auto` indicating that the Q# compiler should generate an adjoint 
    for the operation, based on the operation’s body.
    The generated version will apply the adjoint of each quantum operation
    in the body, in reverse order to the order in the body.
    Non-quantum code may be reorganized to ensure values are computed
    before they are used.
 - The keyword `none` indicating that the operation has no adjoint.
 - A statement block that implements the operation’s adjoint. 

Each of the keywords should be followed by a terminating semicolon.

Thus, an operation definition contain

    Adjoint self;

or

    Adjoint auto;

or 

    Adjoint none;

or 

    Adjoint {
        // Code for the adjoint goes here.
    }

If none of these appear, then no adjoint is defined; this is the same
as if `Adjoint none` is specified.

An operation whose body contains repeat-until-success loops or measurements 
or that calls another operation that does not support the `Adjoint` functor
may not specify the `auto` keyword.

If an operation has no body but should have an adjoint defined, 
it should specify `Adjoint auto` or `Adjoint self`.

### Controlled

The controlled version of an operation specifies how a quantum-controlled 
version of the operation is implemented. 
A more complete description is provided above in the [Controlled](#controlled)
section, above.

It is legal to specify an operation with no controlled version; 
for instance, measurement operations have no controlled version because 
they are not controllable. 
An operation supports the `Controlled` functor if and only if its definition
contains a controlled definition.

A controlled definition consists of the keyword `Controlled`, followed by
one of:

 - The keyword `auto` indicating that the Q# compiler should generate a 
    controlled version of the operation based on the operation’s body. 
    The generated version will apply quantum control to every *quantum* 
    operation.
    Non-quantum code will be unmodified.
 - The keyword `none` indicating that the operation does not have a 
    controlled version.
 - A `(`, a symbol that will be the name of the variable holding the 
    array of control qubits, `)`, and a statement block that implements the 
    controlled version of the operation. 

Each of the keywords should be followed by a terminating semicolon.

Thus, an operation definition contain

    Controlled self;

or 

    Controlled none;

or 

    Controlled(controls) {
        // Code for the controlled version goes here.
        // "controls" is bound to the array of control qubits.
    }

An operation whose body contains repeat-until-success loops or measurements 
or that calls another operation that does not support the `Controlled` functor
may not specify the `auto` keyword.

If an operation has no body but should have a controlled version defined, 
it should specify `Controlled auto`.

### Controlled Adjoint

The controlled adjoint version of an operation specifies how a 
quantum-controlled version of the adjoint of the operation is implemented. 
It is legal to specify an operation with no controlled adjoint version; 
for instance, measurement operations have no controlled adjoint version 
because they are neither controllable nor invertible. 

An operation should define a controlled adjoint variant if and only if 
it defines both a controlled variant and an adjoint variant.

A controlled adjoint definition consists of the keyword `Adjoint`, 
then the keyword `Controlled`, followed either by the keyword `auto` 
indicating that the Q# compiler should generate a controlled adjoint version 
of the operation based on the operation’s body, or by `(`, a symbol that will 
be the name of the variable holding the array of control qubits, `)`, 
and a statement block that implements the controlled adjoint version of the 
operation. 
Each of the keywords should be followed by a terminating semicolon.

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
defined, it should specify `Adjoint Controlled auto`.

### Example Operation Definitions

An operation definition might be as simple as the following, 
which defines the primitive Pauli X operation:

```
operation X (q : Qubit) : () {
    Adjoint self;
    Controlled auto;
    Adjoint Controlled auto;
}
```

The following defines the teleport operation. 
Note that we’ve spelled this out in gory detail, rather than creating 
sub-operations as one normally would.

```
namespace Microsoft.Quantum.Samples {
    // Entangle two qubits.
    // Assumes that both qubits are in the |0> state.
    operation EPR (Q#1 : Qubit, Q#2 : Qubit) : () {
        H(Q#2);
        CNOT(Q#2, Q#1);
    }

    // Teleport the quantum state of the source to the target.
    // Assumes that the target is in the |0> state.
    operation Teleport (source : Qubit, target : Qubit) : () {
        Body {
            // Get a temporary for the Bell pair
            using ancilla = Qubit[1] {
                let temp = ancilla[0];

                // Create a Bell pair between the temporary and the target
                EPR(target, temp);

                // Do the teleportation
                CNOT(source, temp);
                H(source);
                if M(source) == One {
                    X(target);
                }
                if M(temp) == One {
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

For example,

    function DotProduct(a : Double[], b : Double[]) : Double {
        if Length(a) != Length(b) {
            fail "Arrays are not compatible";
        }
        mutable accum = 0.0;
        for i in 0..Length(a)-1 {
            set accum = accum + a[i] * b[i];
        }
        return accum;
    }

# Using The Compiler

Q# code is stored as text in files. 
The top-level constructs allowed in a file are user defined types, 
function and operation declarations, and comments.

The Q# compiler will process one or more text files containing any number of 
these constructs and create a single .NET library exposing the functionality 
defined in these text files. 
This library can be referenced within a .NET project and native .NET code in C# or F# 
can then access the functionality represented by the Q# code within the native .NET 
code. 

The compiler functionality is packaged in two different forms:

- As a command line tool which will take some arguments and 
    generate an assembly which can be linked against.
- As a single file generator packaged within a Visual Studio Extension (VSIX) 
    which can act as a custom tool for Q# files in a project, 
    and generate code-behind C# for each file.
    This provides debugging capability within Visual Studio at the Q# language level.

## Compiler Command Line Interface

The command line interface should take a list of Q# input files and the desired name of the output DLL.

    Q#c.exe f1.Q# f2.Q# f3.Q# --output phase.dll
    
# The Standard Library

Q# includes a large number of operations in its standard library. 
While the semantics of a particular operation is specified here, 
different Q# execution environments may provide different implementations 
of these operations, and may leave some of them unimplemented.

## Functions

These functions are all in the `Microsoft.Quantum.Primitives` namespace.

Name | Signature | Description
-----|-----------|------------
`Random` | `Double[] -> Int` | The random operation takes an array of doubles as input, and returns a randomly-selected index into the array as an `Int`. The probability of selecting a specific index is proportional to the value of the array element at that index. Array elements that are equal to zero are ignored and their indices are never returned. If any array element is less than zero, or if no array element is greater than zero, then the operation fails.
`Floor` | `Double -> Int` | Returns the greatest integer less than or equal to the argument. This is the .NET `System.Math.Floor` function.
`Float` | `Int -> Double` | Returns a floating-point number equal to the input integer.
`Start` | `Range -> Int` | Returns the starting value for a range.
`Step` | `Range -> Int` | Returns the step value for a range.
`Stop` | `Range -> Int` | Returns the stopping value for a range.


## Clifford and Related Operations

These operations are all in the `Microsoft.Quantum.Primitives` namespace.

All of these operations allow both the Controlled and Adjoint functors.

Name | Signature | Unitary | Description
-----|-----------|---------|------------
`X` | `Qubit => ()` | [ 0 1<br>&nbsp; 1 0 ] | The Pauli X gate.
`Y` | `Qubit => ()` | [&nbsp; 0 -_i_<br>&nbsp;&nbsp;&nbsp; _i_&nbsp; 0 ] | The Pauli Y gate.
`Z` | `Qubit => ()` | [ 1&nbsp; 0<br>&nbsp; 0 -1 ] | The Pauli Z gate.
`H` | `Qubit => ()` | 1/√2 [ 1&nbsp; 1 <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 1 -1 ] | The Hadamard gate.
`HY` | `Qubit => ()` | 1/√2 [ 1&nbsp; 1 <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _i_&nbsp; -_i_ ] | The "Hadamard Y" or Y-basis gate.
`S` | `Qubit => ()` | [ 1 0 <br>&nbsp;&nbsp; 0 _i_ ] | The S (phase) gate.
`T` | `Qubit => ()` | [ 1&nbsp;&nbsp;&nbsp; 0 <br>&nbsp; 0 exp(_i_ π/4) ] | The T (π/8) gate.
`CNOT` | `(Qubit, Qubit) => ()` | `Controlled(X)([q1], q2)` | The Controlled NOT gate.
`CCNOT` | `(Qubit, Qubit, Qubit) => ()` | `Controlled(X)([q1;q2], q3)` | The Toffoli, or doubly-controlled NOT, gate. 
`SWAP` | `(Qubit, Qubit) => ()` | [ 1 0 0 0<br>&nbsp; 0 0 1 0<br>&nbsp; 0 1 0 0<br>&nbsp; 0 0 0 1 ]  | Swaps the state of two qubits. This is equivalent to <br>`CNOT(q1, q2)`<br>`CNOT(q2, q1)`<br>`CNOT(q1, q2)`
`MultiX` | `Qubit[] => ()` | | Performs a tensor product of Pauli X gates to the array of qubits. MultiX(qs) is equivalent to <br>`for (index in 0..length(qs)-1)`<br>&nbsp;&nbsp;&nbsp; `X(qs[index])`


## Rotations

These operations are all in the `Microsoft.Quantum.Primitives` namespace.

All of these operations allow both the Controlled and Adjoint functors.

Name | Signature | Unitary | Description
-----|-----------|---------|------------
`R` | `(Pauli, Double, Qubit) => ()` | exp(-_i_ ϕσ/2)  | Rotation by the given amount around the given Pauli axis. σ is the Pauli matrix corresponding to the first argument and ϕ is the second argument.
`RFrac` | `(Pauli, Int, Int, Qubit) => ()` | exp(_i_ πkσ/2^n) | Rotation by the given fraction of π around the given Pauli axis. σ is a Pauli matrix corresponding to the first argument, k is the second argument, and n is the third argument. Note that the sign convention is different than for `R`.
`Rx` | `(Double, Qubit) => ()` | R(PauliX,a,q) | Rotation by the given amount around the Pauli X axis.
`Ry` | `(Double, Qubit) => ()` | R(PauliY,a,q) | Rotation by the given amount around the Pauli Y axis.
`Rz` | `(Double, Qubit) => ()` | R(PauliZ,a,q) | Rotation by the given amount around the Pauli Z axis.
`R1` | `(Double, Qubit) => ()` | | Rotation by the given amount around the \|1> state. This is equivalent to <br>`R(PauliZ,phi,q)`<br>`R(PauliI,-phi,q)`
`R1Frac` | `(Int, Int, Qubit) => ()` | | Rotation by the given fraction around the \|1> state. This is equivalent to <br>`RFrac(PauliZ,-k,n+1,q)`<br>`RFrac(PauliI,k,n+1,q)`
`Exp` | `(Pauli[], Double, Qubit[]) => ()` |  | Performs a rotation based on a tensor product of Pauli matrices to the array of qubits. 
`ExpFrac` | `(Pauli[], Int, Int, Qubit[]) => ()` | | Performs a fractional rotation based on a tensor product of Pauli matrices to the array of qubits. 

## Measurements

These operations are all in the `Microsoft.Quantum.Primitives` namespace.

None of these operations allow any functors.

Name | Signature | Description
-----|-----------|------------
`Measure` | `(Pauli[], Qubit[]) => Result` | Joint measurement of one or more qubits in the specified Pauli bases. If the basis array and qubit array are different lengths, then the operation fails. <br/>When measuring, the +1 eigenvalue of the specified (possibly multi-qubit) Pauli operator corresponds to a `Zero` measurement, and the -1 eigenvalue to a `One` measurement.
`M` | `Qubit => Result` | Measurement of a single qubit in the computational (Pauli Z) basis. `M(q)` is equivalent to `Measure([PauliZ], [q])`.
`MultiM` | `Qubit[] => Result[]` | Individual measurement of an array of qubits in the computational (Pauli Z) basis, in array index order. In some cases this can be optimized. It is equivalent to <br>`mutable rs = New Result[length(qs)]`<br>`for (index in 0..length(qs)-1)`<br>&nbsp;&nbsp;&nbsp; `set rs[index] = M(qs[index])`<br>`return rs`

## Debugging

These operations are all in the `Microsoft.Quantum.Primitives` namespace.

None of these functions or operations allow any functors.

Name | Signature | Description
-----|-----------|------------
`Assert` | `(Pauli[], Qubit[], Result, String) => ()` | Asserts that measuring the given qubits in the given Pauli basis will always have the given result. If the assertion fails, the execution ends by calling `fail` with the given message. By default, this operation is not implemented; simulators that can support it should provide an implementation that performs runtime checking.
`AssertProb` | `(Pauli[], Qubit[], Result, Double, String, Double) => ()` | Asserts that measuring the given qubits in the given Pauli basis will have the given result with the given probability, within some tolerance. Tolerance is additive (e.g. `abs(expected-actual) < tol`). If the assertion fails, the execution ends by calling `fail` with the given message. By default, this operation is not implemented; simulators should provide an implementation that performs runtime checking.
`AssertEqual` | `('A, 'A, String) -> ()` | Asserts that the two values are the same, and fails if not. The first `'A` value is the expected value, the second is the actual value.
`Log` | `(String) -> ()` | Logs a string. By default, this writes the string to the console.

# Appendices

## Type Specifier Syntax

The rough EBNF syntax for type specifiers follows. 
In the syntax, the “symbol” production specifies the set of valid Q# symbols. 

```ebnf
type              = simple-type | 
                    array-type | 
                    tuple-type | 
                    operation-type | 
                    function-type | 
                    user-defined-type
simple-type       = “Int” | “Double” | "Bool" | "String" | 
                    “Qubit” | "Pauli" | “Result” | "Range"
variant           = "Adjoint" | "Controlled"
array-type        = type “[]”
tuple-type        = “(“ [ type { “,” type } ] “)”
operation-type    = “(“ tuple-type “=>” tuple-type [ : variant { "," variant } ] “)”
function-type     = “(“ tuple-type “->” tuple-type “)”
user-defined-type = symbol
```
<!---
## Anticipated Future Features

Some or all of the following features may be added to Q# in the future:

 - Ability to link Q# functions to .NET static methods.
    The expected use for external functions is for core mathematical 
    functions such as `sine` and `exp`.
    External functions used during actual quantum execution must be 
    small enough and simple enough to fit on the classical control hardware.
    In addition, because the quantum state decays randomly over time,
    external functions called during quantum execution must run 
    extremely quickly.
 - Constraints for type parameters on operations. 
    This allows, for instance, the ability to restrict a type parameter
    to only being instantiated with types that are numeric.
 - Type constructors for user-defined types that may be used from within a 
    "using" or "borrowing" acquisition.
    This would make it simpler to allocate user-defined types that contain 
    qubits, rather than getting the qubits first and then building a value of
    the type from the qubit array.
 - Annotation of operation calls with precision requirements.
    This provides a way to control the distribution of the allowed error 
    tolerance for an algorithm.
 - Standard library operations for qubit allocation and release.
    While this gives up the safety of the `using` statement, there may be
    specific algorithms that are very awkward to express without these.
 - Standard library functions for finding the number of qubits available
    for using or borrowing.
 - Keyword and optional arguments.
 - .NET-style attributes for declarations, parameters, and statements.
 - Compiler directives (#if/#endif, #pragma). 
 - A language construct to allow the programmer to designate that a set
    of statement blocks may be safely executed in parallel or in an 
    arbitrary order.
    In some cases this may allow optimizations that are difficult to 
    detect programmatically.
--->
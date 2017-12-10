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
uid: microsoft.quantum.qsharp-ref.expressions
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

# Expressions

## Grouping

Given any expression, that same expression enclosed in parentheses
is an expression of the same type.
For instance, `(7)` is an `Int` expression,
`([1;2;3])` is an expression of type array of `Int`s,
and `((1,2))` is an expression with type `(Int, Int)`.

The equivalence between simple values and single-element tuples described in
<xref:microsoft.quantum.qsharp-ref.type-model#tuple-types> above removes the ambiguity
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
using the `%` (modulus), `^` (power), `&&&` (bitwise AND), `|||` (bitwise OR),
`^^^` (bitwise XOR), `<<<` (arithmetic left shift), or `>>>` (arithmetic right shift) operations. 
The second parameter to either shift operation must be greater than or 
equal to zero.
The behavior for shifting negative numbers is undefined. 

Integer division and integer modulus follow the same behavior for
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
using the `~~~` (bitwise complement) unary operator.

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
standard library `X` operation, and `Message` is a function literal that 
refers to the standard library `Message` function.

If an operation supports the `Adjoint` functor, then `(Adjoint op)` 
is an operation expression.
Similarly, if the operation supports the `Controlled` functor, then 
`(Controlled op)` is an operation expression.
The types of these expressions are specified above in [Functors](xref:microsoft.quantum.qsharp-ref.type-model#functors).

## Callable Invocation Expressions

Given a callable (operation or function) expression and a tuple expression 
of the input type of the callable's signature, an invocation expression 
may be formed by appending the tuple expression to the callable expression.
The type of the invocation expression is the output type of the 
callable's signature.

For example, if `Op` is an operation with signature 
`((Int, Qubit) => Double)`, `Op(3, qubit1)` is an expression of type `Double`.
Similarly, if `Sin` is a function with signature `(Double -> Double)`,
`Sin(0.1)` is an expression of type `Double`.

Invoking the result of a callable-valued expression requires an extra pair
of parentheses around the callable expression.
Thus, to invoke the adjoint of `Op` from the previous paragraph, the
correct syntax is:

```qsharp
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

If a mutable variable is passed as a specified argument when creating
a partial application, the current value of the variable is used.
Changing the value of the variable afterward will not impact the partial
application.

For example, if `Op` has type `((Int, ((Qubit,Qubit), Double)) => ():Adjoint)`:
 - `Op(5,(_,_))` has type `(((Qubit,Qubit), Double) => ():Adjoint)`, and so has `Op(5,_)`.
 - `Op(_,(_,1.0))` has type `((Int, (Qubit,Qubit)) => ():Adjoint)`.
 - `Op(_,((q1,q2),_))` has type `((Int,Double) => ():Adjoint)`. 
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
All elements must be compatible with the same type.
If the common element type is an operation or function type, all of the elements must have the same signature and - in case of operations - the same supported functors.

Empty array literals, `[]`, are not allowed. Instead using `new ★[0]`, where `★` is as placeholder for a suitable type, allows to create the desired array of length zero.

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
[`set`](xref:microsoft.quantum.qsharp-ref.type-model.statements#updating-mutable-symbols) statements 
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
on the right-hand side of a [`mutable`]microsoft.quantum.qsharp-ref.type-model.statements#mutable-symbols) statement.

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

```qsharp
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

```qsharp
(a+b)[13]
```

All arrays in Q# are zero-based.
That is, the first element of an array `a` is always `a[0]`.

## Boolean Expressions

The two `Bool` literal values are `true` and `false`.

Given any two expressions compatible with the same primitive type, the `==` and `!=` binary operators may be used to construct a `Bool` expression. 
The expression will be true if the two expressions are (resp. are not) equal. 
For both magnitude and equality comparision, values of user-defined types are cast to their base type before comparison. 

Equality comparison for `Qubit` values is identity equality; 
that is, whether the two expressions identify the same qubit.
The state of the two qubits are not compared, accessed, measured, or modified
by this comparison.

Equality comparison for `Double` values may be misleading 
due to rounding effects.
For instance, `49.0 * (1.0/49.0) != 1.0`.

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
 `-`, `~~~`,`!` | Unary | Numeric negative, bitwise complement, logical negation (NOT) | `Int` or `Double` for `-`, `Int` for `~~~`, `Bool` for `!`
 `^` | Binary | Integer power | `Int`
 `/`, `*`, `%` | Binary | Division, multiplication, integer modulus | `Int` or `Double` for `/` and `*`, `Int` for `%`
 `+`, `-` | Binary | Addition or string and array concatenation, subtraction | `Int` or `Double`, additionally `String` or any array type for `+`
 `<<<`, `>>>` | Binary | Left shift, right shift | `Int`
 `<`, `<=`, `>`, `>=` | Binary | Less-than, less-than-or-equal, greater-than, greater-than-or-equal comparisons | `Int` or `Double`
 `==`, `!=` | Binary | equal, not-equal comparisons | any primitive type
 `&&&` | Binary | Bitwise AND | `Int`
 `^^^` | Binary | Bitwise XOR | `Int`
 <code>\|\|\|</code> | Binary | Bitwise OR | `Int`
 `&&` | Binary | Logical AND | `Bool`
 <code>\|\|</code> | Binary | Logical OR | `Bool`

## String Interpolations

Q# allows strings to be used in the `fail` statement and the `Log` 
standard function.
The Q# syntax for string interpolations is a subset of the C# 7.0 syntax;
Q# does not support verbatim (multi-line) interpolated strings.
See [*Interpolated Strings*](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interpolated-strings)
for the C# syntax.

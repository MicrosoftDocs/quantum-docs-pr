---
title: Type expressions in Q# | Microsoft Docs 
description: Using and working with type expressions in Q#
author: Gillenhaal Beck
ms.author: a-gibec@microsoft.com 
ms.date: 02/28/2020
ms.topic: article
uid: microsoft.quantum.guide.expressions
---

# Expressions: working with types

`******` GENERAL NOTE: we need more examples alongside the descriptions of operations
`******` Maybe create entirely separate page for working with arrays? 

The name of a symbol bound or assigned to a value of type `'T` is an *expression* of type `'T`.
For instance, if the symbol `count` is bound to the integer value `5`, then `count` is an integer expression.

> [!NOTE]
> Given any expression, that same expression enclosed in parentheses is an expression of the same type.
> For instance, `(7)` is an `Int` expression, `([1,2,3])` is an expression of type `Int[]`, and `((1,2))` is an expression with type `(Int, Int)`.

On the previous page, [Types in Q#](xref:microsoft.quantum.guide.types), we described the various types available in the Q# language. 
Here, we will detail how to create and work with expressions of these types. 


## Numeric Expressions

Numeric expressions are expressions of type `Int`, `BigInt`, or `Double`.
That is, they are either integer or floating-point numbers.

`Int` literals in Q# are identical to integer literals in C#, except that no trailing "l" or "L" is required (or allowed).
Hexadecimal and binary integers are supported with a "0x" and "0b" prefix respectively.

`Double` literals in Q# are identical to double literals in C#, except that no trailing "d" or "D" is required (or allowed).

`BigInt` literals in Q# are identical to big integer strings in .NET, *with* a trailing "l" or "L".
Hexadecimal big integers are supported with a "0x" prefix.
Thus, the following are all valid uses of `BigInt` literals:

```qsharp
let bigZero = 0L;
let bigHex = 0x123456789abcdef123456789abcdefL;
let bigOne = bigZero + 1L;
```

### Creating new numeric expressions

#### Int expressions from array lengths

Given an array expression of any element type, an `Int` expression may be formed using the [`Length`](xref:microsoft.quantum.core.length) built-in function, with the array expression enclosed in parentheses, `(` and `)`.
For instance, if `a` is bound to an array, then `Length(a)` is an integer expression.
If `b` is an array of arrays of integers, `Int[][]`, then `Length(b)` is the number of sub-arrays in `b`, and `Length(b[1])` is the number of integers in the second sub-array in `b`.

#### Unary operators

The operator `-` can also be applied to the left of any numeric expressions, simply corresponding to numeric negation. 
In this case, the new expression's type is the same as that the original---it is simply the previous value multiplied by negative 1.

The `~~~` (bitwise complement) unary operator can be applied to any `Int` or `BigInt` expression, forming a new expression of the same type.

The precedence relationships between these, and all other operations we will discuss, are provided at the bottom of this page. 


#### Binary operators

`******` I think these could be boiled down much more succinctly. Perhaps to a table like at the bottom of the page, but just make it slightly more robust.

##### Standard artithmetic
Given two numeric expressions of the same type, the binary operators `+`, `-`, `*`, and `/` may be used to form a new numeric expression of the same type.

##### Exponentiation

Given two `Int` expressions, the binary operator `^` (power) may be used to form a new `Int` expression.
The same holds for two `Double` expressions forming a new `Double`.
Finally, `^` may be used with a `BigInt` on the *left* and an `Int` on the *right* to form a new `BigInt` expression.
In this case, the second parameter must fit into 32 bits; if not, a runtime error will be raised.

##### Modulus and bitwise logic

Given two `Int` or `BigInt` expressions, a new `Int` or `BigInt` expression may be formed using the operators:
- `%` (modulus),
- `&&&` (bitwise AND)
- `|||` (bitwise OR)
- `^^^` (bitwise XOR)
`******` Clarify with examples HERE. Also, clarify that bitwise stuff is on the binary rep of the integers. 

> [!NOTE]
> For both `Int` and `BigInt` expressions, division and modulus follow the same behavior for negative numbers as C#.
> That is, `a % b` will always have the same sign as `a`, and `b * (a / b) + a % b` will always equal `a`.
> For example:
> 
>  `A` | `B` | `A / B` | `A % B`
> ---------|----------|---------|---------
>  5 | 2 | 2 | 1
>  5 | -2 | -2 | 1
>  -5 | 2 | -2 | -1
>  -5 | -2 | 2 | -1


##### Artithmetic shifts

Given either an `Int` or `BigInt` expression on the *left*, and an `Int` expression on the *right*, the 
- `<<<` (arithmetic left shift) or 
- `>>>` (arithmetic right shift) 
operators may be used to create a new expression with the same type as the left-hand expression.
`******` ADD EXAMPLES

The `Int` on the right side corresponds to the shift amount, and must be greater than or equal to zero (the behavior for negative shift amounts is undefined).
The shift amount for either shift operation must also fit into 32 bits; if not, a runtime error will be raised.
If the number to be shifted is an `Int`, then the shift amount is interpreted `mod 64`; that is, a shift of 1 and a shift of 65 have the same effect.

For both `Int` and `BigInt` values, shifts are arithmetic.
Shifting a negative value either left or right will result in a negative number.
That is, shifting one step to the left or right is exactly the same as multiplying or dividing by 2, respectively.


## Boolean Expressions

The two `Bool` literal values are `true` and `false`.

### Creating new Booleans

#### From other Booleans

Given any Boolean expression, the `not` unary operator may be used to construct a new Boolean expression that is true if the constituent expression is false.

Given any two Boolean expressions, the `and` and `or` binary operators may be used to construct a new Boolean expression that is true if both of (resp. either or both of) the two expressions are true.

#### From numeric expressions

Given any two numeric expressions, the binary operators `>`, `<`, `>=`, and `<=` may be used to construct a new Boolean expression that is true if the first expression is respectively greater than, less than, greater than or equal to, or less than or equal to the second expression.

#### Equality comparison 

Given any two expressions of the same primitive type, the `==` and `!=` binary operators may be used to construct a `Bool` expression.
If two expressions are equal, the `==` operator will yield the Boolean `true`, with `!=` yielding `false`.
The opposite holds if the two expressions are not equal.

> [!NOTE]
> Equality comparison for `Qubit` values simply indicates whether the two expressions identify the same qubit.
> The state of the two qubits are not compared, accessed, measured, or modified by this comparison.

> [!WARNING]
> Equality comparison for `Double` values may be misleading due to rounding effects.
> For instance, `49.0 * (1.0/49.0) != 1.0`.

Lastly, note that the values of user-defined types may not be compared, only their unwrapped values can be compared. 
For example, using the unwrap operator `!` detailed below on this page, 

```qsharp
newtype WrappedInt = Int;     // Yes, this is a contrived example
let x = WrappedInt(1);
let y = WrappedInt(2);
let z = x! == y!;             // This will compile and yield z = false.
let t = x == y;               // This will cause a compiler error.
```

## Conditional Expressions

Given two other expressions of the same type and a Boolean expression, the conditional expression may be formed using the question mark `?` and the vertical bar `|`.
For instance, `a==b ? c | d`.
In this example, the value of the conditional expression will be `c` if `a==b` is true and `d` if it is false.

The two expressions may evaluate to operations that have the same inputs and outputs but support different functors.
In this case, the type of the conditional expression is an operation with those inputs and outputs that supports any functors supported by both expressions.
For example, if `Op1`, `Op2`, and `Op3` all are `Qubit[]=>Unit`, but `Op1` supports `Adjoint`, `Op2` supports `Controlled`, and `Op3` supports both:

- `flag ? Op1 | Op2` is a `(Qubit[] => Unit)` operation.
- `flag ? Op1 | Op3` is a `(Qubit[] => Unit is Adj)` operation.
- `flag ? Op2 | Op3` is a `(Qubit[] => Unit is Ctl)` operation.

If either of the two possible result expressions include a function or operation call, that call will only take place if that result is the one that will be the value of the call.
For instance, in the case `a==b ? C(qs) | D(qs)`, if `a==b` is true then the `C` operation will be invoked, and if it is false then only `D` will be invoked.
This is similar to short-circuiting in other languages.

## String Expressions

Q# allows strings to be used in the `fail` statement of diagnostic operations like [`Assert`](xref:microsoft.quantum.intrinsic.assert) and the [`Message`](xref:microsoft.quantum.intrinsic.message) standard function.

Strings in Q# are either literals or interpolated strings.
String literals are similar to simple string literals in most languages: a sequence of Unicode characters enclosed in double quotes, `"`.
Inside of a string, the back-slash character `\` may be used to 
- escape a double quote character
- insert a new-line as `\n`, 
- insert a carriage return as `\r`, and
- insert a tab as `\t`.
For instance:

```qsharp
"\"Hello world!\", she said.\n"
```

The Q# syntax for string interpolations is a subset of the C# 7.0 syntax; Q# does not support verbatim (multi-line) interpolated strings.
See [*Interpolated Strings*](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/interpolated-strings) for the C# syntax.

Expressions inside of an interpolated string follow Q# syntax, not C# syntax.
Any valid Q# expression may appear in an interpolated string.

## Range Expressions

Given any three `Int` expressions `start`, `step`, and `stop`, `start .. step .. stop` is a range expression whose first element is `start`, second element is `start+step`, third element is `start+step+step`, etc., until `stop` is passed.
Note that `step` can be negative, in which case the range is descending.
A range may be empty if, for instance, `step` is positive and `stop < start`.
The range is inclusive at both ends, so The last element of the range will be `stop` if the difference between `start` and `stop` is an integer multiple of `step`.

Given any two `Int` expressions `start` and `stop`, `start .. stop` is a range expression that is equal to `start .. 1 .. stop`.
Note that the implied `step` is +1 even if `stop` is less than `start`; in such a case, the range is empty.

Some example ranges are:

- `1..3` is the range 1, 2, 3.
- `2..2..5` is the range 2, 4.
- `2..2..6` is the range 2, 4, 6.
- `6..-2..2` is the range 6, 4, 2.
- `2..1` is the empty range.
- `2..6..7` is the range 2.
- `2..2..1` is the empty range.
- `1..-1..2` is the empty range.

## Qubit Expressions

The only `Qubit` expressions are symbols that are bound to `Qubit` values or array elements of `Qubit` arrays.
There are no `Qubit` literals.

## Pauli Expressions

The four `Pauli` values, `PauliI`, `PauliX`, `PauliY`, and `PauliZ`, are all valid `Pauli` expressions.

Other than that, the only `Pauli` expressions are symbols that are bound to `Pauli` values or array elements of `Pauli` arrays.

## Result Expressions

The two `Result` values, `One` and `Zero`, are valid `Result` expressions.

Other than that, the only `Result` expressions are symbols that are bound to `Result` values or array elements of `Result` arrays.
In particular, note that `One` is not the same as the integer `1`, and there is no direct conversion between them.
The same is true for `Zero` and `0`.


## Tuple Expressions

A tuple literal is a sequence of element expressions of the appropriate type, separated by commas, enclosed in `(` and `)`.
For instance, `(1, One)` is an `(Int, Result)` expression.

Other than literals, the only tuple expressions are symbols that are bound to tuple values, array elements of tuple arrays, and callable invocations that return tuples.

## User-Defined Type Expressions

A literal of a user-defined type consists of the type name followed by a tuple literal of the type’s base tuple type.
For instance, if `IntPair` is a user-defined type based on `(Int, Int)`, then `IntPair(2,3)` would be a valid literal of that type.

Other than literals, the only expressions of a user-defined type are symbols that are bound to values of that type, array elements of arrays of that type, and callable invocations that return that type. We discuss the latter in depth on the [next page](xref:microsoft.quantum.guide.callables).

## Unwrap Expressions

In Q#, the unwrap operator is a trailing exclamation mark `!`.
For instance, consider the supposed `IntPair` user-defined type above, with underlying type `(Int, Int)`.
If `s` was a variable with value `IntPair(2,3)`, then `s!` would be `(2,3)`.

The unwrap operator unwraps exactly one layer of wrapping.
Multiple unwrap operators may be used to access a multiply-wrapped value.
For instance:

```qsharp
newtype WrappedInt = Int;
newtype DoublyWrappedInt = WrappedInt;

...
    let x = DoublyWrappedInt(WrappedInt(6));
    let y = x!;       // y is WrappedInt(6)
    let z = x!!;      // z is 6
    let a = x + 5;    // This is an error, a DoublyWrappedInt isn't an Int
    let b = x! + 5;   // Also an error
    let c = x!! + 5;  // This is valid, c will be 11
...
```

### Unwrap Operator Precedence

The `!` operator has higher precedence than all other operators (other than `[]` for array indexing and slicing).
Both `!` and `[]` bind positionally; that is, `a[i]![3]` should be read as `((a[i])!)[3]`: take the `i`'th element of `a`, unwrap it, and then get the 3rd element of the unwrapped value (which must be an array).

[!WARNING] 
> The precedence of the `!` operator has one impact that might not be obvious.
> If a function or operation returns a value that then gets unwrapped, the function or operation call *must* be enclosed in parentheses so that the argument tuple binds to the call rather than to the unwrap.
> For example:
> ```qsharp
> let f = (Foo(arg))!;    // Calls Foo(arg), then unwraps the result
> let g = Foo(arg)!;      // Syntax error
> ```

## Array Expressions

An array literal is a sequence of one or more element expressions, separated by commas, enclosed in `[` and `]`.
All elements must be compatible with the same type.


Given two arrays of the same type, the binary `+` operator may be used to form a new array that is the concatenation of the two arrays.
For instance, `[1,2,3] + [4,5,6]` is `[1,2,3,4,5,6]`.

### Array Creation

Given a type and an `Int` expression, the `new` operator may be used to allocate a new array of the given size.
For instance, `new Int[i+1]` would allocate a new `Int` array with `i+1` elements.

The elements of a new array are initialized to a type-dependent default value.
In most cases this is some variation of zero.

For qubits and callables, which are references to entities, there is no reasonable default value.
Thus, for these types, the default is an invalid reference that cannot be used without causing a runtime error.
This is similar to a null reference in languages such as C# or Java.
Arrays containing qubits or callables must be properly initialized with non-default values before their elements may be safely used. 
Suitable initialization routines can be found in <xref:microsoft.quantum.arrays>.

The default values for each type are:

Type | Default
---------|----------
 `Int` | `0`
 `BigInt` | `0L`
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


### Array Elements

Given an array expression and an `Int` expression, a new expression may be formed using the `[` and `]` array element operator.
The new expression will be the same type as the element type of the array.
For instance, if `a` is bound to an array of `Double`s, then `a[4]` is a `Double` expression.

If the array expression is not a simple identifier, it must be enclosed in parentheses in order to select an element.
For instance, if `a` and `b` are both arrays of `Int`s, an element from the concatenation would be expressed as:

```qsharp
(a+b)[13]
```

All arrays in Q# are zero-based.
That is, the first element of an array `a` is always `a[0]`.


### Array Slices

Given an array expression and a `Range` expression, a new expression may be formed using the `[` and `]` array slice operator.
The new expression will be the same type as the array and will contain the array items indexed by the elements of the `Range`, in the order defined by the `Range`.
For instance, if `a` is bound to an array of `Double`s, then `a[3..-1..0]` is a `Double[]` expression that contains the first four elements of `a` but in the reverse order as they appear in `a`.

If the `Range` is empty, then the resulting array slice will be zero length.

Just as with referencing array elements, if the array expression is not a simple identifier, it must be enclosed it parentheses in order to slice.
If `a` and `b` are both arrays of `Int`s, a slice from the concatenation would be expressed as:

```qsharp
(a+b)[1..2..7]
```

#### Inferred start/end values

Starting with our 0.8 release, we support contextual expressions for range slicing. 
In particular, range start and end values may be omitted in the context of a range slicing expression. 
In that case, the compiler will apply the following rules to infer the intended delimiters for the range. 

For example, if the range start value is omitted,  then the inferred start value 
- is zero if no step is specified or the specified step is positive, and 
- is the length of sliced array minus one if the specified step is negative. 

If the range end value is omitted,  then the inferred end value 
- is the length of sliced array minus one if no step is specified or the specified step is positive, and 
- is zero if the specified step is negative. 

```qsharp
let arr = [1,2,3,4,5,6];
let slice1  = arr[3...];      // slice1 is [4,5,6];
let slice2  = arr[0..2...];   // slice2 is [1,3,5];
let slice3  = arr[...2];      // slice3 is [1,2,3];
let slice4  = arr[...2..3];   // slice4 is [1,3];
let slice5  = arr[...2...];   // slice5 is [1,3,5];
let slice7  = arr[4..-2...];  // slice7 is [5,3,1];
let slice8  = arr[...-1..3];  // slice8 is [6,5,4];
let slice9  = arr[...-1...];  // slice9 is [6,5,4,3,2,1];
let slice10 = arr[...];       // slice10 is [1,2,3,4,5,6];
```

## Copy-and-Update Expressions

New arrays can be created from existing ones via copy-and-update expressions.
A copy-and-update expression is an expression of the form `expression1 w/ expression2 <- expression3`, where `expression1` has to be of type `T[]` for some type `T`. The second `expression2` defines the indices of the element(s) to modify compared to the array in `expression1` and has to be either of type `Int` or of type `Range`. If `expression2` is of type `Int`, `expression3` has to be of type `T`. If `expression2` is of type `Range`, `expression3` has to be of type `T[]`.

A copy-and-update expression `arr w/ idx <- value` constructs a new array with all elements set to the corresponding element in `arr`, except for the element(s) at `idx`, which are set to the one(s) in `value`. 
For example, if `arr` contains an array `[0,1,2,3]`, then 
- `arr w/ 0 <- 10` is the array `[10,1,2,3]`.
- `arr w/ 2 <- 10` is the array `[0,1,10,3]`.
- `arr w/ 0..2..3 <- [10,12]` is the array `[10,1,12,3]`.

Similar expressions exist for named items in user-defined types. 
Consider for example the type 

```qsharp
newtype Complex = (Re : Double, Im : Double);
```
If `c` contains the value of type `Complex(1.,-1.)`, then `c w/ Re <- 0.` is an expression of type `Complex` that evaluates to `Complex(0.,-1.)`.

### Jagged Arrays

A jagged array, sometimes called an "array of arrays", is an array whose elements are arrays.
The elements of a jagged array can be of different sizes.
The following example shows how to declare and initialize a jagged array representing a multiplication table.

```qsharp
let N = 4;
mutable multiplicationTable = new Int[][N];
for (i in 1..N) {

    mutable row = new Int[i];
    for (j in 1..i) {
        set row w/= j-1 <- i * j;
    }
    set multiplicationTable w/= i-1 <- row;
}
```

### Arrays of callables 

Note that more details on callable types can be found on the next page: [Q# callables: functions and operations](xref:microsoft.quantum.guide.callables).

If the common element type is an operation or function type, all of the elements must have the same input and output types.
The element type of the array will support any functors that are supported by all of the elements.
For example, if `Op1`, `Op2`, and `Op3` all are `Qubit[] => Unit`, but `Op1` supports `Adjoint`, `Op2` supports `Controlled`, and `Op3` supports both:

- `[Op1, Op2]` is an array of `(Qubit[] => Unit)` operations.
- `[Op1, Op3]` is an array of `(Qubit[] => Unit is Adj)` operations.
- `[Op2, Op3]` is an array of `(Qubit[] => Unit is Ctl)` operations.

Empty array literals, `[]`, are not allowed.
Instead using `new ★[0]`, where `★` is as placeholder for a suitable type, allows to create the desired array of length zero.



## Operator Precedence

All binary operators are right-associative, except for `^`.

Brackets, `[` and `]`, for array slicing and indexing,
bind before any operator.

The functors `Adjoint` and `Controlled` bind after array indexing
but before all other operators.

Parentheses for operation and function invocation also bind before any
operator but after array indexing and functors.

Operators in order of precedence, from highest to lowest:

Operator | Arity | Description | Operand Types
---------|----------|---------|---------------
 trailing `!` | Unary | Unwrap | Any user-defined type
 `-`, `~~~`, `not` | Unary | Numeric negative, bitwise complement, logical negation | `Int`, `BigInt` or `Double` for `-`, `Int` or `BigInt` for `~~~`, `Bool` for `not`
 `^` | Binary | Integer power | `Int` or `BigInt` for the base, `Int` for the exponent
 `/`, `*`, `%` | Binary | Division, multiplication, integer modulus | `Int`, `BigInt` or `Double` for `/` and `*`, `Int` or `BigInt` for `%`
 `+`, `-` | Binary | Addition or string and array concatenation, subtraction | `Int`, `BigInt` or `Double`, additionally `String` or any array type for `+`
 `<<<`, `>>>` | Binary | Left shift, right shift | `Int` or `BigInt`
 `<`, `<=`, `>`, `>=` | Binary | Less-than, less-than-or-equal, greater-than, greater-than-or-equal comparisons | `Int`, `BigInt` or `Double`
 `==`, `!=` | Binary | equal, not-equal comparisons | any primitive type
 `&&&` | Binary | Bitwise AND | `Int` or `BigInt`
 `^^^` | Binary | Bitwise XOR | `Int` or `BigInt`
 <code>\|\|\|</code> | Binary | Bitwise OR | `Int` or `BigInt`
 `and` | Binary | Logical AND | `Bool`
 `or` | Binary | Logical OR | `Bool`
 `..` | Binary/Ternary | Range operator | `Int`
 `?` `|` | Ternary | Conditional | `Bool` for the left-hand-side
`w/` `<-` | Ternary | Copy-and-update | see [copy-and-update expressions](#copy-and-update-expressions)


## What's next?

On the [next page](xref:microsoft.quantum.guide.callables) we detail two cornerstones of Q#, the callable types: functions and operations.


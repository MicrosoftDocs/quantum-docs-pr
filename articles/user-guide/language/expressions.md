---
title: Expressions in Q#
description: Understand how to specify, reference and combine constants, variables, operators, operations and functions as expressions in Q#.
author: gillenhaalb
ms.author: a-gibec
ms.date: 03/05/2020
ms.topic: article
uid: microsoft.quantum.guide.expressions
no-loc: ['Q#', '$$v']
---

# Expressions in Q#

## Numeric Expressions

Numeric expressions are expressions of type `Int`, `BigInt`, or `Double`.
That is, they are either integer or floating-point numbers.

`Int` literals in Q# are written as a sequence of digits.
Hexadecimal and binary integers are supported and written with a `0x` and `0b` prefix, respectively.

`BigInt` literals in Q# have a trailing `l` or `L` suffix.
Hexadecimal big integers are supported and written with a "0x" prefix.
Thus, the following are all valid uses of `BigInt` literals:

```qsharp
let bigZero = 0L;
let bigHex = 0x123456789abcdef123456789abcdefL;
let bigOne = bigZero + 1L;
```

`Double` literals in Q# are floating-point numbers written using decimal digits.
They can be written with or without a decimal point, `.`, or an exponential part indicated with 'e' or 'E' (after which only a possible negative sign and decimal digits are valid).
The following are valid `Double` literals: `0.0`, `1.2e5`, `1e-5`.

Given an array expression of any element type, you can form an `Int` expression using the [`Length`](xref:microsoft.quantum.core.length) built-in function, with the array expression enclosed in parentheses.
For example, if `a` is bound to an array, then `Length(a)` is
an integer expression.
If `b` is an array of arrays of integers, `Int[][]`, then
`Length(b)` is the number of sub-arrays in `b`, and `Length(b[1])`
is the number of integers in the second sub-array in `b`.

Given two numeric expressions of the same type,
the binary operators `+`, `-`, `*`, and `/` may be used to form
a new numeric expression.
The type of the new expression is the same as the types of the
constituent expressions.

Given two integer expressions, use the binary operator `^` (power)
to form a new integer expression.
Similarly, you can also use `^` with two double expressions to form
a new double expression.
Finally, you can use `^` with a big integer on the left and
an integer on the right to form a new big integer expression.
In this case, the second parameter must fit into 32 bits;
if not, it raises a runtime error.

Given two integer or big integer expressions, form a new integer or
big integer expression using the `%` (modulus),
`&&&` (bitwise AND), `|||` (bitwise OR), or `^^^` (bitwise XOR) operators.

Given either an integer or big integer expression on the left,
and an integer expression on the right, use the `<<<` (arithmetic left shift)
or `>>>` (arithmetic right shift) operators to create
a new expression with the same type as the left-hand expression.

The second parameter (the shift amount) to either shift operation
must be greater than or equal to zero; the behavior for negative
shift amounts is undefined.
The shift amount for either shift operation must also fit into
32 bits; if not, it raises a runtime error.
If the number shifted is an integer, then the shift amount
is interpreted `mod 64`; that is, a shift of 1 and a shift of 65
have the same effect.

For both integer and big integer values, shifts are arithmetic.
Shifting a negative value either left or right results in a negative number.
That is, shifting one step to the left or right is the same as
multiplying or dividing by 2, respectively.

Integer division and integer modulus follow the same behavior for negative numbers as C#. That is, `a % b` always has the same sign as `a`, and `b * (a / b) + a % b` always equals `a`. For example:

|`A` | `B` | `A / B` | `A % B`|
|:---------:|:----------:|:---------:|:---------:|
| 5 | 2 | 2 | 1 |
| 5 | -2 | -2 | 1 |
| -5 | 2 | -2 | -1 |
| -5 | -2 | 2 | -1 |

Big integer division and modulus operations work the same way.

Given any numeric expression, you can form a new expression using the
`-` unary operator.
The new expression is the same type as the constituent expression.

Given any integer or big integer expression, you can form a new expression of the same type using the `~~~` (bitwise complement) unary operator.

## Boolean Expressions

The two `Bool` literal values are `true` and `false`.

Given any two expressions of the same primitive type, the `==`
and `!=` binary operators may be used to construct a `Bool` expression.
The expression is true if the two expressions are equal and false if not.

Values of user-defined types may not be compared, only their unwrapped values can be compared. 
For example, using the "unwrap" operator `!` (explained in detail at [Types in Q#](xref:microsoft.quantum.guide.types#access-anonymous-items-with-the-unwrap-operator)),

```qsharp
newtype WrappedInt = Int;     // Yes, this is a contrived example
let x = WrappedInt(1);
let y = WrappedInt(2);
let z = x! == y!;             // This will compile and yield z = false.
let t = x == y;               // This will cause a compiler error.
```

Equality comparison for `Qubit` values is identity equality;
that is, whether the two expressions identify the same qubit.
The states of the two qubits are not compared, accessed, measured, or modified
by this comparison.

Equality comparison for `Double` values may be misleading
due to rounding effects.
For example, `49.0 * (1.0/49.0) != 1.0`.

Given any two numeric expressions, the binary operators
`>`, `<`, `>=`, and `<=` may be used to construct a new Boolean expression
that is true if the first expression is respectively greater than, less than,
greater than or equal to, or less than or equal to the second expression.

Given any two Boolean expressions, use the `and` binary operator to construct a new Boolean expression that is true if both of the two expressions are true. Likewise, using the `or` operator creates an expression that is true if either of the two expressions is true.

Given any Boolean expression, the `not` unary operator may be used to construct
a new Boolean expression that is true if the constituent expression is false.

## String expressions

Q# allows strings to be used in the `fail` statement (explained in [Control Flow](xref:microsoft.quantum.guide.controlflow#fail-statement)) and in the [`Message`](xref:microsoft.quantum.intrinsic.message) standard function. The specific behavior of the latter depends on the simulator used but typically writes a message to the host console when called during a Q# program.

Strings in Q# are either literals or interpolated strings.

String literals are similar to simple string literals in most languages:
a sequence of Unicode characters enclosed in double-quotes `" "`.
Inside of a string, use the backslash character `\` to escape
a double-quote character (`\"`), or to insert a new-line ( `\n` ), a carriage
return (`\r`), or a tab (`\t`).
For example:

```qsharp
"\"Hello world!\", she said.\n"
```
### Interpolated strings

The Q# syntax for string interpolations is a subset of the C# syntax. Following are the key points as they pertain to Q#:

* To identify a string literal as an interpolated string, prepend it with the `$` symbol. There can be no white space between the `$` and the `"` that starts a string literal.

* The following is a basic example using the [`Message`](xref:microsoft.quantum.intrinsic.message) function to write the result of a measurement to the console, alongside other Q# expressions.

```qsharp
    let num = 8;       // some Q# expression
    let res = M(q);
    Message($"Number: {num}, Result: {res}");
```

* Any valid Q# expression may appear in an interpolated string.

* Expressions inside of an interpolated string follow Q# syntax, not C# syntax. The most notable distinction is that Q# does not support verbatim (multi-line) interpolated strings.

For more details about the C# syntax, see [*Interpolated Strings*](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/interpolated-strings).

## Range Expressions

Given any three `Int` expressions `start`, `step`, and `stop`, the expression `start .. step .. stop` is a range expression whose first element is `start`, second element is `start+step`, third element is `start+step+step`, and so on, until you pass `stop`.
A range may be empty if, for example, `step` is positive and `stop < start`.

The range is inclusive at both ends. That is, if the difference between `start` and `stop` is an integer multiple of `step`, the last element of the range will be `stop`.

Given any two `Int` expressions `start` and `stop`, the expression `start .. stop` is a range expression that is equal to `start .. 1 .. stop`.
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

## Qubit Expressions

The only `Qubit` expressions are symbols that are bound to `Qubit` values
or array elements of `Qubit` arrays.
There are no `Qubit` literals.

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

## Tuple Expressions

A tuple literal is a sequence of element expressions of the appropriate type,
separated by commas, enclosed in parentheses.
For example, `(1, One)` is an `(Int, Result)` expression.

Other than literals, the only tuple expressions are symbols that are bound to
tuple values, array elements of tuple arrays, and callable invocations that
return tuples.

## User-Defined Type Expressions

A literal of a user-defined type consists of the type name followed by a
tuple literal of the type’s base tuple type.
For example, if `IntPair` is a user-defined type based on `(Int, Int)`,
then `IntPair(2, 3)` is a valid literal of that type.

Other than literals, the only expressions of a user-defined type are symbols
that are bound to values of that type, array elements of arrays of that type,
and callable invocations that return that type.

## Unwrap Expressions

In Q#, the unwrap operator is a trailing exclamation mark `!`.
For example, if `IntPair` is a user-defined type with the underlying type `(Int, Int)` and `s` is a variable with value `IntPair(2, 3)`, then `s!` is `(2, 3)`.

For user-defined types defined in terms of other user-defined types, you can repeat the unwrap operator. For example, `s!!` indicates the
doubly-unwrapped value of `s`.
Thus, if `WrappedPair` is a user-defined type with underlying type `IntPair`, and
`t` is a variable with value `WrappedPair(IntPair(1,2))`, then `t!!` is `(1,2)`.

The `!` operator has higher precedence than all other operators other than
`[]` for array indexing and slicing.
`!` and `[]` bind positionally; that is, `a[i]![3]` is read as
`((a[i])!)[3]`: take the `i`th element of `a`, unwrap it, and then
get the 3rd element of the unwrapped value (which must be an array).

The precedence of the `!` operator has one impact that might not be obvious.
If a function or operation returns a value that then gets unwrapped, the
function or operation call must be enclosed in parentheses so that the
argument tuple binds to the call rather than to the unwrap.
For example:

```qsharp
let f = (Foo(arg))!;    // Calls Foo(arg), then unwraps the result
let g = Foo(arg)!;      // Syntax error
```

## Array Expressions

An array literal is a sequence of one or more element expressions, separated by commas, enclosed in square brackets `[]`.
All elements must be compatible with the same type.

Given two arrays of the same type, use the binary `+` operator to form a new array that is the concatenation of the two arrays.
For example, `[1,2,3] + [4,5,6]` = `[1,2,3,4,5,6]`.

### Array Creation

Given a type and an `Int` expression, use the `new` operator to allocate a new array of the given size.
For example, `new Int[i + 1]` allocates a new `Int` array with `i + 1` elements.

Empty array literals, such as `[]`, are not allowed.
Instead, you can create an array of length zero by using `new T[0]`, where `T` is a placeholder for a suitable type.

The elements of a new array initialize to a type-dependent default value.
In most cases, this is some variation of zero.

For qubits and callables, which are references to entities, there is no reasonable default value.
Thus, for these types, the default is an invalid reference that you cannot use without causing a runtime error, similar to a null reference in languages such as C# or Java.
Arrays containing qubits or callables must be initialized with non-default values before you can use their elements safely. 
For suitable initialization routines, see <xref:microsoft.quantum.arrays>.

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

Tuple types initialize element-by-element.


### Array Elements

Given an array expression and an `Int` expression, form a new expression using the array element operator `[]`.
The new expression is the same type as the element type of the array.
For example, if `a` is bound to an array of type `Double`, then `a[4]` is a `Double` expression.

If the array expression is not a simple identifier, you must enclose it in parentheses to select an element.
For example, if `a` and `b` are both arrays of type `Int`, an element from the concatenation is expressed as:

```qsharp
(a + b)[13]
```

All arrays in Q# are zero-based.
That is, the first element of an array `a` is always `a[0]`.


### Array Slices

Given an array expression and a `Range` expression, form a new expression using the array slice operator `[ ]`.
The new expression is the same type as the array and contains the array items indexed by the elements of the `Range`, in the order defined by the `Range`.
For example, if `a` is bound to an array of type `Double`, then `a[3..-1..0]` is a `Double[]` expression that contains the first four elements of `a` but in the reverse order as they appear in `a`.

If the `Range` is empty, then the resulting array slice is zero length.

Just as with referencing array elements, if the array expression is not a simple identifier, you must enclose it in parentheses to slice it.
For example, if `a` and `b` are both arrays of type `Int`, a slice from the concatenation is expressed as:

```qsharp
(a+b)[1..2..7]
```

#### Inferred start/end values

Starting with our [0.8 release](xref:microsoft.quantum.relnotes), we support contextual expressions for range slicing. In particular, you may omit range start and end values in the context of a range slicing expression. In that case, the compiler applies the following rules to infer the intended delimiters for the range:

* If the range *start* value is omitted, then the inferred start value
  * is zero if no step is specified or the specified step is positive.  
  * is the length of the sliced array minus one if the specified step is negative.

* If the range *end* value is omitted, then the inferred end value
  * is the length of the sliced array minus one if no step is specified or the specified step is positive.
  * is zero if the specified step is negative.

Some examples are:

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

### Copy-and-Update Expressions

Since all Q# types are value types (with the qubits taking a somewhat special role), formally a "copy" is created when a value is bound to a symbol or when a symbol is rebound. That is to say, the behavior of Q# is the same as if a copy were created using an assignment operator. 

Of course, in practice, only the relevant pieces are recreated as needed. This affects how you copy arrays because it is not possible to update array items. To modify an existing array requires leveraging a *copy-and-update* mechanism.

You can create a new array from an existing array via *copy-and-update* expressions, which use the operators `w/` and `<-`.
A copy-and-update expression is an expression of the form `expression1 w/ expression2 <- expression3`, where

* `expression1` must be type `T[]` for some type `T`.
* `expression2` defines which indices in the array specified in `expression1` to modify. `expression2` must be either type `Int` or type `Range`.
* `expression3` is the value(s) used to update elements in `expression1`, based on the indices specified in `expression2`. If `expression2` is type `Int`, `expression3` must be type `T`. If `expression2` is type `Range`, `expression3` must be type `T[]`.

For example, the copy-and-update expression `arr w/ idx <- value` constructs a new array with all elements set to the corresponding elements in `arr`, except for the element(s) specified by `idx`, which is set to the value(s) in `value`. 

Given `arr` contains the array `[0,1,2,3]`, then 

- `arr w/ 0 <- 10` is the array `[10,1,2,3]`.
- `arr w/ 2 <- 10` is the array `[0,1,10,3]`.
- `arr w/ 0..2..3 <- [10,12]` is the array `[10,1,12,3]`.

#### Copy-and-update expressions for named items

Similar expressions exist for named items in user-defined types. 

For example, consider the type 

```qsharp
newtype Complex = (Re : Double, Im : Double);
```
If `c` contains the value of type `Complex(1., -1.)`, then `c w/ Re <- 0.` is an expression of type `Complex` that evaluates to `Complex(0., -1.)`.

### Jagged Arrays

A jagged array, sometimes called an "array of arrays," is an array whose elements are arrays.
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

You can also create an array of callables.

* If the common element type is an operation or function type, all of the elements must have the same input and output types.
* The element type of the array supports any [functors](xref:microsoft.quantum.guide.operationsfunctions) that are supported by all of the elements.
For example, if `Op1`, `Op2`, and `Op3` all are `Qubit[] => Unit` operations, but `Op1` supports `Adjoint`, `Op2` supports `Controlled`, and `Op3` supports both:
  * `[Op1, Op2]` is an array of `(Qubit[] => Unit)` operations.
  * `[Op1, Op3]` is an array of `(Qubit[] => Unit is Adj)` operations.
  * `[Op2, Op3]` is an array of `(Qubit[] => Unit is Ctl)` operations.

However, while the operations `(Qubit[] => Unit is Adj)` and  `(Qubit[] => Unit is Ctl)` have the common base type of `(Qubit[] => Unit)`, *arrays* of these operations do not share a common base type.

For example, `[[Op1], [Op2]]` would currently raise an error because it attempts to create an array of the two incompatible array types `(Qubit[] => Unit is Adj)[]` and `(Qubit[] => Unit is Ctl)[]`.

For more information on callables, see [Callable expressions](#callable-expressions)  on this page or [Operations and Functions in Q#](xref:microsoft.quantum.guide.operationsfunctions).

## Conditional Expressions

Given two expressions of the same type and a Boolean expression, form a conditional expression using the question mark, `?`, and the vertical bar `|`. Given `a==b ? c | d`, the value of the conditional expression is `c` if `a==b` is true and `d` if it is false.

### Conditional expressions with callables

Conditional expressions may evaluate to operations that have the same inputs and outputs but support different functors. In this case, the type of the conditional expression is an operation with inputs and outputs that support any functors supported by both expressions.
For example, if `Op1`, `Op2`, and `Op3` all are `Qubit[]=>Unit`, but `Op1` supports `Adjoint`, `Op2` supports `Controlled`, and `Op3` supports both:

- `flag ? Op1 | Op2` is a `(Qubit[] => Unit)` operation.
- `flag ? Op1 | Op3` is a `(Qubit[] => Unit is Adj)` operation.
- `flag ? Op2 | Op3` is a `(Qubit[] => Unit is Ctl)` operation.

If either of the two possible result expressions include a function or operation call, that call only takes place if that result is the one that is the value of the call. For example, in the case `a==b ? C(qs) | D(qs)`, if `a==b` is true, then the `C` operation is invoked, and if it is false then only the `D` operation is invoked. This approach is similar to *short-circuiting* in other languages.

## Callable Expressions

A callable literal is the name of an operation or function defined in the compilation scope. For example, `X` is an operation literal that refers to the standard library `X` operation, and `Message` is a function literal that refers to the standard library `Message` function.

If an operation supports the `Adjoint` functor, then `Adjoint op` is an operation expression.
Similarly, if the operation supports the `Controlled` functor, then `Controlled op` is an operation expression.
For more information about the types of these expressions, see [Calling operation specializations](xref:microsoft.quantum.guide.operationsfunctions#calling-operation-specializations).

Functors (`Adjoint` and `Controlled`) bind more closely than all other operators, except for the unwrap operator `!` and array indexing with `[ ]`.
Thus, the following are all valid, assuming that the operations support the functors used:

```qsharp
Adjoint Op(qs)
Controlled Op(controls, targets)
Controlled Adjoint Op(controls, targets)
Adjoint WrappedOp!(qs)
```

### Type-parameterized callable expressions

You can use a callable literal as a value, for example, to assign it to a variable or pass it to another callable. In this case, if the callable has [type parameters](xref:microsoft.quantum.guide.operationsfunctions#generic-type-parameterized-callables), you must provide the parameters as part of the callable value.

A callable value cannot have any unspecified type parameters. For example, if `Fun` is a function with the signature `'T1->Unit`:

```qsharp
let f = Fun<Int>;            // f is (Int->Unit).
let g = Fun;                 // This causes a compilation error.
SomeOtherFun(Fun<Double>);   // A (Double->Unit) is passed to SomeOtherFun.
SomeOtherFun(Fun);           // This also causes a compilation error.
```

## Callable Invocation Expressions

Given a callable expression (operation or function) and a tuple expression of the input type of the callable's signature, you can form an *invocation expression* by appending the tuple expression to the callable expression.
The type of the invocation expression is the output type of the callable's signature.

For example, if `Op` is an operation with the signature `((Int, Qubit) => Double)`, `Op(3, qubit1)` is an expression of type `Double`.
Similarly, if `Sin` is a function with the signature `(Double -> Double)`, `Sin(0.1)` is an expression of type `Double`.
Finally, if `Builder` is a function with the signature `(Int -> (Int -> Int))`, then `Builder(3)` is a function from `Int` to `Int`.

Invoking the result of a callable-valued expression requires an extra pair of parentheses around the callable expression.
Thus, to invoke the result of calling `Builder` from the previous paragraph, the correct syntax is:

```qsharp
(Builder(3))(2)
```

When invoking a [type-parameterized](xref:microsoft.quantum.guide.operationsfunctions#generic-type-parameterized-callables) callable, you can specify the actual type parameters within angle brackets `< >` after the callable expression.
This action is usually unnecessary as the Q# compiler infers the actual types.
However, it *is* required for [partial application](xref:microsoft.quantum.guide.operationsfunctions#partial-application) if a type-parameterized argument is left unspecified.
It is also useful when passing operations with different functor supports to a callable.

For example, if `Func` has signature `('T1, 'T2, 'T1) -> 'T2`, `Op1` and `Op2` have signature `(Qubit[] => Unit is Adj)`, and `Op3` has signature `(Qubit[] => Unit)`, to invoke `Func` with `Op1` as the first argument, `Op2` as the second, and `Op3` as the third:

```qsharp
let combinedOp = Func<(Qubit[] => Unit), (Qubit[] => Unit is Adj)>(Op1, Op2, Op3);
```

The type specification is required because `Op3` and `Op1` have different types, so the compiler will treat this as ambiguous without the specification.


## Operator Precedence

* All binary operators are right-associative, except for `^`.

* Brackets, `[ ]`, for array slicing and indexing, bind before any operator.

* The functors `Adjoint` and `Controlled` bind after array indexing but before all other operators.

* Parentheses for operation and function invocation also bind before any operator but after array indexing and functors.

Q# operators in order of precedence, from highest to lowest:

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
`w/` `<-` | Ternary | Copy-and-update | See [Copy-and-update expressions](#copy-and-update-expressions)

## Next steps

Now that you can work with expressions in Q#, move on to [Operations and Functions in Q#](xref:microsoft.quantum.guide.operationsfunctions) to learn how to define and call operations and functions.

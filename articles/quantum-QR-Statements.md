---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Q# statements | Microsoft Docs 
description: Q# statements
author: QuantumWriter
uid: microsoft.quantum.qsharp-ref.statements
ms.author: Alan.Geller@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# For Quantum products none of these categories have been defined  yet.
# ms.service: service-name-from-white-list
# ms.prod: product-name-from-white-list
# ms.technology: tech-name-from-white-list
---

# Statements and Other Constructs

## Comments

Comments begin with two forward slashes, `//`, 
and continue until the end of line. 
While expressions can be split across multiple lines, end of line comments in the middle of an expression are not supported. 
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
in Q# can be included using the `@"<ref target>"`, where `<ref target>` is replaced by the
fully qualified name of the code object being referenced.
Optionally, a documentation engine may also support additional Markdown extensions.

For example:

```qsharp
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
/// // Should be equivalent to the identity.
/// ApplyTwice(H, qubit);
/// ```
///
/// # See Also
/// - Microsoft.Quantum.Primitive.H
operation ApplyTwice<'T>(op : ('T => ()), target : 'T) : () {
    body {
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
- **See Also**: A list of fully qualified names indicating related functions, operations, or user-defined types.
- **References**: A list of references and citations for the item being documented.

## Namespaces

Every Q# operation, function, and user-defined type is
defined within a namespace.
Q# follows the same rules for naming as other .NET languages. However, Q# does not support nested namespaces. In particular, for two defined namespaces `NS.Name1` and `NS.Name2`, only the fully qualified namespace can be opened - a directive `open NS;` is **invalid**. 

Every Q# file must include at least one `namespace` directive.
This consists of the `namespace` keyword, followed by the namespace
name, an opening `{`, the construct definitions, and a closing `}`.
All user-defined types, functions, and operations must appear inside of a
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
an identifier, an equals sign `=`, an expression to bind the identifier to,
and a terminating semicolon. 
The type of the identifier is defined to be the same as the type of the expression
it is bound to.

For example, the statement

```qsharp
let i = 5;
```

binds the symbol `i` as an `Int` with the value `5`.

If the right-hand side of the binding is a tuple or a user-defined type, 
then an extended syntax may be used to deconstruct the tuple:

```qsharp
let (i, f) = (5, 0.1);
```

This statement will bind `5` to `i` and `0.1` to `f`.

Deconstructing binds may also be used for more complex tuples, such as:

```qsharp
let (a, (b, c)) = (1, (2, 3))
let (x, y) = (1, (2, 3))
```

In these examples, `a` and `x` both get bound to `1`,
`b` gets bound to `2`, `c` to `3`, and `y` to `(2, 3)`.

Tuple deconstruction can also be used when the right-hand side of the `=` 
is a tuple-valued expression:

```qsharp
let (r1, r2) = MeasureTwice(q1, PauliX, q2, PauliY);
```

### Mutable Symbols

Mutable symbols are defined and initialized using the `mutable` statement.
This statement defines a new symbol binding and specifies that the bound value
may be changed later in the code.

A mutable binding statement consists of the keyword `mutable`, followed by 
an identifier, an equals sign `=`, an expression to bind the identifier to,
and a terminating semicolon. 
The type of the identifier is defined to be the same as the type of the expression
it is bound to.

For example, the statement

```qsharp
mutable counter = 0;
```

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
an identifier, an equals sign `=`, an expression to rebind the identifier to,
and a terminating semicolon. 
The new value must be compatible with the original type, 
and will be promoted to the original type.

For example, the statement

```qsharp
set counter = counter + 1;
```

increments the `counter` symbol from the `mutable` example.

The `set` statement is also used to set the value of an item in a mutable array:

```qsharp
set result[1] = One;
```

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

```qsharp
if a == b {
    ...
    let n = 5;
    ...             // n is 5
}
let n = 8;
...                 // n is 8
```

and

```qsharp
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

But this would be illegal:

```qsharp
let n = 5;
...                 // n is 5
let n = 8;          // Error!!
...
```

as would:

```qsharp
let n = 8;
if a == b {
    ...             // n is 8
    let n = 5;      // Error!
    ...
}
...
```

## Control Flow

### For-Loop

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

```qsharp
for (index in 0 .. n-2) {
    set results[index] = Measure([PauliX], [qubits[index]]);
}
```

The loop variable is bound at each entrance to the loop body, and unbound 
at the end of the body. 
In particular, the loop variable is not bound after the for loop is completed.

### Repeat-Until-Success Loop

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
an important rotation gate $V_3 = (\boldone + 2 i Z) / \sqrt{5}$ using the 
Hadamard and T gates. 
The loop terminates in 8/5 repetitions on average.
See [*Repeat-Until-Success: Non-deterministic decomposition of single-qubit unitaries*](https://arxiv.org/abs/1311.1074) 
(Paetznick and Svore, 2014) for details.

```qsharp
using (ancilla = Qubit[1]) {
    repeat {
        let anc = ancilla[0];
        H(anc);
        T(anc);
        CNOT(target,anc);
        H(anc);
        (Adjoint T)(anc);
        H(anc);
        T(anc);
        H(anc);
        CNOT(target,anc);
        T(anc);
        Z(target);
        H(anc);
        let result = M(anc);
    } until result == Zero
    fixup {
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

```qsharp
if (result == One) {
    X(target);
} else {
    Z(target);
}
```

or

```qsharp
if (i == 1) {
    X(target);
} elif (i == 2) {
    Y(target);
} else {
    Z(target);
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

```qsharp
return 1;
```

or

```qsharp
return ();
```

or

```qsharp
return (results, qubits);
```

### Fail

The fail statement ends execution of an operation and returns an error value 
to the caller. 
It consists of the keyword `fail`, followed by a string
and a terminating semicolon.
The string is returned to the classical driver as the error message.

There is no restriction on the number of fail statements within an operation. 
The compiler may emit a warning if statements follow a fail statement within 
a block.

For example,

```qsharp
fail $"Impossible state reached";
```

or

```qsharp
fail $"Syndrome {syn} is incorrect";
```

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
the symbol that should be bound to the resulting array of qubits, `=`,
the type to acquire (`Qubit`), `[`, an `Int` expression, `]`, and
the statement block within which the qubits will be available. 

For example,

```qsharp
using (qubits = Qubit[bits * 2 + 3]) {
    ...
}
```

### Dirty Qubits

The borrowing statement is used to allocate qubits for temporary use
during a statement block. 
The borrower commits to leaving the qubits in the same state they were in 
when they were borrowed. 
Such qubits are often known as “dirty ancilla”. 
See [*Factoring using 2n+2 qubits with Toffoli based modular multiplication*](https://arxiv.org/abs/1611.07995)
(Haner, Roetteler, and Svore 2017) for an example of dirty ancilla use.

When borrowing qubits, the system will first try to fill the request
from qubits that are in use but that are not accessed during the body
of the `borrowing` statement.
If there aren't enough such qubits, then it will allocate new qubits
to complete the request.

The statement consists of the keyword `borrowing`, followed by 
the symbol that should be bound to the resulting array of qubits, `=`,
the type to acquire (`Qubit`), `[`, an `Int` expression, `]`, and
the statement block within which the qubits will be available. 

For example,

```qsharp
borrowing (qubits = Qubit[bits * 2 + 3]) {
    ...
}
```

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

---
title: Q# statements | Microsoft Docs 
description: Q# statements
author: QuantumWriter
uid: microsoft.quantum.language.statements
ms.author: Alan.Geller@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
---

# Statements and Other Constructs

## Comments

Comments begin with two forward slashes, `//`,
and continue until the end of line.
A comment may appear anywhere in a Q# source file.

### Documentation Comments

Comments that begin with three forward slashes, `///`,
are treated specially by the compiler when they appear immediately before
a namespace, operation, specialization, function, or type definition.
In that case, their contents are taken as documentation for the defined
callable or user-defined type, as for other .NET languages.

Within `///` comments, text to appear as a part of API documentation is
formatted as [Markdown](https://daringfireball.net/projects/markdown/syntax),
with different parts of the documentation being indicated by specially-named
headers.
As an extension to Markdown, cross references to operations, functions and
user-defined types in Q# can be included using the `@"<ref target>"`,
where `<ref target>` is replaced by the fully qualified name of the
code object being referenced.
Optionally, a documentation engine may also support additional
Markdown extensions.

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
/// - Microsoft.Quantum.Intrinsic.H
operation ApplyTwice<'T>(op : ('T => Unit), target : 'T) : Unit {
    op(target);
    op(target);
}
```

The following names are recognized as documentation comment headers.

- **Summary**: A short summary of the behavior of a function or operation,
  or of the purpose of a type. The first paragraph of the summary is used
  for hover information. It should be plain text.
- **Description**: A description of the behavior of a function or operation,
  or of the purpose of a type. The summary and description are concatenated to
  form the generated documentation file for the function, operation, or type.
  The description may contain in-line LaTeX-formatted symbols and equations.
- **Input**: A description of the input tuple for an operation or function.
  May contain additional Markdown subsections indicating each individual
  element of the input tuple.
- **Output**: A description of the tuple returned by an operation or function.
- **Type Parameters**: An empty section which contains one additional
  subsection for each generic type parameter.
- **Example**: A short example of the operation, function or type in use.
- **Remarks**: Miscellaneous prose describing some aspect of the operation,
  function, or type.
- **See Also**: A list of fully qualified names indicating related functions,
  operations, or user-defined types.
- **References**: A list of references and citations for the item being
  documented.

## Namespaces

Every Q# operation, function, and user-defined type is
defined within a namespace.
Q# follows the same rules for naming as other .NET languages.
However, Q# does not support relative references to namespaces.
That is, if the namespace `a.b` has been opened, a reference to an operation
names `c.d` will not be resolved to an operation with full name `a.b.c.d`.

Within a namespace block, the `open` directive may be used to 
import all types and callables declared in a certain namespace and refer to them by their unqualified name. Optionally, a short name for the opened namespace may be defined such that all elements from that namespace can (and need) to be qualified by the defined short name. 
The `open` directive applies to the entire namespace block within a file.

A type or callable defined in another namespace that is not
opened in the current namespace must be referenced by its fully-qualified name.
For example, an operation named `Op` in the `X.Y` namespace must be
referenced by its fully-qualified name `X.Y.Op`, unless the `X.Y`
namespace has been opened earlier in the current block. 
As mentioned above, even if the `X` namespace has been opened, it is not possible to reference the operation as `Y.Op`.
If a short name `Z` for `X.Y` has been defined in that namespace and file, then `Op` needs to be referred to as `Z.Op`. 

```qsharp
namespace NS {
    open Microsoft.Quantum.Intrinsic; // opens the namespace
    open Microsoft.Quantum.Math as Math; // defines a short name for the namespace
}
```

It is usually better to include a namespace by using an `open` directive.
Using a fully-qualified name is required if two namespaces define constructs
with the same name, and the current source uses constructs from both.

## Formatting

Most Q# statements and directives end with a terminating semicolon, `;`.
Statements and declarations such as `for` and `operation` that end with
a statement block do not require a terminating semicolon.
Each statement description notes whether the terminating semicolon
is required.

Statements, like expressions, declarations, and directives, may be broken out across multiple lines.
Having multiple statements on a single line should be avoided.

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

The left-hand-side of the binding consists of a symbol tuple, and the right hand side of an expression.

Since all Q# types are value types - with the qubits taking a somewhat special role - 
formally a "copy" is created when a value is bound to a symbol, or when a symbol is rebound. 
That is to say, the behavior of Q# is the same as if a copy were created on assignment. 
This in particular also includes arrays. Of course in practice only the relevant pieces are actually recreated as needed. 

### Tuple Deconstruction

If the right-hand side of the binding is a tuple,
then that tuple may be deconstructed upon assignment.
Such deconstructions may involve nested tuples, and any full or partial deconstruction is valid as long as the shape of the tuple on the right hand side is compatible with the shape of the symbol tuple.
Tuple deconstruction can in particular also be used when the right-hand side of the `=` is a tuple-valued expression.

```qsharp
let (i, f) = (5, 0.1); // i is bound to 5 and f to 0.1
mutable (a, (_, b)) = (1, (2, 3)); // a is bound to 1, b is bound to 3
mutable (x, y) = ((1, 2), [3, 4]); // x is bound to (1,2), y is bound to [3,4]
set (x, _, y) = ((5, 6), 7, [8]);  // x is rebound to (5,6), y is rebound to [8]
let (r1, r2) = MeasureTwice(q1, PauliX, q2, PauliY);
```

### Immutable Symbols

Immutable symbols are bound using the `let` statement.
This is roughly equivalent to variable declaration and initialization in
languages such as C#, except that Q# symbols, once bound, may not be changed;
`let` bindings are immutable.

An immutable binding consists of the keyword `let`, followed by
a symbol or symbol tuple, an equals sign `=`, an expression to bind the symbol(s) to, and a terminating semicolon.
The type of the bound symbol(s) is inferred based on the expression on the right hand side.

### Mutable Symbols

Mutable symbols are defined and initialized using the `mutable` statement.
Symbols declared and bound as part of a `mutable` statement may be rebound to a different value later in the code. 

A mutable binding statement consists of the keyword `mutable`, followed by
a symbol or symbol tuple, an equals sign `=`, an expression to bind the symbol(s) to, and a terminating semicolon.
The type of the bound symbol(s) is inferred based on the expression on the right hand side. If a symbol is rebound later in the code, its type does not change, and the bound value needs to be compatible with that type.

### Rebinding of Mutable Symbols

A mutable variable may be rebound using a `set` statement.
Such a rebinding consists of the keyword `set`, followed by
a symbol or symbol tuple, an equals sign `=`, an expression to rebind the symbol(s) to, and a terminating semicolon.
The value must be compatible with the type(s) of the symbol(s) it is bound to.

#### Apply-and-Reassign Statement

A particular kind of set-statement we refer to as an apply-and-reassign statement provides a convenient way of concatenation if the right hand side consists of the application of a binary operator and the result is to be rebound to the left argument to the operator. 
For example,
```qsharp
mutable counter = 0;
for (i in 1 .. 2 .. 10) {
    set counter += 1;
    // ...
}
```
increments the value of the counter `counter` in each iteration of the `for` loop. The code above is equivalent to 
```qsharp
mutable counter = 0;
for (i in 1 .. 2 .. 10) {
    set counter = counter + 1;
    // ...
}
```
Similar statements are available for all binary operators in which the type of the left-hand-side matches the expression type. 
This provides for example a convenient way to accumulate values:
```qsharp
mutable results = new Result[0];
for (qubit in qubits) {
    set results += [M(q)];
    // ...
}
```
#### Update-and-Reassign Statement

A similar concatenation exists for copy-and-update expressions on the right hand side. 
Correspondingly, update-and-reassign statements exist for named items in user-defined types as well as for array items.  

```qsharp
newtype Complex = (Re : Double, Im : Double);

function ElementwisePlus(reals : Double[], ims : Double[]) : Complex {
    mutable res = Complex(0.,0.);

    for (r in reals) {
        set res w/= Re <- res::Re + r; // update-and-reassign statement
    }
    for (i in ims) {
        set res w/= Im <- res::Im + i; // update-and-reassign statement
    }
    return res;
}
```

In the case of arrays, 
our standard libraries contain the necessary tools for many common array initialization and manipulation needs, 
and thus help avoid having to update array items in the first place. 
Update-and-reassign statements provide an alternative if needed:

```qsharp
operation GenerateRandomInts(max : Int, nSamples : Int) : Int[] {
    mutable samples = new Double[0];
    for (i in 1 .. nSamples) {
        set samples += [RandomInt(max)];
    }
    return samples;
}

operation SampleUniformDistrbution(nSamples : Int, nSteps : Int) : Double[] {
    let normalization = 1. / IntAsDouble(nSteps);
    mutable samples = GenerateRandomInts(nSteps, nSamples);
    
    for (i in IndexRange(samples) {
        let value = IntAsDouble(samples[i]);
        set samples w/= i <- normalization * value; // update-and-reassign statement
    }
}

```

> [!TIP]   
> Avoid unnecessary use of update-and-reassign statements by leveraging the tools provided in <xref:microsoft.quantum.arrays>.

The function
```qsharp
function PauliEmbedding(pauli : Pauli, length : Int, location : Int) : Pauli[] {
    mutable pauliArray = new Pauli[length];
    for (index in 0 .. length - 1) {
        set pauliArray w/= index <- 
            index == location ? pauli | PauliI;
    }    
    return pauliArray;
}
```
for example can simply be simplified using the function `ConstantArray` in `Microsoft.Quantum.Arrays`, 
and returning a copy-and-update expression:

```qsharp
function PauliEmbedding(pauli : Pauli, length : Int, location : Int) : Pauli[] {
    return ConstantArray(length, PauliI) w/ location <- pauli;
}
```

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
A symbol may only be bound once per block; it is illegal to define a symbol
with the same name as another symbol that is within scope (no "shadowing").
The following sequences would be legal:

```qsharp
if (a == b) {
    ...
    let n = 5;
    ...             // n is 5
}
let n = 8;
...                 // n is 8
```

and

```qsharp
if (a == b) {
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
if (a == b) {
    ...             // n is 8
    let n = 5;      // Error!
    ...
}
...
```

## Control Flow

### For Loop

The `for` statement supports iteration over an integer range or over an array.
The statement consists of the keyword `for`, an open parenthesis `(`,
followed by a symbol or symbol tuple, the keyword `in`, an expression of type `Range` or array, a close parenthesis `)`, and a statement block.

The statement block (the body of the loop) is executed repeatedly,
with the defined symbol(s) (the loop variable(s)) bound to each value in the range or array.
Note that if the range expression evaluates to an empty range or array,
the body will not be executed at all.
The expression is fully evaluated before entering the loop,
and will not change while the loop is executing.

The binding of the declared symbol(s) is immutable and follows the same rules as other variable bindings. 
In particular, it is possible to destruct e.g. array items for an iteration over an array upon assignment to the loop variable(s).

For example,

```qsharp
// ...
for (qubit in qubits) { // qubits contains a Qubit[]
    H(qubit);
}

mutable results = new (Int, Results)[Length(qubits)];
for (index in 0 .. Length(qubits) - 1) {
    set results w/= index <- (index, M(qubits[index]));
}

mutable accumulated = 0;
for ((index, measured) in results) {
    if (measured == One) {
        set accumulated += 1 <<< index;
    }
}
```

The loop variable is bound at each entrance to the loop body, and unbound at the end of the body.
In particular, the loop variable is not bound after the for loop is completed.

### Repeat-Until-Success Loop

The `repeat` statement supports the quantum “repeat until success” pattern.
It consists of the keyword `repeat`, followed by a statement block
(the _loop_ body), the keyword `until`, a Boolean expression, 
and either a terminating semicolon or 
the keyword `fixup` followed by another statement block (the _fixup_).
The loop body, condition, and fixup are all considered to be a single scope,
so symbols bound in the body are available in the condition and fixup.

```qsharp
mutable iter = 1;
repeat {
    ProbabilisticCircuit(qubits);
    let success = ComputeSuccessIndicator(qubits);
}
until (success || iter > maxIter)
fixup {
    iter += 1;
    ComputeCorrection(qubits);
}
```

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
The loop terminates in $\frac{8}{5}$ repetitions on average.
See [*Repeat-Until-Success: Non-deterministic decomposition of single-qubit unitaries*](https://arxiv.org/abs/1311.1074)
(Paetznick and Svore, 2014) for details.

```qsharp
using (qubit = Qubit()) {
    repeat {
        H(qubit);
        T(qubit);
        CNOT(target, qubit);
        H(qubit);
        Adjoint T(qubit);
        H(qubit);
        T(qubit);
        H(qubit);
        CNOT(target, qubit);
        T(qubit);
        Z(target);
        H(qubit);
        let result = M(qubit);
    } until (result == Zero);
}
```

> [!TIP]   
> Avoid using repeat-until-success loops inside functions. 
> The corresponding functionality is provided by while loops in functions. 

### While Loop

Repeat-until-success patterns have a very quantum-specific connotation. They are widely used in particular classes of quantum algorithms -- hence the dedicated language construct in Q#. 
However, loops that break based on a condition and whose execution length is thus unknown at compile time need to be handled with particular care in a quantum runtime. 
Their use within functions on the other hand is unproblematic, since these only contain code that will be executed on conventional (non-quantum) hardware. 

Q# therefore supports to use of while loops within functions only. 
A `while` statement consists of the keyword `while`, an open parenthesis `(`,
a condition (i.e. a Boolean expression), a close parenthesis `)`, and a statement block.
The statement block (the body of the loop) is executed as long as the condition evaluates to `true`.

```qsharp
// ...
mutable (item, index) = (-1, 0);
while (index < Length(arr) && item < 0) { 
    set item = arr[index];
    set index += 1;
}
```

### Conditional Statement

The `if` statement supports conditional execution.
It consists of the keyword `if`, an open parenthesis `(`, a Boolean
expression, a close parenthesis `)`, and a statement block (the _then_ block).
This may be followed by any number of else-if clauses, each of which consists
of the keyword `elif`, an open parenthesis `(`, a Boolean expression,
a close parenthesis `)`, and a statement block (the _else-if_ block).
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
They are only valid within operations.

### Clean Qubits

The `using` statement is used to acquire new qubits for use during a statement block.
The qubits are guaranteed to be initialized to the computational `Zero` state.
The qubits should be in the computational `Zero` state at the
end of the statement block; simulators are encouraged to enforce this.

The statement consists of the keyword `using`, followed by an open
parenthesis `(`, a binding, a close parenthesis `)`, and
the statement block within which the qubits will be available.
The binding follows the same pattern as `let` statements: either a single
symbol or a tuple of symbols, followed by an equals sign `=`, and either a
single value or a matching tuple of initializers.
Initializers are available either for a single qubit, indicated as `Qubit()`, or
an array of qubits, indicated by `Qubit[`, an `Int` expression, and `]`.

For example,

```qsharp
using (qubit = Qubit()) {
    // ...
}
using ((auxiliary, qubits) = (Qubit(), Qubit[bits * 2 + 3])) {
    // ...
}
```

### Borrowed Qubits

The `borrowing` statement is used to obtain qubits for temporary use. 
The statement consists of the keyword `borrowing`, followed by an open
parenthesis `(`, a binding, a close parenthesis `)`, and
the statement block within which the qubits will be available.
The binding follows the same pattern and rules as the one in a `using` statement.

For example,

```qsharp
borrowing (qubit = Qubit()) {
    // ...
}
borrowing ((auxiliary, qubits) = (Qubit(), Qubit[bits * 2 + 3])) {
    // ...
}
```

The borrowed qubits are in an unknown state and go out of scope at the end of the statement block.
The borrower commits to leaving the qubits in the same state they were in when they were borrowed, 
i.e. their state at the beginning and at the end of the statement block is expected to be the same.
This state in particular is not necessarily a classical state, such that in most cases, 
borrowing scopes should not contain measurements. 

See [*Factoring using 2n+2 qubits with Toffoli based modular multiplication*](https://arxiv.org/abs/1611.07995)
(Haner, Roetteler, and Svore 2017) for an example of borrowed qubit use.

When borrowing qubits, the system will first try to fill the request
from qubits that are in use but that are not accessed during the body of the `borrowing` statement.
If there aren't enough such qubits, then it will allocate new qubits
to complete the request.

## Conjugations

In contrast to classical bits, 
releasing quantum memory is slightly more involved
since blindly resetting qubits can have undesired effects on the remaining computation if the qubits are still entangled. 
This can be avoided by properly "undoing" performed computations prior to releasing the memory. 
A common pattern in quantum computing is hence the following: 

```qsharp
operation ApplyWith<'T>(
    outerOperation : ('T => Unit is Adj), 
    innerOperation : ('T => Unit), 
    target : 'T) 
: Unit {

    outerOperation(target);
    innerOperation(target);
    Adjoint outerOperation(target);
}
```

:new: Starting with our 0.9 release, we support a conjugation statement that implements the transformation above. Using that statement, the operation `ApplyWith` can be implemented in the following way:

```qsharp
operation ApplyWith<'T>(
    outerOperation : ('T => Unit is Adj), 
    innerOperation : ('T => Unit), 
    target : 'T) 
: Unit {

    within{ 
        outerOperation(target);
    }
    apply {
        innerOperation(target);
    }
}
```
Such a conjugation statement obviously becomes far more useful if the outer and inner transformation are not readily available as operations but are instead more convenient to describe by a block consisting of several statements. 

The inverse transformation for the statements defined in the within-block is automatically generated by the compiler and executed after the apply-block completes. Since any mutable variables used as part of the within-block cannot be rebound in the apply-block, the generated transformation is guaranteed to be the adjoint of the computation in the within-block. 

## Expression Evaluation Statements

Any call expression of type `Unit` may be used as a statement.
This is primarily of use when calling operations on qubits that return `Unit`
because the purpose of the statement is to modify the implicit quantum state.
Expression evaluation statements require a terminating semicolon.

For example,

```qsharp
X(q);
CNOT(control, target);
Adjoint T(q);
```

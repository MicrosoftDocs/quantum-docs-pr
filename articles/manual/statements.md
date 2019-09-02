---
title: Q# statements
description: Q# statements, Control Flow and other constructs
author: QuantumWriter
uid: microsoft.quantum.manual.statements
ms.author: Alan.Geller@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
---

# Statements, Control Flow, and Other Constructs 

This section contains description of statements,work flow elements like loops or conditonals and other kind of constructs.

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
operation ApplyTwice<'T>(op : ('T => Unit), target : 'T) : Unit
{
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
If a short name `Z` for `X.Y` has been defined in that namespace and file, then `Op` needs to be referred to as `Y.Op`. 

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

We are working to ensure that common punctuation marks are used consistently in all situations.
We expect that this will make Q# easier to learn and to read because these marks
always mean the same thing, and the same concept is always represented the same way.

Specifically:

- The semi-colon, `;`, is used to end a statement or single-line directive.
  It is not used for any other purpose.
- The comma, `,`, is used to separate elements of a sequence. It is used for tuple literals,
  array literals, argument lists, tuple definitions, and type lists. **In a change from earlier
  versions, `;` is no longer supported as an array literal separator.**
- The colon, `:`, is used to introduce a type annotation. It is primarily used in callable signatures.
  Because colon always introduces a type signature, the ternary conditional operator introduced in 0.3
  uses a vertical bar, `|`, to separate the true and false values; thus, Q# uses `cond ? tval | fval`
  instead of the colon as separator as in C.
  
Statements and declarations such as `for` and `operation` that end with
a statement block do not require a terminating semicolon.
Each statement description notes whether the terminating semicolon
is required.

Statements, like expressions, declarations, and directives, may be broken out across multiple lines.
Having multiple statements on a single line should be avoided.
.

## Statement Blocks

Q# statements are grouped into statement blocks.
A statement block starts with an opening `{` and ends with a
closing `}`.

A statement block that is lexically enclosed within another block
is considered to be a sub-block of the containing block;
containing and sub-blocks are also called outer and inner blocks.

## Local variables: Symbol Binding and Assignment

Q# distinguishes between mutable and immutable symbols.

In general, the use of immutable symbols is encouraged because it
allows the compiler to perform more optimizations.

The left-hand-side of the binding consists of a symbol tuple, and the right hand side of an expression.

Since all Q# types are value types - with the qubits taking a somewhat special role - 
formally a "copy" is created when a value is bound to a symbol, or when a symbol is rebound. 
That is to say, the behavior of Q# is the same as if a copy were created on assignment. 
This in particular also includes arrays. Of course in practice only the relevant pieces are actually recreated as needed. 

### Immutable Symbols

Immutable symbols are bound using the `let` statement.
This is roughly equivalent to variable declaration and initialization in
languages such as C#, except that Q# symbols, once bound, may not be changed;
`let` bindings are immutable.

An immutable binding consists of the keyword `let`, followed by
a symbol or symbol tuple, an equals sign `=`, an expression to bind the symbol(s) to, and a terminating semicolon.
The type of the bound symbol(s) is inferred based on the expression on the right hand side. For instance:

```qsharp
let measurementOperators = [PauliX, PauliZ, PauliZ, PauliX, PauliI];
```

This assigns a particular array of Pauli operators to an immutable variable called `measurementOperators`.

> [!TIP]
> Note that we did not need to explicitly specify the type of our new variable, as the expression on the right-hand side of the `let` statement is unambiguous and the type is inferred by the compiler.
Once a variable has been defined in this way, it can no longer be changed in any way.
This allows for several beneficial optimizations, including optimization of the classical logic acting on variables to be reordered for applying the `Adjoint` variant of an operation.

Variables defined using the `let` binding as above are local to a particular scope, such as the body of an operation or the contents of a `for` loop.

### Mutable Symbols

Mutable symbols are defined and initialized using the `mutable` statement.
Symbols declared and bound as part of a `mutable` statement may be rebound to a different value later in the code. 

A mutable binding statement consists of the keyword `mutable`, followed by
a symbol or symbol tuple, an equals sign `=`, an expression to bind the symbol(s) to, and a terminating semicolon.
The type of the bound symbol(s) is inferred based on the expression on the right hand side. If a symbol is rebound later in the code, its type does not change, and the bound value needs to be compatible with that type.

Mutability within Q# is a concept that applies to a *symbol* rather than a type or value. 
Specifically, it does not have a representation in the type system, implicitly or explicitly, and whether or not a binding is mutable (as indicated by the `mutable` keyword) or immutable (as indicated by `let`) does not change the type of the bound variable(s). 
This provides an important way to isolate mutability inside specialized functions and operations.
In particular, even though an adjoint specialization for an operation which uses a mutable variable cannot be auto-generated, auto-generation works fine for an operation calling a function which uses mutability.
For this reason, it is a good practice to make functions and operations which use mutability as short and compact as possible, so that the rest of the quantum program can be written using ordinary immutable variables.

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
for (q in qubits) {
    set results += [M(q)];
    // ...
}
```

#### Update-and-Reassign Statement

A similar concatenation exists for copy-and-update expressions on the right hand side. 
Correspondingly, update-and-reassign statements exist for named items in user-defined types as well as for array items.  

```qsharp
newtype Complex = (Re : Double, Im : Double);

function AddAll (reals : Double[], ims : Double[]) : Complex[] {
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
operation RandomInts(maxInt : Int, nrSamples : Int) : Int[] {

    mutable samples = new Double[0];
    for (i in 1 .. nrSamples) {
        set samples += [RandomInt(maxInt)];
    }
    return samples;
}

operation SampleUniformDistr(nrSamples : Int, prec : Int) : Double[] {

    let normalization = 1. / IntAsDouble(prec);
    mutable samples = RandomInts(prec, nrSamples);
    
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
function EmbedPauli (pauli : Pauli, location : Int, n : Int) : Pauli[]
{
    mutable pauliArray = new Pauli[n];
    for (index in 0 .. n - 1) {
        set pauliArray w/= index <- 
            index == location ? pauli | PauliI;
    }
    return pauliArray;
}
```

for example can simply be simplified using the function `ConstantArray` in `Microsoft.Quantum.Arrays`, 
and returning a copy-and-update expression:

```qsharp
function EmbedPauli (pauli : Pauli, i : Int, n : Int) : Pauli[] {
    return ConstantArray(n, PauliI) w/ i <- pauli;
}
```

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

Within an operation or function, each statement executes in order, similar to most common imperative classical languages.
This flow of control can be modified, however, in three distinct ways:

- `if` Statements
- `for` Loops
- `repeat`-`until` Loops

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
for (qb in qubits) { // qubits contains a Qubit[]
    H(qb);
}

mutable results = new (Int, Results)[Length(qubits)];
for (index in 0 .. Length(qubits) - 1) {
    let measured = 
    set results w/= index <- (index, M(qubits[i]));
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
    ProbabilisticCircuit(qs);
    let success = ComputeSuccessIndicator(qs);
}
until (success || iter > maxIter)
fixup {
    iter += 1;
    ComputeCorrection(qs);
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
The loop terminates in 8/5 repetitions on average.
See [*Repeat-Until-Success: Non-deterministic decomposition of single-qubit unitaries*](https://arxiv.org/abs/1311.1074)
(Paetznick and Svore, 2014) for details.

```qsharp
using (anc = Qubit()) {
    repeat {
        H(anc);
        T(anc);
        CNOT(target,anc);
        H(anc);
        Adjoint T(anc);
        H(anc);
        T(anc);
        H(anc);
        CNOT(target,anc);
        T(anc);
        Z(target);
        H(anc);
        let result = M(anc);
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

### Allocating Qubits
In Q# we can allocate qubits through two different statements: `using` and `borrowing`. The qubits acquired with the statement `using` are called *clean qubits* and those aquired with the statement `borrowing` are called *dirty qubits*.

#### Clean Qubits

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
using (q = Qubit()) {
    // ...
}
using ((ancilla, qubits) = (Qubit(), Qubit[bits * 2 + 3])) {
    // ...
}
```
> [!WARNING]
> Target machines expect that qubits are in the $\ket{0}$ state immediately before deallocation, so that they can be reused and offered to other `using` blocks for allocation.
> Whenever possible, use unitary operations to return any allocated qubits to $\ket{0}$.
> If need be, the @"microsoft.quantum.intrinsic.reset" operation can be used to measure a qubit instead, and to use that measurement result to ensure that the measured qubit is returned to $\ket{0}$. Such a measurement will destroy any entanglement with the remaining qubits and can thus impact the computation. 
> 
#### Dirty Qubits

The `borrowing` statement is used to obtain qubits for temporary use. 
The statement consists of the keyword `borrowing`, followed by an open
parenthesis `(`, a binding, a close parenthesis `)`, and
the statement block within which the qubits will be available.
The binding follows the same pattern and rules as the one in a `using` statement.

For example,

```qsharp
borrowing (q = Qubit()) {
    // ...
}
borrowing ((ancilla, qubits) = (Qubit(), Qubit[bits * 2 + 3])) {
    // ...
}
```

The borrowed qubits are in an unknown state and go out of scope at the end of the statement block.
The borrower commits to leaving the qubits in the same state they were in when they were borrowed, 
i.e. their state at the beginning and at the end of the statement block is expected to be the same.
This state in particular is not necessarily a classical state, such that in most cases, 
borrowing scopes should not contain measurements. 

Such qubits are often known as “dirty ancilla”.
See [*Factoring using 2n+2 qubits with Toffoli based modular multiplication*](https://arxiv.org/abs/1611.07995)
(Haner, Roetteler, and Svore 2017) for an example of dirty ancilla use.

When borrowing qubits, the system will first try to fill the request
from qubits that are in use but that are not accessed during the body of the `borrowing` statement.
If there aren't enough such qubits, then it will allocate new qubits
to complete the request.


### Intrinsic Operations
Once allocated, a qubit can then be passed to functions and operations.
In some sense, this is all that a Q# program can do with a qubit, as the actions that can be taken are all defined as operations.
More information of these operations can be found in [Intrinsic Operations and Functions](xref:microsoft.quantum.libraries.standard.prelude) and [Operations and Functions](xref:microsoft.quantum.manual.operations-functions).

Here we present an example of operation implementation:
First, the single-qubit Pauli operators [$X$](xref:microsoft.quantum.intrinsic.x), [$Y$](xref:microsoft.quantum.intrinsic.y), and [$Z$](xref:microsoft.quantum.intrinsic.z) are represented in Q# by the intrinsic operations `X`, `Y`, and `Z`, each of which has type `(Qubit => Unit is Adj + Ctl)`.
As described in [Intrinsic Operations and Functions](xref:microsoft.quantum.libraries.standard.prelude), we can think of $X$ and hence of `X` as a bit-flip operation or NOT gate.
This lets us prepare states of the form $\ket{s_0 s_1 \dots s_n}$ for some classical bit string $s$:

```qsharp
operation PrepareBitString(bitstring : Bool[], register : Qubit[]) : Unit 
is Adj + Ctl {

    let nQubits = Length(register);
    for (idxQubit in 0..nQubits - 1) {
        if (bitstring[idxQubit]) {
            X(register[idxQubit]);
        }
    }
}

operation Example() : Unit {

    using (register = Qubit[8]) {
        PrepareBitString(
            [true, true, false, false, true, false, false, true],
            register
        );
        // At this point, register now has the state |11001001〉.
    }
}
```
### Expression Evaluation Statements

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
## Measurements ##

Using the `Measure` operation, which is a built in intrinsic non-unitary operation, we can extract classical information from an object of type `Qubit` and assign a classical value as a result, which has a reserved type `Result`, indicating that the result is no longer a quantum state. 
The input to `Measure` is a Pauli axis on the Bloch sphere, represented by an object of type `Pauli` (i.e., for instance `PauliX`) and an object of type `Qubit`. 

A simple example is the following operation which creates one qubit in the $\ket{0}$ state, then applies a Hadamard gate ``H`` to it and then measures the result in the `PauliZ` basis. 

```qsharp
operation MeasureOneQubit() : Result {

    // The following using block creates a fresh qubit and initializes it 
    // in the |0〉 state.
    using (qubit = Qubit()) {
        // We apply a Hadamard operation H to the state, thereby creating the 
        // state 1/sqrt(2)(|0〉+|1〉). 
        H(qubit); 
        // Now we measure the qubit in Z-basis.
        let result = M(qubit);
        // As the qubit is now in an eigenstate of the measurement operator, 
        // we reset the qubit before releasing it. 
        if (result == One) { X(qubit); }   
        // Finally, we return the result of the measurement. 
        return result;
    }
}
```
> [!TIP]
> A great number of typical operations can be implemented in a simpler fashion by using the [libraries](xref:microsoft.quantum.libraries). For 
> example, the code above can be shortened by using the operation [`MResetZ`](xref:microsoft.quantum.measurement.mresetz):

```qsharp
open Microsoft.Quantum.Measurement;

operation MeasureOneQubit() : Result {
   // The following using block creates a fresh qubit and initializes it 
    // in the |0〉 state.
    using (qubit = Qubit()) {
        // We apply a Hadamard operation H to the state, thereby creating the 
        // state 1/sqrt(2)(|0〉+|1〉). 
        H(qubit); 
        // Now we measure the qubit in Z-basis and return the result.
        return MResetZ(qubit);
    }
}
```

A slightly more complicated example is given by the following operation which returns the Boolean value `true` if all qubits in a register of type `Qubit[]` are in the state zero when measured in a specified Pauli basis, and `false` otherwise. 

```qsharp
operation AllMeasurementsZero (pauli : Pauli, qs : Qubit[]) : Bool {

    mutable value = true;
    for (q in qs) {
        if ( Measure([pauli], [q]) == One ) {
            set value = false;
        }
    }
    return value;
}
```

The Q# language allows dependencies of classical control flow on measurement results of qubits. This in turn enables to implement powerful probabilistic gadgets that can reduce the computational cost for implementing unitaries. As an example, it is easy to implement so-called *Repeat-Until-Success* in Q# which are probabilistic circuits that have an *expected* low cost in terms of elementary gates, but for which the true cost depends on an actual run and an actual interleaving of various possible branchings. 

To facilitate Repeat-Until-Success (RUS) patterns, Q# supports the construct
```qsharp
repeat {
    statementBlock1 
}
until (expression)
fixup {
    statementBlock2
}
```
where `statementBlock1` and `statementBlock2` are zero or more Q# statements, and where `expression` is any valid expression that evaluates to a value of type `Bool`. 
In a typical use case, the following circuit implements a rotation around an irrational axis of $(I + 2i Z)/\sqrt{5}$ on the Bloch sphere. This is accomplished by using a known RUS pattern: 

```qsharp
operation RUSCircuit (qubit : Qubit) : Unit {

    using (auxillaryQubits = Qubit[2]) {
        ApplyToEachA(H, ancillas);
        mutable finished = false;
        repeat {
            Controlled X(ancillas, qubit);
            S(qubit);
            Controlled X(ancillas, qubit);
            Z(qubit);
        }
        until(finished)
        fixup {
            if AllMeasurementsZero(ancillas, Xpauli) {
                set finished = true;
            }
        }
    }
}
```

This example shows the use of a mutable variable `finished` which is in scope of the entire repeat-until-fixup loop and which gets initialized before the loop and updated in the fixup step.

Finally, we show an example of a RUS pattern to prepare a quantum state $\frac{1}{\sqrt{3}}\left(\sqrt{2}\ket{0}+\ket{1}\right)$, starting from the $\ket{+}$ state. See also the [unit testing sample provided with the standard library](https://github.com/Microsoft/Quantum/blob/master/Samples/src/UnitTesting/RepeatUntilSuccessCircuits.qs): 

```qsharp
operation RepeatUntilSuccessStatePreparation( target : Qubit ) : Unit {

    using (auxillaryQubit = Qubit()) {
        H(ancilla);
        repeat {
            // We expect target and ancilla qubit to be in |+⟩ state.
            AssertProb( 
                [PauliX], [target], Zero, 1.0, 
                "target qubit should be in the |+⟩ state", 1e-10 );
            AssertProb( 
                [PauliX], [ancilla], Zero, 1.0,
                "ancilla qubit should be in the |+⟩ state", 1e-10 );
                
            Adjoint T(ancilla);
            CNOT(target, ancilla);
            T(ancilla);

            // The probability of measuring |+⟩ state on ancilla is 3/4.
            AssertProb( 
                [PauliX], [ancilla], Zero, 3. / 4., 
                "Error: the probability to measure |+⟩ in the first 
                ancilla must be 3/4",
                1e-10);

            // If we get measurement outcome Zero, we prepare the required state 
            let outcome = Measure([PauliX], [ancilla]);
        }
        until( outcome == Zero )
        fixup {
            // Bring ancilla and target back to |+⟩ state
            if( outcome == One ) {
                Z(ancilla);
                X(target);
                H(target);
            }
        }
        // Return ancilla back to Zero state
        H(ancilla);
    }
}
```
 
Notable programmatic features shown in this operation are a more complex `fixup` part of the loop which involves quantum operations, and the use of `AssertProb` statements to ascertain the probability of measuring the quantum state at certain specified points in the program. See also [Testing and debugging](xref:microsoft.quantum.manual.testing-and-debugging) for more information about `Assert` and `AssertProb` statements. 

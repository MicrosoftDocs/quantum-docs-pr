---
title: Control Flow in Q#
description: Loops, conditionals, etc.
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.date: 03/05/2020
ms.topic: article
uid: microsoft.quantum.guide.controlflow
---

# Control flow in Q#

Within an operation or function, each statement runs in order, similar to other common imperative classical languages.
However, you can modify the flow of control in three distinct ways:

* `if` statements
* `for` loops
* `repeat-until-success` loops

The `if` and `for` control flow constructs proceed in a familiar sense to most classical programming languages. [`Repeat-until-success`](#repeat-until-success-loop) loops are discussed later in this article.

Importantly, `for` loops and `if` statements can be used in operations for which [specializations](xref:microsoft.quantum.guide.operationsfunctions) are auto-generated. In that scenario, the adjoint of a `for` loop reverses the direction and takes the adjoint of each iteration.
This action follows the "shoes-and-socks" principle: if you wish to undo putting on socks and then shoes, you must undo putting on shoes and then undo putting on socks. 

## If, Else-if, Else

The `if` statement supports conditional execution.
It consists of the keyword `if`, a Boolean expression in parentheses, and a statement block (the _then_ block).
Optionally, any number of else-if clauses can follow, each of which consists of the keyword `elif`, a Boolean expression in parentheses, and a statement block (the _else-if_ block).
Finally, the statement can optionally finish with an else clause, which consists of the keyword `else` followed by another statement block (the _else_ block).

The `if` condition is evaluated, and if it is *true*, the *then* block is run.
If the condition is *false*, then the first else-if condition is evaluated; if that is true, then the *else-if* block is run.
Otherwise, the second else-if block evaluates, and then the third, and so on until either a clause with a true condition is encountered or there are no more else-if clauses.
If the original *if* condition and all the else-if clauses evaluate to *false*, the *else* block is run, if provided.

Note that whichever block runs, it runs within its own scope.
Bindings made inside of an `if`, `elif`, or `else` block are not visible after the block ends.

For example,

```qsharp
if (result == One) {
    X(target);
    let n = 1;
    // n is bound
} 
// n is not bound
```
or
```qsharp
if (i == 1) {
    X(target);
    let n = 1;
} elif (i == 2) {
    Y(target);
    let m = n + 1; // would cause an error, because n is no longer bound
} else {
    Z(target);
}
```

## For loop

The `for` statement supports iteration over an integer range or an array.
The statement consists of the keyword `for`, followed by a symbol or symbol tuple, the keyword `in`, and an expression of type `Range` or array, all in parentheses, and a statement block.

The statement block (the body of the loop) runs repeatedly, with the defined symbol (the loop variable) bound to each value in the range or array.
Note that if the range expression evaluates to an empty range or array, the body does not run at all.
The expression is fully evaluated before entering the loop, and does not change while the loop is executing.

The loop variable is bound at each entrance to the loop body, and is unbound at the end of the body.
The loop variable is not bound after the for loop is completed.
The binding of the loop variable is immutable and follows the same rules as other variable bindings. 

In these examples, `qubits` is a register of qubits (i.e. of type `Qubit[]`), 

```qsharp
// ...
for (qubit in qubits) {  // iterate over each qubit value in the array qubits
    H(qubit);
}
// 'qubit' is no longer bound

mutable results = new (Int, Results)[Length(qubits)];
for (index in 0 .. Length(qubits) - 1) {  // iterates over the integers in the Range 0 .. (Length(qubits) - 1)
    set results w/= index <- (index, M(qubits[index])); // measure each qubit, updates the tuple value in the results array that at index 
}

mutable accumulated = 0;
for ((index, measured) in results) { // iterates over the tuple values in results
    if (measured == One) {
        set accumulated += 1 <<< index;
    }
}
```

Note that at the end, we utilized the arithmetic-shift-left binary operator, `<<<`. For more information, see [Numeric Expressions](xref:microsoft.quantum.guide.expressions#numeric-expressions).

## Repeat-until-success loop

The Q# language allows classical control flow to depend on the results of measuring qubits.
This capability, in turn, enables implementing powerful probabilistic gadgets that can reduce the computational cost for implementing unitaries.
Examples of this are the *repeat-until-success* (RUS) patterns in Q#.
These RUS patterns are probabilistic programs that have an *expected* low cost in terms of elementary gates; the incurred cost depends on the actual run and the interleaving of the multiple possible branchings.

To facilitate repeat-until-success (RUS) patterns, Q# supports the constructs

```qsharp
repeat {
    // do stuff
}
until (expression)
fixup {
    // do other stuff
}
```

where `expression` is any valid expression that evaluates to a value of type `Bool`.
The loop body runs, and then the condition is evaluated.
If the condition is true, then the statement is completed; otherwise, the fixup runs, and the statement runs again, starting with the loop body.

All three portions of an RUS loop (the body, the test, and the fixup) are treated as a single scope *for each repetition*, so symbols that are bound in the body are available in both the test and the fixup.
However, completing the execution of the fixup ends the scope for the statement, so that symbol bindings made during the body or fixup are not available in subsequent repetitions.

Further, the `fixup` statement is often useful but not always necessary.
In cases that it is not needed, the construct

```qsharp
repeat {
    // do stuff
}
until (expression);
```

is also a valid RUS pattern.

For more examples and details, see [Repeat-until-success examples](#repeat-until-success-examples) in this article.

> [!TIP]   
> Avoid using repeat-until-success loops inside functions. 
> Use *while* loops to provide the corresponding functionality inside functions. 

## While loop

Repeat-until-success patterns have a very quantum-specific connotation. They are widely used in particular classes of quantum algorithms - hence the dedicated language construct in Q#. 
However, loops that break based on a condition and whose execution length is thus unknown at compile-time, are handled with particular care in a quantum runtime. 
However, their use within functions is unproblematic since these loops only contain code that runs on conventional (non-quantum) hardware. 

Q#, therefore, supports to use of while loops within functions only. 
A `while` statement consists of the keyword `while`, a Boolean expression in parentheses, and a statement block.
The statement block (the body of the loop) runs as long as the condition evaluates to `true`.

```qsharp
// ...
mutable (item, index) = (-1, 0);
while (index < Length(arr) && item < 0) { 
    set item = arr[index];
    set index += 1;
}
```

## Return Statement

The return statement ends the run of an operation or function
and returns a value to the caller.
It consists of the keyword `return`, followed by an expression of the
appropriate type, and a terminating semicolon.

For example,
```qsharp
return 1;
```
or
```qsharp
return (results, qubits);
```

* A callable that returns an empty tuple, `()`, does not require a
return statement.
* To specify an early exit from the operation or function, use `return ();`.
Callables that return any other type require a final return statement.
* There is no maximum number of return statements within an operation.
The compiler may emit a warning if statements follow a return statement
within a block.

   
## Fail statement

The fail statement ends the run of an operation and returns an error value to the caller.
It consists of the keyword `fail`, followed by a string and a terminating semicolon.
The statement returns the string to the classical driver as the error message.

There is no restriction on the number of fail statements within an operation.
The compiler may emit a warning if statements follow a fail statement within a block.

For example,

```qsharp
fail $"Impossible state reached";
```
or, using [interpolated strings](xref:microsoft.quantum.guide.expressions#interpolated-strings),
```qsharp
fail $"Syndrome {syn} is incorrect";
```

## Repeat-until-success examples

### RUS pattern for single-qubit rotation about an irrational axis 

In a typical use case, the following Q# operation implements a rotation around an irrational axis of $(I + 2i Z)/\sqrt{5}$ on the Bloch sphere. The implementation uses a known RUS pattern:

```qsharp
operation ApplyVRotationUsingRUS(qubit : Qubit) : Unit {
    using (controls = Qubit[2]) {
        ApplyToEachA(H, controls);
        mutable finished = false;
        repeat {
            Controlled X(controls, qubit);
            S(qubit);
            Controlled X(controls, qubit);
            Z(qubit);
        }
        until (finished)
        fixup {
            if (MeasureIfAllQubitsAreZero(controls, PauliX)) {
                set finished = true;
            }
        }
    }
}
```

### RUS loop with a mutable variable in scope

This example shows the use of a mutable variable, `finished`, which is within the scope of the entire repeat-until-fixup loop and which gets initialized before the loop and updated in the fixup step.

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

### RUS without `fixup`

This example shows an RUS loop without the fixup step. The code is a probabilistic circuit that implements an important rotation gate $V_3 = (\boldone + 2 i Z) / \sqrt{5}$ using the `H` and `T` gates.
The loop terminates in $\frac{8}{5}$ repetitions on average.
See [*Repeat-Until-Success: Non-deterministic decomposition of single-qubit unitaries*](https://arxiv.org/abs/1311.1074) (Paetznick and Svore, 2014) for more details.

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

### RUS to prepare a quantum state

Finally, here is an example of an RUS pattern to prepare a quantum state $\frac{1}{\sqrt{3}}\left(\sqrt{2}\ket{0}+\ket{1}\right)$, starting from the $\ket{+}$ state.

Notable programmatic features shown in this operation are:

* A more complex `fixup` part of the loop, which involves quantum operations. 
* The use of `AssertProb` statements to ascertain the probability of measuring the quantum state at certain specified points in the program.

For more information about the [`Assert`](xref:microsoft.quantum.intrinsic.assert) and [`AssertProb`](xref:microsoft.quantum.intrinsic.assertprob) operations, see [Testing and debugging](xref:microsoft.quantum.guide.testingdebugging).

```qsharp
operation PrepareStateUsingRUS(target : Qubit) : Unit {
    using (auxiliary = Qubit()) {
        H(auxiliary);
        repeat {
            // We expect the target and auxiliary qubits to each be in
            // the |+> state.
            AssertProb(
                [PauliX], [target], Zero, 1.0,
                "target qubit should be in the |+> state", 1e-10 );
            AssertProb(
                [PauliX], [auxiliary], Zero, 1.0,
                "auxiliary qubit should be in the |+> state", 1e-10 );

            Adjoint T(auxiliary);
            CNOT(target, auxiliary);
            T(auxiliary);

            // The probability of measuring |+> state on the auxiliary qubit
            // is 3/4.
            AssertProb(
                [PauliX], [auxiliary], Zero, 3. / 4.,
                "Error: the probability to measure |+> in the first
                auxiliary must be 3/4",
                1e-10);

            // If we get the measurement outcome Zero, we prepare the
            // required state.
            let outcome = Measure([PauliX], [auxiliary]);
        }
        until (outcome == Zero)
        fixup {
            // Bring the auxiliary and target qubits back to |+> state.
            if (outcome == One) {
                Z(auxiliary);
                X(target);
                H(target);
            }
        }
        // Return the auxiliary qubit back to the Zero state.
        H(auxiliary);
    }
}
```

For more information, see [unit testing sample provided with the standard library](https://github.com/microsoft/Quantum/blob/master/samples/diagnostics/unit-testing/RepeatUntilSuccessCircuits.qs):

## Next steps

Learn about [Testing and Debugging](xref:microsoft.quantum.guide.testingdebugging) in Q#.

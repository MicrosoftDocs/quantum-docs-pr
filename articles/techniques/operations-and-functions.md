---
title: Q# techniques - operations and functions | Microsoft Docs
description: Q# techniques - operations and functions
uid: microsoft.quantum.techniques.opsandfunctions
author: QuantumWriter
ms.author: Christopher.Granade@microsoft.com
ms.date: 12/11/2017
ms.topic: article
---

# Operations and Functions #

Q# programs consist of one or more *operations* which describe side effects which quantum operations can have on quantum data and one or more *functions* which allow to modify classical data. In contrast to operations, functions are used to describe purely classical behavior and do not have any effects besides computing classical output values.

Each operation defined in Q# may then call any number of other operations, including the built-in primitive operations defined by the language. The particular way in which these primitive operations are defined depends on the target machine. When compiled, each operation is represented as a .NET class type that can be provided to target machines.

## Defining New Operations ##

As described above, the most basic building block of a quantum program written in Q# is an *operation*, which can either be called from classical .NET applications, e.g., using a simulator, or by other operations within Q#.
Each operation takes an input, produces an output, and minimally consists of a *body* listing one or more instructions.
For instance, the following operation takes a single qubit as its input, then calls the built-in `X` operation on that input:

```qsharp
operation BitFlip(target : Qubit) : Unit {
    body (...) {
        X(target);
    }
}
```

The keyword `operation` begins the operation definition, and is followed by the name; here, `BitFlip`.
Next, the type of the input is defined as `Qubit`, along with a name `target` for referring to the input within the new operation.
Similarly, the `Unit` defines that the operation's output is empty.
This is used similarly to `void` in C# and other imperative languages, and is equivalent to `unit` in F# and other functional languages.

> [!NOTE]
> We will explore this in more detail below, but each operation in Q# takes exactly one input and returns exactly one output.
> Multiple inputs and outputs are then represented using *tuples*, which collect multiple values together into a single value.
> Informally, we say that Q# is a "tuple-in tuple-out" language.
> Following this concept, `()` should then be read as the "empty" tuple.

Within the new operation, the keyword `body` is used to declare the sequence of statements that make up the new operation.
In the example above, the only statement is to call the @"microsoft.quantum.primitive.x" operation built-in to the Q# prelude.

Operations can also return more interesting types than `Unit`.
For instance, the @"microsoft.quantum.primitive.m" operation returns an output of type `(Result)`, representing having performed a measurement.
We can either pass the output from an operation to another operation, or can use it with the `let` keyword to define a new variable.
<!-- Link to UID for superdense conceptual and example documentation. -->
This allows for representing classical computation that interacts with quantum operations at a low level, such as in superdense coding:

```qsharp
operation Superdense(here : Qubit, there : Qubit) : (Result, Result) {
    body (...) {
        CNOT(there, here);
        H(there);

        let firstBit = M(there);
        let secondBit = M(here);

        return (firstBit, secondBit);
    }
}
```

If an operation does not return a value other than `()`, then it can also specify *variants* as well as a body, specifying how the operation acts when *adjointed* or *controlled*.
The adjoint variant of an operation specifies how it acts when run in reverse, while the controlled variant specifies how an operation acts when applied conditioned on the state of a quantum register.

> [!NOTE]
> Many operations in Q# represent unitary gates.
> If $U$ is the unitary gate represented by an operation `U`, then `(Adjoint U)` represents the unitary gate $U^\dagger$.

In both cases, the variant specification immediately follows the end of the body definition:

```qsharp
operation PrepareEntangledPair(here : Qubit, there : Qubit) : Unit {
    body (...) {
        H(here);
        CNOT(here, there);
    }

    adjoint auto;
    controlled auto;
    controlled adjoint auto;
}
```

Very often, variant specifications will consist of the keyword `auto`, indicating that the compiler should determine how to generate the variant definition.
If the compiler cannot generate a definition automatically, or if a more efficient implementation can be given, then a variant may also be manually defined.
We will see examples of this below in [Higher-Order Control Flow](xref:microsoft.quantum.concepts.control-flow).

To call a variant of an operation, use the `Adjoint` or `Controlled` keywords.
For example, the superdense coding example above can be written more compactly by using the adjoint of `PrepareEntangledPair` to transform the entangled state back into an unentangled pair of qubits:

```qsharp
operation Superdense(here : Qubit, there : Qubit) : (Result, Result) {
    body (...) {
        Adjoint PrepareEntangledPair(there, here);

        let firstBit = M(there);
        let secondBit = M(here);

        return (firstBit, secondBit);
    }
}
```

There are a number of important limitations to consider when designing operations for use with variants.
Most critically, an operation which uses the output value of any other operation cannot use the `auto` keyword to specify variants, as it is ambiguous how to reorder the statements in such an operation to obtain the same effect.


## Defining New Functions ##

Q# also allows for defining *functions*, distinct from operations in that they are not allowed to have any effects beyond calculating an output value.
In particular, functions cannot call operations, act on qubits, sample random numbers, or otherwise depend on state beyond the input value to a function.
As a consequence, Q# functions are *pure*, in that they always map the same input values to the same output values.
This allows the Q# compiler to safely reorder how and when functions are called when generating operation variants.

Defining a function works similarly to defining an operation, except that statements are placed directly within the function, and do not need to be wrapped in a `body` declaration.
For instance:

```qsharp
function Square(x : Double) : (Double) {
    return x * x;
}
```
Whenever it is possible to do so, it is helpful to write out classical logic in terms of functions rather than operations, so that it can be more readily used from within operations.
If we had written `Square` as an operation, for example, then the compiler would not have been able to guarantee that calling it with the same input would consistently produce the same outputs.
This is especially critical when considering operation variants.

To underscore the difference between functions and operations, consider the problem of classically sampling a random number from within a Q# operation:

```qsharp
operation U(target : Qubit) : Unit {
    body (...) {
        let angle = RandomReal()
        Rz(angle, target)
    }
}
```

Each time that `U` is called, it will have a different action on `target`.
In particular, the compiler cannot guarantee that if we added an `Adjoint auto` statement to `U`, then `U(target); Adjoint U(target);` acts as identity (that is, as a no-op).
This violates the definition of the adjoint that we saw in [Vectors and Matrices](xref:microsoft.quantum.concepts.vectors), such that allowing `Adjoint auto` in an operation where we have called the operation @"microsoft.quantum.canon.randomreal" would break the guarantees provided by the compiler; @"microsoft.quantum.canon.randomreal" is an operation for which no adjoint or controlled version exists.

On the other hand, allowing function calls such as `Square` is safe, in that the compiler can be assured that it only needs to preserve the input to `Square` in order to keep its output stable.
Thus, isolating as much classical logic as possible into functions makes it easy to reuse that logic in other functions and operations alike.

## Control Flow ##

Within an operation or function, each statement executes in order, similar to in most common imperative classical languages.
This flow of control can be modified, however, in three distinct ways:

- `if` Statements
- `for` Loops
- `repeat`-`until` Loops

We defer discussion of the latter until we discuss [Repeat Until Sucess (RUS)](xref:microsoft.quantum.techniques.qubits#measurements) circuits.
The `if` and `for` control flow constructs, however, proceed in a familiar sense to most classical programming languages.
In particular, an `if` statement can take a condition, may be followed by one or more `elif` statements, and may end with an `else`:

```qsharp
if (pauli == PauliX) {
    X(qubit);
} elif (pauli == PauliY) {
    Y(qubit);
} elif (pauli == PauliZ) {
    Z(qubit);
} else {
    fail "Cannot use PauliI here.";
}
```

Similarly, `for` loops indicate iteration over a range of integers:

```qsharp
for (idxQubit in 0..nQubits - 1) {
    // Do something to idxQubit...
}
```

Importantly, `for` loops can even be used in operations which declare `adjoint auto` variants, in which case the adjoint of a `for` loop reverses the direction and takes the adjoint of each iteration.
This follows the "shoes-and-socks" principle: if you wish to undo putting on socks and then shoes, you must undo putting on shoes and then undo putting on socks.
It works decidedly less well to try and take your socks off while you're still wearing your shoes!

## Operations and Functions as First-Class Values ##

One critical technique for reasoning about control flow and classical logic using functions rather than operations is to utilize that operations and functions in Q# are *first-class*.
That is, they are each values in the language in their own right.
For instance, the following is perfectly valid Q# code, if a little indirect:

```qsharp
operation FirstClassExample(target : Qubit) : Unit {
    body (...) {
        let ourH = H;
        ourH(target);
    }
}
```

The value of the variable `ourH` in the snippet above is then the operation @"microsoft.quantum.primitive.h", such that we can call that value like any other operation.
This allows us to write operations that take operations as a part of their input, forming higher-order control flow concepts.
For instance, we could imagine wanting to "square" an operation by applying it twice to the same target qubit.

```qsharp
operation ApplyTwice(op : (Qubit => Unit), target : Qubit) : Unit {
    body (...) {
        op(target);
        op(target);
    }
}
```

In this example, the `=>` arrow that appears in the type `((Qubit) => ())` denotes that the input field `op` is an operation which takes as its input the type `(Qubit)` and produces an empty tuple `()` as its output.
Optionally, we can specify that an operation type supports either or both variants by specifying variants after the output type, as in `((Qubit) => () : Adjoint)`.
We will explore this further below, when we discuss types in Q# more generally.

For now, though, we emphasize that we can also return operations as a part of outputs, such that we can isolate some kinds of classical conditional logic as a classical function which returns a description of a quantum program in the form of an operation.
As a simple example, consider the teleportation example, in which the party receiving a two-bit classical message needs to use the message to decode their qubit into the proper teleported state.
We could write this in terms of a function which takes those two classical bits and returns the proper decoding operation.

```qsharp
function TeleporationDecoderForMessage(hereBit : Result, thereBit : Result)
        : (Qubit => Unit : Adjoint, Controlled)
{
    if (hereBit == Zero && thereBit == Zero) {
        return I;
    } elif (hereBit == One && thereBit == Zero) {
        return X;
    } elif (hereBit == Zero && thereBit == One) {
        return Z;
    } else {
        return Y;
    }
}
```

This new function is indeed a function, in that if we call it with the same values of `hereBit` and `thereBit`, we will always get back the same operation.
Thus, the decoder can be safely run inside operations without having to reason about how the decoding logic interacts with the definitions of the different operation variants.
That is, we have isolated the classical logic inside a function, guaranteeing to the compiler that the function call can be reordered with impunity so long as the input is preserved.

We can also treat functions as first-class values, as we will see in more detail when we discuss [operations and function types](#operation-and-function-types).

## Partially Applying Operations and Functions ##

We can do significantly more with functions that return operations by using *partial application*, in which we can provide one or more parts of the input to a function or operation without actually calling it.
For example, recalling the `ApplyTwice` example above, we can indicate that we don't want to specify which qubit the input operation should apply to right away:

```qsharp
operation PartialApplicationExample(op : (Qubit => Unit), target : Qubit) : Unit {
    body (...) {
        let twiceOp = ApplyTwice(op, _);
        twiceOp(target);
    }
}
```

In this case, the local variable `twiceOp` holds the partially applied operation `ApplyTwice(op, _)`, where parts of the input that have not yet been specified are indicated by `_`.
When we actually call `twiceOp` in the next line, we pass as input to the partially applied operation all of the remaining parts of the input to the original operation.
Thus, the above snippet is effectively identical to having called `ApplyTwice(op, target)` directly, save for that we have introduced a new local variable that allows us to delay the call while providing some parts of the input.

Since an operation that has been partially applied is not actually called until its entire input has been provided, we can safely partially apply operations even from within functions.

```qsharp
function SquareOperation(op : (Qubit => Unit)) : (Qubit => Unit) {
    return ApplyTwice(op, _);
}
```

In principle, the classical logic within `SquareOperation` could have been much more involved, but it is still isolated from the rest of an operation by the guarantees that the compiler can offer about functions.
This approach will be used throughout the Q# standard library for expressing classical control flow in a way that can be readily used within quantum programs.

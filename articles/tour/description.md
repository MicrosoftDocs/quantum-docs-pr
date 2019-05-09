---
title: Description of Q#
description: Q# description
author: MikeDodaro
ms.author: Cathy.Palmer@microsoft.com
uid: microsoft.quantum.tour.description
ms.date: 05/02/2019
ms.topic: article
---

# Q# syntax and logic gates

The following code shows a Q# operation.  The term `operation` is applied to Q# code blocks that resemble functions in C#. Parameters of the operation are listed by name and type. In this example the name `qs` refers to an array of quibits. The parameter `oracle` is like a pointer to function. Following the colon, the `Adjoint` keyword specifies autogeneration of code that reverses the effect of the operation.  The return value in this case is void according to the `Unit` keyword.

The body of the operation includes a `for` loop similar to C# syntax.  The logic gate `H` sets a quibit to one of the nonbinary probability states, where the result depends on the starting value of the quibit.

````
operation ApproximateQFT (a: Int, qs: BigEndian, oracle: (BigEndian => Unit) : Adjoint) : Unit {
  body(...) {
    let nQubits = Length(qs!);

    for (i in 0 .. (nQubits - 1)) {
      for (j in 0..(i-1)) {
        if ((i-j) < a) {
          (Controlled R1Frac)([qs![i]], (1, i-j, qs![j]));
        }
      }

      H(qs![i]);
    }

    oracle(qs);
  }

  adjoint invert;
}

````

## Type system and generic classes
Q# is a strongly typed language.  Q# supports design of generic classes and methods that defer the specification of one or more types until the class or method is declared and instantiated by client code.

## Functonal programming concepts
Q# uses concepts from functional programming.

### Immutable or mutable
Objects declared in Q# are immutable by default.  In the statement `let nQubits = Length(qs!);` from the previous example, the `let` keyword creates an immutable array of quibits.  To declare a variable that can be changed, use the `mutable` keyword.  Immutablity is useful in autogeneration of adjoint operations that reverse the results of an operation.

### First class functions
Q# operations and functions are first-class objects.  Functions can be used as arguments to other functions, returned as values, assigned to variables, or stored in data structures.

### Partial application
Q# operations and functions can be called without supplying all the parameters of their declarations.  The object returned from a partially applied function can be called again, which will apply a new parameter value to the previous result.  For example, the following code adds 1 + 2 to output 3.
````
    let add x y = x + y
    let r = add 1 2;
````
The following code partially applies `add` to get the same result.
````
    let add x y = x + y
    let partialAdd = add 1
    let r = partialAdd 2
````

### Functors
The Q# language provides autogenertion of useful variations on an operation.  An operation has a body section, which contains the implementation of the operation. An operation may also have adjoint, controlled, and controlled adjoint sections. These are used to specify specific variants of appropriate operations.

### Resource management
Q# objects can be created in `using` blocks that allocate them and release the memory they use at the end of the block.

Q# can use the borrowing mechanism to allocate qubits as scratch space during a computation. These qubits are generally not in a clean state, that is, they are not necessarily initialized in a known state such as `|0⟩`.  These cubits may be "dirty" in their unknown state or may be entangled with other parts of the quantum computer's memory. 

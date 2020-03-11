---
title: Working with qubits
description: fill description
author: gillenhaalb
ms.author: a-gibec@microsoft.com
ms.date: 03/05/2020
ms.topic: article
uid: microsoft.quantum.guide.using.qubits
---

# Working with qubits

# from 'Statements'
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

---
uid: microsoft.quantum.standardlibsintro
---

# Q# standard libraries #

Q# is supported by a range of different useful operations, functions, and user-defined types that comprise the Q# *standard library*.
The Q# standard library is split into two main parts:

- **The prelude**: operations and functions defined as a part of the target machine and compiler, typically in classical native .NET code.
  In general, different target machines may have different implementations of the prelude appropriate to each system.
- **The canon**: operations and functions defined in Q# building on the logic defined in the prelude.
  The canon implementation is agnostic with respect to target machines.
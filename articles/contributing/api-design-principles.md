---
title: Q# API Design Principles
description: Q# API Design Principles
author: cgranade
ms.author: chgranad
ms.date: 10/12/2018
ms.topic: article
uid: microsoft.quantum.contributing.api-design
---

# Q# API Design Principles

## General Principles

- **DO** expose APIs that places the focus on quantum applications.
  - **DON'T** expose APIs that focus primarily on low-level
        implementation details.

- **DO** choose operation and function names that reflect the
    high-level structure of algorithms and applications.

- **DO** start each API design with sample use cases to ensure that
    APIs are intuitive to use.
  - **DO** ensure that each component of a public API has a
      corresponding use case, rather than trying to design the world
      from the get-go. Put differently, don't introduce public APIs in
      case they are useful, but make sure that each part of an API has
      a *concrete* example in which it will be useful. For example:
    - `ApplyToEachCA` can be used as `ApplyToEachCA(H, _)` to prepare
        registers in a uniform superposition state, a common task in
        many quantum algorithms. The same operation can also be used
        for many other tasks in preparation, numerics, and
        oracle-based algorithms.
  - **DO** brainstorm and workshop new API designs to double-check
      that they are intuitive and meet proposed use cases. For
      example:
    - Inspect current Q\# code to see how new API designs could
        simplify and clarify existing implementations.
    - Review proposed API designs with representatives of primary
        audiences.

- **DO** design APIs to support and encourage readable code.
  - **DO** ensure that code is readable by domain experts and
      non-experts alike.
  - **DO** place the focus on the effects of each operation and
      function within the high-level algorithm, using documentation to
      delve into implementation details as appropriate.

- **DO** design APIs to be stable and to provide forward
    compatibility.

- **DO** deprecate old APIs gracefully when breaking changes are
    required.

  - **DO** provide "shim" operations and functions that allow
      existing user code to operate correctly during deprecation. For
      example:
    - When renaming an operation called `EstimateExpectation` to
        `EstimateAverage`, introduce a new operation called
        `EstimateExpectation` that calls the original operation at
        its new name, so that existing code can continue to work
        correctly.
  - **DO** use the `@Deprecated` attribute to communicate
      deprecations to the user.
  - When renaming an operation or function, **DO** provide the new
      name as a string input to `@Deprecated`.
  - **DON'T** remove existing functions or operations without a
      deprecation period of at least six months for preview releases,
      or at least two years for supported releases.

- **DO** follow the common Q\# [style guide](xref:microsoft.quantum.contributing.style)
    whenever applicable.

## Functions and Operations

- **DO** ensure that every function and operation has a single
    well-defined purpose within the API.
  - **DON'T** expose functions and operations that perform multiple
      unrelated tasks.

- **DO** design functions and operations to compose well with other
    functions and operations, both in the same API and in previously
    existing libraries.

- **DO** design functions and operations to be as reusable as
    possible, and to anticipate future needs.

  - **DON'T** expose purely deterministic classical logic as an
      operation; **DO** expose purely deterministic classical logic as
      a function. For example:

    - A subroutine which squares its floating-point input can be
        written deterministically, and so should be exposed to the
        user as `Squared : Double -> Double` rather than as an
        operation `Square : Double => Double`. This allows for the
        subroutine to be called in more places (e.g.: inside of
        other functions), and provides useful optimization
        information to the compiler that can affect performance and
        optimizations.

    - `ForEach<'TInput, 'TOutput>('TInput => 'TOutput, 'TInput[]) => 'TOutput[]`
        and `Mapped<'TInput, 'TOutput>('TInput -> 'TOutput, 'TInput[]) -> 'TOutput[]`
        differ in the guarantees made with respect to
        determinism; both are useful in different circumstances.

    - API routines that transform the application of quantum
        operations can often be carried out in a deterministic
        fashion and hence can be made available as functions such as
        `CControlled<'T>(op : 'T => Unit) => ((Bool, 'T) => Unit)`.

    - **DO** generalize the input type as much as reasonable for each
        function and operation, using type parameters as needed. For
        example:
      - `ApplyToEach` has type `<'T>(('T => Unit), 'T[]) => Unit`
          rather than the specific type of its most common
          application, `((Qubit => Unit), Qubit[]) => Unit`.

- **DO** choose input and output types for functions and operations
    that are predictable, and that communicate the purpose of a
    callable.

  - **DO** use tuple types to logically group inputs and outputs
      that are only significant when considered together. Consider
      using a user-defined type in these cases. For example:

    - A function to output the local minima of another function
        may need to take bounds of a search interval as input, such
        that `LocalMinima(fn : (Double -> Double), (left : Double, right : Double)) : Double`
        may be an appropriate signature.

    - An operation to estimate a derivative of a machine learning
        classifier using the parameter shift technique may need to
        take both the shifted and unshifted parameter vectors as
        inputs. An input similar to
        `(unshifted : Double[], shifted : Double[])` may be appropriate in
        this case.

  - **DO** order items in input and output tuples consistently
      across different functions and operations. For example:

    - If considering two or functions or operations that each take
        a rotation angle and a target qubit as inputs, ensure that
        they are ordered the same in each input tuple. That is,
        prefer `ApplyRotation(angle : Double, target : Qubit) : Unit is Adj + Ctl`
        and `DelayedRotation(angle : Double, target : Qubit) : (Unit => Unit is Adj + Ctl)`
        to `ApplyRotation(target : Qubit, angle : Double) : Unit is Adj + Ctl`
        and `DelayedRotation(angle : Double, target : Qubit) : (Unit => Unit is Adj + Ctl)`.

- **DO** design functions and operations to work well with Q\#
    language features such as partial application.

  - **DO** order items in input tuples such that the most commonly
      applied inputs occur first (i.e.: so that partial application
      acts similarly to currying).

    - For example, an operation ApplyRotation that takes a
        floating-point number and a qubit as inputs may often be
        partially applied with the floating-point input first for
        use with operations that expect an input of type
        `Qubit => Unit`. Thus, a signature of
        `operation ApplyRotation(angle : Double, target : Qubit) : Unit is Adj + Ctl`
        would work most consistently with partial application.

    - Typically, this guidance means placing all classical data
        before all qubits in input tuples, but use good judgment and
        examine how your API is called in practice.

## User-Defined Types

- **DO** use user-defined types to help make APIs more expressive and
    convenient to use.

  - **DO** introduce new user-defined types to provide helpful
      shorthand for long and/or complicated types. For example:

    - In cases where an operation type with three qubit array
        inputs is commonly taken as an input or returned as an
        output, providing a UDT such as
        `newtype TimeDependentBlockEncoding = ((Qubit[], Qubit[], Qubit[]) => Unit is Adj + Ctl)`
        can help provide a useful shorthand.

    - **DO** introduce new user-defined types to indicate that a given
        base type should only be used in a very particular sense. For
        example:

      - An operation that should be interpreted specifically as an
          operation that encodes classical data into a quantum
          register may be appropriate to label with a user-defined
          type `newtype InputEncoder = (Apply : (Qubit[] => Unit))`.

    - **DO** introduce new user-defined types with named items that
        allow for future extensibility (e.g.: a results structure that
        may contain additional named items in the future). For example:

      - When an operation `TrainModel` exposes a large number of
          configuration options, exposing these options as a new
          `TrainingOptions` UDT and providing a new function
          `DefaultTrainingOptions : Unit -> TrainingOptions` allows
          users to override specific named items in TrainingOptions
          UDT values while still allowing library developers to add
          new UDT items as appropriate.

    - **DO** declare named items for new user-defined types in
        preference to requiring users to know the correct tuple
        deconstruction. For example:

      - When representing a complex number in its polar
          decomposition, prefer
          `newtype ComplexPolar = (Magnitude: Double, Argument: Double)` to
          `newtype ComplexPolar = (Double, Double)`.

- **DON'T** use user-defined types in ways that increase cognitive
    load or that require the user to learn additional concepts and
    nomenclature.

  - **DON'T** introduce user-defined types that require the user to
      make frequent use of the unwrap operator (`!`), or that commonly
      require multiple levels of unwrapping. Possible mitigation strategies
      include:

    - When exposing a user-defined type with a single item,
        consider defining a name for that item. For instance,
        consider `newtype Encoder = (Apply : (Qubit[] => Unit is Adj + Ctl))`
        in preference to `newtype Encoder = (Qubit[] => Unit is Adj + Ctl)`.

    - Ensuring that other functions and operations can accept
        "wrapped" UDT instances directly.

  - **DON'T** introduce new user-defined types that duplicate
      built-in types without providing additional expressiveness. For
      example:

    - A UDT `newtype QubitRegister = Qubit[]` provides no
        additional expressiveness over `Qubit[]`, and is thus harder
        to use with no discernable benefit.

    - A UDT `newtype LittleEndian = Qubit[]` documents how the
        underlying register is to be used and interpreted, and thus
        provides additional expressiveness over its base type.

  - **DON'T** introduce accessor functions unless strictly required;
      strongly prefer named items in this case. For example:

    - When introducing a UDT `newtype Complex = (Double, Double)`,
        prefer modifying the definition to
        `newtype Complex = (Real : Double, Imag : Double)` to introducing
        functions `GetReal : Complex -> Double` and
        `GetImag : Complex -> Double`.

## Namespaces and Organization

- **DO** choose namespace names that are predictable and that clearly
    communicate the purpose of functions, operations, and user-defined
    types in each namespace.

  - **DO** name namespaces as "Publisher.Product.DomainArea." For
      example:

    - Functions, operations, and UDTs published by Microsoft as a
        part of the quantum simulation feature of the Quantum
        Development Kit are placed in the
        "Microsoft.Quantum.Simulation" namespace.

    - For example, Microsoft.Quantum.Math represents a namespace
        published by Microsoft as part of the Quantum Development
        Kit pertaining to the mathematics domain area.

  - **DO** place operations, functions, and user-defined types used
      for specific functionality into a namespace that describes that
      functionality, even when that functionality is used across
      different problem domains. For example:

    - State preparation APIs published by Microsoft as a part of
        the Quantum Development Kit would be placed into
        "Microsoft.Quantum.Preparation," while quantum simulation
        APIs published by Microsoft as a part of the Quantum
        Development Kit would be placed into
        "Microsoft.Quantum.Simulation."

  - **DO** place operations, functions, and user-defined types used
      only within specific domains into namespaces indicating their
      domain of utility. If needed, use subnamespaces to indicate
      focused tasks within each domain-specific namespace. For
      example:

    - Quantum chemistry APIs published by Microsoft as a part of
        the Quantum Development Kit should be placed into
        "Microsoft.Quantum.Chemistry." Functionality specific to
        implementing the Jordan--Wigner decomposition may be placed
        in "Microsoft.Quantum.Chemistry.JordanWigner," so that the
        primary interface for the quantum chemistry domain area is
        not concerned with implementations.

- **DON'T** expose internal details related to implementation and
    testing along with your API.

  - Whenever reasonable, **DO** place all functions and operations
      needed to implement an API into the same namespace as the API
      being implemented, but marked with the "private" or "internal"
      keywords to indicate that they are not part of the public API
      surface for a library. Use a name beginning with an underscore
      (`_`) to visually distinguish private and internal operations and
      functions from public callables. For example:

    - The operation name `_Features` indicates a function that is
        private to a given namespace and assembly, and should be
        accompanied by either the "private" or "internal" keyword.

  - In the rare case that an extensive set of private functions or
    operations are needed to implement the API for a given
    namespace, **DO** place them in a new namespace matching the
    namespace being implemented and ending in ".Private."

  - **DO** place all unit tests into namespaces matching the
      namespace under test and ending in ".Tests."

## Naming Conventions and Vocabulary

- **DO** choose names and terminology that are clear, accessible, and
    readable across a diverse range of audiences, including both quantum
    novices and experts.

  - **DON'T** use discriminatory or exclusionary identifier names,
      nor terminology in API documentation comments.

  - **DO** use API documentation comments to provide relevant
      context, examples, and references, especially for more difficult
      concepts.

  - **DON'T** use identifier names that are unnecessarily esoteric,
      or that require significant quantum algorithms knowledge to
      read. For example:

    - Prefer a "amplitude amplification iteration" to "Grover
        iteration."

  - **DO** choose operations and function names that clearly
      communicate the intended effect of a callable, and not its
      implementation. Note that the implementation can and should be
      documented in API documentation comments. For example:

    - Prefer "estimate overlap" to "Hadamard test," as the latter
        communicates how the former is implemented.

  - **DO** use words in a consistent fashion across all Q\# APIs:

    - **Verbs:**

      - **Apply**: Apply a quantum operation or sequence of
          operations to one or more qubits, causing the state of
          those qubits to change in a coherent fashion. This verb
          is the most general verb in Q\# nomenclature, and
          **SHOULD NOT BE** used when a less general verb is more
          directly relevant.

      - **Assert**: Check that an assumption about the state of
          a target machine and its qubits holds, possibly by using
          unphysical resources. Operations using this verb should
          always be safely removable without affecting the
          functionality of libraries and executable programs. Note
          that unlike facts, assertions may in general depend on
          external state, such as the state of a qubit register,
          the execution environment or so forth. As dependency on
          external state is a kind of side effect, assertions must
          be exposed as operations rather than functions.

      - **Estimate**: Using one or more possibly repeated
          measurements, estimate a classical quantity from
          measurement results.

      - **Prepare**: Apply a quantum operation or sequence of
          operations to one or more qubits assumed to start in a
          particular initial state (typically \|0⋯​0⟩​), causing
          the state of those qubits to evolve to a desired end
          state. In general, acting on states other than the given
          starting state **MAY** result in an undefined unitary
          transformation, but **SHOULD** still preserve that an
          operation and its adjoint "cancel out" and apply a
          no-op.

      - **Measure**: Apply a quantum operation or sequence of
          operations to one or more qubits, reading classical data
          back out.

    - **Nouns**:

      - **Fact**: A Boolean condition which depends only on its
          inputs and not on the state of a target machine, its
        environment, or the state of the machine's qubits. By
        contrast with an assertion, a fact is only sensitive to
        the *values* provided to that fact. For example:

        - `EqualityFactI` represents an equality fact about two
          integer inputs; either the integers provided as
          input are equal to each other, or they are not,
          independent of any other program state.

      - **Options:** A UDT containing several named items that
          can act as "optional arguments" to a function or
          operation. For example:

        - The `TrainingOptions` UDT includes named items for
          learning rate, minibatch size, and other
          configurable parameters for ML training.

    - **Prepositions:** In some cases, prepositions can be used to
        further disambiguate or clarify the roles of nouns and verbs
        in function and operation names. Care should be taken to do
        so sparingly and consistently, however.

      - **As:** Represents that a function's input and output
          represent the same information, but that the output
          represents that information **as** an *X* instead of its
          original representation. This is especially common for
          type conversion functions. For example, IntAsDouble(2)
          indicates that both the input (2) and the output (2.0)
          represent qualitatively the same information, but using
          different Q\# data types to do so.

      - **From:** To ensure consistency, this preposition
          **SHOULD NOT** be used to indicate type conversion
          functions or any other case where **As** is appropriate.

      - **To:** This preposition **SHOULD NOT** be used, as to
          avoid confusion with its usage as a verb in many
          programming languages.

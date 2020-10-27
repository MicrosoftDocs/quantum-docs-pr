---
title: Q# API Design Principles
description: Q# API Design Principles
author: cgranade
ms.author: chgranad
ms.date: 3/9/2020
ms.topic: article
uid: microsoft.quantum.contributing.api-design
no-loc: ['Q#', '$$v']
---

# Q# API Design Principles

## Introduction

As a language and as a platform, Q# empowers users to write, run, understand, and explore quantum applications.
In order to empower users, when we design Q# libraries, we follow a set of API design principles to guide our designs and to help us make usable libraries for the the quantum development community.
This article lists these principles, and gives examples to help guide how to apply them when designing Q# APIs.

> [!TIP]
> This is a fairly detailed document that's intended to help guide library development and in-depth library contributions.
> You'll probably find it most useful if you're writing your own libraries in Q#, or if you're contributing larger features to the [Q# libraries repository](https://github.com/microsoft/QuantumLibraries).
>
> On the other hand, if you're looking to learn how to contribute to the Quantum Development Kit more generally, we suggest starting with the [contribution guide](xref:microsoft.quantum.contributing).
> If you're looking for more general information about how we recommend formatting your Q# code, you may be interested in checking out the [style guide](xref:microsoft.quantum.contributing.style).

## General Principles

**Key principle:** Expose APIs that places the focus on quantum applications.

- ✅ **DO** choose operation and function names that reflect the
    high-level structure of algorithms and applications.
- ⛔️ **DON'T** expose APIs that focus primarily on low-level
    implementation details.

**Key principle:** Start each API design with sample use cases to ensure that
    APIs are intuitive to use.

- ✅ **DO** ensure that each component of a public API has a
    corresponding use case, rather than trying to design for all possible uses from the start.
    Put differently, don't introduce public APIs in
    case they are useful, but make sure that each part of an API has
    a *concrete* example in which it will be useful.

  *Examples:*
  - @"microsoft.quantum.canon.applytoeachca" can be used as `ApplyToEachCA(H, _)` to prepare
      registers in a uniform superposition state, a common task in
      many quantum algorithms. The same operation can also be used
      for many other tasks in preparation, numerics, and
      oracle-based algorithms.

- ✅ **DO** brainstorm and workshop new API designs to double-check
    that they are intuitive and meet proposed use cases.

  *Examples:*
  - Inspect current Q\# code to see how new API designs could
      simplify and clarify existing implementations.
  - Review proposed API designs with representatives of primary
      audiences.

**Key principle:** Design APIs to support and encourage readable code.

- ✅ **DO** ensure that code is readable by domain experts and
    non-experts alike.
- ✅ **DO** place the focus on the effects of each operation and
    function within the high-level algorithm, using documentation to
    delve into implementation details as appropriate.
- ✅ **DO** follow the common [Q\# style guide](xref:microsoft.quantum.contributing.style)
    whenever applicable.

**Key principle:** Design APIs to be stable and to provide forward
    compatibility.

- ✅ **DO** deprecate old APIs gracefully when breaking changes are
    required.

- ✅ **DO** provide "shim" operations and functions that allow
    existing user code to operate correctly during deprecation.

  *Examples:*
  - When renaming an operation called `EstimateExpectation` to
      `EstimateAverage`, introduce a new operation called
      `EstimateExpectation` that calls the original operation at
      its new name, so that existing code can continue to work
      correctly.

- ✅ **DO** use the @"microsoft.quantum.core.deprecated" attribute to communicate deprecations to the user.

- ✅ When renaming an operation or function, **DO** provide the new
    name as a string input to `@Deprecated`.

- ⛔️ **DON'T** remove existing functions or operations without a
    deprecation period of at least six months for preview releases,
    or at least two years for supported releases.

## Functions and Operations

**Key principle:** ensure that every function and operation has a single well-defined purpose within the API.

- ⛔️ **DON'T** expose functions and operations that perform multiple
    unrelated tasks.

**Key principle:** design functions and operations to be as reusable as possible, and to anticipate future needs.

- ✅ **DO** design functions and operations to compose well with other
    functions and operations, both in the same API and in previously
    existing libraries.

  *Examples:*
  - The @"microsoft.quantum.canon.delay" operation makes minimal assumptions
      about its input, and thus can be used to delay applications of either
      operations across the Q# standard library or as defined by users.
  <!-- TODO: define bad example. -->

- ✅ **DO** expose purely deterministic classical logic as
    as functions rather than operations.

  *Examples:*
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

- ✅ **DO** generalize the input type as much as reasonable for each
    function and operation, using type parameters as needed.

  *Examples:*
  - `ApplyToEach` has type `<'T>(('T => Unit), 'T[]) => Unit`
      rather than the specific type of its most common
      application, `((Qubit => Unit), Qubit[]) => Unit`.

> [!TIP]
> It is important to anticipate future needs, but it is also important to solve concrete problems for your users.
> Acting on this key principle thus always requires careful consideration and balancing to avoid developing APIs "just in case."

**Key principle:** choose input and output types for functions and operations that are predictable, and that communicate the purpose of a callable.

- ✅ **DO** use tuple types to logically group inputs and outputs
    that are only significant when considered together. Consider
    using a user-defined type in these cases.

  *Examples:*
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

- ✅ **DO** order items in input and output tuples consistently
    across different functions and operations.

  *Examples:*
  - If considering two or functions or operations that each take
      a rotation angle and a target qubit as inputs, ensure that
      they are ordered the same in each input tuple. That is,
      prefer `ApplyRotation(angle : Double, target : Qubit) : Unit is Adj + Ctl`
      and `DelayedRotation(angle : Double, target : Qubit) : (Unit => Unit is Adj + Ctl)`
      to `ApplyRotation(target : Qubit, angle : Double) : Unit is Adj + Ctl`
      and `DelayedRotation(angle : Double, target : Qubit) : (Unit => Unit is Adj + Ctl)`.

**Key principle:** design functions and operations to work well with Q\# language features such as partial application.

- ✅ **DO** order items in input tuples such that the most commonly
    applied inputs occur first (i.e.: so that partial application
    acts similarly to currying).

  *Examples:*
  - An operation `ApplyRotation` that takes a
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

**Key principle:** use user-defined types to help make APIs more expressive and convenient to use.

- ✅ **DO** introduce new user-defined types to provide helpful
    shorthand for long and/or complicated types.

  *Examples:*
  - In cases where an operation type with three qubit array
      inputs is commonly taken as an input or returned as an
      output, providing a UDT such as
      `newtype TimeDependentBlockEncoding = ((Qubit[], Qubit[], Qubit[]) => Unit is Adj + Ctl)`
      can help provide a useful shorthand.

- ✅ **DO** introduce new user-defined types to indicate that a given
    base type should only be used in a very particular sense.

  *Examples:*
  - An operation that should be interpreted specifically as an
      operation that encodes classical data into a quantum
      register may be appropriate to label with a user-defined
      type `newtype InputEncoder = (Apply : (Qubit[] => Unit))`.

- ✅ **DO** introduce new user-defined types with named items that
    allow for future extensibility (e.g.: a results structure that
    may contain additional named items in the future).

  *Examples:*
  - When an operation `TrainModel` exposes a large number of
      configuration options, exposing these options as a new
      `TrainingOptions` UDT and providing a new function
      `DefaultTrainingOptions : Unit -> TrainingOptions` allows
      users to override specific named items in TrainingOptions
      UDT values while still allowing library developers to add
      new UDT items as appropriate.

- ✅ **DO** declare named items for new user-defined types in
    preference to requiring users to know the correct tuple
    deconstruction.

  *Examples:*
  - When representing a complex number in its polar
      decomposition, prefer
      `newtype ComplexPolar = (Magnitude: Double, Argument: Double)` to
      `newtype ComplexPolar = (Double, Double)`.

**Key principle:** use user-defined types in ways reduce  cognitive
    load and that don't require the user to learn additional concepts and nomenclature.

- ⛔️ **DON'T** introduce user-defined types that require the user to
    make frequent use of the unwrap operator (`!`), or that commonly
    require multiple levels of unwrapping. Possible mitigation strategies
    include:

  - When exposing a user-defined type with a single item,
      consider defining a name for that item. For instance,
      consider `newtype Encoder = (Apply : (Qubit[] => Unit is Adj + Ctl))`
      in preference to `newtype Encoder = (Qubit[] => Unit is Adj + Ctl)`.

  - Ensuring that other functions and operations can accept
      "wrapped" UDT instances directly.

- ⛔️ **DON'T** introduce new user-defined types that duplicate
    built-in types without providing additional expressiveness.

  *Examples:*
  - A UDT `newtype QubitRegister = Qubit[]` provides no
      additional expressiveness over `Qubit[]`, and is thus harder
      to use with no discernable benefit.
  - A UDT `newtype LittleEndian = Qubit[]` documents how the
      underlying register is to be used and interpreted, and thus
      provides additional expressiveness over its base type.

- ⛔️ **DON'T** introduce accessor functions unless strictly required;
    strongly prefer named items in this case.

  *Examples:*
  - When introducing a UDT `newtype Complex = (Double, Double)`,
      prefer modifying the definition to
      `newtype Complex = (Real : Double, Imag : Double)` to introducing
      functions `GetReal : Complex -> Double` and
      `GetImag : Complex -> Double`.

## Namespaces and Organization

**Key principle:** choose namespace names that are predictable and that clearly
    communicate the purpose of functions, operations, and user-defined
    types in each namespace.

- ✅ **DO** name namespaces as `Publisher.Product.DomainArea`.

  *Examples:*
  - Functions, operations, and UDTs published by Microsoft as a
      part of the quantum simulation feature of the Quantum
      Development Kit are placed in the
      `Microsoft.Quantum.Simulation` namespace.
  - `Microsoft.Quantum.Math` represents a namespace
      published by Microsoft as part of the Quantum Development
      Kit pertaining to the mathematics domain area.

- ✅ **DO** place operations, functions, and user-defined types used
    for specific functionality into a namespace that describes that
    functionality, even when that functionality is used across
    different problem domains.

  *Examples:*
  - State preparation APIs published by Microsoft as a part of
      the Quantum Development Kit would be placed into
      `Microsoft.Quantum.Preparation`.
  - Quantum simulation APIs published by Microsoft as a part of the Quantum
      Development Kit would be placed into
      `Microsoft.Quantum.Simulation`.

- ✅ **DO** place operations, functions, and user-defined types used
    only within specific domains into namespaces indicating their
    domain of utility. If needed, use subnamespaces to indicate
    focused tasks within each domain-specific namespace.

  *Examples:*
  - The quantum machine learning library published by Microsoft is largely
      placed into the @"microsoft.quantum.machinelearning" namespace, but example
      datasets are provided by the @"microsoft.quantum.machinelearning.datasets"
      namespace.
  - Quantum chemistry APIs published by Microsoft as a part of
      the Quantum Development Kit should be placed into
      `Microsoft.Quantum.Chemistry`. Functionality specific to
      implementing the Jordan--Wigner decomposition may be placed
      in `Microsoft.Quantum.Chemistry.JordanWigner`, so that the
      primary interface for the quantum chemistry domain area is
      not concerned with implementations.

**Key principle:** Use namespaces and access modifiers together to be
  intentional about the API surface exposed to users, and to hide internal
  details related to implementation and testing of your APIs.

- ✅ Whenever reasonable, **DO** place all functions and operations
    needed to implement an API into the same namespace as the API
    being implemented, but marked with the "private" or "internal"
    keywords to indicate that they are not part of the public API
    surface for a library. Use a name beginning with an underscore
    (`_`) to visually distinguish private and internal operations and
    functions from public callables.

  *Examples:*
  - The operation name `_Features` indicates a function that is
      private to a given namespace and assembly, and should be
      accompanied by either the `internal` keyword.

- ✅ In the rare case that an extensive set of private functions or
  operations are needed to implement the API for a given
  namespace, **DO** place them in a new namespace matching the
  namespace being implemented and ending in `.Private`.

- ✅ **DO** place all unit tests into namespaces matching the
      namespace under test and ending in `.Tests`.

## Naming Conventions and Vocabulary

**Key principle:** Choose names and terminology that are clear, accessible, and
    readable across a diverse range of audiences, including both quantum
    novices and experts.

- ⛔️ **DON'T** use discriminatory or exclusionary identifier names,
    nor terminology in API documentation comments.

- ✅ **DO** use API documentation comments to provide relevant
    context, examples, and references, especially for more difficult
    concepts.

- ⛔️ **DON'T** use identifier names that are unnecessarily esoteric,
    or that require significant quantum algorithms knowledge to
    read.

  *Examples:*
  - Prefer "amplitude amplification iteration" to "Grover
      iteration."

- ✅ **DO** choose operations and function names that clearly
    communicate the intended effect of a callable, and not its
    implementation. Note that the implementation can and should be
    documented in [API documentation comments](xref:microsoft.quantum.guide.filestructure#documentation-comments).

  *Examples:*
  - Prefer "estimate overlap" to "Hadamard test," as the latter
      communicates how the former is implemented.

- ✅ **DO** use words in a consistent fashion across all Q\# APIs:

  - **Verbs:**

    - **Assert**: Check that an assumption about the state of
        a target machine and its qubits holds, possibly by using
        unphysical resources. Operations using this verb should
        always be safely removable without affecting the
        functionality of libraries and executable programs. Note
        that unlike facts, assertions may, in general, depend on
        external state, such as the state of a qubit register,
        the run environment or so forth. As dependency on
        external state is a kind of side effect, assertions must
        be exposed as operations rather than functions.

    - **Estimate**: Using one or more possibly repeated
        measurements, estimate a classical quantity from
        measurement results.

      *Examples:*
      - @"microsoft.quantum.characterization.estimatefrequency"
      - @"microsoft.quantum.characterization.estimateoverlapbetweenstates"

    - **Prepare**: Apply a quantum operation or sequence of
        operations to one or more qubits assumed to start in a
        particular initial state (typically $\ket{00\cdots 0}$​), causing
        the state of those qubits to evolve to a desired end
        state. In general, acting on states other than the given
        starting state **MAY** result in an undefined unitary
        transformation, but **SHOULD** still preserve that an
        operation and its adjoint "cancel out" and apply a
        no-op.

      *Examples:*
      - @"microsoft.quantum.preparation.preparearbitrarystate"
      - @"microsoft.quantum.preparation.prepareuniformsuperposition"

    - **Measure**: Apply a quantum operation or sequence of
        operations to one or more qubits, reading classical data
        back out.

      *Examples:*
      - @"Microsoft.Quantum.Intrinsic.Measure"
      - @"microsoft.quantum.arithmetic.measurefxp"
      - @"microsoft.quantum.arithmetic.measureinteger"

    - **Apply**: Apply a quantum operation or sequence of
        operations to one or more qubits, causing the state of
        those qubits to change in a coherent fashion. This verb
        is the most general verb in Q\# nomenclature, and
        **SHOULD NOT BE** used when a more specific verb is more
        directly relevant.

  - **Nouns**:

    - **Fact**: A Boolean condition which depends only on its
        inputs and not on the state of a target machine, its
      environment, or the state of the machine's qubits. By
      contrast with an assertion, a fact is only sensitive to
      the *values* provided to that fact. For example:

      *Examples:*
      - @"microsoft.quantum.diagnostics.equalityfacti":
        represents an equality fact about two
        integer inputs; either the integers provided as
        input are equal to each other, or they are not,
        independent of any other program state.

    - **Options:** A UDT containing several named items that
        can act as "optional arguments" to a function or
        operation. For example:

      *Examples:*
      - The @"microsoft.quantum.machinelearning.trainingoptions" UDT includes
        named items for learning rate, minibatch size, and other
        configurable parameters for ML training.

  - **Adjectives**:

    - ⛔️ **New**: This adjective **SHOULD NOT** be used, as to avoid confusion
        with its usage as a verb in many
        programming languages (e.g.: C++, C#, Java, TypeScript, PowerShell).

  - **Prepositions:** In some cases, prepositions can be used to
      further disambiguate or clarify the roles of nouns and verbs
      in function and operation names. Care should be taken to do
      so sparingly and consistently, however.

    - **As:** Represents that a function's input and output
        represent the same information, but that the output
        represents that information **as** an *X* instead of its
        original representation. This is especially common for
        type conversion functions.

      *Examples:*
      - `IntAsDouble(2)`
          indicates that both the input (`2`) and the output (`2.0`)
          represent qualitatively the same information, but using
          different Q\# data types to do so.

    - **From:** To ensure consistency, this preposition
        **SHOULD NOT** be used to indicate type conversion
        functions or any other case where **As** is appropriate.

    - ⛔️ **To:** This preposition **SHOULD NOT** be used, as to
        avoid confusion with its usage as a verb in many
        programming languages.

---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: "Quantum Development Techniques: Testing and Debugging | Microsoft Docs"
description: 115-145 characters including spaces. Edit the intro para describing article intent to fit here. This abstract displays in the search result.
services: service-name-with-dashes-AZURE-ONLY 
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: tcNickolas
ms.author: mamykhai@microsoft.com
ms.date: 11/20/2017
ms.topic: article-type-from-white-list
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# ms.service: service-name-from-white-list
# product-name-from-white-list

# Optional fields. Don't forget to remove # if you need a field.
# ms.custom: can-be-multiple-comma-separated
# ms.devlang:devlang-from-white-list
# ms.suite: 
# ms.tgt_pltfrm:
# ms.reviewer:
# manager: MSFT-alias-manager-or-PM-counterpart
---

# Testing and Debugging


## Unit Tests

Q# supports creating unit tests which can be executed as xUnit tests.

### Creating Test Project

Open Visual Studio 2017. Go to the `File` menu and select `New` > `Project...`.
In the project template explorer, under `Installed` > `Visual C#`,
select the `Q# Test Project` template. This will create a project with two files open. 

`Tests.qs` holds Q# unit tests. Tests are operations with signature `() => ()`; they don't need to be specially annotated, and will be grouped in suites in C# code. Initially this file contains one sample unit test `AllocateQubitTest` which checks that a newly allocated qubit is in `|0>` state and prints a message.

`TestSuiteRunner.cs` holds test suite runners - methods annotated with `OperationDriver` which define what subset of tests is to be executed as part of this test suite and how to execute these tests. Initially this file contains one sample test suite `TestTarget` which runs all tests in the same namespace as it is which have names ending with `...Test` on `QuantumSimulator`. 

<!-- TODO: describe parameters of OperationDriver -->

### Running Q# Unit Tests

As a one-time setup, go to `Test` menu and select `Test Settings` > `Default Processor Architecture` > `X64`.

Build the project, go to `Test` menu and select `Windows` > `Test Explorer`. `AllocateQubitTest` will show up in the list of tests in `Not Run Tests` group. Select `Run All` or run this individual test, and it should pass!

<!-- TODO: describe running from command line? -->

## Logging and Assertions

One important consequence of the fact that functions in Q# are deterministic is that a function whose output type is the empty tuple `()` cannot ever be observed from within a Q# program.
That is, a target machine can choose not to execute any function which returns `()` with the guarantee that this omission will not modify the behavior of any following Q# code.
This makes functions a useful tool for embedding assertions and debugging logic.

### Logging

The primitive function @"microsoft.quantum.primitive.message" has type `String -> ()`, and allows to emit diagnostic messages.
That a target machine observes the contents of the input to `Message` does not imply any consequence that is observable from within Q#.
A target machine may thus omit calls to `Message` by the same logic.

`onLog` action of `QuantumSimulator` can be used to define action(s) performed when Q# code calls `Message`. By default logged messages are printed to standard output.

When defining a unit test suite, the logged messages can be directed to the test output. When a project is created from Q# Test Project template, this redirection is pre-configured for the suite created by default as follows:

```
using (var sim = new QuantumSimulator())
{
    // OnLog defines action(s) performed when Q# test calls operation Message
    sim.OnLog += (msg) => { output.WriteLine(msg); };
    op.TestOperationRunner(sim);
}
```

After you execute a test in Test Explorer and click on the test, a panel will apprear with information about test execution: Passed/Failed status, elapsed time and an "Output" link. If you click on it, test output will open in a new window.

### Assertions

The same logic can be applied to implementing assertions. Let's consider a simple example:

```
function AssertPositive(value : Double) : () {
    if (value <= 0) {
        fail "Expected a positive number.";
    }
}
```

Here, the keyword `fail` indicates that the computation should not proceed, raising an exception in the target machine running the Q# program.
By definition, a failure of this kind cannot be observed from within Q#, as no further Q# code is run after a `fail` statement is reached.
Thus, if we proceed past a call to `AssertPositive`, we can be assured by the [anthropic principle](https://www.scottaaronson.com/democritus/lec17.html) that its input was positive, even though we were not able to directly observe this fact.

Building on these ideas, the prelude offers two especially useful assertions, both modeled as functions onto `()`: @"microsoft.quantum.primitive.assert" and @"microsoft.quantum.primitive.assertprob".
These assertions each take a Pauli operator describing a particular measurement of interest, a register on which a measurement is to be performed, and a hypothetical outcome.
On target machines which work by simulation, we are not bound by the [no-cloning theorm](TODO: link to glossary), and can perform such measurements without disturbing the register passed to such assertions.
A simulator can then, similar to the `AssertPositive` function above, abort computation if the hypothetical outcome would not be observed in practice:

<!-- TODO: check that this code is correct. -->

```
using (register = Qubit[1]) {
    H(register[0]);
    Assert([PauliX], register, Zero);
    // Even though we do not have access to states in Q#,
    // we know by the anthropic principle that the state
    // of register at this point is |+〉.
}
```

On actual hardware, where we are constrained by physics, we of course cannot perform such counterfactual measurements, and so the `Assert` and `AssertProb` functions simply return `()` with no other effect.

@"microsoft.quantum.canon" namespace provides several more functions of `Assert` family which allow to check more advanced conditions. They are discussed in detail in [Q# Standard Libraries: Testing and Debugging]() section.

## Debugging

Q# supports a subset of standard Visual Studio debugging capabilities: [setting line breakpoints](https://docs.microsoft.com/en-us/visualstudio/debugger/using-breakpoints), [stepping through code using F10](https://docs.microsoft.com/en-us/visualstudio/debugger/navigating-through-code-with-the-debugger) and [inspecting values of classic variables](https://docs.microsoft.com/en-us/visualstudio/debugger/autos-and-locals-windows) during code execution on simulator.

<!-- TODO: how much detail we need to provide? Are links to standard Visual Studio tools sufficient? -->

### Set Breakpoints 

### Navigate Code

### Inspect Classic Variables


---
title: Contributing code | Microsoft Docs
description: Contributing code
author: cgranade
ms.author: chgranad
ms.date: 10/12/2018
ms.topic: article
uid: microsoft.quantum.contributing.code
---

# Contributing Code #

In addition to reporting issues and improving documentation, contributing code to the Quantum Development Kit can be a very direct way to help your peers in the quantum programming community.
By contributing code, you can help to fix issues, provide new examples, make existing libraries easier to use, or even add entirely new features.

In this guide, we'll detail a bit of what we look for when we review pull requests to help your contribution do the most good.

## What We Look For ##

An ideal code contribution builds on the existing work in a Quantum Development Kit repository to fix issues, expand existing features, or to add new features that are within the scope of a repository.
When we accept a code contribution, it becomes a part of the Quantum Development Kit itself, such that new features will be released, maintained, and developed in the same way as the rest of the Quantum Development Kit.
Thus, it is helpful when functionality added by a contribution is well-tested and is documented.

### Unit Tests ###

The Q# functions, operations, and user-defined types that make up libraries such as the canon are automatically tested as a part of development on the [**Microsoft/QuantumLibraries**](https://github.com/Microsoft/QuantumLibraries/) repository.
When a new pull request is opened, for instance, our [Azure Pipelines](https://azure.microsoft.com/services/devops/pipelines/) configuration will check that the changes in the pull request do not break any existing functionality that the quantum programming community depends on.

With the latest Q# version, unit test are defined using the `@Test("QuantumSimulator")` attribute. The argument may be either "QuantumSimulator", "ToffoliSimulator", "TraceSimulator", or any fully qualified name specifying the execution target. Several attributes defining different execution targets may be attached to the same callable. 
Some of our tests still use the deprecated [Microsoft.Quantum.Xunit](https://www.nuget.org/packages/Microsoft.Quantum.Xunit/) package that exposes all Q# functions and operations ending in `Test` to the [xUnit](https://xunit.github.io/) framework. This package is no longer needed for defining unit tests. 

The following function is used to ensure that the <xref:microsoft.quantum.canon.fst> and <xref:microsoft.quantum.canon.snd> functions both return the right outputs in a representative example.
If the output of `Fst` or `Snd` is incorrect, the `fail` statement is used to cause the test to fail.

```qsharp
@Test("QuantumSimulator")
function PairTest () : Unit {
    let pair = (12, PauliZ);

    if (Fst(pair) != 12) {
        let actual = Fst(pair);
        fail $"Expected 12, actual {actual}.";
    }

    if (Snd(pair) != PauliZ) {
        let actual = Snd(pair);
        fail $"Expected PauliZ, actual {actual}.";
    }
}
```

More complicated conditions can be checked using the techniques in the [testing section](xref:microsoft.quantum.libraries.diagnostics) of the standard libraries guide.
For instance, the following test checks that `H(q); X(q); H(q);` as called by <xref:microsoft.quantum.canon.applywith> does the same thing as `Z(q)`.

```qsharp
@Test("QuantumSimulator")
operation WithTest () : Unit {
    let actual = ApplyWith(H, X, _);
    let expected = Z;
    AssertOperationsEqualReferenced(ApplyToEach(actual, _), ApplyToEachA(expected, _), 4);
}
```

When adding new features, it's a good idea to also add new tests to make sure that your contribution does what it's supposed to.
This helps the rest of the community to maintain and develop your feature, and in particular helps other developers know that they can rely on your feature.

> [!NOTE]
> This works the other way around, too!
> If there's an existing feature that's missing some tests, helping us add test coverage would make a great contribution to the community.

Locally, unit tests can be run using the Visual Studio Test Explorer or the `dotnet test` command, so that you can check your contribution before opening up a pull request.

<!-- TODO:
### Comments and Documentation ###

### Citations and References ### -->

## When We'll Reject a Pull Request ##

Sometimes, we'll reject the pull request for a contribution.
If this happens to you, it doesn't mean that it's bad, as there's a number of reasons why we might not be able to accept a particular contribution.
Perhaps most commonly, a contribution to the quantum programming community is a really good one, but the Quantum Development Kit repositories aren't the right place to develop it.
In such cases, we strongly encourage you to make your own repository --- part of the strength of the Quantum Development Kit is that it's easy to make and distribute your own libraries using GitHub and NuGet.org, the same way that we distribute the canon and chemistry libraries today.

At other times, we may reject a good contribution simply because we aren't yet ready to maintain and develop it.
It can be difficult to do everything, so we plan out what features we're best able to work on as a roadmap.
This can be another case where releasing a feature as a third-party library can make a lot of sense.
Alternatively, we may ask for your help in modifying a feature to better fit into our roadmap so that we can do the best work we can with it.

We'll also ask for changes to a pull request if it requires more documentation or unit tests to help us make use of it, or if it differs enough in style from the rest of the Q# libraries that it will make it harder for users to find your feature.
In these cases, we'll try to offer some advice in code reviews about what can be added or changed to make your contribution easier for us to include.

Finally, we cannot accept contributions that cause harm the quantum computing community, as outlined in the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
We want to ensure that contributions serve the entire quantum computing community, both in its current wonderful diversity, and in the future as it grows to become still more inclusive.
We appreciate your help in realizing this goal.

## Next steps ##

Thanks for helping to make the Quantum Development Kit a great resource for the entire quantum programming community!
To learn more, please continue with the following guide on Q# style.

> [!div class="nextstepaction"]
> [Learn about Q# style guidelines](xref:microsoft.quantum.contributing.style)

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

In this guide, we'll describe what we look for when we review pull requests to help your contribution do the most good.

## What We Look For ##

An ideal code contribution builds on the existing work in a Quantum Development Kit repository to fix issues, expand existing features, or to add new features that are within the scope of a repository.  When we accept a code contribution, it becomes a part of the Quantum Development Kit itself, such that new features will be released, maintained, and developed in the same way as the rest of the Quantum Development Kit.  

It is helpful when functionality added by a contribution is well-tested and is documented. We may ask for changes if it requires more documentation or unit tests to help us make use of it, or changes if it differs enough in style from the rest of the Q# libraries that it will make it harder for users to find your feature.  In these cases, we'll try to offer some advice in code reviews about what can be added or changed to make your contribution easier for us to include.  We also may ask for your help in modifying a contribution to better fit into the Quantum Development Kit offering so that we can do the best work we can with it.

Sometimes, a contribution to the quantum programming community is a really good one, but the Quantum Development Kit is not the right place to publish it.  There's a number of reasons why we might not be able to accept a particular contribution.  We try to make sure that the Quantum Development Kit can be used on a variety of platforms, from Linux, to Windows, to MacOS.  We may not accept a contribution that perhaps may not interest a broad enough developer audience.  At other times, we may reject a good contribution simply because we aren't yet ready to maintain and develop it.  In these cases where we cannot accept the contribution, we strongly encourage you to make your own repository --- part of the strength of the Quantum Development Kit is that it's easy to make and distribute your own libraries using GitHub and NuGet.org, the same way that we distribute the canon and chemistry libraries today.  Releasing a feature as a third-party library can make a lot of sense.

Finally, we cannot accept contributions that cause harm the quantum computing community, as outlined in the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
We want to ensure that contributions serve the entire quantum computing community, both in its current wonderful diversity, and in the future as it grows to become still more inclusive.
We appreciate your help in realizing this goal.

## Next steps ##

Thanks for helping to make the Quantum Development Kit a great resource for the entire quantum programming community!
To learn more, please continue with the following guide on Q# style and then review the information below on documentation and unit testing your contribution.

<div class="nextstepaction">
[Learn about Q# style guidelines](xref:microsoft.quantum.contributing.style)
</div>

### Comments and Documentation ###

### Unit Tests ###

The Q# functions, operations, and user-defined types that make up libraries such as the canon are automatically tested as a part of development on the [**Microsoft/QuantumLibraries**](https://github.com/Microsoft/QuantumLibraries/) repository.
When a new pull request is opened, for instance, our [Azure Pipelines](https://azure.microsoft.com/services/devops/pipelines/) configuration will check that the changes in the pull request do not break any existing functionality that the quantum programming community depends on.
These tests are written using the [Microsoft.Quantum.Xunit](https://www.nuget.org/packages/Microsoft.Quantum.Xunit/) package, which exposes Q# functions and operations as tests for the [xUnit](https://xunit.github.io/) framework.

The [`Canon/tests/Canon.Tests.csproj`](https://github.com/Microsoft/QuantumLibraries/blob/master/Canon/tests/Canon.Tests.csproj) uses this xUnit integration to run any functions or operations ending in `Test`.
For instance, the following function is used to ensure that the <xref:microsoft.quantum.canon.fst> and <xref:microsoft.quantum.canon.snd> functions both return the right outputs in a representative example.
If the output of `Fst` or `Snd` is incorrect, the `fail` statement is used to cause the test to fail.

```qsharp
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

More complicated conditions can be checked using the techniques in the [testing section](xref:microsoft.quantum.libraries.standard.testing) of the standard libraries guide.
For instance, the following test checks that `H(q); X(q); H(q);` as called by <xref:microsoft.quantum.canon.with> does the same thing as `Z(q)`.

```qsharp
operation WithTest () : Unit {    
    let actual = With(H, X, _);
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


### Citations and References ###

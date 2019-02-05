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
These tests are written using the [Microsoft.Quantum.Xunit](https://www.nuget.org/packages/Microsoft.Quantum.Xunit/) package, which exposes Q# functions and operations as tests for the [Xunit](https://xunit.github.io/) framework.

The [`Canon/tests/Canon.Tests.csproj`](https://github.com/Microsoft/QuantumLibraries/blob/master/Canon/tests/Canon.Tests.csproj) uses this Xunit integration to run any functions or operations ending in `Test`.
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

More complicated conditions can be checked using the techniques in the [testing section](microsoft.quantum.libraries.standard.testing) of the standard libraries guide.
For instance, the following test checks that `H(q); X(q); H(q);` as called by <xref:microsoft.quantum.canon.with> does the same thing as `Z(q)`.

```qsharp
operation WithTest () : Unit {    
    let actual = With(H, X, _);
    let expected = Z;
    AssertOperationsEqualReferenced(ApplyToEach(actual, _), ApplyToEachA(expected, _), 4);
}
```

Locally, these tests can be run using the Visual Studio Test Explorer or the `dotnet test` command.


### Comments and Documentation ###

### Citations and References ###

## When We'll Reject a Pull Request ##

**TODO: when do we reject, and why?**

## Next steps ##

Thanks for helping to make the Quantum Development Kit a great resource for the entire quantum programming community!
To learn more, please continue with the following guide on Q# style.

<div class="nextstepaction">
[Learn about Q# style guidelines](xref:microsoft.quantum.contributing.style)
</div>

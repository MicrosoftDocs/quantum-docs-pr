---
title: Contributing samples to the Microsoft QDK
description: Learn how to contribute sample code to the Microsoft Quantum Development Kit (QDK).
author: cgranade
ms.author: chgranad
ms.date: 10/12/2018
ms.topic: contributor-guide
uid: microsoft.quantum.contributing.samples
no-loc: ['Q#', '$$v']
---

# Contributing Samples to the Quantum Development Kit

If you're interested in contributing code to the [samples repository](https://github.com/Microsoft/Quantum), thank you for making the quantum development community a better place!

## The Quantum Development Kit Samples Repository

To help you prepare your contribution to help out as much as possible, it's helpful to take a quick look at how the samples repository is laid out:

```plaintext
microsoft/Quantum
📁 samples/
  📁 algorithms/
    📁 chsh-game/
      📝 CHSHGame.csproj
      📝 Game.qs
      📝 Host.cs
      📝 host.py
      📝 README.md
     ⋮
  📁 arithmetic/
  📁 characterization/
  📁 chemistry/
   ⋮
```

That is, the samples in the [microsoft/Quantum repository](https://github.com/microsoft/Quantum) are broken down by subject area into different folders such as `algorithms/`, `arithmetic/`, or `characterization/`.
Within the folder for each subject area, each sample consists of a single folder that collects everything a user will need to explore and make use of that sample.

## How Samples are Structured

Looking at the files that make up each folder, let's dive into the [`algorithms/chsh-game/`](https://github.com/microsoft/Quantum/tree/main/samples/algorithms/chsh-game) sample.

| File              | Description                                                |
|-------------------|------------------------------------------------------------|
| `CHSHGame.csproj` | Q# project used to build the sample with the .NET Core SDK |
| `Game.qs`         | Q# operations and functions for the sample                 |
| `Host.cs`         | C# host program used to run the sample                     |
| `host.py`         | Python host program used to run the sample                 |
| `README.md`       | Documentation on what the sample does and how to use it    |

Not all samples will have the exact same set of files (e.g.: some samples may be C#-only, others may not have a Python host, or some samples may require auxillary data files to work).

## Anatomy of a Helpful README File

One especially important file, though, is the `README.md` file, as that's what users need to get started with your sample!

Each `README.md` should start with some metadata that helps docs.microsoft.com/samples find your contribution.

> [!div class="nextstepaction"]
> [See how the chsh-game sample is rendered](https://docs.microsoft.com/samples/microsoft/quantum/validating-quantum-mechanics/)

This metadata is provided as a [YAML header](https://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html#yaml-header) that indicates what languages your sample covers (typically, this will be `qsharp`, `csharp`, and `python`), and what products your sample covers (typically, just `qdk`).

:::code language="markdown" source="~/quantum/samples/algorithms/chsh-game/README.md" range="1-11":::

> [!IMPORTANT]
> The `page_type: sample` key in the header is required for your sample to appear at docs.microsoft.com/samples.
> Similarly, the `product` and `language` keys are critical for helping users to find and run your sample.

After that, it's helpful to give a short intro that says what your new sample does:

:::code language="markdown" source="~/quantum/samples/algorithms/chsh-game/README.md" range="13-21":::

Users of your sample will also appreciate knowing what they need to run it (e.g.: do users just need the Quantum Development Kit itself, or do they need additional software such as node.js?):

:::code language="markdown" source="~/quantum/samples/algorithms/chsh-game/README.md" range="23-25":::

With all that in place, you can tell users how to run your sample:

:::code language="markdown" source="~/quantum/samples/algorithms/chsh-game/README.md" range="27-50":::

Finally, it's helpful to tell users what each file in your sample does, and where they can go for more information:

:::code language="markdown" source="~/quantum/samples/algorithms/chsh-game/README.md" range="52-61":::

> [!WARNING]
> Make sure to use absolute URLs here, since your sample will appear at a different URL when rendered at docs.microsoft.com/samples!

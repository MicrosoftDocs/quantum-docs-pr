---
title: Contributing to the Quantum Development Kit | Microsoft Docs
description: Contributing to the Quantum Development Kit
author: cgranade
ms.author: chgranad
ms.date: 10/12/2018
ms.topic: article
uid: microsoft.quantum.contributing
---

# Contributing to the Quantum Development Kit #

The Quantum Development Kit is more than a collection of tools for writing quantum programs.
It's part of a broad community of people discovering quantum computing, performing research in quantum algorithms, developing new applications for quantum devices, and otherwise working to make the most out of the quantum programming.
As a member of that community, the Quantum Development Kit aims to offer quantum developers across a wide range of backgrounds with the features they need.
Your contributions to the Quantum Development Kit help in realizing that goal by improving the tools used by other quantum developers, how those tools are documented, and even by creating new features and functionality that helps make the entire quantum programming community a better place to discover and create.
We're very thankful for your kind contributions, and for the opportunity to work with you to make our community the best that it can be.

In this guide, we provide some advice on how to make your contribution as useful as possible to the broader quantum programming community.

## Building Community ##

The very first thing about making a contribution is to always keep in mind the community that you are contributing to.
By acting respectfully and professionally towards your peers in the quantum programming community and more broadly, you can help to make sure that your efforts build the best and most welcoming community possible.

As a part of that effort, all Quantum Development Kit projects have adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information, please see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## What Kinds of Contributions Help the Community? ##

There are lots of different ways to help the quantum programming community through your contributions.
In this guide, we'll focus on three ways that are especially relevant to the Quantum Development Kit.
All of these ways are critical to building a quantum community that empowers people.
That said, this is definitely not an exhaustive list — we encourage you to explore other ways to help the community build on the promise of quantum programming!

- **Reporting bugs.** The first step in fixing bugs and other kinds of problems is to identify them. If you've found a bug in the Quantum Development Kit, letting us know helps us fix it and make a better set of tools for the quantum programming community.
- **Improving documentation.** Any documentation set can always be better, can cover more details, be made more accessible.
- **Contributing code.** Of course, one of the most direct ways to contribute is by adding new code to the Quantum Development Kit.

These different kinds of contributions are all immensely valuable, and are greatly appreciated.
In the rest of the guide, we'll offer advice on how to make each kind of contribution.

## Where Do Contributions Go? ##

The Quantum Development Kit includes a number of different pieces that all work together to realize a platform for writing quantum programs.
Each of these different pieces finds its home on a different repository, so the one of the earlier things to sort out is where each contribution best belongs.

- [**Microsoft/Quantum**](): Samples and tools to help get started with the Quantum Development Kit.
- [**Microsoft/QuantumLibraries**](): Standard and domain-specific libraries for the Quantum Development Kit.
- [**Microsoft/QuantumKatas**](): Self-paced exercises to help learn more about quantum programming and the Q# language.
- [**MicrosoftDocs/quantum-docs-pr**](): Source code for the documentation published at https://docs.microsoft.com/quantum.

There are also a few other, more specialized repositories focusing on different events, or on auxillary functionality related to the Quantum Development Kit.

> [!NOTE]
> We unfortunately cannot accept code and documentation contributions on the [**Microsoft/QuantumNC**]() repository at this time, but we still very much appreciate bug reports.

## Reporting Bugs ##

If you think you've found a bug in a component of the Quantum Development Kit, we would very much appreciate a report.
After all, someone else may be struggling with the same issue as well; letting us know helps us to get to fixing it for everyone.
The first step in reporting a bug is to start by looking through the existing issues found on each repository, as it's very possible that someone else has reported the same problem.

If the issue has already been found before, it may be helpful to provide additional information or context that can help us to diagnose and solve the problem.
In that case, please feel free to participate in discussions on the issue.

If your bug hasn't been reported before, then we'd appreciate if you open a new issue on the repository for the component in question.
When creating a new issue, you'll be prompted with a template that suggests some information that is often helpful in making informative bug reports:

- Steps to reproduce the problem
- What you expected to happen
- What actually happened
- Information about your software environment (e.g.: OS, .NET Core, and Quantum Development Kit versions)

You can also [create a pull request](https://help.github.com/articles/about-pull-requests/) to fix the bug directly, if it's very straightforward and is not worth the discussion (for example, a typo).

## Improving Documentation ##

The documentation for the Quantum Development Kit takes on several different forms, such that information is readily available to quantum developers.

Following the principles of [Docs as Code](https://www.writethedocs.org/guide/docs-as-code/), all Quantum Development Kit documentation is formatted as code and is managed using Git in the same way as the source code that is used to build the Quantum Development Kit.
For the most part, the code backing documentation consists of various forms of [Markdown](https://daringfireball.net/projects/markdown/), a language for writing out richly formatted text in a plain text format that's easy to use at the command line, in IDEs, and with source control.
We similarly adopt the [MathJax]() library to allow for formatting mathematics in documentation using the LaTeX language.


That said, each form of documentation does vary somewhat in the details:

- The **conceptual documentation** consists of a set of articles that are published to https://docs.microsoft.com/quantum, and that describe everything from the basics of quantum computing to the technical specifications for interchange formats. These articles are written in [DocFX-Flavored Markdown (DFM)](https://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html), a Markdown variant used for creating rich documentation sets.
- The **API reference** is a set of pages for each Q# function, operation, and user-defined type, published to https://docs.microsoft.com/qsharp/api/. These pages document the inputs and operations to each callable, along with examples and links to more information. The API reference is automatically extracted from small DFM documents in Q# source code as a part of each release.
- The **README<!---->.md** files included with each sample and kata describe how to use that sample or kata is used, what it covers, and how it relates to the rest of the Quantum Development Kit. These files are written using [GitHub Flavored Markdown (GFM)](https://github.github.com/gfm/), a more lightweight alternative to DFM that's popular for attaching documentation directly to code repositories.

To contribute an improvement to the conceptual or README documentation, then, starts with a pull request onto either [**MicrosoftDocs/quantum-docs-pr**](), [**Microsoft/Quantum**](), or [**Microsoft/QuantumKatas**](), as is appropriate.
We'll describe more about pull requests below, but for now there's a few things that are good to keep in mind as you improve documentation:

- Readers come to the Quantum Development Kit documentation from a very wide range of backgrounds. Everyone from high school students looking to learn something new and exciting through to tenured faculty performing quantum computing research should be able to get something out of reading the documentation. To the extent that's possible, please don't assume extensive knowledge on the part of your readers, as they may just be starting out. It's most helpful if you can provide clear and accessible descriptions, or can provide links to other resources for more information.
- **TODO**

To contribute an improvement to the API references, it's most helpful to open a pull request directly on the code being documented.
Each function, operation, or user-defined type supports a documentation comment (denoted with `///` instead of `//`), ... **TODO**.

### LaTeX Formatting ###

**TODO**

## Opening Pull Requests ##

**TODO: describe lightweight (web-based) for small changes, links to GitHub Flow for more extensive work.**

**TODO: PR ettiquette, reviews, etc.**

## Contributing Code ##

**TODO: what makes a good PR?**

**TODO: unit testing, style, documentation, citations, etc.**

**TODO: when do we reject, and why?**

## Recognizing Contributions ##

**TODO: point to relnotes and other thank yous**

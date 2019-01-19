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
We similarly adopt the [MathJax]() library to allow for formatting mathematics in documentation using the LaTeX language, as detailed further below.


That said, each form of documentation does vary somewhat in the details:

- The **conceptual documentation** consists of a set of articles that are published to https://docs.microsoft.com/quantum, and that describe everything from the basics of quantum computing to the technical specifications for interchange formats. These articles are written in [DocFX-Flavored Markdown (DFM)](https://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html), a Markdown variant used for creating rich documentation sets.
- The **API reference** is a set of pages for each Q# function, operation, and user-defined type, published to https://docs.microsoft.com/qsharp/api/. These pages document the inputs and operations to each callable, along with examples and links to more information. The API reference is automatically extracted from small DFM documents in Q# source code as a part of each release.
- The **README<!---->.md** files included with each sample and kata describe how to use that sample or kata is used, what it covers, and how it relates to the rest of the Quantum Development Kit. These files are written using [GitHub Flavored Markdown (GFM)](https://github.github.com/gfm/), a more lightweight alternative to DFM that's popular for attaching documentation directly to code repositories.

### Contributing to the Conceptual Documentation ###

To contribute an improvement to the conceptual or README documentation, then, starts with a pull request onto either [**MicrosoftDocs/quantum-docs-pr**](), [**Microsoft/Quantum**](), or [**Microsoft/QuantumKatas**](), as is appropriate.
We'll describe more about pull requests below, but for now there's a few things that are good to keep in mind as you improve documentation:

- Readers come to the Quantum Development Kit documentation from a very wide range of backgrounds. Everyone from high school students looking to learn something new and exciting through to tenured faculty performing quantum computing research should be able to get something out of reading the documentation. To the extent that's possible, please don't assume extensive knowledge on the part of your readers, as they may just be starting out. It's most helpful if you can provide clear and accessible descriptions, or can provide links to other resources for more information.
- Documentation sets aren't laid out like books or papers, in that readers will arrive in what might seem like the "middle." For example, search engines might not suggest the index, or they might have been sent a link by a friend trying to help them out. Try to help your reader by always providing a clear context, along with links where appropriate.
- Some readers will find abstract statements and definitions most helpful, while other readers work best by extrapolating from concrete examples. Providing both the general case and specific examples can help both readers get the most out of quantum programming.
- Especially if you also wrote the code being documented, things may be obvious to you that are not at all obvious to your reader. There's no one unique best way to program, so no matter how clever or experienced a reader might be, they can't guess at what design patterns you found the most helpful to express your ideas in code. Being clear about how a reader can expect to make use of your code can help provide that context.
- Many members of the quantum programming community are academic researchers, and are recognized mainly through citations for their contributions to the community. In addition to helping readers find additional materials, making sure to properly cite academic outputs such as papers, talks, blog posts, and software tools can help academic contributors to keep doing their best work to improve the community.
- The quantum programming community is a broad and wonderfully diverse community. The use of gendered pronouns in third-person examples (e.g.: "if a user ..., he will ...") can work to exclude rather than include. Being cognizant of people's names in citations and links, and of the correct inclusion of non-ASCII characters can serve the diversity of the community by showing respect to its members. Similarly, many words in the English language are often used in a hateful manner, such that their use in technical documentation can cause harm both to individual readers and to the community at large.

### Contributing to the API References ###

To contribute an improvement to the API references, it's most helpful to open a pull request directly on the code being documented.
Each function, operation, or user-defined type supports a documentation comment (denoted with `///` instead of `//`).
When we compile each release of the Quantum Development Kit, these comments are used to generate the API reference at https://docs.microsoft.com/qsharp/api/, including details about the inputs to and outputs from each callable, the assumptions each callable makes, and examples of how to use them.

> [!IMPORTANT]
> Please make sure to not manually edit the generated API documentation, as these files are overwritten with each new release.
> We value your contribution to the community, and want to make sure that your changes continue to help users release after release.

For example, consider an operation `PrepareTrialState(angles : Double[], register : Qubit[]) : Unit`.
A documentation comment should help a user learn how to interpret `angles`, what the operation assumes about the initial state of `register`, what the effect on `register` is, and so forth.
Each of these different pieces of information can be provided to the Q# compiler by a specially named Markdown section in the documentation comment.
For the example of `PrepareTrialState`, we might write something like the following:

```qsharp
/// # Summary
/// Given a register of qubits, prepares them in a trial state by rotating each
/// independently.
///
/// # Description
/// This operation prepares the input register by performing a
/// $Y$ rotation on each qubit by an angle given in `angles`.
///
/// # Input
/// ## angles
/// An array of parameters
/// ## register
/// A register of qubits initially in the $\ket{00\cdots0}$ state.
///
/// # Example
/// To prepare an equal superposition $\ket{++\cdots+}$ over all input qubits:
/// ```qsharp
/// PrepareTrialState(ConstantArray(Length(register), PI() / 2.0), register);
/// ```
///
/// # Remarks
/// This operation is generally useful in the inner loop of an optimization
/// algorithm.
///
/// # See Also
/// - Microsoft.Quantum.Primitive.Ry
operation PrepareTrialState(angles : Double[], register : Qubit[]) : Unit {
    // ...
}
```

In addition to the general practice of documentation writing, in writing API documentation comments it helps to keep a few things in mind:

- The format of each documentation comment has to match what the Q# compiler expects for your documentation to appear correctly. Some sections, such as `/// # Remarks` allow for freeform content, while sections such as `/// # See Also` section are more restrictive.
- A reader may read your API documentation on the main API reference site, on the summary for each namespace, or even from within their IDE through the use of hover information. Making sure that `/// # Summary` isn't longer than about a sentence helps your reader quickly sort out whether they need to read further or look elsewhere, and can help in quickly scanning through namespace summaries.
- Your documentation may well wind up being much longer than the code itself, but that's OK! Even a small piece of code can have unexpected effects to users that don't know the context in which that code exists. By providing concrete examples and clear explanations, you can help users make the best use of the code that's available to them.

### LaTeX Formatting ###

**TODO**

## Opening Pull Requests ##

All of the documentation for the Quantum Development Kit is managed using the Git version control system through the use of several repositories hosted on GitHub.
Using Git and GitHub together makes it easy to collaborate widely on the Quantum Development Kit.
In particular, any Git repository can be cloned or forked to make a completely independent copy of that repository.
This allows you to work on your contribution with the tools and at a pace that you prefer.

When you're ready, you can send us a request to include your contribution into our repos, using GitHub's _pull request_ functionality.
The page for each pull request includes details of all the changes that make your contribution, a list of comments on your contribution, and a set of review tools that other members of the community can use to provide feedback and advice.

While a full tutorial on Git is beyond the scope of this guide, we can suggest the following links for more resources on learning Git:

- **TODO**

**TODO: describe lightweight (web-based) for small changes, links to GitHub Flow for more extensive work.**

**TODO: PR ettiquette, reviews, etc.**

## Contributing Code ##

**TODO: what makes a good PR?**

**TODO: unit testing, style, documentation, citations, etc.**

**TODO: when do we reject, and why?**

## Release Notes ##

**TODO: point to relnotes**

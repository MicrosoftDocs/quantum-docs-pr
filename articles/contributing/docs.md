---
title: Contributing documentation | Microsoft Docs
description: Contributing documentation
author: cgranade
ms.author: chgranad
ms.date: 10/12/2018
ms.topic: article
uid: microsoft.quantum.contributing.docs
---

# Improving Documentation #

The documentation for the Quantum Development Kit takes on several different forms, such that information is readily available to quantum developers.

Following the principles of [Docs as Code](https://www.writethedocs.org/guide/docs-as-code/), all Quantum Development Kit documentation is formatted as code and is managed using Git in the same way as the source code that is used to build the Quantum Development Kit.
For the most part, the code backing documentation consists of various forms of [Markdown](https://daringfireball.net/projects/markdown/), a language for writing out richly formatted text in a plain text format that's easy to use at the command line, in IDEs, and with source control.
We similarly adopt the [MathJax](https://www.mathjax.org/) library to allow for formatting mathematics in documentation using the LaTeX language, as detailed further below.


That said, each form of documentation does vary somewhat in the details:

- The **conceptual documentation** consists of a set of articles that are published to https://docs.microsoft.com/quantum, and that describe everything from the basics of quantum computing to the technical specifications for interchange formats. These articles are written in [DocFX-Flavored Markdown (DFM)](https://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html), a Markdown variant used for creating rich documentation sets.
- The **API reference** is a set of pages for each Q# function, operation, and user-defined type, published to https://docs.microsoft.com/qsharp/api/. These pages document the inputs and operations to each callable, along with examples and links to more information. The API reference is automatically extracted from small DFM documents in Q# source code as a part of each release.
- The **README<!---->.md** files included with each sample and kata describe how to use that sample or kata is used, what it covers, and how it relates to the rest of the Quantum Development Kit. These files are written using [GitHub Flavored Markdown (GFM)](https://github.github.com/gfm/), a more lightweight alternative to DFM that's popular for attaching documentation directly to code repositories.

## Contributing to the Conceptual Documentation ##

To contribute an improvement to the conceptual or README documentation, then, starts with a pull request onto either [**MicrosoftDocs/quantum-docs-pr**](https://github.com/MicrosoftDocs/quantum-docs-pr/
), [**Microsoft/Quantum**](https://github.com/Microsoft/Quantum), or [**Microsoft/QuantumKatas**](https://github.com/Microsoft/QuantumKatas), as is appropriate.
We'll describe more about pull requests below, but for now there's a few things that are good to keep in mind as you improve documentation:

- Readers come to the Quantum Development Kit documentation from a very wide range of backgrounds. Everyone from high school students looking to learn something new and exciting through to tenured faculty performing quantum computing research should be able to get something out of reading the documentation. To the extent that's possible, please don't assume extensive knowledge on the part of your readers, as they may just be starting out. It's most helpful if you can provide clear and accessible descriptions, or can provide links to other resources for more information.
- Documentation sets aren't laid out like books or papers, in that readers will arrive in what might seem like the "middle." For example, search engines might not suggest the index, or they might have been sent a link by a friend trying to help them out. Try to help your reader by always providing a clear context, along with links where appropriate.
- Some readers will find abstract statements and definitions most helpful, while other readers work best by extrapolating from concrete examples. Providing both the general case and specific examples can help both readers get the most out of quantum programming.
- Especially if you also wrote the code being documented, things may be obvious to you that are not at all obvious to your reader. There's no one unique best way to program, so no matter how clever or experienced a reader might be, they can't guess at what design patterns you found the most helpful to express your ideas in code. Being clear about how a reader can expect to make use of your code can help provide that context.
- Many members of the quantum programming community are academic researchers, and are recognized mainly through citations for their contributions to the community. In addition to helping readers find additional materials, making sure to properly cite academic outputs such as papers, talks, blog posts, and software tools can help academic contributors to keep doing their best work to improve the community.
- The quantum programming community is a broad and wonderfully diverse community. The use of gendered pronouns in third-person examples (e.g.: "if a user ..., he will ...") can work to exclude rather than include. Being cognizant of people's names in citations and links, and of the correct inclusion of non-ASCII characters can serve the diversity of the community by showing respect to its members. Similarly, many words in the English language are often used in a hateful manner, such that their use in technical documentation can cause harm both to individual readers and to the community at large.

## Contributing to the API References ##

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
/// - Microsoft.Quantum.Intrinsic.Ry
operation PrepareTrialState(angles : Double[], register : Qubit[]) : Unit {
    // ...
}
```

In addition to the general practice of documentation writing, in writing API documentation comments it helps to keep a few things in mind:

- The format of each documentation comment has to match what the Q# compiler expects for your documentation to appear correctly. Some sections, such as `/// # Remarks` allow for freeform content, while sections such as `/// # See Also` section are more restrictive.
- A reader may read your API documentation on the main API reference site, on the summary for each namespace, or even from within their IDE through the use of hover information. Making sure that `/// # Summary` isn't longer than about a sentence helps your reader quickly sort out whether they need to read further or look elsewhere, and can help in quickly scanning through namespace summaries.
- Your documentation may well wind up being much longer than the code itself, but that's OK! Even a small piece of code can have unexpected effects to users that don't know the context in which that code exists. By providing concrete examples and clear explanations, you can help users make the best use of the code that's available to them.

<!-- ## LaTeX Formatting ##

**TODO** -->

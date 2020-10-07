---
title: Q# in Research
description: Learn about how to use Q# in research.
author: cgranade
ms.author: chgranad
ms.date: 8/5/2020
ms.topic: article
uid: microsoft.quantum.research
no-loc: ['Q#', '$$v']
---

# Q# in Research

Q# and the Quantum Development Kit are important tools for empowering quantum computing research.
On this page, we list a few resources to help you get the most out of Q# in your research.

## Research features

Here, we highlight some of the Q# features that can help you in your research:

- [**Jupyter Notebook integration**](xref:microsoft.quantum.install.jupyter): Use Q# from within Jupyter Notebook to write examples, debug and diagnose quantum algorithms, and to embed in papers.
- [**Python integration**](xref:microsoft.quantum.install.python): Use Q# together with Python research libraries.
- [**Q# standard libraries**](xref:microsoft.quantum.libraries.standard.intro): Provides implementations of many common quantum subroutines, including iterative and quantum phase estimation, quantum simulation, and amplitude amplification.
- [**Resources estimator**](xref:microsoft.quantum.machines.resources-estimator): Counts resources required to run a given Q# program, including qubit width, $T$-depth, and other metrics.

If there are additional features that would help you out in your research, please let us know by filing a [feature request](https://github.com/microsoft/QuantumLibraries/issues/new?assignees=&labels=enhancement&template=feature_request.md&title=).
If you have implemented a feature, we'd greatly appreciate [your contribution to the Quantum Development Kit](xref:microsoft.quantum.contributing.code).

## Q# and reproducible research

The Quantum Development Kit provides several tools to help include Q# code into a reproducible research workflow:

- [**qsharp.sty**](https://github.com/msr-quarc/qsharp.sty): Syntax highlighting support for LaTeX.
- [**quantum-research-template**](https://github.com/cgranade/quantum-research-template): Example project using Q#, LaTeX, and Python together, pre-configured for use in [Visual Studio Codespaces](https://visualstudio.microsoft.com/services/visual-studio-codespaces/).

## Papers using Q\#

- _Implementing Grover Oracles for Quantum Key Search on AES and LowMC_, Jaques et al. (2020). DOI [10/fmcx](https://doi.org/fcmx).
- _Property-based Testing of Quantum Programs in Q#_, Honarvar, Mousavi, and Nagarajan (2020). DOI [10/fcmz](https://doi.org/fcmz).
Google's arithmetic papers
- _Asymptotically Efficient Quantum Karatsuba Multiplication_, Gidney (2019). arXiv [1904.07356](https://arxiv.org/abs/1904.07356).
- _Q# and NWChem: Tools for Scalable Quantum Chemistry on Quantum Computers_, Low et al. (2019). arXiv [1904.01131](https://arxiv.org/abs/1904.01131).

If you have a paper that uses Q# and that you would like for us to add to this list, please let us know by [filing feedback on the documentation repository](https://github.com/MicrosoftDocs/quantum-docs-pr/issues), or by making a [pull request](https://github.com/MicrosoftDocs/quantum-docs-pr/pulls) with your paper added to the list.
Thank you!

## Citing Q\#

To cite Q# in your research, please use the following BibTeX entry:

```bibtex
@inproceedings{qsharp,
  title = {Q\#: {{Enabling Scalable Quantum Computing}} and {{Development}} with a {{High}}-Level {{DSL}}},
  shorttitle = {Q\#},
  booktitle = {Proceedings of the {{Real World Domain Specific Languages Workshop}} 2018},
  author = {Svore, Krysta and Geller, Alan and Troyer, Matthias and Azariah, John and Granade, Christopher and Heim, Bettina and Kliuchnikov, Vadym and Mykhailova, Mariia and Paz, Andres and Roetteler, Martin},
  year = {2018},
  pages = {7:1--7:10},
  publisher = {{ACM}},
  address = {{New York, NY, USA}},
  doi = {10.1145/3183895.3183901},
  isbn = {978-1-4503-6355-6},
  url = {https://aka.ms/AA5xv44}
}
```
